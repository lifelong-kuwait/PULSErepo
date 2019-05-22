using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.TMS.Organization;
using TMS.Library.Common.Address;
using TMS.Library.TMS.Organization;
using TMS.Library.TMS.Organization.POC;
using TMS.Library.Entities.TMS.Language;
using TMS.Business.TMS.Language;

namespace TMS.DataObjects.TMS.Language
{
   public class LanguageDAL: DBGenerics,ILanguageDAL
    {
        public IList<LanguageModel> GetAllLanguagesBAL(long oid)
        {
            return ExecuteListSp<LanguageModel>("TMS_GetAllLanguages", ParamBuilder.Par("OrganizationID", oid));
           // return ExecuteListSp<LanguageModel>("TMS_GetAllLanguages", ParamBuilder.Par("OrganizationID", oid));
        }

        //public IList<LanguageModel> OrganizationAllbyCultureDAL(long culture)
        //{
        //    return ExecuteListSp<LanguageModel>("Organizations_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));
        //}
    }
}
