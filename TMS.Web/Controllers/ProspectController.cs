using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Linq;
using System.Web.Mvc;
using TMS.Business.Interfaces;
using TMS.Business.Interfaces.Common;
using TMS.Business.Interfaces.TMS;
using TMS.Library;
using TMS.Library.Common.Address;
using TMS.Library.Common.Attachment;
using TMS.Library.Entities.CRM;
using TMS.Library.TMS.Persons;
using TMS.Library.TMS.Persons.Others;
using TMS.Web.Core;
using lr = Resources.Resources;

namespace TMS.Web.Controllers
{
    [SessionTimeout]
    public class ProspectController : TMSControllerBase
    {
        private readonly IAttachmentBAL _AttachmentBAL;
        private readonly IPersonBAL _PersonBAL;
        private readonly IPersonContactBAL _objPersonContactBAL;
        private readonly IBALUsers _UserBAL;

        public ProspectController(IAttachmentBAL objIAttachmentBAL, IPersonBAL objIPersonBAL, IPersonContactBAL _objePersonContact, IBALUsers _User)
        {
            _AttachmentBAL = objIAttachmentBAL; _PersonBAL = objIPersonBAL; _objPersonContactBAL = _objePersonContact; _UserBAL = _User;
        }
        // GET: Prospect
        public ActionResult Index()
        {
            return View();
        }

        #region Details

        [ClaimsAuthorizeAttribute("CanViewProspectDetail")]
        public ActionResult Detail(string pid)
        {
            if (string.IsNullOrEmpty(pid))
            {
                return RedirectPermanent(Url.Content("~/Prospect/Index"));
            }
            else
            {
                var data = _PersonBAL.Prospect_GetAllByIdBAL(pid);
                if (data == null)
                {
                    ViewData["model"] = Url.Content("~/Prospect/Index");
                    return View("Static/NotFound");
                }
                else
                {
                    ViewData["model"] = data;
                    return View();
                }
            }
        }
        [HttpPost]
        public ActionResult RecordDetails(Person pvm, FormCollection form)
        {
            return RedirectToAction("~/Prospect/Index");
        }

        [ClaimsAuthorizeAttribute("CanViewPersonAchievement", "CanViewPersonSuggestedTraining", "CanViewPersonRelation", "CanViewPersonAttachments", "CanViewPersonNotes")]
        [ContentAuthorize]
        public ActionResult Others(string pid)
        {
            return PartialView("_DetailOthers", pid);
        }

