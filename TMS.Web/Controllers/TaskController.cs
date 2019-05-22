using Abp.Runtime.Validation;
using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using TelerikReportLibrary;
using TMS.Business.Interfaces.Common;
using TMS.Business.Interfaces.Common.Groups;
using TMS.Business.Interfaces.CRM;
using TMS.Business.Interfaces.TMS;
using TMS.Common;
using TMS.Common.Utilities;
using TMS.Library.Entities.CRM;
using TMS.Library.Task;
using TMS.Library.Users;
using lr = Resources.Resources;

namespace TMS.Web.Controllers
{
    public class TaskController : TMSControllerBase
    {
        private readonly ISalesAdministrationBAL _objSaleBAL;

      
        private IBALTask _TaskBAL { get; set; }
        private IBALUsers _UserBAL { get; set; }
        private readonly IAttachmentBAL _AttachmentBAL;
        private readonly IGroupsBAL _Groups;
        public TaskController(IBALUsers balUser, IAttachmentBAL _AttachmentBAL, IGroupsBAL _Groups,IBALTask balTask, ISalesAdministrationBAL _objSalesBAL)
        {
            _UserBAL = balUser; this._AttachmentBAL = _AttachmentBAL; this._Groups = _Groups; _TaskBAL = balTask;
            _objSaleBAL = _objSalesBAL;
        }


        // GET: Task
        [ClaimsAuthorize("CanViewUsers")]
        public ActionResult Index()
        {
            return View();
        }

