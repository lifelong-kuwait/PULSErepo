using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Business.Interfaces.TMS.Exams;
using TMS.DataObjects.Interfaces.TMS.Exams;
using TMS.Library.TMS.CourseRelatedExam;

using TMS.DataObjects.Interfaces.TMS.Organization;
using TMS.Library.Common.Address;
using TMS.Library.TMS.Organization;
using TMS.Library.TMS.Organization.POC;

namespace TMS.Business.TMS.Exams
{
    public class ExamsBAL:IExamsBAL
    {
        private readonly IExamsDAL _DAL;

        public ExamsBAL(IExamsDAL _IExamsDAL)
        {
            _DAL = _IExamsDAL;
        }
        /// <summary>
        /// Gets all organization bal.
        /// </summary>
        /// <returns>IList&lt;CourseRelatedExamModel&gt;.</returns>
        public IList<CourseRelatedExamModel> GetAllOrganizationBAL()
        {
            return _DAL.GetAllOrganizationDAL();
        }



        //private readonly IOrganizationDAL DAL;

        ///// <summary>
        ///// Initializes a new instance of the <see cref="OrganizationBAL"/> class.
        ///// </summary>
        ///// <param name="_OrganizationDAL">The organization dal.</param>
        //public ExamsBAL(IOrganizationDAL _OrganizationDAL)
        //{
        //    DAL = _OrganizationDAL;
        //}
        ///// <summary>
        ///// Organizations the allby culture bal.
        ///// </summary>
        ///// <param name="culture">The culture.</param>
        ///// <returns>IList&lt;DDlList&gt;.</returns>
        //public IList<DDlList> OrganizationAllbyCultureBAL(string culture)
        //{
        //    return DAL.OrganizationAllbyCultureDAL(culture);
        //}

        ///// <summary>
        ///// Gets the organization by identifier bal.
        ///// </summary>
        ///// <param name="Id">The identifier.</param>
        ///// <returns>OrganizationModel.</returns>
        //public OrganizationModel GetOrganizationByIdBAL(long Id)
        //{
        //    return DAL.GetOrganizationByIdDAL(Id);
        //}

        ///// <summary>
        ///// Organizationses the create bal.
        ///// </summary>
        ///// <param name="_Organization">The organization.</param>
        ///// <returns>System.Int64.</returns>
        //public long Organizations_CreateBAL(OrganizationModel _Organization)
        //{
        //    return DAL.Organizations_CreateDAL(_Organization);
        //}

        ///// <summary>
        ///// Organizationses the update bal.
        ///// </summary>
        ///// <param name="_Organization">The organization.</param>
        ///// <returns>System.Int32.</returns>
        //public int Organizations_UpdateBAL(OrganizationModel _Organization)
        //{
        //    return DAL.Organizations_UpdateDAL(_Organization);
        //}

        ///// <summary>
        ///// Organizationses the delete bal.
        ///// </summary>
        ///// <param name="_Organization">The organization.</param>
        ///// <returns>System.Int32.</returns>
        //public int Organizations_DeleteBAL(OrganizationModel _Organization)
        //{
        //    return DAL.Organizations_DeleteDAL(_Organization);
        //}

        //#region "Point of Contact"
        ///// <summary>
        ///// Gets the point of contact by organization identifier bal.
        ///// </summary>
        ///// <param name="Id">The identifier.</param>
        ///// <returns>IList&lt;PointsOfContact&gt;.</returns>
        //public IList<PointsOfContact> GetPointOfContactByOrganizationIdBAL(long Id)
        //{
        //    return DAL.GetPointOfContactByOrganizationIdDAL(Id);
        //}
        ///// <summary>
        ///// Points the of contact create bal.
        ///// </summary>
        ///// <param name="_OrganizationRelation">The organization relation.</param>
        ///// <returns>System.Int64.</returns>
        //public long PointOfContact_CreateBAL(PointsOfContact _OrganizationRelation)
        //{
        //    return DAL.PointOfContact_CreateDAL(_OrganizationRelation);
        //}

