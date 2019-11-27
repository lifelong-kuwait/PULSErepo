// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas
// Created          : 07-08-2017
//
// Last Modified By : Almas
// Last Modified On : 02-10-2018
// ***********************************************************************
// <copyright file="DDLBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using TMS.Business.Interfaces.Common.DDL;
using TMS.DataObjects.Common.DDL;
using TMS.DataObjects.Interfaces.Common.DDL;
using TMS.Library.Entities.Language;
using TMS.Library.TMS.Persons;

namespace TMS.Business.Common.DDL
{
    /// <summary>
    /// Class DDLBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.Common.DDL.IDDLBAL" />
    public class DDLBAL : IDDLBAL
    {
        /// <summary>
        /// The dal
        /// </summary>
        public readonly IDDLDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="DDLBAL" /> class.
        /// </summary>
        public DDLBAL()
        {
            DAL = new DDLDAL();
        }

        /// <summary>
        /// Cores the countries get allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<CoreLanguage> CoreLanguage_GetAllByCultureBAL(string culture)
        {
            return DAL.CoreLanguage_GetAllbyCultureDAL(culture);
        }

        public IList<DDlList> Coordinator_GetAllByCultureBAL(string culture,long CompanyID)
        {
            return DAL.Coordinator_GetAllbyCultureDAL(culture,CompanyID);
        }

        /// <summary>
        /// Cores the countries get allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CoreCountries_GetAllbyCultureBAL(string culture)
        {
            return DAL.CoreCountries_GetAllbyCultureDAL(culture);
        }

        /// <summary>
        /// Cores the countries get allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CoreCountries_GetAllbyCultureBALbyOrganization(string culture,string Oid)
        {
            return DAL.CoreCountries_GetAllbyCultureDALbyOrganization(culture,Oid);
        }

        /// <summary>
        /// Cores the region state get allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CountryId">The country identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CoreRegionState_GetAllbyCultureBAL(string culture, int CountryId)
        {
            return DAL.CoreRegionState_GetAllbyCultureDAL(culture, CountryId);
        }
        public IList<DDlList> ProgramLanguages_GetAllByCultureClassBAL(string culture, long ClassID)
        {
            return DAL.ProgramLanguages_GetAllByCulturecultureDAL(culture, ClassID);
        }

        /// <summary>
        /// Cores the region state get allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CountryId">The country identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CoreRegionState_GetAllbyCultureBALbyOrganization(string culture, int CountryId, string Oid)
        {
            return DAL.CoreRegionState_GetAllbyCultureDALbyOrganization(culture, CountryId,Oid);
        }

        /// <summary>
        /// Cores the cities region get allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="RegionId">The region identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CoreCitiesRegion_GetAllbyCultureBAL(string culture, int RegionId)
        {
            return DAL.CoreCitiesRegion_GetAllbyCultureDAL(culture, RegionId);
        }

        public IList<DDlList> Resources_GetAllbyCultureBAL(string culture)
        {
            return DAL.Resources_GetAllbyCultureDAL(culture);
        }

        
        /// <summary>
        /// Cores the cities region get allby culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="RegionId">The region identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CoreCitiesRegion_GetAllbyCultureBALbyOrganization(string culture, int RegionId,string Oid)
        {
            return DAL.CoreCitiesRegion_GetAllbyCultureDALbyOrganization(culture, RegionId,Oid);
        }

        /// <summary>
        /// Countries the code get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CountryCode_GetAllByCultureBAL(string culture)
        {
            return DAL.CountryCode_GetAllByCultureDAL(culture);
        }

        /// <summary>
        /// Countries the code get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> NationalityCode_GetAllByCultureBAL(string culture)
        {
            return DAL.NationalityCode_GetAllByCultureDAL(culture);
        }

        /// <summary>
        /// Organizations the types get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> OrganizationTypes_GetAllByCultureBAL(string culture)
        {
            return DAL.OrganizationTypes_GetAllByCultureDAL(culture);
        }

        /// <summary>
        /// Persons the get allfor DDL bal.
        /// </summary>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> PersonGetAllforDDL_BAL(long CompanyID)
        {
            return DAL.PersonGetAllforDDL_DAL(CompanyID);
        }

        /// <summary>
        /// Users the get allfor DDL bal.
        /// </summary>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> UserGetAllforDDL_BAL(long companyId)
        {
            return DAL.UserGetAllforDDL_DAL(companyId);
        }

        /// <summary>
        /// Users the get allfor DDL bal.
        /// </summary>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> UserGetAllUnassignedforDDL_BAL()
        {
            return DAL.UserGetAllUnassignedforDDL_DAL();
        }

        public IList<DDlList> GetAllClasses()
        {
            return DAL.ClassGetAllforDDL_DAL();
        }

