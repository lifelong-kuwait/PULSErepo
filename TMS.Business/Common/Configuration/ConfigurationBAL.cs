// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas
// Created          : 12-24-2017
//
// Last Modified By : Almas
// Last Modified On : 02-10-2018
// ***********************************************************************
// <copyright file="ConfigurationBAL.cs" company="">
//     Copyright ©  2016
// </copyright>
// <summary>

//this section of Business logic include following item's CURD
//Flags
//Venues
//Trainer
//Vendors
//Categories
//FocusAreas
//CourseMaterials
//DegreeCertificates
//CourseLogisticRequirements

//</summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using TMS.Business.Interfaces.Common.Configuration;
using TMS.DataObjects.Interfaces.Common.Configuration;
using TMS.Library;
using TMS.Library.Entities.Common.Configuration;
using TMS.Library.Entities.Common.Configuration.Categories;
using TMS.Library.Entities.Common.Configuration.Vendor;
using TMS.Library.Entities.Common.Configuration.Venues;
using TMS.Library.Entities.Common.Roles;
using TMS.Library.TMS.Admin.Config;

namespace TMS.Business.Common.Configuration
{
    /// <summary>
    /// Class ConfigurationBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.Common.Configuration.IConfigurationBAL" />
    public class ConfigurationBAL : IConfigurationBAL
    {
        /// <summary>
        /// The configuration dal
        /// </summary>
        private readonly IConfigurationDAL _ConfigurationDAL;

       

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationBAL"/> class.
        /// </summary>
        /// <param name="_IConfigurationDAL">The i configuration dal.</param>
        public ConfigurationBAL(IConfigurationDAL _IConfigurationDAL)
        {
            _ConfigurationDAL = _IConfigurationDAL;
        }
        public IList<PersonFlags> PersonFlags_GetALLBAL()
        {
            return _ConfigurationDAL.PersonFlags_GetALL();
        }
        public IList<PersonFlags> PersonFlagsbyOrganization_GetALLBAL(string Oid)
        {
            return _ConfigurationDAL.PersonFlagsbyOrganization_GetALL(Oid);
        }

        /// <summary>
        /// Persons the flags get all bal.
        /// </summary>
        /// <returns>IList&lt;PersonFlags&gt;.</returns>
        public IList<PersonFlags> PersonFlags_GetALLBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return _ConfigurationDAL.PersonFlags_GetALL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

        /// <summary>
        /// Persons the flags get all bal.
        /// </summary>
        /// <returns>IList&lt;PersonFlags&gt;.</returns>
        public IList<PersonFlags> PersonFlagsbyOrganization_GetALLBAL(string Oid, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return _ConfigurationDAL.PersonFlagsbyOrganization_GetALL(Oid, StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

        /// <summary>
        /// Persons the flags create bal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns>System.Int64.</returns>
        public long PersonFlags_CreateBAL(PersonFlags _objPersonFlags)
        {
            return _ConfigurationDAL.PersonFlags_CreateDAL(_objPersonFlags);
        }

        /// <summary>
        /// Persons the flags update bal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns>System.Int32.</returns>
        public int PersonFlags_UpdateBAL(PersonFlags _objPersonFlags)
        {
            return _ConfigurationDAL.PersonFlags_UpdateDAL(_objPersonFlags);
        }

        /// <summary>
        /// Persons the flags delete bal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool PersonFlags_DeleteBAL(PersonFlags _objPersonFlags)
        {
            return _ConfigurationDAL.PersonFlags_DeleteDAL(_objPersonFlags);
        }

        /// <summary>
        /// Persons the flags duplication check bal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <returns>System.Int32.</returns>
        public int PersonFlags_DuplicationCheckBAL(PersonFlags _objPersonFlags,long CompanyID)
        {
            return _ConfigurationDAL.PersonFlags_DuplicationCheckDAL(_objPersonFlags, CompanyID);
        }

        /// <summary>
        /// Persons the flags get count by Person Id bal.
        /// </summary>
        /// <param name="_objPersonFlags">The object person flags.</param>
        /// <param name="PersonId">The PersonId.</param>
        /// <returns>System.Int32.</returns>
        public int PersonFlags_GetCountByPersonIDBAL(PersonFlags _objPersonFlags, string PersonId)
        {
            return _ConfigurationDAL.PersonFlags_GetCountByPersonIDDAL(_objPersonFlags, PersonId);
        }

        /// <summary>
        /// Persons the flags get all culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;PersonFlagsDDL&gt;.</returns>
        public IList<PersonFlagsDDL> PersonFlags_GetAllCultureBAL(string culture, long CompanyID)
        {
            return _ConfigurationDAL.PersonFlags_GetAllCultureDAL(culture,CompanyID);
        }


        public IList<PersonFlagsDDL> PersonFlag_GetAllCultureBAL(string culture)
        {
            return _ConfigurationDAL.PersonFlag_GetAllCultureDAL(culture);
        }

        /// <summary>
        /// Venue the get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Venues&gt;.</returns>
        public List<Venues> Venues_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return _ConfigurationDAL.Venues_GetAllDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

        /// <summary>
        /// Venue the get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Venues&gt;.</returns>
        public List<Venues> VenuesbyOrganization_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            return _ConfigurationDAL.VenuesbyOrganization_GetAllDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText,Oid);
        }

