using System;
using System.Security.Claims;

namespace TMS.Web.Core
{
    public class TMSUser : ClaimsPrincipal
    {
        public TMSUser(ClaimsPrincipal principal)
            : base(principal)
        {
        }

        //public TMSUser()
        //{
        //}

        public string Name
        {
            get
            {
                // return this.FindFirst(ClaimTypes.Name).Value;
                return this.FindFirst("TMS_USER_NAME").Value;
            }
        }

        public string GivenName
        {
            get
            {
                // return this.FindFirst(ClaimTypes.GivenName).Value;
                return this.FindFirst("TMS_USER_GIVEN_NAME").Value;
            }
        }

        public string DateOfBirth
        {
            get
            {
                //return this.FindFirst(ClaimTypes.DateOfBirth).Value;
                return this.FindFirst("TMS_USER_DOB").Value;
            }
        }

        public string NameIdentifier
        {
            get
            {
                //   return this.FindFirst(ClaimTypes.NameIdentifier).Value;
                return this.FindFirst("TMS_USER_NAME_IDENTIFIER").Value;
            }
        }

        public long NameIdentifierInt64
        {
            get
            {
                return Convert.ToInt64(this.FindFirst("TMS_USER_NAME_IDENTIFIER").Value);
            }
        }

        public long CompanyID
        {
            get
            {
                return Convert.ToInt64(this.FindFirst("TMS_USER_CompanyID").Value);
            }
        }

        public string Gender
        {
            get
            {
                // return this.FindFirst(ClaimTypes.Gender).Value;
                return this.FindFirst("TMS_USER_GENDER").Value;
            }
        }

        public string Email
        {
            get
            {
                //return this.FindFirst(ClaimTypes.Email).Value;
                return this.FindFirst("TMS_USER_EMAIL").Value;
            }
        }

        //Cusotm Added user Data Fields
        public string P_FirstName
        {
            get
            {
                return this.FindFirst("TMS_USER_P_FirstName").Value;
            }
        }

        public string P_LastName
        {
            get
            {
                return this.FindFirst("TMS_USER_P_LastName").Value;
            }
        }

        public string P_MiddleName
        {
            get
            {
                return this.FindFirst("TMS_USER_P_MiddleName").Value;
            }
        }

        public string P_MaritalStatus
        {
            get
            {
                return this.FindFirst("TMS_USER_P_MaritalStatus").Value;
            }
        }

        public string S_MaritalStatus
        {
            get
            {
                return this.FindFirst("TMS_USER_S_MaritalStatus").Value;
            }
        }

        public string S_FirstName
        {
            get
            {
                return this.FindFirst("TMS_USER_S_FirstName").Value;
            }
        }

        public string S_LastName
        {
            get
            {
                return this.FindFirst("TMS_USER_S_LastName").Value;
            }
        }

        public string S_MiddleName
        {
            get
            {
                return this.FindFirst("TMS_USER_S_MiddleName").Value;
            }
        }

        public string P_Gender
        {
            get
            {
                return this.FindFirst("TMS_USER_P_Gender").Value;
            }
        }

        public string S_Gender
        {
            get
            {
                return this.FindFirst("TMS_USER_S_Gender").Value;
            }
        }

        //public string S_NantionalIDType
        //{
        //    get
        //    {
        //        return this.FindFirst("TMS_USER_S_NantionalIDType").Value;
        //    }
        //}

        //public string P_NantionalIDType
        //{
        //    get
        //    {
        //        return this.FindFirst("TMS_USER_P_NantionalIDType").Value;
        //    }
        //}

        public string NationalIdentity
        {
            get
            {
                return this.FindFirst("TMS_USER_NationalIdentity").Value;
            }
        }

        public string NickName
        {
            get
            {
                return this.FindFirst("TMS_USER_NickName").Value;
            }
        }

        public string ProfileImage
        {
            get
            {
                return this.FindFirst("TMS_USER_PICTURE") == null ? "" : this.FindFirst("TMS_USER_PICTURE").Value;
            }
        }

        public string Theme
        {
            get
            {
                return this.FindFirst("TMS_USER_THEME") == null ? "" : this.FindFirst("TMS_USER_THEME").Value;
            }
        }

        public bool IsAZureAD
        {
            get
            {
                return Convert.ToBoolean(this.FindFirst("TMS_USER_IsAZureAD").Value);
            }
        }
    }
}