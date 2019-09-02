// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-29-2017
// ***********************************************************************
// <copyright file="IDDLDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Entities.Language;
using TMS.Library.TMS.Persons;

namespace TMS.DataObjects.Interfaces.Common.DDL
{
    /// <summary>
    /// Interface IDDLDAL
    /// </summary>
    public interface IDDLDAL
    {
        /// <summary>
        /// Cores the countries get allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<CoreLanguage> CoreLanguage_GetAllbyCultureDAL(string culture);

        IList<DDlList> Coordinator_GetAllbyCultureDAL(string culture, long CompanyID);

        /// <summary>
        /// Cores the countries get allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CoreCountries_GetAllbyCultureDAL(string culture);

        /// <summary>
        /// Cores the countries get allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CoreCountries_GetAllbyCultureDALbyOrganization(string culture,string Oid);
        IList<DDlList> ProgramLanguages_GetAllByCulturecultureDAL(string culture, long ClassID);

        /// <summary>
        /// Cores the region state get allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CountryId">The country identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CoreRegionState_GetAllbyCultureDAL(string culture, int CountryId);

        /// <summary>
        /// Cores the region state get allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CountryId">The country identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CoreRegionState_GetAllbyCultureDALbyOrganization(string culture, int CountryId,string Oid);

        /// <summary>
        /// Cores the cities region get allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="RegionId">The region identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CoreCitiesRegion_GetAllbyCultureDAL(string culture, int RegionId);
        IList<DDlList> Resources_GetAllbyCultureDAL(string culture);

        /// <summary>
        /// Cores the cities region get allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="RegionId">The region identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CoreCitiesRegion_GetAllbyCultureDALbyOrganization(string culture, int RegionId, string Oid);

        /// <summary>
        /// Countries the code get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CountryCode_GetAllByCultureDAL(string culture);

        /// <summary>
        /// Countries the code get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> NationalityCode_GetAllByCultureDAL(string culture);

        /// <summary>
        /// Organizations the types get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> OrganizationTypes_GetAllByCultureDAL(string culture);

        /// <summary>
        /// Persons the get allfor DDL dal.
        /// </summary>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> PersonGetAllforDDL_DAL(long CompanyID);

        /// <summary>
        /// User the get allfor DDL dal.
        /// </summary>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> UserGetAllforDDL_DAL(long companyId);

        /// <summary>
        /// User the get allfor DDL dal.
        /// </summary>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> UserGetAllUnassignedforDDL_DAL();

        IList<DDlList> ClassGetAllforDDL_DAL();

        /// <summary>
        /// Organizations the person relation types get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> OrganizationPersonRelationTypes_GetAllByCultureDAL(string culture);

        /// <summary>
        /// Courses the categories get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CategoryType">Type of the category.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CourseCategories_GetAllByCultureDAL(string culture, int CategoryType, long CompanyID);
        /// <summary>
        /// Courses the vendors get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CourseVendors_GetAllByCultureDAL(string culture, long CompanyID);

        IList<DDlList> CRMClasses(string culture, long CompanyID);

        IList<DDlList> CRM_Courses(string culture, long CompanyID);
        IList<DDlList> HowHeard(string culture, long CompanyID);

        IList<DDlList> CRM_Users(string culture, long CompanyID);

        

        /// <summary>
        /// Currencieses the get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> Currencies_GetAllByCultureDAL(string culture);
        /// <summary>
        /// Currencieses the get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> CurrenciesbyOrganization_GetAllByCultureDAL(string culture, long Oid);
        /// <summary>
        /// Programs the languages get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> ProgramLanguages_GetAllByCultureDAL(string culture);
        /// <summary>
        /// Programs the languages get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> ProgramLanguages_GetAllByCourseCultureDAL(string culture);
        /// <summary>
        /// Programs the languages get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> ProgramLanguages_GetAllByClassCultureDAL(string culture);
        /// <summary>
        /// Courseses the get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> Courses_GetAllByCultureDAL(string culture, long CompanyID);
        /// <summary>
        /// Classeses the by course identifier and culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CourseId">The course identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> Classes_ByCourseIdAndCultureDAL(string culture, string CourseId, long CompnayID);
        /// <summary>
        /// Roleses the get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> Roles_GetAllByCultureDAL(string culture, long oid);


        IList<DDlList> TrainerDDLDAL(string culture, long CompnayID);
        IList<DDlList> TraineeDDLDAL(string culture, long CompnayID);

        IList<DDlList> VenueDDLDAL(string culture, long CompnayID);

        IList<DDlList> ClassDDLDAL(string culture, long CompnayID);

        IList<DDlList> CourseDDLDAL(string culture, long CompnayID);

        IList<DDlList> Course_ClassDDLDAL(string culture, long CompnayID, long CourseID);

        

        IList<DDlList> Class_TrainerDDLDAL(string culture, long CompnayID, long ClassID);
        IList<DDlList> Class_TraineeDDLDAL(string culture, long CompnayID, long ClassID);
        IList<DDlList> Class_VenueDDLDAL(string culture, long CompnayID, long ClassID);

        IList<DDlList> GetAllCourseCategoriesDAL(string culture, long CompnayID);
    }
}