        /// <summary>
        /// Venue the create bal.
        /// </summary>
        /// <param name="_Venues">The venues.</param>
        /// <returns>System.Int64.</returns>
        public long Venues_CreateBAL(Venues _Venues)
        {
            return _ConfigurationDAL.Venues_CreateDAL(_Venues);
        }

        /// <summary>
        /// Venue the update bal.
        /// </summary>
        /// <param name="_Venues">The venues.</param>
        /// <returns>System.Int32.</returns>
        public int Venues_UpdateBAL(Venues _Venues)
        {
            return _ConfigurationDAL.Venues_UpdateDAL(_Venues);
        }

        /// <summary>
        /// Venue the delete bal.
        /// </summary>
        /// <param name="_Venues">The venues.</param>
        /// <returns>System.Int32.</returns>
        public int Venues_DeleteBAL(Venues _Venues)
        {
            return _ConfigurationDAL.Venues_DeleteDAL(_Venues);
        }

        /// <summary>
        /// Manages the venues get all bal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>List&lt;VenueOpenMapping&gt;.</returns>
        public List<VenueOpenMapping> ManageVenues_GetAllBAL(long OpenId, int OpenType)
        {
            return _ConfigurationDAL.ManageVenues_GetAllDAL(OpenId, OpenType);
        }

        /// <summary>
        /// Manages the venues create bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int64.</returns>
        public long ManageVenues_CreateBAL(VenueOpenMapping _mapping)
        {
            return _ConfigurationDAL.ManageVenues_CreateDAL(_mapping);
        }

        /// <summary>
        /// Manages the venues update bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        public int ManageVenues_UpdateBAL(VenueOpenMapping _mapping)
        {
            return _ConfigurationDAL.ManageVenues_UpdateDAL(_mapping);
        }

        /// <summary>
        /// Manages the venues delete bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        public int ManageVenues_DeleteBAL(VenueOpenMapping _mapping)
        {
            return _ConfigurationDAL.ManageVenues_DeleteDAL(_mapping);
        }

        /// <summary>
        /// Manags the venues duplication check bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        public int ManageVenues_DuplicationCheckBAL(VenueOpenMapping _mapping)
        {
            return _ConfigurationDAL.ManageVenues_DuplicationCheckDAL(_mapping);
        }

        /// <summary>
        /// Venueses the get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <param name="OpenId">The open identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> Venues_GetAllByCultureBAL(string culture, int OpenType, long OpenId, long CompnayID)
        {
            return _ConfigurationDAL.Venues_GetAllByCultureDAL(culture, OpenType, OpenId,CompnayID);
        }

        public IList<DDlList> Venues_GetAllByCultureBAL(string culture, long CompnayID)
        {
            return _ConfigurationDAL.Venues_GetAllByCultureDAL(culture, CompnayID);
        }

        public IList<DDlList> Venues_GetAllByCultureBAL(string culture)
        {
            return _ConfigurationDAL.Venues_GetAllByCultureDAL(culture);
        }

        #region Trainer

        /// <summary>
        /// Manages the trainer get all bal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>List&lt;TrainerOpenMapping&gt;.</returns>
        public List<TrainerOpenMapping> ManageTrainer_GetAllBAL(long OpenId, int OpenType) => _ConfigurationDAL.ManageTrainer_GetAllDAL(OpenId, OpenType);

        /// <summary>
        /// Manages the trainer get by idbal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>TrainerOpenMapping.</returns>
        public TrainerOpenMapping ManageTrainer_GetByIDBAL(long ID) => _ConfigurationDAL.ManageTrainer_GetByIDDAL(ID);

