// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 11-04-2017
// ***********************************************************************
// <copyright file="TMSResourcesBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Business.Interfaces.Admin;
using TMS.DataObjects.Interfaces.TMS.Admin;
using TMS.DataObjects.TMS.Admin;
using TMS.Library.Admin;

namespace TMS.Business.Admin
{
    /// <summary>
    /// Class TMSResourcesBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.Admin.ITMSResourcesBAL" />
    public class TMSResourcesBAL : ITMSResourcesBAL
    {
        /// <summary>
        /// The dal
        /// </summary>
        public ITMSResourceDAL DAL;
        /// <summary>
        /// Initializes a new instance of the <see cref="TMSResourcesBAL"/> class.
        /// </summary>
        public TMSResourcesBAL()
        {
            DAL = new TMSResourceDAL();
        }

        public int ResourceExistCountBAL(string Name)
        {
            return DAL.ResourceExistCountDAL(Name);
        }

        public int LanguageExistCountBAL(long CompnayID)
        {
            return DAL.LanguageExistCountDAL(CompnayID);
        }

        /// <summary>
        /// Gets the TMS resource bal.
        /// </summary>
        /// <param name="Page">The page.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <returns>IList&lt;TMSResource&gt;.</returns>
        public IList<TMSResource> GetTMSResourceBAL(int Page, int PageSize, ref int Total, string SearchText,string Oids)
        {

            return DAL.GetTMSResourceDAL(Page, PageSize, ref Total,  SearchText, Oids);
        }

        /// <summary>
        /// Gets the TMS resource bal.
        /// </summary>
        /// <param name="Page">The page.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <returns>IList&lt;TMSResource&gt;.</returns>
        public IList<TMSResource> GetTMSResourceBALbyOrganization(int Page, int PageSize, ref int Total, string Oid, string SearchText )
        {

            return DAL.GetTMSResourceDALbyOrganization(Page, PageSize,  ref Total, Oid, SearchText);
        }

        /// <summary>
        /// Inserts the dual TMS resource bal.
        /// </summary>
        /// <param name="_obj">The object.</param>
        /// <returns>ResourceCreationDual.</returns>
        public ResourceCreationDual InsertDualTMSResourceBAL(TMSResource _obj)
        {

            return DAL.InsertDualTMSResourceDAL(_obj);
        }
        // <summary>
        /// Resources the exist count bal.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <returns>System.Int32.</returns>
        public ResourceCreationDual InsertOrgResourceBAL(TMSResource _obj)
        {

            return DAL.InsertOrgResourceDAL(_obj);
        }
        /// <summary>
        /// Resources the exist count bal.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <returns>System.Int32.</returns>
        //public int ResourceExistCountBAL(string Name)
        //{
        //    return DAL.ResourceExistCountDAL(Name);
        //}
        /// <summary>
        /// Updates the dual TMS resource bal.
        /// </summary>
        /// <param name="_obj">The object.</param>
        /// <returns>System.Int32.</returns>
        public int UpdateDualTMSResourceBAL(TMSResource _obj)
        {
            return DAL.UpdateDualTMSResourceDAL(_obj);

        }

       
    }
}
