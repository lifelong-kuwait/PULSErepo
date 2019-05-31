using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMS.Business.Interfaces.TMS.SkillsInterestLevel;
using TMS.Library;
using TMS.Library.TMS.Skills;
using lr = Resources.Resources;

namespace TMS.Web.Controllers
{
    public class SkillInterestController : TMSControllerBase
    {
        private readonly ISkillsInterestLevelBAL _objISkillsInterestLevelBAL;

        public SkillInterestController(ISkillsInterestLevelBAL _objSkillsInterestLevelBAL)
        {
            _objISkillsInterestLevelBAL = _objSkillsInterestLevelBAL;
        }

        #region"Skills"

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonSkillsAreasofFocus")]
        public ActionResult PersonSkill(string PersonID)
        {
            return PartialView("_PersonSkill", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonSkillsAreasofFocus")]
        public ActionResult PersonSkill_Read([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _Phone = _objISkillsInterestLevelBAL.PersonSkill_GetbyPersonIdBAL(Convert.ToInt64(PersonID), CurrentUser.CompanyID);
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

        [ClaimsAuthorize("CanViewPersonSkillsAreasofFocus")]
        [DontWrapResult]
        public ActionResult ManageTraineePerson_Read([DataSourceRequest] DataSourceRequest request)
        {

            var _Phone = _objISkillsInterestLevelBAL.PersonFocusAreaSkill_GetbyPersonIdBAL();
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPersonSkillsAreasofFocus")]
        public ActionResult PersonSkill_Create([DataSourceRequest] DataSourceRequest request, string PersonIds, long cid)
        {
            var items = PersonIds.Split(new char[] { ',' });
            List<long> termsList = new List<long>();
            foreach (string s in items)
            {
                long val;

                if (long.TryParse(s, out val))
                {
                    termsList.Add(Convert.ToInt64(val));
                }
            }
           
            long user = CurrentUser.NameIdentifierInt64;
            DateTime date = DateTime.Now;
            long OrganizationID = CurrentUser.CompanyID;
            List<long> list= new List<long>();
            foreach (long value in termsList)
            {
                list.Add(_objISkillsInterestLevelBAL.PersonSkillsInterest_CreateBAL(value, user, date, cid, OrganizationID));

            }
            return Json(list);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPersonSkillsAreasofFocus")]
        public ActionResult PersonSkill_Update([DataSourceRequest] DataSourceRequest request, PersonSkill _objPersonSkill)
        {
            if (ModelState.IsValid)
            {
                PersonSkillsInterest _objSkillsInterest = new PersonSkillsInterest();
                _objSkillsInterest.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objSkillsInterest.UpdatedDate = DateTime.Now;
                _objSkillsInterest.Title = _objPersonSkill.Title;
                _objSkillsInterest.Description = "";
                _objSkillsInterest.ID = _objPersonSkill.ID;
                _objSkillsInterest.Type = PersonSKillInterest.PersonSKillInterest_Person_Skills;
                if (_objISkillsInterestLevelBAL.PersonSkillsInterest_DuplicationCheckBAL(_objSkillsInterest) > 0)
                {
                    ModelState.AddModelError(lr.PersonSkill, lr.PersonSkillDuplicationCheck);
                }
                else
                {
                    var result = _objISkillsInterestLevelBAL.PersonSkillsInterest_UpdateBAL(_objSkillsInterest);
                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
            }
            var resultData = new[] { _objPersonSkill };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeletePersonSkillsAreasofFocus")]
        public ActionResult PersonSkill_Destroy([DataSourceRequest] DataSourceRequest request, PersonSkill _objPersonSkill)
        {
            if (ModelState.IsValid)
            {
                PersonSkillsInterest _objSkillsInterest = new PersonSkillsInterest();
                _objSkillsInterest.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objSkillsInterest.UpdatedDate = DateTime.Now;
                _objSkillsInterest.ID = _objPersonSkill.ID;
                var result = _objISkillsInterestLevelBAL.PersonSkillsInterest_DeleteBAL(_objSkillsInterest);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objPersonSkill };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region"PersonInterest"

        [DontWrapResult]
        public ActionResult PersonInterest(string PersonID)
        {
            return PartialView("_PersonInterest", PersonID);
        }

        [DontWrapResult]
        public ActionResult PersonInterest_Read([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _Phone = _objISkillsInterestLevelBAL.PersonInterest_GetbyPersonIdBAL(Convert.ToInt64(PersonID));
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public ActionResult PersonInterest_Create([DataSourceRequest] DataSourceRequest request, string pid, PersonInterest _objPersonInterest)
        {
            if (ModelState.IsValid)
            {
                PersonSkillsInterest _objSkillsInterest = new PersonSkillsInterest();
                _objSkillsInterest.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objSkillsInterest.PersonID = Convert.ToInt64(pid);
                _objSkillsInterest.OrganizationID = CurrentUser.CompanyID;
                _objSkillsInterest.CreatedDate = DateTime.Now;
                _objSkillsInterest.Title = _objPersonInterest.Title;
                _objSkillsInterest.Description = "";
                _objSkillsInterest.Type = PersonSKillInterest.PersonSKillInterest_Field_Of_Interest;
                if (_objISkillsInterestLevelBAL.PersonSkillsInterest_DuplicationCheckBAL(_objSkillsInterest) > 0)
                {
                    ModelState.AddModelError(lr.PersonFieldofInterest, lr.PersonFieldofInterestDuplicationCheck);
                }
                else
                {
                    _objPersonInterest.ID = _objISkillsInterestLevelBAL.PersonSkillsInterest_CreateBAL(_objSkillsInterest);
                }
            }
            var resultData = new[] { _objPersonInterest };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public ActionResult PersonInterest_Update([DataSourceRequest] DataSourceRequest request, PersonInterest _objPersonInterest)
        {
            if (ModelState.IsValid)
            {
                PersonSkillsInterest _objSkillsInterest = new PersonSkillsInterest();
                _objSkillsInterest.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objSkillsInterest.UpdatedDate = DateTime.Now;
                _objSkillsInterest.Title = _objPersonInterest.Title;
                _objSkillsInterest.Description = "";
                _objSkillsInterest.ID = _objPersonInterest.ID;
                _objSkillsInterest.Type = PersonSKillInterest.PersonSKillInterest_Field_Of_Interest;
                if (_objISkillsInterestLevelBAL.PersonSkillsInterest_DuplicationCheckBAL(_objSkillsInterest) > 0)
                {
                    ModelState.AddModelError(lr.PersonFieldofInterest, lr.PersonFieldofInterestDuplicationCheck);
                }
                else
                {
                    var result = _objISkillsInterestLevelBAL.PersonSkillsInterest_UpdateBAL(_objSkillsInterest);
                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
            }
            var resultData = new[] { _objPersonInterest };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        public ActionResult PersonInterest_Destroy([DataSourceRequest] DataSourceRequest request, PersonInterest _objPersonInterest)
        {
            if (ModelState.IsValid)
            {
                PersonSkillsInterest _objSkillsInterest = new PersonSkillsInterest();
                _objSkillsInterest.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _objSkillsInterest.UpdatedDate = DateTime.Now;
                _objSkillsInterest.ID = _objPersonInterest.ID;
                var result = _objISkillsInterestLevelBAL.PersonSkillsInterest_DeleteBAL(_objSkillsInterest);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _objPersonInterest };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion
        [DontWrapResult]
        public ActionResult PersonLevel(string ID)
        {
            var data = _objISkillsInterestLevelBAL.PersonLevels_GetbyPersonIdBAL(Convert.ToInt64(ID));
            return PartialView("_PersonLevel", data);
        }
    }
}