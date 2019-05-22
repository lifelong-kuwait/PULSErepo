using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Business.Interfaces;
using TMS.Business.Interfaces.Common;
using TMS.Business.Interfaces.Common.Groups;
using TMS.Business.Interfaces.TMS;
using TMS.Common;
using TMS.Common.Utilities;
using TMS.Library.Common.Address;
using TMS.Library.Common.Attachment;
using TMS.Library;
using TMS.Library.TMS.Persons;
using TMS.Library.TMS.Persons.Others;
using TMS.Library.TMS.Trainer;
using TMS.Library.Users;
using lr = Resources.Resources;

namespace TMS.Web.Controllers
{
    public class TrainerController : TMSControllerBase
    {
        private IBALUsers _UserBAL { get; set; }
        private readonly IAttachmentBAL _AttachmentBAL;
        private readonly IGroupsBAL _Groups;
        private readonly IPersonBAL _PersonBAL;
        private readonly ITrainerBAL _TrainerBAL;
        private readonly IPersonContactBAL _objPersonContactBAL;

        public TrainerController(IBALUsers balUser,ITrainerBAL objITrainerBAL,IAttachmentBAL objIAttachmentBAL, IGroupsBAL _Groups, IPersonBAL objIPersonBAL, IPersonContactBAL _objePersonContact)
        {
             _UserBAL = balUser; _TrainerBAL = objITrainerBAL; _AttachmentBAL = objIAttachmentBAL; this._Groups = _Groups; _PersonBAL = objIPersonBAL; _objPersonContactBAL = _objePersonContact;
        }

