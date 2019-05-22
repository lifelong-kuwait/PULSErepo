using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using TMS.Business.Interfaces.TMS;
using TMS.Library.Users;

namespace TMS.Web
{
    public class CurrentUserClaims : ICurrentUserClaims
    {
        private readonly IOffice365UsersBAL BALUsers;
        public CurrentUserClaims(IOffice365UsersBAL _BALUsers)
        {
            this.BALUsers = _BALUsers;
        }

        public Users CheckIfTheUserExistInOurSystem(string Email)
        {
            return this.BALUsers.LoginUserBAL(Email);
        }
        public List<Claim> GetCurrentUserAllClaims(Users _objUser)
        {
            var claims = new List<Claim>();

            // create required claims
            //claims.Add(new Claim(ClaimTypes.DateOfBirth, _objUser.DateOfBirth.ToString()));
            //claims.Add(new Claim(ClaimTypes.Name, _objUser.P_DisplayName.ToString()));
            //claims.Add(new Claim(ClaimTypes.GivenName, _objUser.S_DisplayName == null ? _objUser.P_DisplayName : _objUser.S_DisplayName));
            if(!_objUser.IsAZureAD)
            claims.Add(new Claim(ClaimTypes.NameIdentifier, _objUser.UserID.ToString()));
            //claims.Add(new Claim(ClaimTypes.Email, _objUser.Email.ToString()));
            //claims.Add(new Claim(ClaimTypes.Gender, _objUser.Gender.ToString()));


            //new custom defined 
            claims.Add(new Claim("TMS_USER_DOB", _objUser.DateOfBirth.ToString()));
            claims.Add(new Claim("TMS_USER_NAME", _objUser.P_DisplayName.ToString()));
            claims.Add(new Claim("TMS_USER_GIVEN_NAME", _objUser.S_DisplayName == null ? _objUser.P_DisplayName : _objUser.S_DisplayName));
            claims.Add(new Claim("TMS_USER_NAME_IDENTIFIER", _objUser.UserID.ToString()));
            claims.Add(new Claim("TMS_USER_CompanyID", _objUser.CompanyID.ToString()));
            claims.Add(new Claim("TMS_USER_EMAIL", _objUser.Email.ToString()));
            claims.Add(new Claim("TMS_USER_GENDER", _objUser.Gender.ToString()));
            claims.Add(new Claim("TMS_USER_IsAZureAD", _objUser.IsAZureAD.ToString()));
            //new custom defined 


            // custom – my serialized AppUserState object
            claims.Add(new Claim("TMS_USER_P_FirstName", _objUser.P_FirstName));
            claims.Add(new Claim("TMS_USER_P_LastName", _objUser.P_LastName));
            claims.Add(new Claim("TMS_USER_P_MiddleName", _objUser.P_MiddleName == null ? "" : _objUser.P_MiddleName));
            claims.Add(new Claim("TMS_USER_P_MaritalStatus", _objUser.P_MaritalStatus == null ? "" : _objUser.P_MaritalStatus));
            claims.Add(new Claim("TMS_USER_S_MaritalStatus", _objUser.S_MaritalStatus == null ? "" : _objUser.S_MaritalStatus));
            claims.Add(new Claim("TMS_USER_S_FirstName", _objUser.S_FirstName == null ? _objUser.P_FirstName : _objUser.S_FirstName));
            claims.Add(new Claim("TMS_USER_S_LastName", _objUser.S_LastName == null ? _objUser.P_LastName : _objUser.S_LastName));
            claims.Add(new Claim("TMS_USER_S_MiddleName", _objUser.S_MiddleName == null ? "" : _objUser.S_MiddleName));
            claims.Add(new Claim("TMS_USER_P_Gender", _objUser.P_Gender == null ? "" : _objUser.P_Gender));
            claims.Add(new Claim("TMS_USER_S_Gender", _objUser.S_Gender == null ? "" : _objUser.S_Gender));
           // claims.Add(new Claim("TMS_USER_S_NantionalIDType", _objUser.S_NantionalIDType == null ? "" : _objUser.S_NantionalIDType));
           // claims.Add(new Claim("TMS_USER_P_NantionalIDType", _objUser.P_NantionalIDType == null ? "" : _objUser.P_NantionalIDType));
            claims.Add(new Claim("TMS_USER_NationalIdentity", _objUser.NationalIdentity == null ? "" : _objUser.NationalIdentity));
            claims.Add(new Claim("TMS_USER_NickName", _objUser.NickName == null ? "" : _objUser.NickName));

            claims.Add(new Claim("TMS_USER_PICTURE", _objUser.ProfileImage == null ? "" : _objUser.ProfileImage));
            claims.Add(new Claim("TMS_USER_THEME", string.IsNullOrEmpty(_objUser.ProfileTheme) ? "default" : _objUser.ProfileTheme));

            var UserRoles = this.BALUsers.TMS_Users_GetAllAssignedSecurityGroupsBAL(_objUser.UserID);
            if (UserRoles != null)
            {
                foreach (var item in UserRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item.GroupPermissionCode));
                }
            }

            return claims;
        }
    }

   
}