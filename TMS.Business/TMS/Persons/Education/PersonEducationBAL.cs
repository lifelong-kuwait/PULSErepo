// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="PersonEducationBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Business.Interfaces.TMS.Persons.Education;
using TMS.DataObjects.Interfaces.TMS.Persons.Education;
using TMS.DataObjects.TMS.Persons.Education;
using TMS.Library.TMS.Education;
using TMS.Library.TMS.Persons.Education;

namespace TMS.Business.TMS.Persons.Education
{
    /// <summary>
    /// Class PersonEducationBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.TMS.Persons.Education.IPersonEducationBAL" />
    public class PersonEducationBAL :  IPersonEducationBAL
    {
        private readonly IPersonEducationDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonEducationBAL"/> class.
        /// </summary>
        public PersonEducationBAL()
        {
            DAL = new PersonEducationDAL();
        }

        public int Degree_DuplicationCheckBAL(PersonDegrees _Degrees)
        {
            return DAL.Degree_DuplicationCheckDAL(_Degrees);
        }

        /// <summary>
        /// Persons the education degrees create bal.
        /// </summary>
        /// <param name="_Degrees">The degrees.</param>
        /// <returns>System.Int64.</returns>
        public long PersonEducationDegrees_CreateBAL(PersonDegrees _Degrees)
        {
            return DAL.PersonEducationDegrees_CreateDAL(_Degrees);
        }

        /// <summary>
        /// Persons the education degrees get all by person idbal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonDegrees&gt;.</returns>
        public IList<PersonDegrees> PersonEducationDegrees_GetAllByPersonIDBAL(string PersonId)
        {
            return DAL.PersonEducationDegrees_GetAllByPersonID(PersonId);
        }

        /// <summary>
        /// Persons the education degrees update bal.
        /// </summary>
        /// <param name="_Degrees">The degrees.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationDegrees_UpdateBAL(PersonDegrees _Degrees)
        {
            return DAL.PersonEducationDegrees_UpdateDAL(_Degrees);
        }

        /// <summary>
        /// Persons the education degrees delete bal.
        /// </summary>
        /// <param name="_Degrees">The degrees.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationDegrees_DeleteBAL(PersonDegrees _Degrees)
        {
            return DAL.PersonEducationDegrees_DeleteDAL(_Degrees);
        }

        //certifications
        /// <summary>
        /// Persons the education certifications create bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int64.</returns>
        public long PersonEducationCertifications_CreateBAL(PersonCertifications _objEducation)
        {
            return DAL.PersonEducationCertifications_CreateDAL(_objEducation);
        }

        /// <summary>
        /// Persons the education certifications get all by person idbal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonCertifications&gt;.</returns>
        public IList<PersonCertifications> PersonEducationCertifications_GetAllByPersonIDBAL(string PersonId)
        {
            return DAL.PersonEducationCertifications_GetAllByPersonID(PersonId);
        }

        /// <summary>
        /// Persons the education certifications update bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationCertifications_UpdateBAL(PersonCertifications _objEducation)
        {
            return DAL.PersonEducationCertifications_UpdateDAL(_objEducation);
        }

        /// <summary>
        /// Persons the education certifications delete bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationCertifications_DeleteBAL(PersonCertifications _objEducation)
        {
            return DAL.PersonEducationCertifications_DeleteDAL(_objEducation);
        }

        /// <summary>
        /// Persons the education certifications check duplication bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationCertifications_CheckDuplicationBAL(PersonCertifications _objEducation)
        {
            return DAL.PersonEducationCertifications_CheckDuplicationDAL(_objEducation);
        }

        //certifications
        //Trainings
        /// <summary>
        /// Persons the education trainings create bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int64.</returns>
        public long PersonEducationTrainings_CreateBAL(PersonTrainings _objEducation)
        {
            return DAL.PersonEducationTrainings_CreateDAL(_objEducation);
        }

        /// <summary>
        /// Persons the education trainings get all by person idbal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <param name="type">The type.</param>
        /// <returns>IList&lt;PersonTrainings&gt;.</returns>
        public IList<PersonTrainings> PersonEducationTrainings_GetAllByPersonIDBAL(string PersonId,int type)
        {
            return DAL.PersonEducationTrainings_GetAllByPersonID(PersonId,type);
        }

        /// <summary>
        /// Persons the education trainings update bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationTrainings_UpdateBAL(PersonTrainings _objEducation)
        {
            return DAL.PersonEducationTrainings_UpdateDAL(_objEducation);
        }

        /// <summary>
        /// Persons the education trainings delete bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationTrainings_DeleteBAL(PersonTrainings _objEducation)
        {
            return DAL.PersonEducationTrainings_DeleteDAL(_objEducation);
        }

        //Trainings

