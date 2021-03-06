﻿using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Web.Mvc;
using TMS.Business.Interfaces.TMS;
using TMS.Business.Interfaces.TMS.Program;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS;
using lr = Resources.Resources;
using TMS.Library.Entities.Language;
using TMS.Library.Entities.Coordinator;
using TMS.Library.Entities.Common.Configuration;
using System.Collections.Generic;
using TMS.Library;
using TMS.Library.TMS.Persons;
using TMS.Business.Interfaces.Common.Configuration;
using Abp.Runtime.Validation;
using TMS.Web.Core;
using TMS.Library.Entities.Common.Roles;
using System.Web.Script.Serialization;
using System.Globalization;
using System.Linq;
using TMS.Business.Interfaces;

namespace TMS.Web.Controllers
{
    [SessionTimeout]
    public class ProgramController : TMSControllerBase
    {
        private readonly ICourseBAL _CourseBAL;
        private readonly IClassBAL _ClassBAL;
        private readonly ISessionBAL _SessionBAL;
        private readonly IAttendanceBAL _AttendanceBAL;
        private readonly IConfigurationBAL _objConfigurationBAL;
        private readonly IBALUsers _UserBAL;
        
       

        public ProgramController(ICourseBAL ICourseBAL, IConfigurationBAL _objIConfigurationBAL, IClassBAL IClassBAL, ISessionBAL _ISessionBAL, IAttendanceBAL _IAttendanceBAL,IBALUsers objUserBAL)
        {
            _objConfigurationBAL = _objIConfigurationBAL;
            _CourseBAL = ICourseBAL;
            _ClassBAL = IClassBAL;
            _SessionBAL = _ISessionBAL;
            _UserBAL = objUserBAL;
            _AttendanceBAL = _IAttendanceBAL;
              
            }

        #region Course

        [ClaimsAuthorize("CanViewCourse")]
        public ActionResult Course()
        {
            var json = new JavaScriptSerializer().Serialize(0);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to view Courses at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            return View();
        }

        [ClaimsAuthorize("CanViewCourse")]
        public ActionResult CourseDetail()
        {
            var id = Request.QueryString["id"];
            var json = new JavaScriptSerializer().Serialize(0);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to view Courses detail at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            if (string.IsNullOrEmpty(id))
            {
                return RedirectPermanent(Url.Content("~/Program/Course"));
            }
            else
            {
                var data = _CourseBAL.TMS_Courses_GetByIdBAL(id);
                if (data == null)
                {
                    ViewData["model"] = Url.Content("~/Program/Course");
                    return View("Static/NotFound");
                }
                else
                {
                    ViewData["model"] = data;
                    return View();
                }
            }
        }

        [ClaimsAuthorize("CanViewCourse")]
        [DontWrapResult]
        public ActionResult Course_Read([DataSourceRequest] DataSourceRequest request)
         {
            var json = new JavaScriptSerializer().Serialize(0);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to view Courses at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            var list = this._ClassBAL.personRoleGroups(CurrentUser.NameIdentifierInt64);
            long PersonID = 0;
            if (list.Count == 1 && list[0].PrimaryGroupName == "Trainer")
            {
                PersonID = CurrentUser.NameIdentifierInt64;
            }
            var kendoRequest = new Kendo.Mvc.UI.DataSourceRequest
            {

                Filters = request.Filters,
                Sorts = request.Sorts,
                Groups = request.Groups,
                Aggregates = request.Aggregates
            };
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var Courses = this._CourseBAL.TMS_Courses_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);

            if (CurrentUser.CompanyID > 0)
            {
                if (kendoRequest.Filters.Count > 0)
                {
                    Courses = this._CourseBAL.TMS_CoursesByOrganization_GetAllBAL(request.Page, startRowIndex, 10000, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText, Convert.ToString(CurrentUser.CompanyID),PersonID);
                }
                else
                {
                    Courses = this._CourseBAL.TMS_CoursesByOrganization_GetAllBAL(request.Page, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText, Convert.ToString(CurrentUser.CompanyID), PersonID);

                }
            }
            //var result = new DataSourceResult()
            //{
            //    Data = Courses, // Process data (paging and sorting applied)
            //    Total = Total // Total number of records
            //};
            var data = Courses.ToDataSourceResult(kendoRequest);

            var result = new DataSourceResult()
            {
                AggregateResults = data.AggregateResults,
                Data = data.Data,
                Errors = data.Errors,
                Total = Total
            };
            return Json(result);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        //[ClaimsAuthorize("CanDeleteSession")]

        public JsonResult CourseDelteChk(string _Sessions)
        {
            bool result = false;
            var _returnValue = this._CourseBAL.TMS_CoursesDeleteCheck(Convert.ToString(_Sessions),CurrentUser.CompanyID.ToString());

            if (_returnValue > 0)
            {
                result = false;

            }
            else
            {
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [ClaimsAuthorize("CanViewCourse")]
        [DontWrapResult]
        public JsonResult CourseCategoryCode(long id)
        {
            return Json(this._CourseBAL.CourseCategoryCodeByCourseIdBAL(id), JsonRequestBehavior.AllowGet);
        }

        [ClaimsAuthorize("CanAddEditCourse")]
        [DontWrapResult]
        public ActionResult Course_Create([DataSourceRequest] DataSourceRequest request, Course _Course)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_Course);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to create Courses at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                _Course.CreatedBy = CurrentUser.NameIdentifierInt64;
                _Course.CreatedDate = DateTime.Now;
                _Course.OrganizationID = CurrentUser.CompanyID;
                var codeSuffix = Request.Form["codeSuffix"];
                _Course.CourseCode = codeSuffix + "-" + _Course.CourseCode;
                if (this._CourseBAL.TMS_Courses_Dublicate_PrimaryNameBAL(_Course) > 0)
                {
                    ModelState.AddModelError(lr.PersonSkill, lr.FlagDuplicationCheck);
                }
                else
                {
                    if(_Course.FeeCurrency==null)
                    {
                        _Course.FeeCurrency = 3;
                    }
                    _Course.ID = this._CourseBAL.TMS_Courses_CreateBAL(_Course);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);
                }
            }