        /// <summary>
        /// Manages the trainer create bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int64.</returns>
        public long ManageTrainer_CreateBAL(TrainerOpenMapping _mapping) => _ConfigurationDAL.ManageTrainer_CreateDAL(_mapping);

        /// <summary>
        /// Manages the trainer update bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        public int ManageTrainer_UpdateBAL(TrainerOpenMapping _mapping) => _ConfigurationDAL.ManageTrainer_UpdateDAL(_mapping);

        /// <summary>
        /// Manages the trainer delete bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        public int ManageTrainer_DeleteBAL(TrainerOpenMapping _mapping) => _ConfigurationDAL.ManageTrainer_DeleteDAL(_mapping);

        /// <summary>
        /// Manages the trainer duplication check bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        public int ManageTrainer_DuplicationCheckBAL(TrainerOpenMapping _mapping) => _ConfigurationDAL.ManageTrainer_DuplicationCheckDAL(_mapping);

        /// <summary>
        /// Manages the trainer duplication check bal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        public int ManageTrainer_AvalabilityCheckBAL(TrainerOpenMapping _mapping) => _ConfigurationDAL.ManageTrainer_AvailabilityCheckDAL(_mapping);

        /// <summary>
        /// Manages the trainer get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <param name="OpenId">The open identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> ManageTrainer_GetAllByCultureBAL(string culture, int OpenType, long OpenId, long CompnayID) => _ConfigurationDAL.ManageTrainer_GetAllByCultureDAL(culture, OpenType, OpenId,CompnayID);

        /// <summary>
        /// Manages the trainer get all by culture bal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <param name="OpenId">The open identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> ManageVenue_GetAllByCultureBAL(string culture, int OpenType, long OpenId, long CompnayID) => _ConfigurationDAL.ManageVenue_GetAllByCultureDAL(culture, OpenType, OpenId, CompnayID);

        #endregion Trainer

        #region Vendors