        [ClaimsAuthorizeAttribute("CanViewProspects")]
        [DontWrapResult]
        public ActionResult Person_Record_GetAll([DataSourceRequest] DataSourceRequest request, string PSID)
        {
            var _person = _PersonBAL.Person_Record_GetALLBAL(PSID);
            return Json(_person.ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region CURD

        [ClaimsAuthorizeAttribute("CanViewProspects")]
        [DontWrapResult]
        public ActionResult Person_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            // long ClassID = 0;
            //  ClassID = Convert.ToInt64(Request.QueryString["ClassId"]);
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }

            var _person = _PersonBAL.Prospect_GetALLBAL(CurrentCulture, CurrentUser.CompanyID, SearchText);
            return Json(_person.ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorizeAttribute("CanAddEditProspects")]
        [DontWrapResult]
        public ActionResult Person_Create([DataSourceRequest] DataSourceRequest request, Person _person)
        {
            if (ModelState.IsValid)
            {
                bool _valid = false;
                if (_UserBAL.LoginPerson_DuplicationCheckBAL(new Person { Email = _person.Email,CreatedBy=CurrentUser.CompanyID }) > 0)
                {
                    ModelState.AddModelError(lr.UserEmailAlreadyExist, lr.UserEmailAlreadyExist);
                    // return Json(lr.UserEmailAlreadyExist, JsonRequestBehavior.AllowGet);
                    _valid = false;
                }
                else if (_UserBAL.LoginPerson_DuplicationPhoneNumberCheckBAL(new Person { ContactNumber = _person.ContactNumber, CreatedBy = CurrentUser.CompanyID }) > 0)
                {
                    ModelState.AddModelError(lr.DubliocationHappen, lr.PersonContactPhoneDuplicationCheck);
                    //return Json(lr.UserEmailAlreadyExist, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    //if (_person.Email != null)//when Email is Provided
                    //{
                    //    _valid = true;
                    //}
                    //else
                    //if (_person.ContactNumber != null)//when Contact number is provided
                    //{
                    //    if (_person.CountryCode == 0)//when country code is  provided
                    //    {
                    //        ModelState.AddModelError(lr.PersonPhoneCountryCode, lr.PersonPhoneNumberProvideCountryocde);
                    //    }
                    //    else
                    //    {
                    //        _valid = true;
                    //    }
                    //}
                    //else
                    //{
                    //    ModelState.AddModelError(lr.PersonContactEmail, lr.PersonEmailorPhoneRequired);
                    //}
                    _valid = true;
                    if (_valid)
                    {
                        _person.CreatedBy = CurrentUser.NameIdentifierInt64;
                        _person.CreatedDate = DateTime.Now;
                        _person.OrganizationID = CurrentUser.CompanyID;
                        string _profilePict = string.Empty;
                        _person.DateOfBirth = DateTime.Now;
                        var Resp = SavePersonData(_person, ref _profilePict);
                        _person.AddedByAlias = CurrentUser.Name;
                        _person.ID = Resp.ID;
                        long val = Convert.ToInt64(_person.AssignedToString);
                        if(val==0 ||val<0)
                            _person.AssignedTo = CurrentUser.NameIdentifierInt64;
                        else
                            _person.AssignedTo = val;
                        _person.PersonRegCode = Resp.PersonRegCode;
                        _person.ProfilePicture = _profilePict;
                        long crmval = (long)_person.CrmClientType;


                        if (_person.ID != long.MinValue)
                        {
                            _PersonBAL.ManageAssigned_CreateBAL(_person);

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

        [ClaimsAuthorizeAttribute("CanAddEditProspects")]
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public ActionResult Person_Update([DataSourceRequest] DataSourceRequest request, Person _person, string filename, long aid)
        {
            _person.UpdatedBy = CurrentUser.NameIdentifierInt64;
            _person.UpdatedDate = DateTime.Now;

            bool _valid = false;
            if (_UserBAL.LoginPerson_DuplicationCheckBAL(new Person { Email = _person.Email,CreatedBy=_person.CreatedBy }) > 0)
            {
                ModelState.AddModelError(lr.UserEmailAlreadyExist, lr.UserEmailAlreadyExist);
                // return Json(lr.UserEmailAlreadyExist, JsonRequestBehavior.AllowGet);
                _valid = false;
            }
            else if (_UserBAL.LoginPerson_DuplicationPhoneNumberUpdateCheckBAL(new Person { ContactNumber = _person.ContactNumber, CreatedBy = CurrentUser.CompanyID, ID = _person.ID }) > 0)
            {
                ModelState.AddModelError(lr.DubliocationHappen, lr.PersonContactPhoneDuplicationCheck);
                //return Json(lr.UserEmailAlreadyExist, JsonRequestBehavior.AllowGet);
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
                        _person.CountryCode = 134;
                        _valid = true;
                        //ModelState.AddModelError(lr.PersonPhoneCountryCode, lr.PersonPhoneNumberProvideCountryocde);
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
                    _person.UpdatedBy = CurrentUser.NameIdentifierInt64;
                    if(_person.CrmClientType==null)
                    {
                        _person.CrmClientType = CRMClientType.Not_Specified;
                    }
                    var result = _PersonBAL.Person_UpdateBAL(_person);
                    _person.ProfilePicture = HandlePersonProfilePicture(filename, _person.ID, aid);
                    if (result != -1)
                    {
                        if (_person.PhoneID > 0)
                        {
                            if (_person.ContactNumber != null)
                            {
                                if(_person.CountryCode==0)
                                {
                                    _person.CountryCode = 134;
                                }
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
            }
            var resultData = new[] { _person };
            if (_person.Flags != null)
                _person.Flags = _person.Flags.Where(i => i != null).ToList();
            //return Json(new object[0].ToDataSourceResult(request, ModelState));
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorizeAttribute("CanDeleteProspect")]
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public ActionResult Prospect_Destroy([DataSourceRequest] DataSourceRequest request, Person _person)
        {
            if (_PersonBAL.ManageCourse_Assigned(_person.ID) > 0)
            {
                ModelState.AddModelError(lr.PersonPhoneNumber, lr.PersonPhoneDuplication);
            }
            else
            {
                _person.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _person.UpdatedDate = DateTime.Now;
                var result = _PersonBAL.Person_DeleteBAL(_person);

                //if (result == -1)
                //{
                //    //if()
                //    //_objPersonContactBAL.PersonEmailAddress_DeleteBAL();
                //}
                //var resultData = new[] { _person };
            }
                return Json(new object[0].ToDataSourceResult(request, ModelState));
            // return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [NonAction]
        public PersonResponse SavePersonData(Person _person, ref string _profilePict)
        {
            var result = _PersonBAL.ProspectInsertNewPersonBAL(_person, 3);
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

        #endregion

        #region


        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewScheduleClassess")]
        public ActionResult ScheduledClasses(long PersonID)
        {
            return PartialView("ScheduledClasses", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewScheduleClassess")]
        public ActionResult ManageScheduledClasses_Read([DataSourceRequest] DataSourceRequest request, long PersonID)
        {
            var _Phone = _PersonBAL.ManageScheduledClasses_GetAllBAL(Convert.ToInt64(PersonID));
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditScheduleClassess")]
        public ActionResult ManageScheduledClasses_Create([DataSourceRequest] DataSourceRequest request, CRM_classPersonMapping _mapping, long oid)
        {
            if (ModelState.IsValid)
            {
                _mapping.PersonID = oid;
                if (_PersonBAL.ManageScheduleCourse_DuplicationCheckBAL(_mapping) > 0)
                {
                    ModelState.AddModelError(lr.DubliocationHappen, lr.DubliocationHappen);
                }
                else
                {
                    _mapping.PersonID = oid;
                    _mapping.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _mapping.CreatedOn = DateTime.Now;
                    _mapping.ID = _PersonBAL.ManageScheduledClasses_CreateBAL(_mapping);
                }
            }
            var resultData = new[] { _mapping };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditScheduleClassess")]
        public ActionResult ManageScheduledClasses_Update([DataSourceRequest] DataSourceRequest request, CRM_classPersonMapping _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                _objPhoneNumbers.UpdatedOn = DateTime.Now;
                if (_PersonBAL.ManageScheduledClasses_DublicationBAL(_objPhoneNumbers) > 0)
                {
                    ModelState.AddModelError(lr.DubliocationHappen, lr.DubliocationHappen);
                }
                else
                {
                    _objPhoneNumbers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPhoneNumbers.UpdatedOn = DateTime.Now;
                var result = _PersonBAL.ManageScheduledClasses_UpdateBAL(_objPhoneNumbers);
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
        [ClaimsAuthorize("CanDeleteScheduleClassess")]
        public ActionResult ManageScheduledClasses_Destroy([DataSourceRequest] DataSourceRequest request, CRM_classPersonMapping _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                _objPhoneNumbers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPhoneNumbers.UpdatedOn = DateTime.Now;
                var results = _PersonBAL.ManageScheduledClasses_DeleteBAL(_objPhoneNumbers);
                if (results == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objPhoneNumbers };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }




        #endregion

        #region classes

        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewProposedCourses")]
        public ActionResult ProposedCourses(long PersonID)
        {
            return PartialView("ProposedCourses", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewProposedCourses")]
        public ActionResult ManageProposedCourses_Read([DataSourceRequest] DataSourceRequest request, long PersonID)
        {
            var _Phone = _PersonBAL.ManageProposedCourses_GetAllBAL(Convert.ToInt64(PersonID));
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonPhone")]
        public ActionResult ManageProposedCourses_Create([DataSourceRequest] DataSourceRequest request, CRM_CourseMapping _mapping, long oid)
        {
            if (ModelState.IsValid)
            {
                _mapping.PersonID = oid;
                if (_PersonBAL.ManageCourse_DuplicationCheckBAL(_mapping) > 0)
                {
                    ModelState.AddModelError(lr.DubliocationHappen, lr.DubliocationHappen);
                }
                else
                {
                    _mapping.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _mapping.CreatedOn = DateTime.Now;

                    _mapping.ID = _PersonBAL.ManageProposedCourses_CreateBAL(_mapping);
                }
            }
            var resultData = new[] { _mapping };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonPhone")]
        public ActionResult ManageProposedCourses_Update([DataSourceRequest] DataSourceRequest request, CRM_CourseMapping _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                //if (_objPersonContactBAL.PersonPhoneNumbers_DuplicationCheckBAL(_objPhoneNumbers, Convert.ToInt64(pid)) > 0)
                //{
                //    ModelState.AddModelError(lr.PersonPhoneNumber, lr.PersonPhoneDuplication);
                //}
                //   else
                //  {
                _objPhoneNumbers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPhoneNumbers.UpdatedOn = DateTime.Now;
                var result = _PersonBAL.ManageProposedCourses_UpdateBAL(_objPhoneNumbers);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
                //  }
            }
            var resultData = new[] { _objPhoneNumbers };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanDeletePersonPhone")]
        public ActionResult ManageProposedCourses_Destroy([DataSourceRequest] DataSourceRequest request, CRM_CourseMapping _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                _objPhoneNumbers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPhoneNumbers.UpdatedOn = DateTime.Now;
                var results = _PersonBAL.ManageProposedCourses_DeleteBAL(_objPhoneNumbers);
                if (results == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objPhoneNumbers };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }


        #endregion Clsses

        #region CourseCategory

        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult CourseCategory(long PersonID)
        {
            return PartialView("CourseCategory", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult ManageCategory_Read([DataSourceRequest] DataSourceRequest request, long PersonID)
        {
            var _Phone = _PersonBAL.ManageCategory_GetAllBAL(Convert.ToInt64(PersonID));
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonPhone")]
        public ActionResult ManageCategory_Create([DataSourceRequest] DataSourceRequest request, CRM_CourseCategoryMapping _mapping, long oid)
        {
            if (ModelState.IsValid)
            {
                _mapping.PersonID = oid;
                if (_PersonBAL.ManageCourseCategory_DuplicationCheckBAL(_mapping) > 0)
                {
                    ModelState.AddModelError(lr.DubliocationHappen, lr.DubliocationHappen);
                }
                else
                {
                _mapping.CreatedBy = CurrentUser.NameIdentifierInt64;
                _mapping.CreatedOn = DateTime.Now;

                _mapping.ID = _PersonBAL.ManageCategory_CreateBAL(_mapping);
                  }
            }
            var resultData = new[] { _mapping };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonPhone")]
        public ActionResult ManageCategory_Update([DataSourceRequest] DataSourceRequest request, CRM_CourseCategoryMapping _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                //if (_objPersonContactBAL.ManageCourseCategory_DuplicationCheckBAL(_objPhoneNumbers, Convert.ToInt64(pid)) > 0)
                //{
                //   ModelState.AddModelError(lr.PersonPhoneNumber, lr.PersonPhoneDuplication);
                //}
                //   else
                // {
                _objPhoneNumbers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPhoneNumbers.UpdatedOn = DateTime.Now;
                var result = _PersonBAL.ManageCategory_UpdateBAL(_objPhoneNumbers);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
                 //}
            }
            var resultData = new[] { _objPhoneNumbers };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanDeletePersonPhone")]
        public ActionResult ManageCategory_Destroy([DataSourceRequest] DataSourceRequest request, CRM_CourseCategoryMapping _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                _objPhoneNumbers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPhoneNumbers.UpdatedOn = DateTime.Now;
                var results = _PersonBAL.ManageCategory_DeleteBAL(_objPhoneNumbers);
                if (results == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objPhoneNumbers };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }


        #endregion CourseCategory

        #region AssignedTo

        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult AssignedTo(long PersonID)
        {
            return PartialView("AssignedTo", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult ManageAssigned_Read([DataSourceRequest] DataSourceRequest request, long PersonID)
        {
            var _Phone = _PersonBAL.ManageAssigned_GetAllBAL(Convert.ToInt64(PersonID));
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }



        #endregion AssignedTo

        #region HowHeard

        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult HowHeard(long PersonID)
        {
            return PartialView("HowHeard", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult ManageHowHeard_Read([DataSourceRequest] DataSourceRequest request, long PersonID)
        {
            var _Phone = _PersonBAL.ManageHowHeard_GetAllBAL(Convert.ToInt64(PersonID));
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonPhone")]
        public ActionResult ManageHowHeard_Create([DataSourceRequest] DataSourceRequest request, CRMHowHeardMapping _mapping, long oid)
        {
            if (ModelState.IsValid)
            {
                var _Phone = _PersonBAL.ManageHowHeard_GetAllBAL(Convert.ToInt64(oid));
                bool flage = false;
                foreach (var x in _Phone)
                {
                    if (_mapping.HowHeardID == x.HowHeardID)
                    {
                        flage = true;
                        break;
                    }
                }
                if (flage)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
                else
                {


                    _mapping.PersonID = oid;

                    _mapping.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _mapping.CreatedOn = DateTime.Now;

                    _mapping.ID = _PersonBAL.ManageHowHeard_CreateBAL(_mapping);
                }

            }
            var resultData = new[] { _mapping };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonPhone")]
        public ActionResult ManageHowHeard_Update([DataSourceRequest] DataSourceRequest request, CRMHowHeardMapping _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                //if (_objPersonContactBAL.PersonPhoneNumbers_DuplicationCheckBAL(_objPhoneNumbers, Convert.ToInt64(pid)) > 0)
                //{
                //    ModelState.AddModelError(lr.PersonPhoneNumber, lr.PersonPhoneDuplication);
                //}
                //   else
                //  {
                var _Phone = _PersonBAL.ManageHowHeard_GetAllBAL(Convert.ToInt64(_objPhoneNumbers.PersonID));
                bool flage = false;
                foreach (var x in _Phone)
                {
                    if (_objPhoneNumbers.HowHeardID == x.HowHeardID)
                    {
                        flage = true;
                        break;
                    }
                }
                if (flage)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
                else
                {
                    _objPhoneNumbers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                    _objPhoneNumbers.UpdatedOn = DateTime.Now;
                    var result = _PersonBAL.ManageHowHeard_UpdateBAL(_objPhoneNumbers);
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
        public ActionResult ManageHowHeard_Destroy([DataSourceRequest] DataSourceRequest request, CRMHowHeardMapping _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                _objPhoneNumbers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPhoneNumbers.UpdatedOn = DateTime.Now;
                var results = _PersonBAL.ManageHowHeard_DeleteBAL(_objPhoneNumbers);
                if (results == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objPhoneNumbers };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }


        #endregion Clsses



        #region RecordCall

        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult RecordCall(long PersonID)
        {
            return PartialView("RecordCall", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult ManageRecordCall_Read([DataSourceRequest] DataSourceRequest request, long PersonID)
        {
            var _Phone = _PersonBAL.ManageRecordCall_GetAllBAL(Convert.ToInt64(PersonID));
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonPhone")]
        public ActionResult ManageRecordCall_Create([DataSourceRequest] DataSourceRequest request, CRM_CallManager _mapping, long oid)
        {
            if (ModelState.IsValid)
            {
                _mapping.PersonID = oid;

                _mapping.CreatedBy = CurrentUser.NameIdentifierInt64;
                _mapping.CreatedOn = DateTime.Now;

                _mapping.ID = _PersonBAL.ManageRecordCall_CreateBAL(_mapping);

            }
            var resultData = new[] { _mapping };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonPhone")]
        public ActionResult ManageForword_Create([DataSourceRequest] DataSourceRequest request, long pid)
        {
            CRM_CallManager _mapping = new CRM_CallManager();
            if (ModelState.IsValid)
            {
                _mapping.PersonID = pid;

                _mapping.CreatedBy = CurrentUser.NameIdentifierInt64;
                _mapping.AssignedTo = CurrentUser.NameIdentifierInt64;
                _mapping.CreatedOn = DateTime.Now;
                _mapping.CallTime = DateTime.Now;
                _mapping.CallType = Calltype.Forwarded;
                _mapping.Notes = "System Generated Call";
                _mapping.PerformedBy = CurrentUser.NameIdentifierInt64.ToString();


                _mapping.ID = _PersonBAL.ManageRecordCall_CreateBAL(_mapping);

            }
            var resultData = new[] { _mapping };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonPhone")]
        public ActionResult ManageRecordCall_Update([DataSourceRequest] DataSourceRequest request, CRM_CallManager _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                //if (_objPersonContactBAL.PersonPhoneNumbers_DuplicationCheckBAL(_objPhoneNumbers, Convert.ToInt64(pid)) > 0)
                //{
                //    ModelState.AddModelError(lr.PersonPhoneNumber, lr.PersonPhoneDuplication);
                //}
                //   else
                //  {
                _objPhoneNumbers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPhoneNumbers.UpdatedOn = DateTime.Now;
                var result = _PersonBAL.ManageRecordCall_UpdateBAL(_objPhoneNumbers);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
                //  }
            }
            var resultData = new[] { _objPhoneNumbers };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanDeletePersonPhone")]
        public ActionResult ManageRecordCall_Destroy([DataSourceRequest] DataSourceRequest request, CRM_CallManager _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                _objPhoneNumbers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPhoneNumbers.UpdatedOn = DateTime.Now;
                var results = _PersonBAL.ManageRecordCall_DeleteBAL(_objPhoneNumbers);
                if (results == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objPhoneNumbers };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }


        #endregion Clsses


        #region Visit History

        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult RecordVisit(long PersonID)
        {
            return PartialView("RecordVisit", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult ManageRecordVisit_Read([DataSourceRequest] DataSourceRequest request, long PersonID)
        {
            var _Phone = _PersonBAL.ManageRecordVisit_GetAllBAL(Convert.ToInt64(PersonID));
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonPhone")]
        public ActionResult ManageRecordVisit_Create([DataSourceRequest] DataSourceRequest request, CRM_VisitHistory _mapping, long oid)
        {
            if (ModelState.IsValid)
            {
                _mapping.PersonID = oid;

                _mapping.CreatedBy = CurrentUser.NameIdentifierInt64;
                _mapping.CreatedOn = DateTime.Now;

                _mapping.ID = _PersonBAL.ManageRecordVisit_CreateBAL(_mapping);

            }
            var resultData = new[] { _mapping };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditPersonPhone")]
        public ActionResult ManageRecordVisit_Update([DataSourceRequest] DataSourceRequest request, CRM_VisitHistory _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                //if (_objPersonContactBAL.PersonPhoneNumbers_DuplicationCheckBAL(_objPhoneNumbers, Convert.ToInt64(pid)) > 0)
                //{
                //    ModelState.AddModelError(lr.PersonPhoneNumber, lr.PersonPhoneDuplication);
                //}
                //   else
                //  {
                _objPhoneNumbers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPhoneNumbers.UpdatedOn = DateTime.Now;
                var result = _PersonBAL.ManageRecordVisit_UpdateBAL(_objPhoneNumbers);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
                //  }
            }
            var resultData = new[] { _objPhoneNumbers };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanDeletePersonPhone")]
        public ActionResult ManageRecordVisit_Destroy([DataSourceRequest] DataSourceRequest request, CRM_VisitHistory _objPhoneNumbers)
        {
            if (ModelState.IsValid)
            {
                _objPhoneNumbers.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPhoneNumbers.UpdatedOn = DateTime.Now;
                var results = _PersonBAL.ManageRecordVisit_DeleteBAL(_objPhoneNumbers);
                if (results != -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objPhoneNumbers };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }


        #endregion Visit History


        #region AssignedTo

        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult AssigmentHistory(long PersonID)
        {
            return PartialView("AssigmentHistory", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult AssigmentHistory_Read([DataSourceRequest] DataSourceRequest request, long PersonID)
        {
            var _Phone = _PersonBAL.AssigmentHistory_GetAllBAL(Convert.ToInt64(PersonID));
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }



        #endregion AssignedTo


        #region AssignedTo

        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult EnrolmentHistory(long PersonID)
        {
            return PartialView("EnrolmentHistory", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonPhone")]
        public ActionResult EnrolmentHistory_Read([DataSourceRequest] DataSourceRequest request, long PersonID)
        {
            var _Phone = _PersonBAL.EnrolmentHistory_GetAllBAL(Convert.ToInt64(PersonID));
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }



        #endregion AssignedTo
    }
}