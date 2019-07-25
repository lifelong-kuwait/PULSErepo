// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 11-05-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="ICourseDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Data;
using TMS.Library.Entities.Common.Configuration;
using TMS.Library.Entities.Coordinator;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS;

namespace TMS.DataObjects.Interfaces.TMS
{
    /// <summary>
    /// Interface ICourseDAL
    /// </summary>
    public interface ICourseDAL
    {
        /// <summary>
        /// TMSs the courses get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Course&gt;.</returns>
        List<Course> TMS_Courses_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText);

        /// <summary>
        /// TMSs the courses get all dal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Course&gt;.</returns>
        List<Course> TMS_CoursesByOrganization_GetAllDAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid);

        /// <summary>
        /// TMSs the courses get by identifier dal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Course.</returns>
        Course TMS_Courses_GetByIdDAL(string ID);

        /// <summary>
        /// Courses the category code by course identifier dal.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.String.</returns>
        string CourseCategoryCodeByCourseIdDAL(long id);

        /// <summary>
        /// TMSs the courses create dal.
        /// </summary>
        /// <param name="_Course">The course.</param>
        /// <returns>System.Int64.</returns>
        long TMS_Courses_CreateDAL(Course _Course);
        /// <summary>
        /// TMSs the courses create dal.
        /// </summary>
        /// <param name="_Course">The course.</param>
        /// <returns>System.Int64.</returns>
        IList<Sessions> TMS_SessionAttendance_GetAllDAL(Sessions _Course);
        IList<Sessions> TMS_SessionAttendance_GetAllByIDDAL(int _Course);
        /// <summary>
        /// TMSs the courses update dal.
        /// </summary>
        /// <param name="_Course">The course.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Courses_UpdateDAL(Course _Course);
        int TMS_Courses_Dublicate_PrimaryNameDAL(Course _Course);
        /// <summary>
        /// TMSs the courses delete dal.
        /// </summary>
        /// <param name="_Course">The course.</param>
        /// <returns>System.Int32.</returns>
        int TMS_Courses_DeleteDAL(Course _Course);
        int class_CheckDAL(Course _Course, long CompanyID);

        int Session_CheckBAL(Sessions _Course, long CompanyID);

        #region Course Coordinate

        IList<CourseCoordinatorMapping> TMS_CourseCoordinator_GetAllDAL(long CourseId);

        long TMS_CourseCoordinate_CreateDAL(CourseCoordinatorMapping _Coordinate, long CourseId);

        int TMS_CourseCoordinate_UpdateDAL(CourseCoordinatorMapping _Coordinate, long CourseId);

        int TMS_CourseCoordinate_DeleteDAL(CourseCoordinatorMapping _Coordinate, long CourseId);

        #endregion

        #region Course Focus Area

        IList<FocusAreas> TMS_FocusAreaDLL_GetAllDAL(string CurrentCulture, long CompanyID);

        IList<FocusAreas> TMS_CourseFocusArea_GetAllDAL(long CourseId);

        long TMS_CourseFocusArea_CreateDAL(FocusAreas _focusarea, long CourseId);

        int TMS_CourseFocusArea_UpdateDAL(FocusAreas _focusarea, long CourseId);

        int TMS_CourseFocusArea_DeleteDAL(FocusAreas _focusarea, long CourseId);
         int TMS_CourseFocusArea_DublicationDAL(FocusAreas _focusarea, long CourseId);
        #endregion

        // DataSet GetCourseReportDataDAL(long ClassID, long CourseID);
    }
}