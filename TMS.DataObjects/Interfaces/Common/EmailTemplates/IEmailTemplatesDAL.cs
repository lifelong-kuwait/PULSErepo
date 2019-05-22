// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-09-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 07-09-2017
// ***********************************************************************
// <copyright file="IEmailTemplatesDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using TMS.Library.Common;
namespace TMS.DataObjects.Interfaces.Common.EmailTemplates
{
    /// <summary>
    /// Interface IEmailTemplatesDAL
    /// </summary>
    public interface IEmailTemplatesDAL
    {
        /// <summary>
        /// TMSs the groups get all by culture dal.
        /// </summary>
        /// <param name="TemplateTypeID">The template type identifier.</param>
        /// <returns>EmailTemplate.</returns>
        EmailTemplate TMS_Groups_GetAllByCultureDAL(int TemplateTypeID);
    }
}