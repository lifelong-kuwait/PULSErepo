using Abp.Runtime.Validation;
using Abp.Web.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using TMS.Business.Interfaces.TMS;
using TMS.Library.Users;
using lr = Resources.Resources;

namespace TMS.Web.Controllers
{
    public class HomeController : TMSControllerBase
    {
        private readonly IBALUsers BALUsers;
        private  ICurrentUserClaims Claims { get; set; }
        private IOffice365UsersBAL _Office365UsersBAL { get; set; }
        public HomeController(IBALUsers _BALUsers, ICurrentUserClaims CurrentUserClaims, IOffice365UsersBAL __Office365UsersBAL)
        {
            this.BALUsers = _BALUsers; this.Claims = CurrentUserClaims; this._Office365UsersBAL = __Office365UsersBAL;
        }
        UserHistory userlogin = new UserHistory();
        LoginUsers objloginuser = new LoginUsers();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }
          [HttpGet]
        public ActionResult Office365Enabled()
        {
            var value = this._Office365UsersBAL.TMS_Setting_GetOffice365BAL();
            return View(value);
        }
        [HttpPost]
        public ActionResult Office365Enabled(bool IsOffice365)
        {
            if (this._Office365UsersBAL.TMS_Setting_GetOffice365_UpdateBAL(IsOffice365) >= 1)
            {
                TempData["Success"] = "Success";
            }
            return View(IsOffice365);
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {            
           // var dd = Crypto.CreatePasswordHash("almas");
            var value = this._Office365UsersBAL.TMS_Setting_GetOffice365BAL();
            var model = new LoginModel { ReturnUrl = returnUrl, isOffice365Enabled = value };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableValidation]
        public ActionResult Login(LoginModel infoOfData)
        {
            infoOfData.isOffice365Enabled = false;
            

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", L("Invalidpassword"));
                return View(infoOfData);
            }
            else
            {
                var _objUser = this.BALUsers.LoginUserBAL(infoOfData.Email);
              

                if (_objUser != null)//check if the email is found
                {
                  
                   
                  
                    if (_objUser.IsLockedOut)
                    {
                        ModelState.AddModelError("", lr.UserLockedOutMessage);
                        return View(infoOfData);
                    }
                    //then verify the password
                    if (string.IsNullOrEmpty(_objUser.Password))
                    {
                        ModelState.AddModelError("", L("Invalidpassword"));
                    }
                    else
                    {

                        //  UserHistory userlogin = new UserHistory();
                        //if (_objUser.UserID > 0)
                        //{
                        //    Session["UserID"] = _objUser.UserID;
                        //    userlogin.UserID = _objUser.UserID;
                        //    userlogin.LoginDateTime = DateTime.Now;
                        //    this.BALUsers.Create_UserHistoryBAL(userlogin);
                        //}
                        if (Crypto.VerifyPassword(infoOfData.Password, _objUser.Password))
                        {
                            Session["CompanyID"] = _objUser.CompanyID;
                            Session["UserID"] = _objUser.UserID;
                            userlogin.UserID = _objUser.UserID;
                            userlogin.LoginDateTime = DateTime.Now;
                            this.BALUsers.Create_UserHistoryBAL(userlogin);
                            IdentitySignin(_objUser, false);
                            return Redirect(GetRedirectUrl(infoOfData.ReturnUrl));
                           
                        }
                        else
                        {
                            if (_objUser.LockedOutAttempt >= TMSHelper.FormAuthenticationLockedOutAttemptMax())
                            {
                                this.BALUsers.UpdateUserLockedOutBAL(infoOfData.Email, _objUser.UserID, _objUser.LockedOutAttempt + 1, true);
                                ModelState.AddModelError("", lr.UserLockedOutMessage);
                            }
                            else
                            {
                                this.BALUsers.UpdateUserLockedOutBAL(infoOfData.Email, _objUser.UserID, _objUser.LockedOutAttempt + 1, false);

                                if (_objUser.LockedOutAttempt >= TMSHelper.FormAuthenticationLockedOutAttemptNotifyUser())
                                {
                                    ModelState.AddModelError("", lr.InvalidpasswordWithAttempts + " " + (TMSHelper.FormAuthenticationLockedOutAttemptMax() - _objUser.LockedOutAttempt));
                                }
                                else
                                {
                                    ModelState.AddModelError("", L("Invalidpassword"));
                                }
                            }

                        }
                    }
                }
                else
                {//user is not found with form authentication.
                    ModelState.AddModelError("", L("Invalidpassword"));
                }
                return View(infoOfData);
            }
        }

