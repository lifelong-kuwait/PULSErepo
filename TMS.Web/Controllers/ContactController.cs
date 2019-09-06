using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMS.Business.Interfaces;
using TMS.Business.Interfaces.Common.Address;
using TMS.Business.Interfaces.TMS;
using TMS.Business.Interfaces.TMS.Organization;
using TMS.Library;
using TMS.Library.Common.Address;
using TMS.Library.TMS.Persons;
using lr = Resources.Resources;

namespace TMS.Web.Controllers
{
    public class ContactController : TMSControllerBase
    {
        private readonly IAddressBAL _objAddressBAL;
        private readonly IPersonContactBAL _objPersonContactBAL;
        private readonly IOrganizationBAL _objIOrganizationBAL;
        private readonly IBALUsers _UserBAL;

        public ContactController(IAddressBAL _objeAddress, IPersonContactBAL _objePersonContact, IOrganizationBAL _objeIOrganizationBAL, IBALUsers _User)
        {
            _objAddressBAL = _objeAddress; _objPersonContactBAL = _objePersonContact; _objIOrganizationBAL = _objeIOrganizationBAL; _UserBAL = _User;
        }

        #region"Address"

        [ClaimsAuthorize("CanViewPersonAddresses")]
        [DontWrapResult]
        public ActionResult PrimaryAddress(string PersonID)
        {
            return PartialView("_PrimaryAddress", PersonID);
        }

