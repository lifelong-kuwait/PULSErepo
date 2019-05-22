// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="SkillsInterestLevelBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Business.Interfaces.TMS.SkillsInterestLevel;
using TMS.DataObjects.Interfaces.TMS.SkillsInterestLevel;
using TMS.DataObjects.TMS.SkillsInterestLevel;
using TMS.Library.Entities.Common.Configuration;
using TMS.Library.TMS.Persons.Skills;
using TMS.Library.TMS.Skills;

namespace TMS.Business.TMS.SkillsInterestLevel
{
    /// <summary>
    /// Class SkillsInterestLevelBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.TMS.SkillsInterestLevel.ISkillsInterestLevelBAL" />
    public class SkillsInterestLevelBAL : ISkillsInterestLevelBAL
    {
        private readonly ISkillsInterestLevelDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkillsInterestLevelBAL"/> class.
        /// </summary>
        public SkillsInterestLevelBAL()
        {
            DAL = new SkillsInterestLevelDAL();
        }
        #region"SkillsInterest"
        /// <summary>
        /// Persons the skill getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonSkill&gt;.</returns>
        public IList<PersonSkill> PersonSkill_GetbyPersonIdBAL(long PersonId, long CompanyID)
        {
            return DAL.PersonSkill_GetbyPersonId(PersonId, CompanyID);
        }

        /// <summary>
        /// Persons the skill getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonSkill&gt;.</returns>
        public IList<FocusAreas> PersonSkill_GetbyfocusIdBAL(long cid)
        {
            return DAL.PersonSkill_GetbyfocusId(cid);
        }

        /// <summary>
        /// Persons the skill getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonSkill&gt;.</returns>
        public IList<FocusAreas> PersonFocusAreaSkill_GetbyPersonIdBAL()
        {
            return DAL.PersonFocusAreaSkill_GetbyPersonId();
        }

        /// <summary>
        /// Persons the interest getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonInterest&gt;.</returns>
        public IList<PersonInterest> PersonInterest_GetbyPersonIdBAL(long PersonId)
        {
            return DAL.PersonInterest_GetbyPersonId(PersonId);
        }

        /// <summary>
        /// Persons the skills interest create bal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int64.</returns>
        public long PersonSkillsInterest_CreateBAL(PersonSkillsInterest _objPersonSkillsInterest)
        {
            return DAL.PersonSkillsInterest_CreateDAL(_objPersonSkillsInterest);
        }

        /// <summary>
        /// Persons the skills interest create bal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int64.</returns>
        public long PersonSkillsInterest_CreateBAL(string PersonIds,long user,string date,long cid, long OrganizationID)
        {
            return DAL.PersonSkillsInterest_CreateDAL(PersonIds,user,date,cid, OrganizationID);
        }

        /// <summary>
        /// Persons the skills interest update bal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int32.</returns>
        public int PersonSkillsInterest_UpdateBAL(PersonSkillsInterest _objPersonSkillsInterest)
        {
            return DAL.PersonSkillsInterest_UpdateDAL(_objPersonSkillsInterest);
        }

        /// <summary>
        /// Persons the skills interest delete bal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int32.</returns>
        public int PersonSkillsInterest_DeleteBAL(PersonSkillsInterest _objPersonSkillsInterest)
        {
            return DAL.PersonSkillsInterest_DeleteDAL(_objPersonSkillsInterest);
        }

        /// <summary>
        /// Persons the skills interest duplication check bal.
        /// </summary>
        /// <param name="_objPersonSkillsInterest">The object person skills interest.</param>
        /// <returns>System.Int32.</returns>
        public int PersonSkillsInterest_DuplicationCheckBAL(PersonSkillsInterest _objPersonSkillsInterest)
        {
            return DAL.PersonSkillsInterest_DuplicationCheckDAL(_objPersonSkillsInterest);
        }

        /// <summary>
        /// Persons the levels getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>PersonLevels.</returns>
        public PersonLevels PersonLevels_GetbyPersonIdBAL(long PersonId)
        {
            return DAL.PersonLevels_GetbyPersonId(PersonId);
        }

        /// <summary>
        /// Persons the levels create bal.
        /// </summary>
        /// <param name="_objPersonLevels">The object person levels.</param>
        /// <returns>System.Int64.</returns>
        public long PersonLevels_CreateBAL(PersonLevels _objPersonLevels)
        {
            return DAL.PersonLevels_CreateDAL(_objPersonLevels);
        }

        /// <summary>
        /// Persons the levels update bal.
        /// </summary>
        /// <param name="_objPersonLevels">The object person levels.</param>
        /// <returns>System.Int32.</returns>
        public int PersonLevels_UpdateBAL(PersonLevels _objPersonLevels)
        {
            return DAL.PersonLevels_UpdateDAL(_objPersonLevels);
        }

        #endregion
    }
}