        ///// <summary>
        ///// Points the of contact update bal.
        ///// </summary>
        ///// <param name="_OrganizationRelation">The organization relation.</param>
        ///// <returns>System.Int32.</returns>
        //public int PointOfContact_UpdateBAL(PointsOfContact _OrganizationRelation)
        //{
        //    return DAL.PointOfContact_UpdateDAL(_OrganizationRelation);
        //}

        ///// <summary>
        ///// Points the of contact delete bal.
        ///// </summary>
        ///// <param name="_OrganizationRelation">The organization relation.</param>
        ///// <returns>System.Int32.</returns>
        //public int PointOfContact_DeleteBAL(PointsOfContact _OrganizationRelation)
        //{
        //    return DAL.PointOfContact_DeleteDAL(_OrganizationRelation);
        //}

        ///// <summary>
        ///// Points the of contact duplication check bal.
        ///// </summary>
        ///// <param name="_OrganizationRelation">The organization relation.</param>
        ///// <returns>System.Int32.</returns>
        //public int PointOfContact_DuplicationCheckBAL(PointsOfContact _OrganizationRelation)
        //{
        //    return DAL.PointOfContact_DuplicationCheckDAL(_OrganizationRelation);
        //}
        //#endregion

        //#region"Organization links"
        ///// <summary>
        ///// Organizations the links getby organization identifier bal.
        ///// </summary>
        ///// <param name="OrganizationId">The organization identifier.</param>
        ///// <returns>IList&lt;Links&gt;.</returns>
        //public IList<Links> OrganizationLinks_GetbyOrganizationIdBAL(long OrganizationId)
        //{
        //    return DAL.OrganizationLinks_GetbyOrganizationId(OrganizationId);
        //}

        ///// <summary>
        ///// Organizations the links create bal.
        ///// </summary>
        ///// <param name="_objLinks">The object links.</param>
        ///// <param name="OrganizationId">The organization identifier.</param>
        ///// <returns>System.Int64.</returns>
        //public long OrganizationLinks_CreateBAL(Links _objLinks, long OrganizationId)
        //{
        //    return DAL.OrganizationLinks_CreateDAL(_objLinks, OrganizationId);
        //}

        ///// <summary>
        ///// Organizations the links update bal.
        ///// </summary>
        ///// <param name="_objLinks">The object links.</param>
        ///// <returns>System.Int32.</returns>
        //public int OrganizationLinks_UpdateBAL(Links _objLinks)
        //{
        //    return DAL.OrganizationLinks_UpdateDAL(_objLinks);
        //}

        ///// <summary>
        ///// Organizations the links delete bal.
        ///// </summary>
        ///// <param name="_objLinks">The object links.</param>
        ///// <param name="OrganizationId">The organization identifier.</param>
        ///// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        //public bool OrganizationLinks_DeleteBAL(Links _objLinks, long OrganizationId)
        //{
        //    return DAL.OrganizationLinks_DeleteDAL(_objLinks, OrganizationId);
        //}

        ///// <summary>
        ///// Organizations the links duplication check bal.
        ///// </summary>
        ///// <param name="_objLinks">The object links.</param>
        ///// <param name="OrganizationId">The organization identifier.</param>
        ///// <returns>System.Int32.</returns>
        //public int OrganizationLinks_DuplicationCheckBAL(Links _objLinks, long OrganizationId)
        //{
        //    return DAL.OrganizationLinks_DuplicationCheckDAL(_objLinks, OrganizationId);
        //}
        ///// <summary>
        ///// Organizations the links get count by organization idbal.
        ///// </summary>
        ///// <param name="OrganizationId">The organization identifier.</param>
        ///// <returns>System.Int32.</returns>
        //public int OrganizationLinks_GetCountByOrganizationIDBAL(long OrganizationId)
        //{
        //    return DAL.OrganizationLinks_GetCountByOrganizationIDDAL(OrganizationId);
        //}
        //#endregion

    }
}
