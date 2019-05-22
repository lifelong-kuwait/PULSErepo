// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="IPersonEducationBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.TMS.Education;
using TMS.Library.TMS.Persons.Education;

namespace TMS.Business.Interfaces.TMS.Persons.Education
{
    /// <summary>
    /// Interface IPersonEducationBAL
    /// </summary>
    public interface IPersonEducationBAL
    {
        int Degree_DuplicationCheckBAL(PersonDegrees _Degrees);
        /// <summary>
        /// Persons the education degrees create bal.
        /// </summary>
        /// <param name="_Degrees">The degrees.</param>
        /// <returns>System.Int64.</returns>
        long PersonEducationDegrees_CreateBAL(PersonDegrees _Degrees);

        /// <summary>
        /// Persons the education degrees get all by person idbal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonDegrees&gt;.</returns>
        IList<PersonDegrees> PersonEducationDegrees_GetAllByPersonIDBAL(string PersonId);

        /// <summary>
        /// Persons the education degrees update bal.
        /// </summary>
        /// <param name="_Degrees">The degrees.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationDegrees_UpdateBAL(PersonDegrees _Degrees);

        /// <summary>
        /// Persons the education degrees delete bal.
        /// </summary>
        /// <param name="_Degrees">The degrees.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationDegrees_DeleteBAL(PersonDegrees _Degrees);

        //certifications
        /// <summary>
        /// Persons the education certifications create bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int64.</returns>
        long PersonEducationCertifications_CreateBAL(PersonCertifications _objEducation);
        /// <summary>
        /// Persons the education certifications get all by person idbal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonCertifications&gt;.</returns>
        IList<PersonCertifications> PersonEducationCertifications_GetAllByPersonIDBAL(string PersonId);
        /// <summary>
        /// Persons the education certifications update bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationCertifications_UpdateBAL(PersonCertifications _objEducation);
        /// <summary>
        /// Persons the education certifications delete bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationCertifications_DeleteBAL(PersonCertifications _objEducation);
        /// <summary>
        /// Persons the education certifications check duplication bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationCertifications_CheckDuplicationBAL(PersonCertifications _objEducation);
        //certifications
        //Trainings
        /// <summary>
        /// Persons the education trainings create bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int64.</returns>
        long PersonEducationTrainings_CreateBAL(PersonTrainings _objEducation);
        /// <summary>
        /// Persons the education trainings get all by person idbal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <param name="type">The type.</param>
        /// <returns>IList&lt;PersonTrainings&gt;.</returns>
        IList<PersonTrainings> PersonEducationTrainings_GetAllByPersonIDBAL(string PersonId,int type);
        /// <summary>
        /// Persons the education trainings update bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationTrainings_UpdateBAL(PersonTrainings _objEducation);
        /// <summary>
        /// Persons the education trainings delete bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationTrainings_DeleteBAL(PersonTrainings _objEducation);
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
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int64.</returns>
        long PersonEducationWorkExperiences_CreateDAL(WorkExperiences _objEducation);
        /// <summary>
        /// Persons the education work experiences update dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationWorkExperiences_UpdateDAL(WorkExperiences _objEducation);
        /// <summary>
        /// Persons the education work experiences delete dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationWorkExperiences_DeleteDAL(WorkExperiences _objEducation);
        /// <summary>
        /// Persons the education work experiences duplication check bal.
        /// </summary>
        /// <param name="_objWorkExperiences">The object work experiences.</param>
        /// <param name="pid">The pid.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationWorkExperiences_DuplicationCheckBAL(WorkExperiences _objWorkExperiences,string pid);
        //WorkExperiences


        //WorkExperiences
        /// <summary>
        /// Persons the education achievements get all by person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonAchievements&gt;.</returns>
        IList<PersonAchievements> PersonEducationAchievements_GetAllByPersonID(string PersonId);
        /// <summary>
        /// Persons the education work achievements create bal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <returns>System.Int64.</returns>
        long PersonEducationWorkAchievements_CreateBAL(PersonAchievements _objPersonAchievements);
        /// <summary>
        /// Persons the education work achievements update bal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationWorkAchievements_UpdateBAL(PersonAchievements _objPersonAchievements);
        /// <summary>
        /// Persons the education work achievements delete bal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationWorkAchievements_DeleteBAL(PersonAchievements _objPersonAchievements);
        /// <summary>
        /// Persons the education work achievements duplication check bal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <param name="pid">The pid.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationWorkAchievements_DuplicationCheckBAL(PersonAchievements _objPersonAchievements, string pid);
        //WorkExperiences


        //Trainings
        /// <summary>
        /// Persons the education suggested trainings get all by person idbal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <param name="type">The type.</param>
        /// <returns>IList&lt;PersonSuggestedTrainings&gt;.</returns>
        IList<PersonSuggestedTrainings> PersonEducationSuggestedTrainings_GetAllByPersonIDBAL(string PersonId, int type);
        /// <summary>
        /// Persons the education suggested trainings create bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int64.</returns>
        long PersonEducationSuggestedTrainings_CreateBAL(PersonSuggestedTrainings _objEducation);
        /// <summary>
        /// Persons the education suggested trainings update bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationSuggestedTrainings_UpdateBAL(PersonSuggestedTrainings _objEducation);
        /// <summary>
        /// Persons the education suggested trainings delete bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationSuggestedTrainings_DeleteBAL(PersonSuggestedTrainings _objEducation);
        /// <summary>
        /// Persons the education suggested trainings duplication check bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <param name="pid">The pid.</param>
        /// <returns>System.Int32.</returns>
        int PersonEducationSuggestedTrainings_DuplicationCheckBAL(PersonSuggestedTrainings _objEducation, string pid);
        //Trainings
    }
}