        public void IdentitySignin(Users _objUser, bool isPersistent = false)
        {
            ////var claims = new List<Claim>();

            ////// create required claims
            ////claims.Add(new Claim(ClaimTypes.DateOfBirth, _objUser.DateOfBirth.ToString()));
            ////claims.Add(new Claim(ClaimTypes.Name, _objUser.P_DisplayName.ToString()));
            ////claims.Add(new Claim(ClaimTypes.GivenName, _objUser.S_DisplayName == null ? _objUser.P_DisplayName : _objUser.S_DisplayName));
            ////claims.Add(new Claim(ClaimTypes.NameIdentifier, _objUser.UserID.ToString()));
            ////claims.Add(new Claim(ClaimTypes.Email, _objUser.Email.ToString()));
            ////claims.Add(new Claim(ClaimTypes.Gender, _objUser.Gender.ToString()));

            ////// custom – my serialized AppUserState object
            ////claims.Add(new Claim("TMS_USER_P_FirstName", _objUser.P_FirstName));
            ////claims.Add(new Claim("TMS_USER_P_LastName", _objUser.P_LastName));
            ////claims.Add(new Claim("TMS_USER_P_MiddleName", _objUser.P_MiddleName == null ? "" : _objUser.P_MiddleName));
            ////claims.Add(new Claim("TMS_USER_P_MaritalStatus", _objUser.P_MaritalStatus == null ? "" : _objUser.P_MaritalStatus));
            ////claims.Add(new Claim("TMS_USER_S_MaritalStatus", _objUser.S_MaritalStatus == null ? "" : _objUser.S_MaritalStatus));
            ////claims.Add(new Claim("TMS_USER_S_FirstName", _objUser.S_FirstName== null ? _objUser.P_FirstName:_objUser.S_FirstName));
            ////claims.Add(new Claim("TMS_USER_S_LastName", _objUser.S_LastName == null ? _objUser.P_LastName : _objUser.S_LastName));
            ////claims.Add(new Claim("TMS_USER_S_MiddleName", _objUser.S_MiddleName == null ? "" : _objUser.S_MiddleName));
            ////claims.Add(new Claim("TMS_USER_P_Gender", _objUser.P_Gender == null ? "" : _objUser.P_Gender));
            ////claims.Add(new Claim("TMS_USER_S_Gender", _objUser.S_Gender == null ? "" : _objUser.S_Gender));
            ////claims.Add(new Claim("TMS_USER_S_NantionalIDType", _objUser.S_NantionalIDType == null ? "" : _objUser.S_NantionalIDType));
            ////claims.Add(new Claim("TMS_USER_P_NantionalIDType", _objUser.P_NantionalIDType == null ? "" : _objUser.P_NantionalIDType));
            ////claims.Add(new Claim("TMS_USER_NationalIdentity", _objUser.NationalIdentity == null ? "" : _objUser.NationalIdentity));
            ////claims.Add(new Claim("TMS_USER_NickName", _objUser.NickName == null ? "" : _objUser.NickName));

            ////claims.Add(new Claim("TMS_USER_PICTURE", _objUser.ProfileImage == null ? "" : _objUser.ProfileImage));
            ////claims.Add(new Claim("TMS_USER_THEME", string.IsNullOrEmpty(_objUser.ProfileTheme) ? "" : _objUser.ProfileTheme));

            ////var userroles = this.BALUsers.TMS_Users_GetAllAssignedSecurityGroupsBAL(_objUser.UserID);
            ////if (userroles != null)
            ////{
            ////    foreach (var item in userroles)
            ////    {
            ////        claims.Add(new Claim(ClaimTypes.Role, item.GroupPermissionCode));
            ////    }
            ////}




            //if (userroles != null)
            //{
            //    foreach (var item in userroles)
            //    {
            //        claims.Add(new Claim(ClaimTypes.Role, item));
            //    }
            //}

            //claims.Add(new Claim(ClaimTypes.Role, "CanViewEmail"));
            //claims.Add(new Claim(ClaimTypes.Role, "CanEditEmail"));
            //claims.Add(new Claim(ClaimTypes.Role, "CanCreateEmail"));
            //claims.Add(new Claim(ClaimTypes.Role, "CanDeletePhone"));

            //ICurrentUserClaims claimsClass ;
            _objUser.IsAZureAD = false;
            var claims = Claims.GetCurrentUserAllClaims(_objUser);

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);

            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            authManager.SignIn(identity);
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Admin");
            }

            return returnUrl;
        }

        public ActionResult LogOut()
        {

            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;
            if (Session["UserID"] != null) { 
            userlogin.UserID = Convert.ToInt64(Session["UserID"]);
         //   userlogin.UserID = objloginuser.UserID;
            userlogin.LogoutDateTime = DateTime.Now;

            this.BALUsers.Update_UserHistoryBAL(userlogin);
        }

            authManager.SignOut( CookieAuthenticationDefaults.AuthenticationType);

                return RedirectToAction("Login", "Home");
        }

        public ActionResult Theme(string theme)
        {
            this.BALUsers.UpdateLoginUserThemesDAL(theme, CurrentUser.NameIdentifierInt64);

            var AuthenticationManager = HttpContext.GetOwinContext().Authentication;
            var Identity = new ClaimsIdentity(User.Identity);
            Identity.RemoveClaim(Identity.FindFirst("TMS_USER_THEME"));
            Identity.AddClaim(new Claim("TMS_USER_THEME", theme));
            AuthenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant
(new ClaimsPrincipal(Identity), new AuthenticationProperties());
            return Content("1");
        }
        //public void Create_UserHistoryBAL(UserHistory userlogin)
        //{
        //    LoginUsers objusers=new LoginUsers();
        //    userlogin.UserID = objusers.UserID;
        //    userlogin.LoginDateTime= DateTime.Now;
        //    this.BALUsers.Create_UserHistoryBAL(userlogin);
        //}
     
        public ActionResult UnAuthenticated()
        {
            return PartialView("_notKnow");
        }

        [DontWrapResult]
        public ActionResult UnAuthorized()
        {
            return Content("403");
        }

        public ActionResult Test()
        {
            List<string> ff = new List<string>();
            ff.Add("1");
            ff.Add("2");
            ff.Add("3");
            ff.Add("4");
            string ifa = string.Empty;
            for (int i = 0; i < ff.Count; i++)
            {
                ifa = ifa + ff[i].ToString();
                if (ff.Count - 1 != i)
                {
                    ifa = ifa + ",";
                }
            }
            return Content("");
        }


        public void SignIn()
        {
                HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" }, OpenIdConnectAuthenticationDefaults.AuthenticationType);
        }

        public void SignOut()
        {
            // Send an OpenID Connect sign-out request.

            if (Session["UserID"] != null)
            {
                userlogin.UserID = Convert.ToInt64(Session["UserID"]);
                //   userlogin.UserID = objloginuser.UserID;
                userlogin.LogoutDateTime = DateTime.Now;

                this.BALUsers.Update_UserHistoryBAL(userlogin);
            }

            HttpContext.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
        }
        public void EndSession()
        {
            // If AAD sends a single sign-out message to the app, end the user's session, but don't redirect to AAD for sign out.
            HttpContext.GetOwinContext().Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
        }

        public void UserNotBelongToSystem()
        {
            // If AAD sends a single sign-out message to the app, end the user's session, but don't redirect to AAD for sign out.
            HttpContext.GetOwinContext().Authentication.SignOut(
               OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
        }
    }
}