        /// <summary>
        /// Vendorses the get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Vendors&gt;.</returns>
        public List<Vendors> Vendors_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText) => _ConfigurationDAL.Vendors_GetAllDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText);

        /// <summary>
        /// Vendorses the get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Vendors&gt;.</returns>
        public List<Vendors> Vendors_GetAllBALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid) => _ConfigurationDAL.Vendors_GetAllDALbyOrg(StartRowIndex, PageSize, ref Total, SortExpression, SearchText,Oid);

        /// <summary>
        /// Vendorses the create bal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int64.</returns>
        public long Vendors_CreateBAL(Vendors _Vendors) => _ConfigurationDAL.Vendors_CreateDAL(_Vendors);

        /// <summary>
        /// Vendorses the update bal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int32.</returns>
        public int Vendors_UpdateBAL(Vendors _Vendors) => _ConfigurationDAL.Vendors_UpdateDAL(_Vendors);

        /// <summary>
        /// Vendorses the delete bal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int32.</returns>
        public int Vendors_DeleteBAL(Vendors _Vendors) => _ConfigurationDAL.Vendors_DeleteDAL(_Vendors);

        /// <summary>
        /// Vendorses the duplication check bal.
        /// </summary>
        /// <param name="_Vendors">The vendors.</param>
        /// <returns>System.Int32.</returns>
        public int Vendors_DuplicationCheckBAL(Vendors _Vendors) => _ConfigurationDAL.Vendors_DuplicationCheckDAL(_Vendors);

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
        public List<TMSCategories> TMSCategories_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText) => _ConfigurationDAL.TMSCategories_GetAllDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText);

        /// <summary>
        /// TMSs the categories get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;TMSCategories&gt;.</returns>
        public List<TMSCategories> TMSCategoriesbyOrganization_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid) => _ConfigurationDAL.TMSCategoriesbyOrganization_GetAllDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText,Oid);

        /// <summary>
        /// TMSs the categories get by idbal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>TMSCategories.</returns>
        public TMSCategories TMSCategories_GetByIDBAL(long ID) => _ConfigurationDAL.TMSCategories_GetByIDDAL(ID);

        /// <summary>
        /// TMSs the categories create bal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int64.</returns>
        public long TMSCategories_CreateBAL(TMSCategories _categories) => _ConfigurationDAL.TMSCategories_CreateDAL(_categories);

        /// <summary>
        /// TMSs the categories update bal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int32.</returns>
        public int TMSCategories_UpdateBAL(TMSCategories _categories) => _ConfigurationDAL.TMSCategories_UpdateDAL(_categories);

        /// <summary>
        /// TMSs the categories delete bal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int32.</returns>
        public int TMSCategories_DeleteBAL(TMSCategories _categories) => _ConfigurationDAL.TMSCategories_DeleteDAL(_categories);

        /// <summary>
        /// TMSs the categories duplication check bal.
        /// </summary>
        /// <param name="_categories">The categories.</param>
        /// <returns>System.Int32.</returns>
        public int TMSCategories_DuplicationCheckBAL(TMSCategories _categories) => _ConfigurationDAL.TMSCategories_DuplicationCheckDAL(_categories);

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
        public List<FocusAreas> FocusAreas_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText) => _ConfigurationDAL.FocusAreas_GetAllDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText);

        /// <summary>
        /// Focuses the areas get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;FocusAreas&gt;.</returns>
        public List<FocusAreas> FocusAreasbyOrganization_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid) => _ConfigurationDAL.FocusAreasbyOrganization_GetAllDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText,Oid);

        /// <summary>
        /// Focuses the areas create bal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int64.</returns>
        public long FocusAreas_CreateBAL(FocusAreas _objFocusAreas) => _ConfigurationDAL.FocusAreas_CreateDAL(_objFocusAreas);

        /// <summary>
        /// Focuses the areas update bal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int32.</returns>
        public int FocusAreas_UpdateBAL(FocusAreas _objFocusAreas) => _ConfigurationDAL.FocusAreas_UpdateDAL(_objFocusAreas);

        /// <summary>
        /// Focuses the areas delete bal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int32.</returns>
        public int FocusAreas_DeleteBAL(FocusAreas _objFocusAreas) => _ConfigurationDAL.FocusAreas_DeleteDAL(_objFocusAreas);

        /// <summary>
        /// Focuses the areas duplication check bal.
        /// </summary>
        /// <param name="_objFocusAreas">The object focus areas.</param>
        /// <returns>System.Int32.</returns>
        public int FocusAreas_DuplicationCheckBAL(FocusAreas _objFocusAreas) => _ConfigurationDAL.FocusAreas_DuplicationCheckDAL(_objFocusAreas);
        #endregion FocusAreas


        #region CourseMaterials

        public int ManageLogistic_DuplicationCheckBAL(CourseLogisticRequirementsMapping _objlogmap) => _ConfigurationDAL.ManageLogistic_DuplicationCheckDAL(_objlogmap);
        public int CourseMeterialMap_DuplicationCheckBAL(CourseMeterialsMapping _objlogmap) => _ConfigurationDAL.CourseMeterialMap_DuplicationCheckDAL(_objlogmap);
        /// <summary>
        /// <summary>
        /// Courses the materials get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseMaterials&gt;.</returns>
        public List<CourseMaterials> CourseMaterials_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText) => _ConfigurationDAL.CourseMaterials_GetAllDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText);

        /// <summary>
        /// Courses the materials get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseMaterials&gt;.</returns>
        public List<CourseMaterials> CourseMaterials_GetAllBALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid) => _ConfigurationDAL.CourseMaterials_GetAllDALbyOrg(StartRowIndex, PageSize, ref Total, SortExpression, SearchText,Oid);

        /// <summary>
        /// Courses the materials create bal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int64.</returns>
        public long CourseMaterials_CreateBAL(CourseMaterials _objCourseMaterials) => _ConfigurationDAL.CourseMaterials_CreateDAL(_objCourseMaterials);

        /// <summary>
        /// Courses the materials update bal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int32.</returns>
        public int CourseMaterials_UpdateBAL(CourseMaterials _objCourseMaterials) => _ConfigurationDAL.CourseMaterials_UpdateDAL(_objCourseMaterials);

        /// <summary>
        /// Courses the materials delete bal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int32.</returns>
        public int CourseMaterials_DeleteBAL(CourseMaterials _objCourseMaterials) => _ConfigurationDAL.CourseMaterials_DeleteDAL(_objCourseMaterials);

        /// <summary>
        /// Courses the materials duplication check bal.
        /// </summary>
        /// <param name="_objCourseMaterials">The object course materials.</param>
        /// <returns>System.Int32.</returns>
        public int CourseMaterials_DuplicationCheckBAL(CourseMaterials _objCourseMaterials) => _ConfigurationDAL.CourseMaterials_DuplicationCheckDAL(_objCourseMaterials);
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
        public List<DegreeCertificates> DegreeCertificates_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText) => _ConfigurationDAL.DegreeCertificates_GetAllDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText);

        /// <summary>
        /// Degrees the certificates get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;DegreeCertificates&gt;.</returns>
        public List<DegreeCertificates> DegreeCertificates_GetAllBALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid) => _ConfigurationDAL.DegreeCertificates_GetAllDALbyOrg(StartRowIndex, PageSize, ref Total, SortExpression, SearchText,Oid);

        /// <summary>
        /// Degrees the certificates create bal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int64.</returns>
        public long DegreeCertificates_CreateBAL(DegreeCertificates _objDegreeCertificates) => _ConfigurationDAL.DegreeCertificates_CreateDAL(_objDegreeCertificates);

        /// <summary>
        /// Degrees the certificates update bal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int32.</returns>
        public int DegreeCertificates_UpdateBAL(DegreeCertificates _objDegreeCertificates) => _ConfigurationDAL.DegreeCertificates_UpdateDAL(_objDegreeCertificates);

        /// <summary>
        /// Degrees the certificates delete bal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int32.</returns>
        public int DegreeCertificates_DeleteBAL(DegreeCertificates _objDegreeCertificates) => _ConfigurationDAL.DegreeCertificates_DeleteDAL(_objDegreeCertificates);

        /// <summary>
        /// Degrees the certificates duplication check bal.
        /// </summary>
        /// <param name="_objDegreeCertificates">The object degree certificates.</param>
        /// <returns>System.Int32.</returns>
        public int DegreeCertificates_DuplicationCheckBAL(DegreeCertificates _objDegreeCertificates) => _ConfigurationDAL.DegreeCertificates_DuplicationCheckDAL(_objDegreeCertificates);
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
        public List<CourseLogisticRequirements> CourseLogisticRequirements_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText) => _ConfigurationDAL.CourseLogisticRequirements_GetAllDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText);

        /// <summary>
        /// Courses the logistic requirements get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;CourseLogisticRequirements&gt;.</returns>
        public List<CourseLogisticRequirements> CourseLogisticRequirements_GetAllBALbyOrg(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid) => _ConfigurationDAL.CourseLogisticRequirements_GetAllDALbyOrg(StartRowIndex, PageSize, ref Total, SortExpression, SearchText,Oid);

        /// <summary>
        /// Courses the logistic requirements create bal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int64.</returns>
        public long CourseLogisticRequirements_CreateBAL(CourseLogisticRequirements _objCourseLogisticRequirements) => _ConfigurationDAL.CourseLogisticRequirements_CreateDAL(_objCourseLogisticRequirements);

        /// <summary>
        /// Courses the logistic requirements update bal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int32.</returns>
        public int CourseLogisticRequirements_UpdateBAL(CourseLogisticRequirements _objCourseLogisticRequirements) => _ConfigurationDAL.CourseLogisticRequirements_UpdateDAL(_objCourseLogisticRequirements);

        /// <summary>
        /// Courses the logistic requirements delete bal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int32.</returns>
        public int CourseLogisticRequirements_DeleteBAL(CourseLogisticRequirements _objCourseLogisticRequirements) => _ConfigurationDAL.CourseLogisticRequirements_DeleteDAL(_objCourseLogisticRequirements);

        /// <summary>
        /// Courses the logistic requirements duplication check bal.
        /// </summary>
        /// <param name="_objCourseLogisticRequirements">The object course logistic requirements.</param>
        /// <returns>System.Int32.</returns>
        public int CourseLogisticRequirements_DuplicationCheckBAL(CourseLogisticRequirements _objCourseLogisticRequirements) => _ConfigurationDAL.CourseLogisticRequirements_DuplicationCheckDAL(_objCourseLogisticRequirements);
        #endregion CourseLogisticRequirements

        public long ManageLogisticMap_CreateBAL(CourseLogisticRequirementsMapping _mapping) => _ConfigurationDAL.ManageLogisticMap_CreateDAL(_mapping);


        public long ManageCourseMeterialMap_CreateBAL(CourseMeterialsMapping _mapping) => _ConfigurationDAL.ManageCourseMeterialMap_CreateDAL(_mapping);

        public long ManageSessionMeterialMap_CreateBAL(SessionMeterialsMapping _mapping) => _ConfigurationDAL.ManageSessionMeterialMap_CreateDAL(_mapping);

        public long ManageCourseClassMeterialMap_CreateBAL(ClassMeterialsMapping _mapping) => _ConfigurationDAL.ManageCourseClassMeterialMap_CreateDAL(_mapping);


        public long Audit_CreateBAL(string IpAddress, DateTime createddate, long oid, long userid, EventType events, string browser)
        {
           
            return  _ConfigurationDAL.Audit_CreateBAL(IpAddress,createddate,oid,userid,events,browser);
        }



        public int ManageLogisticMap_UpdateBAL(CourseLogisticRequirementsMapping _mapping) => _ConfigurationDAL.ManageLogisticMap_UpdateDAL(_mapping);

        public int ManageCourseMeterialMap_UpdateBAL(CourseMeterialsMapping _mapping) => _ConfigurationDAL.ManageCourseMeterialMap_UpdateDAL(_mapping);

        public int CourseMaterials_CheckBAL(CourseMaterials _objCourseMaterials) => _ConfigurationDAL.CourseMaterials_CheckDAL(_objCourseMaterials);

        public int CourseClassMaterials_CheckBAL(CourseMaterials _objCourseMaterials) => _ConfigurationDAL.CourseClassMaterials_CheckDAL(_objCourseMaterials);

        public int CourseSessionMaterials_CheckBAL(CourseMaterials _objCourseMaterials) => _ConfigurationDAL.CourseSessionMaterials_CheckDAL(_objCourseMaterials);

        public List<CourseLogisticRequirementsMapping> ManageCourseMap_GetAllBAL(long oid,long CourseID) => _ConfigurationDAL.ManageCourseMap_GetAllDAL(oid,CourseID);

        public List<CourseLogisticRequirements> ManageCourse_GetAllBAL(long oid) => _ConfigurationDAL.ManageCourse_GetAllDAL(oid);

        public List<CourseMeterialsMapping> ManageCourseMeterialMap_GetAllBAL(long oid, long CourseID) => _ConfigurationDAL.ManageCourseMeterialMap_GetAllDAL(oid,CourseID);

        public List<CourseMeterialsMapping> ManageCourseMeterial_GetAllBAL(long oid) => _ConfigurationDAL.ManageCourseMeterial_GetAllDAL(oid);

        public List<ClassMeterialsMapping> ManageClassMeterialMap_GetAllBAL(long oid, long ClassID) => _ConfigurationDAL.ManageClassMeterialMap_GetAllDAL(oid,ClassID);


        public List<SessionMeterialsMapping> ManageSessionMeterialMap_GetAllBAL(long oid) => _ConfigurationDAL.ManageSessionMeterialMap_GetAllDAL(oid);
        public List<AuditLog> AuditLog_GetAllBAL(long oid) => _ConfigurationDAL.AuditLog_GetAllDAL(oid);


        
        public int CourseLogisticRequirements_CheckBAL(CourseLogisticRequirements _objCourseLogisticRequirements) => _ConfigurationDAL.CourseLogisticRequirements_CheckDAL(_objCourseLogisticRequirements);





        public IList<DDlList> CourseLogistic_GetAllByCultureBALL(string culture, long CompnayID) => _ConfigurationDAL.CourseLogistic_GetAllByCultureDAL(culture, CompnayID);

        public IList<DDlList> CourseMeterial_GetAllByCultureBAL(string culture, long CompnayID) => _ConfigurationDAL.CourseMeterial_GetAllByCultureDAL(culture, CompnayID);

        public IList<DDlList> HowHeard_GetAllByCultureBAL(string culture, long CompnayID) => _ConfigurationDAL.HowHeard_GetAllByCultureDAL(culture, CompnayID);


        public IList<DDlList> CRMUser_GetAllByCultureBAL(string culture, long CompnayID) => _ConfigurationDAL.CRMUser_GetAllByCultureDAL(culture, CompnayID);


        public IList<DDlList> CRMCourses_GetAllByCultureBAL(string culture, long CompnayID) => _ConfigurationDAL.CRMCourses_GetAllByCultureDAL(culture, CompnayID);

        public IList<DDlList> CRMClasses_GetAllByCultureBAL(string culture, long CompnayID) => _ConfigurationDAL.CRMClasses_GetAllByCultureDAL(culture, CompnayID);


        
        public int ManageCourseClassMeterialMap_DeleteBAL(ClassMeterialsMapping _mapping) => _ConfigurationDAL.ManageCourseClassMeterialMap_DeleteDAL(_mapping);





        public int ManageCourseMeterialMap_DeleteBAL(CourseMeterialsMapping _mapping) => _ConfigurationDAL.ManageCourseMeterialMap_DeleteDAL(_mapping);



        public int ManageLogisticMap_DeleteBAL(CourseLogisticRequirementsMapping _mapping) => _ConfigurationDAL.ManageLogisticMap_DeleteDAL(_mapping);


    }
}