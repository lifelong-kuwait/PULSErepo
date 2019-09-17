// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 12-24-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-10-2018
// ***********************************************************************
// <copyright file="IConfigurationBAL.cs" company="LifeLong www.lifelongkuwait.com">
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

namespace TMS.Business.Interfaces.Common.Configuration
{
    /// <summary>
    /// Interface IConfigurationBAL
    /// </summary>
    public interface IConfigurationBAL
    {
        #region Flags
        IList<PersonFlags> PersonFlags_GetALLBAL();
        IList<PersonFlags> PersonFlagsbyOrganization_GetALLBAL(string Oid);
        /// <summary>
        /// Persons the flags get allbal.
        /// </summary>
        /// <returns>IList&lt;PersonFlags&gt;.</returns>
        IList<PersonFlags> PersonFlags_GetALLBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);
        
        /// <summary>
        /// Persons the flags get allbal.
        /// </summary>
        /// <returns>IList&lt;PersonFlags&gt;.</returns>
        IList<PersonFlags> PersonFlagsbyOrganization_GetALLBAL(string Oid, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Persons the flags create bal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns>System.Int64.</returns>
        long PersonFlags_CreateBAL(PersonFlags _objPersonFlags);

        /// <summary>
        /// Persons the flags update bal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns>System.Int32.</returns>
        int PersonFlags_UpdateBAL(PersonFlags _objPersonFlags);

        /// <summary>
        /// Persons the flags delete bal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool PersonFlags_DeleteBAL(PersonFlags _objPersonFlags);

        /// <summary>
        /// Persons the flags duplication check bal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns>System.Int32.</returns>
        int PersonFlags_DuplicationCheckBAL(PersonFlags _objPersonFlags,long CompanyID);

        /// <summary>
        /// Persons the flags get count by person idbal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonFlags_GetCountByPersonIDBAL(PersonFlags _objPersonFlags, string PersonId);

        /// <summary>
        /// Persons the flags get all culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;PersonFlagsDDL&gt;.</returns>
        IList<PersonFlagsDDL> PersonFlags_GetAllCultureBAL(string culture,long CompanyID);
        IList<PersonFlagsDDL> PersonFlag_GetAllCultureBAL(string culture);

        #endregion Flags

        /// <summary>
        /// Venueses the get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Venues&gt;.</returns>
        List<Venues> Venues_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Venueses the get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Venues&gt;.</returns>
        List<Venues> VenuesbyOrganization_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);
        /// <summary>
        /// Venueses the get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Venues&gt;.</returns>
        long VenuesForDestroy_GetAllBAL(long venueID);


        /// <summary>
        /// Venueses the create bal.
        /// </summary>
        /// <param name="_Venues">The venues.</param>
        /// <returns>System.Int64.</returns>
        long Venues_CreateBAL(Venues _Venues);

        /// <summary>
        /// Venueses the update bal.
        /// </summary>
        /// <param name="_Venues">The venues.</param>
        /// <returns>System.Int32.</returns>
        int Venues_UpdateBAL(Venues _Venues);

        /// <summary>
        /// Venueses the delete bal.
        /// </summary>
        /// <param name="_Venues">The venues.</param>
        /// <returns>System.Int32.</returns>
        int Venues_DeleteBAL(Venues _Venues);

        /// <summary>
        /// Manages the venues get all bal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>List&lt;VenueOpenMapping&gt;.</returns>
        List<VenueOpenMapping> ManageVenues_GetAllBAL(long OpenId, int OpenType);

        /// <summary>
        /// Manages the venues create bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int64.</returns>
        long ManageVenues_CreateBAL(VenueOpenMapping _mapping);

        /// <summary>
        /// Manages the venues update bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        int ManageVenues_UpdateBAL(VenueOpenMapping _mapping);

        /// <summary>
        /// Manages the venues delete bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        int ManageVenues_DeleteBAL(VenueOpenMapping _mapping);

        /// <summary>
        /// Manages the venues duplication check bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        int ManageVenues_DuplicationCheckBAL(VenueOpenMapping _mapping);

        /// <summary>
        /// Venueses the get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <param name="OpenId">The open identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> Venues_GetAllByCultureBAL(string culture, int OpenType, long OpenId,long CompnayID);
        
        IList<DDlList> Venues_GetAllByClassBAL(string culture, int OpenType, long OpenId, long CompnayID);

        IList<DDlList> Venues_GetAllByCultureBAL(string culture, long CompnayID);

        IList<DDlList> Venues_GetAllByCultureBAL(string culture);

        #region Trainer

        /// <summary>
        /// Manages the trainer get all bal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>List&lt;TrainerOpenMapping&gt;.</returns>
        List<TrainerOpenMapping> ManageTrainer_GetAllBAL(long OpenId, int OpenType);

        /// <summary>
        /// Manages the trainer get by idbal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>TrainerOpenMapping.</returns>
        TrainerOpenMapping ManageTrainer_GetByIDBAL(long ID);

        /// <summary>
        /// Manages the trainer create bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int64.</returns>
        long ManageTrainer_CreateBAL(TrainerOpenMapping _mapping);

