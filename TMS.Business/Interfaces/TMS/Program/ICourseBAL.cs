// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 11-05-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="ICourseBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.Entities.Common.Configuration;
using TMS.Library.Entities.Coordinator;
using TMS.Library.Entities.TMS.Course;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS;

namespace TMS.Business.Interfaces.TMS
{
    /// <summary>
    /// Interface ICourseBAL
    /// </summary>
    public interface ICourseBAL
    {
        /// <summary>
        /// TMSs the courses get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Course&gt;.</returns>
        List<Course> TMS_Courses_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Course&gt;.</returns>
        List<Course> TMS_CoursesByOrganization_GetAllBAL(int page, int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Course&gt;.</returns>
        long TMS_CoursesDeleteCheck(string CourseId, string Oid);

        /// <summary>
        /// TMSs the courses get by identifier bal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Course.</returns>
        Course TMS_Courses_GetByIdBAL(string ID);
        /// <summary>
        /// Persons the insert new person bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>PersonResponse.</returns>
        List<CourseDataBar> CourseDataBarBAL(DateTime startdate, DateTime lastdate, long CompanyId);
        /// <summary>
        /// Persons the insert new person bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>PersonResponse.</returns>
        List<CourseDataBar> CourseFutureDataBarBAL(DateTime startdate, DateTime lastdate, long CompanyId);
        /// <summary>
        /// Persons the insert new person bal.
        /// </summary>
        /// <param name="_objPerson">The object person.</param>
        /// <returns>PersonResponse.</returns>
        List<CourseDataBar> CLassFutureDataBarBAL(DateTime startdate, DateTime lastdate, long CompanyId);

        /// <summary>
        /// Courses the category code by course identifier bal.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.String.</returns>
        string CourseCategoryCodeByCourseIdBAL(long id);
        /// <summary>
        /// TMSs the courses create bal.
        /// </summary>
        /// <param name="_Course">The course.</param>
        /// <returns>System.Int64.</returns>
        long TMS_Courses_CreateBAL(Course _Course);
        /// <summary>
        /// TMSs the courses update bal.
        /// </summary>
        /// <param name="_Course">The course.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Courses_UpdateBAL(Course _Course);
        int TMS_Courses_Dublicate_PrimaryNameBAL(Course _Course);
        /// <summary>
        /// TMSs the courses delete bal.
        /// </summary>
        /// <param name="_Course">The course.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Courses_DeleteBAL(Course _Course);
        int class_CheckBAL(Course _Course, long CompanyID);
        int Session_CheckBAL(Sessions _Course, long CompanyID);
        IList<Sessions> TMS_SessionAttendance_GetAllBAL(Sessions _Course);
        IList<Sessions> TMS_SessionAttendance_GetAllByIDBAL(int _Course);
        #region Course Coordinator

        IList<CourseCoordinatorMapping> TMS_CourseCoordinate_GetAllBAL(long CourseId);

        long TMS_CourseCoordinate_CreateBAL(CourseCoordinatorMapping _Coordinate, long CourseId);

        int TMS_CourseCoordinate_UpdateBAL(CourseCoordinatorMapping _Coordinate, long CourseId);

        int TMS_CourseCoordinate_DeleteDAL(CourseCoordinatorMapping _Coordinate, long CourseId);

        #endregion

        #region Course Focus Area

        IList<FocusAreas> TMS_FocusAreaDLL_GetAllBAL(string CurrentCulture,long CompanyID);

        IList<FocusAreas> TMS_CourseFocusArea_GetAllBAL(long CourseId);

        long TMS_CourseFocusArea_CreateBAL(FocusAreas _focusarea, long CourseId);

        int TMS_CourseFocusArea_UpdateBAL(FocusAreas _focusarea, long CourseId);
         int TMS_CourseFocusArea_DublicationBAL(FocusAreas _focusarea, long CourseId);
     
        int TMS_CourseFocusArea_DeleteDAL(FocusAreas _focusarea, long CourseId);

        #endregion
      //  DataSet GetCourseReportData(long ClassID, long CourseID);
    }
}
