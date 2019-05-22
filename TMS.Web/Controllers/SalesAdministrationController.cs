using Abp.Web.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMS.Business.Interfaces.Common;
using TMS.Business.Interfaces.Common.Groups;
using TMS.Library.Common.Groups;
using TMS.Library.Entities.Common.Roles;
using lr = Resources.Resources;
using TMS.Business.Interfaces.CRM;
using TMS.Library.Entities.CRM;

namespace TMS.Web.Controllers
{
    public class SalesAdministrationController : TMSControllerBase
    {
        private readonly ISalesAdministrationBAL _objSaleBAL;

        public SalesAdministrationController(ISalesAdministrationBAL _objSalesBAL)
        {
            _objSaleBAL = _objSalesBAL;
        }


        // GET: SalesAdministration
        public ActionResult Index()
        {
            return View();
        }


        [ClaimsAuthorize("CanViewSession")]
        public ActionResult SaleAdminstration()
        {
            return View();
          
        }

        #region Courses

        [ClaimsAuthorize("CanViewSession")]
        [DontWrapResult]
        public ActionResult ManageCourse()
        {

            return PartialView("ManageCourse");
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewProgramTrainer")]
        public ActionResult ManageCourse_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }

            return Json(_objSaleBAL.ManageCourse_GetAllBAL(CurrentUser.CompanyID, SearchText).ToDataSourceResult(request, ModelState));
        }



        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        public ActionResult ManageCourse_Create([DataSourceRequest] DataSourceRequest request, CRMCourses _objlogmap)
        {
            if (ModelState.IsValid)
            {
                _objlogmap.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objlogmap.CreatedDate = DateTime.Now;
                _objlogmap.OrganizationID = CurrentUser.CompanyID;


                _objlogmap.ID = _objSaleBAL.ManageCourse_CreateBAL(_objlogmap);
                //}
            }
            var resultData = new[] { _objlogmap };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        public ActionResult CourseUpdate([DataSourceRequest] DataSourceRequest request, CRMCourses _course)
        {
            if (ModelState.IsValid)
            {

                _course.ModifiedBy = CurrentUser.NameIdentifierInt64;
                _course.ModifiedOn = DateTime.Now;
                var result = _objSaleBAL.CourseUpdateBAL(_course);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _course };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteProgramTrainer")]
        public ActionResult Course_Destroy([DataSourceRequest] DataSourceRequest request, CRMCourses _courses)
        {
            if (ModelState.IsValid)
            {
                _courses.ModifiedBy = CurrentUser.NameIdentifierInt64;
                _courses.ModifiedOn = DateTime.Now;
                var result = _objSaleBAL.Course_DeleteBAL(_courses);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _courses };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }


        #endregion Courses




        #region Configuration

        [ClaimsAuthorize("CanViewSession")]
        [DontWrapResult]
        public ActionResult ManageConfiguration()
        {

            return PartialView("ManageConfiguration");
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewProgramTrainer")]
        public ActionResult ManageConfiguration_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            int Total = 0;
            var SearchText = Request.Form["SearchText"];
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }

            return Json(_objSaleBAL.ManageConfiguration_GetAllBAL(CurrentUser.CompanyID, SearchText).ToDataSourceResult(request, ModelState));
        }



        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        public ActionResult ManageConfiguration_Create([DataSourceRequest] DataSourceRequest request, CRMCourses _objlogmap)
        {
            if (ModelState.IsValid)
            {
                _objlogmap.CreatedBy = CurrentUser.NameIdentifierInt64;
                _objlogmap.CreatedDate = DateTime.Now;
                _objlogmap.OrganizationID = CurrentUser.CompanyID;


                _objlogmap.ID = _objSaleBAL.ManageCourse_CreateBAL(_objlogmap);
                //}
            }
            var resultData = new[] { _objlogmap };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanAddEditProgramTrainer")]
        public ActionResult ConfigurationUpdate([DataSourceRequest] DataSourceRequest request, CRMCourses _course)
        {
            if (ModelState.IsValid)
            {

                _course.ModifiedBy = CurrentUser.NameIdentifierInt64;
                _course.ModifiedOn = DateTime.Now;
                var result = _objSaleBAL.CourseUpdateBAL(_course);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _course };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }


        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ClaimsAuthorize("CanDeleteProgramTrainer")]
        public ActionResult Configuration_Destroy([DataSourceRequest] DataSourceRequest request, CRMCourses _courses)
        {
            if (ModelState.IsValid)
            {
                _courses.ModifiedBy = CurrentUser.NameIdentifierInt64;
                _courses.ModifiedOn = DateTime.Now;
                var result = _objSaleBAL.Course_DeleteBAL(_courses);
                if (result == -1)
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
                }
            }
            var resultData = new[] { _courses };
            return Json(resultData.AsQueryable().ToDataSourceResult(request, ModelState));
        }


        #endregion Configuration

    }
}