        [DontWrapResult]
        [ContentAuthorize]
        [ClaimsAuthorize("CanViewOrganizationAddresses")]
        public ActionResult OrganizationAddress(string oid)
        {
            return PartialView("_OrganizationAddress", oid);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewOrganizationAddresses", "CanViewPersonAddresses")]
        public ActionResult ContactAddress_Read([DataSourceRequest] DataSourceRequest request, string oid, int type)
        {
            IList<Addresses> _Address = new List<Addresses>();
            if (type == 1)
            {
                _Address = _objAddressBAL.TMS_PersonAddresses_GetbyPersonIdBAL(oid);
            }
            else
            {
                _Address = _objAddressBAL.TMS_OrganizationAddresses_GetbyOrganizationIdBAL(oid);
            }
            return Json(_Address.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditOrganizationAddresses", "CanAddEditPersonAddresses")]
        public ActionResult ContactAddress_Create([DataSourceRequest] DataSourceRequest request, long oid, int type, Addresses _AddressesPrimary)
        {
            if (ModelState.IsValid)
            {
                if (this._objAddressBAL.Address_DuplicationCheckBAL(_AddressesPrimary) > 1)
                {
                    ModelState.AddModelError(lr.AddressAddressDublication, lr.AddressAddressDublication);

                    //  return Json(lr.AddressAddressOne, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    _AddressesPrimary.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _AddressesPrimary.CreatedDate = DateTime.Now;
                    //_Addres'sesPrimary.AddressType = AddressType.AddressType_Primary;
                    if (type == 1)
                    {
                        _AddressesPrimary.ID = _objAddressBAL.TMS_PersonAddresses_CreateBAL(_AddressesPrimary, Convert.ToInt64(oid));
                    }
                    else
                    {
                        _AddressesPrimary.ID = _objAddressBAL.TMS_OrganizationAddresses_CreateBAL(_AddressesPrimary, Convert.ToInt64(oid));
                    }
                }
            }
            var resultData = new[] { _AddressesPrimary };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditOrganizationAddresses", "CanAddEditPersonAddresses")]
        public ActionResult ContactAddress_Update([DataSourceRequest] DataSourceRequest request, Addresses _AddressesPrimary)
        {
            if (ModelState.IsValid)
            {
                _AddressesPrimary.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _AddressesPrimary.UpdatedDate = DateTime.Now;
                var result = _objAddressBAL.TMS_PersonAddresses_UpdateBAL(_AddressesPrimary);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _AddressesPrimary };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanDeleteOrganizationAddresses", "CanDeletePersonAddresses")]
        public ActionResult ContactAddress_Destroy([DataSourceRequest] DataSourceRequest request, long oid, int type, Addresses _AddressesPrimary)
        {
            if (ModelState.IsValid)
            {
                _AddressesPrimary.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _AddressesPrimary.UpdatedDate = DateTime.Now;
                if (type == 1)
                {
                    var result = _objAddressBAL.TMS_PersonAddresses_DeleteBAL(_AddressesPrimary, Convert.ToInt64(oid));
                    if (!result)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
                else
                {
                    var result = _objAddressBAL.TMS_OrganizationAddresses_DeleteBAL(_AddressesPrimary, Convert.ToInt64(oid));
                    if (!result)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
            }
            var resultData = new[] { _AddressesPrimary };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region"Links"

        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonOnlinePresence")]
        public ActionResult PersonLinks(string PersonID)
        {
            return PartialView("_PersonLinks", PersonID);
        }

        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewOrganizationOnlinePresence")]
        public ActionResult OrganizationLinks(string oid)
        {
            return PartialView("_OrganizationLinks", oid);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewOrganizationOnlinePresence", "CanViewPersonOnlinePresence")]
        public ActionResult Links_Read([DataSourceRequest] DataSourceRequest request, string oid, int type)
        {
            IList<Links> _Phone = new List<Links>();
            if (type == 1)
            {
                _Phone = _objPersonContactBAL.PersonLinks_GetbyPersonIdBAL(Convert.ToInt64(oid));
            }
            else
            {
                _Phone = _objIOrganizationBAL.OrganizationLinks_GetbyOrganizationIdBAL(Convert.ToInt64(oid));
            }
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditOrganizationOnlinePresence", "CanAddEditPersonOnlinePresence")]
        public ActionResult Links_Create([DataSourceRequest] DataSourceRequest request, long oid, int type, Links _objLinks)
        {
            if (ModelState.IsValid)
            {
                _objLinks.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objLinks.CreatedDate = DateTime.Now;
                _objLinks.Description = "";
                if (type == 1)
                {
                    if (_objPersonContactBAL.PersonLinks_GetCountByPersonIDBAL(Convert.ToInt64(oid)) >= TMSHelper.GetPersonLinksLimit())
                    {
                        ModelState.AddModelError(lr.PersonContactLink, lr.PersonContactLinkMaxLimit);
                    }
                    else if (_objPersonContactBAL.PersonLinks_DuplicationCheckBAL(_objLinks, Convert.ToInt64(oid)) > 0)
                    {
                        ModelState.AddModelError(lr.PersonContactLink, lr.PersonContactLinkDuplicationCheck);
                    }
                    else
                    {
                        _objLinks.ID = _objPersonContactBAL.PersonLinks_CreateBAL(_objLinks, Convert.ToInt64(oid));
                    }
                }
                else
                {
                    if (_objIOrganizationBAL.OrganizationLinks_GetCountByOrganizationIDBAL(Convert.ToInt64(oid)) >= TMSHelper.GetPersonLinksLimit())
                    {
                        ModelState.AddModelError(lr.PersonContactLink, lr.OrganizationContactLinkMaxLimit);
                    }
                    else if (_objIOrganizationBAL.OrganizationLinks_DuplicationCheckBAL(_objLinks, Convert.ToInt64(oid)) > 0)
                    {
                        ModelState.AddModelError(lr.PersonContactLink, lr.OrganizationContactLinkDuplicationCheck);
                    }
                    else
                    {
                        _objLinks.ID = _objIOrganizationBAL.OrganizationLinks_CreateBAL(_objLinks, Convert.ToInt64(oid));
                    }
                }
            }
            var resultData = new[] { _objLinks };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditOrganizationOnlinePresence", "CanAddEditPersonOnlinePresence")]
        public ActionResult Links_Update([DataSourceRequest] DataSourceRequest request, long oid, int type, Links _objLinks)
        {
            if (ModelState.IsValid)
            {
                _objLinks.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objLinks.UpdatedDate = DateTime.Now;
                _objLinks.Description = "";
                if (type == 1)
                {
                    if (_objPersonContactBAL.PersonLinks_DuplicationCheckBAL(_objLinks, Convert.ToInt64(oid)) > 0)
                    {
                        ModelState.AddModelError(lr.PersonContactLink, lr.PersonContactLinkDuplicationCheck);
                    }
                    else
                    {
                        var result = _objPersonContactBAL.PersonLinks_UpdateBAL(_objLinks);
                        if (result == -1)
                        {
                            ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                        }
                    }
                }
                else
                {
                    if (_objIOrganizationBAL.OrganizationLinks_DuplicationCheckBAL(_objLinks, Convert.ToInt64(oid)) > 0)
                    {
                        ModelState.AddModelError(lr.PersonContactLink, lr.OrganizationContactLinkDuplicationCheck);
                    }
                    else
                    {
                        var result = _objIOrganizationBAL.OrganizationLinks_UpdateBAL(_objLinks);
                        if (result == -1)
                        {
                            ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                        }
                    }
                }
            }
            var resultData = new[] { _objLinks };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanDeleteOrganizationOnlinePresence", "CanDeletePersonOnlinePresence")]
        public ActionResult Links_Destroy([DataSourceRequest] DataSourceRequest request, long oid, int type, Links _objLinks)
        {
            if (ModelState.IsValid)
            {
                _objLinks.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objLinks.UpdatedDate = DateTime.Now;
                if (type == 1)
                {
                    var result = _objPersonContactBAL.PersonLinks_DeleteBAL(_objLinks, Convert.ToInt64(oid));
                    if (!result)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
                else
                {
                    var result = _objIOrganizationBAL.OrganizationLinks_DeleteBAL(_objLinks, Convert.ToInt64(oid));
                    if (!result)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
            }
            var resultData = new[] { _objLinks };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region"PersonPhone"

        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult PersonPhone(string PersonID)
        {
            return PartialView("_PhoneNumber", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult PersonPhone_Read([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _Phone = _objPersonContactBAL.PersonPhoneNumbers_GetbyPersonIdBAL(Convert.ToInt64(PersonID));
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonPhone")]
        public ActionResult PersonPhone_Create([DataSourceRequest] DataSourceRequest request, string pid, PhoneNumbers _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                if (_objPersonContactBAL.PersonPhoneNumbers_DuplicationCheckBAL(_objPhoneNumbers, Convert.ToInt64(pid)) > 1)
                {
                    ModelState.AddModelError(lr.PersonPhoneNumber, lr.PersonPhoneDuplication);
                }
                else
                {
                    _objPhoneNumbers.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _objPhoneNumbers.CreatedDate = DateTime.Now;
                    _objPhoneNumbers.ID = _objPersonContactBAL.PersonPhoneNumbers_CreateBAL(_objPhoneNumbers, Convert.ToInt64(pid));
                }
            }
            var resultData = new[] { _objPhoneNumbers };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonPhone")]
        public ActionResult PersonPhone_Update([DataSourceRequest] DataSourceRequest request, string pid, PhoneNumbers _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                if (_objPersonContactBAL.PersonPhoneNumbers_DuplicationCheckBAL(_objPhoneNumbers, Convert.ToInt64(pid)) > 0)
                {
                    ModelState.AddModelError(lr.PersonPhoneNumber, lr.PersonPhoneDuplication);
                }
                else
                {
                    _objPhoneNumbers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                    _objPhoneNumbers.UpdatedDate = DateTime.Now;
                    var result = _objPersonContactBAL.PersonPhoneNumbers_UpdateBAL(_objPhoneNumbers, Convert.ToInt64(pid));
                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
            }
            var resultData = new[] { _objPhoneNumbers };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanDeletePersonPhone")]
        public ActionResult PersonPhone_Destroy([DataSourceRequest] DataSourceRequest request, string pid, PhoneNumbers _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                _objPhoneNumbers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPhoneNumbers.UpdatedDate = DateTime.Now;
                if (_objPhoneNumbers.IsPrimary == true)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.PrimaryContents);

                }
                else
                {
                    var result = _objPersonContactBAL.PersonPhoneNumbers_DeleteBAL(_objPhoneNumbers, Convert.ToInt64(pid));
                    if (!result)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
            }
            var resultData = new[] { _objPhoneNumbers };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region"EmailAddress"

        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonEmail")]
        public ActionResult EmailAddress(string PersonID)
        {
            return PartialView("_EmailAddress", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonEmail")]
        public ActionResult EmailAddress_Read([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _Phone = _objPersonContactBAL.PersonEmailAddress_GetbyPersonIdBAL(Convert.ToInt64(PersonID));
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonEmail")]
        public ActionResult EmailAddress_Create([DataSourceRequest] DataSourceRequest request, string pid, EmailAddresses _objEmailAddresses)
        {
            if (ModelState.IsValid)
            {
                if (_UserBAL.LoginPerson_DuplicationCheckBAL(new Person { Email = _objEmailAddresses.Email, CreatedBy = CurrentUser.NameIdentifierInt64 }) > 0)
                {
                    ModelState.AddModelError(lr.UserEmailAlreadyExist, lr.UserEmailAlreadyExist);
                    // return Json(lr.UserEmailAlreadyExist, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    _objEmailAddresses.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _objEmailAddresses.CreatedDate = DateTime.Now;
                    if (_objPersonContactBAL.PersonEmailAddress_GetCountByPersonIDBAL(Convert.ToInt64(pid)) >= TMSHelper.GetPersonEmailLimit())
                    {
                        ModelState.AddModelError(lr.PersonContactEmail, string.Format(lr.PersonContactEmailLimit, TMSHelper.GetPersonEmailLimit().ToString()));
                    }
                    else if (_objPersonContactBAL.PersonEmailAddress_DuplicationCheckBAL(_objEmailAddresses, Convert.ToInt64(pid)) > 0)
                    {
                        ModelState.AddModelError(lr.PersonContactEmail, lr.PersonContactEmailDuplicationCheck);
                    }
                    else
                    {
                        _objEmailAddresses.ID = _objPersonContactBAL.PersonEmailAddress_CreateBAL(_objEmailAddresses, Convert.ToInt64(pid));
                    }
                }
            }
            var resultData = new[] { _objEmailAddresses };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonEmail")]
        public ActionResult EmailAddress_Update([DataSourceRequest] DataSourceRequest request, string pid, EmailAddresses _objEmailAddresses)
        {
            if (ModelState.IsValid)
            {
                if (_UserBAL.LoginPerson_DuplicationCheckBAL(new Person { Email = _objEmailAddresses.Email,CreatedBy=CurrentUser.NameIdentifierInt64 }) > 1)
                {
                    ModelState.AddModelError(lr.UserEmailAlreadyExist, lr.UserEmailAlreadyExist);
                    // return Json(lr.UserEmailAlreadyExist, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    _objEmailAddresses.UpdatedBy = CurrentUser.NameIdentifierInt64;
                    _objEmailAddresses.UpdatedDate = DateTime.Now;
                    if (_objPersonContactBAL.PersonEmailAddress_DuplicationCheckBAL(_objEmailAddresses, Convert.ToInt64(pid)) > 0)
                    {
                        ModelState.AddModelError(lr.PersonContactEmail, lr.PersonContactEmailDuplicationCheck);
                    }
                    else
                    {
                        var result = _objPersonContactBAL.PersonEmailAddress_UpdateBAL(_objEmailAddresses, Convert.ToInt64(pid));
                        if (result == -1)
                        {
                            ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                        }
                    }
                }
            }
            var resultData = new[] { _objEmailAddresses };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanDeletePersonEmail")]
        public ActionResult EmailAddress_Destroy([DataSourceRequest] DataSourceRequest request, string pid, EmailAddresses _objEmailAddresses)
        {
            if (ModelState.IsValid)
            {
                _objEmailAddresses.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objEmailAddresses.UpdatedDate = DateTime.Now;
                if (_objEmailAddresses.IsPrimary == true)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.PrimaryContents);

                }
                else
                {
                    var result = _objPersonContactBAL.PersonEmailAddress_DeleteBAL(_objEmailAddresses, Convert.ToInt64(pid));
                    if (!result)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
            }
            var resultData = new[] { _objEmailAddresses };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region"Person Availability"

        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonAvailability")]
        public ActionResult PersonAvailability(string PersonID)
        {
            return PartialView("_PersonAvailability", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonAvailability")]
        public ActionResult PersonAvailability_Read([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _Phone = _objPersonContactBAL.PersonAvailability_GetbyPersonIdBAL(Convert.ToInt64(PersonID));
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonAvailability")]
        public ActionResult PersonAvailability_Create([DataSourceRequest] DataSourceRequest request, string pid, PersonAvailability _objPersonAvailibility)
        {
            if (ModelState.IsValid)
            {
                _objPersonAvailibility.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objPersonAvailibility.PersonID = Convert.ToInt64(pid);
                _objPersonAvailibility.CreatedDate = DateTime.Now;
                if (_objPersonContactBAL.PersonAvailability_DuplicationCheckBAL(_objPersonAvailibility) > 0)
                {
                    ModelState.AddModelError(lr.PersonContactAvailabilityFromDate, lr.PersonContactAvailabilityDuplicationCheck);
                }
                else
                {
                    _objPersonAvailibility.ID = _objPersonContactBAL.PersonAvailability_CreateBAL(_objPersonAvailibility);
                }
            }
            var resultData = new[] { _objPersonAvailibility };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonAvailability")]
        public ActionResult PersonAvailability_Update([DataSourceRequest] DataSourceRequest request, PersonAvailability _objPersonAvailibility)
        {
            if (ModelState.IsValid)
            {
                _objPersonAvailibility.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPersonAvailibility.UpdatedDate = DateTime.Now;
                if (_objPersonContactBAL.PersonAvailability_DuplicationCheckBAL(_objPersonAvailibility) > 0)
                {
                    ModelState.AddModelError(lr.PersonContactAvailabilityFromDate, lr.PersonContactAvailabilityDuplicationCheck);
                }
                else
                {
                    var result = _objPersonContactBAL.PersonAvailability_UpdateBAL(_objPersonAvailibility);
                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
            }
            var resultData = new[] { _objPersonAvailibility };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanDeletePersonAvailability")]
        public ActionResult PersonAvailability_Destroy([DataSourceRequest] DataSourceRequest request, PersonAvailability _objPersonAvailibility)
        {
            if (ModelState.IsValid)
            {
                _objPersonAvailibility.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPersonAvailibility.UpdatedDate = DateTime.Now;
                var result = _objPersonContactBAL.PersonAvailability_DeleteBAL(_objPersonAvailibility);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objPersonAvailibility };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion
    }
}