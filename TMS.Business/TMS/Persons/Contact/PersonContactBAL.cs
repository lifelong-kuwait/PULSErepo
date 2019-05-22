// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="PersonContactBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Business.Interfaces;
using TMS.DataObjects.Interfaces;
using TMS.DataObjects.TMS;
using TMS.Library.Common.Address;

namespace TMS.Business.TMS.Persons.Contact
{
    /// <summary>
    /// Class PersonContactBAL.
    /// </summary>
    /// <seealso cref="TMS.Business.Interfaces.IPersonContactBAL" />
    public class PersonContactBAL : IPersonContactBAL
    {
        private readonly IPersonContactDAL DAL;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonContactBAL"/> class.
        /// </summary>
        public PersonContactBAL()
        {
            DAL = new PersonContactDAL();
        }
        #region"PhoneNumber"
        /// <summary>
        /// Persons the phone numbers getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PhoneNumbers&gt;.</returns>
        public IList<PhoneNumbers> PersonPhoneNumbers_GetbyPersonIdBAL(long PersonId)
        {
            return DAL.PersonPhoneNumbers_GetbyPersonId(PersonId);
        }

        /// <summary>
        /// Persons the phone numbers create bal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        public long PersonPhoneNumbers_CreateBAL(PhoneNumbers _objPhoneNumbers, long PersonId)
        {
            return DAL.PersonPhoneNumbers_CreateDAL(_objPhoneNumbers, PersonId);
        }

        /// <summary>
        /// Persons the phone numbers update bal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonPhoneNumbers_UpdateBAL(PhoneNumbers _objPhoneNumbers, long PersonId)
        {
            return DAL.PersonPhoneNumbers_UpdateDAL(_objPhoneNumbers,PersonId);
        }

        /// <summary>
        /// Persons the phone numbers delete bal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool PersonPhoneNumbers_DeleteBAL(PhoneNumbers _objPhoneNumbers, long PersonId)
        {
            return DAL.PersonPhoneNumbers_DeleteDAL(_objPhoneNumbers, PersonId);
        }

        /// <summary>
        /// Persons the phone numbers duplication check bal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonPhoneNumbers_DuplicationCheckBAL(PhoneNumbers _objPhoneNumbers, long PersonId)
        {
            return DAL.PersonPhoneNumbers_DuplicationCheckDAL(_objPhoneNumbers, PersonId);
        }



        #endregion
        #region"Email Address"
        /// <summary>
        /// Persons the email address getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;EmailAddresses&gt;.</returns>
        public IList<EmailAddresses> PersonEmailAddress_GetbyPersonIdBAL(long PersonId)
        {
            return DAL.PersonEmailAddress_GetbyPersonId(PersonId);
        }

        /// <summary>
        /// Persons the email address create bal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        public long PersonEmailAddress_CreateBAL(EmailAddresses _objEmailAddresses, long PersonId)
        {
            return DAL.PersonEmailAddress_CreateDAL(_objEmailAddresses, PersonId);
        }

        /// <summary>
        /// Persons the email address update bal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEmailAddress_UpdateBAL(EmailAddresses _objEmailAddresses, long PersonId)
        {
            return DAL.PersonEmailAddress_UpdateDAL(_objEmailAddresses, PersonId);
        }

        /// <summary>
        /// Persons the email address delete bal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool PersonEmailAddress_DeleteBAL(EmailAddresses _objEmailAddresses, long PersonId)
        {
            return DAL.PersonEmailAddress_DeleteDAL(_objEmailAddresses, PersonId);
        }

        /// <summary>
        /// Persons the email address duplication check bal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEmailAddress_DuplicationCheckBAL(EmailAddresses _objEmailAddresses, long PersonId)
        {
            return DAL.PersonEmailAddress_DuplicationCheckDAL(_objEmailAddresses, PersonId);
        }
        /// <summary>
        /// Persons the email address get count by person idbal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEmailAddress_GetCountByPersonIDBAL(long PersonId)
        {
            return DAL.PersonEmailAddress_GetCountByPersonIDDAL( PersonId);
        }
        #endregion

        #region"Links"
        /// <summary>
        /// Persons the links getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;Links&gt;.</returns>
        public IList<Links> PersonLinks_GetbyPersonIdBAL(long PersonId)
        {
            return DAL.PersonLinks_GetbyPersonId(PersonId);
        }

        /// <summary>
        /// Persons the links create bal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        public long PersonLinks_CreateBAL(Links _objLinks, long PersonId)
        {
            return DAL.PersonLinks_CreateDAL(_objLinks, PersonId);
        }

        /// <summary>
        /// Persons the links update bal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <returns>System.Int32.</returns>
        public int PersonLinks_UpdateBAL(Links _objLinks)
        {
            return DAL.PersonLinks_UpdateDAL(_objLinks);
        }

        /// <summary>
        /// Persons the links delete bal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool PersonLinks_DeleteBAL(Links _objLinks, long PersonId)
        {
            return DAL.PersonLinks_DeleteDAL(_objLinks, PersonId);
        }

        /// <summary>
        /// Persons the links duplication check bal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonLinks_DuplicationCheckBAL(Links _objLinks, long PersonId)
        {
            return DAL.PersonLinks_DuplicationCheckDAL(_objLinks, PersonId);
        }
        /// <summary>
        /// Persons the links get count by person idbal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonLinks_GetCountByPersonIDBAL(long PersonId)
        {
            return DAL.PersonLinks_GetCountByPersonIDDAL(PersonId);
        }
        #endregion

        #region"Person Availibility"
        /// <summary>
        /// Persons the availability getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonAvailability&gt;.</returns>
        public IList<PersonAvailability> PersonAvailability_GetbyPersonIdBAL(long PersonId)
        {
            return DAL.PersonAvailability_GetbyPersonId(PersonId);
        }

        /// <summary>
        /// Persons the availability create bal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int64.</returns>
        public long PersonAvailability_CreateBAL(PersonAvailability _objPersonAvailability)
        {
            return DAL.PersonAvailability_CreateDAL(_objPersonAvailability);
        }

        /// <summary>
        /// Persons the availability update bal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int32.</returns>
        public int PersonAvailability_UpdateBAL(PersonAvailability _objPersonAvailability)
        {
            return DAL.PersonAvailability_UpdateDAL(_objPersonAvailability);
        }

        /// <summary>
        /// Persons the availability delete bal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int32.</returns>
        public int PersonAvailability_DeleteBAL(PersonAvailability _objPersonAvailability)
        {
            return DAL.PersonAvailability_DeleteDAL(_objPersonAvailability);
        }

        /// <summary>
        /// Persons the availability duplication check bal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int32.</returns>
        public int PersonAvailability_DuplicationCheckBAL(PersonAvailability _objPersonAvailability)
        {
            return DAL.PersonAvailability_DuplicationCheckDAL(_objPersonAvailability);
        }
        #endregion
    }
}