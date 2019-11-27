// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-29-2017
// ***********************************************************************
// <copyright file="IDDLBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Entities.Language;
using TMS.Library.TMS.Persons;

namespace TMS.Business.Interfaces.Common.DDL
{
    /// <summary>
    /// Interface IDDLBAL
    /// </summary>
    public interface IDDLBAL
    {
        /// <summary>
        /// Cores the countries get allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<CoreLanguage> CoreLanguage_GetAllByCultureBAL(string culture);

        IList<DDlList> Coordinator_GetAllByCultureBAL(string culture, long CompanyID);

        /// <summary>
        /// Cores the countries get allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CoreCountries_GetAllbyCultureBAL(string culture);

        /// <summary>
        /// Cores the countries get allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CoreCountries_GetAllbyCultureBALbyOrganization(string culture,string Oid);

        /// <summary>
        /// Cores the region state get allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CountryId">The country identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CoreRegionState_GetAllbyCultureBAL(string culture, int CountryId);

        /// <summary>
        /// Cores the region state get allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CountryId">The country identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CoreRegionState_GetAllbyCultureBALbyOrganization(string culture, int CountryId,string Oid);

        /// <summary>
        /// Cores the cities region get allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="RegionId">The region identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CoreCitiesRegion_GetAllbyCultureBAL(string culture, int RegionId);

        IList<DDlList> Resources_GetAllbyCultureBAL(string culture);

        /// <summary>
        /// Cores the cities region get allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="RegionId">The region identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CoreCitiesRegion_GetAllbyCultureBALbyOrganization(string culture, int RegionId,string Oid);

        /// <summary>
        /// Countries the code get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CountryCode_GetAllByCultureBAL(string culture);

        /// <summary>
        /// Countries the code get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> NationalityCode_GetAllByCultureBAL(string culture);

        /// <summary>
        /// Organizations the types get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> OrganizationTypes_GetAllByCultureBAL(string culture);

        /// <summary>
        /// Persons the get allfor DDL bal.
        /// </summary>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> PersonGetAllforDDL_BAL(long CompanyID);
        IList<DDlList> CRMClasses(string culture, long CompanyID);
             IList<DDlList> CRM_Courses(string culture, long CompanyID);
        IList<DDlList> HowHeard(string culture, long CompanyID);
        IList<DDlList> CRM_Users(string culture, long CompanyID);
        
        /// <summary>
        /// Users the get allfor DDL bal.
        /// </summary>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> UserGetAllforDDL_BAL(long companyId);

        IList<DDlList> UserGetAllUnassignedforDDL_BAL();

        IList<DDlList> GetAllClasses();

        /// <summary>
        /// Organizations the person relation types get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> OrganizationPersonRelationTypes_GetAllByCultureBAL(string culture);

        /// <summary>
        /// Courses the categories get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CategoryType">Type of the category.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CourseCategories_GetAllByCultureBAL(string culture, int CategoryType,long CompanyID);

        /// <summary>
        /// Courses the vendors get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CourseVendors_GetAllByCultureBAL(string culture, long CompanyID);

        /// <summary>
        /// Currencieses the get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> Currencies_GetAllByCultureBAL(string culture);

        /// <summary>
        /// Currencieses the get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CurrenciesbyOrganization_GetAllByCultureBAL(string culture, long Oid);

        /// <summary>
        /// Programs the languages get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> ProgramLanguages_GetAllByCultureBAL(string culture);
        /// <summary>
        /// Programs the languages get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> ProgramLanguages_GetAllByCourseCultureBAL(string culture);
        /// <summary>
        /// Programs the languages get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> ProgramLanguages_GetAllByClassCultureBAL(string culture);
        /// <summary>
        /// Courseses the get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> Courses_GetAllByCultureBAL(string culture, long CompanyID,long personID);
        /// <summary>
        /// Classeses the by course identifier and culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CourseId">The course identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> Classes_ByCourseIdAndCultureBAL(string culture, string CourseId, long CompnayID);

        /// <summary>
        /// Roleses the get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> Roles_GetAllByCultureBAL(string culture, long oid);
        IList<DDlList> ProgramLanguages_GetAllByCultureClassBAL(string culture, long ClassID);


        IList<DDlList> TrainerDDLBAL(string culture, long CompnayID);


        IList<DDlList> ClassDDLBAL(string culture, long CompnayID);
        IList<DDlList> CourseDDLBAL(string culture, long CompnayID);

        IList<DDlList> Course_ClassDDLBAL(string culture, long CompnayID,long CourseID,long PersonId);

        IList<DDlList> Class_TrainerDDLBAL(string culture, long CompnayID, long ClassID);

        IList<DDlList> TraineeDDLBAL(string culture, long CompnayID);

        IList<DDlList> Class_TraineeDDLBAL(string culture, long CompnayID, long ClassID);
        //  int LanguageExistCountBAL(long CompnayID);

        IList<DDlList> VenueDDLBAL(string culture, long CompnayID);
    }
}