using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.IO;
using System.Web.Mvc;


using TMS.Business.Interfaces.Common;
using TMS.Business.Interfaces.TMS.Exams;
using TMS.Business.Interfaces.TMS.Organization;
using TMS.Library.Common.Attachment;
using TMS.Library.TMS.Organization;
using TMS.Library.TMS.Organization.POC;
using lr = Resources.Resources;
using TMS.Business.Interfaces.TMS;
using TMS.Library;
using System.Web.Script.Serialization;

namespace TMS.Web.Controllers
{
    public class CourseController :  TMSControllerBase
    {
        private readonly IExamsBAL _ExamsBAL;
        private readonly IBALUsers _UserBAL;
        private readonly IOrganizationBAL OrganizationBAL;
        private readonly IAttachmentBAL _AttachmentBAL;

        public CourseController(IOrganizationBAL IOrganizationBAL, IBALUsers objUserBAL, IAttachmentBAL _AttachmentBAL,IExamsBAL ExamsBAL)
        {
            this.OrganizationBAL = IOrganizationBAL; this._UserBAL = objUserBAL; this._AttachmentBAL = _AttachmentBAL; this._ExamsBAL = ExamsBAL;
        }

        // GET: Course
        public ActionResult ManageCourseRelatedExam()
        {
            var json = new JavaScriptSerializer().Serialize(0);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to read Manage Course Related Exam at" + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            return View();
        }

        [ClaimsAuthorizeAttribute("CanViewOrganizationDetail")]
        public ActionResult Detail(long oid)
        {
            if (string.IsNullOrEmpty(oid.ToString()))
            {
                return RedirectPermanent(Url.Content("~/Organization/Index"));
            }
            else
            {
                var data = this.OrganizationBAL.GetOrganizationByIdBAL(oid);
                if (data == null)
                {
                    ViewData["model"] = Url.Content("~/Organization/Index");
                    return View("Static/NotFound");
                }
                else
                {
                    var json = new JavaScriptSerializer().Serialize(0);
                    _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to read detail Manage Course Related Exam at" + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                    ViewData["model"] = data;
                    return View();
                }
            }
        }

        [ClaimsAuthorizeAttribute("CanViewOrganization")]
        [DontWrapResult]
        public ActionResult Organization_Read([DataSourceRequest] DataSourceRequest request)
        {
            var json = new JavaScriptSerializer().Serialize(0);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to read organization at" + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            var _Organization = this._ExamsBAL.GetAllOrganizationBAL();
            return Json(_Organization.ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorizeAttribute("CanAddEditOrganization")]
        [DontWrapResult]
        public ActionResult Organization_Create([DataSourceRequest] DataSourceRequest request, OrganizationModel _Organization, string filename, long aid)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_Organization);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to create organization at" + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                bool _valid = false;
                if (_Organization.P_Name != null)//when Email is Provided
                {
                    _valid = true;
                }
                else if (_Organization.ShortName != null)//when Contact number is provided
                {
                    _valid = true;
                }
                else
                {
                    ModelState.AddModelError(lr.OrganizationFullName, lr.OrganizationEnterFullNameOrShortName);
                }
                if (_valid)
                {
                    if (_Organization.P_Name != null)
                    {
                        if (_Organization.ShortName == null)
                        {
                            _Organization.FullName = _Organization.P_Name;
                        }
                        else
                        {
                            _Organization.FullName = _Organization.P_Name + " (" + _Organization.ShortName + ")";
                        }
                    }
                    else
                    {
                        _Organization.FullName = _Organization.ShortName;
                    }
                    _Organization.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _Organization.CreatedDate = DateTime.Now;
                    string _profilePict = string.Empty;
                    _Organization.ID = this.OrganizationBAL.Organizations_CreateBAL(_Organization);
                    _Organization.LogoPicture = HandleOrganizationIndexLogo(filename, _Organization.ID, aid);
                }
            }

