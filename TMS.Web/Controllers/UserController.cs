using Abp.Runtime.Validation;
using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Business.Interfaces.Common;
using TMS.Business.Interfaces.Common.Groups;
using TMS.Business.Interfaces.TMS;
using TMS.Common;
using TMS.Common.Utilities;
using TMS.Library.Users;
using lr = Resources.Resources;

namespace TMS.Web.Controllers
{
    public class UserController : TMSControllerBase
    {
        private IBALUsers _UserBAL { get; set; }
        private readonly IAttachmentBAL _AttachmentBAL;
        private readonly IGroupsBAL _Groups;
        public UserController(IBALUsers balUser, IAttachmentBAL _AttachmentBAL, IGroupsBAL _Groups)
        {
            _UserBAL = balUser; this._AttachmentBAL = _AttachmentBAL; this._Groups=_Groups;
        }

        public ActionResult Async_Save(IEnumerable<HttpPostedFileBase> files)
        {
            // The Name of the Upload component is "files"
            if (files != null)
            {
                foreach (var file in files)
                {
                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(file.FileName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    // The files are not actually saved in this demo
                    // file.SaveAs(physicalPath);
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        public ActionResult Async_Remove(string[] fileNames)
        {
            // The parameter of the Remove action must be called "fileNames"

            if (fileNames != null)
            {
                foreach (var fullName in fileNames)
                {
                    var fileName = Path.GetFileName(fullName);
                    var physicalPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                    // TODO: Verify user permissions

                    if (System.IO.File.Exists(physicalPath))
                    {
                        // The files are not actually removed in this demo
                        // System.IO.File.Delete(physicalPath);
                    }
                }
            }

            // Return an empty string to signify success
            return Content("");
        }

        #region "Users"

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public JsonResult IsUserWithEmail_Available(string Email, string initialEmail)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return Json("Enter Email please!", JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (Email == initialEmail)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                if (this._UserBAL.LoginUsers_DuplicationCheckBAL(new LoginUsers { Email = Email }) > 0)
                {
                    return Json(lr.UserEmailAlreadyExist, JsonRequestBehavior.AllowGet);
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Reset()
        {
            //need to update the logic check if the user belong to system then show him the change c password then also check on timestamp like only k=link is valid for thee 24 hours
            long UserID = Convert.ToInt64(UtilityFunctions.GetQueryString("uid"));
            string timestamp = UtilityFunctions.GetQueryString("ts");
            long CurrentPersonID = Convert.ToInt32(UtilityFunctions.GetQueryString("pid"));
            long ChangePassword = Convert.ToInt32(UtilityFunctions.GetQueryString("vc"));
            if ((UserID > 0 && ChangePassword > 0) || (CurrentPersonID > 0 && ChangePassword > 0))
            {
                ChangePasswordModel model = new ChangePasswordModel
                {
                    ts = timestamp,
                    uid = UserID
                };
                return View(model);
            }
            else
            {
                return RedirectPermanent("~/Home/Login");
            }
        }
        [HttpPost]
        public ActionResult Reset(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                LoginUsers _objUsers = new LoginUsers
                {
                    Password = Crypto.CreatePasswordHash(model.Password),
                    UserID = model.uid,
                    UpdatedBy = 1,
                    UpdatedDate = DateTime.UtcNow
                };
                var res = this._UserBAL.LoginUsers_UpdatePasswordBAL(_objUsers);
                return RedirectPermanent("~/Home/Login");
            }
            return View(model);
        }
        [ClaimsAuthorize("CanViewUsers")]
        public ActionResult Index()
        {
            return View();
        }

        [DontWrapResult]
        [ClaimsAuthorizeAttribute("CanViewUsers")]
        public ActionResult LoginUser_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
         //   int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }

            //var user = this._UserBAL.LoginUsers_GetAllBAL(CurrentCulture, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            //if (CurrentUser.CompanyID > 0)
            //{
            //    user = this._UserBAL.LoginUsersOrganization_GetAllBAL(CurrentCulture, Convert.ToString(CurrentUser.CompanyID), startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            //}
            //var result = new DataSourceResult()
            //{
            //    Data = user, // Process data (paging and sorting applied)
            //    Total = Total // Total number of records
            //};
            //return Json(result);

            if (CurrentUser.CompanyID > 0)
            {
                //var _userdata = this._UserBAL.LoginUsersOrganization_GetAllBAL(CurrentCulture, Convert.ToString(CurrentUser.CompanyID), startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
                var _userdata = this._UserBAL.LoginUsersOrganization_GetAllBAL(CurrentCulture, Convert.ToString(CurrentUser.CompanyID), SearchText);
                return Json(_userdata.ToDataSourceResult(request, ModelState));
                //var result = new DataSourceResult()
                //{
                //    Data = _userdata, // Process data (paging and sorting applied)
                //    Total = Total // Total number of records
                //};
                //return Json(result);
            }
            else
            {
                //var _userdata = this._UserBAL.LoginUsers_GetAllBAL(CurrentCulture, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
                var _userdata = this._UserBAL.LoginUsers_GetAllBAL(CurrentCulture, SearchText);
                return Json(_userdata.ToDataSourceResult(request, ModelState));
                //var result = new DataSourceResult()
                //{
                //    Data = _userdata, // Process data (paging and sorting applied)
                //    Total = Total // Total number of records
                //};
                //return Json(result);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult LoginUser_Create([DataSourceRequest] DataSourceRequest request, LoginUsers _objUsers, string filename, long aid)
        {
            if (ModelState.IsValid)
            {
                if (this._UserBAL.LoginUsers_DuplicationCheckBAL(new LoginUsers { Email = _objUsers.Email }) > 0)
                {
                    return Json(lr.UserEmailAlreadyExist, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if (!_objUsers.IsSendCreatePasswordEmail)
                    {
                        if (_objUsers.ConfirmPassword != _objUsers.Password)
                        {
                            ModelState.AddModelError(lr.UserConfirmPassword, lr.UserConfirmPasswordNotMatch);
                        }
                        else
                        {
                            _objUsers.CreatedBy = CurrentUser.NameIdentifierInt64;
                            _objUsers.CreatedDate = DateTime.Now;
                            _objUsers.CompanyID = CurrentUser.CompanyID;
                            _objUsers.AddedByAlias = CurrentUser.Name;
                            _objUsers.Password = Crypto.CreatePasswordHash(_objUsers.Password);
                            _objUsers.UserID = this._UserBAL.LoginUsers_CreateBAL(ref _objUsers);//.PersonEmailAddress_CreateBAL(_objGroups);
                        }
                    }
                    else
                    {
                        _objUsers.CreatedBy = CurrentUser.NameIdentifierInt64;
                        _objUsers.CreatedDate = DateTime.Now;
                        _objUsers.CompanyID = CurrentUser.CompanyID;
                        _objUsers.AddedByAlias = CurrentUser.Name;
                        _objUsers.Password = "";                        
                        _objUsers.UserID = this._UserBAL.LoginUsers_CreateBAL(ref _objUsers);//.PersonEmailAddress_CreateBAL(_objGroups);
                        if (_objUsers.IsSendCreatePasswordEmail)
                        {
                            if (HandleSendEmailToUser(_objUsers))
                            {

                            }
                            else
                            {
                                ModelState.AddModelError(lr.UserEmail, lr.UserEmailNotSendButUserCreated);
                            }
                        }
                    }
                }
                var image = HandlProfilePicture(filename, _objUsers.UserID, aid);

                if (!string.IsNullOrEmpty(image))
                {
                    _objUsers.ProfileImage = image;
                    var res = this._UserBAL.LoginUsers_UpdateProfileImageBAL(_objUsers);
                    _objUsers.ProfileImage = image.Replace("~/", "");
                }
                else { _objUsers.ProfileImage = null; }
            }
            var resultData = new[] { _objUsers };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

       
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        public ActionResult LoginUser_Update([DataSourceRequest] DataSourceRequest request, LoginUsers _objUsers,string filename, long aid)
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
            if (CurrentUser.CompanyID > 0)
            {
                return Json(this._Groups.TMS_Groups_GetAllByOrganizationCultureBAL(CurrentCulture,CurrentUser.CompanyID), JsonRequestBehavior.AllowGet);
            }
            else {
                return Json(this._Groups.TMS_Groups_GetAllByCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}