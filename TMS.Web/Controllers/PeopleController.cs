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
using Abp.Runtime.Validation;
using TMS.Web.Core;
using System.Collections.Generic;
using TMS.Business.Interfaces.TMS.Program;
using System.Web.Script.Serialization;

namespace TMS.Web.Controllers
{
    [SessionTimeout]
    public class PeopleController : TMSControllerBase
    {
        private readonly IAttachmentBAL _AttachmentBAL;
        private readonly IPersonBAL _PersonBAL;
        private readonly IBALUsers _UserBAL;
        private readonly ITrainerBAL _TrainerBAL;
        private readonly IPersonContactBAL _objPersonContactBAL;
        private readonly IConfigurationBAL _objConfigurationBAL;
        private readonly IClassBAL _ClassBAL;

        public PeopleController(IAttachmentBAL objIAttachmentBAL, IClassBAL IClassBAL,IConfigurationBAL _objIConfigurationBAL, ITrainerBAL objITrainerBAL, IPersonBAL objIPersonBAL, IBALUsers objUserBAL, IPersonContactBAL _objePersonContact)
        {
            _objConfigurationBAL = _objIConfigurationBAL; _ClassBAL = IClassBAL; _AttachmentBAL = objIAttachmentBAL; _TrainerBAL = objITrainerBAL; _PersonBAL = objIPersonBAL; _UserBAL = objUserBAL; _objPersonContactBAL = _objePersonContact;
        }

        #region Person

