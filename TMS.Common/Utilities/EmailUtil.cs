// ***********************************************************************
// Assembly         : TMS.Common
// Author           : Almas Shabbir
// Created          : 07-09-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 07-09-2017
// ***********************************************************************
// <copyright file="EmailUtil.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataObjects.Common.EmailTemplates;
using TMS.DataObjects.Interfaces.Common.EmailTemplates;
using TMS.Library.Common;

namespace TMS.Common.Utilities
{
    /// <summary>
    /// Class EmailUtil.
    /// </summary>
    public class EmailUtil
    {

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <param name="_UserID">The user identifier.</param>
        /// <param name="Displayname">The displayname.</param>
        /// <param name="isPrimary">if set to <c>true</c> [is primary].</param>
        /// <param name="Subject">The subject.</param>
        /// <returns>System.String.</returns>
        public string GetBody(Int64 _UserID,string Displayname, bool isPrimary,ref string Subject)
       {

           string _URL = UtilityFunctions.AddQuerystringVar(UtilityFunctions.GetConfigurationValue("SITEURL") + ("User/Reset"), "uid", _UserID.ToString());
           _URL = UtilityFunctions.AddQuerystringVar(_URL, "vc", "4");
           _URL = UtilityFunctions.AddQuerystringVar(_URL, "ts",  DateTime.Now.ToString("yyyyMMddHHmmssfff"));
           string fullname = Displayname;

           IEmailTemplatesDAL EmailDal = new EmailTemplatesDAL();
           string template = string.Empty;
           EmailTemplate objEmailTemplate = EmailDal.TMS_Groups_GetAllByCultureDAL(UtilityFunctions.MapValue<int>(Library.EmailTemplateType.UserRegistration, typeof(int)));
            
           if (objEmailTemplate != null)
           {
               if (isPrimary) { template = objEmailTemplate.PrimaryTemplateText; Subject = objEmailTemplate.PrimaryTemplateSubject; }
               else { template = objEmailTemplate.SecondaryTemplateText; Subject = objEmailTemplate.SecondaryTemplateSubject; }
               template = template.Replace("[Name]", fullname);
               template = template.Replace("[AppName]", UtilityFunctions.GetConfigurationValue("ApplicationName"));
               template = template.Replace("[Link]", @"<a href='"+_URL+"'>LINK</a>");
           }
           return template;

       }
    }
}
