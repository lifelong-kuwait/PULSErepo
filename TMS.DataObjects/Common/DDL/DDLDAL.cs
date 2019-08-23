// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 01-14-2018
// ***********************************************************************
// <copyright file="DDLDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.Common.DDL;
using TMS.Library.Entities.Language;
using TMS.Library.TMS.Persons;

namespace TMS.DataObjects.Common.DDL
{
    /// <summary>
    /// Class DDLDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.Common.DDL.IDDLDAL" />
    public class DDLDAL : DBGenerics, IDDLDAL
    {
        /// <summary>
        /// Cores the countries get allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<CoreLanguage> CoreLanguage_GetAllbyCultureDAL(string culture)
        {
            return ExecuteListSp<CoreLanguage>("CoreLanguages_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));
        }
        public IList<DDlList> ProgramLanguages_GetAllByCulturecultureDAL(string culture, long ClassID)
        {
            return ExecuteListSp<DDlList>("ProgramLanguages_GetAllByCultureClass", ParamBuilder.Par("culture", culture), ParamBuilder.Par("ClassID", ClassID)); ;
        }



        public IList<DDlList> Coordinator_GetAllbyCultureDAL(string culture, long CompanyID)
        {
            return ExecuteListSp<DDlList>("Coordinator_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5),ParamBuilder.Par("OrganizationID",CompanyID));
        }

        /// <summary>
        /// Cores the countries get allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CoreCountries_GetAllbyCultureDAL(string culture)
        {
            return ExecuteListSp<DDlList>("CoreCountries_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));
        }

        /// <summary>
        /// Cores the countries get allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CoreCountries_GetAllbyCultureDALbyOrganization(string culture,string Oid)
        {
            return ExecuteListSp<DDlList>("CoreCountries_GetAllByCultureOrganization", ParamBuilder.ParNVarChar("Culture", culture, 5), ParamBuilder.Par("Oid",Oid));
        }

        /// <summary>
        /// Cores the region state get allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CountryId">The country identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CoreRegionState_GetAllbyCultureDAL(string culture, int CountryId)
        {
            return ExecuteListSp<DDlList>("CoreRegionState_GetByCountryIDCulture", ParamBuilder.ParNVarChar("Culture", culture, 5), ParamBuilder.Par("CountryId", CountryId));
        }

        /// <summary>
        /// Cores the region state get allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CountryId">The country identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CoreRegionState_GetAllbyCultureDALbyOrganization(string culture, int CountryId, string Oid)
        {
            return ExecuteListSp<DDlList>("CoreRegionState_GetByCountryIDCultureOrganization", ParamBuilder.ParNVarChar("Culture", culture, 5), ParamBuilder.Par("CountryId", CountryId), ParamBuilder.Par("Oid",Oid));
        }

        /// <summary>
        /// Cores the cities region get allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="RegionId">The region identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CoreCitiesRegion_GetAllbyCultureDAL(string culture, int RegionId)
        {
            return ExecuteListSp<DDlList>("CoreCitiesRegionAndCountriesWise_GetByRegionIDCulture", ParamBuilder.ParNVarChar("Culture", culture, 5), ParamBuilder.Par("RegionId", RegionId));
        }

        public IList<DDlList> Resources_GetAllbyCultureDAL(string culture)
        {
            return ExecuteListSp<DDlList>("TMS_ResourcesDLL", ParamBuilder.ParNVarChar("culture", culture,5));
        }

        /// <summary>
        /// Cores the cities region get allby culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="RegionId">The region identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CoreCitiesRegion_GetAllbyCultureDALbyOrganization(string culture, int RegionId,string Oid)
        {
            return ExecuteListSp<DDlList>("CoreCitiesRegionAndCountriesWise_GetByRegionIDCultureOrganization", ParamBuilder.ParNVarChar("Culture", culture, 5), ParamBuilder.Par("RegionId", RegionId), ParamBuilder.Par("Oid",Oid));
        }

        /// <summary>
        /// Countries the code get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CountryCode_GetAllByCultureDAL(string culture)
        {
            return ExecuteListSp<DDlList>("CountryCode_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));
        }

        /// <summary>
        /// Countries the code get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> NationalityCode_GetAllByCultureDAL(string culture)
        {
            return ExecuteListSp<DDlList>("NationalityCode_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));
        }

        /// <summary>
        /// Organizations the types get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> OrganizationTypes_GetAllByCultureDAL(string culture)
        {
            return ExecuteListSp<DDlList>("TMS_OrganizationTypes_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));
        }

        /// <summary>
        /// Persons the get allfor DDL dal.
        /// </summary>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> PersonGetAllforDDL_DAL(long CompanyID)
        {
          //  return ExecuteListSp<DDlList>("TMS_PersonDDL");

            return ExecuteListSp<DDlList>("TMS_PersonDDL", ParamBuilder.Par("OrganizationID", CompanyID));

        }
        public IList<DDlList> UserGetAllforDDL_DAL(long CompanyId)
        {
            return ExecuteListSp<DDlList>("TMS_UserDDL", ParamBuilder.Par("CompantID", CompanyId));
        }

        public IList<DDlList> UserGetAllUnassignedforDDL_DAL()
        {
            return ExecuteListSp<DDlList>("TMS_UserUnassignedDDL");
        }

        public IList<DDlList> ClassGetAllforDDL_DAL()
        {
            return ExecuteListSp<DDlList>("TMS_ClassesDLL");
        }

        /// <summary>
        /// Organizations the person relation types get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> OrganizationPersonRelationTypes_GetAllByCultureDAL(string culture)
        {
            return ExecuteListSp<DDlList>("TMS_OrganizationPersonRelationTypes_GetAllByCulture", ParamBuilder.ParNVarChar("Culture", culture, 5));
        }

        #region"Program Course"

        /// <summary>
        /// Courses the categories get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CategoryType">Type of the category.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CourseCategories_GetAllByCultureDAL(string culture, int CategoryType, long CompnayID)
        {
            return ExecuteListSp<DDlList>("TMS_Categories_GetAllByCulture",
                ParamBuilder.Par("CategoryType", CategoryType), ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));
        }

        /// <summary>
        /// Courses the vendors get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CourseVendors_GetAllByCultureDAL(string culture,long CompnayID)
        {
            return ExecuteListSp<DDlList>("TMS_CourseVendors_GetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));
        }
        public IList<DDlList> CRMClasses(string culture, long CompnayID)
        {
            return ExecuteListSp<DDlList>("CRM_Classes_GetAllByCulture", ParamBuilder.Par("Culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));
        }
        public IList<DDlList> CRM_Courses(string culture, long CompnayID)
        {
            return ExecuteListSp<DDlList>("CRM_Courses_GetAllByCulture", ParamBuilder.Par("Culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));
        }
        public IList<DDlList> HowHeard(string culture, long CompnayID)
        {
            return ExecuteListSp<DDlList>("HowHeard_ForCourseGetAllByCulture", ParamBuilder.Par("Culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));
        }

        public IList<DDlList> CRM_Users(string culture, long CompnayID)
        {
            return ExecuteListSp<DDlList>("CRM_User_GetAllByCulture", ParamBuilder.Par("Culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));
        }


        
        //  IList<DDlList> CRM_Courses(string culture, long CompanyID);
        /// <summary>
        /// Currencieses the get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> Currencies_GetAllByCultureDAL(string culture)
        {
            return ExecuteListSp<DDlList>("Currencies_GetAllByCulture", ParamBuilder.Par("culture", culture)); ;
        }

        /// <summary>
        /// Currencieses the get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> CurrenciesbyOrganization_GetAllByCultureDAL(string culture, long Oid)
        {
            return ExecuteListSp<DDlList>("Currencies_GetAllByCultureAndOrganization", ParamBuilder.Par("culture", culture),ParamBuilder.Par("Oid",Oid)); ;
        }

        /// <summary>
        /// Programs the languages get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> ProgramLanguages_GetAllByCultureDAL(string culture)
        {
            return ExecuteListSp<DDlList>("ProgramLanguages_GetAllByCulture", ParamBuilder.Par("culture", culture)); ;
        }

        /// <summary>
        /// Courseses the get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> Courses_GetAllByCultureDAL(string culture, long CompanyID)
        {
            return ExecuteListSp<DDlList>("TMS_Courses_GetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompanyID)); ;
        }
        /// <summary>
        /// Classeses the by course identifier and culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="CourseId">The course identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> Classes_ByCourseIdAndCultureDAL(string culture,string CourseId, long CompnayID)
        {
            return ExecuteListSp<DDlList>("TMS_Classes_ByCourseIdAndCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("CourseId", CourseId), ParamBuilder.Par("OrganizationID", CompnayID)); ;
        }
        /// <summary>
        /// Roleses the get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> Roles_GetAllByCultureDAL(string culture, long oid) => ExecuteListSp<DDlList>("Roles_GetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", oid));

        public IList<DDlList> TrainerDDLDAL(string culture, long CompnayID)
        {
            return ExecuteListSp<DDlList>("TMS_TraineDDLAndCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID)); ;

        }

        public IList<DDlList> TraineeDDLDAL(string culture, long CompnayID)
        {
            return ExecuteListSp<DDlList>("TMS_TraineeDDLAndCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID)); ;

        }

        public IList<DDlList> VenueDDLDAL(string culture, long CompnayID)
        {
            return ExecuteListSp<DDlList>("TMS_VenueDDLAndCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID)); ;

        }
        public IList<DDlList> ClassDDLDAL(string culture, long CompnayID)
        {
            return ExecuteListSp<DDlList>("TMS_ClassDDLAndCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID)); ;

        }


        public IList<DDlList> CourseDDLDAL(string culture, long CompnayID)
        {
            return ExecuteListSp<DDlList>("TMS_CourseDDLAndCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID)); ;

        }
        public IList<DDlList> Course_ClassDDLDAL(string culture, long CompnayID, long CourseID)
        {
            return ExecuteListSp<DDlList>("TMS_Course_ClassDDLAndCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID), ParamBuilder.Par("CourseID", CourseID)); ;

        }

        public IList<DDlList> Class_TrainerDDLDAL(string culture, long CompnayID, long ClassID)
        {
            return ExecuteListSp<DDlList>("TMS_Class_TrainerDDLAndCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID), ParamBuilder.Par("ClassID", ClassID)); ;

        }


        public IList<DDlList> Class_TraineeDDLDAL(string culture, long CompnayID, long ClassID)
        {
            return ExecuteListSp<DDlList>("TMS_Class_TraineeDDLAndCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID), ParamBuilder.Par("ClassID", ClassID)); ;

        }

        public IList<DDlList> Class_VenueDDLDAL(string culture, long CompnayID, long ClassID)
        {
            return ExecuteListSp<DDlList>("TMS_Class_VenueDDLAndCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID), ParamBuilder.Par("ClassID", ClassID)); ;

        }

        public IList<DDlList> GetAllCourseCategoriesDAL(string culture, long CompnayID)
        {
            return ExecuteListSp<DDlList>("CourseCatagory_GetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID)); ;

        }
        #endregion
    }
}