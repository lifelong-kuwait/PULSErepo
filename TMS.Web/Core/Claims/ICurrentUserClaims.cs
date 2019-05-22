using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Users;

namespace TMS.Web
{
    public interface ICurrentUserClaims
    {
        List<Claim> GetCurrentUserAllClaims(Users _objUser);
        Users CheckIfTheUserExistInOurSystem(string Email);
    }
}