        #region Status

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public JsonResult EditStatusDone([DataSourceRequest]DataSourceRequest request,Sls_Task _objTask,string ID)
        {
            long _viewID = long.Parse(ID);
            _objTask.ModifiedBy = 216;
            _objTask.ModifiedOn = DateTime.Now;
            var result = this._TaskBAL.ChangeStatus_DoneBAL(_objTask);
            if (result == -1)
            {
                ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
            }
            var resultData = new[] { _objTask };
            return Json(resultData, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public JsonResult EditStatusUnderway([DataSourceRequest]DataSourceRequest request, Sls_Task _objTask, string ID)
        {
            long _viewID = long.Parse(ID);
            _objTask.ModifiedBy = 216;
            _objTask.ModifiedOn = DateTime.Now;
            var result = this._TaskBAL.ChangeStatus_UnderwayBAL(_objTask);
            if (result == -1)
            {
                ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
            }
            var resultData = new[] { _objTask };
            return Json(resultData, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [ClaimsAuthorize("CanViewUsers")]
        public ActionResult EditStatusRescheduled(string ID,string DueDate)
        {
            Sls_Task objtask = new Sls_Task();
            objtask.ID = int.Parse(ID);
            DateTime date = DateTime.ParseExact(DueDate, "{0:MM-dd-yyyy}", null);
            objtask.DueDate = date;
            return View(objtask);
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult EditStatusRescheduled(Sls_Task _objTask)
        {
            
            _objTask.ModifiedBy = 216;
            _objTask.ModifiedOn = DateTime.Now;
            var result = this._TaskBAL.ChangeStatus_RescheduleBAL(_objTask);
            if (result == -1)
            {
                ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
            }
            var resultData = new[] { _objTask };
            return RedirectToAction("Index");
        }

        #endregion

        #region CURD
        [DontWrapResult]
        [ClaimsAuthorize("CanViewUsers")]
        public ActionResult Sls_Tasks_Read([DataSourceRequest] DataSourceRequest request)
        {
            if (CurrentUser.CompanyID > 0)
            {
                return Json(this._TaskBAL.Task_GetAllBALbyOrganization(CurrentCulture,Convert.ToString(CurrentUser.CompanyID),CurrentSession.UserId).ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(this._TaskBAL.Task_GetAllBAL(CurrentCulture, CurrentSession.UserId).ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
            }
            

            //return Json(this._UserBAL.LoginUsers_GetAllBAL(CurrentCulture).ToDataSourceResult(request, ModelState));
        }


        [ClaimsAuthorizeAttribute("CanAddEditPerson")]
        [DontWrapResult]
        public ActionResult Task_Create([DataSourceRequest] DataSourceRequest request, Sls_Task _objTasks)
        {
            if (ModelState.IsValid)
            {
                Sls_Task objTask = new Sls_Task
                {
                    LeadID=_objTasks.LeadID,
                    DueDate=_objTasks.DueDate,
                    OrganizationID=CurrentUser.CompanyID,
                    Status=3,
                    Description=_objTasks.Description,
                    TaskType=_objTasks.TaskType,
                    CompletionTime=DateTime.Now,
                    CreatedBy=CurrentUser.NameIdentifierInt64,
                    CreatedOn=DateTime.Now,
                    ModifiedBy=CurrentUser.NameIdentifierInt64,
                    ModifiedOn=DateTime.Now,
                    IsDeleted =false,
                    IsActive =true,
                    AssignedBy=CurrentUser.NameIdentifierInt64,
                    AssignedTo=_objTasks.AssignedTo
                };
                _objTasks.ID = _TaskBAL.Task_CreateBAL(objTask);
                if (_objTasks.ID == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }

            }

            var resultData = new[] { _objTasks };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult LoginUser_Update([DataSourceRequest] DataSourceRequest request, LoginUsers _objUsers, string filename, long aid)
        {
            if (ModelState.IsValid)
            {
                if (_objUsers.ConfirmPassword != _objUsers.Password)
                {

                    ModelState.AddModelError(lr.UserConfirmPassword, lr.UserConfirmPasswordNotMatch);
                }
                else
                {
                    _objUsers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                    _objUsers.UpdatedDate = DateTime.Now;
                    if (String.IsNullOrEmpty(_objUsers.Password))
                    {
                        //update with password otherwise
                        var image = HandlProfilePicture(filename, _objUsers.UserID, aid);
                        if (!string.IsNullOrEmpty(image))
                        {
                            _objUsers.ProfileImage = image;
                            var res = this._UserBAL.LoginUsers_UpdateProfileImageBAL(_objUsers);
                            _objUsers.ProfileImage = image.Replace("~/", "");
                        }
                        var result = this._UserBAL.LoginUsers_UpdateBAL(_objUsers);
                        if (result == -1)
                        {
                            ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                        }
                    }
                    else
                    {
                        var image = HandlProfilePicture(filename, _objUsers.UserID, aid);
                        if (!string.IsNullOrEmpty(image))
                        {
                            _objUsers.ProfileImage = image;
                            var res = this._UserBAL.LoginUsers_UpdateProfileImageBAL(_objUsers);
                            _objUsers.ProfileImage = image.Replace("~/", "");
                        }
                        var result = this._UserBAL.LoginUsers_UpdateBAL(_objUsers);
                        if (result == -1)
                        {
                            ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                        }
                        else
                        {

                            _objUsers.Password = Crypto.CreatePasswordHash(_objUsers.Password);
                            var res = this._UserBAL.LoginUsers_UpdatePasswordBAL(_objUsers);
                            _objUsers.Password = null;
                            _objUsers.ConfirmPassword = null;
                        }
                    }
                }
            }
            var resultData = new[] { _objUsers };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanDeleteUsers")]
        public ActionResult LoginUser_Destroy([DataSourceRequest] DataSourceRequest request, LoginUsers _objUsers)
        {
            //ModelState.Remove("Password");
            //ModelState.Remove("ConfirmPassword");
            if (ModelState.IsValid)
            {
                _objUsers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objUsers.UpdatedDate = DateTime.Now;
                var result = this._UserBAL.LoginUsers_DeleteBAL(_objUsers);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objUsers };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [NonAction]
        private string LoginUser_ProfilePicture(string picturename, long PersonId)
        {
            if (!string.IsNullOrEmpty(picturename))
            {
                //var model = _AttachmentBAL.TMS_Attachment_GetSingleByIdAndTypeBAL(aid);
                //_AttachmentBAL.TMS_Attachment_CompletedProfileLogoBAL(new TMS_Attachments { CompletedDate = DateTime.Now, ID = aid, OpenID = PersonId, OpenType = 1 });
                //return model.FilePath.Replace("~/", "") + model.FileName;
            }
            return null;
        }

        [NonAction]
        private string HandlProfilePicture(string picturename, long OrganizationId, long aid)//handle in case of new is created
        {
            if (!string.IsNullOrEmpty(picturename))
            {
                var _aatchedFromDB = _AttachmentBAL.TMS_Attachment_GetSingleByIdAndTypeBAL(aid);

                var newparentroot = DateTime.Now.Ticks.ToString();
                var physicalPath = Path.Combine(Server.MapPath("~/UploadTempFolder"));
                string strSource = physicalPath + "/" + _aatchedFromDB.FileParentRootFolder + "/" + _aatchedFromDB.FileName;
                string targetString = "~/Attachment/TMS/Users/" + OrganizationId + "/" + newparentroot + "/";
                string targetSource = Utility.CreateDirectory(Path.Combine(Server.MapPath(targetString))) + _aatchedFromDB.FileName;
                Utility.MoveAttachment(strSource, targetSource, false);
                //System.IO.DirectoryInfo di = new DirectoryInfo(physicalPath + "/" + _aatchedFromDB.FileParentRootFolder);
                //di.Delete();
                //_AttachmentBAL.TMS_Attachment_CompletedOrganizationLogoBAL(new TMS_Attachments { CompletedDate = DateTime.Now, ID = aid, OpenID = OrganizationId, OpenType = 2, FileParentRootFolder = newparentroot, FilePath = targetString });
                //var model = _AttachmentBAL.TMS_Attachment_GetSingleByIdAndTypeBAL(aid);
                return targetString + _aatchedFromDB.FileName;
            }
            return null;
        }

        [NonAction]
        private bool HandleSendEmailToUser(LoginUsers _objUsers)
        {

            EmailUtil emutil = new EmailUtil();
            bool isPrimary = false;
            string Subject = null;
            if (CurrentCulture == TMSHelper.PrimaryLanguageCode())
            {
                isPrimary = true;
            }
            var EmailBody = emutil.GetBody(_objUsers.UserID, (isPrimary == true ? _objUsers.P_DisplayName : _objUsers.S_DisplayName), isPrimary, ref Subject);
            return EmailSend.SendMail(_objUsers.Email, null, Subject, EmailBody, false, null, null);
        }
        #endregion "Users"

        #region"Groups"

        [DontWrapResult]
        public JsonResult UserLoginGroups()
        {
            return Json(this._Groups.TMS_Groups_GetAllByCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Reporting
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult Reporting()
        {
            return View();
        }
        
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult SecondReporting()
        {
            return View();
        }

        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult ThirdReporting()
        {
            //var _person = new List<dummyPersonModel>
            //{
            //    new dummyPersonModel { ID=10024,AddedByAlias="Trainee 1" },
            //    new dummyPersonModel { ID=10031,AddedByAlias="Trainee as 8" },
            //    new dummyPersonModel { ID=10025,AddedByAlias="Trainee 2" },
            //    new dummyPersonModel { ID=10029,AddedByAlias="Trainee = 6" },
            //};

            //var items = new dummyPersonViewModel(_person);
            //items.SelectedPersonId = 10024;
            //return View(items);
            return View();
        }

        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult TraineeDetailReport()
        {
            return View();
        }

        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult SalesOrderDetailReport()
        {
            return View();
        }

        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult InvoiceReport()
        {
            return View();
        }

        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult EmployeeSalesReport()
        {
            return View();
        }

        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult ReportCatalog()
        {
            return View();
        }

        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult ClassDetailReport()
        {
            return View();
        }

        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult EmployeeSalesSummaryReport()
        {
            return View();
        }

        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult TrainerDetailReport()
        {
            return View();
        }

        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult SampleTrainarDetailReport()
        {
            return View();
        }

        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult ListBoundReport()
        {
            return View();
        }

        #endregion




        [ClaimsAuthorize("CanViewSession")]
        public ActionResult SaleAdminstration()
        {
            return View();

        }

        #region Courses

        [ClaimsAuthorize("CanViewSession")]
        [DontWrapResult]
        public ActionResult ManageCourse()
        {

            return PartialView("ManageCourse");
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewProgramTrainer")]
        public ActionResult ManageCourse_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }

            return Json(_objSaleBAL.ManageCourse_GetAllBAL(CurrentUser.CompanyID, SearchText).ToDataSourceResult(request, ModelState));
        }



        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        public ActionResult ManageCourse_Create([DataSourceRequest] DataSourceRequest request, CRMCourses _objlogmap)
        {
            if (ModelState.IsValid)
            {
                _objlogmap.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objlogmap.CreatedDate = DateTime.Now;
                _objlogmap.OrganizationID = CurrentUser.CompanyID;


                _objlogmap.ID = _objSaleBAL.ManageCourse_CreateBAL(_objlogmap);
                //}
            }
            var resultData = new[] { _objlogmap };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        public ActionResult CourseUpdate([DataSourceRequest] DataSourceRequest request, CRMCourses _course)
        {
            if (ModelState.IsValid)
            {

                _course.ModifiedBy = CurrentUser.NameIdentifierInt64;
                _course.ModifiedOn = DateTime.Now;
                var result = _objSaleBAL.CourseUpdateBAL(_course);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _course };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteProgramTrainer")]
        public ActionResult Course_Destroy([DataSourceRequest] DataSourceRequest request, CRMCourses _courses)
        {
            if (ModelState.IsValid)
            {
                _courses.ModifiedBy = CurrentUser.NameIdentifierInt64;
                _courses.ModifiedOn = DateTime.Now;
                var result = _objSaleBAL.Course_DeleteBAL(_courses);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _courses };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }


        #endregion Courses




        #region Configuration

        [ClaimsAuthorize("CanViewSession")]
        [DontWrapResult]
        public ActionResult ManageConfiguration()
        {

            return PartialView("ManageConfiguration");
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewProgramTrainer")]
        public ActionResult ManageConfiguration_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }

            return Json(_objSaleBAL.ManageConfiguration_GetAllBAL(CurrentUser.CompanyID, SearchText).ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorize("CanViewSession")]
        [DontWrapResult]
        public ActionResult ReassignProspect()
        {

            return PartialView("ReassignProspect");
        }


        public ActionResult ReassignProspects(FormCollection form)
        {
            var success = true;
            try
            {
                var prospectIds = form["PersonID"];
                var userId = form["UserID"];
                foreach (var prospectId in prospectIds.Split(','))
                {
                    if (string.IsNullOrEmpty(prospectId)) continue;

                    var oldUser = prospectId.Split('_')[1];
                    var pId = prospectId.Split('_')[0];
                    if (oldUser == userId)
                    {
                        success = false;
                    }
                    else
                    {
                        CRM_UserMapping obj = new CRM_UserMapping();
                        int length = pId.Length;
                        if (length > 8)
                        {
                            string personsid = pId.Remove(0, 25);
                            obj.PersonID = Convert.ToInt64(personsid);
                        }
                        else
                        {
                            obj.PersonID = Convert.ToInt64(pId);
                        }
                        obj.UpdatedBy = CurrentUser.NameIdentifierInt64;
                        obj.UpdatedOn = DateTime.Now;
                            // AssignedBy= CurrentUser.NameIdentifierInt64.ToString(),
                            obj.UserID = Convert.ToInt64(userId);
                        
                        _objSaleBAL.ReassignProspectBAL(obj);

                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
                return View("SaleAdminstration");
            }




        [DontWrapResult]
        [ClaimsAuthorize("CanViewProgramTrainer")]
        public ActionResult Prospects()
        {
            //var startRowIndex = (request.Page - 1) * request.PageSize;
            //int Total = 0;
            //var SearchText = Request.Form["SearchText"];
            //if (request.PageSize == 0)
            //{
            //    request.PageSize = 10;
            //}
            var prospectlist = _objSaleBAL.ReassignProspectBAL(CurrentUser.CompanyID);
            return PartialView(prospectlist);
        }


        [DontWrapResult]
        [ClaimsAuthorize("CanViewProgramTrainer")]
        public ActionResult Users()
        {
            //var startRowIndex = (request.Page - 1) * request.PageSize;
            //int Total = 0;
            //var SearchText = Request.Form["SearchText"];
            //if (request.PageSize == 0)
            //{
            //    request.PageSize = 10;
            //}
            var users = _objSaleBAL.UserProspectBAL(CurrentUser.CompanyID);
            return PartialView(users);
        }



        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        public ActionResult ManageConfiguration_Create([DataSourceRequest] DataSourceRequest request, CRMHowHeard _objlogmap)
        {
            if (ModelState.IsValid)
            {
                _objlogmap.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objlogmap.CreatedDate = DateTime.Now;
                _objlogmap.OrganizationID = CurrentUser.CompanyID;


                _objlogmap.ID = _objSaleBAL.ManageConfiguration_CreateBAL(_objlogmap);
                //}
            }
            var resultData = new[] { _objlogmap };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        public ActionResult ConfigurationUpdate([DataSourceRequest] DataSourceRequest request, CRMHowHeard _course)
        {
            if (ModelState.IsValid)
            {

                _course.ModifiedBy = CurrentUser.NameIdentifierInt64;
                _course.ModifiedOn = DateTime.Now;
                var result = _objSaleBAL.ManageConfiguration_UpdateBAL(_course);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _course };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteProgramTrainer")]
        public ActionResult Configuration_Destroy([DataSourceRequest] DataSourceRequest request, CRMHowHeard _courses)
        {
            if (ModelState.IsValid)
            {
                _courses.ModifiedBy = CurrentUser.NameIdentifierInt64;
                _courses.ModifiedOn = DateTime.Now;
                var result = _objSaleBAL.ManageConfiguration_DeleteBAL(_courses);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _courses };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }


        [ClaimsAuthorizeAttribute("CanViewPersonDetail")]
        public ActionResult Detail(long pid)
        {
            return PartialView("Detail", pid);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewProgramTrainer")]
        public ActionResult ManageDetail_Read([DataSourceRequest] DataSourceRequest request,long TaskID)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }

            return Json(_TaskBAL.Task_GetAllByIdBAL(TaskID).ToDataSourceResult(request, ModelState));
        }

        #endregion Configuration
    }
}