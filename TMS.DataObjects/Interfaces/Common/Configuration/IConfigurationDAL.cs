// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas
// Created          : 12-24-2017
//
// Last Modified By : Almas
// Last Modified On : 02-10-2018
// ***********************************************************************
// <copyright file="IConfigurationDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using TMS.Library;
using TMS.Library.Entities.Common.Configuration;
using TMS.Library.Entities.Common.Configuration.Categories;
using TMS.Library.Entities.Common.Configuration.Vendor;
using TMS.Library.Entities.Common.Configuration.Venues;
using TMS.Library.Entities.Common.Roles;
using TMS.Library.TMS.Admin.Config;

namespace TMS.DataObjects.Interfaces.Common.Configuration
{
    /// <summary>
    /// Interface IConfigurationDAL
    /// </summary>
    public interface IConfigurationDAL
    {
        #region Flags
        IList<PersonFlags> PersonFlags_GetALL();
        IList<PersonFlags> PersonFlagsbyOrganization_GetALL(string Oid);
        /// <summary>
        /// Persons the flags get all.
        /// </summary>
        /// <returns>IList&lt;PersonFlags&gt;.</returns>
        IList<PersonFlags> PersonFlags_GetALL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Persons the flags get all.
        /// </summary>
        /// <returns>IList&lt;PersonFlags&gt;.</returns>
        IList<PersonFlags> PersonFlagsbyOrganization_GetALL(string Oid, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Persons the flags create dal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns>System.Int64.</returns>
        long PersonFlags_CreateDAL(PersonFlags _objPersonFlags);

        /// <summary>
        /// Persons the flags update dal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns>System.Int32.</returns>
        int PersonFlags_UpdateDAL(PersonFlags _objPersonFlags);

        /// <summary>
        /// Persons the flags delete dal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool PersonFlags_DeleteDAL(PersonFlags _objPersonFlags);

        /// <summary>
        /// Persons the flags duplication check dal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns>System.Int32.</returns>
        int PersonFlags_DuplicationCheckDAL(PersonFlags _objPersonFlags,long CompanyID);

        /// <summary>
        /// Persons the flags get count by person id dal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonFlags_GetCountByPersonIDDAL(PersonFlags _objPersonFlags, string PersonId);

        /// <summary>
        /// Persons the flags get all culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;PersonFlagsDDL&gt;.</returns>
        IList<PersonFlagsDDL> PersonFlags_GetAllCultureDAL(string culture, long CompanyID);
        IList<PersonFlagsDDL> PersonFlag_GetAllCultureDAL(string culture);

        /// <summary>
        /// Persons the flags insert by person identifier.
        /// </summary>
        /// <param name="flagID">The flag identifier.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <param name="CreatedBy">The created by.</param>
        /// <returns>System.Int64.</returns>
        long PersonFlags_InsertByPersonID(long flagID, string PersonId, long? CreatedBy);

        /// <summary>
        /// Persons the flags delete by person identifier.
        /// </summary>
        /// <param name="flagID">The flag identifier.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <param name="UpdatedBy">The updated by.</param>
        /// <returns>System.Int64.</returns>
        long PersonFlags_DeleteByPersonID(long flagID, string PersonId, long? UpdatedBy);

        #endregion Flags

        #region Venue

        /// <summary>
        /// Venues the get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Venues&gt;.</returns>
        List<Venues> Venues_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Venues the get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Venues&gt;.</returns>
        List<Venues> VenuesbyOrganization_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);


        /// <summary>
        /// Venues the create dal.
        /// </summary>
        /// <param name="_Venues">The venues.</param>
        /// <returns>System.Int64.</returns>
        long Venues_CreateDAL(Venues _Venues);

        /// <summary>
        /// Venues the update dal.
        /// </summary>
        /// <param name="_Venues">The venues.</param>
        /// <returns>System.Int32.</returns>
        int Venues_UpdateDAL(Venues _Venues);