        /// <summary>
        /// Manages the trainer update bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        int ManageTrainer_UpdateBAL(TrainerOpenMapping _mapping);

        /// <summary>
        /// Manages the trainer delete bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        int ManageTrainer_DeleteBAL(TrainerOpenMapping _mapping);

        /// <summary>
        /// Manages the trainer duplication check bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        int ManageTrainer_DuplicationCheckBAL(TrainerOpenMapping _mapping);

        /// <summary>
        /// Manages the trainer duplication check bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        int ManageTrainer_AvalabilityCheckBAL(TrainerOpenMapping _mapping);

        /// <summary>
        /// Manages the trainer get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <param name="OpenId">The open identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        IList<DDlList> ManageTrainer_GetAllByCultureBAL(string culture, int OpenType, long OpenId,long CompnayID);
        IList<DDlList> ManageVenue_GetAllByCultureBAL(string culture, int OpenType, long OpenId, long CompnayID);

        #endregion Trainer

        #region Vendors

        /// <summary>
        /// Vendors the get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Vendors&gt;.</returns>
        List<Vendors> Vendors_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Vendors the get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Vendors&gt;.</returns>
        List<Vendors> Vendors_GetAllBALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);

        /// <summary>
        /// Vendors the create bal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int64.</returns>
        long Vendors_CreateBAL(Vendors _Vendors);

        /// <summary>
        /// Vendors the update bal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int32.</returns>
        int Vendors_UpdateBAL(Vendors _Vendors);

        /// <summary>
        /// Vendors the delete bal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int32.</returns>
        int Vendors_DeleteBAL(Vendors _Vendors);

        /// <summary>
        /// Vendors the duplication check bal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int32.</returns>
        int Vendors_DuplicationCheckBAL(Vendors _Vendors);

        #endregion Vendors

        #region Categories

        /// <summary>
        /// TMSs the categories get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;TMSCategories&gt;.</returns>
        List<TMSCategories> TMSCategories_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// TMSs the categories get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;TMSCategories&gt;.</returns>
        List<TMSCategories> TMSCategoriesbyOrganization_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);

        /// <summary>
        /// TMSs the categories get by idbal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>TMSCategories.</returns>
        TMSCategories TMSCategories_GetByIDBAL(long ID);

        /// <summary>
        /// TMSs the categories create bal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int64.</returns>
        long TMSCategories_CreateBAL(TMSCategories _categories);

        /// <summary>
        /// TMSs the categories update bal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int32.</returns>
        int TMSCategories_UpdateBAL(TMSCategories _categories);

        /// <summary>
        /// TMSs the categories delete bal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int32.</returns>
        int TMSCategories_DeleteBAL(TMSCategories _categories);

        /// <summary>
        /// TMSs the categories duplication check bal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int32.</returns>
        int TMSCategories_DuplicationCheckBAL(TMSCategories _categories);

        #endregion Categories



        #region FocusAreas
        /// <summary>
        /// Focuses the areas get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;FocusAreas&gt;.</returns>
        List<FocusAreas> FocusAreas_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Focuses the areas get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;FocusAreas&gt;.</returns>
        List<FocusAreas> FocusAreasbyOrganization_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);

        /// <summary>
        /// Focuses the areas create bal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int64.</returns>
        long FocusAreas_CreateBAL(FocusAreas _objFocusAreas);

        /// <summary>
        /// Focuses the areas update bal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int32.</returns>
        int FocusAreas_UpdateBAL(FocusAreas _objFocusAreas);

        /// <summary>
        /// Focuses the areas delete bal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int32.</returns>
        int FocusAreas_DeleteBAL(FocusAreas _objFocusAreas);

        /// <summary>
        /// Focuses the areas duplication check bal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int32.</returns>
        int FocusAreas_DuplicationCheckBAL(FocusAreas _objFocusAreas);
        #endregion FocusAreas

        #region CourseMaterials
        
             int ManageLogistic_DuplicationCheckBAL(CourseLogisticRequirementsMapping _objlogmap);
        int CourseMeterialMap_DuplicationCheckBAL(CourseMeterialsMapping _objlogmap);
        /// <summary>
        /// Courses the materials get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseMaterials&gt;.</returns>
        List<CourseMaterials> CourseMaterials_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Courses the materials get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseMaterials&gt;.</returns>
        List<CourseMaterials> CourseMaterials_GetAllBALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);


        /// <summary>
        /// Courses the materials create bal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int64.</returns>
        long CourseMaterials_CreateBAL(CourseMaterials _objCourseMaterials);

        /// <summary>
        /// Courses the materials update bal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int32.</returns>
        int CourseMaterials_UpdateBAL(CourseMaterials _objCourseMaterials);

        /// <summary>
        /// Courses the materials delete bal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int32.</returns>
        int CourseMaterials_DeleteBAL(CourseMaterials _objCourseMaterials);

        /// <summary>
        /// Courses the materials duplication check bal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int32.</returns>
        int CourseMaterials_DuplicationCheckBAL(CourseMaterials _objCourseMaterials);
        #endregion CourseMaterials


        #region DegreeCertificates
        /// <summary>
        /// Degrees the certificates get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;DegreeCertificates&gt;.</returns>
        List<DegreeCertificates> DegreeCertificates_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Degrees the certificates get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;DegreeCertificates&gt;.</returns>
        List<DegreeCertificates> DegreeCertificates_GetAllBALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);

        /// <summary>
        /// Degrees the certificates create bal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int64.</returns>
        long DegreeCertificates_CreateBAL(DegreeCertificates _objDegreeCertificates);

        /// <summary>
        /// Degrees the certificates update bal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int32.</returns>
        int DegreeCertificates_UpdateBAL(DegreeCertificates _objDegreeCertificates);

        /// <summary>
        /// Degrees the certificates delete bal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int32.</returns>
        int DegreeCertificates_DeleteBAL(DegreeCertificates _objDegreeCertificates);

        /// <summary>
        /// Degrees the certificates duplication check bal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int32.</returns>
        int DegreeCertificates_DuplicationCheckBAL(DegreeCertificates _objDegreeCertificates);
        #endregion DegreeCertificates

        #region CourseLogisticRequirements
        /// <summary>
        /// Courses the logistic requirements get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseLogisticRequirements&gt;.</returns>
        List<CourseLogisticRequirements> CourseLogisticRequirements_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// Courses the logistic requirements get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseLogisticRequirements&gt;.</returns>
        List<CourseLogisticRequirements> CourseLogisticRequirements_GetAllBALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);

        /// <summary>
        /// Courses the logistic requirements create bal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int64.</returns>
        long CourseLogisticRequirements_CreateBAL(CourseLogisticRequirements _objCourseLogisticRequirements);

        /// <summary>
        /// Courses the logistic requirements update bal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int32.</returns>
        int CourseLogisticRequirements_UpdateBAL(CourseLogisticRequirements _objCourseLogisticRequirements);

        /// <summary>
        /// Courses the logistic requirements delete bal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int32.</returns>
        int CourseLogisticRequirements_DeleteBAL(CourseLogisticRequirements _objCourseLogisticRequirements);

        /// <summary>
        /// Courses the logistic requirements duplication check bal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int32.</returns>
        int CourseLogisticRequirements_DuplicationCheckBAL(CourseLogisticRequirements _objCourseLogisticRequirements);
        #endregion CourseLogisticRequirements

        long ManageLogisticMap_CreateBAL(CourseLogisticRequirementsMapping _mapping);
        long ManageCourseMeterialMap_CreateBAL(CourseMeterialsMapping _mapping);

        long ManageSessionMeterialMap_CreateBAL(SessionMeterialsMapping _mapping);
        long ManageCourseClassMeterialMap_CreateBAL(ClassMeterialsMapping _mapping);
        long Audit_CreateBAL(string IpAddress,DateTime createddate,long oid, long userid, EventType events, string browser);

        int ManageLogisticMap_UpdateBAL(CourseLogisticRequirementsMapping _mapping);

        int ManageCourseMeterialMap_UpdateBAL(CourseMeterialsMapping _mapping);

        int ManageCourseClassMeterialMap_DeleteBAL(ClassMeterialsMapping _mapping);

        int ManageCourseMeterialMap_DeleteBAL(CourseMeterialsMapping _mapping);
        int ManageLogisticMap_DeleteBAL(CourseLogisticRequirementsMapping _mapping);
        IList<DDlList> CourseLogistic_GetAllByCultureBALL(string culture, long CompnayID);

        IList<DDlList> CourseMeterial_GetAllByCultureBAL(string culture, long CompnayID);
        IList<DDlList> HowHeard_GetAllByCultureBAL(string culture, long CompnayID);

        IList<DDlList> CRMUser_GetAllByCultureBAL(string culture, long CompnayID);

        IList<DDlList> CRMCourses_GetAllByCultureBAL(string culture, long CompnayID);

        IList<DDlList> CRMClasses_GetAllByCultureBAL(string culture, long CompnayID);


        int CourseMaterials_CheckBAL(CourseMaterials _objCourseMaterials);

        int CourseClassMaterials_CheckBAL(CourseMaterials _objCourseMaterials);

        int CourseSessionMaterials_CheckBAL(CourseMaterials _objCourseMaterials);
        List<CourseLogisticRequirementsMapping> ManageCourseMap_GetAllBAL(long oid,long CourseID);
        List<CourseLogisticRequirements> ManageCourse_GetAllBAL(long oid);

        List<CourseMeterialsMapping> ManageCourseMeterialMap_GetAllBAL(long oid, long CourseID);

        List<CourseMeterialsMapping> ManageCourseMeterial_GetAllBAL(long oid);
        List<ClassMeterialsMapping> ManageClassMeterialMap_GetAllBAL(long oid, long ClassID);

        List<SessionMeterialsMapping> ManageSessionMeterialMap_GetAllBAL(long oid);
        List<AuditLog> AuditLog_GetAllBAL(long oid);
        int CourseLogisticRequirements_CheckBAL(CourseLogisticRequirements _objCourseLogisticRequirements);







    }
}