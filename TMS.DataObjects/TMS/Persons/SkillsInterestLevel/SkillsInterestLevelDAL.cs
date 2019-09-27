// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="SkillsInterestLevelDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces.TMS.SkillsInterestLevel;
using TMS.Library;
using TMS.Library.Entities.Common.Configuration;
using TMS.Library.TMS.Persons.Skills;
using TMS.Library.TMS.Skills;

namespace TMS.DataObjects.TMS.SkillsInterestLevel
{
    /// <summary>
    /// Class SkillsInterestLevelDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.TMS.SkillsInterestLevel.ISkillsInterestLevelDAL" />
    public class SkillsInterestLevelDAL : DBGenerics, ISkillsInterestLevelDAL
    {
        #region"Skills&Intrest"

        /// <summary>
        /// Persons the skill getby person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonSkill&gt;.</returns>
        public IList<PersonSkill> PersonSkill_GetbyPersonId(long PersonId, long CompanyID)
        {
            return ExecuteListSp<PersonSkill>("TMS_PersonSkillInterest_GetbyPersonID", ParamBuilder.Par("PersonID", PersonId), ParamBuilder.Par("OrganizationID", CompanyID));
        }

        /// <summary>
        /// Persons the skill getby person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonSkill&gt;.</returns>
        public IList<FocusAreas> PersonSkill_GetbyfocusId(long cid)
        {
            return ExecuteListSp<FocusAreas>("FocusAreas_GetAllbyfocusID", ParamBuilder.Par("ID", cid));
        }

        /// <summary>
        /// Persons the skill getby person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonSkill&gt;.</returns>
        public IList<FocusAreas> PersonFocusAreaSkill_GetbyPersonId(string CompanyId)
        {
            var parameters = new[] { ParamBuilder.Par("Type", PersonSKillInterest.PersonSKillInterest_Person_Skills),
                ParamBuilder.Par("CompanyId", CompanyId)
            };
            return ExecuteListSp<FocusAreas>("FocusAreas_GetAllbyID", parameters);
        }

        /// <summary>
        /// Persons the interest getby person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonInterest&gt;.</returns>
        public IList<PersonInterest> PersonInterest_GetbyPersonId(long PersonId)
        {
            return ExecuteListSp<PersonInterest>("TMS_PersonSkillInterest_GetbyPersonID", ParamBuilder.Par("PersonID", PersonId), ParamBuilder.Par("Type", PersonSKillInterest.PersonSKillInterest_Field_Of_Interest));
        }