        /// <summary>
        /// Venues the delete dal.
        /// </summary>
        /// <param name="_Venues">The venues.</param>
        /// <returns>System.Int32.</returns>
        int Venues_DeleteDAL(Venues _Venues);

        /// <summary>
        /// Manages the venues get all dal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>List&lt;VenueOpenMapping&gt;.</returns>
        List<VenueOpenMapping> ManageVenues_GetAllDAL(long OpenId, int OpenType);

        /// <summary>
        /// Manages the venues create dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int64.</returns>
        long ManageVenues_CreateDAL(VenueOpenMapping _mapping);

        /// <summary>
        /// Manages the venues update dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        int ManageVenues_UpdateDAL(VenueOpenMapping _mapping);

        /// <summary>
        /// Manages the venues delete dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        int ManageVenues_DeleteDAL(VenueOpenMapping _mapping);

        /// <summary>
        /// Manages the venues duplication check dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        int ManageVenues_DuplicationCheckDAL(VenueOpenMapping _mapping);

        /// <summary>
        /// Venues the get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <param name="OpenId">The open identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> Venues_GetAllByCultureDAL(string culture, int OpenType, long OpenId, long CompnayID);

        IList<DDlList> Venues_GetAllByCultureDAL(string culture, long CompnayID);

        IList<DDlList> Venues_GetAllByCultureDAL(string culture);

        #endregion Venue

        #region Trainer

        /// <summary>
        /// Manages the trainer get all dal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>List&lt;TrainerOpenMapping&gt;.</returns>
        List<TrainerOpenMapping> ManageTrainer_GetAllDAL(long OpenId, int OpenType);

        /// <summary>
        /// Manages the trainer get by id dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>TrainerOpenMapping.</returns>
        TrainerOpenMapping ManageTrainer_GetByIDDAL(long ID);

        /// <summary>
        /// Manages the trainer create dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int64.</returns>
        long ManageTrainer_CreateDAL(TrainerOpenMapping _mapping);

        /// <summary>
        /// Manages the trainer update dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        int ManageTrainer_UpdateDAL(TrainerOpenMapping _mapping);

        /// <summary>
        /// Manages the trainer delete dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        int ManageTrainer_DeleteDAL(TrainerOpenMapping _mapping);

        /// <summary>
        /// Manages the trainer duplication check dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        int ManageTrainer_DuplicationCheckDAL(TrainerOpenMapping _mapping);

        /// <summary>
        /// Manages the trainer duplication check dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        int ManageTrainer_AvailabilityCheckDAL(TrainerOpenMapping _mapping);

        /// <summary>
        /// Manages the trainer get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <param name="OpenId">The open identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> ManageTrainer_GetAllByCultureDAL(string culture, int OpenType, long OpenId, long CompnayID);

        #endregion Trainer

        #region "Vandors"

        /// <summary>
        /// Vendors the get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Vendors&gt;.</returns>
        List<Vendors> Vendors_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Vendors the get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Vendors&gt;.</returns>
        List<Vendors> Vendors_GetAllDALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);

        /// <summary>
        /// Vendors the create dal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int64.</returns>
        long Vendors_CreateDAL(Vendors _Vendors);

        /// <summary>
        /// Vendors the update dal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int32.</returns>
        int Vendors_UpdateDAL(Vendors _Vendors);

        /// <summary>
        /// Vendors the delete dal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int32.</returns>
        int Vendors_DeleteDAL(Vendors _Vendors);

        /// <summary>
        /// Vendors the duplication check dal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int32.</returns>
        int Vendors_DuplicationCheckDAL(Vendors _Vendors);

        #endregion "Vandors"

        #region "Categories"

