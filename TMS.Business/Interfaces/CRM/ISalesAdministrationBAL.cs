using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities.CRM;

namespace TMS.Business.Interfaces.CRM
{
   public interface ISalesAdministrationBAL
    {


        IList<CRMCourses> ManageCourse_GetAllBAL(long ID, string SearchText);


        long ManageCourse_CreateBAL(CRMCourses _Organization);

        int CourseUpdateBAL(CRMCourses _Organization);

        int Course_DeleteBAL(CRMCourses _Organization);



        IList<CRMHowHeard> ManageConfiguration_GetAllBAL(long ID, string SearchText);

        IList<ActivitySummeryReport> ActivitySummaryReport_GetAllBAL(long ID, string SearchText);
                             
   //     IList<ActivitySummeryReport> DuplicateProspectReport_GetAllBAL(long ID, string SearchText);

        long ManageConfiguration_CreateBAL(CRMHowHeard _Organization);

        int ManageConfiguration_UpdateBAL(CRMHowHeard _Organization);

        int ManageConfiguration_DeleteBAL(CRMHowHeard _Organization);

        

        IList<CRM_PersonEnrolment> ReassignProspectBAL(long CompanyID);

        IList<CRM_UserEnrolment> UserProspectBAL(long CompanyID);

        long ReassignProspectBAL(CRM_UserMapping _Organization);
        long AssigementHistory_CreateBAL(CRM_UserMapping _Organization);

    }
}
