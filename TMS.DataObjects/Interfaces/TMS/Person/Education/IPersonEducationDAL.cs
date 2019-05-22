// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="IPersonEducationDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Library.TMS.Education;
using TMS.Library.TMS.Persons.Education;

namespace TMS.DataObjects.Interfaces.TMS.Persons.Education
{
    /// <summary>
    /// Interface IPersonEducationDAL
    /// </summary>
    public interface IPersonEducationDAL
   {
        int Degree_DuplicationCheckDAL(PersonDegrees _Degrees);
        /// <summary>
        /// Persons the education degrees create dal.
        /// </summary>
        /// <param name="_Degrees">The degrees.</param>
        /// <returns>System.Int64.</returns>
        long PersonEducationDegrees_CreateDAL(PersonDegrees _Degrees);
        /// <summary>
        /// Persons the education degrees get all by person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonDegrees&gt;.</returns>
        IList<PersonDegrees> PersonEducationDegrees_GetAllByPersonID(string PersonId);
        /// <summary>
        /// Persons the education degrees delete dal.
        /// </summary>
        /// <param name="_Degrees">The degrees.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationDegrees_DeleteDAL(PersonDegrees _Degrees);
        /// <summary>
        /// Persons the education degrees update dal.
        /// </summary>
        /// <param name="_Degrees">The degrees.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationDegrees_UpdateDAL(PersonDegrees _Degrees);

        //Certifications
        /// <summary>
        /// Persons the education certifications get all by person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonCertifications&gt;.</returns>
        IList<PersonCertifications> PersonEducationCertifications_GetAllByPersonID(string PersonId);
        /// <summary>
        /// Persons the education certifications create dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int64.</returns>
        long PersonEducationCertifications_CreateDAL(PersonCertifications _objEducation);
        /// <summary>
        /// Persons the education certifications update dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationCertifications_UpdateDAL(PersonCertifications _objEducation);
        /// <summary>
        /// Persons the education certifications delete dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationCertifications_DeleteDAL(PersonCertifications _objEducation);
        /// <summary>
        /// Persons the education certifications check duplication dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationCertifications_CheckDuplicationDAL(PersonCertifications _objEducation);
        //Certifications

        //Trainings
        /// <summary>
        /// Persons the education trainings get all by person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <param name="type">The type.</param>
        /// <returns>IList&lt;PersonTrainings&gt;.</returns>
        IList<PersonTrainings> PersonEducationTrainings_GetAllByPersonID(string PersonId, int type);
        /// <summary>
        /// Persons the education trainings create dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int64.</returns>
        long PersonEducationTrainings_CreateDAL(PersonTrainings _objEducation);
        /// <summary>
        /// Persons the education trainings update dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationTrainings_UpdateDAL(PersonTrainings _objEducation);
        /// <summary>
        /// Persons the education trainings delete dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationTrainings_DeleteDAL(PersonTrainings _objEducation);
        //Trainings

        //WorkExperiences
        /// <summary>
        /// Persons the education work experiences get all by person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;WorkExperiences&gt;.</returns>
        IList<WorkExperiences> PersonEducationWorkExperiences_GetAllByPersonID(string PersonId, string culture);
        /// <summary>
        /// Persons the education work experiences create dal.
        /// </summary>
        /// <param name="_objWorkExperiences">The object work experiences.</param>
        /// <returns>System.Int64.</returns>
        long PersonEducationWorkExperiences_CreateDAL(WorkExperiences _objWorkExperiences);
        /// <summary>
        /// Persons the education work experiences update dal.
        /// </summary>
        /// <param name="_objWorkExperiences">The object work experiences.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationWorkExperiences_UpdateDAL(WorkExperiences _objWorkExperiences);
        /// <summary>
        /// Persons the education work experiences delete dal.
        /// </summary>
        /// <param name="_objWorkExperiences">The object work experiences.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationWorkExperiences_DeleteDAL(WorkExperiences _objWorkExperiences);
        /// <summary>
        /// Persons the education work experiences duplication check dal.
        /// </summary>
        /// <param name="_objWorkExperiences">The object work experiences.</param>
        /// <param name="pid">The pid.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationWorkExperiences_DuplicationCheckDAL(WorkExperiences _objWorkExperiences, string pid);
        //WorkExperiences

        //PersonAchievements
        /// <summary>
        /// Persons the education achievements get all by person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonAchievements&gt;.</returns>
        IList<PersonAchievements> PersonEducationAchievements_GetAllByPersonID(string PersonId);
        /// <summary>
        /// Persons the education work achievements create dal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <returns>System.Int64.</returns>
        long PersonEducationWorkAchievements_CreateDAL(PersonAchievements _objPersonAchievements);
        /// <summary>
        /// Persons the education work achievements update dal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationWorkAchievements_UpdateDAL(PersonAchievements _objPersonAchievements);
        /// <summary>
        /// Persons the education work achievements delete dal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationWorkAchievements_DeleteDAL(PersonAchievements _objPersonAchievements);
        /// <summary>
        /// Persons the education work achievements duplication check dal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <param name="pid">The pid.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationWorkAchievements_DuplicationCheckDAL(PersonAchievements _objPersonAchievements, string pid);
        //PersonAchievements

        //Trainings
        /// <summary>
        /// Persons the education suggested trainings get all by person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <param name="type">The type.</param>
        /// <returns>IList&lt;PersonSuggestedTrainings&gt;.</returns>
        IList<PersonSuggestedTrainings> PersonEducationSuggestedTrainings_GetAllByPersonID(string PersonId, int type);
        /// <summary>
        /// Persons the education suggested trainings create dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int64.</returns>
        long PersonEducationSuggestedTrainings_CreateDAL(PersonSuggestedTrainings _objEducation);
        /// <summary>
        /// Persons the education suggested trainings update dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationSuggestedTrainings_UpdateDAL(PersonSuggestedTrainings _objEducation);
        /// <summary>
        /// Persons the education suggested trainings delete dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationSuggestedTrainings_DeleteDAL(PersonSuggestedTrainings _objEducation);
        /// <summary>
        /// Persons the education suggested trainings duplication check dal.
        /// </summary>
        /// <param name="_objTrainings">The object trainings.</param>
        /// <param name="pid">The pid.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationSuggestedTrainings_DuplicationCheckDAL(PersonSuggestedTrainings _objTrainings, string pid   );
       //Trainings

   }
}
