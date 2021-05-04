using Abp.Runtime.Validation;
using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TMS.Business.Interfaces.Jobs;
using TMS.Library.Entities.Jobs;
using lr = Resources.Resources;

namespace TMS.Web.Controllers
{
    [ClaimsAuthorizeAttribute("CanViewJobApplicationDetailJobModule", "CanViewJobApplicationsJobModule")]
    public class JobApplicationsController : TMSControllerBase
    {
        private readonly IJobsBAL _IJobsBAL;

        public JobApplicationsController(IJobsBAL _objIJobsBAL)
        {
            _IJobsBAL = _objIJobsBAL;
        }
        // GET: JobAplicationRequirement
        [ClaimsAuthorizeAttribute("CanViewJobApplicationDetailJobModule")]

        public ActionResult Index(long JobRID)
        {
            return View(JobRID);
        }

        [DontWrapResult]
        public ActionResult JobsApplications_Read([DataSourceRequest] DataSourceRequest request,long JobID)
        {

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
            IList<JobApplicationPerson> _JobsRequirement;
            if (kendoRequest.Filters.Count > 0)
            {
                _JobsRequirement = _IJobsBAL.read_AllJobsApplicationPersonBAL(JobID,ref Total, CurrentCulture, SearchText, GridHelper.GetSortExpression(request, "ID").ToString(), startRowIndex, request.Page, 10000, CurrentUser.CompanyID);

            }
            else
            {
                _JobsRequirement = this._IJobsBAL.read_AllJobsApplicationPersonBAL(JobID,ref Total, CurrentCulture, SearchText, GridHelper.GetSortExpression(request, "ID").ToString(), startRowIndex, request.Page, request.PageSize, CurrentUser.CompanyID);

            }
            _JobsRequirement = _JobsRequirement.Distinct().ToList();
            var data = _JobsRequirement.ToDataSourceResult(kendoRequest);
            var result = new DataSourceResult()
            {
                AggregateResults = data.AggregateResults,
                Data = data.Data,
                Errors = data.Errors,
                Total = Total
            };
            return Json(result);
        }
        // [ClaimsAuthorizeAttribute("CanAddEditPerson")]
        [DisableValidation]
        [DontWrapResult]
        public ActionResult JobRequirement_Create([DataSourceRequest] DataSourceRequest request, JobsRequirement _jobsRequirement)
        {
            if (ModelState.IsValid)
            {
                _jobsRequirement.OrganizationID = CurrentUser.CompanyID;
                _jobsRequirement.CreatedBy = CurrentUser.NameIdentifierInt64;
                var results = this._IJobsBAL.Jobs_Requirement_Create(_jobsRequirement);
                return Json(new object[0].ToDataSourceResult(request, ModelState));
            }
            var resultData = new[] { _jobsRequirement };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }
        [DisableValidation]
        [DontWrapResult]
        public ActionResult JobRequirement_Update([DataSourceRequest] DataSourceRequest request, JobsRequirement _jobsRequirement)
        {
            if (ModelState.IsValid)
            {

                _jobsRequirement.UpdateBy = CurrentUser.NameIdentifierInt64;
                _jobsRequirement.IsActive = true;
                var results = this._IJobsBAL.Jobs_Requirement_Update(_jobsRequirement);
                return Json(new object[0].ToDataSourceResult(request, ModelState));
            }
            var resultData = new[] { _jobsRequirement };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }
        // [ClaimsAuthorizeAttribute("CanDeletePerson")]
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        // [DisableValidation]
        public ActionResult JobRequirement_Destroy([DataSourceRequest] DataSourceRequest request, JobsRequirement _jobsRequirement)
        {
            var json = new JavaScriptSerializer().Serialize(_jobsRequirement);
            //_UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Delete_Success.ToString(), System.Environment.MachineName, "User tried to Delete Person " + DateTime.UtcNow, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);
            _jobsRequirement.UpdateBy = CurrentUser.NameIdentifierInt64;
            var result = this._IJobsBAL.Jobs_Requirement_Destroy(_jobsRequirement);
            return Json(new object[0].ToDataSourceResult(request, ModelState));

        }

        [HttpPost]
        [DisableValidation]
        public ActionResult ActiveJob(string ID)
        {
            long JID = Convert.ToInt64(ID);
            var results = this._IJobsBAL.Jobs_Requirement_Active(JID, CurrentUser.NameIdentifierInt64);
            return null;
        }
        [HttpPost]
        [DisableValidation]
        public ActionResult InActiveJob(string ID)
        {
            long JID = Convert.ToInt64(ID);
            var results = this._IJobsBAL.Jobs_Requirement_InActive(JID, CurrentUser.NameIdentifierInt64);
            return null;
        }

    }
}