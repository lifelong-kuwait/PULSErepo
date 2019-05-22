// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 11-20-2016
// ***********************************************************************
// <copyright file="ISkillsInterestLevelDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Entities.Common.Configuration;
using TMS.Library.TMS.Persons.Skills;
using TMS.Library.TMS.Skills;

namespace TMS.DataObjects.Interfaces.TMS.SkillsInterestLevel
{
    /// <summary>
    /// Interface ISkillsInterestLevelDAL
    /// </summary>
    public interface ISkillsInterestLevelDAL
    {
        #region"Skills&Intrest"

        /// <summary>
        /// Persons the skill getby person identifier.
        /// </summary>
        /// <param name="PersonId">The PersonId.</param>
        /// <returns>IList&lt;PersonSkill&gt;.</returns>
        IList<PersonSkill> PersonSkill_GetbyPersonId(long PersonId, long CompanyID);

        /// <summary>
        /// Persons the skill getby person identifier.
        /// </summary>
        /// <param name="PersonId">The PersonId.</param>
        /// <returns>IList&lt;PersonSkill&gt;.</returns>
        IList<FocusAreas> PersonSkill_GetbyfocusId(long cid);

        /// <summary>
        /// Persons the skill getby person identifier.
        /// </summary>
        /// <param name="PersonId">The PersonId.</param>
        /// <returns>IList&lt;PersonSkill&gt;.</returns>
        IList<FocusAreas> PersonFocusAreaSkill_GetbyPersonId();

        /// <summary>
        /// Persons the interest getby person identifier.
        /// </summary>
        /// <param name="PersonId">The PersonId.</param>
        /// <returns>IList&lt;PersonInterest&gt;.</returns>
        IList<PersonInterest> PersonInterest_GetbyPersonId(long PersonId);

        /// <summary>
        /// Persons the skills interest create dal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int64.</returns>
        long PersonSkillsInterest_CreateDAL(PersonSkillsInterest _objPersonSkillsInterest);

        /// <summary>
        /// Persons the skills interest create dal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int64.</returns>
        long PersonSkillsInterest_CreateDAL(string PersonIds,long user,string date,long cid, long OrganizationID);

        /// <summary>
        /// Persons the skills interest update dal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int32.</returns>
        int PersonSkillsInterest_UpdateDAL(PersonSkillsInterest _objPersonSkillsInterest);

        /// <summary>
        /// Persons the skills interest delete dal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int32.</returns>
        int PersonSkillsInterest_DeleteDAL(PersonSkillsInterest _objPersonSkillsInterest);

        /// <summary>
        /// Persons the skills interest duplication check dal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int32.</returns>
        int PersonSkillsInterest_DuplicationCheckDAL(PersonSkillsInterest _objPersonSkillsInterest);

        #endregion

        #region "Person Levels"

        /// <summary>
        /// Persons the levels getby person identifier.
        /// </summary>
        /// <param name="PersonId">The PersonId.</param>
        /// <returns>PersonLevels.</returns>
        PersonLevels PersonLevels_GetbyPersonId(long PersonId);

        /// <summary>
        /// Persons the levels create dal.
        /// </summary>
        /// <param name="_objPersonLevels">The object person levels.</param>
        /// <returns>System.Int64.</returns>
        long PersonLevels_CreateDAL(PersonLevels _objPersonLevels);

        /// <summary>
        /// Persons the levels update dal.
        /// </summary>
        /// <param name="_objPersonLevels">The object person levels.</param>
        /// <returns>System.Int32.</returns>
        int PersonLevels_UpdateDAL(PersonLevels _objPersonLevels);

        #endregion
    }
}