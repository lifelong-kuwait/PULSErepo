// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-09-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 07-09-2017
// ***********************************************************************
// <copyright file="EmailTemplatesDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.Common.EmailTemplates;
using TMS.Library.Common;

namespace TMS.DataObjects.Common.EmailTemplates
{
    /// <summary>
    /// Class EmailTemplatesDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Interfaces.Common.EmailTemplates.IEmailTemplatesDAL" />
    public class EmailTemplatesDAL : IEmailTemplatesDAL
    {
        /// <summary>
        /// TMSs the groups get all by culture dal.
        /// </summary>
        /// <param name="TemplateTypeID">The template type identifier.</param>
        /// <returns>EmailTemplate.</returns>
        public EmailTemplate TMS_Groups_GetAllByCultureDAL(int TemplateTypeID)
        {
            EmailTemplate EmailTemplate = new EmailTemplate();
            var conString = DBHelper.ConnectionString;
            using (var conn = new SqlConnection(conString))
            {
                conn.Open();
                string qry = @"TMS_EmailTemplates_GetTemplateTypeID";
                DynamicParameters param = new DynamicParameters();
                param.Add("@TemplateTypeID", TemplateTypeID);
                EmailTemplate = conn.Query<EmailTemplate>(qry.ToString(), param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault<EmailTemplate>();
                conn.Close();
            }
            return EmailTemplate;
        }
    }
}