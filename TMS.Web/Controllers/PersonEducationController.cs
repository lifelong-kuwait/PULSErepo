using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Linq;
using System.Web.Mvc;
using TMS.Business.Interfaces.TMS.Persons.Education;
using TMS.Library.TMS.Education;
using TMS.Library.TMS.Persons.Education;
using lr = Resources.Resources;
using TMS.Library;
namespace TMS.Web.Controllers
{
    public class PersonEducationController : TMSControllerBase
    {
        private readonly IPersonEducationBAL _PersonEducationBAL;

        public PersonEducationController(IPersonEducationBAL objIPersonEducationBAL)
        {
            _PersonEducationBAL = objIPersonEducationBAL;
        }

        #region"Degree"

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonEducation")]
        public ActionResult Degree(string PersonID)
        {
            return PartialView("_Degree", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonEducation")]
        public ActionResult PersonDegree_Read([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _person = _PersonEducationBAL.PersonEducationDegrees_GetAllByPersonIDBAL(PersonID);
            return Json(_person.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPersonEducation")]
        public ActionResult PersonDegree_Create([DataSourceRequest] DataSourceRequest request, string pid, PersonDegrees _personDegree)
        {
            if (ModelState.IsValid)
            {
                _personDegree.PersonID = Convert.ToInt64(pid);
                if (this._PersonEducationBAL.Degree_DuplicationCheckBAL(_personDegree) > 0)
                {
                    ModelState.AddModelError(lr.EducationEducationDublication, lr.EducationEducationDublication);
                    // return Json(lr.DegreeCertificatesPrimaryNameDuplicate, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    _personDegree.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _personDegree.CreatedDate = DateTime.Now;
                    _personDegree.PersonID = Convert.ToInt64(pid);
                    _personDegree.ID = _PersonEducationBAL.PersonEducationDegrees_CreateBAL(_personDegree);
                }
            }
            var resultData = new[] { _personDegree };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPersonEducation")]
        public ActionResult PersonDegree_Update([DataSourceRequest] DataSourceRequest request, PersonDegrees _personDegree)
        {
            if (ModelState.IsValid)
            {
                if (this._PersonEducationBAL.Degree_DuplicationCheckBAL(_personDegree) > 0)
                {
                    ModelState.AddModelError(lr.EducationEducationDublication, lr.EducationEducationDublication);
                    // return Json(lr.DegreeCertificatesPrimaryNameDuplicate, JsonRequestBehavior.AllowGet);
                }
                else
                {


                    _personDegree.UpdatedBy = CurrentUser.NameIdentifierInt64;
                    _personDegree.UpdatedDate = DateTime.Now;
                    var result = _PersonEducationBAL.PersonEducationDegrees_UpdateBAL(_personDegree);
                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                    }
                }
            }
            var resultData = new[] { _personDegree };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeletePersonEducation")]
        public ActionResult PersonDegree_Destroy([DataSourceRequest] DataSourceRequest request, PersonDegrees _personDegree)
        {
            if (ModelState.IsValid)
            {
                _personDegree.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _personDegree.UpdatedDate = DateTime.Now;
                var result = _PersonEducationBAL.PersonEducationDegrees_DeleteBAL(_personDegree);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _personDegree };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region"Certifications"

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonCertification")]
        public ActionResult Certification(string PersonID)
        {
            return PartialView("_Certifications", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonCertification")]
        public ActionResult PersonCertifications_Read([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _person = _PersonEducationBAL.PersonEducationCertifications_GetAllByPersonIDBAL(PersonID);
            return Json(_person.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPersonCertification")]
        public ActionResult PersonCertifications_Create([DataSourceRequest] DataSourceRequest request, string pid, PersonCertifications _personCertifications)
        {
            if (ModelState.IsValid)
            {
                if (_PersonEducationBAL.PersonEducationCertifications_CheckDuplicationBAL(_personCertifications) == 0)
                {
                    _personCertifications.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _personCertifications.CreatedDate = DateTime.Now;
                    _personCertifications.PersonID = Convert.ToInt64(pid);
                    _personCertifications.ID = _PersonEducationBAL.PersonEducationCertifications_CreateBAL(_personCertifications);
                }
                else
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.PersonEducationCertificationsDuplicationMessage);
                }
            }
            var resultData = new[] { _personCertifications };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPersonCertification")]
        public ActionResult PersonCertifications_Update([DataSourceRequest] DataSourceRequest request, PersonCertifications _personCertifications)
        {
            if (ModelState.IsValid)
            {
                _personCertifications.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _personCertifications.UpdatedDate = DateTime.Now;
                var result = _PersonEducationBAL.PersonEducationCertifications_UpdateBAL(_personCertifications);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _personCertifications };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeletePersonCertification")]
        public ActionResult PersonCertifications_Destroy([DataSourceRequest] DataSourceRequest request, PersonCertifications _personCertifications)
        {
            if (ModelState.IsValid)
            {
                _personCertifications.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _personCertifications.UpdatedDate = DateTime.Now;
                var result = _PersonEducationBAL.PersonEducationCertifications_DeleteBAL(_personCertifications);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _personCertifications };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region"TrainingDelivered"

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonTrainingHistory")]
        public ActionResult TrainingDelivered(string PersonID)
        {
            return PartialView("_TrainingDelivered", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonTrainingHistory")]
        public ActionResult PersonTrainingDelivered_Read([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _person = _PersonEducationBAL.PersonEducationTrainings_GetAllByPersonIDBAL(PersonID, (int)TrainingType.TrainingType_Existing);
            return Json(_person.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPersonTrainingHistory")]
        public ActionResult PersonTrainingDelivered_Create([DataSourceRequest] DataSourceRequest request, string pid, PersonTrainings _personTrainingDelivered)
        {
            if (ModelState.IsValid)
            {
                var _person = _PersonEducationBAL.PersonEducationTrainings_GetAllByPersonIDBAL(pid, (int)TrainingType.TrainingType_Existing);
                var _personExist = _person.Where(x => x.TrainingP_Title == _personTrainingDelivered.TrainingP_Title).ToList();
                if (_personExist.Count>0)
                {
                    ModelState.AddModelError(lr.TrainingTitleAllreadyExists, lr.TrainingTitleAllreadyExists);

                }
                else
                {
                    _personTrainingDelivered.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _personTrainingDelivered.CreatedDate = DateTime.Now;
                    _personTrainingDelivered.PersonID = Convert.ToInt64(pid);
                    _personTrainingDelivered.TrainingType = TrainingType.TrainingType_Existing;
                    var result = _PersonEducationBAL.PersonEducationTrainings_CreateBAL(_personTrainingDelivered);
                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.PersonEducationCertificationsDuplicationMessage);
                    }
                    else
                    {
                        _personTrainingDelivered.ID = result;
                    }
                }
               
            }
            var resultData = new[] { _personTrainingDelivered };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPersonTrainingHistory")]
        public ActionResult PersonTrainingDelivered_Update([DataSourceRequest] DataSourceRequest request, PersonTrainings _personTrainingDelivered)
        {
            if (ModelState.IsValid)
            {
                var _person = _PersonEducationBAL.PersonEducationTrainings_GetAllByPersonIDBAL(_personTrainingDelivered.PersonID.ToString(), (int)TrainingType.TrainingType_Existing);
                var _personExist = _person.Where(x => x.TrainingP_Title == _personTrainingDelivered.TrainingP_Title).ToList();
                if (_personExist.Count > 1)
                {
                    ModelState.AddModelError(lr.TrainingTitleAllreadyExists, lr.TrainingTitleAllreadyExists);

                }
                else
                {
                    if(_personExist.Count <=1)
                    {
                        var _personTrainingTitle = _personExist.Where(x => x.ID == _personTrainingDelivered.ID).ToList();
                        if(_personTrainingTitle.Count==1|| _personTrainingTitle.Count == 0)
                        {
                            _personTrainingDelivered.UpdatedBy = CurrentUser.NameIdentifierInt64;
                            _personTrainingDelivered.UpdatedDate = DateTime.Now;
                            _personTrainingDelivered.TrainingType = TrainingType.TrainingType_Existing;
                            var result = _PersonEducationBAL.PersonEducationTrainings_UpdateBAL(_personTrainingDelivered);
                            if (result == -1)
                            {
                                ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                            }
                        }else
                        {
                            ModelState.AddModelError(lr.TrainingTitleAllreadyExists, lr.TrainingTitleAllreadyExists);

                        }

                    }

                  
                }
            }
            var resultData = new[] { _personTrainingDelivered };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeletePersonTrainingHistory")]
        public ActionResult PersonTrainingDelivered_Destroy([DataSourceRequest] DataSourceRequest request, PersonTrainings _personTrainingDelivered)
        {
            if (ModelState.IsValid)
            {
                _personTrainingDelivered.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _personTrainingDelivered.UpdatedDate = DateTime.Now;
                _personTrainingDelivered.TrainingType = TrainingType.TrainingType_Existing;
                var result = _PersonEducationBAL.PersonEducationTrainings_DeleteBAL(_personTrainingDelivered);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _personTrainingDelivered };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region"WorkExperiences"

        [DontWrapResult]
        [ContentAuthorize]
        [ClaimsAuthorize("CanViewWorkExperience")]
        public ActionResult WorkExperience(string PersonID)
        {
            return PartialView("_WorkExperience", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewWorkExperience")]
        public ActionResult PersonWorkExperience_Read([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _person = _PersonEducationBAL.PersonEducationWorkExperiences_GetAllByPersonID(PersonID, CurrentCulture);
            return Json(_person.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditWorkExperience")]
        public ActionResult PersonWorkExperience_Create([DataSourceRequest] DataSourceRequest request, string pid, WorkExperiences _personWorkExperiences)
        {
            var now = DateTime.Now;
            var startOfMonth = new DateTime(now.Year, now.Month, 1);
            if (_personWorkExperiences.IsCurrent) { _personWorkExperiences.EndTimePeriod = startOfMonth; }
            if (ModelState.IsValid)
            {
                if(_personWorkExperiences.IsCurrent==false)
                {
                    int result = DateTime.Compare(_personWorkExperiences.StartTimePeriod, _personWorkExperiences.EndTimePeriod);
                    if(result==1)
                    {
                        ModelState.AddModelError(lr.StartandEndDateConflict, lr.StartandEndDateConflict);
                    }

                }


                if (_personWorkExperiences.OrganizationID == -1)
                {
                    _personWorkExperiences.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _personWorkExperiences.CreatedDate = DateTime.Now;
                    _personWorkExperiences.PersonID = Convert.ToInt64(pid);
                    _personWorkExperiences.StartTimePeriod = new DateTime(_personWorkExperiences.StartTimePeriod.Year, _personWorkExperiences.StartTimePeriod.Month, 1);
                    if (_personWorkExperiences.OrganizationID == -1)
                    { _personWorkExperiences.OrganizationID = 0; }
                    var result = _PersonEducationBAL.PersonEducationWorkExperiences_CreateDAL(_personWorkExperiences);
                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.PersonEducationCertificationsDuplicationMessage);
                    }
                    else
                    {
                        _personWorkExperiences.ID = result;
                    }
                }
                else
                {
                    if (_PersonEducationBAL.PersonEducationWorkExperiences_DuplicationCheckBAL(_personWorkExperiences, pid) == 0)
                    {
                        _personWorkExperiences.CreatedBy = CurrentUser.NameIdentifierInt64;
                        _personWorkExperiences.CreatedDate = DateTime.Now;
                        _personWorkExperiences.PersonID = Convert.ToInt64(pid);
                        _personWorkExperiences.StartTimePeriod = new DateTime(_personWorkExperiences.StartTimePeriod.Year, _personWorkExperiences.StartTimePeriod.Month, 1);
                        if (_personWorkExperiences.OrganizationID == -1)
                        { _personWorkExperiences.OrganizationID = 0; }
                        var result = _PersonEducationBAL.PersonEducationWorkExperiences_CreateDAL(_personWorkExperiences);
                        if (result == -1)
                        {
                            ModelState.AddModelError(lr.ErrorServerError, lr.PersonEducationCertificationsDuplicationMessage);
                        }
                        else
                        {
                            _personWorkExperiences.ID = result;
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(lr.PersonEducationWorkExperiencesTimePeriod, lr.PersonEducationWorkExperiencesTwoJobCheck);
                    }
                }

            }
            var resultData = new[] { _personWorkExperiences };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }


        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditWorkExperience")]
        public ActionResult PersonWorkExperience_Update([DataSourceRequest] DataSourceRequest request, WorkExperiences _personWorkExperiences)
        {
            if (_personWorkExperiences.IsCurrent) { _personWorkExperiences.EndTimePeriod = DateTime.Now; }
            if (ModelState.IsValid)
            {
                if (_personWorkExperiences.IsCurrent == false)
                {
                    int result1 = DateTime.Compare(_personWorkExperiences.StartTimePeriod, _personWorkExperiences.EndTimePeriod);
                    if (result1 == 1)
                    {
                        ModelState.AddModelError(lr.StartandEndDateConflict, lr.StartandEndDateConflict);
                    }

                }
                _personWorkExperiences.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _personWorkExperiences.UpdatedDate = DateTime.Now;
                if (_personWorkExperiences.OrganizationID == -1)
                { _personWorkExperiences.OrganizationID = 0; }

                var result = _PersonEducationBAL.PersonEducationWorkExperiences_UpdateDAL(_personWorkExperiences);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _personWorkExperiences };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }


        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanDeleteWorkExperience")]
        public ActionResult PersonWorkExperience_Destroy([DataSourceRequest] DataSourceRequest request, WorkExperiences _personWorkExperiences)
        {
            if (ModelState.IsValid)
            {
                _personWorkExperiences.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _personWorkExperiences.UpdatedDate = DateTime.Now;
                var result = _PersonEducationBAL.PersonEducationWorkExperiences_DeleteDAL(_personWorkExperiences);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _personWorkExperiences };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region"Achievement"

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonAchievement")]
        public ActionResult Achievement(string PersonID)
        {
            return PartialView("_Achievement", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonAchievement")]
        public ActionResult PersonAchievement_Read([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _person = _PersonEducationBAL.PersonEducationAchievements_GetAllByPersonID(PersonID);
            return Json(_person.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPersonAchievement")]
        public ActionResult PersonAchievement_Create([DataSourceRequest] DataSourceRequest request, string pid, PersonAchievements _personPersonAchievements)
        {
            if (ModelState.IsValid)
            {
                if (_PersonEducationBAL.PersonEducationWorkAchievements_DuplicationCheckBAL(_personPersonAchievements, pid) == 0)
                {
                    _personPersonAchievements.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _personPersonAchievements.CreatedDate = DateTime.Now;
                    _personPersonAchievements.PersonID = Convert.ToInt64(pid);
                    var result = _PersonEducationBAL.PersonEducationWorkAchievements_CreateBAL(_personPersonAchievements);
                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.PersonEducationCertificationsDuplicationMessage);
                    }
                    else
                    {
                        _personPersonAchievements.ID = result;
                    }
                }
                else
                {
                    ModelState.AddModelError(lr.PersonEducationWorkExperiencesTimePeriod, lr.PersonEducationAchievementDuplication);
                }
            }
            var resultData = new[] { _personPersonAchievements };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPersonAchievement")]
        public ActionResult PersonAchievement_Update([DataSourceRequest] DataSourceRequest request, PersonAchievements _personPersonAchievements)
        {
            if (ModelState.IsValid)
            {
                _personPersonAchievements.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _personPersonAchievements.UpdatedDate = DateTime.Now;
                var result = _PersonEducationBAL.PersonEducationWorkAchievements_UpdateBAL(_personPersonAchievements);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _personPersonAchievements };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeletePersonAchievement")]
        public ActionResult PersonAchievement_Destroy([DataSourceRequest] DataSourceRequest request, PersonAchievements _personPersonAchievements)
        {
            if (ModelState.IsValid)
            {
                _personPersonAchievements.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _personPersonAchievements.UpdatedDate = DateTime.Now;
                var result = _PersonEducationBAL.PersonEducationWorkAchievements_DeleteBAL(_personPersonAchievements);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _personPersonAchievements };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion

        #region"SuggestedTraining"

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonSuggestedTraining")]
        public ActionResult SuggestedTraining(string PersonID)
        {
            return PartialView("_SuggestedTraining", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonSuggestedTraining")]
        public ActionResult PersonSuggestedTraining_Read([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _person = _PersonEducationBAL.PersonEducationSuggestedTrainings_GetAllByPersonIDBAL(PersonID, (int)TrainingType.TrainingType_Suggested);
            return Json(_person.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPersonSuggestedTraining")]
        public ActionResult PersonSuggestedTraining_Create([DataSourceRequest] DataSourceRequest request, string pid, PersonSuggestedTrainings _personTrainingDelivered)
        {
            if (ModelState.IsValid)
            {
                _personTrainingDelivered.TrainingType = TrainingType.TrainingType_Suggested;
                if (_PersonEducationBAL.PersonEducationSuggestedTrainings_DuplicationCheckBAL(_personTrainingDelivered, pid) == 0)
                {
                    _personTrainingDelivered.CreatedBy = CurrentUser.NameIdentifierInt64;
                    _personTrainingDelivered.CreatedDate = DateTime.Now;
                    _personTrainingDelivered.PersonID = Convert.ToInt64(pid);

                    var result = _PersonEducationBAL.PersonEducationSuggestedTrainings_CreateBAL(_personTrainingDelivered);
                    if (result == -1)
                    {
                        ModelState.AddModelError(lr.ErrorServerError, lr.PersonEducationCertificationsDuplicationMessage);
                    }
                    else
                    {
                        _personTrainingDelivered.ID = result;
                    }
                }
                else
                {
                    ModelState.AddModelError(lr.PersonEducationTrainingPrimaryTitle, lr.PersonEducationTrainingTitleDuplication);
                }
            }
            var resultData = new[] { _personTrainingDelivered };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditPersonSuggestedTraining")]
        public ActionResult PersonSuggestedTraining_Update([DataSourceRequest] DataSourceRequest request, PersonSuggestedTrainings _personTrainingDelivered)
        {
            if (ModelState.IsValid)
            {
                _personTrainingDelivered.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _personTrainingDelivered.UpdatedDate = DateTime.Now;
                _personTrainingDelivered.TrainingType = TrainingType.TrainingType_Suggested;
                var result = _PersonEducationBAL.PersonEducationSuggestedTrainings_UpdateBAL(_personTrainingDelivered);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _personTrainingDelivered };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeletePersonSuggestedTraining")]
        public ActionResult PersonSuggestedTraining_Destroy([DataSourceRequest] DataSourceRequest request, PersonSuggestedTrainings _personTrainingDelivered)
        {
            if (ModelState.IsValid)
            {
                _personTrainingDelivered.UpdatedBy = CurrentUser.NameIdentifierInt64;
                _personTrainingDelivered.UpdatedDate = DateTime.Now;
                _personTrainingDelivered.TrainingType = TrainingType.TrainingType_Suggested;
                var result = _PersonEducationBAL.PersonEducationSuggestedTrainings_DeleteBAL(_personTrainingDelivered);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _personTrainingDelivered };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }

        #endregion
    }
}