        //WorkExperiences
        /// <summary>
        /// Persons the education work experiences get all by person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;WorkExperiences&gt;.</returns>
        public IList<WorkExperiences> PersonEducationWorkExperiences_GetAllByPersonID(string PersonId, string culture)
        {
            return DAL.PersonEducationWorkExperiences_GetAllByPersonID(PersonId, culture);
        }
        /// <summary>
        /// Persons the education work experiences create dal.
        /// </summary>
        /// <param name="_objWorkExperiences">The object work experiences.</param>
        /// <returns>System.Int64.</returns>
        public long PersonEducationWorkExperiences_CreateDAL(WorkExperiences _objWorkExperiences)
        {
            return DAL.PersonEducationWorkExperiences_CreateDAL(_objWorkExperiences);
        }



        /// <summary>
        /// Persons the education work experiences update dal.
        /// </summary>
        /// <param name="_objWorkExperiences">The object work experiences.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationWorkExperiences_UpdateDAL(WorkExperiences _objWorkExperiences)
        {
            return DAL.PersonEducationWorkExperiences_UpdateDAL(_objWorkExperiences);
        }

        /// <summary>
        /// Persons the education work experiences delete dal.
        /// </summary>
        /// <param name="_objWorkExperiences">The object work experiences.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationWorkExperiences_DeleteDAL(WorkExperiences _objWorkExperiences)
        {
            return DAL.PersonEducationWorkExperiences_DeleteDAL(_objWorkExperiences);
        }

        /// <summary>
        /// Persons the education work experiences duplication check bal.
        /// </summary>
        /// <param name="_objWorkExperiences">The object work experiences.</param>
        /// <param name="pid">The pid.</param>
        /// <returns>System.Int32.</returns>
        public int  PersonEducationWorkExperiences_DuplicationCheckBAL(WorkExperiences _objWorkExperiences,string pid){
            return DAL.PersonEducationWorkExperiences_DuplicationCheckDAL(_objWorkExperiences,pid);
        }

        //WorkExperiences

        //PersonAchievements
        /// <summary>
        /// Persons the education achievements get all by person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonAchievements&gt;.</returns>
        public IList<PersonAchievements> PersonEducationAchievements_GetAllByPersonID(string PersonId)
        {
            return DAL.PersonEducationAchievements_GetAllByPersonID(PersonId);
        }
        /// <summary>
        /// Persons the education work achievements create bal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <returns>System.Int64.</returns>
        public long PersonEducationWorkAchievements_CreateBAL(PersonAchievements _objPersonAchievements)
        {
            return DAL.PersonEducationWorkAchievements_CreateDAL(_objPersonAchievements);
        }
        /// <summary>
        /// Persons the education work achievements update bal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationWorkAchievements_UpdateBAL(PersonAchievements _objPersonAchievements)
        {
            return DAL.PersonEducationWorkAchievements_UpdateDAL(_objPersonAchievements);
        }

        /// <summary>
        /// Persons the education work achievements delete bal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationWorkAchievements_DeleteBAL(PersonAchievements _objPersonAchievements)
        {
            return DAL.PersonEducationWorkAchievements_DeleteDAL(_objPersonAchievements);
        }

        /// <summary>
        /// Persons the education work achievements duplication check bal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <param name="pid">The pid.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationWorkAchievements_DuplicationCheckBAL(PersonAchievements _objPersonAchievements, string pid)
        {
            return DAL.PersonEducationWorkAchievements_DuplicationCheckDAL(_objPersonAchievements, pid);
        }

        //PersonAchievements

        //Trainings
        /// <summary>
        /// Persons the education suggested trainings create bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int64.</returns>
        public long PersonEducationSuggestedTrainings_CreateBAL(PersonSuggestedTrainings _objEducation)
        {
            return DAL.PersonEducationSuggestedTrainings_CreateDAL(_objEducation);
        }

        /// <summary>
        /// Persons the education suggested trainings get all by person idbal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <param name="type">The type.</param>
        /// <returns>IList&lt;PersonSuggestedTrainings&gt;.</returns>
        public IList<PersonSuggestedTrainings> PersonEducationSuggestedTrainings_GetAllByPersonIDBAL(string PersonId, int type)
        {
            return DAL.PersonEducationSuggestedTrainings_GetAllByPersonID(PersonId, type);
        }

        /// <summary>
        /// Persons the education suggested trainings update bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationSuggestedTrainings_UpdateBAL(PersonSuggestedTrainings _objEducation)
        {
            return DAL.PersonEducationSuggestedTrainings_UpdateDAL(_objEducation);
        }

        /// <summary>
        /// Persons the education suggested trainings delete bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationSuggestedTrainings_DeleteBAL(PersonSuggestedTrainings _objEducation)
        {
            return DAL.PersonEducationSuggestedTrainings_DeleteDAL(_objEducation);
        }
        /// <summary>
        /// Persons the education suggested trainings duplication check bal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <param name="pid">The pid.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationSuggestedTrainings_DuplicationCheckBAL(PersonSuggestedTrainings _objEducation, string pid)
        {
            return DAL.PersonEducationSuggestedTrainings_DuplicationCheckDAL(_objEducation,pid);
        }


        //Trainings
    }
}