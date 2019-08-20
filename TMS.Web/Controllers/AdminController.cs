// ***********************************************************************
// Assembly         : TMS.Web
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By :  Almas Shabbir
// Last Modified On : 02-10-2018
// ***********************************************************************
// <copyright file="AdminController.cs" company="LifeLong">
//     Copyright ©  2017
// </copyright>
// <summary>this controller will be used to handle all admin related operations which may includes groups and roles managements</summary>
// ***********************************************************************
using Abp.Web.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMS.Business.Interfaces.Common;
using TMS.Business.Interfaces.Common.Groups;
using TMS.Library.Common.Groups;
using TMS.Library.Entities.Common.Roles;
using lr = Resources.Resources;
using TMS.Web.Core;

namespace TMS.Web.Controllers
{
    [SessionTimeout]
    public class AdminController : TMSControllerBase
    {
        private readonly IGroupsBAL _Groups;

        private readonly IRolesBAL _Roles;
        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController" /> class.
        /// </summary>
        /// <param name="__RolesBAL">The roles bal.</param>
        /// <param name="GroupBAL">The group bal.</param>
        public AdminController(IRolesBAL __RolesBAL, IGroupsBAL GroupBAL)
        {
            _Groups = GroupBAL;
            _Roles = __RolesBAL;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [Authorize]
        public ActionResult Index() => View();

        /// <summary>
        /// Prerequisites this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [Authorize]
        public ActionResult Prerequisite() => View();

        #region "Groups"

        /// <summary>
        /// Groups this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [ClaimsAuthorize("CanViewGroups")]
        public ActionResult Groups() => View();

        /// <summary>
        /// Groups the read.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>ActionResult.</returns>
        [ClaimsAuthorize("CanViewGroups")]
        [DontWrapResult]
        public ActionResult Groups_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            if (CurrentUser.CompanyID > 0)
            {
                var _Phone = _Groups.TMS_GroupsByOrganization_GetAllBAL(CurrentCulture, Convert.ToString(CurrentUser.CompanyID), startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
                return Json(_Phone.ToDataSourceResult(request, ModelState));
            }
            else
            {
                var _Phone = _Groups.TMS_Groups_GetAllBAL(CurrentCulture, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
                return Json(_Phone.ToDataSourceResult(request, ModelState));
            }
        }

        /// <summary>
        /// Groups the create.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="_objGroups">The object groups.</param>
        /// <returns>ActionResult.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditGroups")]
        public ActionResult Groups_Create([DataSourceRequest] DataSourceRequest request, SecurityGroups _objGroups)
        {
            if (ModelState.IsValid)
            {
                _objGroups.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objGroups.CreatedDate = DateTime.Now;
                _objGroups.OrganizationID = CurrentUser.CompanyID;
                _objGroups.AddedByAlias = CurrentUser.Name;
                _objGroups.GroupId = _Groups.TMS_Groups_CreateBAL(_objGroups);//.PersonEmailAddress_CreateBAL(_objGroups);
                //ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
            }
            var resultData = new[] { _objGroups };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        /// <summary>
        /// Groups the update.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="_objGroups">The object groups.</param>
        /// <returns>ActionResult.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditGroups")]
        public ActionResult Groups_Update([DataSourceRequest] DataSourceRequest request, SecurityGroups _objGroups)
        {
            if (ModelState.IsValid)
            {
                _objGroups.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objGroups.UpdatedDate = DateTime.Now;
                var result = _Groups.TMS_Groups_UpdateBAL(_objGroups);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objGroups };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        /// <summary>
        /// Groups the destroy.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="_objGroups">The object groups.</param>
        /// <returns>ActionResult.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
      //  [ActivityAuthorize]
        [ClaimsAuthorize("CanDeleteGroups")]
        public ActionResult Groups_Destroy([DataSourceRequest] DataSourceRequest request, SecurityGroups _objGroups)
        {
          
            if (_Groups.IsDeletedAllow(_objGroups) > 0)
            {
                return Json(lr.UserEmailAlreadyExist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (_objGroups.GroupId <= 3)
                    {
                    }
                    else
                    {

                        _objGroups.UpdatedBy = CurrentUser.NameIdentifierInt64;
                        _objGroups.UpdatedDate = DateTime.Now;
                        var result = _Groups.TMS_Groups_DeleteBAL(_objGroups);
                        if (result == -1)
                        {
                            ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                        }
                    }
                }

                var resultData = new[] { _objGroups };
                return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
            }
        }

        #endregion "Groups"

        #region "GroupDetail"


        [HttpGet]
        [ClaimsAuthorize("CanViewGroupsDetail")]
        public ActionResult GroupDetail(long GroupId)
        {
            //if (string.IsNullOrEmpty(GroupId.ToString()))
            //{
            //    return RedirectPermanent(Url.Content("~/Admin/Groups"));
            //}
            //else
            //{
            //    var GroupData = this._Groups.TMS_Groups_GetbyGroupIdBAL(CurrentCulture, GroupId);
            //    //if (CurrentUser.CompanyID > 0)
            //    //{
            //    //    GroupData = this._Groups.TMS_Groups_GetbyGroupIdBALbyOrg(CurrentCulture, GroupId, Convert.ToString(CurrentUser.CompanyID));
            //    //}
            //    if (GroupData == null)
            //    {
            //        ViewData["model"] = Url.Content("~/Organization/Index");
            //        return View("Static/NotFound");
            //    }
            //    else
            //    {
            //        var PermissionData = this._Groups.SecurityGroupsPermissions_GetAllByGroupIdBAL(CurrentCulture, GroupId);
            //        //if (CurrentUser.CompanyID > 0)
            //        //{
            //        //    PermissionData = this._Groups.SecurityGroupsPermission_GetAllByGroupIdBALbyOrg(CurrentCulture, GroupId, Convert.ToString(CurrentUser.CompanyID));
            //        //}
            //        // ViewData["model"] = PermissionData;
                   Session["GroupId"] = GroupId;
                    ViewData["GroupId"] = GetGroupName(GroupId);
                    return View();
            //    }
            //}
        }

        /// <summary>
        /// Groups the detail.
        /// </summary>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpGet]
        [ClaimsAuthorize("CanViewGroupsDetail")]
        public ActionResult CRMGroupDetail()
        {
            long GroupId = Convert.ToInt64(Session["GroupId"]);
            if (string.IsNullOrEmpty(GroupId.ToString()))
            {
                return RedirectPermanent(Url.Content("~/Admin/Groups"));
            }
            else
            {
                var GroupData = this._Groups.TMS_Groups_GetbyGroupIdBAL(CurrentCulture, GroupId);
                //if (CurrentUser.CompanyID > 0)
                //{
                //    GroupData = this._Groups.TMS_Groups_GetbyGroupIdBALbyOrg(CurrentCulture, GroupId, Convert.ToString(CurrentUser.CompanyID));
                //}
                if (GroupData == null)
                {
                    ViewData["model"] = Url.Content("~/Organization/Index");
                    return View("Static/NotFound");
                }
                else
                {
                    var PermissionData = this._Groups.SecurityGroupsPermissions_GetAllByGroupIdBAL(CurrentCulture, GroupId);
                    //if (CurrentUser.CompanyID > 0)
                    //{
                    //    PermissionData = this._Groups.SecurityGroupsPermission_GetAllByGroupIdBALbyOrg(CurrentCulture, GroupId, Convert.ToString(CurrentUser.CompanyID));
                    //}
                    // ViewData["model"] = PermissionData;
                    ViewData["GroupId"] =GetGroupName(GroupId);
                    return PartialView(PermissionData);
                }
            }
        }
        //[HttpGet]
        //[ClaimsAuthorize("CanViewTMSGroups")]
        //public ActionResult TMSGroupDetail(long GroupId)
        //{
        //    GroupId = Convert.ToInt64(Session["GroupId"]);
        //    return PartialView("TMSGroupDetail",GroupId);
        //}

        [HttpGet]
        [ClaimsAuthorize("CanViewGroupsDetail")]
        public ActionResult TMSGroupDetail()
        {
            long GroupId = Convert.ToInt64(Session["GroupId"]);
            if (string.IsNullOrEmpty(GroupId.ToString()))
            {
                return RedirectPermanent(Url.Content("~/Admin/Groups"));
            }
            else
            {
                var GroupData = this._Groups.TMS_Groups_GetbyGroupIdBAL(CurrentCulture, GroupId);
                //if (CurrentUser.CompanyID > 0)
                //{
                //    GroupData = this._Groups.TMS_Groups_GetbyGroupIdBALbyOrg(CurrentCulture, GroupId, Convert.ToString(CurrentUser.CompanyID));
                //}
                if (GroupData == null)
                {
                    ViewData["model"] = Url.Content("~/Organization/Index");
                    return View("Static/NotFound");
                }
                else
                {
                    var PermissionData = this._Groups.SecurityGroupsPermission_GetAllByGroupIdBAL(CurrentCulture, GroupId);
                    //if (CurrentUser.CompanyID > 0)
                    //{
                    //    PermissionData = this._Groups.SecurityGroupsPermission_GetAllByGroupIdBALbyOrg(CurrentCulture, GroupId, Convert.ToString(CurrentUser.CompanyID));
                    //}
                    // ViewData["model"] = PermissionData;
                    ViewData["GroupId"] =GetGroupName(GroupId);
                    return PartialView(PermissionData);
                }
            }
        }


        /// <summary>
        /// Gets the name of the group.
        /// </summary>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>System.String.</returns>
        [NonAction]
        public string GetGroupName(long GroupId)
        {
            var GroupData = this._Groups.TMS_Groups_GetbyGroupIdBAL(CurrentCulture, GroupId);
            if (CurrentCulture == TMSHelper.PrimaryLangName())
            {
                return GroupData.PrimaryGroupName;
            }
            else
            {
                return GroupData.PrimaryGroupName;
            }
        }
        [HttpPost]
        [ClaimsAuthorize("CanViewGroupsDetail")]
        public ActionResult CRMGroupDetail(List<SecurityGroupsPermission> permissionsList)

        {
            long GroupId = Convert.ToInt64(Session["GroupId"]);
            var ChangesFromDb = permissionsList.Where(x => x.IsChecked != x.NewChecked);//all those whose values are changed this needs to be updated for the database
            var NotPresentInDatabase = ChangesFromDb.Where(x => x.GroupPermissionId == int.MinValue);
            var PresentInDatabase = ChangesFromDb.Where(x => x.GroupPermissionId != int.MinValue);

            if (NotPresentInDatabase.Count() > 0)
            {
                foreach (var data in NotPresentInDatabase)
                {
                    data.GroupId = GroupId;
                    data.IsChecked = data.NewChecked;
                    data.CreatedBy = CurrentUser.NameIdentifierInt64;
                    data.CreatedDate = DateTime.UtcNow;
                    data.GroupPermissionId = this._Groups.TMS_GroupPermissions_CreateDAL(data);
                }
            }
            if (PresentInDatabase.Count() > 0)
            {
                foreach (var data in PresentInDatabase)
                {
                    data.IsChecked = data.NewChecked;
                    data.UpdatedBy = CurrentUser.NameIdentifierInt64;
                    data.UpdatedDate = DateTime.UtcNow;
                    var Result = this._Groups.TMS_GroupPermissions_UpdateBAL(data);
                }
            }

            // ViewData["model"] = permissionsList;
            TempData["Success"] = "Success";
            ViewData["GroupName"] = GetGroupName(GroupId);
            return View(permissionsList);
        }
        /// <summary>
        /// Groups the detail.
        /// </summary>
        /// <param name="permissionsList">The permissions list.</param>
        /// <param name="GroupId">The group identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        [ClaimsAuthorize("CanUpdateGroupsDetail")]
        public ActionResult TMSGroupDetail(List<SecurityGroupsPermission> permissionsList)
        {
            long GroupId = Convert.ToInt64(Session["GroupId"]);
            var ChangesFromDb = permissionsList.Where(x => x.IsChecked != x.NewChecked);//all those whose values are changed this needs to be updated for the database
            var NotPresentInDatabase = ChangesFromDb.Where(x => x.GroupPermissionId == int.MinValue);
            var PresentInDatabase = ChangesFromDb.Where(x => x.GroupPermissionId != int.MinValue);

            if (NotPresentInDatabase.Count() > 0)
            {
                foreach (var data in NotPresentInDatabase)
                {
                    data.GroupId = GroupId;
                    data.IsChecked = data.NewChecked;
                    data.CreatedBy = CurrentUser.NameIdentifierInt64;
                    data.CreatedDate = DateTime.UtcNow;
                    data.GroupPermissionId = this._Groups.TMS_GroupPermissions_CreateDAL(data);
                }
            }
            if (PresentInDatabase.Count() > 0)
            {
                foreach (var data in PresentInDatabase)
                {
                    data.IsChecked = data.NewChecked;
                    data.UpdatedBy = CurrentUser.NameIdentifierInt64;
                    data.UpdatedDate = DateTime.UtcNow;
                    var Result = this._Groups.TMS_GroupPermissions_UpdateBAL(data);
                }
            }

            // ViewData["model"] = permissionsList;
            TempData["Success"] = "Success";
            ViewData["GroupName"] = GetGroupName(GroupId);
            return View(permissionsList);
        }

        #endregion "GroupDetail"

        #region "Roles"

        /// <summary>
        /// Roles this instance.
        /// </summary>
        /// <returns>ActionResult.</returns>
        [DontWrapResult]
        public ActionResult Roles()
        {
            return View();
        }

        /// <summary>
        /// Roles the read.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>ActionResult.</returns>
        [DontWrapResult]
        [ClaimsAuthorize("CanViewRoles")]
        public ActionResult Roles_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var classes = _Roles.Roles_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            if (CurrentUser.CompanyID > 0)
            {
                classes = _Roles.Roles_GetAllBALbyOrganization(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText, Convert.ToString(CurrentUser.CompanyID));
            }
            //var classes = _Roles.Roles_GetAll_BAL(ref Total);
            var result = new DataSourceResult()
            {
                Data = classes, // Process data (paging and sorting applied)
                Total = Total // Total number of records
            };
            return Json(result);
        }

        /// <summary>
        /// Roles the create.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="_objRoles">The object roles.</param>
        /// <returns>ActionResult.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditRoles")]
        public ActionResult Roles_Create([DataSourceRequest] DataSourceRequest request, Roles _objRoles)
        {
            if (ModelState.IsValid)
            {
                _objRoles.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objRoles.CreatedDate = DateTime.Now;
                _objRoles.OrganizationID = CurrentUser.CompanyID;
                _objRoles.AddedByAlias = CurrentUser.Name;

                if (_Roles.Roles_DuplicationCheckBAL(_objRoles) > 0)
                {
                    ModelState.AddModelError(lr.RolesPrimaryName, lr.RolesPrimaryNameDuplicateRole);
                }
                else
                {
                    _objRoles.ID = _Roles.Roles_CreateBAL(_objRoles);
                }
            }
            var resultData = new[] { _objRoles };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        /// <summary>
        /// Roles the update.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="_objRoles">The object roles.</param>
        /// <returns>ActionResult.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditRoles")]
        public ActionResult Roles_Update([DataSourceRequest] DataSourceRequest request, Roles _objRoles)
        {
            if (ModelState.IsValid)
            {
                _objRoles.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objRoles.UpdatedDate = DateTime.Now;

                if (_Roles.Roles_DuplicationCheckBAL(_objRoles) > 0)
                {
                    ModelState.AddModelError(lr.RolesPrimaryName, lr.RolesPrimaryNameDuplicateRole);
                }
                else
                {
                    var result = _Roles.Roles_UpdateBAL(_objRoles);
                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
            }

            var resultData = new[] { _objRoles };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        /// <summary>
        /// Roles the destroy.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="_objRoles">The object roles.</param>
        /// <returns>ActionResult.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanDeleteRoles")]
        public ActionResult Roles_Destroy([DataSourceRequest] DataSourceRequest request, Roles _objRoles)
        {
            if (ModelState.IsValid)
            {
                _objRoles.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objRoles.UpdatedDate = DateTime.Now;
                var result = _Roles.Roles_DeleteBAL(_objRoles);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objRoles };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion "Roles"
    }
}