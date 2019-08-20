using Abp.Web.Models;
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


        public ProgramController(ICourseBAL ICourseBAL, IConfigurationBAL _objIConfigurationBAL, IClassBAL IClassBAL, ISessionBAL _ISessionBAL, IAttendanceBAL _IAttendanceBAL)
        {
            _objConfigurationBAL = _objIConfigurationBAL;
            _CourseBAL = ICourseBAL;
            _ClassBAL = IClassBAL;
            _SessionBAL = _ISessionBAL;
            _AttendanceBAL = _IAttendanceBAL;
        }

        #region Course

        [ClaimsAuthorize("CanViewCourse")]
        public ActionResult Course()
        {
            return View();
        }

        [ClaimsAuthorize("CanViewCourse")]
        public ActionResult CourseDetail()
        {
            var id = Request.QueryString["id"];
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
                Courses = this._CourseBAL.TMS_CoursesByOrganization_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText, Convert.ToString(CurrentUser.CompanyID));
            }
            var result = new DataSourceResult()
            {
                Data = Courses, // Process data (paging and sorting applied)
                Total = Total // Total number of records
            };
            return Json(result);
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
        public ActionResult Course_Destroy([DataSourceRequest] DataSourceRequest request, Course _Course)
        {
            if (ModelState.IsValid)
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
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if(SearchText=="")
                SearchText=null;
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            long CourseId = 0;
            CourseId = Convert.ToInt64(Request.QueryString["CourseId"]);
            var Classs = this._ClassBAL.TMS_Classes_GetAllBAL(CourseId, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            if (CurrentUser.CompanyID > 0)
            {
                Classs = this._ClassBAL.TMS_ClassesByOrganization_GetAllBAL(CourseId, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText, Convert.ToString(CurrentUser.CompanyID));
            }
            var result = new DataSourceResult()
            {
                Data = Classs, // Process data (paging and sorting applied)
                Total = Total // Total number of records
            };
            return Json(result);
        }

        [ClaimsAuthorize("CanViewClass")]
        [DontWrapResult]
        public JsonResult CourseDetailById(string id)
        {
            int count = 0;
            var result = _ClassBAL.GetCourseDetailByIdForNewClassBAL(id, ref count);
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
                    ModelState.AddModelError(lr.SessionTimeConflict, lr.StartandEndDateConflict);
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
                    ModelState.AddModelError(lr.SessionTimeConflict, lr.StartandEndDateConflict);
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
            if (ModelState.IsValid)
            {
                //  string PersonIds = "2233";
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
                _Classes.CreatedBy = CurrentUser.NameIdentifierInt64;
                _Classes.CreatedDate = DateTime.Now;
                _Classes.ClassID = cid;
                _Classes.ID = _ClassBAL.TrainerOpenMapping_CreateByPersonIdsBAL(_Classes, PersonIds);
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
                    ModelState.AddModelError(lr.OrganizationNameDublicaton, lr.OrganizationNameDublicaton);
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
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
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
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
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
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
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

                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
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
            return View();
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
                    ViewData["model"] = data;
                    return View();
                }
            }
        }

        [ClaimsAuthorize("CanViewSession")]
        [DontWrapResult]
        public ActionResult Sessions_Read([DataSourceRequest] DataSourceRequest request)
        {

            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            long ClassID = 0;
            ClassID = Convert.ToInt64(Request.QueryString["ClassId"]);
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }

            var Courses = this._SessionBAL.TMS_Sessions_GetALLByCultureBAL(ClassID, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            if (CurrentUser.CompanyID > 0)
            {
                //if (_SessionBAL.User_EmailCheckBAL(CurrentUser.CompanyID, CurrentUser.Email) > 0)
                //{
                //    Courses = this._SessionBAL.TMS_SessionsTrainer_GetALLByCultureBAL(CurrentUser.Email,ClassID, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText, Convert.ToString(CurrentUser.CompanyID));

                //}
                // else {
                Courses = this._SessionBAL.TMS_SessionsbyOrganization_GetALLByCultureBAL(ClassID, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText, Convert.ToString(CurrentUser.CompanyID));
                // }
            }

            var result = new DataSourceResult()
            {
                Data = Courses, // Process data (paging and sorting applied)
                Total = Total // Total number of records
            };
            return Json(result);
        }

        [ClaimsAuthorize("CanAddEditSession")]
        [DontWrapResult]
        public ActionResult Sessions_Create([DataSourceRequest] DataSourceRequest request, Sessions _Sessions, long ClassID)
        {
            if (ModelState.IsValid)
            {
                if (VerifyBussinessRules(_Sessions))
                {
                    DateTime t1 = Convert.ToDateTime(_Sessions.StartTimeString);
                    DateTime t2 = Convert.ToDateTime(_Sessions.EndTimeString);
                    int value = DateTime.Compare(t1, t2);
                    // checking 
                    if (value < 0)
                    {


                        _Sessions.CreatedBy = CurrentUser.NameIdentifierInt64;
                        _Sessions.CreatedDate = DateTime.Now;
                        _Sessions.OrganizationID = CurrentUser.CompanyID;
                        _Sessions.ClassID = ClassID;
                        if (VerifyBussinessRules(_Sessions))
                        {
                            if (_SessionBAL.GetSessionVenueOccupancyDetailBAL(_Sessions) > 0)
                            {
                                ModelState.AddModelError(lr.VenueOcupaidByOther, lr.VenueOcupaidByOther);
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
                        ModelState.AddModelError(lr.SessionTimeConflict, lr.StartandEndDateConflict);

                    }


                }


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
                _Sessions.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Sessions.UpdatedDate = DateTime.Now;
                if (VerifyBussinessRules(_Sessions))
                {
                    //int value = DateTime.Compare(_Sessions.StartTime, _Sessions.EndTime);
                    DateTime t1 = Convert.ToDateTime(_Sessions.StartTimeString);
                    DateTime t2 = Convert.ToDateTime(_Sessions.EndTimeString);
                    int value = DateTime.Compare(t1, t2);
                    // checking 
                    if (value < 0)
                    {
                        if (_SessionBAL.GetSessionVenueOccupancyDetailBAL(_Sessions) > 0)
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
                        ModelState.AddModelError(lr.SessionTimeConflict, lr.StartandEndDateConflict);

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
        [DisableValidation]
        public JsonResult SessionDelteChk(int _Sessions)
        {
            bool result = false;
            var _returnValue = _CourseBAL.TMS_SessionAttendance_GetAllByIDBAL(_Sessions);
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
                ModelState.AddModelError(lr.ClassMaximumSessionPerDay, lr.SessionMaximumSessionLimitReached);
                return false;
            }
            else if (!result.IsValidSessionDateTime)
            {
                ModelState.AddModelError(lr.SessionTimeConflict, lr.SessionIsValidSessionTime);
                return false;
            }
            else if (!result.IsValidScheduleDate)
            {
                ModelState.AddModelError(lr.SessionScheduleDate, lr.SessionIsValidScheduleDate);
                return false;
            }
            else if (!result.IsValidTrainerTime)
            {
                ModelState.AddModelError(lr.Trainer, lr.SessionIsValidTrainerTime);
                return false;
            }
            else if (!result.IsValidVenueTime)
            {
                ModelState.AddModelError(lr.VenueName, lr.SessionIsValidVenueTime);
                return false;
            }
            else if (!result.IsValidVenueAvailabilityTime)
            {
                ModelState.AddModelError(lr.VenueAvailabelTimeRange, lr.VenueAvailabelTimeRangeIssue);
                return false;
            }
            else if (!string.IsNullOrEmpty(result.ConflictNames.Trim()))
            {
                ModelState.AddModelError(lr.ClassMaximumSessionPerDay, string.Format(lr.SessionConflictNames, result.ConflictNames.Trim()));
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
            return new JsonResult { Data = _AttendanceBAL.ManageScheduleBAL(CurrentUser.CompanyID, CourseID, ClassID), JsonRequestBehavior = JsonRequestBehavior.AllowGet };

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