// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 12-12-2016
// ***********************************************************************
// <copyright file="IPersonContactDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.Library.Common.Address;

namespace TMS.DataObjects.Interfaces
{
    /// <summary>
    /// Interface IPersonContactDAL
    /// </summary>
    public interface IPersonContactDAL
    {
        #region"PhoneNumber"

        /// <summary>
        /// Persons the phone numbers getby person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PhoneNumbers&gt;.</returns>
        IList<PhoneNumbers> PersonPhoneNumbers_GetbyPersonId(long PersonId);

        /// <summary>
        /// Persons the phone numbers create dal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        long PersonPhoneNumbers_CreateDAL(PhoneNumbers _objPhoneNumbers, long PersonId);

        /// <summary>
        /// Persons the phone numbers update dal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonPhoneNumbers_UpdateDAL(PhoneNumbers _objPhoneNumbers, long PersonId);

        /// <summary>
        /// Persons the phone numbers delete dal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool PersonPhoneNumbers_DeleteDAL(PhoneNumbers _objPhoneNumbers, long PersonId);

        /// <summary>
        /// Persons the phone numbers duplication check dal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonPhoneNumbers_DuplicationCheckDAL(PhoneNumbers _objPhoneNumbers, long PersonId);

        #endregion

        #region"Email Address"

        /// <summary>
        /// Persons the email address getby person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;EmailAddresses&gt;.</returns>
        IList<EmailAddresses> PersonEmailAddress_GetbyPersonId(long PersonId);

        /// <summary>
        /// Persons the email address create dal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        long PersonEmailAddress_CreateDAL(EmailAddresses _objEmailAddresses, long PersonId);

        /// <summary>
        /// Persons the email address update dal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonEmailAddress_UpdateDAL(EmailAddresses _objEmailAddresses, long PersonId);

        /// <summary>
        /// Persons the email address delete dal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool PersonEmailAddress_DeleteDAL(EmailAddresses _objEmailAddresses, long PersonId);

        /// <summary>
        /// Persons the email address duplication check dal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonEmailAddress_DuplicationCheckDAL(EmailAddresses _objEmailAddresses, long PersonId);

        /// <summary>
        /// Persons the email address get count by person iddal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonEmailAddress_GetCountByPersonIDDAL(long PersonId);

        #endregion

        #region"Link"

        /// <summary>
        /// Persons the links getby person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;Links&gt;.</returns>
        IList<Links> PersonLinks_GetbyPersonId(long PersonId);

        /// <summary>
        /// Persons the links create dal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        long PersonLinks_CreateDAL(Links _objLinks, long PersonId);

        /// <summary>
        /// Persons the links update dal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <returns>System.Int32.</returns>
        int PersonLinks_UpdateDAL(Links _objLinks);

        /// <summary>
        /// Persons the links delete dal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool PersonLinks_DeleteDAL(Links _objLinks, long PersonId);

        /// <summary>
        /// Persons the links duplication check dal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonLinks_DuplicationCheckDAL(Links _objLinks, long PersonId);

        /// <summary>
        /// Persons the links get count by person iddal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        int PersonLinks_GetCountByPersonIDDAL(long PersonId);

        #endregion

        #region"PersonAvailibility"

        /// <summary>
        /// Persons the availability getby person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonAvailability&gt;.</returns>
        IList<PersonAvailability> PersonAvailability_GetbyPersonId(long PersonId);

        /// <summary>
        /// Persons the availability create dal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int64.</returns>
        long PersonAvailability_CreateDAL(PersonAvailability _objPersonAvailability);

        /// <summary>
        /// Persons the availability update dal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int32.</returns>
        int PersonAvailability_UpdateDAL(PersonAvailability _objPersonAvailability);

        /// <summary>
        /// Persons the availability delete dal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int32.</returns>
        int PersonAvailability_DeleteDAL(PersonAvailability _objPersonAvailability);

        /// <summary>
        /// Persons the availability duplication check dal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int32.</returns>
        int PersonAvailability_DuplicationCheckDAL(PersonAvailability _objPersonAvailability);

        #endregion
    }
}