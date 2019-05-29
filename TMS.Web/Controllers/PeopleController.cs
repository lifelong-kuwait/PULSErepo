using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Linq;
using System.Web.Mvc;
using TMS.Business.Interfaces;
using TMS.Business.Interfaces.Common;
using TMS.Business.Interfaces.TMS;
using TMS.Library.Common.Address;
using TMS.Library.Common.Attachment;
using TMS.Library.TMS.Persons;
using TMS.Library.Users;
using TMS.Library.TMS.Persons.Others;
using lr = Resources.Resources;
using TMS.Library.Entities.TMS.Program;
using TMS.Library;
using TMS.Business.Interfaces.Common.Configuration;
using TMS.Library.Entities.CRM;

namespace TMS.Web.Controllers
{
    public class PeopleController : TMSControllerBase
    {
        private readonly IAttachmentBAL _AttachmentBAL;
        private readonly IPersonBAL _PersonBAL;
        private readonly IBALUsers _UserBAL;
        private readonly ITrainerBAL _TrainerBAL;
        private readonly IPersonContactBAL _objPersonContactBAL;
        private readonly IConfigurationBAL _objConfigurationBAL;

        public PeopleController(IAttachmentBAL objIAttachmentBAL,   IConfigurationBAL _objIConfigurationBAL, ITrainerBAL objITrainerBAL, IPersonBAL objIPersonBAL, IBALUsers objUserBAL, IPersonContactBAL _objePersonContact)
        {
            _objConfigurationBAL = _objIConfigurationBAL; _AttachmentBAL = objIAttachmentBAL; _TrainerBAL = objITrainerBAL; _PersonBAL = objIPersonBAL; _UserBAL = objUserBAL; _objPersonContactBAL = _objePersonContact;
        }

        #region Person

        [ClaimsAuthorizeAttribute("CanViewPerson")]
        public ActionResult Person(long pT)
        {
            ViewData["RoleID"] = pT;
            return View(pT);
        }


        [ClaimsAuthorizeAttribute("CanViewPersonDetail")]
        public ActionResult Detail(string pid)
        {
            if (string.IsNullOrEmpty(pid))
            {
                return RedirectPermanent(Url.Content("~/People/Person"));
            }
            else
            {
                var data = _PersonBAL.Person_GetAllByIdBAL(pid);
                if (data == null)
                {
                    ViewData["model"] = Url.Content("~/People/Person");
                    return View("Static/NotFound");
                }
                else
                {
                    ViewData["model"] = data;
                    return View();
                }
            }
        }

        [ClaimsAuthorizeAttribute("CanViewPerson")]
        public ActionResult PersonActive(long pT)
        {
            ViewData["RoleID"] = pT;
            return View(pT);
        }

        //[ClaimsAuthorizeAttribute("CanViewPersonDetail")]
        //public ActionResult ManageForword_Create([DataSourceRequest] DataSourceRequest request)
        //{
        //    //long RoleID = 1;
        //    //var startRowIndex = (request.Page - 1) * request.PageSize;
        //    int Total = 0;
        //    //var SearchText = Request.Form["SearchText"];
        //    //if (request.PageSize == 0)
        //    //{
        //    //    request.PageSize = 10;
        //    //}
        //    var startRowIndex = (request.Page - 1) * request.PageSize;
        //    //   int Total = 0;
        //    var SearchText = Request.Form["SearchText"];
        //    if (request.PageSize == 0)
        //    {
        //        request.PageSize = 10;
        //    }

        //    var _person = this._TrainerBAL.DeletedPerson_GetAllBAL(CurrentCulture, CurrentUser.CompanyID, SearchText);
        //        return Json(_person.ToDataSourceResult(request, ModelState));
           
        //}

        [ClaimsAuthorizeAttribute("CanViewPersonAchievement", "CanViewPersonSuggestedTraining", "CanViewPersonRelation", "CanViewPersonAttachments", "CanViewPersonNotes")]
        [ContentAuthorize]
        public ActionResult Others(string pid)
        {
            return PartialView("_DetailOthers", pid);
        }
        //CanViewPersonByOrganization

