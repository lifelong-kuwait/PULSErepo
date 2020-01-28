using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using TMS.Business.Interfaces.Common;
using TMS.Business.Interfaces.Common.Configuration;
using TMS.Business.Interfaces.TMS.Program;
using TMS.Library;
using TMS.Library.Common.Attachment;
using TMS.Library.Entities.Common.Configuration;
using TMS.Library.Entities.Common.Configuration.Categories;
using TMS.Library.Entities.Common.Configuration.Vendor;
using TMS.Library.Entities.Common.Configuration.Venues;
using TMS.Library.Entities.Common.Roles;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS.Admin.Config;
using TMS.Web.Core;
using lr = Resources.Resources;

namespace TMS.Web.Controllers
{
    [SessionTimeout]
    public class ConfigController : TMSControllerBase
    {
        private readonly IConfigurationBAL _objConfigurationBAL;
        private readonly IClassBAL _ClassBAL;
        private readonly IAttachmentBAL _AttachmentBAL;
        public ConfigController(IConfigurationBAL _objIConfigurationBAL, IClassBAL _ClassIBAL, IAttachmentBAL _AttachmentBAL)
        {
            _objConfigurationBAL = _objIConfigurationBAL; _ClassBAL = _ClassIBAL; this._AttachmentBAL = _AttachmentBAL;
        }

        #region Flags

