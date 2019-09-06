using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.IO;
using System.Web.Mvc;
using TMS.Business.Interfaces.Common;
using TMS.Business.Interfaces.TMS.Organization;
using TMS.Library.Common.Attachment;
using TMS.Library.TMS.Organization;
using TMS.Library.TMS.Organization.POC;
using TMS.Web.Core;
using lr = Resources.Resources;

namespace TMS.Web.Controllers
{
    [SessionTimeout]
    public class OrganizationController : TMSControllerBase
    {
        private readonly IOrganizationBAL OrganizationBAL;
        private readonly IAttachmentBAL _AttachmentBAL;

        public OrganizationController(IOrganizationBAL IOrganizationBAL, IAttachmentBAL _AttachmentBAL)
        {
            this.OrganizationBAL = IOrganizationBAL; this._AttachmentBAL = _AttachmentBAL;
        }

        [ClaimsAuthorizeAttribute("CanViewOrganization")]
        public ActionResult Index()
        {
            // var logopicture = this.OrganizationBAL.GetAllOrganizationbypicBAL(CurrentUser.CompanyID);
            //   Session["logo"] = logopicture;

            return View();
        }

        [ClaimsAuthorizeAttribute("CanViewOrganizationDetail")]
        public ActionResult Detail(long oid)
        {
            /// TMS.Library.TMS.Organization.OrganizationModel mod = new OrganizationModel();
            //  Session["logo"] = mod.LogoPicture;
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
                    ViewData["model"] = data;
                    return View();
                }
            }
        }

        [ClaimsAuthorizeAttribute("CanViewOrganization")]
        [DontWrapResult]
        public ActionResult Organization_Read([DataSourceRequest] DataSourceRequest request)
        {
            // TMS.Library.TMS.Organization.OrganizationModel mod = new OrganizationModel();
            //  Session["logo"] = mod.LogoPicture;
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }

            if (CurrentUser.CompanyID > 0)
            {
                var _Organization = this.OrganizationBAL.GetAllOrganizationbyIDBAL(Convert.ToString(CurrentUser.CompanyID), SearchText);
                return Json(_Organization.ToDataSourceResult(request, ModelState));
            }
            else
            {
                var _Organization = this.OrganizationBAL.GetAllOrganizationBAL(SearchText);
                return Json(_Organization.ToDataSourceResult(request, ModelState));
            }
        }

        [ClaimsAuthorizeAttribute("CanAddOrganization")]
        [DontWrapResult]
        public ActionResult Organization_Create([DataSourceRequest] DataSourceRequest request, OrganizationModel _Organization, string filename, long aid)
        {
            if (ModelState.IsValid)
            {
                var _OrganizationDub = OrganizationBAL.GetAllOrganizationbyIDBAL(Convert.ToString(CurrentUser.CompanyID), "");
                bool flage = true;
                foreach (var x in _OrganizationDub)
                {
                    string str = x.P_Name;
                    if (str == _Organization.P_Name)
                    {
                        flage = false;
                        break;
                    }
                }
                if (flage == false)
                {
                    ModelState.AddModelError(lr.OrganizationNameDublicaton, lr.OrganizationNameDublicaton);
                }
                else
                {


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
                        _Organization.UpdatedBy = CurrentUser.NameIdentifierInt64;
                        _Organization.UpdatedDate = DateTime.Now;
                        _Organization.CompanyID = CurrentUser.CompanyID;
                        //   string _profilePict = string.Empty;
                        // _Organization.LogoPicture = HandleOrganizationIndexLogo(filename, _Organization.ID, aid);
                        _Organization.ID = this.OrganizationBAL.Organizations_CreateBAL(_Organization);
                        var _profilePict = HandleOrganizationIndexLogo(filename, _Organization.ID, aid);

                        if (!string.IsNullOrEmpty(_profilePict))
                        {
                            _Organization.LogoPicture = _profilePict;
                            var res = this.OrganizationBAL.Org_UpdateProfileImageBAL(_Organization);
                            _Organization.LogoPicture = _profilePict.Replace("~/", "");
                        }
                        else { _Organization.LogoPicture = null; }
                    }
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
                var _OrganizationDub = OrganizationBAL.GetAllOrganizationbyIDBAL(Convert.ToString(CurrentUser.CompanyID), "");
                bool flage = true;
                foreach (var x in _OrganizationDub)
                {
                    string str = x.P_Name;
                    long OrgId = x.ID;

                    if (str == _Organization.P_Name)
                    {
                        if (OrgId != _Organization.ID)
                        {
                            flage = false;
                            break;
                        }

                    }
                }
                if (flage == false)
                {
                    ModelState.AddModelError(lr.OrganizationNameDublicaton, lr.OrganizationNameDublicaton);
                }
                else
                {
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
            return PartialView("_PointOfContact", oid);
        }

        [DontWrapResult]
        [ClaimsAuthorizeAttribute("CanViewPointofContact")]
        public ActionResult PointOfContact_Read([DataSourceRequest] DataSourceRequest request, string oid)
        {
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
                _PointsOfContact.OrganizationID = Convert.ToInt64(oid);
                if (_PointsOfContact.PersonID == CurrentUser.NameIdentifierInt64)
                {
                    ModelState.AddModelError(lr.PointOfContactAssignIssue, lr.CurrentUserPointOfContactAssignIssue);
                }
                else
                {
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
                if (_PointsOfContact.PersonID == CurrentUser.NameIdentifierInt64)
                {
                    ModelState.AddModelError(lr.PointOfContactAssignIssue, lr.CurrentUserPointOfContactAssignIssue);
                }
                else
                {
                    _PointsOfContact.UpdatedBy = CurrentUser.NameIdentifierInt64;
                    _PointsOfContact.UpdatedDate = DateTime.Now;
                    var result = this.OrganizationBAL.PointOfContact_UpdateBAL(_PointsOfContact);
                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
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


        #region "Resources"

        [ContentAuthorize]
        [ClaimsAuthorizeAttribute("CanViewPointofContact")]
        public ActionResult Resources(string oid)
        {
            return PartialView("_Resources", oid);
        }

        //[DontWrapResult]
        //public ActionResult Resource_Read([DataSourceRequest] DataSourceRequest request)
        //{

        //    var SearchText = Request.Form["SearchText"];

        //    var startRowIndex = (request.Page - 1) * request.PageSize;
        //    var value = GridHelper.GetSortExpression(request, "P_Resourceid");
        //    int Total = 0;
        //    var resources = _objeResources.GetTMSResourceBAL(request.Page, request.PageSize, ref Total, SearchText).ToList();
        //    if (CurrentUser.CompanyID > 0)
        //    {
        //        resources = _objeResources.GetTMSResourceBALbyOrganization(request.Page, request.PageSize, ref Total, Convert.ToString(CurrentUser.CompanyID), SearchText).ToList();
        //    }


        //    // var startRowIndex = (request.Page - 1) * request.PageSize;
        //    //var value = GridHelper.GetSortExpression(request, "P_Resourceid");
        //    //int Total = 0;
        //    //var resources = _objeResources.GetTMSResourceBAL(startRowIndex, request.PageSize, ref Total, value, SearchText);
        //    //if (CurrentUser.CompanyID > 0)
        //    //{
        //    //    resources = _objeResources.GetTMSResourceBALbyOrganization(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "IDP_Resourceid"), SearchText, Convert.ToString(CurrentUser.CompanyID)).ToList();
        //    //}

        //    if (request.Sorts.Any())
        //    {
        //        foreach (SortDescriptor sortDescriptor in request.Sorts)
        //        {
        //            if (sortDescriptor.SortDirection == ListSortDirection.Ascending)
        //            {
        //                switch (sortDescriptor.Member)
        //                {
        //                    case "Name":
        //                        resources = resources.OrderBy(order => order.Name).ToList();
        //                        break;
        //                    case "P_Value":
        //                        resources = resources.OrderBy(order => order.P_Value).ToList();
        //                        break;
        //                    case "S_Value":
        //                        resources = resources.OrderBy(order => order.S_Value).ToList();
        //                        break;
        //                    case "CreatedDate":
        //                        resources = resources.OrderBy(order => order.CreatedDate).ToList();
        //                        break;
        //                    case "CreatedBy":
        //                        resources = resources.OrderBy(order => order.CreatedBy).ToList();
        //                        break;
        //                }
        //            }
        //            else
        //            {
        //                switch (sortDescriptor.Member)
        //                {
        //                    case "Name":
        //                        resources = resources.OrderByDescending(order => order.Name).ToList();
        //                        break;
        //                    case "P_Value":
        //                        resources = resources.OrderByDescending(order => order.P_Value).ToList();
        //                        break;
        //                    case "S_Value":
        //                        resources = resources.OrderByDescending(order => order.S_Value).ToList();
        //                        break;
        //                    case "CreatedDate":
        //                        resources = resources.OrderByDescending(order => order.CreatedDate).ToList();
        //                        break;
        //                    case "CreatedBy":
        //                        resources = resources.OrderByDescending(order => order.CreatedBy).ToList();
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //EF cannot page unsorted data.
        //        resources = resources.OrderBy(o => o.P_Resourceid).ToList();
        //    }
        //    var result = new DataSourceResult()
        //    {
        //        Data = resources, // Process data (paging and sorting applied)
        //        Total = Total // Total number of records

        //    };

        //    return Json(result);
        //}


        #endregion "Resources"
    }
}