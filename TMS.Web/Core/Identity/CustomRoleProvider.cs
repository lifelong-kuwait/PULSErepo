using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TMS.Business.Interfaces.TMS;

namespace TMS.Web.Core.Identity
{
    public class CustomRoleProvider : RoleProvider
    {
        public IBALUsers _dalusers { get; set; }
        public CustomRoleProvider( IBALUsers balUser)
        {
            _dalusers = balUser;
           // _services = new Services();
        }
        public override string[] GetRolesForUser(string username)
        {
            return _dalusers.loginUserRolesBAL(username);
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        public override string Name
        {
            get
            {
                return base.Name;
            }
        }


    }
}