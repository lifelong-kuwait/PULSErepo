// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="PersonEducationDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.TMS.Persons.Education;
using TMS.Library.TMS.Education;
using TMS.Library.TMS.Persons.Education;

namespace TMS.DataObjects.TMS.Persons.Education
{
    /// <summary>
    /// Class PersonEducationDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.TMS.Persons.Education.IPersonEducationDAL" />
    public class PersonEducationDAL : DBGenerics, IPersonEducationDAL
    {
        #region "Degrees"

        public int Degree_DuplicationCheckDAL(PersonDegrees _Degrees)
        {
            return ExecuteScalarSPInt32("TMS_Degree_DuplicationCheck",
              ParamBuilder.Par("P_Title", _Degrees.P_Title)
                   );
        }
        /// <summary>
        /// Persons the education degrees get all by person identifier.
        /// </summary>
        /// <param name="_personId">The person identifier.</param>
        /// <returns>IList&lt;PersonDegrees&gt;.</returns>
        public IList<PersonDegrees> PersonEducationDegrees_GetAllByPersonID(string _personId)
        {
            return ExecuteList<PersonDegrees>("SELECT * FROM dbo.PersonEducationDegrees WHERE IsDeleted=0 AND IsActive=1 AND PersonID=" + _personId);
        }

        /// <summary>
        /// Persons the education degrees create dal.
        /// </summary>
        /// <param name="_Degrees">The degrees.</param>
        /// <returns>System.Int64.</returns>
        public long PersonEducationDegrees_CreateDAL(PersonDegrees _Degrees)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonEducationDegrees_Create", parameters,
                            ParamBuilder.Par("PersonID", _Degrees.PersonID),
                            ParamBuilder.Par("P_Title", _Degrees.P_Title),
                             ParamBuilder.Par("S_Title", _Degrees.S_Title),
                            ParamBuilder.Par("University", _Degrees.University),
                            ParamBuilder.Par("Result", _Degrees.Result),
                            ParamBuilder.Par("ResultTypeID", _Degrees.ResultTypeID),
                            ParamBuilder.Par("Session", _Degrees.Session),
                            ParamBuilder.Par("Duration", _Degrees.Duration),
                            ParamBuilder.Par("Major", _Degrees.Major),
                            ParamBuilder.Par("DegreeStatus", _Degrees.DegreeStatus),
                            ParamBuilder.Par("Description", _Degrees.Description),
                            ParamBuilder.Par("CreatedBy", _Degrees.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _Degrees.CreatedDate));
        }

        /// <summary>
        /// Persons the education degrees update dal.
        /// </summary>
        /// <param name="_Degrees">The degrees.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationDegrees_UpdateDAL(PersonDegrees _Degrees)
        {
            return ExecuteScalarInt32Sp("TMS_PersonEducationDegrees_Update",
                            ParamBuilder.Par("ID", _Degrees.ID),
                            ParamBuilder.Par("P_Title", _Degrees.P_Title),
                            ParamBuilder.Par("S_Title", _Degrees.S_Title),
                            ParamBuilder.Par("University", _Degrees.University),
                            ParamBuilder.Par("Result", _Degrees.Result),
                            ParamBuilder.Par("ResultTypeID", _Degrees.ResultTypeID),
                            ParamBuilder.Par("Session", _Degrees.Session),
                            ParamBuilder.Par("Duration", _Degrees.Duration),
                            ParamBuilder.Par("Major", _Degrees.Major),
                            ParamBuilder.Par("DegreeStatus", _Degrees.DegreeStatus),
                            ParamBuilder.Par("Description", _Degrees.Description),
                            ParamBuilder.Par("UpdatedBy", _Degrees.UpdatedBy),
                            ParamBuilder.Par("UpdatedDate", _Degrees.UpdatedDate));
        }

        /// <summary>
        /// Persons the education degrees delete dal.
        /// </summary>
        /// <param name="_Degrees">The degrees.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationDegrees_DeleteDAL(PersonDegrees _Degrees)
        {
            return ExecuteScalarInt32Sp("TMS_PersonEducationDegrees_Delete",
            ParamBuilder.Par("ID", _Degrees.ID),
             ParamBuilder.Par("UpdatedBy", _Degrees.UpdatedBy),
             ParamBuilder.Par("UpdatedDate", _Degrees.UpdatedDate));
        }

        #endregion "Degrees"

        #region"Certifications"

        /// <summary>
        /// Persons the education certifications get all by person identifier.
        /// </summary>
        /// <param name="_personId">The person identifier.</param>
        /// <returns>IList&lt;PersonCertifications&gt;.</returns>
        public IList<PersonCertifications> PersonEducationCertifications_GetAllByPersonID(string _personId)
        {
            return ExecuteListSp<PersonCertifications>("TMS_PersonEducationCertifications_GetbyId", ParamBuilder.Par("PersonID", _personId));
        }

        /// <summary>
        /// Persons the education certifications create dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int64.</returns>
        public long PersonEducationCertifications_CreateDAL(PersonCertifications _objEducation)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonEducationCertifications_Create", parameters,
                            ParamBuilder.Par("PersonID", _objEducation.PersonID),
                            ParamBuilder.Par("CertificationP_Name", _objEducation.CertificationP_Name),
                            ParamBuilder.Par("CertificationS_Name", _objEducation.CertificationS_Name),
                            ParamBuilder.Par("CertificationDurationType", _objEducation.CertificationDurationType),
                            ParamBuilder.Par("CertificationDuration", _objEducation.CertificationDuration),
                            ParamBuilder.Par("CertificationReferenceNo", _objEducation.CertificationReferenceNo),
                            ParamBuilder.Par("CompletionYear", _objEducation.CompletionYear),
                            ParamBuilder.Par("AwardingBody", _objEducation.AwardingBody),
                            ParamBuilder.Par("Institute", _objEducation.Institute),
                            ParamBuilder.Par("ValidityDuration", _objEducation.ValidityDuration),
                            ParamBuilder.Par("CreatedBy", _objEducation.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _objEducation.CreatedDate));
        }

        /// <summary>
        /// Persons the education certifications update dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationCertifications_UpdateDAL(PersonCertifications _objEducation)
        {
            return ExecuteScalarInt32Sp("TMS_PersonEducationCertifications_Update",
             ParamBuilder.Par("ID", _objEducation.ID),
                            ParamBuilder.Par("CertificationP_Name", _objEducation.CertificationP_Name),
                            ParamBuilder.Par("CertificationS_Name", _objEducation.CertificationS_Name),
                            ParamBuilder.Par("CertificationDurationType", _objEducation.CertificationDurationType),
                            ParamBuilder.Par("CertificationDuration", _objEducation.CertificationDuration),
                            ParamBuilder.Par("CertificationReferenceNo", _objEducation.CertificationReferenceNo),
                            ParamBuilder.Par("CompletionYear", _objEducation.CompletionYear),
                            ParamBuilder.Par("AwardingBody", _objEducation.AwardingBody),
                            ParamBuilder.Par("Institute", _objEducation.Institute),
                            ParamBuilder.Par("ValidityDuration", _objEducation.ValidityDuration),
                            ParamBuilder.Par("UpdatedBy", _objEducation.UpdatedBy),
                            ParamBuilder.Par("UpdatedDate", _objEducation.UpdatedDate));
        }

        /// <summary>
        /// Persons the education certifications delete dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationCertifications_DeleteDAL(PersonCertifications _objEducation)
        {
            return ExecuteScalarInt32Sp("TMS_PersonEducationCertifications_Delete",
                ParamBuilder.Par("ID", _objEducation.ID),
    ParamBuilder.Par("UpdatedBy", _objEducation.UpdatedBy),
    ParamBuilder.Par("UpdatedDate", _objEducation.UpdatedDate));
        }

        /// <summary>
        /// Persons the education certifications check duplication dal.
        /// </summary>
        /// <param name="_objEducation">The object education.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationCertifications_CheckDuplicationDAL(PersonCertifications _objEducation)
        {
            return ExecuteScalarInt32(string.Format("SELECT count(*) FROM dbo.PersonEducationCertifications WHERE (CertificationReferenceNo='{0}' or CertificationP_Name='{1}' ) AND IsDeleted=0", _objEducation.CertificationReferenceNo, _objEducation.CertificationP_Name));
        }

        #endregion

        #region"TrainingDelivered"

        /// <summary>
        /// Persons the education trainings get all by person identifier.
        /// </summary>
        /// <param name="_personId">The person identifier.</param>
        /// <param name="type">The type.</param>
        /// <returns>IList&lt;PersonTrainings&gt;.</returns>
        public IList<PersonTrainings> PersonEducationTrainings_GetAllByPersonID(string _personId, int type)
        {
            return ExecuteListSp<PersonTrainings>("TMS_PersonEducationTrainings_GetbyId", ParamBuilder.Par("PersonID", _personId), ParamBuilder.Par("TrainingType", type));
        }

        /// <summary>
        /// Persons the education trainings create dal.
        /// </summary>
        /// <param name="_objTrainings">The object trainings.</param>
        /// <returns>System.Int64.</returns>
        public long PersonEducationTrainings_CreateDAL(PersonTrainings _objTrainings)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonEducationTrainings_Create", parameters,
                            ParamBuilder.Par("PersonID", _objTrainings.PersonID),
                            ParamBuilder.Par("TrainingP_Title", _objTrainings.TrainingP_Title),
                            ParamBuilder.Par("TrainingS_Title", _objTrainings.TrainingS_Title),
                            ParamBuilder.Par("TrainingType", _objTrainings.TrainingType),
                            ParamBuilder.Par("DurationType", _objTrainings.DurationType),
                            ParamBuilder.Par("CourseDuration", _objTrainings.CourseDuration),
                            ParamBuilder.Par("CourseOutline", _objTrainings.CourseOutline),
                            ParamBuilder.Par("LearningObjective", _objTrainings.LearningObjective),
                            ParamBuilder.Par("ClientName", _objTrainings.ClientName),
                            ParamBuilder.Par("ClientReferencePersonsName", _objTrainings.ClientReferencePersonsName),
                            ParamBuilder.Par("ClientReferencePersonsTitle", _objTrainings.ClientReferencePersonsTitle),
                            ParamBuilder.Par("ClientReferencePersonsPhone", _objTrainings.ClientReferencePersonsPhone),
                            ParamBuilder.Par("ClientReferencePersonsEmail", _objTrainings.ClientReferencePersonsEmail),
                            ParamBuilder.Par("CreatedBy", _objTrainings.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _objTrainings.CreatedDate));
        }

        /// <summary>
        /// Persons the education trainings update dal.
        /// </summary>
        /// <param name="_objTrainings">The object trainings.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationTrainings_UpdateDAL(PersonTrainings _objTrainings)
        {
            return ExecuteScalarInt32Sp("TMS_PersonEducationTrainings_Update",
                ParamBuilder.Par("ID", _objTrainings.ID),
                        ParamBuilder.Par("TrainingP_Title", _objTrainings.TrainingP_Title),
                        ParamBuilder.Par("TrainingS_Title", _objTrainings.TrainingS_Title),
                        ParamBuilder.Par("TrainingType", _objTrainings.TrainingType),
                        ParamBuilder.Par("DurationType", _objTrainings.DurationType),
                        ParamBuilder.Par("CourseDuration", _objTrainings.CourseDuration),
                        ParamBuilder.Par("CourseOutline", _objTrainings.CourseOutline),
                        ParamBuilder.Par("LearningObjective", _objTrainings.LearningObjective),
                        ParamBuilder.Par("ClientName", _objTrainings.ClientName),
                        ParamBuilder.Par("ClientReferencePersonsName", _objTrainings.ClientReferencePersonsName),
                        ParamBuilder.Par("ClientReferencePersonsTitle", _objTrainings.ClientReferencePersonsTitle),
                        ParamBuilder.Par("ClientReferencePersonsPhone", _objTrainings.ClientReferencePersonsPhone),
                        ParamBuilder.Par("ClientReferencePersonsEmail", _objTrainings.ClientReferencePersonsEmail),
                        ParamBuilder.Par("UpdatedBy", _objTrainings.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _objTrainings.UpdatedDate));
        }

        /// <summary>
        /// Persons the education trainings delete dal.
        /// </summary>
        /// <param name="_objTrainings">The object trainings.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationTrainings_DeleteDAL(PersonTrainings _objTrainings)
        {
            return ExecuteScalarInt32Sp("TMS_PersonEducationTrainings_Delete",
                ParamBuilder.Par("ID", _objTrainings.ID),
    ParamBuilder.Par("UpdatedBy", _objTrainings.UpdatedBy),
    ParamBuilder.Par("UpdatedDate", _objTrainings.UpdatedDate));
        }

        #endregion

        #region"WorkExperiences"

        /// <summary>
        /// Persons the education work experiences get all by person identifier.
        /// </summary>
        /// <param name="_personId">The person identifier.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>IList&lt;WorkExperiences&gt;.</returns>
        public IList<WorkExperiences> PersonEducationWorkExperiences_GetAllByPersonID(string _personId, string culture)
        {
            return ExecuteListSp<WorkExperiences>("TMS_PersonEducationWorkExperiences_GetbyId", ParamBuilder.Par("PersonID", _personId), ParamBuilder.Par("Culture", culture));
        }

        /// <summary>
        /// Persons the education work experiences create dal.
        /// </summary>
        /// <param name="_objWorkExperiences">The object work experiences.</param>
        /// <returns>System.Int64.</returns>
        public long PersonEducationWorkExperiences_CreateDAL(WorkExperiences _objWorkExperiences)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonEducationWorkExperiences_Create", parameters,
                            ParamBuilder.Par("PersonID", _objWorkExperiences.PersonID),
                            ParamBuilder.Par("OrganizationID", _objWorkExperiences.OrganizationID),
                            ParamBuilder.Par("RelationType", _objWorkExperiences.RelationType),
                            ParamBuilder.Par("CompanyName", _objWorkExperiences.CompanyName),
                            ParamBuilder.Par("P_Title", _objWorkExperiences.P_Title),
                            ParamBuilder.Par("S_Title", _objWorkExperiences.S_Title),
                            ParamBuilder.Par("JobStatus", _objWorkExperiences.JobStatus),
                            ParamBuilder.Par("Location", _objWorkExperiences.Location),
                            ParamBuilder.Par("StartTimePeriod", _objWorkExperiences.StartTimePeriod),
                            ParamBuilder.Par("EndTimePeriod", _objWorkExperiences.EndTimePeriod),
                            ParamBuilder.Par("IsCurrent", _objWorkExperiences.IsCurrent),
                            ParamBuilder.Par("ReferenceName", _objWorkExperiences.ReferenceName),
                            ParamBuilder.Par("ReferenceEmail", _objWorkExperiences.ReferenceEmail),
                            ParamBuilder.Par("ReferencePhone", _objWorkExperiences.ReferencePhone),
                            ParamBuilder.Par("Description", _objWorkExperiences.Description),
                            ParamBuilder.Par("CreatedBy", _objWorkExperiences.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _objWorkExperiences.CreatedDate));
        }

        /// <summary>
        /// Persons the education work experiences update dal.
        /// </summary>
        /// <param name="_objWorkExperiences">The object work experiences.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationWorkExperiences_UpdateDAL(WorkExperiences _objWorkExperiences)
        {
            return ExecuteScalarInt32Sp("TMS_PersonEducationWorkExperiences_Update",
                                ParamBuilder.Par("ID", _objWorkExperiences.ID),
                                ParamBuilder.Par("OrganizationID", _objWorkExperiences.OrganizationID),
                                ParamBuilder.Par("CompanyName", _objWorkExperiences.CompanyName),
                                ParamBuilder.Par("RelationType", _objWorkExperiences.RelationType),
                                ParamBuilder.Par("P_Title", _objWorkExperiences.P_Title),
                                ParamBuilder.Par("S_Title", _objWorkExperiences.S_Title),
                                ParamBuilder.Par("JobStatus", _objWorkExperiences.JobStatus),
                                ParamBuilder.Par("Location", _objWorkExperiences.Location),
                                ParamBuilder.Par("StartTimePeriod", _objWorkExperiences.StartTimePeriod),
                                ParamBuilder.Par("EndTimePeriod", _objWorkExperiences.EndTimePeriod),
                                ParamBuilder.Par("IsCurrent", _objWorkExperiences.IsCurrent),
                                ParamBuilder.Par("ReferenceName", _objWorkExperiences.ReferenceName),
                                ParamBuilder.Par("ReferenceEmail", _objWorkExperiences.ReferenceEmail),
                                ParamBuilder.Par("ReferencePhone", _objWorkExperiences.ReferencePhone),
                                ParamBuilder.Par("Description", _objWorkExperiences.Description),
                                ParamBuilder.Par("UpdatedBy", _objWorkExperiences.UpdatedBy),
                                ParamBuilder.Par("UpdatedDate", _objWorkExperiences.UpdatedDate));
        }

        /// <summary>
        /// Persons the education work experiences delete dal.
        /// </summary>
        /// <param name="_objWorkExperiences">The object work experiences.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationWorkExperiences_DeleteDAL(WorkExperiences _objWorkExperiences)
        {
            return ExecuteScalarInt32Sp("TMS_PersonEducationWorkExperiences_Delete",
                             ParamBuilder.Par("ID", _objWorkExperiences.ID),
                                ParamBuilder.Par("UpdatedBy", _objWorkExperiences.UpdatedBy),
                                ParamBuilder.Par("UpdatedDate", _objWorkExperiences.UpdatedDate));
        }

        /// <summary>
        /// Persons the education work experiences duplication check dal.
        /// </summary>
        /// <param name="_objWorkExperiences">The object work experiences.</param>
        /// <param name="pid">The pid.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationWorkExperiences_DuplicationCheckDAL(WorkExperiences _objWorkExperiences, string pid)
        {
            return ExecuteScalarSPInt32("TMS_PersonEducationWorkExperiences_DuplicationCheck",
                         ParamBuilder.Par("PersonID", pid),
                            ParamBuilder.Par("StartDate", _objWorkExperiences.StartTimePeriod),
                            ParamBuilder.Par("EndDate", _objWorkExperiences.EndTimePeriod),
                            ParamBuilder.Par("JobStatus", _objWorkExperiences.JobStatus));
        }

        #endregion

        #region"Achievements"

        /// <summary>
        /// Persons the education achievements get all by person identifier.
        /// </summary>
        /// <param name="_personId">The person identifier.</param>
        /// <returns>IList&lt;PersonAchievements&gt;.</returns>
        public IList<PersonAchievements> PersonEducationAchievements_GetAllByPersonID(string _personId)
        {
            return ExecuteListSp<PersonAchievements>("TMS_PersonEducationAchievements_GetbyId", ParamBuilder.Par("PersonID", _personId));
        }

        /// <summary>
        /// Persons the education work achievements create dal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <returns>System.Int64.</returns>
        public long PersonEducationWorkAchievements_CreateDAL(PersonAchievements _objPersonAchievements)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonEducationAchievements_Create", parameters,
                            ParamBuilder.Par("PersonID", _objPersonAchievements.PersonID),
                            ParamBuilder.Par("P_Title", _objPersonAchievements.P_Title),
                            ParamBuilder.Par("S_Title", _objPersonAchievements.S_Title),
                            ParamBuilder.Par("Type", _objPersonAchievements.Type),
                            ParamBuilder.Par("AnnouncedDate", _objPersonAchievements.AnnouncedDate),
                            ParamBuilder.Par("Description", _objPersonAchievements.Description),
                            ParamBuilder.Par("CreatedBy", _objPersonAchievements.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _objPersonAchievements.CreatedDate));
        }

        /// <summary>
        /// Persons the education work achievements update dal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationWorkAchievements_UpdateDAL(PersonAchievements _objPersonAchievements)
        {
            return ExecuteScalarInt32Sp("TMS_PersonEducationAchievements_Update",
                            ParamBuilder.Par("ID", _objPersonAchievements.ID),
                            ParamBuilder.Par("P_Title", _objPersonAchievements.P_Title),
                            ParamBuilder.Par("S_Title", _objPersonAchievements.S_Title),
                            ParamBuilder.Par("Type", _objPersonAchievements.Type),
                            ParamBuilder.Par("AnnouncedDate", _objPersonAchievements.AnnouncedDate),
                            ParamBuilder.Par("Description", _objPersonAchievements.Description),
                            ParamBuilder.Par("UpdatedBy", _objPersonAchievements.UpdatedBy),
                            ParamBuilder.Par("UpdatedDate", _objPersonAchievements.UpdatedDate));
        }

        /// <summary>
        /// Persons the education work achievements delete dal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationWorkAchievements_DeleteDAL(PersonAchievements _objPersonAchievements)
        {
            return ExecuteScalarInt32Sp("TMS_PersonEducationAchievements_Delete",
                            ParamBuilder.Par("ID", _objPersonAchievements.ID),
                            ParamBuilder.Par("UpdatedBy", _objPersonAchievements.UpdatedBy),
                            ParamBuilder.Par("UpdatedDate", _objPersonAchievements.UpdatedDate));
        }

        /// <summary>
        /// Persons the education work achievements duplication check dal.
        /// </summary>
        /// <param name="_objPersonAchievements">The object person achievements.</param>
        /// <param name="pid">The pid.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationWorkAchievements_DuplicationCheckDAL(PersonAchievements _objPersonAchievements, string pid)
        {
            return ExecuteScalarSPInt32("TMS_PersonEducationAchievements_DuplicationCheck",
           ParamBuilder.Par("PersonID", pid),
           ParamBuilder.Par("Type", _objPersonAchievements.Type),
           ParamBuilder.Par("AnnouncedDate", _objPersonAchievements.AnnouncedDate));
        }

        #endregion

        #region"TrainingDelivered"

        /// <summary>
        /// Persons the education suggested trainings get all by person identifier.
        /// </summary>
        /// <param name="_personId">The person identifier.</param>
        /// <param name="type">The type.</param>
        /// <returns>IList&lt;PersonSuggestedTrainings&gt;.</returns>
        public IList<PersonSuggestedTrainings> PersonEducationSuggestedTrainings_GetAllByPersonID(string _personId, int type)
        {
            return ExecuteListSp<PersonSuggestedTrainings>("TMS_PersonEducationTrainings_GetbyId", ParamBuilder.Par("PersonID", _personId), ParamBuilder.Par("TrainingType", type));
        }

        /// <summary>
        /// Persons the education suggested trainings create dal.
        /// </summary>
        /// <param name="_objTrainings">The object trainings.</param>
        /// <returns>System.Int64.</returns>
        public long PersonEducationSuggestedTrainings_CreateDAL(PersonSuggestedTrainings _objTrainings)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonEducationTrainings_Create", parameters,
                        ParamBuilder.Par("PersonID", _objTrainings.PersonID),
                        ParamBuilder.Par("TrainingP_Title", _objTrainings.TrainingP_Title),
                        ParamBuilder.Par("TrainingS_Title", _objTrainings.TrainingS_Title),
                        ParamBuilder.Par("TrainingType", _objTrainings.TrainingType),
                        ParamBuilder.Par("DurationType", _objTrainings.DurationType),
                        ParamBuilder.Par("CourseDuration", _objTrainings.CourseDuration),
                        ParamBuilder.Par("CourseOutline", _objTrainings.CourseOutline),
                        ParamBuilder.Par("LearningObjective", _objTrainings.LearningObjective),
                        ParamBuilder.Par("ClientName", _objTrainings.ClientName),
                        ParamBuilder.Par("ClientReferencePersonsName", _objTrainings.ClientReferencePersonsName),
                        ParamBuilder.Par("ClientReferencePersonsTitle", _objTrainings.ClientReferencePersonsTitle),
                        ParamBuilder.Par("ClientReferencePersonsPhone", _objTrainings.ClientReferencePersonsPhone),
                        ParamBuilder.Par("ClientReferencePersonsEmail", _objTrainings.ClientReferencePersonsEmail),
                        ParamBuilder.Par("CreatedBy", _objTrainings.CreatedBy),
                        ParamBuilder.Par("CreatedDate", _objTrainings.CreatedDate));
        }

        /// <summary>
        /// Persons the education suggested trainings update dal.
        /// </summary>
        /// <param name="_objTrainings">The object trainings.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationSuggestedTrainings_UpdateDAL(PersonSuggestedTrainings _objTrainings)
        {
            return ExecuteScalarInt32Sp("TMS_PersonEducationTrainings_Update",
                    ParamBuilder.Par("ID", _objTrainings.ID),
                    ParamBuilder.Par("TrainingP_Title", _objTrainings.TrainingP_Title),
                    ParamBuilder.Par("TrainingS_Title", _objTrainings.TrainingS_Title),
                    ParamBuilder.Par("TrainingType", _objTrainings.TrainingType),
                    ParamBuilder.Par("DurationType", _objTrainings.DurationType),
                    ParamBuilder.Par("CourseDuration", _objTrainings.CourseDuration),
                    ParamBuilder.Par("CourseOutline", _objTrainings.CourseOutline),
                    ParamBuilder.Par("LearningObjective", _objTrainings.LearningObjective),
                    ParamBuilder.Par("ClientName", _objTrainings.ClientName),
                    ParamBuilder.Par("ClientReferencePersonsName", _objTrainings.ClientReferencePersonsName),
                    ParamBuilder.Par("ClientReferencePersonsTitle", _objTrainings.ClientReferencePersonsTitle),
                    ParamBuilder.Par("ClientReferencePersonsPhone", _objTrainings.ClientReferencePersonsPhone),
                    ParamBuilder.Par("ClientReferencePersonsEmail", _objTrainings.ClientReferencePersonsEmail),
                    ParamBuilder.Par("UpdatedBy", _objTrainings.UpdatedBy),
                    ParamBuilder.Par("UpdatedDate", _objTrainings.UpdatedDate));
        }

        /// <summary>
        /// Persons the education suggested trainings delete dal.
        /// </summary>
        /// <param name="_objTrainings">The object trainings.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationSuggestedTrainings_DeleteDAL(PersonSuggestedTrainings _objTrainings)
        {
            return ExecuteScalarInt32Sp("TMS_PersonEducationTrainings_Delete",
                ParamBuilder.Par("ID", _objTrainings.ID),
    ParamBuilder.Par("UpdatedBy", _objTrainings.UpdatedBy),
    ParamBuilder.Par("UpdatedDate", _objTrainings.UpdatedDate));
        }

        /// <summary>
        /// Persons the education suggested trainings duplication check dal.
        /// </summary>
        /// <param name="_objTrainings">The object trainings.</param>
        /// <param name="pid">The pid.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEducationSuggestedTrainings_DuplicationCheckDAL(PersonSuggestedTrainings _objTrainings, string pid)
        {
            return ExecuteScalarSPInt32("TMS_PersonEducationTrainings_DuplicationCheck",
                ParamBuilder.Par("PersonID", pid),
                  ParamBuilder.Par("TrainingP_Title", _objTrainings.TrainingP_Title),
     ParamBuilder.Par("TrainingType", _objTrainings.TrainingType));
        }

        #endregion
    }
}