        /// <summary>
        /// TMSs the categories get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;TMSCategories&gt;.</returns>
        List<TMSCategories> TMSCategories_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// TMSs the categories get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;TMSCategories&gt;.</returns>
        List<TMSCategories> TMSCategoriesbyOrganization_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);

        /// <summary>
        /// TMSs the categories get by id dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>TMSCategories.</returns>
        TMSCategories TMSCategories_GetByIDDAL(long ID);

        /// <summary>
        /// TMSs the categories create dal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int64.</returns>
        long TMSCategories_CreateDAL(TMSCategories _categories);

        /// <summary>
        /// TMSs the categories update dal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int32.</returns>
        int TMSCategories_UpdateDAL(TMSCategories _categories);

        /// <summary>
        /// TMSs the categories delete dal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int32.</returns>
        int TMSCategories_DeleteDAL(TMSCategories _categories);

        /// <summary>
        /// TMSs the categories duplication check dal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int32.</returns>
        int TMSCategories_DuplicationCheckDAL(TMSCategories _categories);

        #endregion "Categories"

        #region "FocusArea"

        /// <summary>
        /// Focuses the areas get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;FocusAreas&gt;.</returns>
        List<FocusAreas> FocusAreas_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Focuses the areas get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;FocusAreas&gt;.</returns>
        List<FocusAreas> FocusAreasbyOrganization_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);

        /// <summary>
        /// Focuses the areas create dal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int64.</returns>
        long FocusAreas_CreateDAL(FocusAreas _objFocusAreas);

        /// <summary>
        /// Focuses the areas update dal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int32.</returns>
        int FocusAreas_UpdateDAL(FocusAreas _objFocusAreas);

        /// <summary>
        /// Focuses the areas delete dal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int32.</returns>
        int FocusAreas_DeleteDAL(FocusAreas _objFocusAreas);
        /// <summary>
        /// Focuses the areas duplication check dal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int32.</returns>
        int FocusAreas_DuplicationCheckDAL(FocusAreas _objFocusAreas);
        #endregion "FocusArea"

        #region CourseMaterials
        int CourseMeterialMap_DuplicationCheckDAL(CourseMeterialsMapping _objlogmap);

        int ManageLogistic_DuplicationCheckDAL(CourseLogisticRequirementsMapping _objlogmap);

        
        /// <summary>
        /// Courses the materials get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseMaterials&gt;.</returns>
        List<CourseMaterials> CourseMaterials_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Courses the materials get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseMaterials&gt;.</returns>
        List<CourseMaterials> CourseMaterials_GetAllDALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);

        /// <summary>
        /// Courses the materials create dal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int64.</returns>
        long CourseMaterials_CreateDAL(CourseMaterials _objCourseMaterials);

        /// <summary>
        /// Courses the materials update dal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int32.</returns>
        int CourseMaterials_UpdateDAL(CourseMaterials _objCourseMaterials);

        /// <summary>
        /// Courses the materials delete dal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int32.</returns>
        int CourseMaterials_DeleteDAL(CourseMaterials _objCourseMaterials);

        /// <summary>
        /// Courses the materials duplication check dal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int32.</returns>
        int CourseMaterials_DuplicationCheckDAL(CourseMaterials _objCourseMaterials);
        #endregion CourseMaterials


        #region DegreeCertificates
        /// <summary>
        /// Degrees the certificates get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;DegreeCertificates&gt;.</returns>
        List<DegreeCertificates> DegreeCertificates_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Degrees the certificates get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;DegreeCertificates&gt;.</returns>
        List<DegreeCertificates> DegreeCertificates_GetAllDALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);

        /// <summary>
        /// Degrees the certificates create dal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int64.</returns>
        long DegreeCertificates_CreateDAL(DegreeCertificates _objDegreeCertificates);

        /// <summary>
        /// Degrees the certificates update dal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int32.</returns>
        int DegreeCertificates_UpdateDAL(DegreeCertificates _objDegreeCertificates);

        /// <summary>
        /// Degrees the certificates delete dal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int32.</returns>
        int DegreeCertificates_DeleteDAL(DegreeCertificates _objDegreeCertificates);

        /// <summary>
        /// Degrees the certificates duplication check dal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int32.</returns>
        int DegreeCertificates_DuplicationCheckDAL(DegreeCertificates _objDegreeCertificates);
        #endregion DegreeCertificates

        #region CourseLogisticRequirements
        /// <summary>
        /// Courses the logistic requirements get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseLogisticRequirements&gt;.</returns>
        List<CourseLogisticRequirements> CourseLogisticRequirements_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Courses the logistic requirements get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseLogisticRequirements&gt;.</returns>
        List<CourseLogisticRequirements> CourseLogisticRequirements_GetAllDALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);

        /// <summary>
        /// Courses the logistic requirements create dal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int64.</returns>
        long CourseLogisticRequirements_CreateDAL(CourseLogisticRequirements _objCourseLogisticRequirements);

        /// <summary>
        /// Courses the logistic requirements update dal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int32.</returns>
        int CourseLogisticRequirements_UpdateDAL(CourseLogisticRequirements _objCourseLogisticRequirements);

        /// <summary>
        /// Courses the logistic requirements delete dal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int32.</returns>
        int CourseLogisticRequirements_DeleteDAL(CourseLogisticRequirements _objCourseLogisticRequirements);

        /// <summary>
        /// Courses the logistic requirements duplication check dal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int32.</returns>
        int CourseLogisticRequirements_DuplicationCheckDAL(CourseLogisticRequirements _objCourseLogisticRequirements);
        #endregion CourseLogisticRequirements
        long ManageLogisticMap_CreateDAL(CourseLogisticRequirementsMapping _mapping);

        long ManageCourseMeterialMap_CreateDAL(CourseMeterialsMapping _mapping);

        long ManageSessionMeterialMap_CreateDAL(SessionMeterialsMapping _mapping);


        long ManageCourseClassMeterialMap_CreateDAL(ClassMeterialsMapping _mapping);

         long Audit_CreateBAL(string IpAddress, DateTime createddate, long oid, long userid, EventType events, string browser);
        int ManageLogisticMap_UpdateDAL(CourseLogisticRequirementsMapping _mapping);

        int ManageCourseMeterialMap_UpdateDAL(CourseMeterialsMapping _mapping);

        int ManageCourseClassMeterialMap_DeleteDAL(ClassMeterialsMapping _mapping);

        int ManageCourseMeterialMap_DeleteDAL(CourseMeterialsMapping _mapping);

        int ManageLogisticMap_DeleteDAL(CourseLogisticRequirementsMapping _mapping);

        IList<DDlList> CourseLogistic_GetAllByCultureDAL(string culture, long CompnayID);



        IList<DDlList> CourseMeterial_GetAllByCultureDAL(string culture, long CompnayID);

        IList<DDlList> HowHeard_GetAllByCultureDAL(string culture, long CompnayID);

        IList<DDlList> CRMUser_GetAllByCultureDAL(string culture, long CompnayID);

        IList<DDlList> CRMCourses_GetAllByCultureDAL(string culture, long CompnayID);

        IList<DDlList> CRMClasses_GetAllByCultureDAL(string culture, long CompnayID);

        int CourseMaterials_CheckDAL(CourseMaterials _objCourseMaterials);

        int CourseClassMaterials_CheckDAL(CourseMaterials _objCourseMaterials);


        int CourseSessionMaterials_CheckDAL(CourseMaterials _objCourseMaterials);
        List<CourseLogisticRequirementsMapping> ManageCourseMap_GetAllDAL(long oid,long CourseID);
        List<CourseLogisticRequirements> ManageCourse_GetAllDAL(long oid);

        List<CourseMeterialsMapping> ManageCourseMeterialMap_GetAllDAL(long oid, long CourseID);

        List<CourseMeterialsMapping> ManageCourseMeterial_GetAllDAL(long oid);

        List<ClassMeterialsMapping> ManageClassMeterialMap_GetAllDAL(long oid, long ClassID);

        List<SessionMeterialsMapping> ManageSessionMeterialMap_GetAllDAL(long oid);

        List<AuditLog> AuditLog_GetAllDAL(long oid);
        
        int CourseLogisticRequirements_CheckDAL(CourseLogisticRequirements _objCourseLogisticRequirements);







    }
}