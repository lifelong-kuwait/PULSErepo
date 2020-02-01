// ***********************************************************************
// Assembly         : TMS.DataObjects
// Author           : Almas Shabbir
// Created          : 07-08-2017
//
// Last Modified By : Almas Shabbir
// Last Modified On : 02-12-2018
// ***********************************************************************
// <copyright file="PersonContactDAL.cs" company="LifeLong www.lifelongkuwait.com">
//     Copyright ©  2016
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using TMS.DataObjects.Generics;
using TMS.DataObjects.Interfaces;
using TMS.Library.Common.Address;

namespace TMS.DataObjects.TMS
{
    /// <summary>
    /// Class PersonContactDAL.
    /// </summary>
    /// <seealso cref="TMS.DataObjects.Generics.DBGenerics" />
    /// <seealso cref="TMS.DataObjects.Interfaces.IPersonContactDAL" />
    public class PersonContactDAL : DBGenerics, IPersonContactDAL
    {
        #region"PhoneNumber"

        /// <summary>
        /// Persons the phone numbers getby person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PhoneNumbers&gt;.</returns>
        public IList<PhoneNumbers> PersonPhoneNumbers_GetbyPersonId(long PersonId)
        {
            return ExecuteListSp<PhoneNumbers>("TMS_PersonPhoneNumbers_GetbyPersonId", ParamBuilder.Par("PersonID", PersonId));
        }