        #region Trainer
        // GET: Trainer
        [ActivityAuthorize]
        [ClaimsAuthorizeAttribute("CanViewPerson")]
        public ActionResult Index(long pT)
        {
            //if (pT == 0) { pT = (int)personType.Person; }
            ViewData["Role"] = pT;
            return View(pT);
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

        [ClaimsAuthorizeAttribute("CanViewPerson")]
        [DontWrapResult]
        [ActivityAuthorize]
        public ActionResult Trainer_Read([DataSourceRequest] DataSourceRequest request,long RoleID)
        {

            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            long ClassID = 0;
            ClassID = Convert.ToInt64(Request.QueryString["ClassId"]);
           
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            //   int Total
                if (CurrentUser.CompanyID > 0)
            {
                var _trainer = this._TrainerBAL.TrainerOrganization_GetAllBAL(CurrentCulture, RoleID, Convert.ToString(CurrentUser.CompanyID), SearchText);
                    return Json(_trainer.ToDataSourceResult(request, ModelState));
            }
            //var result = new DataSourceResult()
            //{
            //    Data = _trainer, // Process data (paging and sorting applied)
            //    Total = Total // Total number of records
            //};
            //return Json(result);
            else
            {
                var _trainer = this._TrainerBAL.Trainer_GetAllBAL(CurrentCulture, RoleID, Convert.ToString(CurrentUser.CompanyID), SearchText);
                   return Json(_trainer.ToDataSourceResult(request, ModelState));

            }
        }

        [ClaimsAuthorizeAttribute("CanAddEditPerson")]
        [DontWrapResult]
        [ActivityAuthorize]
        public ActionResult Trainer_Create([DataSourceRequest] DataSourceRequest request, Trainer _objTrainer,long RoleID)
        {
            if (ModelState.IsValid)
            {
                bool _valid = false;
                if (_objTrainer.Email != null)//when Email is Provided
                {
                    _valid = true;
                }
                else if (_objTrainer.ContactNumber != null)//when Contact number is provided
                {
                    if (_objTrainer.CountryCode == 0)//when country code is  provided
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
                    _objTrainer.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _objTrainer.CreatedDate = DateTime.Now;
                    _objTrainer.OrganizationID = CurrentUser.CompanyID;
                    string _profilePict = string.Empty;
                    var Resp = SavePersonData(_objTrainer, ref _profilePict,RoleID);
                    _objTrainer.AddedByAlias = CurrentUser.Name;
                    _objTrainer.ID = Resp.ID;
                    _objTrainer.PersonRegCode = Resp.PersonRegCode;
                    _objTrainer.ProfilePicture = _profilePict;
                    if (_objTrainer.ID != long.MinValue)
                    {
                        if (_objTrainer.ContactNumber != null)//when ContactNumber is Provided
                        {
                            PhoneNumbers _objPhoneNumbers = new PhoneNumbers
                            {
                                ContactNumber = _objTrainer.ContactNumber,
                                CountryCode = _objTrainer.CountryCode,
                                IsPrimary = true,
                                Extension = _objTrainer.Extension,
                                CreatedBy = CurrentUser.NameIdentifierInt64,
                                CreatedDate = DateTime.Now
                            };
                            _objTrainer.PhoneID = _objPersonContactBAL.PersonPhoneNumbers_CreateBAL(_objPhoneNumbers, _objTrainer.ID);
                        }
                        if (_objTrainer.Email != null)//when Email is Provided
                        {
                            EmailAddresses _objEmailAddresses = new EmailAddresses
                            {
                                Email = _objTrainer.Email,
                                IsPrimary = true,
                                CreatedBy = CurrentUser.NameIdentifierInt64,
                                CreatedDate = DateTime.Now
                            };
                            _objTrainer.EmailID = _objPersonContactBAL.PersonEmailAddress_CreateBAL(_objEmailAddresses, _objTrainer.ID);
                        }
                    }
                }
            }

            var resultData = new[] { _objTrainer };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }


        [ClaimsAuthorizeAttribute("CanAddEditPerson")]
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public ActionResult Trainer_Update([DataSourceRequest] DataSourceRequest request, Trainer _objTrainer, string filename, long aid)
        {
            _objTrainer.UpdatedBy = CurrentUser.NameIdentifierInt64;
            _objTrainer.UpdatedDate = DateTime.Now;

            bool _valid = false;
            if (_objTrainer.Email != null)//when Email is Provided
            {
                _valid = true;
            }
            else if (_objTrainer.ContactNumber != null)//when Contact number is provided
            {
                if (_objTrainer.CountryCode == 0)//when country code is  provided
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
                var result = _TrainerBAL.Trainer_UpdateBAL(_objTrainer);
                _objTrainer.ProfilePicture = HandlePersonProfilePicture(filename, _objTrainer.ID, aid);
                if (result != -1)
                {
                    if (_objTrainer.PhoneID > 0)
                    {
                        if (_objTrainer.ContactNumber != null)
                        {
                            if (_objTrainer.CountryCode != 0)//when country code is  provided
                            {
                                PhoneNumbers _objPhoneNumbers = new PhoneNumbers
                                {
                                    ID = _objTrainer.PhoneID,
                                    ContactNumber = _objTrainer.ContactNumber,
                                    CountryCode = _objTrainer.CountryCode,
                                    IsPrimary = true,
                                    Extension = _objTrainer.Extension,
                                    UpdatedBy = CurrentUser.NameIdentifierInt64,
                                    UpdatedDate = DateTime.Now
                                };
                                _objPersonContactBAL.PersonPhoneNumbers_UpdateBAL(_objPhoneNumbers, _objTrainer.ID);
                            }
                            else
                            {
                            }
                        }
                    }
                    else
                    {
                        if (_objTrainer.ContactNumber != null)//when Contact number is provided
                        {
                            if (_objTrainer.CountryCode == 0)//when country code is  provided
                            {
                                ModelState.AddModelError(lr.PersonPhoneCountryCode, lr.PersonPhoneNumberProvideCountryocde);
                            }
                            else
                            {
                                PhoneNumbers _objPhoneNumbers = new PhoneNumbers
                                {
                                    ID = _objTrainer.PhoneID,
                                    ContactNumber = _objTrainer.ContactNumber,
                                    CountryCode = _objTrainer.CountryCode,
                                    IsPrimary = true,
                                    Extension = _objTrainer.Extension,
                                    CreatedBy = CurrentUser.NameIdentifierInt64,
                                    CreatedDate = DateTime.Now
                                };
                                _objTrainer.PhoneID = _objPersonContactBAL.PersonPhoneNumbers_CreateBAL(_objPhoneNumbers, _objTrainer.ID);
                            }
                        }
                    }
                    if (_objTrainer.EmailID > 0)
                    {
                        if (_objTrainer.Email != null)//when Email is Provided
                        {
                            EmailAddresses _objEmailAddresses = new EmailAddresses
                            {
                                ID = _objTrainer.EmailID,
                                Email = _objTrainer.Email,
                                IsPrimary = true,
                                UpdatedBy = CurrentUser.NameIdentifierInt64,
                                UpdatedDate = DateTime.Now
                            };
                            _objPersonContactBAL.PersonEmailAddress_UpdateBAL(_objEmailAddresses, _objTrainer.ID);
                        }
                    }
                    else
                    {
                        if (_objTrainer.Email != null)//when Email is Provided
                        {
                            EmailAddresses _objEmailAddresses = new EmailAddresses
                            {
                                Email = _objTrainer.Email,
                                IsPrimary = true,
                                CreatedBy = CurrentUser.NameIdentifierInt64,
                                CreatedDate = DateTime.Now
                            };
                            _objTrainer.EmailID = _objPersonContactBAL.PersonEmailAddress_CreateBAL(_objEmailAddresses, _objTrainer.ID);
                        }
                    }
                }
            }
            var resultData = new[] { _objTrainer };
            if (_objTrainer.Flags != null)
                _objTrainer.Flags = _objTrainer.Flags.Where(i => i != null).ToList();
            //return Json(new object[0].ToDataSourceResult(request, ModelState));
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorizeAttribute("CanDeletePerson")]
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public ActionResult Trainer_Destroy([DataSourceRequest] DataSourceRequest request, Trainer _objTrainer)
        {
            //ModelState.Remove("Password");
            //ModelState.Remove("ConfirmPassword");
            if (ModelState.IsValid)
            {
                _objTrainer.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objTrainer.UpdatedDate = DateTime.Now;
                var result = this._TrainerBAL.Trainer_DeleteBAL(_objTrainer);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objTrainer };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [NonAction]
        public Library.TMS.Trainer.PersonResponse SavePersonData(Trainer _objTrainer, ref string _profilePict,long RoleID)
        {
            var result = _TrainerBAL.PersonInsertNewPersonBAL(_objTrainer,RoleID);
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

        #region View Detail Card

        [ClaimsAuthorizeAttribute("CanViewPersonDetail")]
        public ActionResult DetailCard(string pid)
        {
            Session["pid"] = pid;
            if (string.IsNullOrEmpty(pid))
            {
                return RedirectPermanent(Url.Content("~/Trainer/Index"));
            }
            else
            {
                var data = _TrainerBAL.Trainer_GetAllByIdBALdetailCard(pid);
                if (data == null)
                {
                    ViewData["model"] = Url.Content("~/Trainer/Index");
                    return View("Static/NotFound");
                }
                else
                {
                    ViewData["model"] = data;
                    return View();
                }
            }
        }

        [DontWrapResult]
        [ClaimsAuthorizeAttribute("CanViewPersonDetail")]
        public ActionResult TraineeDetailCard(string pid)
        {
            Session["pid"] = pid;
            if (string.IsNullOrEmpty(pid))
            {
                return RedirectPermanent(Url.Content("~/Trainer/Index"));
            }
            else
            {
                var data = _TrainerBAL.Trainer_GetAllByIdBALdetailCard(pid);
                if (data == null)
                {
                    ViewData["model"] = Url.Content("~/Trainer/Index");
                    return View("Static/NotFound");
                }
                else
                {
                    ViewData["model"] = data;
                    return View();
                }
            }
        }

        #endregion

        #region View Registration Card

        [ClaimsAuthorizeAttribute("CanViewPersonDetail")]
        public ActionResult RegistrationSlip(string pid)
        {
            if (string.IsNullOrEmpty(pid))
            {
                return RedirectPermanent(Url.Content("~/Trainer/Index"));
            }
            else
            {
                var data = _TrainerBAL.Trainer_GetAllByIdBALdetailCard(pid);
                if (data == null)
                {
                    ViewData["model"] = Url.Content("~/Trainer/Index");
                    return View("Static/NotFound");
                }
                else
                {
                    ViewData["model"] = data;
                    return View();
                }
            }
        }

        [ClaimsAuthorizeAttribute("CanViewPersonDetail")]
        public ActionResult TraineeRegistrationSlip(string pid)
        {
            if (string.IsNullOrEmpty(pid))
            {
                return RedirectPermanent(Url.Content("~/Trainer/Index"));
            }
            else
            {
                var data = _TrainerBAL.Trainer_GetAllByIdBALdetailCard(pid);
                if (data == null)
                {
                    ViewData["model"] = Url.Content("~/Trainer/Index");
                    return View("Static/NotFound");
                }
                else
                {
                    ViewData["model"] = data;
                    return View();
                }
            }
        }

        #endregion

        #region View Class Detail
        [ClaimsAuthorizeAttribute("CanViewPersonDetail")]
        public ActionResult ClassDetail(string pid)
        {
            if (string.IsNullOrEmpty(pid))
            {
                return RedirectPermanent(Url.Content("~/Trainer/Index"));
            }
            else
            {
                var data = _TrainerBAL.Trainer_GetAllByIdBALdetailCard(pid);
                if (data == null)
                {
                    ViewData["model"] = Url.Content("~/Trainer/Index");
                    return View("Static/NotFound");
                }
                else
                {
                    ViewData["model"] = data;
                    return View();
                }
            }
        }

        [ClaimsAuthorizeAttribute("CanViewPersonDetail")]
        public ActionResult TraineeClassDetail(string pid)
        {
            if (string.IsNullOrEmpty(pid))
            {
                return RedirectPermanent(Url.Content("~/Trainer/Index"));
            }
            else
            {
                var data = _TrainerBAL.Trainer_GetAllByIdBALdetailCard(pid);
                if (data == null)
                {
                    ViewData["model"] = Url.Content("~/Trainer/Index");
                    return View("Static/NotFound");
                }
                else
                {
                    ViewData["model"] = data;
                    return View();
                }
            }
        }

        #endregion

        #region"Groups"

        [DontWrapResult]
        public JsonResult UserLoginGroups()
        {
            return Json(this._Groups.TMS_Groups_GetAllByCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}