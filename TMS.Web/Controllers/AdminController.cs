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
using TMS.Business.Interfaces.TMS;
using TMS.Library.Entities.TMS.Persons;
using TMS.Library.Entities.TMS.Course;
using System.Drawing;
using TMS.Library.Entities.TMS.Program;
using TMS.Business.Interfaces.TMS.Program;

namespace TMS.Web.Controllers
{
    [SessionTimeout]
    public class AdminController : TMSControllerBase
    {
        private readonly IGroupsBAL _Groups;
        private readonly IPersonBAL _PersonBAL;
        private readonly IRolesBAL _Roles;
        private readonly ICourseBAL _CourseBAL;
        private readonly ISessionBAL _SessionBAL;
        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController" /> class.
        /// </summary>
        /// <param name="__RolesBAL">The roles bal.</param>
        /// <param name="GroupBAL">The group bal.</param>
        public AdminController(ICourseBAL ICourseBAL, ISessionBAL _ISessionBAL, IRolesBAL __RolesBAL, IGroupsBAL GroupBAL, IPersonBAL objIPersonBAL)
        {
            _SessionBAL = _ISessionBAL;
            _CourseBAL = ICourseBAL;
            _PersonBAL = objIPersonBAL;
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
                var _Phone = _Groups.TMS_GroupsByOrganization_GetAllBAL(request.Page,CurrentCulture, Convert.ToString(CurrentUser.CompanyID), startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
                var result = new DataSourceResult()
                {

                    Data = _Phone,
                    Total = Total
                };
                return Json(result);
            }
            else
            {
                var _Phone = _Groups.TMS_Groups_GetAllBAL(request.Page, CurrentCulture, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
                var result = new DataSourceResult()
                {
                    
                    Data = _Phone,
                    Total = Total
                };
                return Json(result);
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
        /// <summary>
        /// Groups the destroy.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="_objGroups">The object groups.</param>
        /// <returns>ActionResult.</returns>
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        //  [ActivityAuthorize]

        public JsonResult Groups_Destroy_Verify(long _objGroupsID)
        {
            SecurityGroups _objGroups = new SecurityGroups();
            _objGroups.GroupId = _objGroupsID;
            if (_objGroupsID == 1 || _objGroupsID == 20008)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else if (_Groups.IsDeletedAllow(_objGroups) > 0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
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
        //[ClaimsAuthorize("CanViewGroupsDetail")]
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
                    ViewData["GroupId"] = GetGroupName(GroupId);
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
                    var PermissionData = this._Groups.SecurityGroupsPermission_GetAllByGroupIdBAL(CurrentCulture, GroupId,CurrentUser.CompanyID,CurrentUser.NameIdentifierInt64);
                    //if (CurrentUser.CompanyID > 0)
                    //{
                    //    PermissionData = this._Groups.SecurityGroupsPermission_GetAllByGroupIdBALbyOrg(CurrentCulture, GroupId, Convert.ToString(CurrentUser.CompanyID));
                    //}
                    //ViewData["model"] = PermissionData;
                    ViewData["GroupId"] = GetGroupName(GroupId);
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
            //var ChangesFromDb = permissionsList.Where(x => x.IsChecked != x.NewChecked);//all those whose values are changed this needs to be updated for the database
            //var NotPresentInDatabase = ChangesFromDb.Where(x => x.GroupPermissionId == int.MinValue);
            //var PresentInDatabase = ChangesFromDb.Where(x => x.GroupPermissionId != int.MinValue);
            //if (NotPresentInDatabase.Count() <= 0)
            //{
                foreach (var data in permissionsList)
                {
                    data.GroupId = GroupId;
                    data.IsChecked = data.NewChecked;
                    data.CreatedBy = CurrentUser.NameIdentifierInt64;
                    data.CreatedDate = DateTime.UtcNow;
                    data.GroupPermissionId = this._Groups.TMS_GroupPermissions_CreateDAL(data);
                }
            //}
            //else
            //{
            //    if (NotPresentInDatabase.Count() > 0)
            //    {
            //        foreach (var data in NotPresentInDatabase)
            //        {
            //            data.GroupId = GroupId;
            //            data.IsChecked = data.NewChecked;
            //            data.CreatedBy = CurrentUser.NameIdentifierInt64;
            //            data.CreatedDate = DateTime.UtcNow;
            //            data.GroupPermissionId = this._Groups.TMS_GroupPermissions_CreateDAL(data);
            //        }
            //    }
            //    if (PresentInDatabase.Count() > 0)
            //    {
            //        foreach (var data in PresentInDatabase)
            //        {
            //            data.IsChecked = data.NewChecked;
            //            data.UpdatedBy = CurrentUser.NameIdentifierInt64;
            //            data.UpdatedDate = DateTime.UtcNow;
            //            var Result = this._Groups.TMS_GroupPermissions_UpdateBAL(data);
            //        }
            //    }
            //}
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
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanViewTMSAdmin")]
        public ActionResult PersonTrainerTraineeData()
        {
            List<PersonBarData> list = new List<PersonBarData>();
            DateTime date = DateTime.Today;
            int year = date.Year;
            for(int i=1;i<=12;i++)
            {
                
                var firstDayOfMonth = new DateTime(year, i, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                var result = _PersonBAL.PersonBarBAL(firstDayOfMonth, lastDayOfMonth,CurrentUser.CompanyID);
                PersonBarData obj = new PersonBarData();
                obj.month = firstDayOfMonth.ToString("MMM");
                obj.person = result.First().person;
                obj.trainer = result.First().trainer;
                obj.trainee= result.First().trainee;
                list.Add(obj);
            }
            return Json(list);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanViewTMSAdmin")]
        public ActionResult CourseData()
        {

            List<CourseDataBar> list = new List<CourseDataBar>();
            DateTime date = DateTime.Today;
            int year = date.Year;
            for (int i = 1; i <= 12; i++)
            {
               
                var firstDayOfMonth = new DateTime(year, i, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                var result = _CourseBAL.CourseDataBarBAL(firstDayOfMonth, lastDayOfMonth, CurrentUser.CompanyID);
                CourseDataBar obj = new CourseDataBar();
                obj.month = firstDayOfMonth.ToString("MMM");
                obj.CourseCount = result.First().CourseCount;
                var random = new Random();
                var color = String.Format("#{0:X6}", random.Next(0x1000000));
                obj.customColor = color.ToString();
                list.Add(obj);
            }
            return Json(list);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanViewTMSAdmin")]
        public ActionResult CourseFutureData()
        {

            List<CourseDataBar> list = new List<CourseDataBar>();
            DateTime date = DateTime.Today;
            int year = date.Year;
            int c = date.Month;
            for (int i = 1; i <= 12; i++)
            {
                DateTime future = date.AddMonths(i-1);
                var firstDayOfMonth = new DateTime(future.Year, future.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                var result = _CourseBAL.CourseFutureDataBarBAL(firstDayOfMonth, lastDayOfMonth, CurrentUser.CompanyID);
                CourseDataBar obj = new CourseDataBar();
                obj.month = firstDayOfMonth.ToString("MMM-yyyy");
                obj.CourseCount = result.First().CourseCount;
                var random = new Random();
                var color = String.Format("#{0:X6}", random.Next(0x1000000));
                obj.customColor = color.ToString();
                list.Add(obj);
            }
            return Json(list);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanViewTMSAdmin")]
        public ActionResult ClassFutureData()
        {

            List<CourseDataBar> list = new List<CourseDataBar>();
            DateTime date = DateTime.Today;
            int year = date.Year;
            int c = date.Month;
            for (int i = 1; i <= 12; i++)
            {
                DateTime future = date.AddMonths(i - 1);
                var firstDayOfMonth = new DateTime(future.Year, future.Month, 1);
                var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                var result = _CourseBAL.CLassFutureDataBarBAL(firstDayOfMonth, lastDayOfMonth, CurrentUser.CompanyID);
                CourseDataBar obj = new CourseDataBar();
                obj.month = firstDayOfMonth.ToString("MMM-yyyy");
                obj.CourseCount = result.First().CourseCount;
                var random = new Random();
                var color = String.Format("#{0:X6}", random.Next(0x1000000));
                obj.customColor = color.ToString();
                list.Add(obj);
            }
            return Json(list);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanViewTMSAdmin")]
        public ActionResult SessionsData()
        {

            List<SessionWeekBarData> list = new List<SessionWeekBarData>();
            DateTime date = DateTime.Today;
            int year = date.Year;
            var firstDayOfMonth = new DateTime(year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            getweek getweek = new getweek();
            foreach (WeekRange wr in getweek.GetWeekRange(firstDayOfMonth, lastDayOfMonth))
            {
                var result = _SessionBAL.TMS_Sessions_BarBAL(wr.Start.Date.ToString(), wr.End.ToShortDateString(), CurrentUser.CompanyID);
                SessionWeekBarData obj = new SessionWeekBarData();
                obj.week = "Week"+wr.WeekNo;
                obj.sessionsCount = result.First().sessionsCount;
                var random = new Random();
                var color = String.Format("#{0:X6}", random.Next(0x1000000));
                obj.customColor = color.ToString();
                list.Add(obj);
            }
            return Json(list);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanViewTMSAdmin")]
        public ActionResult SchedulePartial()
        {
            return PartialView("Schedule_Read");
        }
        }
}