        [ClaimsAuthorize("CanViewFlags")]
        [DontWrapResult]
        public ActionResult Flags()
        {
            return View();
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewFlags")]
        public ActionResult Flags_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
           // var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }


            if (CurrentUser.CompanyID > 0)
            {
                var _Phone = _objConfigurationBAL.PersonFlagsbyOrganization_GetALLBAL(Convert.ToString(CurrentUser.CompanyID));
                return Json(_Phone.ToDataSourceResult(request, ModelState));
            }
            else {
                var _Phone = _objConfigurationBAL.PersonFlags_GetALLBAL();
                return Json(_Phone.ToDataSourceResult(request, ModelState));
            }
            //var startRowIndex = (request.Page - 1) * request.PageSize;
            //int Total = 0;
            //var SearchText = Request.Form["SearchText"];
            //if (request.PageSize == 0)
            //{
            //    request.PageSize = 10;
            //}
            //var _Phone = _objConfigurationBAL.PersonFlags_GetALLBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);

            //if (CurrentUser.CompanyID > 0)
            //{
            //   _Phone = _objConfigurationBAL.PersonFlagsbyOrganization_GetALLBAL(Convert.ToString(CurrentUser.CompanyID), startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            //  //  return Json(_Phone.ToDataSourceResult(request, ModelState));
            //}
            //else
            //{
            //    // return Json(_Phone.ToDataSourceResult(request, ModelState));
            //}
            //var result = new DataSourceResult()
            //{
            //    Data = _Phone, // Process data (paging and sorting applied)
            //    Total = Total // Total number of records
            //};
            //return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditFlags")]
        public ActionResult Flags_Create([DataSourceRequest] DataSourceRequest request, PersonFlags _objPersonFlags)
        {
            if (ModelState.IsValid)
            {
              
                _objPersonFlags.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objPersonFlags.CreatedDate = DateTime.Now;
                _objPersonFlags.OrganizationID = CurrentUser.CompanyID;
                if (_objConfigurationBAL.PersonFlags_DuplicationCheckBAL(_objPersonFlags,CurrentUser.CompanyID) > 0)
                {
                    ModelState.AddModelError(lr.PersonSkill, lr.FlagDuplicationCheck);
                }
                else
                {
                    _objPersonFlags.ID = _objConfigurationBAL.PersonFlags_CreateBAL(_objPersonFlags);

                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                   // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                   // string browserName = req.Browser.Browser;
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64,EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);
                }
            }
            var resultData = new[] { _objPersonFlags };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditFlags")]
        public ActionResult Flags_Update([DataSourceRequest] DataSourceRequest request, PersonFlags _objPersonFlags)
        {
            if (ModelState.IsValid)
            {
                _objPersonFlags.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPersonFlags.UpdatedDate = DateTime.Now;
                if (_objConfigurationBAL.PersonFlags_DuplicationCheckBAL(_objPersonFlags,CurrentUser.CompanyID) > 0)
                {
                    ModelState.AddModelError(lr.PersonSkill, lr.FlagDuplicationCheck);
                }
                else
                {
                  //  _objPersonFlags.ID = _objConfigurationBAL.PersonFlags_CreateBAL(_objPersonFlags);

                  
                    var result = _objConfigurationBAL.PersonFlags_UpdateBAL(_objPersonFlags);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    // var req = System.Web.HttpContext.Current.Request.Browser.Browser;
                    // string browserName = req.Browser.Browser;
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);

                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
            }
            var resultData = new[] { _objPersonFlags };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteFlags")]
        public ActionResult Flags_Destroy([DataSourceRequest] DataSourceRequest request, PersonFlags _objPersonFlags)
        {
            if (ModelState.IsValid)
            {
                _objPersonFlags.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objPersonFlags.UpdatedDate = DateTime.Now;
                var result = _objConfigurationBAL.PersonFlags_DeleteBAL(_objPersonFlags);
               // _objPersonFlags.ID = _objConfigurationBAL.PersonFlags_CreateBAL(_objPersonFlags);

                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (!result)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objPersonFlags };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion Flags

        #region Venues

        [ClaimsAuthorize("CanViewVenue")]
        [DontWrapResult]
        public ActionResult Venues()
        {
            return View();
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewVenue")]
        public ActionResult Venues_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            List<Venues> Classs = new List<Venues>();
            if (CurrentUser.CompanyID < 0)
            {
                Classs = this._objConfigurationBAL.Venues_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);

            }
            else if (CurrentUser.CompanyID > 0)
            {
                Classs = this._objConfigurationBAL.VenuesbyOrganization_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText,Convert.ToString(CurrentUser.CompanyID));
            }
            //var result = new DataSourceResult()
            //{
            //    Data = Classs, // Process data (paging and sorting applied)
            //    Total = Total // Total number of records
            //};
            //var resultData = new[] { Classs };
            return Json(Classs.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditVenue")]
        public ActionResult Venues_Create([DataSourceRequest] DataSourceRequest request, Venues _objVenues)
        {
            if (ModelState.IsValid)
            {
                if (_objVenues.SecondaryName == null)
                    _objVenues.SecondaryName = "";
                if (_objVenues.VenueStatusID == null)
                    _objVenues.VenueStatusID = 0;
                if (_objVenues.VenueCodeID == null)
                    _objVenues.VenueCodeID = "";
                if (_objVenues.RateType == null)
                    _objVenues.RateType = 0;
                if (_objVenues.Cost == null)
                    _objVenues.Cost = 0;
                if (_objVenues.Currency == null)
                    _objVenues.Currency =0;
                if (_objVenues.Capacity == null)
                    _objVenues.Capacity = "";
                if (_objVenues.IsCommon == null)
                    _objVenues.IsCommon = false;
                if (_objVenues.CountryID == null)
                    _objVenues.CountryID = 145;
                if (_objVenues.StateID == null)
                    _objVenues.StateID = 0;
                _objVenues.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objVenues.CreatedDate = DateTime.Now;
                _objVenues.OrganizationID = CurrentUser.CompanyID;
                _objVenues.AvailableFrom = UtilityFunctions.MapValue<DateTime>(_objVenues.AvailableFromString, typeof(DateTime));
                _objVenues.AvailableTo = UtilityFunctions.MapValue<DateTime>(_objVenues.AvailableToString, typeof(DateTime));
                _objVenues.ID = _objConfigurationBAL.Venues_CreateBAL(_objVenues);

                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

            }
            var resultData = new[] { _objVenues };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditVenue")]
        public ActionResult Venues_Update([DataSourceRequest] DataSourceRequest request, Venues _objVenues)
        {
            if (ModelState.IsValid)
            {
                if (_objVenues.SecondaryName == null)
                    _objVenues.SecondaryName = "";
                if (_objVenues.VenueStatusID == null)
                    _objVenues.VenueStatusID = 0;
                if (_objVenues.VenueCodeID == null)
                    _objVenues.VenueCodeID = "";
                if (_objVenues.RateType == null)
                    _objVenues.RateType = 0;
                if (_objVenues.Cost == null)
                    _objVenues.Cost = 0;
                if (_objVenues.Currency == null)
                    _objVenues.Currency = 0;
                if (_objVenues.Capacity == null)
                    _objVenues.Capacity = "";
                if (_objVenues.IsCommon == null)
                    _objVenues.IsCommon = false;
                if (_objVenues.CountryID == null)
                    _objVenues.CountryID = 145;
                if (_objVenues.StateID == null)
                    _objVenues.StateID = 0;
                _objVenues.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objVenues.UpdatedDate = DateTime.Now;
                _objVenues.AvailableFrom = UtilityFunctions.MapValue<DateTime>(_objVenues.AvailableFromString, typeof(DateTime));
                _objVenues.AvailableTo = UtilityFunctions.MapValue<DateTime>(_objVenues.AvailableToString, typeof(DateTime));
                var result = _objConfigurationBAL.Venues_UpdateBAL(_objVenues);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objVenues };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteVenue")]
        public ActionResult Venues_Destroy([DataSourceRequest] DataSourceRequest request, Venues _objVenues)
        {
            if (ModelState.IsValid)
            {
                _objVenues.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objVenues.UpdatedDate = DateTime.Now;
                var result = _objConfigurationBAL.Venues_DeleteBAL(_objVenues);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objVenues };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        //[ClaimsAuthorize("CanDeleteSession")]

        public JsonResult VenuesDelteChk(string _Sessions)
        {
            bool result = false;
            var _returnValue  = this._objConfigurationBAL.VenuesForDestroy_GetAllBAL(Convert.ToInt64(_Sessions));

            if (_returnValue > 0)
            {
                result = false;

            }
            else
            {
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion Venues

        #region Venues Detail added for Open Type

        [ClaimsAuthorize("CanViewPrgramVenues")]
        [DontWrapResult]
        public ActionResult ManageVenues(int Opentype, long OpenId)
        {
            ViewData["OpenType"] = Opentype;
            return PartialView("_Venues", OpenId);
        }
        [ClaimsAuthorize("CanViewPrgramVenues")]
        [DontWrapResult]
        public ActionResult ManageVenuesClass(int Opentype, long OpenId)
        {
            ViewData["OpenType"] = Opentype;
            return PartialView("_VenueClass", OpenId);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPrgramVenues")]
        public ActionResult ManageVenues_Read([DataSourceRequest] DataSourceRequest request, int Opentype, long OpenId)
        {
            return Json(_objConfigurationBAL.ManageVenues_GetAllBAL(OpenId, Opentype).ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPrgramVenues")]
        public ActionResult ManageVenues_Create([DataSourceRequest] DataSourceRequest request, VenueOpenMapping _objVenues, int otp, long oid)
        {
            if (ModelState.IsValid)
            {
                _objVenues.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objVenues.CreatedDate = DateTime.Now;
                _objVenues.OpenId = oid;
                _objVenues.OpenType = otp;
                //
                if (_objConfigurationBAL.ManageVenues_DuplicationCheckBAL(_objVenues) > 0)
                {
                    ModelState.AddModelError(lr.VenueName, lr.VenueDuplicationCheck);
                }
                else
                {
                    _objVenues.ID = _objConfigurationBAL.ManageVenues_CreateBAL(_objVenues);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                }
            }
            var resultData = new[] { _objVenues };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPrgramVenues")]
        public ActionResult ManageVenues_Update([DataSourceRequest] DataSourceRequest request, VenueOpenMapping _objVenues)
        {
            if (ModelState.IsValid)
            {
                _objVenues.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objVenues.UpdatedDate = DateTime.Now;
                //
                if (_objConfigurationBAL.ManageVenues_DuplicationCheckBAL(_objVenues) > 0)
                {
                    ModelState.AddModelError(lr.VenueName, lr.VenueDuplicationCheck);
                }
                else
                {
                    var result = _objConfigurationBAL.ManageVenues_UpdateBAL(_objVenues);
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
            var resultData = new[] { _objVenues };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeletePrgramVenues")]
        public ActionResult ManageVenues_Destroy([DataSourceRequest] DataSourceRequest request, VenueOpenMapping _objVenues)
        {
            if (ModelState.IsValid)
            {
                _objVenues.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objVenues.UpdatedDate = DateTime.Now;
                var result = _objConfigurationBAL.ManageVenues_DeleteBAL(_objVenues);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objVenues };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion Venues Detail added for Open Type

        #region Trainer Detail added for Open Type

        [ClaimsAuthorize("CanViewProgramTrainer")]
        [DontWrapResult]
        public ActionResult ManageTrainer(int Opentype, long OpenId)
        {
            ViewData["OpenType"] = Opentype;
            return PartialView("_Trainer", OpenId);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewProgramTrainer")]
        public ActionResult ManageTrainer_Read([DataSourceRequest] DataSourceRequest request, int Opentype, long OpenId)
        {
            return Json(_objConfigurationBAL.ManageTrainer_GetAllBAL(OpenId, Opentype).ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        public ActionResult ManageTrainer_Create([DataSourceRequest] DataSourceRequest request, TrainerOpenMapping _objtrainer, int otp, long oid)
        {
            if (ModelState.IsValid)
            {
                IList<ClassTraineeMapping> ClassTrainee=null;
                if (CurrentUser.CompanyID > 0)
                {
                    ClassTrainee= _ClassBAL.ClassTraineeMapping_GetAllBALOrganization(CurrentCulture, oid, CurrentUser.CompanyID);
                }
                else
                {
                    ClassTrainee= _ClassBAL.ClassTraineeMapping_GetAllBAL(CurrentCulture, oid);
                }
                var item = ClassTrainee
                .Cast<ClassTraineeMapping>().Where(i => i.PersonID== _objtrainer.PersonID).ToList();
                if(item.Count>0)
                {
                    ModelState.AddModelError(lr.Trainee, lr.ClassTraineeCannotAssignAsTrainee);
                }
                else
                {

                
                _objtrainer.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objtrainer.CreatedDate = DateTime.Now;
                _objtrainer.OpenId = oid;
                _objtrainer.OpenType = otp;
              //  if (_objConfigurationBAL.ManageTrainer_AvalabilityCheckBAL(_objtrainer) > 0)
              //  {
                   if (_objConfigurationBAL.ManageTrainer_DuplicationCheckBAL(_objtrainer) > 0)
                    {
                        ModelState.AddModelError(lr.Trainer, lr.TrainerDuplicationCheck);
                    }
                    else
                    {
                        _objtrainer.ID = _objConfigurationBAL.ManageTrainer_CreateBAL(_objtrainer);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                }

                    //  }
                    //else
                    //{
                    //    ModelState.AddModelError(lr.Trainer,"Trainer is not available for this Class Date.");
                    //}
                }
            }
            var resultData = new[] { _objtrainer };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        public ActionResult ManageTrainer_Update([DataSourceRequest] DataSourceRequest request, TrainerOpenMapping _objtrainer)
        {
            if (ModelState.IsValid)
            {
                _objtrainer.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objtrainer.UpdatedDate = DateTime.Now;
                //
                //if (_objConfigurationBAL.ManageTrainer_AvalabilityCheckBAL(_objtrainer) > 0)
                //{
                    if (_objConfigurationBAL.ManageTrainer_DuplicationCheckBAL(_objtrainer) > 0)
                    {
                        ModelState.AddModelError(lr.Trainer, lr.TrainerDuplicationCheck);
                    }
                    else
                    {
                        var result = _objConfigurationBAL.ManageTrainer_UpdateBAL(_objtrainer);
                        string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                        if (string.IsNullOrEmpty(ip))
                            ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                        _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);

                        if (result == -1)
                        {
                            ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                        }
                    }
                //}
                //else
                //{
                //    ModelState.AddModelError(lr.Trainer, "Trainer is not available for this Class Date.");
                //}
            }
            var resultData = new[] { _objtrainer };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteProgramTrainer")]
        public ActionResult ManageTrainer_Destroy([DataSourceRequest] DataSourceRequest request, TrainerOpenMapping _objtrainer)
        {
            if (ModelState.IsValid)
            {
                _objtrainer.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objtrainer.UpdatedDate = DateTime.Now;
                var result = _objConfigurationBAL.ManageTrainer_DeleteBAL(_objtrainer);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objtrainer };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion Venues Detail added for Open Type

        #region CourseVendors

        [ClaimsAuthorize("CanViewVendor")]
        [DontWrapResult]
        public ActionResult Vendors()
        {
            return View();
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewVendor")]
        public ActionResult Vendors_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var Classs = this._objConfigurationBAL.Vendors_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            if (CurrentUser.CompanyID > 0)
            {
                Classs = this._objConfigurationBAL.Vendors_GetAllBALbyOrg(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText,Convert.ToString(CurrentUser.CompanyID));
            }
            var result = new DataSourceResult()
            {
                Data = Classs, // Process data (paging and sorting applied)
                Total = Total // Total number of records
            };
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditVendor")]
        public ActionResult Vendors_Create([DataSourceRequest] DataSourceRequest request, Vendors _Vendors)
        {
            if (ModelState.IsValid)
            {
                _Vendors.CreatedBy = CurrentUser.NameIdentifierInt64;
                _Vendors.CreatedDate = DateTime.Now;
                _Vendors.OrganizationID = CurrentUser.CompanyID;
                if (_objConfigurationBAL.Vendors_DuplicationCheckBAL(_Vendors) > 0)
                {
                    ModelState.AddModelError(lr.VendorCode, lr.VendorCodeDuplicate);
                }
                else
                {
                    _Vendors.ID = _objConfigurationBAL.Vendors_CreateBAL(_Vendors);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                }
            }
            var resultData = new[] { _Vendors };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditVendor")]
        public ActionResult Vendors_Update([DataSourceRequest] DataSourceRequest request, Vendors _Vendors)
        {
            if (ModelState.IsValid)
            {
                _Vendors.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Vendors.UpdatedDate = DateTime.Now;

                if (_objConfigurationBAL.Vendors_DuplicationCheckBAL(_Vendors) > 0)
                {
                    ModelState.AddModelError(lr.VendorCode, lr.VendorCodeDuplicate);
                }
                else
                {
                    var result = _objConfigurationBAL.Vendors_UpdateBAL(_Vendors);
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
            var resultData = new[] { _Vendors };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteVendor")]
        public ActionResult Vendors_Destroy([DataSourceRequest] DataSourceRequest request, Vendors _Vendors)
        {
            if (ModelState.IsValid)
            {
                _Vendors.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Vendors.UpdatedDate = DateTime.Now;
                var result = _objConfigurationBAL.Vendors_DeleteBAL(_Vendors);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _Vendors };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion CourseVendors



        #region Categories

        [ClaimsAuthorize("CanViewCategory")]
        [DontWrapResult]
        public ActionResult Categories()
        {
            return View();

        }

        [ClaimsAuthorize("CanViewCategory")]
        [DontWrapResult]
        public ActionResult CourseCategories()
        {
            return PartialView("_Categories");
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewCategory")]
        public ActionResult Categories_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
           
            var Classs = _objConfigurationBAL.TMSCategories_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            if (CurrentUser.CompanyID > 0)
            {
                Classs = _objConfigurationBAL.TMSCategoriesbyOrganization_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText,Convert.ToString(CurrentUser.CompanyID));
            }
            var result = new DataSourceResult()
            {
                Data = Classs, // Process data (paging and sorting applied)
                Total = Total // Total number of records
            };
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditCategory")]
        public ActionResult Categories_Create([DataSourceRequest] DataSourceRequest request, TMSCategories _Categories)
        {
            if (ModelState.IsValid)
            {
                _Categories.CreatedBy = CurrentUser.NameIdentifierInt64;
                _Categories.CreatedDate = DateTime.Now;
                _Categories.OrganizationID = CurrentUser.CompanyID;
                if (_objConfigurationBAL.TMSCategories_DuplicationCheckBAL(_Categories) > 0)
                {
                    ModelState.AddModelError(lr.CategoryCode, lr.CategoryCodeDuplicate);
                }
                else
                {
                    _Categories.ID = _objConfigurationBAL.TMSCategories_CreateBAL(_Categories);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                }
            }
            var resultData = new[] { _Categories };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditCategory")]
        public ActionResult Categories_Update([DataSourceRequest] DataSourceRequest request, TMSCategories _Categories)
        {
            if (ModelState.IsValid)
            {
                _Categories.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Categories.UpdatedDate = DateTime.Now;

                if (_objConfigurationBAL.TMSCategories_DuplicationCheckBAL(_Categories) > 0)
                {
                    ModelState.AddModelError(lr.CategoryCode, lr.CategoryCodeDuplicate);
                }
                else
                {
                    var result = _objConfigurationBAL.TMSCategories_UpdateBAL(_Categories);
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
            var resultData = new[] { _Categories };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteCategory")]
        public ActionResult Categories_Destroy([DataSourceRequest] DataSourceRequest request, TMSCategories _Categories)
        {
            if (ModelState.IsValid)
            {
                _Categories.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Categories.UpdatedDate = DateTime.Now;
                var result = _objConfigurationBAL.TMSCategories_DeleteBAL(_Categories);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _Categories };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion Categories
        #region CategoriesCRM
        [ClaimsAuthorize("CanViewCourseCategory")]
        [DontWrapResult]
        public ActionResult CourseCategoriesCRM()
        {
            return PartialView("_CategoriesCRM");
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewCourseCategory")]
        public ActionResult Categories_ReadCRM([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }

            var Classs = _objConfigurationBAL.TMSCategories_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            if (CurrentUser.CompanyID > 0)
            {
                Classs = _objConfigurationBAL.TMSCategoriesbyOrganization_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText, Convert.ToString(CurrentUser.CompanyID));
            }
            var result = new DataSourceResult()
            {
                Data = Classs, // Process data (paging and sorting applied)
                Total = Total // Total number of records
            };
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditCourseCategory")]
        public ActionResult Categories_CreateCRM([DataSourceRequest] DataSourceRequest request, TMSCategories _Categories)
        {
            if (ModelState.IsValid)
            {
                _Categories.CreatedBy = CurrentUser.NameIdentifierInt64;
                _Categories.CreatedDate = DateTime.Now;
                _Categories.OrganizationID = CurrentUser.CompanyID;
                if (_objConfigurationBAL.TMSCategories_DuplicationCheckBAL(_Categories) > 0)
                {
                    ModelState.AddModelError(lr.CategoryCode, lr.CategoryCodeDuplicate);
                }
                else
                {
                    _Categories.ID = _objConfigurationBAL.TMSCategories_CreateBAL(_Categories);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                }
            }
            var resultData = new[] { _Categories };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditCourseCategory")]
        public ActionResult Categories_UpdateCRM([DataSourceRequest] DataSourceRequest request, TMSCategories _Categories)
        {
            if (ModelState.IsValid)
            {
                _Categories.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Categories.UpdatedDate = DateTime.Now;

                if (_objConfigurationBAL.TMSCategories_DuplicationCheckBAL(_Categories) > 0)
                {
                    ModelState.AddModelError(lr.CategoryCode, lr.CategoryCodeDuplicate);
                }
                else
                {
                    var result = _objConfigurationBAL.TMSCategories_UpdateBAL(_Categories);
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
            var resultData = new[] { _Categories };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteCourseCategory")]
        public ActionResult Categories_DestroyCRM([DataSourceRequest] DataSourceRequest request, TMSCategories _Categories)
        {
            if (ModelState.IsValid)
            {
                _Categories.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _Categories.UpdatedDate = DateTime.Now;
                var result = _objConfigurationBAL.TMSCategories_DeleteBAL(_Categories);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _Categories };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }
        #endregion

        #region FocusAreas

        [ClaimsAuthorize("CanViewFocusAreas")]
        [DontWrapResult]
        public ActionResult FocusAreas()
        {
            return View();
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewFocusAreas")]
        public ActionResult FocusAreas_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var Classs = _objConfigurationBAL.FocusAreas_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            if (CurrentUser.CompanyID > 0)
            {
                Classs = _objConfigurationBAL.FocusAreasbyOrganization_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText,Convert.ToString(CurrentUser.CompanyID));
            }
            var result = new DataSourceResult()
            {
                Data = Classs, // Process data (paging and sorting applied)
                Total = Total // Total number of records
            };
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditFocusAreas")]
        public ActionResult FocusAreas_Create([DataSourceRequest] DataSourceRequest request, FocusAreas _objFocusAreas)
        {
            if (ModelState.IsValid)
            {
                _objFocusAreas.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objFocusAreas.CreatedDate = DateTime.Now;
                _objFocusAreas.OrganizationID = CurrentUser.CompanyID;
                if (_objConfigurationBAL.FocusAreas_DuplicationCheckBAL(_objFocusAreas) > 0)
                {
                    ModelState.AddModelError(lr.FocusAreaPrimaryName, lr.FocusAreaPrimayNameDuplicate);
                }
                else
                {
                    _objFocusAreas.ID = _objConfigurationBAL.FocusAreas_CreateBAL(_objFocusAreas);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                }
            }
            var resultData = new[] { _objFocusAreas };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditFocusAreas")]
        public ActionResult FocusAreas_Update([DataSourceRequest] DataSourceRequest request, FocusAreas _objFocusAreas)
        {
            if (ModelState.IsValid)
            {
                _objFocusAreas.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objFocusAreas.UpdatedDate = DateTime.Now;

                if (_objConfigurationBAL.FocusAreas_DuplicationCheckBAL(_objFocusAreas) > 0)
                {
                    ModelState.AddModelError(lr.FocusAreaPrimaryName, lr.FocusAreaPrimayNameDuplicate);
                }
                else
                {
                    var result = _objConfigurationBAL.FocusAreas_UpdateBAL(_objFocusAreas);
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
            var resultData = new[] { _objFocusAreas };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteFocusAreas")]
        public ActionResult FocusAreas_Destroy([DataSourceRequest] DataSourceRequest request, FocusAreas _objFocusAreas)
        {
            if (ModelState.IsValid)
            {
                _objFocusAreas.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objFocusAreas.UpdatedDate = DateTime.Now;
                var result = _objConfigurationBAL.FocusAreas_DeleteBAL(_objFocusAreas);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objFocusAreas };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }
        #endregion FocusAreas



        #region CourseMaterials

        [ClaimsAuthorize("CanViewCourseMaterials")]
        [DontWrapResult]
        public ActionResult CourseMaterials()
        {
            return View();
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewCourseMaterials")]
        public ActionResult CourseMaterials_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var Classs = _objConfigurationBAL.CourseMaterials_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            if (CurrentUser.CompanyID > 0)
            {
                Classs = _objConfigurationBAL.CourseMaterials_GetAllBALbyOrg(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText,Convert.ToString(CurrentUser.CompanyID));
            }
            var result = new DataSourceResult()
            {
                Data = Classs, // Process data (paging and sorting applied)
                Total = Total // Total number of records
            };
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditCourseMaterials")]
        public ActionResult CourseMaterials_Create([DataSourceRequest] DataSourceRequest request, CourseMaterials _objTMS_CourseMaterials)
        {
            if (ModelState.IsValid)
            {
                _objTMS_CourseMaterials.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objTMS_CourseMaterials.CreatedDate = DateTime.Now;
                _objTMS_CourseMaterials.OrganizationID = CurrentUser.CompanyID;
                if (_objConfigurationBAL.CourseMaterials_DuplicationCheckBAL(_objTMS_CourseMaterials) > 0)
                {
                    ModelState.AddModelError(lr.CourseMaterialsPrimaryMaterial, lr.CourseMaterialsPrimaryMaterialDuplicate);
                }
                else
                {
                    _objTMS_CourseMaterials.ID = _objConfigurationBAL.CourseMaterials_CreateBAL(_objTMS_CourseMaterials);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                }
            }
            var resultData = new[] { _objTMS_CourseMaterials };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditCourseMaterials")]
        public ActionResult CourseMaterials_Update([DataSourceRequest] DataSourceRequest request, CourseMaterials _objTMS_CourseMaterials)
        {
            if (ModelState.IsValid)
            {
                _objTMS_CourseMaterials.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objTMS_CourseMaterials.UpdatedDate = DateTime.Now;

                if (_objConfigurationBAL.CourseMaterials_DuplicationCheckBAL(_objTMS_CourseMaterials) > 0)
                {
                    ModelState.AddModelError(lr.CourseMaterialsPrimaryMaterial, lr.CourseMaterialsPrimaryMaterialDuplicate);
                }
                else
                {
                    var result = _objConfigurationBAL.CourseMaterials_UpdateBAL(_objTMS_CourseMaterials);
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
            var resultData = new[] { _objTMS_CourseMaterials };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteCourseMaterials")]
        public ActionResult CourseMaterials_Destroy([DataSourceRequest] DataSourceRequest request, CourseMaterials _objTMS_CourseMaterials)
        {
            if (ModelState.IsValid)
            {
                _objTMS_CourseMaterials.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objTMS_CourseMaterials.UpdatedDate = DateTime.Now;
                var result = _objConfigurationBAL.CourseMaterials_DeleteBAL(_objTMS_CourseMaterials);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objTMS_CourseMaterials };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }



        [ClaimsAuthorize("CanViewProgramTrainer")]
        [DontWrapResult]
        public ActionResult ManageCourseMeterialMap(long CourseID)
        {

            return PartialView("_CourseMaterialMap", CourseID);
        }




        [DontWrapResult]
        [ClaimsAuthorize("CanViewProgramTrainer")]
        public ActionResult ManageCourseMeterialMap_Read([DataSourceRequest] DataSourceRequest request,long CourseID)
        {
            return Json(_objConfigurationBAL.ManageCourseMeterialMap_GetAllBAL(CurrentUser.CompanyID,CourseID).ToDataSourceResult(request, ModelState));
        }


        [DontWrapResult]
        [ClaimsAuthorize("CanViewProgramTrainer")]
        public ActionResult ManageCourseMeterial_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_objConfigurationBAL.ManageCourseMeterial_GetAllBAL(CurrentUser.CompanyID).ToDataSourceResult(request, ModelState));
        }



        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        public ActionResult ManageCourseMeterialMap_Create([DataSourceRequest] DataSourceRequest request, CourseMeterialsMapping _objlogmap, long oid)
        {
            if (ModelState.IsValid)
            {
                _objlogmap.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objlogmap.CreatedOn = DateTime.Now;
                _objlogmap.CourseID = oid;
                if (_objConfigurationBAL.CourseMeterialMap_DuplicationCheckBAL(_objlogmap) > 0)
                {
                    ModelState.AddModelError(lr.PrimaryMaterial, lr.CourseMeterialPrimayNameDuplicate);
                }
                else
                {
                    _objlogmap.ID = _objConfigurationBAL.ManageCourseMeterialMap_CreateBAL(_objlogmap);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                }
            }
            var resultData = new[] { _objlogmap };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }




        //[AcceptVerbs(HttpVerbs.Post)]
        //[DontWrapResult]
        //[ClaimsAuthorize("CanDeleteProgramTrainer")]
        public ActionResult ManageCourseMeterialMap_Destroy([DataSourceRequest] DataSourceRequest request, CourseMeterialsMapping _objlogmap)
        {
            if (ModelState.IsValid)
            {
                _objlogmap.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objlogmap.UpdatedOn = DateTime.Now;
                var result = _objConfigurationBAL.ManageCourseMeterialMap_DeleteBAL(_objlogmap);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objlogmap };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion CourseMaterials


        #region ClassMeterial


        [ClaimsAuthorize("CanViewProgramTrainer")]
        [DontWrapResult]
        public ActionResult ManageClassMeterialMap(long ClassId)
        {

            return PartialView("_ClassMeterialMap", ClassId);
        }




        [DontWrapResult]
        [ClaimsAuthorize("CanViewProgramTrainer")]
        public ActionResult ManageClassMeterialMap_Read([DataSourceRequest] DataSourceRequest request,long ClassID)
        {
            return Json(_objConfigurationBAL.ManageClassMeterialMap_GetAllBAL(CurrentUser.CompanyID, ClassID).ToDataSourceResult(request, ModelState));
        }



        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        public ActionResult ManageClassMeterialMap_Create([DataSourceRequest] DataSourceRequest request, ClassMeterialsMapping _objlogmap, long oid)
        {
            if (ModelState.IsValid)
            {
                _objlogmap.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objlogmap.CreatedOn = DateTime.Now;
                _objlogmap.ClassID = oid;
                var DublicateCheck=_objConfigurationBAL.ManageClassMeterialMap_GetAllBAL(CurrentUser.CompanyID, oid);
                bool flage = true;
                foreach (var x in DublicateCheck)
                {
                    long str = x.CourseMaterialID;
                    if (str == _objlogmap.CourseMaterialID)
                    {
                        flage = false;
                        break;
                    }
                }
                if (flage == false)
                {
                    ModelState.AddModelError(lr.DubliocationHappen, lr.MaterialDublication);
                   
                }
                else
                {

                //
                //if (_objConfigurationBAL.ManageTrainer_DuplicationCheckBAL(_objlogmap) > 0)
                //{
                //    ModelState.AddModelError(lr.Trainer, lr.TrainerDuplicationCheck);
                //}
                //else
                //{
                _objlogmap.ID = _objConfigurationBAL.ManageCourseClassMeterialMap_CreateBAL(_objlogmap);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                    //}

                }
            }
            var resultData = new[] { _objlogmap };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }




        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteProgramTrainer")]
        public ActionResult ManageClassMeterialMap_Destroy([DataSourceRequest] DataSourceRequest request, ClassMeterialsMapping _objlogmap)
        {
            if (ModelState.IsValid)
            {
                _objlogmap.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objlogmap.UpdatedOn = DateTime.Now;
                var result = _objConfigurationBAL.ManageCourseClassMeterialMap_DeleteBAL(_objlogmap);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objlogmap };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }


        #endregion ClassMeterial




        #region SessionMeterial


        [ClaimsAuthorize("CanViewProgramTrainer")]
        [DontWrapResult]
        public ActionResult ManageSessionMeterialMap(long SessionID)
        {

            return PartialView("_SessionMeterialMapTemplate", SessionID);
        }




        [DontWrapResult]
        [ClaimsAuthorize("CanViewProgramTrainer")]
        public ActionResult ManageSessionMeterialMap_Read([DataSourceRequest] DataSourceRequest request,long SessionID)
        {
            return Json(_objConfigurationBAL.ManageSessionMeterialMap_GetAllBAL(CurrentUser.CompanyID).ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorize("CanViewSaleAdminstration")]
        [DontWrapResult]
        public ActionResult AuditLog()
        {

            return View("AuditLog");
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewSaleAdminstration")]
        public ActionResult AuditLog_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_objConfigurationBAL.AuditLog_GetAllBAL(CurrentUser.CompanyID).ToDataSourceResult(request, ModelState));
        }



        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        public ActionResult ManageSessionMeterialMap_Create([DataSourceRequest] DataSourceRequest request, SessionMeterialsMapping _objlogmap, long oid)
        {
            if (ModelState.IsValid)
            {
                _objlogmap.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objlogmap.CreatedOn = DateTime.Now;
                _objlogmap.SessionID = oid;
                //
                //if (_objConfigurationBAL.ManageTrainer_DuplicationCheckBAL(_objlogmap) > 0)
                //{
                //    ModelState.AddModelError(lr.Trainer, lr.TrainerDuplicationCheck);
                //}
                //else
                //{
                _objlogmap.ID = _objConfigurationBAL.ManageSessionMeterialMap_CreateBAL(_objlogmap);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                //}
            }
            var resultData = new[] { _objlogmap };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }




        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteProgramTrainer")]
        public ActionResult ManageSessionMeterialMap_Destroy([DataSourceRequest] DataSourceRequest request, CourseLogisticRequirementsMapping _objlogmap)
        {
            if (ModelState.IsValid)
            {
                _objlogmap.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objlogmap.UpdatedDate = DateTime.Now;
                // var result = _objConfigurationBAL.ManageTrainer_DeleteBAL(_objlogmap);
                //if (result == -1)
                //{
                //    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                //}
            }
            var resultData = new[] { _objlogmap };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }


        #endregion SessionMeterial



        /////DAL Interface
        #region DegreeCertificates

        [ClaimsAuthorize("CanViewDegreeCertificates")]
        [DontWrapResult]
        public ActionResult DegreeCertificates()
        {
            return View();
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewDegreeCertificates")]
        public ActionResult DegreeCertificates_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var Classs = _objConfigurationBAL.DegreeCertificates_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            if (CurrentUser.CompanyID > 0)
            {
                Classs = _objConfigurationBAL.DegreeCertificates_GetAllBALbyOrg(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText,Convert.ToString(CurrentUser.CompanyID));
            }
            var result = new DataSourceResult()
            {
                Data = Classs, // Process data (paging and sorting applied)
                Total = Total // Total number of records
            };
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        
        [ClaimsAuthorize("CanAddEditDegreeCertificates")]
        public ActionResult DegreeCertificates_Create([DataSourceRequest] DataSourceRequest request, DegreeCertificates _objDegreeCertificates, string filename, long aid)
        {
            if (ModelState.IsValid)
            {
                _objDegreeCertificates.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objDegreeCertificates.CreatedDate = DateTime.Now;
                _objDegreeCertificates.OrganizationID = CurrentUser.CompanyID;
                if (_objConfigurationBAL.DegreeCertificates_DuplicationCheckBAL(_objDegreeCertificates) > 0)
                {
                    ModelState.AddModelError(lr.DegreeCertificatesPrimaryName, lr.DegreeCertificatesPrimaryNameDuplicate);
                }
                else
                {
                    _objDegreeCertificates.ID = _objConfigurationBAL.DegreeCertificates_CreateBAL(_objDegreeCertificates);
                    string path=HandleCertificate(filename, _objDegreeCertificates.ID, aid);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                }
            }
            var resultData = new[] { _objDegreeCertificates };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }
        [NonAction]
        public string HandleCertificate(string picturename, long OrganizationId, long aid)//handle in case of new is created
        {
            if (!string.IsNullOrEmpty(picturename))
            {
                var _aatchedFromDB = _AttachmentBAL.TMS_Attachment_GetSingleByIdAndTypeBAL(aid);

                var newparentroot = DateTime.Now.Ticks.ToString();
                var physicalPath = Path.Combine(Server.MapPath("~/UploadTempFolder"));
                string strSource = physicalPath + "/" + _aatchedFromDB.FileParentRootFolder + "/" + _aatchedFromDB.FileName;
                string targetString = "~/Attachment/TMS/Organization/" + CurrentUser.CompanyID + "/Certificates/" + newparentroot + "/";
                string targetSource = Utility.CreateDirectory(Path.Combine(Server.MapPath(targetString))) + _aatchedFromDB.FileName;
                Utility.MoveAttachment(strSource, targetSource, false);
                System.IO.DirectoryInfo di = new DirectoryInfo(physicalPath + "/" + _aatchedFromDB.FileParentRootFolder);
                di.Delete();
                _AttachmentBAL.TMS_Attachment_CompletedOrganizationLogoBAL(new TMS_Attachments { CompletedDate = DateTime.Now, ID = aid, OpenID = OrganizationId, OpenType = 4, FileParentRootFolder = newparentroot, FilePath = targetString });
                var model = _AttachmentBAL.TMS_Attachment_GetSingleByIdAndTypeBAL(aid);
                return model.FilePath.Replace("~/", "") + model.FileName;
            }
            return "/images/i/people.png";
        }
        //[AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewDegreeCertificates")]
        public ActionResult Preview_Certificate(string pid)
        {
            int Total = 0;
            List<DegreeCertificates> degree = new List<DegreeCertificates>();
           degree= _objConfigurationBAL.DegreeCertificates_GetAllBALbyOrg(0, 1000, ref Total, null, "", Convert.ToString(CurrentUser.CompanyID));
            var Newdegree = degree.FirstOrDefault(i => i.ID == Convert.ToInt64(pid));
            return View(Newdegree);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditDegreeCertificates")]
        public ActionResult DegreeCertificates_Update([DataSourceRequest] DataSourceRequest request, DegreeCertificates _objDegreeCertificates, string filename, long aid)
        {
            if (ModelState.IsValid)
            {
                _objDegreeCertificates.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objDegreeCertificates.UpdatedDate = DateTime.Now;
                _objDegreeCertificates.OrganizationID = CurrentUser.CompanyID;
                if (_objConfigurationBAL.DegreeCertificates_DuplicationCheckBAL(_objDegreeCertificates) > 0)
                {
                    ModelState.AddModelError(lr.DegreeCertificatesPrimaryName, lr.DegreeCertificatesPrimaryNameDuplicate);
                }
                else
                {
                    string path = HandleCertificate(filename, _objDegreeCertificates.ID, aid);
                    var result = _objConfigurationBAL.DegreeCertificates_UpdateBAL(_objDegreeCertificates);
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
            var resultData = new[] { _objDegreeCertificates };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteDegreeCertificates")]
        public ActionResult DegreeCertificates_Destroy([DataSourceRequest] DataSourceRequest request, DegreeCertificates _objDegreeCertificates)
        {
            if (ModelState.IsValid)
            {
                _objDegreeCertificates.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objDegreeCertificates.UpdatedDate = DateTime.Now;
                var result = _objConfigurationBAL.DegreeCertificates_DeleteBAL(_objDegreeCertificates);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objDegreeCertificates };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }
        #endregion DegreeCertificates

        #region CourseLogisticRequirements

        [ClaimsAuthorize("CanViewCourseLogisticRequirements")]
        [DontWrapResult]
        public ActionResult CourseLogisticRequirements()
        {
            return View();
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewCourseLogisticRequirements")]
        public ActionResult CourseLogisticRequirements_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var Classs = _objConfigurationBAL.CourseLogisticRequirements_GetAllBAL(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText);
            if (CurrentUser.CompanyID > 0)
            {
                Classs = _objConfigurationBAL.CourseLogisticRequirements_GetAllBALbyOrg(startRowIndex, request.PageSize, ref Total, GridHelper.GetSortExpression(request, "ID"), SearchText,Convert.ToString(CurrentUser.CompanyID));
            }
            var result = new DataSourceResult()
            {
                Data = Classs, // Process data (paging and sorting applied)
                Total = Total // Total number of records
            };
            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditCourseLogisticRequirements")]
        public ActionResult CourseLogisticRequirements_Create([DataSourceRequest] DataSourceRequest request, CourseLogisticRequirements _objCourseLogisticRequirements)
        {
            if (ModelState.IsValid)
            {
                _objCourseLogisticRequirements.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objCourseLogisticRequirements.CreatedDate = DateTime.Now;
                _objCourseLogisticRequirements.OrganizationID = CurrentUser.CompanyID;
                if (_objConfigurationBAL.CourseLogisticRequirements_DuplicationCheckBAL(_objCourseLogisticRequirements) > 0)
                {
                    ModelState.AddModelError(lr.CourseLogisticRequirementsPrimaryRequirementName, lr.CourseLogisticRequirementsPrimaryRequirementNameDuplicate);
                }
                else
                {
                    _objCourseLogisticRequirements.ID = _objConfigurationBAL.CourseLogisticRequirements_CreateBAL(_objCourseLogisticRequirements);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                }
            }
            var resultData = new[] { _objCourseLogisticRequirements };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditCourseLogisticRequirements")]
        public ActionResult CourseLogisticRequirements_Update([DataSourceRequest] DataSourceRequest request, CourseLogisticRequirements _objCourseLogisticRequirements)
        {
            if (ModelState.IsValid)
            {
                _objCourseLogisticRequirements.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objCourseLogisticRequirements.UpdatedDate = DateTime.Now;

                if (_objConfigurationBAL.CourseLogisticRequirements_DuplicationCheckBAL(_objCourseLogisticRequirements) > 0)
                {
                    ModelState.AddModelError(lr.CourseLogisticRequirementsPrimaryRequirementName, lr.CourseLogisticRequirementsPrimaryRequirementNameDuplicate);
                }
                else
                {
                    var result = _objConfigurationBAL.CourseLogisticRequirements_UpdateBAL(_objCourseLogisticRequirements);
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
            var resultData = new[] { _objCourseLogisticRequirements };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteCourseLogisticRequirements")]
        public ActionResult CourseLogisticRequirements_Destroy([DataSourceRequest] DataSourceRequest request, CourseLogisticRequirements _objCourseLogisticRequirements)
        {
            if (ModelState.IsValid)
            {
                _objCourseLogisticRequirements.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objCourseLogisticRequirements.UpdatedDate = DateTime.Now;
                var result = _objConfigurationBAL.CourseLogisticRequirements_DeleteBAL(_objCourseLogisticRequirements);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objCourseLogisticRequirements };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }
        [ClaimsAuthorize("CanViewProgramTrainer")]
        [DontWrapResult]
        public ActionResult ManageCourseMap(long CourseID)
        {

            return PartialView("_CourseLogisticMap", CourseID);
        }




        [DontWrapResult]
        [ClaimsAuthorize("CanViewProgramTrainer")]
        public ActionResult ManageCourseMap_Read([DataSourceRequest] DataSourceRequest request, long CourseID)
        {
            return Json(_objConfigurationBAL.ManageCourseMap_GetAllBAL(CurrentUser.CompanyID,CourseID).ToDataSourceResult(request, ModelState));
        }


        [DontWrapResult]
        [ClaimsAuthorize("CanViewProgramTrainer")]
        public ActionResult ManageCourse_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_objConfigurationBAL.ManageCourse_GetAllBAL(CurrentUser.CompanyID).ToDataSourceResult(request, ModelState));
        }



        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        public ActionResult ManageLogisticMap_Create([DataSourceRequest] DataSourceRequest request, CourseLogisticRequirementsMapping _objlogmap, long oid)
        {
            if (ModelState.IsValid)
            {
                //foreach(var objs in _objlogmap)
                //{
                //    objs.CreatedBy = CurrentUser.NameIdentifierInt64;
                //    objs.CreatedDate = DateTime.Now;
                //    objs.ID = _objConfigurationBAL.ManageLogisticMap_CreateBAL(objs);
                //}
                // List<List<CourseLogisticRequirementsMapping>> _objlogmaps = new List<List<CourseLogisticRequirementsMapping>>();
                _objlogmap.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objlogmap.CreatedDate = DateTime.Now;
                _objlogmap.CourseID = oid;
                //
               if (_objConfigurationBAL.ManageLogistic_DuplicationCheckBAL(_objlogmap) > 0)
               {
                    ModelState.AddModelError(lr.PrimaryRequirementName, lr.LogisticDuplicationCheck);
                }
                else
                {

                    _objlogmap.ID = _objConfigurationBAL.ManageLogisticMap_CreateBAL(_objlogmap);
                    string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                    if (string.IsNullOrEmpty(ip))
                        ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);

                }
            }
            var resultData = new[] { _objlogmap };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }



        //[AcceptVerbs(HttpVerbs.Post)]
        //[DontWrapResult]
        //[ClaimsAuthorize("CanAddEditProgramTrainer")]
        //public ActionResult ManageLogisticMap_Create([DataSourceRequest] DataSourceRequest request)
        //{
        //    return Json(_objConfigurationBAL.ManageCourseMap_GetAllBAL(CurrentUser.CompanyID).ToDataSourceResult(request, ModelState));

        //    //if (ModelState.IsValid)
        //    //{
        //    //    //foreach(var objs in _objlogmap)
        //    //    //{
        //    //    //    objs.CreatedBy = CurrentUser.NameIdentifierInt64;
        //    //    //    objs.CreatedDate = DateTime.Now;
        //    //    //    objs.ID = _objConfigurationBAL.ManageLogisticMap_CreateBAL(objs);
        //    //    //}
        //    //    // List<List<CourseLogisticRequirementsMapping>> _objlogmaps = new List<List<CourseLogisticRequirementsMapping>>();
        //    //    //_objlogmap.CreatedBy = CurrentUser.NameIdentifierInt64;
        //    //    //_objlogmap.CreatedDate = DateTime.Now;
        //    //    //_objlogmap.CourseID = oid;
        //    //    //
        //    //    //if (_objConfigurationBAL.ManageTrainer_DuplicationCheckBAL(_objlogmap) > 0)
        //    //    //{
        //    //    //    ModelState.AddModelError(lr.Trainer, lr.TrainerDuplicationCheck);
        //    //    //}
        //    //    //else
        //    //    //{

        //    //    _objlogmap.ID = _objConfigurationBAL.ManageLogisticMap_CreateBAL(_objlogmap);
        //    //    //}
        //    //}
        //    //var resultData = new[] { _objlogmap };
        //    // return Json(resultData.ToDataSourceResult(request, ModelState));
        //}


        public ActionResult ManageLogisticMap_Update([DataSourceRequest] DataSourceRequest request, CourseLogisticRequirementsMapping _objlogmap)
        {
            if (ModelState.IsValid)
            {
                _objlogmap.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objlogmap.UpdatedDate = DateTime.Now;
                //
                //if (_objConfigurationBAL.ManageTrainer_DuplicationCheckBAL(_objtrainer) > 0)
                //{
                //    ModelState.AddModelError(lr.Trainer, lr.TrainerDuplicationCheck);
                //}
                //else
                //{
                var result = _objConfigurationBAL.ManageLogisticMap_UpdateBAL(_objlogmap);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Update, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
                // }
            }
            var resultData = new[] { _objlogmap };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteProgramTrainer")]
        public ActionResult ManageLogisticMap_Destroy([DataSourceRequest] DataSourceRequest request, CourseLogisticRequirementsMapping _objlogmap)
        {
            if (ModelState.IsValid)
            {
                _objlogmap.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objlogmap.UpdatedDate = DateTime.Now;
                var result = _objConfigurationBAL.ManageLogisticMap_DeleteBAL(_objlogmap);
                string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (string.IsNullOrEmpty(ip))
                    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                _objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Delete, System.Web.HttpContext.Current.Request.Browser.Browser);

                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objlogmap };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion CourseLogisticRequirements



    }
}