            var resultData = new[] { _Course };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorize("CanAddEditCourse")]
        [DontWrapResult]
        public ActionResult Course_Update([DataSourceRequest] DataSourceRequest request, Course _Course)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_Course);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Update_Success.ToString(), System.Environment.MachineName, "User tried to update Courses at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                _Course.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Course.UpdatedDate = DateTime.Now;
                var codeSuffix = Request.Form["codeSuffix"];
                _Course.CourseCode = codeSuffix + "-" + _Course.CourseCode;
                this._CourseBAL.TMS_Courses_UpdateBAL(_Course);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                // string browserName = req.Browser.Browser;
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);

            }

            var resultData = new[] { _Course };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteCourse")]
        [DisableValidation]
        public ActionResult Course_Destroy([DataSourceRequest] DataSourceRequest request, Course _Course)
        {
            //if (ModelState.IsValid)
            //{

                var json = new JavaScriptSerializer().Serialize(_Course);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Delete_Success.ToString(), System.Environment.MachineName, "User tried to destroy Courses at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                bool result1 = false;
                var _returnValue = this._CourseBAL.TMS_CoursesDeleteCheck(_Course.ID.ToString(), CurrentUser.CompanyID.ToString());

                if (_returnValue > 0)
                {
                    result1 = false;

                }
                else
                {
                    _Course.UpdatedBy = CurrentUser.NameIdentifierInt64;
                    _Course.UpdatedDate = DateTime.Now;
                    if (_CourseBAL.class_CheckBAL(_Course, CurrentUser.CompanyID) > 0)
                    {
                        ModelState.AddModelError(lr.PersonSkill, lr.FlagDuplicationCheck);
                    }
                    else
                    {
                        var result = this._CourseBAL.TMS_Courses_DeleteBAL(_Course);
                        string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (string.IsNullOrEmpty(ip))
                            ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                        // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                        // string browserName = req.Browser.Browser;
                        _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                        if (result == -1)
                        {
                            ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                        }
                    }
                }
            //}
            var resultData = new[] { _Course };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        #endregion Course

        #region Class

        [ClaimsAuthorize("CanViewClass")]
        public ActionResult ClassNested(long CourseID)
        {
            return PartialView("_Class", CourseID);
        }

        [ClaimsAuthorize("CanViewClass")]
        public ActionResult Class()
        {
            return View();
        }



        [ClaimsAuthorize("CanViewClass")]
        [DontWrapResult]
        public ActionResult Class_Read([DataSourceRequest] DataSourceRequest request)
        {
            var json = new JavaScriptSerializer().Serialize(0);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to read Class at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            var list =this._ClassBAL.personRoleGroups(CurrentUser.NameIdentifierInt64);
            var kendoRequest = new Kendo.Mvc.UI.DataSourceRequest
            {

                Filters = request.Filters,
                Sorts = request.Sorts,
                Groups = request.Groups,
                Aggregates = request.Aggregates
            };
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (SearchText == "")
                SearchText = null;
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            long CourseId = 0;
            CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
            List<Classes> Classs = new List<Classes>();
            if (CurrentUser.CompanyID < 0)
            {
                Classs = this._ClassBAL.TMS_Classes_GetAllBAL(CourseId, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            }

            else if (CurrentUser.CompanyID > 0)
            {
                long PersonId = 0;
                if(list.Count==1 && list[0].PrimaryGroupName=="Trainer")
                {
                    PersonId = CurrentUser.NameIdentifierInt64;
                }
                if (CourseId <= 0)
                {
                    Classs = this._ClassBAL.TMS_ClassesAllByOrganization_GetAllBAL(CourseId, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText, Convert.ToString(CurrentUser.CompanyID),PersonId);
                }
                else
                {
                    Classs = this._ClassBAL.TMS_ClassesByOrganization_GetAllBAL(CourseId, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText, Convert.ToString(CurrentUser.CompanyID));
                }
            }
            //var result = new DataSourceResult()
            //{
            //    Data = Classs, // Process data (paging and sorting applied)
            //    Total = Total // Total number of records
            //};
            return Json(Classs.ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorize("CanViewClass")]
        [DontWrapResult]
        public JsonResult CourseDetailById(string id)
        {
            int count = 0;
            var result = _ClassBAL.GetCourseDetailByIdForNewClassBAL(id, ref count);
            var json = new JavaScriptSerializer().Serialize(id);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to detail Class at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            if (count > 0)
            {
                result.CourseCode = result.CourseCode + "-" + DateTime.Now.Year.ToString().Substring(2, 2) + "-" + (count + 1).ToString("000");
            }
            else
            {
                result.CourseCode = result.CourseCode + "-" + DateTime.Now.Year.ToString().Substring(2, 2) + "-001";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [ClaimsAuthorize("CanAddEditClass")]
        [DontWrapResult]
        public ActionResult Class_Create([DataSourceRequest] DataSourceRequest request, Classes _Class)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_Class);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to create Class at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                DateTime t1 = Convert.ToDateTime(_Class.StartTimeString);
                DateTime t2 = Convert.ToDateTime(_Class.EndTimeString);
                int value = DateTime.Compare(t1, t2);
                // checking 
                if (value < 0)
                {
                    _Class.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _Class.CreatedDate = DateTime.Now;
                    _Class.OrganizationID = CurrentUser.CompanyID;
                    _Class.StartTime = UtilityFunctions.MapValue<DateTime>(_Class.StartDate.ToShortDateString() + " " + _Class.StartTimeString, typeof(DateTime));
                    DateTime dtEndTime = UtilityFunctions.MapValue<DateTime>(_Class.EndDate.ToShortDateString() + " " + _Class.EndTimeString, typeof(DateTime));
                    if (dtEndTime < _Class.StartTime)
                        dtEndTime = dtEndTime.AddDays(1);
                    _Class.EndTime = dtEndTime;
                    if (_Class.EvaluationLink == null)
                    {
                        _Class.EvaluationLink = "";
                    }
                    if (_Class.FollowUp == null)
                    {
                        _Class.FollowUp = "";
                    }
                    if (_Class.SecondaryClassTitle == null)
                    {
                        _Class.SecondaryClassTitle = "";
                    }


                    _Class.ID = _ClassBAL.TMS_Classes_CreateBAL(_Class);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                    // string browserName = req.Browser.Browser;
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                }
                else
                {
                    ModelState.AddModelError(lr.SessionTimeConflict, lr.StartandEndTimeConflict);
                }
            }

            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorize("CanAddEditClass")]
        [DontWrapResult]
        public ActionResult Class_Update([DataSourceRequest] DataSourceRequest request, Classes _Class)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_Class);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Update_Success.ToString(), System.Environment.MachineName, "User tried to update Class at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                DateTime t1 = Convert.ToDateTime(_Class.StartTimeString);
                DateTime t2 = Convert.ToDateTime(_Class.EndTimeString);
                int value = DateTime.Compare(t1, t2);
                // checking 
                if (value < 0)
                {
                    int sessioncount = _ClassBAL.TMS_Classes_SessionCountBAL(_Class.ID);
                    if (_Class.MaximumSessionPerDay < sessioncount)
                    {
                        ModelState.AddModelError(lr.MaximumSessionConflict, lr.MaximumSessionConflict);
                    }
                    else
                    {


                        _Class.UpdatedBy = CurrentUser.NameIdentifierInt64;
                        _Class.UpdatedDate = DateTime.Now;
                        _Class.StartTime = UtilityFunctions.MapValue<DateTime>(_Class.StartDate.ToShortDateString() + " " + _Class.StartTimeString, typeof(DateTime));
                        DateTime dtEndTime = UtilityFunctions.MapValue<DateTime>(_Class.EndDate.ToShortDateString() + " " + _Class.EndTimeString, typeof(DateTime));
                        if (dtEndTime < _Class.StartTime)
                            dtEndTime = dtEndTime.AddDays(1);
                        _Class.EndTime = dtEndTime;
                        if (_Class.EvaluationLink == null)
                        {
                            _Class.EvaluationLink = "";
                        }
                        if (_Class.FollowUp == null)
                        {
                            _Class.FollowUp = "";
                        }
                        if (_Class.SecondaryClassTitle == null)
                            _Class.SecondaryClassTitle = "";
                        _ClassBAL.TMS_Classes_UpdateBAL(_Class);
                        string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (string.IsNullOrEmpty(ip))
                            ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                        // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                        // string browserName = req.Browser.Browser;
                        _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);
                    }
                }
                else
                {
                    ModelState.AddModelError(lr.SessionTimeConflict, lr.StartandEndTimeConflict);
                }
            }

            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteClass")]
        public ActionResult Class_Destroy([DataSourceRequest] DataSourceRequest request, Classes _Class)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_Class);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Delete_Success.ToString(), System.Environment.MachineName, "User tried to destroy Class at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                int sessioncount = _ClassBAL.TMS_Classes_SessionCountBAL(_Class.ID);
                if (sessioncount > 0)
                {
                    ModelState.AddModelError(lr.MaximumSessionConflictDelete, lr.MaximumSessionConflictDelete);
                }
                else
                {
                    _Class.UpdatedBy = CurrentUser.NameIdentifierInt64;
                    _Class.UpdatedDate = DateTime.Now;
                    var result = _ClassBAL.TMS_Classes_DeleteDAL(_Class);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                    // string browserName = req.Browser.Browser;
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
            }
            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorize("CanViewClass")]
        public ActionResult ClassDetail()
        {
            var id = Request.QueryString["id"];
            if (string.IsNullOrEmpty(id))
            {
                return RedirectPermanent(Url.Content("~/Program/Class"));
            }
            else
            {
                var data = _ClassBAL.TMS_Classes_GetByIdBAL(id);
                if (data == null)
                {
                    ViewData["model"] = Url.Content("~/Program/Class");
                    return View("Static/NotFound");
                }
                else
                {
                    ViewData["model"] = data;
                    return View();
                }
            }
        }
        [ClaimsAuthorize("CanViewClass")]
        public ActionResult ClassDetail2()
        {
            var id = Request.QueryString["id"];
            if (string.IsNullOrEmpty(id))
            {
                return RedirectPermanent(Url.Content("~/Program/Class"));
            }
            else
            {
                var data = _ClassBAL.TMS_Classes_GetByIdBAL(id);
                if (data == null)
                {
                    ViewData["model"] = Url.Content("~/Program/Class");
                    return View("Static/NotFound");
                }
                else
                {
                    ViewData["model"] = data;
                    return View();
                }
            }
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteClass")]
        [DisableValidation]
        public JsonResult ClassDelteChk(long _ClassID)
        {
            bool result = false;
            int sessioncount = _ClassBAL.TMS_Classes_SessionCountBAL(_ClassID);
            if (sessioncount > 0)
            {
                result = false;
                //ModelState.AddModelError(lr.MaximumSessionConflictDelete, lr.MaximumSessionConflictDelete);
            }
            else
            {
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [ClaimsAuthorize("CanViewProgramTrainee")]
        [DontWrapResult]
        public ActionResult ManageTrainee(long ClassId)
        {
            return PartialView("_ManageTrainee", ClassId);
        }

        [ClaimsAuthorize("CanViewProgramTrainee")]
        [DontWrapResult]
        public ActionResult ManageTrainee_Read([DataSourceRequest] DataSourceRequest request, long ClassID)
        {
            ViewData["ClassTraineeClassIdCreating"] = ClassID;
            var json = new JavaScriptSerializer().Serialize(ClassID);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to read Class trainee at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            if (CurrentUser.CompanyID > 0)
            {
                return Json(_ClassBAL.ClassTraineeMapping_GetAllBALOrganization(CurrentCulture, ClassID, CurrentUser.CompanyID).ToDataSourceResult(request, ModelState));
            }
            else
            {
                return Json(_ClassBAL.ClassTraineeMapping_GetAllBAL(CurrentCulture, ClassID).ToDataSourceResult(request, ModelState));
            }
        }

        [ClaimsAuthorize("CanAddEditProgramTrainee")]
        [DontWrapResult]
        public ActionResult ManageTraineePerson_Read([DataSourceRequest] DataSourceRequest request, long ClassID)
        {

            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var json = new JavaScriptSerializer().Serialize(ClassID);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to read Class trainee at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            if (CurrentUser.CompanyID > 0)
            {
                var Classs = this._ClassBAL.ClassTrainee_GetAllByClassIDForCreatingBALOrganization(CurrentCulture, CurrentUser.CompanyID, ClassID, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
                
                var result = new DataSourceResult()
                {
                    Data = Classs, // Process data (paging and sorting applied)
                    Total = Total // Total number of records
                };


                return Json(result);

            }
            else
            {
                var Classs = this._ClassBAL.ClassTrainee_GetAllByClassIDForCreatingBAL(CurrentCulture, ClassID, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);

                var result = new DataSourceResult()
                {
                    Data = Classs, // Process data (paging and sorting applied)
                    Total = Total // Total number of records
                };


                return Json(result);
            }
        }

        [ClaimsAuthorize("CanAddEditProgramTrainee")]
        [DontWrapResult]

        public ActionResult ManageTrainee_Create([DataSourceRequest] DataSourceRequest request, string PersonIds, long cid)
        {
            ClassTraineeMapping _Classes = new ClassTraineeMapping();
            List<TrainerOpenMapping> ManageTrainer = _objConfigurationBAL.ManageTrainer_GetAllBAL(Convert.ToInt32(cid), 2);
            bool flage = true;
            long trainerid = -1;
            var json = new JavaScriptSerializer().Serialize(PersonIds);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to create Class trainee at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            foreach (var x in ManageTrainer)
            {
                if (PersonIds.Contains(x.PersonID.ToString()))
                {
                    flage = false;
                    trainerid = x.PersonID;
                    break;
                }
            }
            if (flage == false)
            {
                ModelState.AddModelError(lr.Trainer, lr.ClassTrainerCannotAssignAsTrainee);
            }
            else
            {



                if (ModelState.IsValid)
                {
                    //  string PersonIds = "2233";
                    bool flg = true;
                    string[] arr = PersonIds.Split(',');
                    string msg = "";
                    foreach(var item in arr)
                    {
                        var valaue = _ClassBAL.TMS_ClassTraineeMapping_BussinesRuleVerifyBAL(cid.ToString(), item,CurrentUser.CompanyID);
                        if(valaue.Count>0)
                        {
                            flg = false;
                            foreach(var x in valaue)
                            {
                                string t = "(" + x.P_DisplayName + " is added in Class " + x.PrimaryClassTitle + " ),";
                                msg=msg+t;
                            }
                        }
                    }
                    if (flg)
                    {
                        _Classes.CreatedBy = CurrentUser.NameIdentifierInt64;
                        _Classes.CreatedDate = DateTime.Now;
                        _Classes.ClassID = cid;
                        _Classes.ID = _ClassBAL.TMS_ClassTraineeMapping_CreateBAL(_Classes, PersonIds);
                        string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (string.IsNullOrEmpty(ip))
                            ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                        // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                        // string browserName = req.Browser.Browser;
                        _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);
                        

                    } else
                    {
                        ModelState.AddModelError(lr.TraineeTimeConflictWithOtherClass, msg);

                    }
                }
            }
            var resultData = new[] { _Classes };

            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteProgramTrainee")]
        public ActionResult ManageTrainee_Destroy([DataSourceRequest] DataSourceRequest request, long ID)
        {
            ClassTraineeMapping _Class = new ClassTraineeMapping();
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(ID);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Delete_Success.ToString(), System.Environment.MachineName, "User tried to destroy Class trainee at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                _Class.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Class.UpdatedDate = DateTime.Now;
                _Class.ID = ID;
                var result = _ClassBAL.TMS_ClassTraineeMapping_DeleteBAL(_Class);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                // string browserName = req.Browser.Browser;
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorize("CanViewProgramTrainer")]
        [DontWrapResult]
        public ActionResult ManageTrainerPerson_Read([DataSourceRequest] DataSourceRequest request, long ClassID)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            var json = new JavaScriptSerializer().Serialize(ClassID);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to read Class trainee at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            if (CurrentUser.CompanyID > 0)
            {
                var Classs = this._ClassBAL.TrainerGetAllOrganizationExceptClassTrainerBAL(CurrentCulture, CurrentUser.CompanyID, ClassID, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
                var result = new DataSourceResult()
                {
                    Data = Classs, // Process data (paging and sorting applied)
                    Total = Total // Total number of records
                };
                return Json(result);
            }

            else
            {
                var Classs = this._ClassBAL.TrainerGetAllExceptClassTrainerBAL(CurrentCulture, ClassID, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
                var result = new DataSourceResult()
                {
                    Data = Classs, // Process data (paging and sorting applied)
                    Total = Total // Total number of records
                };
                return Json(result);
            }

        }

        [ClaimsAuthorize("CanAddEditProgramTrainee")]
        [DontWrapResult]
        public ActionResult ManageTrainerPerson_Create([DataSourceRequest] DataSourceRequest request, string PersonIds, long cid)
        {
            ClassTrainerMapping _Classes = new ClassTrainerMapping();
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(PersonIds);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to create Class trainee at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                _Classes.CreatedBy = CurrentUser.NameIdentifierInt64;
                _Classes.CreatedDate = DateTime.Now;
                _Classes.ClassID = cid;
                _Classes.ID = _ClassBAL.TrainerOpenMapping_CreateByPersonIdsBAL(_Classes, PersonIds);
                //Notifications nof = new Notifications();
                //nof.NotificationText = "Your are added in Class as trainer";
                //nof.Organization_ID = CurrentUser.CompanyID;
                //nof.ToUser = Convert.ToInt64(PersonIds);
                //nof.FromUser = CurrentUser.NameIdentifierInt64;
                //nof.ActionUrl = "Program/Classes/";
                //nof.Event_ID = 1;
                //nof.CreatedDate = DateTime.Now;
                //this.BALNotification.create_NotificationsBAL(nof);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                // string browserName = req.Browser.Browser;
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

            }

            var resultData = new[] { _Classes };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        #endregion Class

        #region Trainer Classes

        [ClaimsAuthorize("CanViewPrgramVenues")]
        [DontWrapResult]
        public ActionResult TrainerClasses(long id)
        {
            //  string pid = Request.QueryString["pid"];
            //ViewData["OpenType"] = Opentype;
            // var pid = (string)Session["pid"];
            return PartialView("_TrainerClasses", id);
        }

        [ClaimsAuthorize("CanViewPrgramVenues")]
        [DontWrapResult]
        public ActionResult TrainerClass_Read([DataSourceRequest] DataSourceRequest request)
        {
            var pid = (string)Session["pid"];
            long id = Convert.ToInt64(pid);
            var json = new JavaScriptSerializer().Serialize(0);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to read Class trainer at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            int Total = 0;
            //  long id = 60066;
            //   string pid = Request.QueryString["pid"];
            if (CurrentUser.CompanyID > 0)
            {
                var Class = this._ClassBAL.TMS_TrainerClasses_GetByOrganizationIdBAL(id, CurrentUser.CompanyID, ref Total);
                var result = new DataSourceResult()
                {
                    Data = Class,
                    Total = Total// Process data (paging and sorting applied)
                                 //Total = Total // Total number of records
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var Class = this._ClassBAL.TMS_TrainerClasses_GetByIdBAL(id, ref Total);
                var result = new DataSourceResult()
                {
                    Data = Class,
                    Total = Total   /// Process data (paging and sorting applied)
                    //Total = Total // Total number of records
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }


            //return Json(_ClassBAL.TMS_TrainerClasses_GetByIdBAL(id).ToDataSourceResult( request, ModelState),JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region  Class Logistics

        [DontWrapResult]
        public ActionResult ClassLogistics(long ClassId)
        {
            return PartialView(ClassId);
        }

        [DontWrapResult]
        public JsonResult LogisticsGroups()
        {
            long ClassID = Convert.ToInt64(Session["ClassID"]);
            Session.Remove("ClassID");
            return Json(this._ClassBAL.TMS_ClassLogisticsDLL_GetAllBAL(CurrentCulture, CurrentUser.CompanyID, ClassID), JsonRequestBehavior.AllowGet);
        }

        [ClaimsAuthorize("CanViewClass")]
        [DontWrapResult]
        public ActionResult ClassLogistics_Read([DataSourceRequest] DataSourceRequest request, long ClassID)
        {
            Session["ClassID"] = ClassID;
            var SearchText = Request.Form["SearchText"];
            long CourseId = 0;
            ViewData["ClassTraineeClassIdCreating"] = ClassID;
            CourseId = Convert.ToInt64(Request.QueryString["ClassID"]);
            var Classs = this._ClassBAL.TMS_ClassLogestics_GetAllBAL(CourseId);
            return Json(Classs.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ClaimsAuthorizeAttribute("CanAddEditClass")]
        [DontWrapResult]
        public ActionResult ClassLogistics_Create([DataSourceRequest] DataSourceRequest request, CourseLogisticRequirements _Class, long ClassID)
        {
            if (ModelState.IsValid)
            {

                var Classs = this._ClassBAL.TMS_ClassLogestics_GetAllBAL(ClassID);
                bool flage = true;
                foreach (var x in Classs)
                {
                    long str = x.ID;
                    if (str == _Class.ID)
                    {
                        flage = false;
                        break;
                    }
                }
                if (flage == false)
                {
                    ModelState.AddModelError(lr.DubliocationHappen, lr.LogisticDublication);
                }
                else
                {
                    //long ClassID = 30014;
                    _Class.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _Class.CreatedDate = DateTime.Now;
                    //_Class.OrganizationID = ID;
                    _Class.ID = _ClassBAL.TMS_ClassLogistics_CreateBAL(_Class, ClassID);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                    // string browserName = req.Browser.Browser;
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                }
            }
            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));

        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorizeAttribute("CanAddEditClass")]
        public ActionResult ClassLogistics_Update([DataSourceRequest] DataSourceRequest request, CourseLogisticRequirements _Class, long ClassID)
        {
            if (ModelState.IsValid)
            {
                long CourseId = 0;
                CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
                _Class.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Class.UpdatedDate = DateTime.Now;
                var result = _ClassBAL.TMS_ClassLogistics_UpdateDAL(_Class, ClassID);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                // string browserName = req.Browser.Browser;
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteClass")]
        public ActionResult ClassLogistics_Destroy([DataSourceRequest] DataSourceRequest request, CourseLogisticRequirements _Class, long ClassID)
        {
            if (ModelState.IsValid)
            {
                long CourseId = 0;
                CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
                _Class.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Class.UpdatedDate = DateTime.Now;
                var result = _ClassBAL.TMS_ClassLogistics_DeleteDAL(_Class, ClassID);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                // string browserName = req.Browser.Browser;
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region Course Language
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        [DontWrapResult]
        public ActionResult CourseLanguage(long CourseID)
        {
            return PartialView(CourseID);
        }

        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        [DontWrapResult]
        public ActionResult CourseLanguage_Read([DataSourceRequest] DataSourceRequest request)
        {

            var SearchText = Request.Form["SearchText"];
            long CourseId = 0;
            CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
            var Classs = this._ClassBAL.TMS_Classes_GetAllBAL(CourseId, SearchText);
            return Json(Classs.ToDataSourceResult(request, ModelState));
        }


        [ClaimsAuthorizeAttribute("CanAddEditClass")]
        [DontWrapResult]
        public ActionResult CourseLanguage_Create([DataSourceRequest] DataSourceRequest request, MapLanguage _Class)
        {
            if (ModelState.IsValid)
            {
                long CourseId = 0;
                CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
                var Classs = this._ClassBAL.TMS_Classes_GetAllBAL(CourseId, "");
                bool flage = true;
                foreach (var x in Classs)
                {
                    long _LanguageName = x.LanguageID;
                    if (_Class.LanguageID == _LanguageName)
                    {
                        flage = false;
                        break;
                    }
                }
                if (flage == true)
                {


                    _Class.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _Class.CreatedDate = DateTime.Now;
                    _Class.ID = _ClassBAL.TMS_CourseLanguage_CreateBAL(_Class, CourseId);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                    // string browserName = req.Browser.Browser;
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);
                }
                else
                {
                    ModelState.AddModelError(lr.DubliocationHappen, lr.LanguageDublication);
                }
            }

            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [DontWrapResult]
        [ClaimsAuthorizeAttribute("CanAddEditClass")]
        public ActionResult CourseLanguage_Update([DataSourceRequest] DataSourceRequest request, MapLanguage _Class)
        {
            if (ModelState.IsValid)
            {
                long CourseId = 0;
                CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
                _Class.ModifiedBy = CurrentUser.NameIdentifierInt64;
                _Class.ModifiedDate = DateTime.Now;
                var Classs = this._ClassBAL.TMS_Classes_GetAllBAL(CourseId, "");
                bool flage = true;
                foreach (var x in Classs)
                {
                    long _LanguageName = x.LanguageID;
                    if (_Class.LanguageID == _LanguageName)
                    {
                        flage = false;
                        break;
                    }
                }
                if (flage == true)
                {
                    var result = _ClassBAL.TMS_CourseLanguage_UpdateDAL(_Class, CourseId);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                    // string browserName = req.Browser.Browser;
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);

                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
                else
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteClass")]
        public ActionResult CourseLanguage_Destroy([DataSourceRequest] DataSourceRequest request, MapLanguage _Class)
        {
            if (ModelState.IsValid)
            {
                long CourseId = 0;
                CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
                _Class.ModifiedBy = CurrentUser.NameIdentifierInt64;
                _Class.ModifiedDate = DateTime.Now;
                var result = _ClassBAL.TMS_CourseLanguage_DeleteDAL(_Class, CourseId);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                // string browserName = req.Browser.Browser;
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region Course Coordinator
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        [DontWrapResult]
        public ActionResult CourseCoordinator(long CourseID)
        {
            Session["_CLassID"] = CourseID;
            return PartialView(CourseID);
        }
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        [DontWrapResult]
        public JsonResult CourseCoordinateGroups()
        {
            long ClassID = Convert.ToInt64(Session["ClassID"]);
            Session.Remove("ClassID");

            return Json(this._ClassBAL.TMS_ClassLogisticsDLL_GetAllBAL(CurrentCulture, CurrentUser.CompanyID, ClassID), JsonRequestBehavior.AllowGet);
        }

        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        [DontWrapResult]
        public ActionResult CourseCoordinator_Read([DataSourceRequest] DataSourceRequest request)
        {
            var SearchText = Request.Form["SearchText"];
            long CourseId = 0;
            CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
            var Classs = this._CourseBAL.TMS_CourseCoordinate_GetAllBAL(CourseId);
            return Json(Classs.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [ClaimsAuthorizeAttribute("CanAddEditClass")]
        [DontWrapResult]
        public ActionResult CourseCoordinator_Create([DataSourceRequest] DataSourceRequest request, CourseCoordinatorMapping _Class, long ClassID)
        {
            if (ModelState.IsValid)
            {

                var Classs = this._CourseBAL.TMS_CourseCoordinate_GetAllBAL(ClassID);
                bool flage = true;
                foreach (var x in Classs)
                {
                    long coordinatorId = x.CoordinateID;
                    if (coordinatorId == _Class.CoordinateID)
                    {
                        flage = false;
                        break;
                    }
                }
                if (flage)
                {

                    _Class.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _Class.CreatedDate = DateTime.Now;
                    _Class.ID = _CourseBAL.TMS_CourseCoordinate_CreateBAL(_Class, ClassID);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                    // string browserName = req.Browser.Browser;
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);
                }
                else
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }

            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [ActivityAuthorize]
        [DontWrapResult]
        [ClaimsAuthorizeAttribute("CanAddEditClass")]
        public ActionResult CourseCoordinator_Update([DataSourceRequest] DataSourceRequest request, CourseCoordinatorMapping _Class, long ClassID)
        {
            var Classs = this._CourseBAL.TMS_CourseCoordinate_GetAllBAL(ClassID);
            bool flage = true;
            foreach (var x in Classs)
            {
                long coordinatorId = x.CoordinateID;
                if (coordinatorId == _Class.CoordinateID)
                {
                    flage = false;
                    break;
                }
            }
            if (flage)
            {

                long CourseId = 0;
                CourseId = Convert.ToInt64(Session["_CLassID"]);
                _Class.CreatedBy = CurrentUser.NameIdentifierInt64;
                _Class.ModifiedDate = DateTime.Now;
                var result = _CourseBAL.TMS_CourseCoordinate_UpdateBAL(_Class, CourseId);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                // string browserName = req.Browser.Browser;
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            else
            {
                ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
            }

            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteClass")]
        public ActionResult CourseCoordinate_Destroy([DataSourceRequest] DataSourceRequest request, CourseCoordinatorMapping _Class, long ClassID)
        {
            if (ModelState.IsValid)
            {
                //long CourseId = 0;
                //CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
                _Class.ModifiedBy = CurrentUser.NameIdentifierInt64;
                _Class.ModifiedDate = DateTime.Now;
                var result = _CourseBAL.TMS_CourseCoordinate_DeleteDAL(_Class, ClassID);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                // string browserName = req.Browser.Browser;
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region Course Focus Area
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        [DontWrapResult]
        public ActionResult CourseFocusArea(long CourseID)
        {
            return PartialView(CourseID);
        }
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        [DontWrapResult]
        public JsonResult CoordinateGroups()
        {
            return Json(this._CourseBAL.TMS_FocusAreaDLL_GetAllBAL(CurrentCulture, CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
        }

        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        [DontWrapResult]
        public ActionResult CourseFocusArea_Read([DataSourceRequest] DataSourceRequest request)
        {

            var SearchText = Request.Form["SearchText"];
            long CourseID = 0;
            CourseID = Convert.ToInt64(Request.QueryString["CourseId"]);
            var Classs = this._CourseBAL.TMS_CourseFocusArea_GetAllBAL(CourseID);
            return Json(Classs.ToDataSourceResult(request, ModelState));
        }


        [ClaimsAuthorizeAttribute("CanAddEditClass")]
        [DontWrapResult]
        public ActionResult CourseFocusArea_Create([DataSourceRequest] DataSourceRequest request, FocusAreas _Class)
        {
            if (ModelState.IsValid)
            {
                long CourseId = 0;
                CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
                _Class.CreatedBy = CurrentUser.NameIdentifierInt64;
                _Class.CreatedDate = DateTime.Now;

                if (_CourseBAL.TMS_CourseFocusArea_DublicationBAL(_Class, CourseId) > 0)
                {
                    ModelState.AddModelError(lr.DubliocationHappen, lr.DubliocationHappen);
                }
                else
                {


                    _Class.ID = _CourseBAL.TMS_CourseFocusArea_CreateBAL(_Class, CourseId);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                    // string browserName = req.Browser.Browser;
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);
                }
            }

            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [DontWrapResult]
        [ClaimsAuthorizeAttribute("CanAddEditClass")]
        public ActionResult CourseFocusArea_Update([DataSourceRequest] DataSourceRequest request, FocusAreas _Class)
        {
            if (ModelState.IsValid)
            {
                long CourseId = 0;
                CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
                _Class.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Class.UpdatedDate = DateTime.Now;
                if (_CourseBAL.TMS_CourseFocusArea_DublicationBAL(_Class, CourseId) > 0)
                {
                    ModelState.AddModelError(lr.DubliocationHappen, lr.DubliocationHappen);
                }
                else
                {
                    var result = _CourseBAL.TMS_CourseFocusArea_UpdateBAL(_Class, CourseId);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                    // string browserName = req.Browser.Browser;
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);


                }
            }
            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteClass")]
        public ActionResult CourseFocusArea_Destroy([DataSourceRequest] DataSourceRequest request, FocusAreas _Class)
        {
            if (ModelState.IsValid)
            {
                long CourseId = 0;
                CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
                _Class.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Class.UpdatedDate = DateTime.Now;
                var result = _CourseBAL.TMS_CourseFocusArea_DeleteDAL(_Class, CourseId);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                // string browserName = req.Browser.Browser;
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region Sessions

        [ClaimsAuthorize("CanViewSession")]
        public ActionResult SessionNested(long ClassId)
        {
            return PartialView("_Sessions", ClassId);
        }

        [ClaimsAuthorize("CanViewSession")]
        public ActionResult Sessions()
        {
            Session["CalanderValues"] = "";
            var json = new JavaScriptSerializer().Serialize(0);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to read sessions at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            return View();
        }
        [DontWrapResult]
        [HttpPost]
        public void SetSessionValues(string CalanderValues)
        {
            Session["CalanderValues"] = CalanderValues;
            
        }
        [ClaimsAuthorize("CanViewReports")]
        public ActionResult TrainerDetailReport()
        {
            return View();
            // return View("Views/Report/TrainerDetailReport");
            //return View("~/Views/Report/TrainerDetailReport");
        }

        [ClaimsAuthorize("CanViewReports")]
        public ActionResult TraineeDetailReport()
        {
            return View();
            // return View("Views/Report/TrainerDetailReport");
            //return View("~/Views/Report/TrainerDetailReport");
        }

        [ClaimsAuthorize("CanViewReports")]
        public ActionResult Attendance()
        {
            return View();
            // return View("Views/Report/TrainerDetailReport");
            //return View("~/Views/Report/TrainerDetailReport");
        }

        [ClaimsAuthorize("CanViewReports")]
        public ActionResult ClassReportFuture()
        {
            return View();
            // return View("Views/Report/TrainerDetailReport");
            //return View("~/Views/Report/TrainerDetailReport");
        }


        [ClaimsAuthorize("CanViewReports")]
        public ActionResult ClassSchedule()
        {
            return View();
            // return View("Views/Report/TrainerDetailReport");
            //return View("~/Views/Report/TrainerDetailReport");
        }


        [ClaimsAuthorize("CanViewReports")]
        public ActionResult CourseAttendanceReport()
        {
            return View();
            // return View("Views/Report/TrainerDetailReport");
            //return View("~/Views/Report/TrainerDetailReport");
        }


        [ClaimsAuthorize("CanViewReports")]
        public ActionResult VenueDetailReport()
        {
            return View();
            // return View("Views/Report/TrainerDetailReport");
            //return View("~/Views/Report/TrainerDetailReport");
        }



        [ClaimsAuthorize("CanViewReports")]
        public ActionResult VenueMatrixReport()
        {
            return View();
            // return View("Views/Report/TrainerDetailReport");
            //return View("~/Views/Report/TrainerDetailReport");
        }


        [ClaimsAuthorize("CanViewReports")]
        public ActionResult ClassDetailReport()
        {
            return View();
            // return View("Views/Report/TrainerDetailReport");
            //return View("~/Views/Report/TrainerDetailReport");
        }

        [ClaimsAuthorize("CanViewReports")]
        public ActionResult OccupancyVenueReport()
        {
            return View();
            // return View("Views/Report/TrainerDetailReport");
            //return View("~/Views/Report/TrainerDetailReport");
        }


        [ClaimsAuthorize("CanViewReports")]
        public ActionResult VenueDailyUtilizationReport()
        {
            return View();
            // return View("Views/Report/TrainerDetailReport");
            //return View("~/Views/Report/TrainerDetailReport");
        }


        [ClaimsAuthorize("CanViewReports")]
        public ActionResult TraineePeriodicReport()
        {
            return View();
            // return View("Views/Report/TrainerDetailReport");
            //return View("~/Views/Report/TrainerDetailReport");
        }


        [ClaimsAuthorize("CanViewReports")]
        public ActionResult CoursePeriodicReport()
        {
            return View();
        }


        [ClaimsAuthorize("CanViewReports")]
        public ActionResult VenueDetailUtilizationReport()
        {
            return View();
            // return View("Views/Report/TrainerDetailReport");
            //return View("~/Views/Report/TrainerDetailReport");
        }

        [ClaimsAuthorize("CanViewReports")]
        public ActionResult WeeklySummeryReport()
        {
            return View();
            // return View("Views/Report/TrainerDetailReport");
            //return View("~/Views/Report/TrainerDetailReport");
        }

        [ClaimsAuthorize("CanViewReports")]
        public ActionResult Schedules()
        {
            return View();

        }

        //[ClaimsAuthorize("CanViewSession")]
        //public ActionResult SessionsDetail()
        //{
        //    var id = Request.QueryString["id"];
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return RedirectPermanent(Url.Content("~/Program/Course"));
        //    }
        //    else
        //    {
        //        var data = _CourseBAL.TMS_Courses_GetByIdBAL(id);
        //        if (data == null)
        //        {
        //            ViewData["model"] = Url.Content("~/Program/Course");
        //            return View("Static/NotFound");
        //        }
        //        else
        //        {
        //            ViewData["model"] = data;
        //            return View();
        //        }
        //    }
        //}

        [ClaimsAuthorize("CanViewSession")]
        public ActionResult SessionsDetail()
        {
            var id = Request.QueryString["id"];
            if (string.IsNullOrEmpty(id))
            {
                return RedirectPermanent(Url.Content("~/Program/Sessions"));
            }
            else
            {
                var data = _SessionBAL.TMS_Session_GetByIdBAL(id);
                if (data == null)
                {
                    ViewData["model"] = Url.Content("~/Program/Sessions");
                    return View("Static/NotFound");
                }
                else
                {
                    var json = new JavaScriptSerializer().Serialize(0);
                    _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to read sessions detail at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                    ViewData["model"] = data;
                    return View();
                }
            }
        }

        [ClaimsAuthorize("CanViewSession")]
        [DontWrapResult]
        public ActionResult Sessions_Read([DataSourceRequest] DataSourceRequest request)
        {
            var list = this._ClassBAL.personRoleGroups(CurrentUser.NameIdentifierInt64);
            long PersonID = 0;
            var json = new JavaScriptSerializer().Serialize(0);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to read sessions detail at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            if (list.Count==1 && list[0].PrimaryGroupName=="Trainer")
            {
                PersonID = CurrentUser.NameIdentifierInt64;
            }
            var kendoRequest = new Kendo.Mvc.UI.DataSourceRequest
            {

                Filters = request.Filters,
                Sorts = request.Sorts,
                Groups = request.Groups,
                Aggregates = request.Aggregates
            };
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            long ClassID = 0;
            ClassID = Convert.ToInt64(Request.QueryString["ClassId"]);
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            IList<Sessions> Sessions=null;
            if (CurrentUser.CompanyID <= 0)
            {
                Sessions = this._SessionBAL.TMS_Sessions_GetALLByCultureBAL(ClassID, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            }
            else if (CurrentUser.CompanyID > 0)
            {
                if (ClassID <= 0)
                {
                    if (kendoRequest.Filters.Count > 0)
                    {
                        Sessions = this._SessionBAL.TMS_SessionsbyOrganization_GetALLSessionsByCultureBAL(ClassID, startRowIndex, 10000, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText, Convert.ToString(CurrentUser.CompanyID), request.Page, PersonID);
                    }
                    else
                    {
                        Sessions = this._SessionBAL.TMS_SessionsbyOrganization_GetALLSessionsByCultureBAL(ClassID, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText, Convert.ToString(CurrentUser.CompanyID), request.Page, PersonID);

                    }
                }
                else
                {
                    Sessions = this._SessionBAL.TMS_SessionsbyOrganization_GetALLByCultureBAL(ClassID, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText, Convert.ToString(CurrentUser.CompanyID));
                }
            }
            
            var data = Sessions.ToDataSourceResult(kendoRequest);
            var result = new DataSourceResult()
            {
                AggregateResults = data.AggregateResults,
                Data = data.Data,
                Errors = data.Errors,
                Total = Total
            };
            //var result = new DataSourceResult()
            //{
            //    Data = Sessions, // Process data (paging and sorting applied)
            //    Total = Total // Total number of records
            //};
            return Json(result);
        }

        [ClaimsAuthorize("CanAddEditSession")]
        [DontWrapResult]
        public ActionResult Sessions_Create([DataSourceRequest] DataSourceRequest request, Sessions _Sessions, long ClassID)
        {
            if (ModelState.IsValid)
            {
                string _SessionsDates = "";
                try { 
                     _SessionsDates = System.Web.HttpContext.Current.Session["CalanderValues"].ToString();
                }
                catch(Exception e)
                {
                    ModelState.AddModelError(lr.SessionTimeConflict + "  " + _Sessions.ScheduleDate, lr.StartandEndDateConflict + "  " + _Sessions.ScheduleDate);
                }
                    if (_SessionsDates != "")
                    {
                    string[] authorsList = _SessionsDates.Split(',');
                    DateTime[] dateObjects= new DateTime[1000];
                    for (int x=0;x<authorsList.Length;++x)
                    {
                        string str = authorsList[x].ToString();
                        string date = str.Substring(4, 11);
                        DateTime s = DateTime.ParseExact(date, "MMM dd yyyy", CultureInfo.InvariantCulture);
                        dateObjects[x] = s;
                    }
                    List<DateTime> lst = dateObjects.OfType<DateTime>().ToList();
                    lst.RemoveAll(x=>x.Year== DateTime.MinValue.Year);
                    var result = _SessionBAL.GetClassDetailByClassIdForNewSessionBAL(_Sessions.ClassID.ToString(), "0");
                    int Count = result.Count;
                    foreach (var item in lst)
                    {

                        _Sessions.ScheduleDate = item.Date;
                        Count = ++Count;
                        _Sessions.SessionName = result.ClassName + "-" + (Count);
                        
                        if (VerifyBussinessRules(_Sessions))
                        {

                            var json = new JavaScriptSerializer().Serialize(_Sessions);
                            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to create sessions detail at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);
                            DateTime t1 = Convert.ToDateTime(_Sessions.StartTimeString);
                            DateTime t2 = Convert.ToDateTime(_Sessions.EndTimeString);
                            int value = DateTime.Compare(t1, t2);
                            // checking 
                            if (value < 0)
                            {
                                var lastItem = lst.Last();
                                if(lastItem.Date==item.Date && _Sessions.IsLastSession==true)
                                {
                                    _Sessions.IsLastSession = true;
                                }
                                else
                                {
                                    _Sessions.IsLastSession = false;
                                }
                                _Sessions.CreatedBy = CurrentUser.NameIdentifierInt64;
                                _Sessions.CreatedDate = DateTime.Now;
                                _Sessions.OrganizationID = CurrentUser.CompanyID;
                                _Sessions.ClassID = ClassID;
                                if (VerifyBussinessRules(_Sessions))
                                {
                                    if (_SessionBAL.GetSessionVenueOccupancyDetailBAL(_Sessions) > 0)
                                    {
                                        ModelState.AddModelError(lr.VenueOcupaidByOther + "  " + _Sessions.ScheduleDate, lr.VenueOcupaidByOther + "  " + _Sessions.ScheduleDate);
                                        break;
                                    }
                                    else
                                    {
                                        _Sessions.ID = this._SessionBAL.TMS_Sessions_CreateBAL(_Sessions);
                                        string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                                        if (string.IsNullOrEmpty(ip))
                                            ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                                        // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                                        // string browserName = req.Browser.Browser;
                                        _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                                    }


                                }
                            }
                            else
                            {
                                ModelState.AddModelError(lr.SessionTimeConflict+"  "+ _Sessions.ScheduleDate, lr.StartandEndDateConflict + "  " + _Sessions.ScheduleDate);
                                break;
                            }

                        }
                        else
                        {
                            
                            ModelState.AddModelError(lr.SessionTimeConflict + "  " + _Sessions.ScheduleDate, lr.StartandEndDateConflict + "  " + _Sessions.ScheduleDate);
                            break;
                        }

                    }
                }
                else
                {
                    
                    ModelState.AddModelError(lr.ErrorServerError, lr.SessionScheduleDate);
                    
                }


            }
            else
            {
                ModelState.AddModelError(lr.ErrorServerError , lr.SessionScheduleDate);

            }
            var resultData = new[] { _Sessions };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorize("CanAddEditSession")]
        [DontWrapResult]
        public ActionResult Sessions_Update([DataSourceRequest] DataSourceRequest request, Sessions _Sessions)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_Sessions);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Update_Success.ToString(), System.Environment.MachineName, "User tried to update sessions detail at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                _Sessions.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Sessions.UpdatedDate = DateTime.Now;
                if (VerifyBussinessRules(_Sessions))
                {
                    //int value = DateTime.Compare(_Sessions.StartTime, _Sessions.EndTime);
                    DateTime t1 = Convert.ToDateTime(_Sessions.StartTimeString);
                    DateTime t2 = Convert.ToDateTime(_Sessions.EndTimeString);
                    string date = Convert.ToDateTime(_Sessions.ScheduleDate).ToString("MM-dd-yyyy");
                    _Sessions.ScheduleDate = Convert.ToDateTime(date);
                    int value = DateTime.Compare(t1, t2);
                    // checking 
                    if (value < 0)
                    {
                        if (_SessionBAL.GetSessionVenueOccupancyDetailUPBAL(_Sessions) > 0)
                        {
                            ModelState.AddModelError(lr.VenueOcupaidByOther, lr.VenueOcupaidByOther);
                        }
                        else
                        {
                            this._SessionBAL.TMS_Sessions_UpdateBAL(_Sessions);
                            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                            if (string.IsNullOrEmpty(ip))
                                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                            // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                            // string browserName = req.Browser.Browser;
                            _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(lr.SessionTimeConflict, lr.StartandEndTimeConflict);

                    }
                }
            }

            var resultData = new[] { _Sessions };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteSession")]
        public ActionResult Sessions_Destroy([DataSourceRequest] DataSourceRequest request, Sessions _Sessions)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_Sessions);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Delete_Success.ToString(), System.Environment.MachineName, "User tried to destroy sessions detail at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                _Sessions.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Sessions.UpdatedDate = DateTime.Now;
                var _returnValue = _CourseBAL.TMS_SessionAttendance_GetAllBAL(_Sessions);
                if (_returnValue.Count > 0)
                {
                    ModelState.AddModelError(lr.PersonSkill, lr.FlagDuplicationCheck);
                }
                else
                {
                    var result = this._SessionBAL.TMS_Sessions_DeleteBAL(_Sessions);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                    // string browserName = req.Browser.Browser;
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
            }
            var resultData = new[] { _Sessions };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteSession")]

        public JsonResult SessionDelteChk(string _Sessions)
        {
            bool result = false;
            var _returnValue = _CourseBAL.TMS_SessionAttendance_GetAllByIDBAL(Convert.ToInt32(_Sessions));
            if (_returnValue.Count > 0)
            {
                result = false;

            }
            else
            {
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [ClaimsAuthorize("CanAddEditSession")]
        [DontWrapResult]
        public JsonResult ClassDetailById(string id, string sid)
        {
            var result = _SessionBAL.GetClassDetailByClassIdForNewSessionBAL(id, sid);
            result.ClassName = result.ClassName + "-" + (result.Count + 1);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private bool VerifyBussinessRules(Sessions sesions)
        {
            bool isValid = true;
            sesions.StartTime = UtilityFunctions.MapValue<DateTime>(sesions.ScheduleDate.ToShortDateString() + " " + sesions.StartTimeString, typeof(DateTime));
            //date time if the end date is for the next day
            DateTime dtEndTime = UtilityFunctions.MapValue<DateTime>(sesions.ScheduleDate.ToShortDateString() + " " + sesions.EndTimeString, typeof(DateTime));
            if (dtEndTime < sesions.StartTime)
                dtEndTime = dtEndTime.AddDays(1);

            sesions.EndTime = dtEndTime;

            var result = _SessionBAL.GetClassDetailByClassIdForNewSessionBAL(sesions);

            if (result.MaximumSessionLimitReached)
            {
                ModelState.AddModelError(lr.ClassMaximumSessionPerDay +"  " +sesions.ScheduleDate, lr.SessionMaximumSessionLimitReached + "  " + sesions.ScheduleDate);
                return false;
            }
            else if (!result.IsValidSessionDateTime)
            {
                ModelState.AddModelError(lr.SessionTimeConflict + "  " + sesions.ScheduleDate, lr.SessionIsValidSessionTime + "  " + sesions.ScheduleDate);
                return false;
            }
            else if (!result.IsValidScheduleDate)
            {
                ModelState.AddModelError(lr.SessionScheduleDate + "  " + sesions.ScheduleDate, lr.SessionIsValidScheduleDate + "  " + sesions.ScheduleDate);
                return false;
            }
            else if (!result.IsValidTrainerTime)
            {
                ModelState.AddModelError(lr.Trainer+sesions.ScheduleDate + "  " + sesions.ScheduleDate, lr.SessionIsValidTrainerTime + "  " + sesions.ScheduleDate);
                return false;
            }
            else if (!result.IsValidVenueTime )
            {
                ModelState.AddModelError(lr.VenueName + "  " + sesions.ScheduleDate, lr.SessionIsValidVenueTime + "  " + sesions.ScheduleDate);
                return false;
            }
            else if (!result.IsValidVenueAvailabilityTime)
            {
                ModelState.AddModelError(lr.VenueAvailabelTimeRange + "  " + sesions.ScheduleDate, lr.VenueAvailabelTimeRangeIssue + "  " + sesions.ScheduleDate);
                return false;
            }
            else if (!string.IsNullOrEmpty(result.ConflictNames.Trim()))
            {
                ModelState.AddModelError(lr.ClassMaximumSessionPerDay + "  " + sesions.ScheduleDate, string.Format(lr.SessionConflictNames, result.ConflictNames.Trim()));
                return false;
            }

            return isValid;
            //if (CurrentSessionPresenter.MaximumLimitReached(ClassID, CurrentSessionID, ObjSession.ScheduleDate)) //some how completed
            //{
            //    ShowMessage(Message.EnumMessageType.Warning, "MESSAGE_SESSION_MAXIMUMLIMITREACHED");
            //    return false;
            //}
            //else if (!CurrentSessionPresenter.IsValidSessionDateTime(ClassID, CurrentSessionID, ObjSession.ScheduleDate, ObjSession.StartTime, ObjSession.EndTime)) //some how completed
            //{
            //    ShowMessage(Message.EnumMessageType.Warning, "MESSAGE_SESSION_CONFLICTSWITH_OTHERSESSIONS");
            //    return false;
            //}
            //else if (!CurrentSessionPresenter.IsValidScheduleDate(ClassID, ObjSession.ScheduleDate)) //some how completed
            //{
            //    ShowMessage(Message.EnumMessageType.Warning, "MESSAGE_SESSION_INVALID_SCHEDULEDATE");
            //    return false;
            //}
            //else if (!CurrentSessionPresenter.IsValidTrainerTime(ObjSession.ID, ObjSession.TrainerID, ObjSession.ScheduleDate, ObjSession.StartTime, ObjSession.EndTime))
            //{
            //    ShowMessage(Message.EnumMessageType.Warning, "MESSAGE_SESSION_INVALID_TRAINER_TIME");
            //    return false;
            //}
            //else if (!CurrentSessionPresenter.IsValidVenueTime(ObjSession.ID, ObjSession.VenueID, ObjSession.ScheduleDate, ObjSession.StartTime, ObjSession.EndTime))
            //{
            //    ShowMessage(Message.EnumMessageType.Warning, "MESSAGE_SESSION_INVALID_VENUE_TIME");
            //    return false;
            //}
            //else
            //{
            //    string ConflictTrainees = CurrentSessionPresenter.IsValidTraineesSessionTime(ObjSession.ID,
            //        ObjSession.ClassID, ObjSession.ScheduleDate, ObjSession.StartTime, ObjSession.EndTime);
            //    if (ConflictTrainees.Trim() != string.Empty)
            //    {
            //        ConflictTrainees = ConflictTrainees.Trim().TrimEnd(',');
            //        string message = string.Format(TrainingResourceManager.GetMessage("MESSAGE_SESSION_CONFLICT_TRAINEES_SESSIONS"), ConflictTrainees);
            //        message = "<p>" + message + "</p>";
            //        ShowMessageManual(Message.EnumMessageType.Warning, message);
            //        return false;
            //    }
            //}
        }

        #endregion Sessions

        #region Session Logistics

        [DontWrapResult]
        public ActionResult SessionLogistics(long ClassId)
        {
            return PartialView(ClassId);
        }

        [DontWrapResult]
        public JsonResult SessionLogisticsGroups()
        {
            long ClassID = Convert.ToInt64(Session["ClassID"]);
            Session.Remove("ClassID");
            return Json(this._ClassBAL.TMS_ClassLogisticsDLL_GetAllBAL(CurrentCulture, CurrentUser.CompanyID, ClassID), JsonRequestBehavior.AllowGet);
        }

        [ClaimsAuthorize("CanViewClass")]
        [DontWrapResult]
        public ActionResult SessionLogistics_Read([DataSourceRequest] DataSourceRequest request, long ClassID)
        {
            var SearchText = Request.Form["SearchText"];
            long CourseId = 0;
            ViewData["ClassTraineeClassIdCreating"] = ClassID;
            CourseId = Convert.ToInt64(Request.QueryString["ClassID"]);
            var Classs = this._ClassBAL.TMS_SessionLogestics_GetAllBAL(CourseId);
            return Json(Classs.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ClaimsAuthorizeAttribute("CanAddEditClass")]
        [DontWrapResult]
        public ActionResult SessionLogistics_Create([DataSourceRequest] DataSourceRequest request, CourseLogisticRequirements _Class, long ClassID)
        {
            if (ModelState.IsValid)
            {
                //long ClassID = 30014;
                _Class.CreatedBy = CurrentUser.NameIdentifierInt64;
                _Class.CreatedDate = DateTime.Now;
                //_Class.OrganizationID = ID;
                _Class.ID = _ClassBAL.TMS_SessionLogistics_CreateBAL(_Class, ClassID);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                // string browserName = req.Browser.Browser;
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

            }
            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));

        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorizeAttribute("CanAddEditClass")]
        public ActionResult SessionLogistics_Update([DataSourceRequest] DataSourceRequest request, CourseLogisticRequirements _Class, long ClassID)
        {
            if (ModelState.IsValid)
            {
                long CourseId = 0;
                CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
                _Class.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Class.UpdatedDate = DateTime.Now;
                var result = _ClassBAL.TMS_SessionLogistics_UpdateDAL(_Class, ClassID);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                // string browserName = req.Browser.Browser;
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteClass")]
        public ActionResult SessionLogistics_Destroy([DataSourceRequest] DataSourceRequest request, CourseLogisticRequirements _Class, long ClassID)
        {
            if (ModelState.IsValid)
            {
                long CourseId = 0;
                CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
                _Class.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Class.UpdatedDate = DateTime.Now;
                var result = _ClassBAL.TMS_SessionLogistics_DeleteDAL(_Class, ClassID);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                // string browserName = req.Browser.Browser;
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _Class };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region Attendance

        [ClaimsAuthorize("CanViewAttendance")]
        [DontWrapResult]
        public ActionResult ManageAttendance(long id)
        {
            Session["SessionID"] = id;
            var Attendance = _AttendanceBAL.ManageSessionAttendanceBAL(CurrentUser.CompanyID, id);
            return PartialView("_Attendances", Attendance);
        }

        //[ClaimsAuthorize("CanViewCourse")]
        //[DontWrapResult]
        //public ActionResult ManageAttendance()
        //{
        //    long id = 20009;
        //   // long id = Convert.ToInt64(Request.QueryString["id"]);
        //    return Json(_AttendanceBAL.ManageSessionAttendanceBAL(CurrentUser.CompanyID,id));
        //}


        [ClaimsAuthorize("CanAddEditAttendance")]
        [DontWrapResult]
        [HttpPost]
        public ActionResult Attendance_Create(List<Attendance> Attendance, FormCollection frm)
        {
            int Atttype = 0;
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(Attendance);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to insert sessions attendance detail at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                // string att = frm["Present"].ToString();
                if ("Mark All Present" == frm["Present"].ToString())
                {
                    foreach (var _Attendance in Attendance)
                    {
                        _Attendance.CreatedBy = CurrentUser.NameIdentifierInt64;
                        _Attendance.CreatedOn = DateTime.Now;
                        _Attendance.UpdatedBy = CurrentUser.NameIdentifierInt64;
                        _Attendance.UpdatedOn = DateTime.Now;
                        _Attendance.SessionID = Convert.ToInt64(Session["SessionID"]);

                        Atttype = 2;
                        _Attendance.IsMarked = true;
                        _Attendance.Date = DateTime.Now;

                        _Attendance.OrganizationID = CurrentUser.CompanyID;
                        _Attendance.ID = _AttendanceBAL.MarkTraineesAttendanceBAL(_Attendance, Atttype);
                        string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (string.IsNullOrEmpty(ip))
                            ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                        // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                        // string browserName = req.Browser.Browser;
                        _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                    }

                }
                else
                {
                    foreach (var _Attendance in Attendance)
                    {

                        _Attendance.CreatedBy = CurrentUser.NameIdentifierInt64;
                        _Attendance.CreatedOn = DateTime.Now;
                        _Attendance.UpdatedBy = CurrentUser.NameIdentifierInt64;
                        _Attendance.UpdatedOn = DateTime.Now;
                        _Attendance.SessionID = Convert.ToInt64(Session["SessionID"]);
                        if (AttendanceType.Attendance_Type_Unmarked == _Attendance.AttendanceType)
                        {
                            Atttype = 1;
                        }

                        else if (AttendanceType.AttendanceType_Present == _Attendance.AttendanceType)
                        {
                            Atttype = 2;
                        }
                        else if (AttendanceType.AttendanceType_Absent == _Attendance.AttendanceType)
                        {
                            Atttype = 3;
                        }
                        else if (AttendanceType.AttendanceType_OnLeave == _Attendance.AttendanceType)
                        {
                            Atttype = 4;
                        }
                        else if (AttendanceType.AttendanceType_Late == _Attendance.AttendanceType)
                        {
                            Atttype = 5;
                        }
                        else
                        {
                            Atttype = 6;
                        }

                        _Attendance.IsMarked = (_Attendance.AttendanceType != AttendanceType.Attendance_Type_Unmarked);
                        _Attendance.Date = DateTime.Now;
                        _Attendance.OrganizationID = CurrentUser.CompanyID;
                        _Attendance.ID = _AttendanceBAL.MarkTraineesAttendanceBAL(_Attendance, Atttype);

                    }
                }
            }
            // return View ("");
            return RedirectToAction("Sessions", "Program");
        }

        #endregion Attendance

        #region Schedule
        [ClaimsAuthorize("CanViewSchedule")]
        [DontWrapResult]
        public ActionResult Schedule()
        {
            return View("Schedule_Read");
        }
        [ClaimsAuthorize("CanViewSchedule")]
        [DontWrapResult]
        public virtual JsonResult Schedule_Read(string courseId, string classId)
        {
            long? CourseID = Convert.ToInt64(courseId);
            long? ClassID = Convert.ToInt64(classId);
            DateTime date = DateTime.Today;
            int year = date.Year;
            var firstDayOfMonth = new DateTime(year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            return new JsonResult { Data = _AttendanceBAL.ManageScheduleBAL(CurrentUser.CompanyID, CourseID, ClassID, firstDayOfMonth,lastDayOfMonth), MaxJsonLength = Int32.MaxValue, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            // return Json(_AttendanceBAL.ManageScheduleBAL(CurrentUser.CompanyID,CourseID,ClassID).ToDataSourceResult());
        }

        [ClaimsAuthorize("CanViewSchedule")]
        [DontWrapResult]
        public ActionResult ScheduleTemplate(int? ID)
        {
            var course = _AttendanceBAL.CourseGetAllBAL(CurrentCulture, CurrentUser.CompanyID);
            ViewBag.Department = course;
            return PartialView("_ScheduleTemplate", course);
        }

        //public ActionResult GetOfficeByDeptId(int CourseID)
        //{
        //    //List<Office> offices = EmpBAL.GAllOffices(DepartementID);
        //    SelectList obgcity;//= new SelectList(offices, "ID", "Office1", 0);

        //    return Json(obgcity);
        //}


        #endregion Schedule
    }
}