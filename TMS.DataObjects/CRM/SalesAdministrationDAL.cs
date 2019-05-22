using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.CRM;
using TMS.Library.Entities.CRM;
using Dapper;
using System.Data.SqlClient;

namespace TMS.DataObjects.CRM
{
    public class SalesAdministrationDAL : DBGenerics, ISalesAdministrationDAL
    {
        public int CourseUpdateDAL(CRMCourses _courses)
        {
            return ExecuteScalarInt32Sp("CRM_CourseUpdate",
                           ParamBuilder.Par("ID", _courses.ID),
                           ParamBuilder.Par("PrimaryCourseName", _courses.PrimaryCourseName),
                           ParamBuilder.Par("SecondaryCourseName", _courses.SecondaryCourseName),
                            ParamBuilder.Par("Description", _courses.Description),
                           ParamBuilder.Par("ModifiedBy", _courses.ModifiedBy),
                           ParamBuilder.Par("ModifiedDate", _courses.ModifiedOn));
        }

        public int Course_DeleteDAL(CRMCourses _Organization)
        {
            return ExecuteScalarInt32Sp("CRM_Course_Delete",
                        ParamBuilder.Par("ID", _Organization.ID),                
                        ParamBuilder.Par("ModifiedBy", _Organization.ModifiedBy),
                        ParamBuilder.Par("ModifiedDate", _Organization.ModifiedOn));
        }

       

        public long ManageCourse_CreateDAL(CRMCourses _Organization)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("CRM_Course_Create", parameters,
                        ParamBuilder.Par("PrimaryCourseName", _Organization.PrimaryCourseName),
                        ParamBuilder.Par("SecondaryCourseName", _Organization.SecondaryCourseName),
                        ParamBuilder.Par("Description", _Organization.Description),
                          ParamBuilder.Par("OrganizationID", _Organization.OrganizationID),
                        ParamBuilder.Par("CreatedBy", _Organization.CreatedBy),
                        ParamBuilder.Par("CreatedDate", _Organization.CreatedDate)
                        );
        }

        //  public object ParamBuilder { get; private set; }

        public IList<CRMCourses> ManageCourse_GetAllDAL(long ID, string SearchText)
        {
            return ExecuteListSp<CRMCourses>("CRM_Courses_GetAll", ParamBuilder.Par("OrganizationID", ID), ParamBuilder.Par("SearchText", SearchText));

        }




        //public IList<CRMCourses> ManageConfiguration_GetAllDAL(long ID, string SearchText)
        //{
        //    return ExecuteListSp<CRMCourses>("CRM_Configuration_GetAll", ParamBuilder.Par("OrganizationID", ID), ParamBuilder.Par("SearchText", SearchText));

        //}

        IList<CRMHowHeard> ISalesAdministrationDAL.ManageConfiguration_GetAllDAL(long ID, string SearchText)
        {
            return ExecuteListSp<CRMHowHeard>("CRM_Configuration_GetAll", ParamBuilder.Par("OrganizationID", ID), ParamBuilder.Par("SearchText", SearchText));

        }

        public long ManageConfiguration_CreateDAL(CRMHowHeard _Organization)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("CRM_Configration_Create", parameters,
                        ParamBuilder.Par("Name", _Organization.Name),                     
                        ParamBuilder.Par("Description", _Organization.Description),
                          ParamBuilder.Par("OrganizationID", _Organization.OrganizationID),
                        ParamBuilder.Par("CreatedBy", _Organization.CreatedBy),
                        ParamBuilder.Par("CreatedDate", _Organization.CreatedDate)
                        );
        }

        public int ManageConfiguration_UpdateDAL(CRMHowHeard _Organization)
        {
            return ExecuteScalarInt32Sp("CRM_ConfigrationUpdate",
                           ParamBuilder.Par("ID", _Organization.ID),
                           ParamBuilder.Par("Name", _Organization.Name),
                            ParamBuilder.Par("Description", _Organization.Description),
                           ParamBuilder.Par("ModifiedBy", _Organization.ModifiedBy),
                           ParamBuilder.Par("ModifiedDate", _Organization.ModifiedOn));

          
        }

        public int ManageConfiguration_DeleteDAL(CRMHowHeard _Organization)
        {
            return ExecuteScalarInt32Sp("CRM_Confugration_Delete",
                      ParamBuilder.Par("ID", _Organization.ID),
                      ParamBuilder.Par("ModifiedBy", _Organization.ModifiedBy),
                      ParamBuilder.Par("ModifiedDate", _Organization.ModifiedOn));
        }

        public IList<CRM_PersonEnrolment> ReassignProspectDAL(long CompanyID)
        {
            return ExecuteListSp<CRM_PersonEnrolment>("CRM_Prospects_GetAll", ParamBuilder.Par("OrganizationID", CompanyID));
        }
        public IList<CRM_UserEnrolment> UserProspectDAL(long CompanyID)
        {
            return ExecuteListSp<CRM_UserEnrolment>("CRM_Users_GetAll", ParamBuilder.Par("OrganizationID", CompanyID));
        }

         public long ReassignProspectDAL(CRM_UserMapping _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_UserMapping_Create",
                     ParamBuilder.Par("PersonID", _mapping.PersonID),
                        ParamBuilder.Par("UserID", _mapping.UserID),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),

                        ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn)
                        );
        }


        public long AssigementHistory_CreateDAL(CRM_UserMapping _mapping)
        {
            return ExecuteScalarInt32Sp("CRM_ProspectsAssignmentHistory_Create",
                     ParamBuilder.Par("PersonID", _mapping.PersonID),
                        ParamBuilder.Par("UserID", _mapping.UserID),
                        ParamBuilder.Par("UpdatedBy", _mapping.UpdatedBy),

                        ParamBuilder.Par("UpdatedOn", _mapping.UpdatedOn)
                        );


        }

        public IList<ActivitySummeryReport> ActivitySummaryReport_GetAllDAL(long ID, string SearchText)
        {
            return ExecuteListSp<ActivitySummeryReport>("CRM_ActivitySummaryReport", ParamBuilder.Par("OrganizationID", ID), ParamBuilder.Par("SearchText", SearchText));

        }
    }
}
