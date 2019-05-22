using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities.CRM;

namespace TMS.DataObjects.Interfaces.CRM
{
   public interface ISalesAdministrationDAL
    {
        IList<CRMCourses> ManageCourse_GetAllDAL(long ID, string SearchText);

        long ManageCourse_CreateDAL(CRMCourses _Organization);

        int CourseUpdateDAL(CRMCourses _Organization);


        int Course_DeleteDAL(CRMCourses _Organization);


     //   IList<CRMCourses> ManageConfiguration_GetAllDAL(long ID, string SearchText);


        IList<CRMHowHeard> ManageConfiguration_GetAllDAL(long ID, string SearchText);


        long ManageConfiguration_CreateDAL(CRMHowHeard _Organization);

        int ManageConfiguration_UpdateDAL(CRMHowHeard _Organization);

        int ManageConfiguration_DeleteDAL(CRMHowHeard _Organization);

        IList<CRM_PersonEnrolment> ReassignProspectDAL(long CompanyID);

        IList<CRM_UserEnrolment> UserProspectDAL(long CompanyID);

        long ReassignProspectDAL(CRM_UserMapping _Organization);

        long AssigementHistory_CreateDAL(CRM_UserMapping _Organization);
        IList<ActivitySummeryReport> ActivitySummaryReport_GetAllDAL(long ID, string SearchText);

    }
}