        [ClaimsAuthorizeAttribute("CanViewPerson")]
        [DontWrapResult]
        public ActionResult Person_Read([DataSourceRequest] DataSourceRequest request, long RoleID)
        {
            //var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            //var SearchText = Request.Form["SearchText"];
            //if (request.PageSize == 0)
            //{
            //    request.PageSize = 10;
            //}
            var startRowIndex = (request.Page - 1) * request.PageSize;
            //   int Total = 0;
            var SearchText = Request.Form["SearchText"];
            var DeletedPerson = Request.Form["DeletedPerson"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            if (RoleID == 10)
            {
                var _person = this._TrainerBAL.DeletedPerson_GetAllBAL(CurrentCulture, CurrentUser.CompanyID, SearchText);
                return Json(_person.ToDataSourceResult(request, ModelState));
            }
            else { 
            if (CurrentUser.CompanyID > 0)
            {
                //var _person = _PersonBAL.PersonOrganization_GetALLBAL(Convert.ToString(CurrentUser.CompanyID));
                var _person = this._TrainerBAL.TrainerOrganization_GetAllBAL(CurrentCulture, RoleID, Convert.ToString(CurrentUser.CompanyID),  SearchText);
                return Json(_person.ToDataSourceResult(request, ModelState));
            }
            else
            {
                var _person = this._TrainerBAL.Trainer_GetAllBAL(CurrentCulture, RoleID, Convert.ToString(CurrentUser.CompanyID),  SearchText);

                return Json(_person.ToDataSourceResult(request, ModelState));
            }
            //var result = new DataSourceResult()
            //{
            //    Data = _person, // Process data (paging and sorting applied)
            //    Total = Total // Total number of records
            //};
           // return Json(result);
            //else { 
            ////var _person = _PersonBAL.Person_GetALLBAL();
            //        return Json(_person.ToDataSourceResult(request, ModelState));
            }
        }




        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public JsonResult IsUserWithEmail_Available(string Email, string initialEmail)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return Json("Enter Email please!", JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (Email == initialEmail)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                if (this._UserBAL.LoginUsers_DuplicationCheckBAL(new LoginUsers { Email = Email }) > 0)
                {
                    return Json(lr.UserEmailAlreadyExist, JsonRequestBehavior.AllowGet);
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }



        [ClaimsAuthorizeAttribute("CanAddEditPerson")]

        [DontWrapResult]
        public ActionResult Person_Create([DataSourceRequest] DataSourceRequest request, Person _person, long RoleID)
        {
            if (ModelState.IsValid)
            {
                bool _valid = false;

                if (_UserBAL.LoginPerson_DuplicationCheckBAL(new Person { Email = _person.Email }) > 0)
                {
                    ModelState.AddModelError(lr.AddressAddressDublication, lr.AddressAddressDublication);
                    // return Json(lr.UserEmailAlreadyExist, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    if (_person.Email != null)//when Email is Provided
                    {
                        _valid = true;
                    }
                    else if (_person.ContactNumber != null)//when Contact number is provided
                    {
                        if (_person.CountryCode == 0)//when country code is  provided
                        {
                            ModelState.AddModelError(lr.PersonPhoneCountryCode, lr.PersonPhoneNumberProvideCountryocde);
                        }
                        else
                        {
                            _valid = true;
                        }
                    }



                    else
                    {
                        ModelState.AddModelError(lr.PersonContactEmail, lr.PersonEmailorPhoneRequired);
                    }



                    if (_valid)
                    {
                        //  _person.ProfilePicture = HandlePersonProfilePicture(filename, _person.ID, aid);
                        _person.CreatedBy = CurrentUser.NameIdentifierInt64;
                        _person.CreatedDate = DateTime.Now;
                        _person.OrganizationID = CurrentUser.CompanyID;
                        string _profilePict = string.Empty;
                        if (_person.ClientType == 0)
                            _person.ClientType = ClientType.ClientType_Internal;
                        var Resp = SavePersonData(_person, ref _profilePict, RoleID);
                        string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (string.IsNullOrEmpty(ip))
                            ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                        _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                        _person.AddedByAlias = CurrentUser.Name;
                        _person.ID = Resp.ID;
                        _person.PersonRegCode = Resp.PersonRegCode;
                        _person.ProfilePicture = _profilePict;
                        if (_person.ID != long.MinValue)
                        {
                         //   _PersonBAL.ManageAssigned_CreateBAL(_person);
                            if (_person.ContactNumber != null)//when ContactNumber is Provided
                            {
                                PhoneNumbers _objPhoneNumbers = new PhoneNumbers
                                {
                                    ContactNumber = _person.ContactNumber,
                                    CountryCode = _person.CountryCode,
                                    IsPrimary = true,
                                    Extension = _person.Extension,
                                    CreatedBy = CurrentUser.NameIdentifierInt64,
                                    CreatedDate = DateTime.Now
                                };
                                _person.PhoneID = _objPersonContactBAL.PersonPhoneNumbers_CreateBAL(_objPhoneNumbers, _person.ID);
                            }
                            if (_person.Email != null)//when Email is Provided
                            {


                                EmailAddresses _objEmailAddresses = new EmailAddresses
                                {
                                    Email = _person.Email,
                                    IsPrimary = true,
                                    CreatedBy = CurrentUser.NameIdentifierInt64,
                                    CreatedDate = DateTime.Now
                                };
                                _person.EmailID = _objPersonContactBAL.PersonEmailAddress_CreateBAL(_objEmailAddresses, _person.ID);
                            }
                        }
                    }

                }
            }
            var resultData = new[] { _person };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorizeAttribute("CanAddEditPerson")]
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public ActionResult Person_Update([DataSourceRequest] DataSourceRequest request, Person _person, string filename, long aid)
        {
            _person.UpdatedBy = CurrentUser.NameIdentifierInt64;
            _person.UpdatedDate = DateTime.Now;
            _person.ClientType = ClientType.ClientType_Internal;

            bool _valid = false;
            if (_person.Email != null)//when Email is Provided
            {
                _valid = true;
            }
            else if (_person.ContactNumber != null)//when Contact number is provided
            {
                if (_person.CountryCode == 0)//when country code is  provided
                {
                    ModelState.AddModelError(lr.PersonPhoneCountryCode, lr.PersonPhoneNumberProvideCountryocde);
                }
                else
                {
                    _valid = true;
                }
            }
            else
            {
                ModelState.AddModelError(lr.PersonContactEmail, lr.PersonEmailorPhoneRequired);
            }
            if (_valid)
            {
                var result = _PersonBAL.Person_UpdateBAL(_person);
                _person.ProfilePicture = HandlePersonProfilePicture(filename, _person.ID, aid);
                if (result != -1)
                {
                    if (_person.PhoneID > 0)
                    {
                        if (_person.ContactNumber != null)
                        {
                            if (_person.CountryCode != 0)//when country code is  provided
                            {
                                PhoneNumbers _objPhoneNumbers = new PhoneNumbers
                                {
                                    ID = _person.PhoneID,
                                    ContactNumber = _person.ContactNumber,
                                    CountryCode = _person.CountryCode,
                                    IsPrimary = true,
                                    Extension = _person.Extension,
                                    UpdatedBy = CurrentUser.NameIdentifierInt64,
                                    UpdatedDate = DateTime.Now
                                };
                                _objPersonContactBAL.PersonPhoneNumbers_UpdateBAL(_objPhoneNumbers, _person.ID);
                                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                                if (string.IsNullOrEmpty(ip))
                                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);

                            }
                            else
                            {
                            }
                        }
                    }
                    else
                    {
                        if (_person.ContactNumber != null)//when Contact number is provided
                        {
                            if (_person.CountryCode == 0)//when country code is  provided
                            {
                                ModelState.AddModelError(lr.PersonPhoneCountryCode, lr.PersonPhoneNumberProvideCountryocde);
                            }
                            else
                            {
                                PhoneNumbers _objPhoneNumbers = new PhoneNumbers
                                {
                                    ID = _person.PhoneID,
                                    ContactNumber = _person.ContactNumber,
                                    CountryCode = _person.CountryCode,
                                    IsPrimary = true,
                                    Extension = _person.Extension,
                                    CreatedBy = CurrentUser.NameIdentifierInt64,
                                    CreatedDate = DateTime.Now
                                };
                                _person.PhoneID = _objPersonContactBAL.PersonPhoneNumbers_CreateBAL(_objPhoneNumbers, _person.ID);
                            }
                        }
                    }
                    if (_person.EmailID > 0)
                    {
                        if (_person.Email != null)//when Email is Provided
                        {
                            EmailAddresses _objEmailAddresses = new EmailAddresses
                            {
                                ID = _person.EmailID,
                                Email = _person.Email,
                                IsPrimary = true,
                                UpdatedBy = CurrentUser.NameIdentifierInt64,
                                UpdatedDate = DateTime.Now
                            };
                            _objPersonContactBAL.PersonEmailAddress_UpdateBAL(_objEmailAddresses, _person.ID);
                        }
                    }
                    else
                    {
                        if (_person.Email != null)//when Email is Provided
                        {
                            EmailAddresses _objEmailAddresses = new EmailAddresses
                            {
                                Email = _person.Email,
                                IsPrimary = true,
                                CreatedBy = CurrentUser.NameIdentifierInt64,
                                CreatedDate = DateTime.Now
                            };
                            _person.EmailID = _objPersonContactBAL.PersonEmailAddress_CreateBAL(_objEmailAddresses, _person.ID);
                        }
                    }
                }
            }
            var resultData = new[] { _person };
            if (_person.Flags != null)
                _person.Flags = _person.Flags.Where(i => i != null).ToList();
            //return Json(new object[0].ToDataSourceResult(request, ModelState));
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorizeAttribute("CanDeletePerson")]
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public ActionResult Person_Activ([DataSourceRequest] DataSourceRequest request, string pid)
        {

            Person _person = new Person();
            _person.IsActive = true;
            _person.IsDeleted = false;
            _person.ID = Convert.ToInt64(pid);
                _person.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _person.UpdatedDate = DateTime.Now;

                var result = _PersonBAL.Person_ActiveBAL(_person);
                return Json(new object[0].ToDataSourceResult(request, ModelState));
            


        }


        [ClaimsAuthorizeAttribute("CanDeletePerson")]
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public ActionResult Person_Destroy([DataSourceRequest] DataSourceRequest request, Person _person)
        {

            if (_UserBAL.DeletePerson_CheckBAL(new ClassTrainerMapping { PersonID = _person.ID }) > 0)
            {
                //ModelState.AddModelError(lr.UserEmailAlreadyExist, lr.UserEmailAlreadyExist);
                return Json(lr.UserEmailAlreadyExist, JsonRequestBehavior.AllowGet);
            }
            else {
                _person.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _person.UpdatedDate = DateTime.Now;

                var result = _PersonBAL.Person_DeleteBAL(_person);
                return Json(new object[0].ToDataSourceResult(request, ModelState));
            }


        }

        [NonAction]
        public PersonResponse SavePersonData(Person _person, ref string _profilePict, long RoleID)
        {
            var result = _PersonBAL.PersonInsertNewPersonBAL(_person, RoleID);
            _profilePict = "/images/i/people.png"; // _profilePict=   HandlePersonAttachment(filename, result.ID);
            return result;
        }

        [NonAction]
        public string HandlePersonProfilePicture(string picturename, long PersonId, long aid)
        {
            if (!string.IsNullOrEmpty(picturename))
            {
                var model = _AttachmentBAL.TMS_Attachment_GetSingleByIdAndTypeBAL(aid);
                _AttachmentBAL.TMS_Attachment_CompletedProfileLogoBAL(new TMS_Attachments { CompletedDate = DateTime.Now, ID = aid, OpenID = PersonId, OpenType = 1 });

                return model.FilePath.Replace("~/", "") + model.FileName;
            }
            return "/images/i/people.png";
        }

        [DontWrapResult]
        public JsonResult CoordinateGroups()
        {
            return Json(this._PersonBAL.TMS_Coordinate_GetAllByCultureBAL(CurrentCulture),JsonRequestBehavior.AllowGet);

        }

        #endregion Person

        #region Person By Organization

        //[ClaimsAuthorizeAttribute("CanViewPersonByOrganization")]
        //public ActionResult PersonOrganization()
        //{
        //    return View();
        //}

        //[ClaimsAuthorizeAttribute("CanViewPersonByOrganization")]
        //[DontWrapResult]
        //public ActionResult PersonByOrganization_Read([DataSourceRequest] DataSourceRequest request)
        //{
        //    var _person = _PersonBAL.PersonOrganization_GetALLBAL(Convert.ToString(CurrentUser.CompanyID));
        //    return Json(_person.ToDataSourceResult(request, ModelState));
        //}

        //[ClaimsAuthorizeAttribute("CanAddEditPersonByOrganization")]
        //[DontWrapResult]
        //public ActionResult PersonByOrganization_Create([DataSourceRequest] DataSourceRequest request, Person _person)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        bool _valid = false;
        //        if (_person.Email != null)//when Email is Provided
        //        {
        //            _valid = true;
        //        }
        //        else if (_person.ContactNumber != null)//when Contact number is provided
        //        {
        //            if (_person.CountryCode == 0)//when country code is  provided
        //            {
        //                ModelState.AddModelError(lr.PersonPhoneCountryCode, lr.PersonPhoneNumberProvideCountryocde);
        //            }
        //            else
        //            {
        //                _valid = true;
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(lr.PersonContactEmail, lr.PersonEmailorPhoneRequired);
        //        }
        //        if (_valid)
        //        {
        //            _person.CreatedBy = CurrentUser.NameIdentifierInt64;
        //            _person.CreatedDate = DateTime.Now;
        //            _person.OrganizationID = CurrentUser.CompanyID;
        //            string _profilePict = string.Empty;
        //            var Resp = SavePersonData(_person, ref _profilePict);
        //            _person.AddedByAlias = CurrentUser.Name;
        //            _person.ID = Resp.ID;
        //            _person.PersonRegCode = Resp.PersonRegCode;
        //            _person.ProfilePicture = _profilePict;
        //            if (_person.ID != long.MinValue)
        //            {
        //                if (_person.ContactNumber != null)//when ContactNumber is Provided
        //                {
        //                    PhoneNumbers _objPhoneNumbers = new PhoneNumbers
        //                    {
        //                        ContactNumber = _person.ContactNumber,
        //                        CountryCode = _person.CountryCode,
        //                        IsPrimary = true,
        //                        Extension = _person.Extension,
        //                        CreatedBy = CurrentUser.NameIdentifierInt64,
        //                        CreatedDate = DateTime.Now
        //                    };
        //                    _person.PhoneID = _objPersonContactBAL.PersonPhoneNumbers_CreateBAL(_objPhoneNumbers, _person.ID);
        //                }
        //                if (_person.Email != null)//when Email is Provided
        //                {
        //                    EmailAddresses _objEmailAddresses = new EmailAddresses
        //                    {
        //                        Email = _person.Email,
        //                        IsPrimary = true,
        //                        CreatedBy = CurrentUser.NameIdentifierInt64,
        //                        CreatedDate = DateTime.Now
        //                    };
        //                    _person.EmailID = _objPersonContactBAL.PersonEmailAddress_CreateBAL(_objEmailAddresses, _person.ID);
        //                }
        //            }
        //        }
        //    }

        //    var resultData = new[] { _person };
        //    return Json(resultData.ToDataSourceResult(request, ModelState));
        //}
        #endregion

        #region"Relation to Person"

        [ClaimsAuthorizeAttribute("CanViewPersonRelation")]
        [DontWrapResult]
        public ActionResult Relation(string PersonID)
        {
            return PartialView("_PersonRelation", PersonID);
        }

        [ClaimsAuthorizeAttribute("CanViewPersonRelation")]
        [DontWrapResult]
        public ActionResult Relation_read([DataSourceRequest] DataSourceRequest request, long pid)
        {
            var _Phone = _PersonBAL.PersonRelationGetAllbyPersonIDBAL(pid);
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorizeAttribute("CanAddEditPersonRelation")]
        [ActivityAuthorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public ActionResult Relation_Create([DataSourceRequest] DataSourceRequest request, long pid, PersonRelation _objPersonRelation)
        {
            if (ModelState.IsValid)
            {
                _objPersonRelation.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objPersonRelation.CreatedDate = DateTime.Now;
                _objPersonRelation.RelationFrom = pid;
                if (_PersonBAL.PersonRelationToPerson_DuplicationCheckBAL(_objPersonRelation) == 0)
                {
                    _objPersonRelation.RelationID = _PersonBAL.PersonRelationToPerson_CreateBAL(_objPersonRelation);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                }
                else
                {
                    ModelState.AddModelError(lr.PersonRelationToField, lr.PersonRelationDuplicationMessage);
                }
            }
            var resultData = new[] { _objPersonRelation };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorizeAttribute("CanAddEditPersonRelation")]
        [ActivityAuthorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public ActionResult Relation_Update([DataSourceRequest] DataSourceRequest request, PersonRelation _objPersonRelation)
        {
            if (ModelState.IsValid)
            {
                _objPersonRelation.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPersonRelation.UpdatedDate = DateTime.Now;

                if (_PersonBAL.PersonRelationToPerson_DuplicationCheckBAL(_objPersonRelation) == 0)
                {
                    var result = _PersonBAL.PersonRelationToPerson_UpdateBAL(_objPersonRelation);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);

                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
                else
                {
                    ModelState.AddModelError(lr.PersonRelationToField, lr.PersonRelationDuplicationMessage);
                }
            }
            var resultData = new[] { _objPersonRelation };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorizeAttribute("CanDeletePersonRelation")]
        [ActivityAuthorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public ActionResult Relation_Destroy([DataSourceRequest] DataSourceRequest request, PersonRelation _objPersonRelation)
        {
            if (ModelState.IsValid)
            {
                _objPersonRelation.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPersonRelation.UpdatedDate = DateTime.Now;
                var result = _PersonBAL.PersonRelationToPerson_DeleteBAL(_objPersonRelation);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objPersonRelation };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region Venues Detail added for Open Type

        [ClaimsAuthorize("CanViewPersonRoles")]
        [DontWrapResult]
        public ActionResult ManageRoles(long PersonId)
        {
            return PartialView("_PersonRoles", PersonId);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonRoles")]
        public ActionResult ManageRoles_Read([DataSourceRequest] DataSourceRequest request, long PersonId)
        {

            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var Classs = _PersonBAL.TMS_PersonRolesMapping_GetbyPersonIDBAL(PersonId,CurrentUser.CompanyID, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            var result = new DataSourceResult()
            {
                Data = Classs, // Process data (paging and sorting applied)
                Total = Total // Total number of records
            };
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPersonRoles")]
        public ActionResult ManageRoles_Create([DataSourceRequest] DataSourceRequest request, PersonRolesMapping _objPersonRoles)
        {
            if (ModelState.IsValid)
            {
                _objPersonRoles.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objPersonRoles.CreatedDate = DateTime.Now;
                _objPersonRoles.PersonID = Convert.ToInt64(Request.QueryString["PersonID"]);
                CRM_EnrolmentHistory EnrolmentHistory = new CRM_EnrolmentHistory();
                EnrolmentHistory.CreatedBy = CurrentUser.NameIdentifierInt64;
                EnrolmentHistory.CreatedOn = DateTime.Now;
                EnrolmentHistory.PersonID = Convert.ToInt64(Request.QueryString["PersonID"]);
                EnrolmentHistory.RoleName = "Trainee";
                _objPersonRoles.ClientType = ClientType.ClientType_Internal;
                if (_objPersonRoles.IsLogin == true && _objPersonRoles.Password != null)
                {

                    var person = _PersonBAL.Person_GetAllByIdBAL(Convert.ToString(_objPersonRoles.PersonID));

                    if (_UserBAL.LoginUsers_DuplicationCheckBAL(new LoginUsers { Email = person.Email }) > 0)
                    {
                        ModelState.AddModelError(lr.UsersTitle, lr.UserEmailAlreadyExist);
                        if (_PersonBAL.TMS_PersonRolesMapping_DuplicationCheckBAL(_objPersonRoles) > 0)
                        {
                            ModelState.AddModelError(lr.VenueName, lr.VenueDuplicationCheck);
                        }
                        else
                        {
                            _objPersonRoles.ID = _PersonBAL.TMS_PersonRolesMapping_CreateBAL(_objPersonRoles);
                            _PersonBAL.Enrolment_CreateBAL(EnrolmentHistory);
                            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                            if (string.IsNullOrEmpty(ip))
                                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                            _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                        }
                    }
                    else
                    {
                        _objPersonRoles.Password = Crypto.CreatePasswordHash(_objPersonRoles.Password);
                        _PersonBAL.TMS_PersonintoUser_CreateBAL(_objPersonRoles);
                        if (_PersonBAL.TMS_PersonRolesMapping_DuplicationCheckBAL(_objPersonRoles) > 0)
                        {
                            ModelState.AddModelError(lr.VenueName, lr.VenueDuplicationCheck);
                        }
                        else
                        {
                            _objPersonRoles.ID = _PersonBAL.TMS_PersonRolesMapping_CreateBAL(_objPersonRoles);
                            _PersonBAL.Enrolment_CreateBAL(EnrolmentHistory);
                        }
                    }
                }
                else
                {
                    if (_PersonBAL.TMS_PersonRolesMapping_DuplicationCheckBAL(_objPersonRoles) > 0)
                    {
                        ModelState.AddModelError(lr.VenueName, lr.VenueDuplicationCheck);
                    }
                    else
                    {
                        _objPersonRoles.ID = _PersonBAL.TMS_PersonRolesMapping_CreateBAL(_objPersonRoles);
                        _PersonBAL.Enrolment_CreateBAL(EnrolmentHistory);
                        string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (string.IsNullOrEmpty(ip))
                            ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                        _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                    }
                }
            }
            var resultData = new[] { _objPersonRoles };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPersonRoles")]
        public ActionResult ManageRoles_Update([DataSourceRequest] DataSourceRequest request, PersonRolesMapping _objPersonRoles)
        {
            if (ModelState.IsValid)
            {
                _objPersonRoles.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPersonRoles.UpdatedDate = DateTime.Now;
                var person = _PersonBAL.Person_GetAllByIdBAL(Convert.ToString(_objPersonRoles.PersonID));

                if (_objPersonRoles.IsLogin == true && _objPersonRoles.Password != null)
                {
                    if (_UserBAL.LoginUsers_DuplicationCheckBAL(new LoginUsers { Email = person.Email }) > 0)
                    {
                        ModelState.AddModelError(lr.UsersTitle, lr.UserEmailAlreadyExist);
                        if (_PersonBAL.TMS_PersonRolesMapping_DuplicationCheckBAL(_objPersonRoles) > 0)
                        {
                            ModelState.AddModelError(lr.VenueName, lr.VenueDuplicationCheck);
                        }
                        else
                        {
                            var result = _PersonBAL.TMS_PersonRolesMapping_UpdateBAL(_objPersonRoles);
                            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                            if (string.IsNullOrEmpty(ip))
                                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                            _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);

                            if (result == -1)
                            {
                                ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                            }
                        }
                    }
                    else
                    {
                        _objPersonRoles.Password = Crypto.CreatePasswordHash(_objPersonRoles.Password);
                        _PersonBAL.TMS_PersonintoUser_CreateBAL(_objPersonRoles);
                        string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (string.IsNullOrEmpty(ip))
                            ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                        _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                        if (_PersonBAL.TMS_PersonRolesMapping_DuplicationCheckBAL(_objPersonRoles) > 0)
                        {
                            ModelState.AddModelError(lr.VenueName, lr.VenueDuplicationCheck);
                        }
                        else
                        {
                            var result = _PersonBAL.TMS_PersonRolesMapping_UpdateBAL(_objPersonRoles);
                            if (result == -1)
                            {
                                ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                            }
                        }
                    }
                }
                else
                {
                    if (_PersonBAL.TMS_PersonRolesMapping_DuplicationCheckBAL(_objPersonRoles) > 0)
                    {
                        ModelState.AddModelError(lr.VenueName, lr.VenueDuplicationCheck);
                    }
                    else
                    {
                        var result = _PersonBAL.TMS_PersonRolesMapping_UpdateBAL(_objPersonRoles);
                        if (result == -1)
                        {
                            ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                        }
                    }
                }
                //
                //if (_PersonBAL.TMS_PersonRolesMapping_DuplicationCheckBAL(_objPersonRoles) > 0)
                //{
                //    ModelState.AddModelError(lr.VenueName, lr.VenueDuplicationCheck);
                //}
                //else
                //{
                //    var result = _PersonBAL.TMS_PersonRolesMapping_UpdateBAL(_objPersonRoles);
                //    if (result == -1)
                //    {
                //        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                //    }
                //}
            }
            var resultData = new[] { _objPersonRoles };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeletePersonRoles")]
        public ActionResult ManageRoles_Destroy([DataSourceRequest] DataSourceRequest request, PersonRolesMapping _objPersonRoles)
        {
            if (ModelState.IsValid)
            {
                _objPersonRoles.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPersonRoles.UpdatedDate = DateTime.Now;
                //if (_objPersonRoles.RoleID == 2)
                //{

                //}
                var result = _PersonBAL.TMS_PersonRolesMapping_DeleteBAL(_objPersonRoles);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objPersonRoles };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion Venues
    }
}