        /// <summary>
        /// Organizations the person relation types get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> OrganizationPersonRelationTypes_GetAllByCultureBAL(string culture)
        {
            return DAL.OrganizationPersonRelationTypes_GetAllByCultureDAL(culture);
        }

        #region"Program Course"

        /// <summary>
        /// Courses the categories get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CategoryType">Type of the category.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CourseCategories_GetAllByCultureBAL(string culture, int CategoryType, long CompanyID)
        {
            return DAL.CourseCategories_GetAllByCultureDAL(culture, CategoryType, CompanyID);
        }

        /// <summary>
        /// Courses the vendors get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CourseVendors_GetAllByCultureBAL(string culture, long CompanyID)
        {
            return DAL.CourseVendors_GetAllByCultureDAL(culture, CompanyID);
        }

        public IList<DDlList> CRMClasses(string culture, long CompanyID)
        {
            return DAL.CRMClasses(culture, CompanyID);
        }

        public IList<DDlList> CRM_Courses(string culture, long CompanyID)
        {
            return DAL.CRM_Courses(culture, CompanyID);
        }

        public IList<DDlList> HowHeard(string culture, long CompanyID)
        {
            return DAL.HowHeard(culture, CompanyID);
        }
        public IList<DDlList> CRM_Users(string culture, long CompanyID)
        {
            return DAL.CRM_Users(culture, CompanyID);
        }

        

        /// <summary>
        /// Currencies the get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> Currencies_GetAllByCultureBAL(string culture) => DAL.Currencies_GetAllByCultureDAL(culture);

        /// <summary>
        /// Currencies the get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CurrenciesbyOrganization_GetAllByCultureBAL(string culture, long Oid) => DAL.CurrenciesbyOrganization_GetAllByCultureDAL(culture,Oid);

        /// <summary>
        /// Programs the languages get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> ProgramLanguages_GetAllByCultureBAL(string culture)
        {
            return DAL.ProgramLanguages_GetAllByCultureDAL(culture);
        }
        /// <summary>
        /// Programs the languages get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> ProgramLanguages_GetAllByCourseCultureBAL(string culture)
        {
            return DAL.ProgramLanguages_GetAllByCourseCultureDAL(culture);
        }
        /// <summary>
        /// Programs the languages get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> ProgramLanguages_GetAllByClassCultureBAL(string culture)
        {
            return DAL.ProgramLanguages_GetAllByClassCultureDAL(culture);
        }
        /// <summary>
        /// Course the get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> Courses_GetAllByCultureBAL(string culture,long CompanyID,long perosnId)
        {
            return DAL.Courses_GetAllByCultureDAL(culture, CompanyID, perosnId);
        }

        /// <summary>
        /// Course the by course identifier and culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CourseId">The course identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> Classes_ByCourseIdAndCultureBAL(string culture, string CourseId, long CompnayID)
        {
            return DAL.Classes_ByCourseIdAndCultureDAL(culture, CourseId,CompnayID);
        }
        /// <summary>
        /// Roles the get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> Roles_GetAllByCultureBAL(string culture,long oid) => DAL.Roles_GetAllByCultureDAL(culture,oid);

        public IList<DDlList> TrainerDDLBAL(string culture, long CompnayID)
        {
            return DAL.TrainerDDLDAL(culture, CompnayID);
        }

        public IList<DDlList> TraineeDDLBAL(string culture, long CompnayID)
        {
            return DAL.TraineeDDLDAL(culture, CompnayID);
        }

        public IList<DDlList> VenueDDLBAL(string culture, long CompnayID)
        {
            return DAL.VenueDDLDAL(culture, CompnayID);
        }

        public IList<DDlList> ClassDDLBAL(string culture, long CompnayID)
        {
            return DAL.ClassDDLDAL(culture, CompnayID);
        }


        public IList<DDlList> CourseDDLBAL(string culture, long CompnayID)
        {
            return DAL.CourseDDLDAL(culture, CompnayID);
        }

        public IList<DDlList> Course_ClassDDLBAL(string culture, long CompnayID, long CourseID, long personId)
        {
            return DAL.Course_ClassDDLDAL(culture, CompnayID,CourseID,personId);
        }

        public IList<DDlList> Class_TrainerDDLBAL(string culture, long CompnayID, long ClassID)
        {
            return DAL.Class_TrainerDDLDAL(culture, CompnayID, ClassID);
        }

        public IList<DDlList> Class_TraineeDDLBAL(string culture, long CompnayID, long ClassID)
        {
            return DAL.Class_TraineeDDLDAL(culture, CompnayID, ClassID);
        }

        public IList<DDlList> Class_VenueDDLBAL(string culture, long CompnayID, long ClassID)
        {
            return DAL.Class_VenueDDLDAL(culture, CompnayID, ClassID);
        }

        public IList<DDlList> GetAllCourseCategories(string culture, long CompnayID)
        {
            return DAL.GetAllCourseCategoriesDAL(culture, CompnayID);
        }

        
        #endregion
    }
}