        //[ClaimsAuthorizeAttribute("CanViewPerson")]
        public ActionResult Person(long pT)
        {
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to View Persons " + DateTime.UtcNow, "", 0, "People", "Person", pT.ToString(), CurrentUser.CompanyID);
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
                    ViewData["model"] = Url.Content("~/People/PersonActive?pT=0");
                    return View("Static/NotFound");
                }
                else
                {
                    _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to View Persons Detail " + DateTime.UtcNow, "", 0, "People", "Detail", pid.ToString(), CurrentUser.CompanyID);
                    ViewData["model"] = data;
                    return View();
                }
            }
        }

        [ClaimsAuthorizeAttribute("CanViewPerson")]
        public ActionResult PersonActive(long pT)
        {
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to View Active Persons " + DateTime.UtcNow, "", 0, "People", "Person", pT.ToString(), CurrentUser.CompanyID);

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
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to View others" + DateTime.UtcNow, "", 0, "People", "others", pid.ToString(), CurrentUser.CompanyID);

            return PartialView("_DetailOthers", pid);
        }
        //CanViewPersonByOrganization

        //[ClaimsAuthorizeAttribute("CanViewPerson")]
        [DontWrapResult]
        public ActionResult Person_Read([DataSourceRequest]DataSourceRequest request, long RoleID)
         {
            var list = this._ClassBAL.personRoleGroups(CurrentUser.NameIdentifierInt64);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to Read Persons " + DateTime.UtcNow, "", 0, "People", "Person_Read", RoleID.ToString(), CurrentUser.CompanyID);
             long PersonId = 0;
            if (list.Count == 1 && list[0].PrimaryGroupName == "Trainer")
            {
                PersonId = CurrentUser.NameIdentifierInt64;
            }
            //var startRowIndex = (request.Page - 1) * request.PageSize;
            //int Total = 0;
            //var SearchText = Request.Form["SearchText"];
            //if (request.PageSize == 0)
            //{
            //    request.PageSize = 10; 
            //}
            var kendoRequest = new Kendo.Mvc.UI.DataSourceRequest
            {
               
                Filters = request.Filters,
                Sorts = request.Sorts,
                Groups = request.Groups,
                Aggregates = request.Aggregates
            };
            var startRowIndex = (request.Page - 1) * request.PageSize;
               int Total = 0;
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
            else
            {
                if (CurrentUser.CompanyID > 0)
                {
                    IList<TMS.Library.TMS.Trainer.Trainer> _person;
                    if (kendoRequest.Filters.Count>0)
                    {
                         _person = this._TrainerBAL.TrainerOrganization_GetAllBAL(ref Total, CurrentCulture, RoleID, Convert.ToString(CurrentUser.CompanyID), SearchText, GridHelper.GetSortExpression(request, "ID").ToString(), startRowIndex, request.Page, 10000, PersonId);

                    }
                    else
                    {
                        _person = this._TrainerBAL.TrainerOrganization_GetAllBAL(ref Total, CurrentCulture, RoleID, Convert.ToString(CurrentUser.CompanyID), SearchText, GridHelper.GetSortExpression(request, "ID").ToString(), startRowIndex, request.Page, request.PageSize, PersonId);

                    }
                    //var _person = _PersonBAL.PersonOrganization_GetALLBAL(Convert.ToString(CurrentUser.CompanyID));,string SortExpression,int StartRowIndex,int page,int PageSize
                    _person = _person.Distinct().ToList();
                    var data = _person.ToDataSourceResult(kendoRequest);

                    var result = new DataSourceResult()
                    {
                        AggregateResults = data.AggregateResults,
                        Data = data.Data,
                        Errors = data.Errors,
                        Total = Total
                    };

                    //var result = new DataSourceResult()
                    //{
                    //    Data = _person, // Process data (paging and sorting applied)
                    //    Total = Total // Total number of records
                    //};
                    return Json(result);
                }
                else
                {
                    var _person = this._TrainerBAL.Trainer_GetAllBAL(CurrentCulture, RoleID, Convert.ToString(CurrentUser.CompanyID), SearchText);

                    return Json(_person.ToDataSourceResult(request, ModelState));
                }
                
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
                if (this._UserBAL.LoginUsers_DuplicationCheckBAL(new LoginUsers { Email = Email, CompanyID = CurrentUser.CompanyID }) > 0)
                {
                    return Json(lr.UserEmailAlreadyExist, JsonRequestBehavior.AllowGet);
                }
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }



        [ClaimsAuthorizeAttribute("CanAddEditPerson")]
        [DisableValidation]
        [DontWrapResult]
        public ActionResult Person_Create([DataSourceRequest] DataSourceRequest request, Person _person, long RoleID)
        {
            if (ModelState.IsValid)
            {
                bool _valid = false;
                var json = new JavaScriptSerializer().Serialize(_person);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to insert Person " + DateTime.UtcNow, "", 0, "People", "Person_Create", json.ToString(), CurrentUser.CompanyID);

                if (_UserBAL.LoginPerson_DuplicationCheckBAL(new Person { Email = _person.Email, CreatedBy = CurrentUser.CompanyID }) > 0)
                {
                    ModelState.AddModelError(lr.DubliocationHappen, lr.PersonContactEmailDuplicationCheck);
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

                    if (_person.IsLogin == true && _person.Password != null)
                    {
                       
                        if (_UserBAL.LoginUsersAsTrainer_DuplicationCheckBAL(new LoginUsers { Email = _person.Email, CompanyID = CurrentUser.CompanyID }) > 0)
                        {
                            ModelState.AddModelError(lr.UsersTitle, lr.UserEmailAlreadyExist);
                            _valid = false;
                        }
                    }

                    if (_valid)
                    {
                        //  _person.ProfilePicture = HandlePersonProfilePicture(filename, _person.ID, aid);
                        _person.CreatedBy = CurrentUser.NameIdentifierInt64;
                        _person.CreatedDate = DateTime.Now;
                        _person.OrganizationID = CurrentUser.CompanyID;
                        string _profilePict = string.Empty;
                        if (_person.DateOfBirth == null)
                            _person.DateOfBirth = DateTime.Now.AddYears(-10);
                        if (_person.ClientType == 0)
                            _person.ClientType = ClientType.ClientType_Internal;
                        if(_person.ClientType==null)
                            _person.ClientType = ClientType.Not_Specified;
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
                            if (_person.ContactNumber != null)//when ContactNumber is Provided
                            {
                                PhoneNumbers _objPhoneNumbers = new PhoneNumbers
                                {
                                    ContactNumber = _person.ContactNumber,
                                    CountryCode = _person.CountryCode,
                                    IsPrimary = true,
                                    Extension = _person.Extension,
                                    CreatedBy = CurrentUser.NameIdentifierInt64,
                                    CreatedDate = DateTime.Now,

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
                                    CreatedDate = DateTime.Now,
                                    PersonID = _person.ID,
                                    OrganizationID = _person.OrganizationID
                                };
                                _person.EmailID = _objPersonContactBAL.PersonEmailAddress_CreateBAL(_objEmailAddresses, _person.ID);
                            }
                            if (_person.IsLogin == true && _person.Password != null)
                            {

                                var person = _PersonBAL.Person_GetAllByIdBAL(Convert.ToString(Resp.ID));
                               if (_UserBAL.LoginUsersAsTrainer_DuplicationCheckBAL(new LoginUsers { Email = person.Email,CompanyID=CurrentUser.CompanyID }) > 0)
                                {
                                    ModelState.AddModelError(lr.UsersTitle, lr.UserEmailAlreadyExist);

                                }
                                else
                                {
                                    _person.Password = Crypto.CreatePasswordHash(_person.Password);
                                    _person.IsActive = true;
                                    PersonRolesMapping obj = new PersonRolesMapping();
                                    obj.PersonID = Convert.ToInt64(Resp.ID);
                                    obj.Password = _person.Password;
                                    obj.RoleID = 2;
                                    obj.CreatedBy = CurrentUser.NameIdentifierInt64;
                                    obj.CreatedDate = DateTime.Now;
                                    _PersonBAL.TMS_PersonintoUser_CreateBAL(obj);

                                }

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
        //[DisableValidation]
        public ActionResult Person_Update([DataSourceRequest] DataSourceRequest request, Person _person, string filename, long aid)
        {
            _person.UpdatedBy = CurrentUser.NameIdentifierInt64;
            _person.UpdatedDate = DateTime.Now;
            _person.ClientType = ClientType.ClientType_Internal;
            var json = new JavaScriptSerializer().Serialize(_person);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Update_Success.ToString(), System.Environment.MachineName, "User tried to Update Person " + DateTime.UtcNow, "", 0, "People", "Person_Update", json.ToString(), CurrentUser.CompanyID);

            bool _valid = false;
            if (_UserBAL.LoginPerson_DuplicationCheckUpdateBAL(new Person { Email = _person.Email, CreatedBy = CurrentUser.CompanyID,ID=_person.ID}) > 0)
            {
                ModelState.AddModelError(lr.PersonContactEmailDuplicationCheck, lr.PersonContactEmailDuplicationCheck);
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
                    if (_person.DateOfBirth == null)
                        _person.DateOfBirth = DateTime.Now.AddYears(-10);
                    if (_person.ClientType == null)
                        _person.ClientType = ClientType.Not_Specified;
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
                                    UpdatedDate = DateTime.Now,
                                    PersonID = _person.ID,
                                    OrganizationID = _person.OrganizationID
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
                                    CreatedDate = DateTime.Now,
                                    PersonID = _person.ID,
                                    OrganizationID = _person.OrganizationID
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
       // [DisableValidation]
        public ActionResult Person_Destroy([DataSourceRequest] DataSourceRequest request, Person _person)
        {
            var json = new JavaScriptSerializer().Serialize(_person);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Delete_Success.ToString(), System.Environment.MachineName, "User tried to Delete Person " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);
            if (_UserBAL.DeletePerson_CheckBAL(new ClassTrainerMapping { PersonID = _person.ID }) > 0)
            {
                //ModelState.AddModelError(lr.UserEmailAlreadyExist, lr.UserEmailAlreadyExist);
                return Json(lr.UserEmailAlreadyExist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                _person.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _person.UpdatedDate = DateTime.Now;

                var result = _PersonBAL.Person_DeleteBAL(_person);
                return Json(new object[0].ToDataSourceResult(request, ModelState));
            }


        }
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteSession")]

        public JsonResult PersonDeleteChk(string _Sessions)
        {
            var result = "";
            if (_UserBAL.DeletePerson_CheckBAL(new ClassTrainerMapping { PersonID = Convert.ToInt64(_Sessions) }) > 0)
            {
                result = _UserBAL.Person_AllAssignPersonClassesBAL(new ClassTrainerMapping { PersonID = Convert.ToInt64(_Sessions), CreatedDate = DateTime.Now });
            }
            else
            {
                result = "";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
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
            return Json(this._PersonBAL.TMS_Coordinate_GetAllByCultureBAL(CurrentCulture), JsonRequestBehavior.AllowGet);

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
            var json = new JavaScriptSerializer().Serialize(pid);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to Read Person Relations " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

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
                var json = new JavaScriptSerializer().Serialize(_objPersonRelation);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to create Person Relation " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

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
                var json = new JavaScriptSerializer().Serialize(_objPersonRelation);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Update_Success.ToString(), System.Environment.MachineName, "User tried to update Person Relation " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

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
                var json = new JavaScriptSerializer().Serialize(_objPersonRelation);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Delete_Success.ToString(), System.Environment.MachineName, "User tried to destroy Person Relation " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

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
            var json = new JavaScriptSerializer().Serialize(PersonId);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to read Person Roles " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            return PartialView("_PersonRoles", PersonId);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonRoles")]
        public ActionResult ManageRoles_Read([DataSourceRequest] DataSourceRequest request, long PersonId)
        {
            var json = new JavaScriptSerializer().Serialize(PersonId);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to read Person Roles " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var Classs = _PersonBAL.TMS_PersonRolesMapping_GetbyPersonIDBAL(PersonId, CurrentUser.CompanyID, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
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
                var json = new JavaScriptSerializer().Serialize(_objPersonRoles);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to create Person Roles " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

                _objPersonRoles.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objPersonRoles.CreatedDate = DateTime.Now;
                _objPersonRoles.PersonID = Convert.ToInt64(Request.QueryString["PersonID"]);
                CRM_EnrolmentHistory EnrolmentHistory = new CRM_EnrolmentHistory();
                EnrolmentHistory.CreatedBy = CurrentUser.NameIdentifierInt64;
                EnrolmentHistory.CreatedOn = DateTime.Now;
                EnrolmentHistory.PersonID = Convert.ToInt64(Request.QueryString["PersonID"]);
                EnrolmentHistory.RoleName = "Trainee";
                _objPersonRoles.IsActive = true;
                _objPersonRoles.ClientType = ClientType.ClientType_Internal;
                if (_objPersonRoles.IsLogin == true && _objPersonRoles.Password != null)
                {

                    var person = _PersonBAL.Person_GetAllByIdBAL(Convert.ToString(_objPersonRoles.PersonID));

                    if (_UserBAL.LoginUsersAsTrainer_DuplicationCheckBAL(new LoginUsers { Email = person.Email,CompanyID=CurrentUser.CompanyID }) > 0)
                    {
                        ModelState.AddModelError(lr.UsersTitle, lr.UserEmailAlreadyExist);
                        if (_PersonBAL.TMS_PersonRolesMapping_DuplicationCheckBAL(_objPersonRoles) > 0)
                        {
                            ModelState.AddModelError(lr.DubliocationHappen, lr.RoleName);
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
                        _objPersonRoles.IsActive = true;
                        _PersonBAL.TMS_PersonintoUser_CreateBAL(_objPersonRoles);
                        if (_PersonBAL.TMS_PersonRolesMapping_DuplicationCheckBAL(_objPersonRoles) > 0)
                        {
                            ModelState.AddModelError(lr.DubliocationHappen, lr.RoleName);
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
                        ModelState.AddModelError(lr.DubliocationHappen, lr.RoleName);
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
                var json = new JavaScriptSerializer().Serialize(_objPersonRoles);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Update_Success.ToString(), System.Environment.MachineName, "User tried to update Person Roles " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

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
                var json = new JavaScriptSerializer().Serialize(_objPersonRoles);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Delete_Success.ToString(), System.Environment.MachineName, "User tried to delete Person Roles " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

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
        #region CRM Roles
        [ClaimsAuthorize("CanViewPersonRolesCRM")]
        [DontWrapResult]
        public ActionResult ManageRolesCRM(long PersonId)
        {
            var json = new JavaScriptSerializer().Serialize(PersonId);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to read CRM Person Roles " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);
            return PartialView("_PersonRolesCRM", PersonId);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonRolesCRM")]
        public ActionResult ManageRoles_ReadCRM([DataSourceRequest] DataSourceRequest request, long PersonId)
        {
            var json = new JavaScriptSerializer().Serialize(PersonId);
            _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to read CRM Person Roles " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var Classs = _PersonBAL.TMS_PersonRolesMapping_GetbyPersonIDBAL(PersonId, CurrentUser.CompanyID, startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
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
        public ActionResult ManageRoles_CreateCRM([DataSourceRequest] DataSourceRequest request, PersonRolesMapping _objPersonRoles)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_objPersonRoles);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to create CRM Person Roles " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);
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
                            ModelState.AddModelError(lr.DubliocationHappen, lr.RoleName);
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
                            ModelState.AddModelError(lr.DubliocationHappen, lr.RoleName);
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
                        ModelState.AddModelError(lr.DubliocationHappen, lr.RoleName);
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
        public ActionResult ManageRoles_UpdateCRM([DataSourceRequest] DataSourceRequest request, PersonRolesMapping _objPersonRoles)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_objPersonRoles);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Update_Success.ToString(), System.Environment.MachineName, "User tried to update CRM Person Roles " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

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
        public ActionResult ManageRoles_DestroyCRM([DataSourceRequest] DataSourceRequest request, PersonRolesMapping _objPersonRoles)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_objPersonRoles);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Delete_Success.ToString(), System.Environment.MachineName, "User tried to destroy CRM Person Roles " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);

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

        #endregion
    }
}