using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Business.Interfaces.CRM;
using TMS.DataObjects.Interfaces.CRM;
using TMS.Library.Entities.CRM;

namespace TMS.Business.CRM
{
    public class SalesAdministrationBAL : ISalesAdministrationBAL
    {
        private readonly ISalesAdministrationDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrganizationBAL"/> class.
        /// </summary>
        /// <param name="_OrganizationDAL">The organization dal.</param>
        public SalesAdministrationBAL(ISalesAdministrationDAL _SaleDAL)
        {
            DAL = _SaleDAL;
        }

        public long ManageCourse_CreateBAL(CRMCourses _Organization)
        {
            return DAL.ManageCourse_CreateDAL( _Organization);
        }

        public IList<CRMCourses> ManageCourse_GetAllBAL(long ID, string SearchText)
        {
            return DAL.ManageCourse_GetAllDAL(ID, SearchText);
        }

        public int CourseUpdateBAL(CRMCourses _Organization)
        {
            return DAL.CourseUpdateDAL(_Organization);
        }

        public int Course_DeleteBAL(CRMCourses _Organization)
        {
            return DAL.Course_DeleteDAL(_Organization);
        }

        //public IList<CRMCourses> ManageConfiguration_GetAllBAL(long ID, string SearchText)
        //{
        //    return DAL.ManageConfiguration_GetAllDAL(ID, SearchText);
        //}

        IList<CRMHowHeard> ISalesAdministrationBAL.ManageConfiguration_GetAllBAL(long ID, string SearchText)
        {
            return DAL.ManageConfiguration_GetAllDAL(ID, SearchText);
        }

        public long ManageConfiguration_CreateBAL(CRMHowHeard _Organization)
        {
            return DAL.ManageConfiguration_CreateDAL(_Organization);
        }

        public int ManageConfiguration_UpdateBAL(CRMHowHeard _Organization)
        {
            return DAL.ManageConfiguration_UpdateDAL(_Organization);
        }

        public int ManageConfiguration_DeleteBAL(CRMHowHeard _Organization)
        {
            return DAL.ManageConfiguration_DeleteDAL(_Organization);
        }

        public IList<CRM_PersonEnrolment> ReassignProspectBAL(long CompanyID)
        {
            return DAL.ReassignProspectDAL(CompanyID);
        }
        public IList<CRM_UserEnrolment> UserProspectBAL(long CompanyID)
        {
            return DAL.UserProspectDAL(CompanyID);
        }

        public long ReassignProspectBAL(CRM_UserMapping _Organization)
        {
            return DAL.ReassignProspectDAL(_Organization);
        }

      public long AssigementHistory_CreateBAL(CRM_UserMapping _Organization)
        {
            return DAL.AssigementHistory_CreateDAL(_Organization);
        }

        public IList<ActivitySummeryReport> ActivitySummaryReport_GetAllBAL(long ID, string SearchText)
        {
            return DAL.ActivitySummaryReport_GetAllDAL(ID, SearchText);
        }
    }
}