        /// <summary>
        /// Persons the skills interest create dal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int64.</returns>
        public long PersonSkillsInterest_CreateDAL(PersonSkillsInterest _objPersonSkillsInterest)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonSkillInterest_Create", parameters,
                                    ParamBuilder.Par("OrganizationID", _objPersonSkillsInterest.OrganizationID),
                                     ParamBuilder.Par("PersonID", _objPersonSkillsInterest.PersonID),
                                    ParamBuilder.Par("Title", _objPersonSkillsInterest.Title),
                                    ParamBuilder.Par("Type", _objPersonSkillsInterest.Type),
                                    ParamBuilder.Par("Description", _objPersonSkillsInterest.Description),
                                    ParamBuilder.Par("CreatedBy", _objPersonSkillsInterest.CreatedBy),
                                    ParamBuilder.Par("CreatedDate", _objPersonSkillsInterest.CreatedDate));
        }

        /// <summary>
        /// Persons the skills interest create dal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int64.</returns>
        public long PersonSkillsInterest_CreateDAL(long PersonId, long OrganizationID,string title,long Type,string description,long user,DateTime date )
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonSkillInterest_Create", parameters,
                                    ParamBuilder.Par("PersonID", PersonId),
                                    ParamBuilder.Par("OrganizationID", OrganizationID),
                                    ParamBuilder.Par("Title", title),
                                    ParamBuilder.Par("Type", Type),
                                    ParamBuilder.Par("Description", description),
                                    ParamBuilder.Par("CreatedBy", user),
                                    ParamBuilder.Par("CreatedDate", date));
                                    
        }

        /// <summary>
        /// Persons the skills interest update dal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int32.</returns>
        public int PersonSkillsInterest_UpdateDAL(PersonSkillsInterest _objPersonSkillsInterest)
        {
            return ExecuteScalarInt32Sp("TMS_PersonSkillInterest_Update",
                                    ParamBuilder.Par("ID", _objPersonSkillsInterest.ID),
                                    ParamBuilder.Par("Title", _objPersonSkillsInterest.Title),
                                    ParamBuilder.Par("Description", _objPersonSkillsInterest.Description),
                                    ParamBuilder.Par("UpdatedBy", _objPersonSkillsInterest.UpdatedBy),
                                    ParamBuilder.Par("UpdatedDate", _objPersonSkillsInterest.UpdatedDate));
        }

        /// <summary>
        /// Persons the skills interest delete dal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int32.</returns>
        public int PersonSkillsInterest_DeleteDAL(PersonSkillsInterest _objPersonSkillsInterest)
        {
            return ExecuteScalarInt32Sp("TMS_PersonSkillInterest_Delete",
                                    ParamBuilder.Par("ID", _objPersonSkillsInterest.ID),
                                    ParamBuilder.Par("UpdatedBy", _objPersonSkillsInterest.UpdatedBy),
                                    ParamBuilder.Par("UpdatedDate", _objPersonSkillsInterest.UpdatedDate));
        }

        /// <summary>
        /// Persons the skills interest duplication check dal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int32.</returns>
        public int PersonSkillsInterest_DuplicationCheckDAL(PersonSkillsInterest _objPersonSkillsInterest)
        {
            return ExecuteScalarSPInt32("TMS_PersonSkillInterest_DuplicationCheck",
                                    ParamBuilder.Par("PersonID", _objPersonSkillsInterest.PersonID),
                                    ParamBuilder.Par("Title", _objPersonSkillsInterest.Title),
                                    ParamBuilder.Par("Type", _objPersonSkillsInterest.Type));
        }
        /// <summary>
        /// Persons the skills interest duplication check dal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int32.</returns>
        public int PersonSkills_DuplicationCheckDAL(long cid, string _skill, long value)
        {
            return ExecuteScalarSPInt32("TMS_PersonSkillInterest_DuplicationCheck",
                                    ParamBuilder.Par("PersonID", cid),
                                    ParamBuilder.Par("Title", _skill),
                                    ParamBuilder.Par("Type", value));
        }

        #endregion
        #region "PersonLevel"
        /// <summary>
        /// Persons the levels getby person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>PersonLevels.</returns>
        public PersonLevels PersonLevels_GetbyPersonId(long PersonId)
        {
            return ExecuteSinglewithSP<PersonLevels>("TMS_PersonLevels_GetbyPersonID", ParamBuilder.Par("PersonID", PersonId));
        }


        /// <summary>
        /// Persons the levels create dal.
        /// </summary>
        /// <param name="_objPersonLevels">The object person levels.</param>
        /// <returns>System.Int64.</returns>
        public long PersonLevels_CreateDAL(PersonLevels _objPersonLevels)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonLevels_Create", parameters,
                                    ParamBuilder.Par("PersonID", _objPersonLevels.PersonID),
                                    ParamBuilder.Par("Name", _objPersonLevels.Name),
                                    ParamBuilder.Par("Description", _objPersonLevels.Description),
                                    ParamBuilder.Par("CreatedBy", _objPersonLevels.CreatedBy),
                                    ParamBuilder.Par("CreatedDate", _objPersonLevels.CreatedDate));
        }

        /// <summary>
        /// Persons the levels update dal.
        /// </summary>
        /// <param name="_objPersonLevels">The object person levels.</param>
        /// <returns>System.Int32.</returns>
        public int PersonLevels_UpdateDAL(PersonLevels _objPersonLevels)
        {
            return ExecuteScalarInt32Sp("TMS_PersonLevels_Update",
                                    ParamBuilder.Par("ID", _objPersonLevels.ID),
                                    ParamBuilder.Par("Name", _objPersonLevels.Name),
                                    ParamBuilder.Par("Description", _objPersonLevels.Description),
                                    ParamBuilder.Par("UpdatedBy", _objPersonLevels.UpdatedBy),
                                    ParamBuilder.Par("UpdatedDate", _objPersonLevels.UpdatedDate));
        }
        #endregion
    }
}