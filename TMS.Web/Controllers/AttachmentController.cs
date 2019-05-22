using Abp.Runtime.Validation;
using Abp.Web.Models;
using Abp.Web.Security.AntiForgery;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.IO;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using TMS.Business.Interfaces.Common;
using TMS.Library;
using TMS.Library.Common.Attachment;
using TMS.Web.Core;
using lr = Resources.Resources;
namespace TMS.Web.Controllers
{
    public class AttachmentController : Controller
    {
        private readonly IAttachmentBAL _AttachmentBAL;

        public AttachmentController(IAttachmentBAL objIAttachmentBAL)
        {
            _AttachmentBAL = objIAttachmentBAL;
        }

        protected TMSUser CurrentUser
        {
            get
            {
                return new TMSUser(this.User as ClaimsPrincipal);
            }
        }

        #region "Open Attachments"
        [DontWrapResult]
        [ContentAuthorize]
        [ClaimsAuthorize("CanViewPersonAttachments", "CanViewOrganizationAttachments")]
        public ActionResult OpenAttachments(string OpenId,int Opentype)
        {
            ViewData["OpenType"] = Opentype;
            return PartialView("_Attachments", OpenId);
        }
        [DontWrapResult]
        public ActionResult Attachments_Read([DataSourceRequest] DataSourceRequest request, int Opentype, long OpenId)
        {
            var TMS_Attachment = _AttachmentBAL.TMS_Attachment_GetByIdAndTypeBAL(OpenId, Opentype);
            return Json(TMS_Attachment.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonAttachments", "CanAddEditOrganizationAttachments")]
        public ActionResult Attachment_Create([DataSourceRequest] DataSourceRequest request, TMS_Attachments _TMS_Attachments, string parentFoldername, long aid)
        {
            if (ModelState.IsValid)
            {
                _TMS_Attachments.CompletedDate = DateTime.Now;
                if (_TMS_Attachments.ValidTill == null)
                {
                  _TMS_Attachments.ValidTill= DateTime.Now.AddMonths(TMSHelper.AttachmentValidTillPeriodInMonths());
                }
                _TMS_Attachments.ID = aid;
                _TMS_Attachments.FileParentRootFolder = parentFoldername;
                _AttachmentBAL.TMS_Attachment_CompletedBAL(_TMS_Attachments);
            }
            var resultData = new[] { _TMS_Attachments };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonAttachments", "CanAddEditOrganizationAttachments")]
        public ActionResult Attachment_Update([DataSourceRequest] DataSourceRequest request, TMS_Attachments _TMS_Attachments, string parentFoldername, long aid)
        {
            if (ModelState.IsValid)
            {
                _TMS_Attachments.CompletedDate = DateTime.Now;
                _TMS_Attachments.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _TMS_Attachments.UpdatedDate = DateTime.Now;
                int result;
                if (_TMS_Attachments.FileType == AttachmentsFileType.AttachmentsFileType_ProfilePicture)
                {
                    _TMS_Attachments.ValidTill = DateTime.Now.AddMonths(TMSHelper.AttachmentValidTillPeriodInMonths());
                    _TMS_Attachments.ID = aid;
                    result = _AttachmentBAL.TMS_Attachment_CompletedProfileLogoBAL(_TMS_Attachments);
                }
                else
                {
                    result = _AttachmentBAL.TMS_Attachment_UpdateBAL(_TMS_Attachments);
                }
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _TMS_Attachments };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanDeletePersonAttachments", "CanDeleteOrganizationAttachments")]
        public ActionResult Attachment_Destroy([DataSourceRequest] DataSourceRequest request, TMS_Attachments _TMS_Attachments)
        {
            if (ModelState.IsValid)
            {
                _TMS_Attachments.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _TMS_Attachments.UpdatedDate = DateTime.Now;

                var result = _AttachmentBAL.TMS_Attachment_DeleteBAL(_TMS_Attachments);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _TMS_Attachments };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region"Handle Attachment Open Save/Remove"
        public ActionResult TMSSaveAttachment(HttpPostedFileBase fileupload,long oid,int otype,int fileType)
        {
            var extention = Path.GetExtension(fileupload.FileName);
            TMS_Attachments _Attachments = new TMS_Attachments
            {
                FileParentRootFolder = DateTime.Now.Ticks.ToString()
            };
            string targetString;
            if (otype == 1)
            {
                targetString = "~/Attachment/TMS/Person/" + oid + "/Attachment/"+_Attachments.FileParentRootFolder+"/";
            }
            else
            {
                targetString = "~/Attachment/TMS/Organization/" + oid + "/Attachment/" + _Attachments.FileParentRootFolder + "/"; ;
            }
            string targetSource = Utility.CreateDirectory(Path.Combine(Server.MapPath(targetString)));
            var physicalPath = Path.Combine(targetSource, fileupload.FileName);
            _Attachments.CreatedBy=CurrentUser.NameIdentifierInt64;
            _Attachments.CreatedDate= DateTime.Now;
            _Attachments.FileExtension = Path.GetExtension(fileupload.FileName);
            _Attachments.FileName=fileupload.FileName;
            _Attachments.FilePath = targetString;
            _Attachments.FileSize=fileupload.ContentLength;
            _Attachments.FileType=(AttachmentsFileType)fileType;
            _Attachments.OpenID=oid;
            _Attachments.OpenType=otype;
            var result = _AttachmentBAL.TMS_Attachment_CreateBAL(_Attachments);
            fileupload.SaveAs(physicalPath);
            return Json(new { parentFoldername = _Attachments.FileParentRootFolder, aid = result }, "text/plain");
        }
        public ActionResult RemoveTMSAttachment(string parentFoldername, string fileNames, long oid, int Opentype, long aid)
        {
            RemoveTMSFileFromDisk(parentFoldername, fileNames, oid, Opentype, aid);
            return Content("");
        }
        [NonAction]
        internal void RemoveTMSFileFromDisk(string parentFoldername, string name, long oid, int Opentype,long aid)
        {
            string targetPath;
            if (Opentype == 1)
            {
                targetPath = "~/Attachment/TMS/Person/" + oid + "/Attachment/" + parentFoldername + "/";
            }
            else
            {
                targetPath = "~/Attachment/TMS/Organization/" + oid + "/Attachment/" + parentFoldername + "/"; ;
            }
            var fileName = Path.GetFileName(name);
            var physicalPath = Path.Combine(Server.MapPath(targetPath));
            if (System.IO.File.Exists(physicalPath + "/" + name))
            {
                
                System.IO.File.Delete(physicalPath + "/" + name);
                TMS_Attachments _Attachments = new TMS_Attachments
                {
                    UpdatedBy = CurrentUser.NameIdentifierInt64,
                    UpdatedDate = DateTime.Now,
                    ID = aid
                };
                _AttachmentBAL.TMS_Attachment_DeleteBAL(_Attachments);
                System.IO.DirectoryInfo di = new DirectoryInfo(physicalPath);
                di.Delete();
            }
        }

        public ActionResult RemovePictureAndLogo(string parentFoldername, string fileNames, long oid, int Opentype, long aid)
        {
            RemoveTMSFileFromDiskLogoProfile(parentFoldername, fileNames, oid, Opentype, aid);
            return Content("");
        }
        [NonAction]
        internal void RemoveTMSFileFromDiskLogoProfile(string parentFoldername, string name, long oid, int Opentype, long aid)
        {
            string targetPath;
            if (Opentype == 1)
            {
                targetPath = "~/Attachment/TMS/Person/" + oid + "/Profile/" + parentFoldername + "/";
            }
            else
            {
                targetPath = "~/Attachment/TMS/Organization/" + oid + "/Profile/" + parentFoldername + "/"; ;
            }
            var fileName = Path.GetFileName(name);
            var physicalPath = Path.Combine(Server.MapPath(targetPath));
            if (System.IO.File.Exists(physicalPath + "/" + name))
            {

                System.IO.File.Delete(physicalPath + "/" + name);
                TMS_Attachments _Attachments = new TMS_Attachments
                {
                    UpdatedBy = CurrentUser.NameIdentifierInt64,
                    UpdatedDate = DateTime.Now,
                    ID = aid
                };
                _AttachmentBAL.TMS_Attachment_DeleteBAL(_Attachments);
                System.IO.DirectoryInfo di = new DirectoryInfo(physicalPath);
                di.Delete();
            }
        }

        public ActionResult SavePictureAndLogo(HttpPostedFileBase fileupload, long oid, int otype)//this is called once person or organization have the id
        {
            var extention = Path.GetExtension(fileupload.FileName);
            TMS_Attachments _Attachments = new TMS_Attachments
            {
                FileParentRootFolder = DateTime.Now.Ticks.ToString()
            };
            string targetString;
            if (otype == 1)
            {
                targetString = "~/Attachment/TMS/Person/" + oid + "/Profile/" + _Attachments.FileParentRootFolder + "/";
            }
            else
            {
                targetString = "~/Attachment/TMS/Organization/" + oid + "/Profile/" + _Attachments.FileParentRootFolder + "/"; ;
            }
            string targetSource = Utility.CreateDirectory(Path.Combine(Server.MapPath(targetString)));
            var physicalPath = Path.Combine(targetSource, fileupload.FileName);
            _Attachments.CreatedBy = CurrentUser.NameIdentifierInt64;
            _Attachments.CreatedDate = DateTime.Now;
            _Attachments.FileExtension = Path.GetExtension(fileupload.FileName);
            _Attachments.FileName = fileupload.FileName;
            _Attachments.FilePath = targetString;
            _Attachments.FileSize = fileupload.ContentLength;
            _Attachments.FileType = AttachmentsFileType.AttachmentsFileType_ProfilePicture;
            _Attachments.OpenID = oid;
            _Attachments.OpenType = otype;
            var result = _AttachmentBAL.TMS_Attachment_CreateBAL(_Attachments);
            fileupload.SaveAs(physicalPath);
            return Json(new { parentFoldername = _Attachments.FileParentRootFolder, aid = result }, "text/plain");
        }

        public ActionResult SaveOrganizationLogo(HttpPostedFileBase fileupload)//this is called on Organization grid when organization was not created
        {
            var extention = Path.GetExtension(fileupload.FileName);
            TMS_Attachments _Attachments = new TMS_Attachments
            {
                FileParentRootFolder = DateTime.Now.Ticks.ToString()
            };
            string targetString;
            targetString = "~/UploadTempFolder/" + _Attachments.FileParentRootFolder + "/";
            string targetSource = Utility.CreateDirectory(Path.Combine(Server.MapPath(targetString)));
            var physicalPath = Path.Combine(targetSource, fileupload.FileName);
            _Attachments.CreatedBy = CurrentUser.NameIdentifierInt64;
            _Attachments.CreatedDate = DateTime.Now;
            _Attachments.FileExtension = Path.GetExtension(fileupload.FileName);
            _Attachments.FileName = fileupload.FileName;
            _Attachments.FilePath = targetString;
            _Attachments.FileSize = fileupload.ContentLength;
            _Attachments.FileType = AttachmentsFileType.AttachmentsFileType_ProfilePicture;
            _Attachments.OpenID = -1;
            _Attachments.OpenType = 2;
            var result = _AttachmentBAL.TMS_Attachment_CreateBAL(_Attachments);
            fileupload.SaveAs(physicalPath);
            return Json(new { parentFoldername = _Attachments.FileParentRootFolder, aid = result }, "text/plain");
        }

        public ActionResult RemoveOrganizationLogo(long aid)
        {
            RemoveTMSFileFromDiskLogoOnly(aid);
            return Content("");
        }
        [NonAction]
        internal void RemoveTMSFileFromDiskLogoOnly(long aid)
        {
            var model = _AttachmentBAL.TMS_Attachment_GetSingleByIdAndTypeBAL(aid);
            
            string targetPath= model.FilePath;

            var fileName = model.FileName;
            var physicalPath = Path.Combine(Server.MapPath(targetPath));
            if (System.IO.File.Exists(physicalPath + "/" + fileName))
            {

                System.IO.File.Delete(physicalPath + "/" + fileName);
                TMS_Attachments _Attachments = new TMS_Attachments
                {
                    UpdatedBy = CurrentUser.NameIdentifierInt64,
                    UpdatedDate = DateTime.Now,
                    ID = aid
                };
                _AttachmentBAL.TMS_Attachment_DeleteBAL(_Attachments);
                System.IO.DirectoryInfo di = new DirectoryInfo(physicalPath);
                di.Delete();
            }
        }
        #endregion
    }
}