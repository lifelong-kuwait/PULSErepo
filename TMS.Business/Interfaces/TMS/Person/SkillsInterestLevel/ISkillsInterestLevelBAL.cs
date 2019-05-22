// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="ISkillsInterestLevelBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Entities.Common.Configuration;
using TMS.Library.TMS.Persons.Skills;
using TMS.Library.TMS.Skills;

namespace TMS.Business.Interfaces.TMS.SkillsInterestLevel
{
    /// <summary>
    /// Interface ISkillsInterestLevelBAL
    /// </summary>
    public interface ISkillsInterestLevelBAL
    {
        #region"SkillsInterest"

        /// <summary>
        /// Persons the skill getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonSkill&gt;.</returns>
        IList<PersonSkill> PersonSkill_GetbyPersonIdBAL(long PersonId,long CompanyID);

        /// <summary>
        /// Persons the skill getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonSkill&gt;.</returns>
        IList<FocusAreas> PersonSkill_GetbyfocusIdBAL(long cid);

        /// <summary>
        /// Persons the skill getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonSkill&gt;.</returns>
        IList<FocusAreas> PersonFocusAreaSkill_GetbyPersonIdBAL();

        /// <summary>
        /// Persons the interest getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonInterest&gt;.</returns>
        IList<PersonInterest> PersonInterest_GetbyPersonIdBAL(long PersonId);

        /// <summary>
        /// Persons the skills interest create bal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int64.</returns>
        long PersonSkillsInterest_CreateBAL(PersonSkillsInterest _objPersonSkillsInterest);

        /// <summary>
        /// Persons the skills interest create bal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int64.</returns>
        long PersonSkillsInterest_CreateBAL(string PersonIds,long user,string date,long cid,long OrganizationID);

        /// <summary>
        /// Persons the skills interest update bal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int32.</returns>
        int PersonSkillsInterest_UpdateBAL(PersonSkillsInterest _objPersonSkillsInterest);

        /// <summary>
        /// Persons the skills interest delete bal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int32.</returns>
        int PersonSkillsInterest_DeleteBAL(PersonSkillsInterest _objPersonSkillsInterest);

        /// <summary>
        /// Persons the skills interest duplication check bal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int32.</returns>
        int PersonSkillsInterest_DuplicationCheckBAL(PersonSkillsInterest _objPersonSkillsInterest);

        #endregion

        #region "Person Levels"

        /// <summary>
        /// Persons the levels getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>PersonLevels.</returns>
        PersonLevels PersonLevels_GetbyPersonIdBAL(long PersonId);

        /// <summary>
        /// Persons the levels create bal.
        /// </summary>
        /// <param name="_objPersonLevels">The object person levels.</param>
        /// <returns>System.Int64.</returns>
        long PersonLevels_CreateBAL(PersonLevels _objPersonLevels);

        /// <summary>
        /// Persons the levels update bal.
        /// </summary>
        /// <param name="_objPersonLevels">The object person levels.</param>
        /// <returns>System.Int32.</returns>
        int PersonLevels_UpdateBAL(PersonLevels _objPersonLevels);

        #endregion
    }
}