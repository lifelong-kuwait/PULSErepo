// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 12-24-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-10-2018
// ***********************************************************************
// <copyright file="ConfigurationDALVenue.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.Common.Configuration;
using TMS.Library.Entities.Common.Configuration.Venues;

namespace TMS.DataObjects.Common.Configuration
{
    /// <summary>
    /// Class ConfigurationDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.Common.Configuration.IConfigurationDAL" />
    public partial class ConfigurationDAL : DBGenerics, IConfigurationDAL
    {
        #region Add Edit Delete GetAll GetByID for the Venue

        /// <summary>
        /// Venues the get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Venues&gt;.</returns>
        public List<Venues> Venues_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            List<Venues> Venue = new List<Venues>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText });
                using (var multi = conn.QueryMultiple("Venues_GetAll", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Venue = multi.Read<Venues>().AsList<Venues>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Venue.ToList();
        }

        /// <summary>
        /// Venues the get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Venues&gt;.</returns>
        public List<Venues> VenuesbyOrganization_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            List<Venues> Venue = new List<Venues>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { StartRowIndex = StartRowIndex, PageSize = PageSize, SortExpression = SortExpression, SearchText = SearchText, Oid = Oid });
                using (var multi = conn.QueryMultiple("Venues_GetAllbyOrganization", dbParams, commandType: System.Data.CommandType.StoredProcedure))
                {
                    Venue = multi.Read<Venues>().AsList<Venues>();
                    if (!multi.IsConsumed)
                        Total = multi.Read<int>().FirstOrDefault<int>();
                }

                conn.Close();
            }
            return Venue.ToList();
        }

        /// <summary>
        /// Venues the create dal.
        /// </summary>
        /// <param name="_Venues">The venues.</param>
        /// <returns>System.Int64.</returns>
        public long Venues_CreateDAL(Venues _Venues)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("Venues_Create", parameters,
                    ParamBuilder.Par("PrimaryName", _Venues.PrimaryName),
                    ParamBuilder.Par("SecondaryName", _Venues.SecondaryName),
                    ParamBuilder.Par("VenueStatusID", _Venues.VenueStatusID),
                    ParamBuilder.Par("DrivingInstruction", _Venues.DrivingInstruction),
                    ParamBuilder.Par("Coordinates", _Venues.Coordinates),
                    ParamBuilder.Par("PersonID", _Venues.PersonID),
                    ParamBuilder.Par("VenueCodeID", _Venues.VenueCodeID),
                    ParamBuilder.Par("OrganizationID", _Venues.OrganizationID),
                    ParamBuilder.Par("Rating", _Venues.Rating),
                    ParamBuilder.Par("RateType", _Venues.RateType),
                    ParamBuilder.Par("Cost", _Venues.Cost),
                    ParamBuilder.Par("Currency", _Venues.Currency),
                    ParamBuilder.Par("Setup", _Venues.Setup),
                    ParamBuilder.Par("Notes", _Venues.Notes),
                    ParamBuilder.Par("Capacity", _Venues.Capacity),
                    ParamBuilder.Par("ContactPersonName", _Venues.ContactPersonName),
                    ParamBuilder.Par("ContactPersonPhone", _Venues.ContactPersonPhone),
                    ParamBuilder.Par("ContactPersonEmail", _Venues.ContactPersonEmail),
                    ParamBuilder.Par("AvailableFrom", _Venues.AvailableFrom),
                    ParamBuilder.Par("AvailableTo", _Venues.AvailableTo),
                    ParamBuilder.Par("IsCommon", _Venues.IsCommon),
                    ParamBuilder.Par("AddressLine1", _Venues.AddressLine1),
                    ParamBuilder.Par("AddressLine2", _Venues.AddressLine2),
                    ParamBuilder.Par("ZipCode", _Venues.ZipCode),
                    ParamBuilder.Par("CountryID", _Venues.CountryID),
                    ParamBuilder.Par("StateID", _Venues.StateID),
                    ParamBuilder.Par("CityID", _Venues.CityID),
                    ParamBuilder.Par("CreatedBy", _Venues.CreatedBy),
                    ParamBuilder.Par("CreatedDate", _Venues.CreatedDate)
);
        }

        /// <summary>
        /// Venues the update dal.
        /// </summary>
        /// <param name="_Venues">The venues.</param>
        /// <returns>System.Int32.</returns>
        public int Venues_UpdateDAL(Venues _Venues)
        {
            return ExecuteScalarInt32Sp("Venues_Update",
                        ParamBuilder.Par("ID", _Venues.ID),
                        ParamBuilder.Par("PrimaryName", _Venues.PrimaryName),
                        ParamBuilder.Par("SecondaryName", _Venues.SecondaryName),
                        ParamBuilder.Par("VenueStatusID", _Venues.VenueStatusID),
                        ParamBuilder.Par("DrivingInstruction", _Venues.DrivingInstruction),
                        ParamBuilder.Par("Coordinates", _Venues.Coordinates),
                        ParamBuilder.Par("PersonID", _Venues.PersonID),
                        ParamBuilder.Par("VenueCodeID", _Venues.VenueCodeID),
                        ParamBuilder.Par("Rating", _Venues.Rating),
                        ParamBuilder.Par("RateType", _Venues.RateType),
                        ParamBuilder.Par("Cost", _Venues.Cost),
                        ParamBuilder.Par("Currency", _Venues.Currency),
                        ParamBuilder.Par("Setup", _Venues.Setup),
                        ParamBuilder.Par("Notes", _Venues.Notes),
                        ParamBuilder.Par("Capacity", _Venues.Capacity),
                        ParamBuilder.Par("ContactPersonName", _Venues.ContactPersonName),
                        ParamBuilder.Par("ContactPersonPhone", _Venues.ContactPersonPhone),
                        ParamBuilder.Par("ContactPersonEmail", _Venues.ContactPersonEmail),
                        ParamBuilder.Par("AvailableFrom", _Venues.AvailableFrom),
                        ParamBuilder.Par("AvailableTo", _Venues.AvailableTo),
                        ParamBuilder.Par("IsCommon", _Venues.IsCommon),
                        ParamBuilder.Par("AddressLine1", _Venues.AddressLine1),
                        ParamBuilder.Par("AddressLine2", _Venues.AddressLine2),
                        ParamBuilder.Par("ZipCode", _Venues.ZipCode),
                        ParamBuilder.Par("CountryID", _Venues.CountryID),
                        ParamBuilder.Par("StateID", _Venues.StateID),
                        ParamBuilder.Par("CityID", _Venues.CityID),
                        ParamBuilder.Par("UpdatedBy", _Venues.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _Venues.UpdatedDate)
            );
        }

        /// <summary>
        /// Venues the delete dal.
        /// </summary>
        /// <param name="_Venues">The venues.</param>
        /// <returns>System.Int32.</returns>
        public int Venues_DeleteDAL(Venues _Venues)
        {
            return ExecuteScalarInt32Sp("Venues_Delete",
                        ParamBuilder.Par("ID", _Venues.ID),
                        ParamBuilder.Par("UpdatedBy", _Venues.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _Venues.UpdatedDate)

            );
        }

        #endregion Add Edit Delete GetAll GetByID for the Venue

        //

        #region Add Edit Delete GetAll GetByID for the Venue

        /// <summary>
        /// Manages the venues get all dal.
        /// </summary>
        /// <param name="OpenId">The open identifier.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <returns>List&lt;VenueOpenMapping&gt;.</returns>
        public List<VenueOpenMapping> ManageVenues_GetAllDAL(long OpenId, int OpenType)
        {
            List<VenueOpenMapping> Venue = new List<VenueOpenMapping>();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { OpenId = OpenId, OpenType = OpenType });
                Venue = conn.Query<VenueOpenMapping>("VenueOpenMapping_GetAllByTypeAndId", dbParams, commandType: System.Data.CommandType.StoredProcedure).ToList<VenueOpenMapping>();
                conn.Close();
            }
            return Venue.ToList();
        }

        /// <summary>
        /// Manages the venues get by iddal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>VenueOpenMapping.</returns>
        public VenueOpenMapping ManageVenues_GetByIDDAL(long ID)
        {
            VenueOpenMapping Venue = new VenueOpenMapping();
            using (var conn = new SqlConnection(DBHelper.ConnectionString))
            {
                conn.Open();
                DynamicParameters dbParams = new DynamicParameters();
                dbParams.AddDynamicParams(new { ID = ID });
                Venue = conn.Query<VenueOpenMapping>("VenueOpenMapping_GetbyId", dbParams, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault<VenueOpenMapping>();
                conn.Close();
            }
            return Venue;
        }

        /// <summary>
        /// Manages the venues create dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int64.</returns>
        public long ManageVenues_CreateDAL(VenueOpenMapping _mapping)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("VenueOpenMapping_Create", parameters,
                        ParamBuilder.Par("VenueID", _mapping.VenueID),
                        ParamBuilder.Par("OpenId", _mapping.OpenId),
                        ParamBuilder.Par("OpenType", _mapping.OpenType),
                        ParamBuilder.Par("CreatedBy", _mapping.CreatedBy),
                        ParamBuilder.Par("CreatedDate", _mapping.CreatedDate)
                        );
        }

        /// <summary>
        /// Manages the venues update dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        public int ManageVenues_UpdateDAL(VenueOpenMapping _mapping)
        {
            return ExecuteScalarInt32Sp("VenueOpenMapping_Update",
                        ParamBuilder.Par("ID", _mapping.ID),
                        ParamBuilder.Par("VenueID", _mapping.VenueID),
                        ParamBuilder.Par("UpdatedDate", _mapping.UpdatedDate),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy)
                        );
        }

        /// <summary>
        /// Manages the venues delete dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        public int ManageVenues_DeleteDAL(VenueOpenMapping _mapping)
        {
            return ExecuteScalarInt32Sp("VenueOpenMapping_Delete",
                        ParamBuilder.Par("ID", _mapping.ID),
                        ParamBuilder.Par("UpdatedDate", _mapping.UpdatedDate),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy)

                        );
        }

        /// <summary>
        /// Manages the venues duplication check dal.
        /// </summary>
        /// <param name="_mapping">The mapping.</param>
        /// <returns>System.Int32.</returns>
        public int ManageVenues_DuplicationCheckDAL(VenueOpenMapping _mapping)
        {
            return ExecuteScalarSPInt32("VenueOpenMapping_DuplicationCheck",
                    ParamBuilder.Par("VenueID", _mapping.VenueID),
                                ParamBuilder.Par("OpenId", _mapping.OpenId), ParamBuilder.Par("OpenType", _mapping.OpenType));
        }

        /// <summary>
        /// Venues the get all by culture dal.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="OpenType">Type of the open.</param>
        /// <param name="OpenId">The open identifier.</param>
        /// <returns>IList&lt;DDlList&gt;.</returns>
        public IList<DDlList> Venues_GetAllByCultureDAL(string culture, int OpenType, long OpenId,long CompnayID)
        {
            if (CompnayID > 0)
            {
                switch (OpenType)
                {
                    case -1:
                        return ExecuteListSp<DDlList>("Venues_ForCourseGetAllByCulturebyOrg", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));
                    case 3:
                        return ExecuteListSp<DDlList>("Venues_ForCourseGetAllByCulturebyOrg", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));

                    default:
                        return ExecuteListSp<DDlList>("Venues_ByOpenIdAndTypeAndCulturebyOrg", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OpenId", OpenId), ParamBuilder.Par("OpenType", OpenType), ParamBuilder.Par("OrganizationID", CompnayID));
                }
            }
            else
            {
                switch (OpenType)
                {
                    case -1:
                        return ExecuteListSp<DDlList>("Venues_ForCourseGetAllByCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));
                    case 3:
                        return ExecuteListSp<DDlList>("Venues_ForCourseGetAllByCulturebyOrg", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));

                    default:
                        return ExecuteListSp<DDlList>("Venues_ByOpenIdAndTypeAndCulture", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OpenId", OpenId), ParamBuilder.Par("OpenType", OpenType), ParamBuilder.Par("OrganizationID", CompnayID));
                }
            }
           
        }

        public IList<DDlList> Venues_GetAllByCultureDAL(string culture, long CompnayID)
        {
            return ExecuteListSp<DDlList>("Venues_ForCourseGetAllByCulturebyOrg", ParamBuilder.Par("culture", culture), ParamBuilder.Par("OrganizationID", CompnayID));
        }

        public IList<DDlList> Venues_GetAllByCultureDAL(string culture)
        {
            return ExecuteListSp<DDlList>("Venues_ForCourseGetAllByCulture", ParamBuilder.Par("culture", culture));
        }

        #endregion Add Edit Delete GetAll GetByID for the Venue
    }
}