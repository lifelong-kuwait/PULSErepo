// ***********************************************************************
// Assembly         : TMS.Business
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-12-2016
// ***********************************************************************
// <copyright file="IPersonContactBAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Common.Address;

namespace TMS.Business.Interfaces
{
    /// <summary>
    /// Interface IPersonContactBAL
    /// </summary>
    public interface IPersonContactBAL
    {
        #region"PhoneNumber"

        /// <summary>
        /// Persons the phone numbers getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PhoneNumbers&gt;.</returns>
        IList<PhoneNumbers> PersonPhoneNumbers_GetbyPersonIdBAL(long PersonId);

        /// <summary>
        /// Persons the phone numbers create bal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        long PersonPhoneNumbers_CreateBAL(PhoneNumbers _objPhoneNumbers, long PersonId);

        /// <summary>
        /// Persons the phone numbers update bal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonPhoneNumbers_UpdateBAL(PhoneNumbers _objPhoneNumbers, long PersonId);

        /// <summary>
        /// Persons the phone numbers delete bal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool PersonPhoneNumbers_DeleteBAL(PhoneNumbers _objPhoneNumbers, long PersonId);

        /// <summary>
        /// Persons the phone numbers duplication check bal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonPhoneNumbers_DuplicationCheckBAL(PhoneNumbers _objPhoneNumbers, long PersonId);

        #endregion
        #region"Email Address"

        /// <summary>
        /// Persons the email address getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;EmailAddresses&gt;.</returns>
        IList<EmailAddresses> PersonEmailAddress_GetbyPersonIdBAL(long PersonId);

        /// <summary>
        /// Persons the email address create bal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        long PersonEmailAddress_CreateBAL(EmailAddresses _objEmailAddresses, long PersonId);
    
        /// <summary>
        /// Persons the email address update bal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonEmailAddress_UpdateBAL(EmailAddresses _objEmailAddresses, long PersonId);

        /// <summary>
        /// Persons the email address delete bal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool PersonEmailAddress_DeleteBAL(EmailAddresses _objEmailAddresses, long PersonId);

        /// <summary>
        /// Persons the email address duplication check bal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonEmailAddress_DuplicationCheckBAL(EmailAddresses _objEmailAddresses, long PersonId);

        /// <summary>
        /// Persons the email address get count by person id bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonEmailAddress_GetCountByPersonIDBAL(long PersonId);

        #endregion
        #region "Links"

        /// <summary>
        /// Persons the links getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;Links&gt;.</returns>
        IList<Links> PersonLinks_GetbyPersonIdBAL(long PersonId);

        /// <summary>
        /// Persons the links create bal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        long PersonLinks_CreateBAL(Links _objLinks, long PersonId);

        /// <summary>
        /// Persons the links update bal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <returns>System.Int32.</returns>
        int PersonLinks_UpdateBAL(Links _objLinks);

        /// <summary>
        /// Persons the links delete bal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool PersonLinks_DeleteBAL(Links _objLinks, long PersonId);

        /// <summary>
        /// Persons the links duplication check bal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonLinks_DuplicationCheckBAL(Links _objLinks, long PersonId);

        /// <summary>
        /// Persons the links get count by person id bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonLinks_GetCountByPersonIDBAL(long PersonId);

        #endregion
        #region "Person Availability"

        /// <summary>
        /// Persons the availability getby person identifier bal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonAvailability&gt;.</returns>
        IList<PersonAvailability> PersonAvailability_GetbyPersonIdBAL(long PersonId);

        /// <summary>
        /// Persons the availability create bal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int64.</returns>
        long PersonAvailability_CreateBAL(PersonAvailability _objPersonAvailability);

        /// <summary>
        /// Persons the availability update bal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int32.</returns>
        int PersonAvailability_UpdateBAL(PersonAvailability _objPersonAvailability);

        /// <summary>
        /// Persons the availability delete bal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int32.</returns>
        int PersonAvailability_DeleteBAL(PersonAvailability _objPersonAvailability);

        /// <summary>
        /// Persons the availability duplication check bal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int32.</returns>
        int PersonAvailability_DuplicationCheckBAL(PersonAvailability _objPersonAvailability);

        #endregion
    }
}