        /// <summary>
        /// Persons the phone numbers create dal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        public long PersonPhoneNumbers_CreateDAL(PhoneNumbers _objPhoneNumbers, long PersonId)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonPhoneNumbers_Create", parameters,
                ParamBuilder.Par("PersonID", PersonId),
                ParamBuilder.Par("ContactNumber", _objPhoneNumbers.ContactNumber),
                ParamBuilder.Par("CountryCode", _objPhoneNumbers.CountryCode),
                    ParamBuilder.Par("Extension", _objPhoneNumbers.Extension),
                    ParamBuilder.Par("IsPrimary", _objPhoneNumbers.IsPrimary),
                    ParamBuilder.Par("PhoneTypeID", _objPhoneNumbers.PhoneTypeID),
                    ParamBuilder.Par("CreatedDate", _objPhoneNumbers.CreatedDate),
                    ParamBuilder.Par("CreatedBy", _objPhoneNumbers.CreatedBy));
        }

        /// <summary>
        /// Persons the phone numbers update dal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonPhoneNumbers_UpdateDAL(PhoneNumbers _objPhoneNumbers, long PersonId)
        {
            return ExecuteScalarInt32Sp("TMS_PersonPhoneNumbers_Update",
                    ParamBuilder.Par("ID", _objPhoneNumbers.ID),
                      ParamBuilder.Par("PersonID", PersonId),
                    ParamBuilder.Par("ContactNumber", _objPhoneNumbers.ContactNumber),
                     ParamBuilder.Par("CountryCode", _objPhoneNumbers.CountryCode),
                    ParamBuilder.Par("Extension", _objPhoneNumbers.Extension),
                    ParamBuilder.Par("IsPrimary", _objPhoneNumbers.IsPrimary),
                    ParamBuilder.Par("PhoneTypeID", _objPhoneNumbers.PhoneTypeID),
                    ParamBuilder.Par("UpdatedDate", _objPhoneNumbers.UpdatedDate),
                    ParamBuilder.Par("UpdatedBy", _objPhoneNumbers.UpdatedBy));
        }

        /// <summary>
        /// Persons the phone numbers delete dal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool PersonPhoneNumbers_DeleteDAL(PhoneNumbers _objPhoneNumbers, long PersonId)
        {
            var parameters = new[] { ParamBuilder.Par("IsDeleted", false) };
            return ExecuteBoolwithOutPutparameterSp("TMS_PersonPhoneNumbers_Delete", parameters,
                    ParamBuilder.Par("PhoneNumberID", _objPhoneNumbers.ID),
                    ParamBuilder.Par("PersonID", PersonId),
                    ParamBuilder.Par("UpdatedDate", _objPhoneNumbers.UpdatedDate),
                    ParamBuilder.Par("UpdatedBy", _objPhoneNumbers.UpdatedBy));
        }

        /// <summary>
        /// Persons the phone numbers duplication check dal.
        /// </summary>
        /// <param name="_objPhoneNumbers">The object phone numbers.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonPhoneNumbers_DuplicationCheckDAL(PhoneNumbers _objPhoneNumbers, long PersonId)
        {
            return ExecuteScalarSPInt32("TMS_PersonPhoneNumbers_DuplicationCheck",
                    ParamBuilder.Par("ContactNumber", _objPhoneNumbers.ContactNumber),
                     ParamBuilder.Par("ID", _objPhoneNumbers.ID),
                    ParamBuilder.Par("PersonID", PersonId));
        }

        #endregion

        #region"Email Address"

        /// <summary>
        /// Persons the email address getby person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;EmailAddresses&gt;.</returns>
        public IList<EmailAddresses> PersonEmailAddress_GetbyPersonId(long PersonId)
        {
            return ExecuteListSp<EmailAddresses>("TMS_PersonEmailAddresses_GetbyPersonId", ParamBuilder.Par("PersonID", PersonId));
        }

        /// <summary>
        /// Persons the email address create dal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        public long PersonEmailAddress_CreateDAL(EmailAddresses _objEmailAddresses, long PersonId)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonEmailAddresses_Create", parameters,
                        ParamBuilder.Par("PersonID", PersonId),
                        ParamBuilder.Par("Email", _objEmailAddresses.Email),
                        ParamBuilder.Par("IsPrimary", _objEmailAddresses.IsPrimary),
                        ParamBuilder.Par("CreatedDate", _objEmailAddresses.CreatedDate),
                        ParamBuilder.Par("CreatedBy", _objEmailAddresses.CreatedBy),
                        ParamBuilder.Par("OrganizationID",_objEmailAddresses.OrganizationID));
        }

        /// <summary>
        /// Persons the email address update dal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEmailAddress_UpdateDAL(EmailAddresses _objEmailAddresses, long PersonId)
        {
            return ExecuteScalarInt32Sp("TMS_PersonEmailAddresses_Update",
                    ParamBuilder.Par("ID", _objEmailAddresses.ID),
                    ParamBuilder.Par("PersonID", PersonId),
                    ParamBuilder.Par("Email", _objEmailAddresses.Email),
                    ParamBuilder.Par("IsPrimary", _objEmailAddresses.IsPrimary),
                    ParamBuilder.Par("UpdatedDate", _objEmailAddresses.UpdatedDate),
                    ParamBuilder.Par("UpdatedBy", _objEmailAddresses.UpdatedBy));
        }

        /// <summary>
        /// Persons the email address delete dal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool PersonEmailAddress_DeleteDAL(EmailAddresses _objEmailAddresses, long PersonId)
        {
            var parameters = new[] { ParamBuilder.Par("IsDeleted", false) };
            return ExecuteBoolwithOutPutparameterSp("TMS_PersonEmailAddresses_Delete", parameters,
                    ParamBuilder.Par("EmailAddressID", _objEmailAddresses.ID),
                    ParamBuilder.Par("PersonID", PersonId),
                    ParamBuilder.Par("UpdatedDate", _objEmailAddresses.UpdatedDate),
                    ParamBuilder.Par("UpdatedBy", _objEmailAddresses.UpdatedBy));
        }

        /// <summary>
        /// Persons the email address duplication check dal.
        /// </summary>
        /// <param name="_objEmailAddresses">The object email addresses.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEmailAddress_DuplicationCheckDAL(EmailAddresses _objEmailAddresses, long PersonId)
        {
            return ExecuteScalarSPInt32("TMS_PersonEmailAddresses_DuplicationCheck",
                    ParamBuilder.Par("Email", _objEmailAddresses.Email),
                     ParamBuilder.Par("ID", _objEmailAddresses.ID),
                    ParamBuilder.Par("PersonID", PersonId));
        }

        /// <summary>
        /// Persons the email address get count by person iddal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonEmailAddress_GetCountByPersonIDDAL(long PersonId)
        {
            return ExecuteScalarSPInt32("TMS_PersonEmailAddresses_GetCountByPersonID",
                    ParamBuilder.Par("PersonID", PersonId));
        }

        #endregion
        /// <summary>
        /// Section Link DAL All Functions related to Database Persistence is Here
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;Links&gt;.</returns>
        #region"Link"

        public IList<Links> PersonLinks_GetbyPersonId(long PersonId)
        {
            return ExecuteListSp<Links>("TMS_PersonLinks_GetbyPersonID", ParamBuilder.Par("PersonID", PersonId));
        }

        /// <summary>
        /// Persons the links create dal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int64.</returns>
        public long PersonLinks_CreateDAL(Links _objLinks, long PersonId)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonLinks_Create", parameters,
                        ParamBuilder.Par("PersonID", PersonId),
                        ParamBuilder.Par("Link", _objLinks.Link),
                        ParamBuilder.Par("Description", _objLinks.Description),
                        ParamBuilder.Par("LinkType", _objLinks.LinkType),
                        ParamBuilder.Par("CreatedBy", _objLinks.CreatedBy),
                        ParamBuilder.Par("CreatedDate", _objLinks.CreatedDate));
        }

        /// <summary>
        /// Persons the links update dal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <returns>System.Int32.</returns>
        public int PersonLinks_UpdateDAL(Links _objLinks)
        {
            return ExecuteScalarInt32Sp("TMS_Links_Update",
                        ParamBuilder.Par("ID", _objLinks.ID),
                        ParamBuilder.Par("Link", _objLinks.Link),
                        ParamBuilder.Par("Description", _objLinks.Description),
                        ParamBuilder.Par("LinkType", _objLinks.LinkType),
                        ParamBuilder.Par("UpdatedBy", _objLinks.UpdatedBy),
                        ParamBuilder.Par("UpdatedDate", _objLinks.UpdatedDate));
        }

        /// <summary>
        /// Persons the links delete dal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool PersonLinks_DeleteDAL(Links _objLinks, long PersonId)
        {
            var parameters = new[] { ParamBuilder.Par("IsDeleted", false) };
            return ExecuteBoolwithOutPutparameterSp("TMS_PersonLinks_Delete", parameters,
                    ParamBuilder.Par("LinkID", _objLinks.ID),
                    ParamBuilder.Par("PersonID", PersonId),
                    ParamBuilder.Par("UpdatedBy", _objLinks.UpdatedBy),
                    ParamBuilder.Par("UpdatedDate", _objLinks.UpdatedDate));
        }

        /// <summary>
        /// Persons the links duplication check dal.
        /// </summary>
        /// <param name="_objLinks">The object links.</param>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonLinks_DuplicationCheckDAL(Links _objLinks, long PersonId)
        {
            return ExecuteScalarSPInt32("TMS_PersonLinks_DuplicationCheck",
                    ParamBuilder.Par("Link", _objLinks.Link),
                    ParamBuilder.Par("LinkType", _objLinks.LinkType),
                    ParamBuilder.Par("PersonID", PersonId));
        }

        /// <summary>
        /// Persons the links get count by person iddal.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>System.Int32.</returns>
        public int PersonLinks_GetCountByPersonIDDAL(long PersonId)
        {
            return ExecuteScalarSPInt32("TMS_PersonLinks_GetCountByPersonID",
                    ParamBuilder.Par("PersonID", PersonId));
        }

        #endregion

        #region"PersonAvailibility"

        /// <summary>
        /// Persons the availability getby person identifier.
        /// </summary>
        /// <param name="PersonId">The person identifier.</param>
        /// <returns>IList&lt;PersonAvailability&gt;.</returns>
        public IList<PersonAvailability> PersonAvailability_GetbyPersonId(long PersonId)
        {
            return ExecuteListSp<PersonAvailability>("TMS_PersonAvailability_GetbyPersonID", ParamBuilder.Par("PersonID", PersonId));
        }

        /// <summary>
        /// Persons the availability create dal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int64.</returns>
        public long PersonAvailability_CreateDAL(PersonAvailability _objPersonAvailability)
        {
            var parameters = new[] { ParamBuilder.Par("ID", 0) };
            return ExecuteInt64withOutPutparameterSp("TMS_PersonAvailability_Create", parameters,
                            ParamBuilder.Par("PersonID", _objPersonAvailability.PersonID),
                            ParamBuilder.Par("FromDate", _objPersonAvailability.FromDate),
                            ParamBuilder.Par("ToDate", _objPersonAvailability.ToDate),
                            ParamBuilder.Par("CreatedBy", _objPersonAvailability.CreatedBy),
                            ParamBuilder.Par("CreatedDate", _objPersonAvailability.CreatedDate));
        }

        /// <summary>
        /// Persons the availability update dal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int32.</returns>
        public int PersonAvailability_UpdateDAL(PersonAvailability _objPersonAvailability)
        {
            return ExecuteScalarInt32Sp("TMS_PersonAvailability_Update",
                           ParamBuilder.Par("ID", _objPersonAvailability.ID),
                           ParamBuilder.Par("FromDate", _objPersonAvailability.FromDate),
                           ParamBuilder.Par("ToDate", _objPersonAvailability.ToDate),
                           ParamBuilder.Par("UpdatedBy", _objPersonAvailability.UpdatedBy),
                           ParamBuilder.Par("UpdatedDate", _objPersonAvailability.UpdatedDate));
        }

        /// <summary>
        /// Persons the availability delete dal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int32.</returns>
        public int PersonAvailability_DeleteDAL(PersonAvailability _objPersonAvailability)
        {
            return ExecuteScalarSPInt32("TMS_PersonAvailability_Delete",
                           ParamBuilder.Par("ID", _objPersonAvailability.ID),
                           ParamBuilder.Par("UpdatedBy", _objPersonAvailability.UpdatedBy),
                           ParamBuilder.Par("UpdatedDate", _objPersonAvailability.UpdatedDate));
        }

        /// <summary>
        /// Persons the availability duplication check dal.
        /// </summary>
        /// <param name="_objPersonAvailability">The object person availability.</param>
        /// <returns>System.Int32.</returns>
        public int PersonAvailability_DuplicationCheckDAL(PersonAvailability _objPersonAvailability)
        {
            return ExecuteScalarSPInt32("TMS_PersonAvailability_DuplicationCheck",
                            ParamBuilder.Par("PersonID", _objPersonAvailability.PersonID),
                            ParamBuilder.Par("FromDate", _objPersonAvailability.FromDate),
                            ParamBuilder.Par("ToDate", _objPersonAvailability.ToDate));
        }

        #endregion
    }
}