            var resultData = new[] { _Organization };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorizeAttribute("CanAddEditOrganization")]
        [DontWrapResult]
        public ActionResult Organization_Update([DataSourceRequest] DataSourceRequest request, OrganizationModel _Organization, string filename, long aid)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_Organization);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to update organization at" + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                bool _valid = false;
                if (_Organization.P_Name != null)//when Email is Provided
                {
                    _valid = true;
                }
                else if (_Organization.ShortName != null)//when Contact number is provided
                {
                    _valid = true;
                }
                else
                {
                    ModelState.AddModelError(lr.OrganizationFullName, lr.OrganizationEnterFullNameOrShortName);
                }
                if (_valid)
                {
                    if (_Organization.P_Name != null)
                    {
                        if (_Organization.ShortName == null)
                        {
                            _Organization.FullName = _Organization.P_Name;
                        }
                        else
                        {
                            _Organization.FullName = _Organization.P_Name + " (" + _Organization.ShortName + ")";
                        }
                    }
                    else
                    {
                        _Organization.FullName = _Organization.ShortName;
                    }
                    _Organization.UpdatedBy = CurrentUser.NameIdentifierInt64;
                    _Organization.UpdatedDate = DateTime.Now;
                    string _profilePict = string.Empty;
                    this.OrganizationBAL.Organizations_UpdateBAL(_Organization);
                    if (!string.IsNullOrEmpty(filename))
                        _Organization.LogoPicture = HandleOrganizationLogo(filename, _Organization.ID, aid);
                }
            }

            var resultData = new[] { _Organization };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorizeAttribute("CanDeleteOrganization")]
        public ActionResult Organization_Destroy([DataSourceRequest] DataSourceRequest request, OrganizationModel _Organization)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(0);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Delete_Success.ToString(), System.Environment.MachineName, "User tried to destroy organization at" + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                _Organization.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Organization.UpdatedDate = DateTime.Now;
                var result = this.OrganizationBAL.Organizations_DeleteBAL(_Organization);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _Organization };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [NonAction]
        public string HandleOrganizationIndexLogo(string picturename, long OrganizationId, long aid)//handle in case of new is created
        {
            if (!string.IsNullOrEmpty(picturename))
            {
                var _aatchedFromDB = _AttachmentBAL.TMS_Attachment_GetSingleByIdAndTypeBAL(aid);

                var newparentroot = DateTime.Now.Ticks.ToString();
                var physicalPath = Path.Combine(Server.MapPath("~/UploadTempFolder"));
                string strSource = physicalPath + "/" + _aatchedFromDB.FileParentRootFolder + "/" + _aatchedFromDB.FileName;
                string targetString = "~/Attachment/TMS/Organization/" + OrganizationId + "/Profile/" + newparentroot + "/";
                string targetSource = Utility.CreateDirectory(Path.Combine(Server.MapPath(targetString))) + _aatchedFromDB.FileName;
                Utility.MoveAttachment(strSource, targetSource, false);
                System.IO.DirectoryInfo di = new DirectoryInfo(physicalPath + "/" + _aatchedFromDB.FileParentRootFolder);
                di.Delete();
                _AttachmentBAL.TMS_Attachment_CompletedOrganizationLogoBAL(new TMS_Attachments { CompletedDate = DateTime.Now, ID = aid, OpenID = OrganizationId, OpenType = 2, FileParentRootFolder = newparentroot, FilePath = targetString });
                var model = _AttachmentBAL.TMS_Attachment_GetSingleByIdAndTypeBAL(aid);
                return model.FilePath.Replace("~/", "") + model.FileName;
            }
            return "/images/i/people.png";
        }

        [NonAction]
        public string HandleOrganizationLogo(string picturename, long OrganizationId, long aid)//handle in case of update organization
        {
            if (!string.IsNullOrEmpty(picturename))
            {
                var model = _AttachmentBAL.TMS_Attachment_GetSingleByIdAndTypeBAL(aid);
                _AttachmentBAL.TMS_Attachment_CompletedProfileLogoBAL(new TMS_Attachments { CompletedDate = DateTime.Now, ID = aid, OpenID = OrganizationId, OpenType = 2 });
                return model.FilePath.Replace("~/", "") + model.FileName;
            }
            return "/images/i/people.png";
        }

        [ContentAuthorize]
        [ClaimsAuthorize("CanViewOrganizationAttachments", "CanViewOrganizationNotes")]
        public ActionResult Others(string oid)
        {
            return PartialView("_DetailOthers", oid);
        }

        #region "Point of Contact"

        [ContentAuthorize]
        [ClaimsAuthorizeAttribute("CanViewPointofContact")]
        public ActionResult PointOfContact(string oid)
        {
            var json = new JavaScriptSerializer().Serialize(oid);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to read point of contact at" + DateTime.UtcNow+" with user id ="+CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            return PartialView("_PointOfContact", oid);
        }

        [DontWrapResult]
        [ClaimsAuthorizeAttribute("CanViewPointofContact")]
        public ActionResult PointOfContact_Read([DataSourceRequest] DataSourceRequest request, string oid)
        {
            var json = new JavaScriptSerializer().Serialize(oid);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to read point of contact at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            var _Organization = this.OrganizationBAL.GetPointOfContactByOrganizationIdBAL(Convert.ToInt64(oid));
            return Json(_Organization.ToDataSourceResult(request, ModelState));
        }

        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorizeAttribute("CanAddEditPointofContact")]
        public ActionResult PointOfContact_Create([DataSourceRequest] DataSourceRequest request, PointsOfContact _PointsOfContact, string oid)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_PointsOfContact);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to create point of contact at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                _PointsOfContact.OrganizationID = Convert.ToInt64(oid);
                if (this.OrganizationBAL.PointOfContact_DuplicationCheckBAL(_PointsOfContact) == 0)
                {
                    _PointsOfContact.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _PointsOfContact.CreatedDate = DateTime.Now;
                    _PointsOfContact.ID = this.OrganizationBAL.PointOfContact_CreateBAL(_PointsOfContact);
                }
                else
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.PointofContactDuplicationMessage);
                }
            }

            var resultData = new[] { _PointsOfContact };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [ActivityAuthorize]
        [DontWrapResult]
        [ClaimsAuthorizeAttribute("CanAddEditPointofContact")]
        public ActionResult PointOfContact_Update([DataSourceRequest] DataSourceRequest request, PointsOfContact _PointsOfContact)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_PointsOfContact);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Update_Success.ToString(), System.Environment.MachineName, "User tried to update point of contact at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                _PointsOfContact.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _PointsOfContact.UpdatedDate = DateTime.Now;
                var result = this.OrganizationBAL.PointOfContact_UpdateBAL(_PointsOfContact);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }

            var resultData = new[] { _PointsOfContact };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ActivityAuthorize]
        [DontWrapResult]
        [ClaimsAuthorizeAttribute("CanDeletePointofContact")]
        public ActionResult PointOfContact_Destroy([DataSourceRequest] DataSourceRequest request, PointsOfContact _PointsOfContact)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_PointsOfContact);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Delete_Success.ToString(), System.Environment.MachineName, "User tried to destroy point of contact at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                _PointsOfContact.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _PointsOfContact.UpdatedDate = DateTime.Now;
                var result = this.OrganizationBAL.PointOfContact_DeleteBAL(_PointsOfContact);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }

            var resultData = new[] { _PointsOfContact };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        #endregion "Point of Contact"
    }
}