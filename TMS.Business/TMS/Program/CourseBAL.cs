// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 11-05-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="CourseBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Data;
using TMS.Business.Interfaces.TMS;
using TMS.DataObjects.Interfaces.TMS;
using TMS.Library.Entities.Common.Configuration;
using TMS.Library.Entities.Coordinator;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS;

namespace TMS.Business.TMS
{
    /// <summary>
    /// Class CourseBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.TMS.ICourseBAL" />
    public class CourseBAL : ICourseBAL
    {
        private readonly ICourseDAL _CourseDAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="CourseBAL"/> class.
        /// </summary>
        /// <param name="__CourseDAL">The course dal.</param>
        public CourseBAL(ICourseDAL __CourseDAL)
        {
            _CourseDAL = __CourseDAL;
        }

        public CourseBAL()
        {
        }

        /// <summary>
        /// TMSs the courses get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Course&gt;.</returns>
        public List<Course> TMS_Courses_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText)
        {
            return _CourseDAL.TMS_Courses_GetAllDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText);
        }

        /// <summary>
        /// TMSs the courses get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Course&gt;.</returns>
        public List<Course> TMS_CoursesByOrganization_GetAllBAL(int StartRowIndex, int PageSize, ref int Total, string SortExpression, string SearchText,string Oid)
        {
            return _CourseDAL.TMS_CoursesByOrganization_GetAllDAL(StartRowIndex, PageSize, ref Total, SortExpression, SearchText,Oid);
        }
        /// <summary>
        /// TMSs the courses get all bal.
        /// </summary>
        /// <param name="StartRowIndex">Start index of the row.</param>
        /// <param name="PageSize">Size of the page.</param>
        /// <param name="Total">The total.</param>
        /// <param name="SortExpression">The sort expression.</param>
        /// <param name="SearchText">The search text.</param>
        /// <returns>List&lt;Course&gt;.</returns>
        public long TMS_CoursesDeleteCheck(string CourseId, string Oid)
        {
            return _CourseDAL.TMS_CoursesDeleteCheckDAL( CourseId,  Oid);
        }
        /// <summary>long TMS_CoursesDeleteCheck(string CourseId, string Oid);
        /// TMSs the courses get by identifier bal.
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>Course.</returns>
        public Course TMS_Courses_GetByIdBAL(string ID)
        {
            return _CourseDAL.TMS_Courses_GetByIdDAL(ID);
        }
        /// <summary>
        /// Courses the category code by course identifier bal.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.String.</returns>
        public string CourseCategoryCodeByCourseIdBAL(long id)
        {
            return _CourseDAL.CourseCategoryCodeByCourseIdDAL(id);
        }

        /// <summary>
        /// TMSs the courses create bal.
        /// </summary>
        /// <param name="_Course">The course.</param>
        /// <returns>System.Int64.</returns>
        public long TMS_Courses_CreateBAL(Course _Course)
        {
            return _CourseDAL.TMS_Courses_CreateDAL(_Course);
        }

        /// <summary>
        /// TMSs the courses update bal.
        /// </summary>
        /// <param name="_Course">The course.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Courses_UpdateBAL(Course _Course)
        {
            return _CourseDAL.TMS_Courses_UpdateDAL(_Course);
        }
      public  int TMS_Courses_Dublicate_PrimaryNameBAL(Course _Course)
        {
            return _CourseDAL.TMS_Courses_Dublicate_PrimaryNameDAL(_Course);
        }

        /// <summary>
        /// TMSs the courses delete bal.
        /// </summary>
        /// <param name="_Course">The course.</param>
        /// <returns>System.Int32.</returns>
        public int TMS_Courses_DeleteBAL(Course _Course)
        {
            return _CourseDAL.TMS_Courses_DeleteDAL(_Course);
        }
        public int class_CheckBAL(Course _Course, long CompanyID)
        {
            return _CourseDAL.class_CheckDAL(_Course, CompanyID);
        }

        public int Session_CheckBAL(Sessions _Course, long CompanyID)
        {
            return _CourseDAL.Session_CheckBAL(_Course, CompanyID);
        }
       public IList<Sessions> TMS_SessionAttendance_GetAllBAL(Sessions _Course)
        {
            return _CourseDAL.TMS_SessionAttendance_GetAllDAL(_Course);
        }
        #region Course Coordinate
        public IList<Sessions> TMS_SessionAttendance_GetAllByIDBAL(int _Course)
        {
            
                return _CourseDAL.TMS_SessionAttendance_GetAllByIDDAL(_Course);
            
        }
        public IList<CourseCoordinatorMapping> TMS_CourseCoordinate_GetAllBAL(long CourseId)
        {
            return _CourseDAL.TMS_CourseCoordinator_GetAllDAL(CourseId);
        }

        
        public long TMS_CourseCoordinate_CreateBAL(CourseCoordinatorMapping _Coordinate, long CourseId)
        {
            return _CourseDAL.TMS_CourseCoordinate_CreateDAL(_Coordinate, CourseId);
        }

        public int TMS_CourseCoordinate_UpdateBAL(CourseCoordinatorMapping _Coordinate, long CourseId)
        {
            return _CourseDAL.TMS_CourseCoordinate_UpdateDAL(_Coordinate, CourseId);
        }

        public int TMS_CourseCoordinate_DeleteDAL(CourseCoordinatorMapping _Coordinate, long CourseId)
        {
            return _CourseDAL.TMS_CourseCoordinate_DeleteDAL(_Coordinate, CourseId);
        }

        #endregion

        #region Course Focus Area

        public IList<FocusAreas> TMS_FocusAreaDLL_GetAllBAL(string CurrentCulture, long CompanyID)
        {
            return _CourseDAL.TMS_FocusAreaDLL_GetAllDAL(CurrentCulture, CompanyID);
        }

        public IList<FocusAreas> TMS_CourseFocusArea_GetAllBAL(long CourseId)
        {
            return _CourseDAL.TMS_CourseFocusArea_GetAllDAL(CourseId);
        }

        public long TMS_CourseFocusArea_CreateBAL(FocusAreas _focusarea, long CourseId)
        {
            return _CourseDAL.TMS_CourseFocusArea_CreateDAL(_focusarea, CourseId);
        }

        public int TMS_CourseFocusArea_UpdateBAL(FocusAreas _focusarea, long CourseId)
        {
            return _CourseDAL.TMS_CourseFocusArea_UpdateDAL(_focusarea, CourseId);
        }
        public int TMS_CourseFocusArea_DublicationBAL(FocusAreas _focusarea, long CourseId)
        {
            return _CourseDAL.TMS_CourseFocusArea_DublicationDAL(_focusarea, CourseId);
        }
        public int TMS_CourseFocusArea_DeleteDAL(FocusAreas _focusarea, long CourseId)
        {
            return _CourseDAL.TMS_CourseFocusArea_DeleteDAL(_focusarea, CourseId);
        }

        #endregion


        //public DataSet GetCourseReportData(long ClassID, long CourseID)
        //{
        //    return _CourseDAL.GetCourseReportDataDAL(ClassID, CourseID);
        //}

    }
}