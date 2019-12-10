using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMS.Business.Interfaces.Common;
using TMS.Business.Interfaces.Common.Groups;
using TMS.Business.Interfaces.TMS;
using TMS.Common;
using TMS.Common.Utilities;
using TMS.Library.Entities.CRM;
using TMS.Library.Users;
using TMS.Web.Core;
using lr = Resources.Resources;

namespace TMS.Web.Controllers
{
    [SessionTimeout]
    public class UserLogController : TMSControllerBase
    {

        private IBALUsers _UserBAL { get; set; }
        private readonly IAttachmentBAL _AttachmentBAL;
        private readonly IGroupsBAL _Groups;
        public UserLogController(IBALUsers balUser, IAttachmentBAL _AttachmentBAL, IGroupsBAL _Groups)
        {
            _UserBAL = balUser; this._AttachmentBAL = _AttachmentBAL; this._Groups = _Groups;
        }
        [ClaimsAuthorize("CanViewUserLog")]
        public ActionResult UserLog()
        {
            return View();
        }
        [ClaimsAuthorize("CanViewUserErrorLog")]
        public ActionResult UserErrorLog()
        {
            return View();
        }
        [DontWrapResult]
        [ClaimsAuthorizeAttribute("CanViewUserLog")]
        public ActionResult UserLog_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            var SearchText = Request.Form["SearchText"];
            int Total = 0;
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var kendoRequest = new Kendo.Mvc.UI.DataSourceRequest
            {

                Filters = request.Filters,
                Sorts = request.Sorts,
                Groups = request.Groups,
                Aggregates = request.Aggregates
            };
            if (CurrentUser.CompanyID > 0)
            {
                IList<CRM_UserLog> _userdata;
                if (kendoRequest.Filters.Count > 0)
                {
                    _userdata = this._UserBAL.LogOrganization_GetAllBAL(ref Total, CurrentUser.CompanyID.ToString(), SearchText, "ID", startRowIndex, request.Page, 20000);

                }
                else
                {
                     _userdata = this._UserBAL.LogOrganization_GetAllBAL(ref Total, CurrentUser.CompanyID.ToString(), SearchText, "ID", startRowIndex, request.Page, request.PageSize);

                }
                //LogOrganization_GetAllBAL(ref int Total, string OrgID, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize)
                _userdata = _userdata.Distinct().ToList();
                var data = _userdata.ToDataSourceResult(kendoRequest);

                var result = new DataSourceResult()
                {
                    AggregateResults = data.AggregateResults,
                    Data = data.Data,
                    Errors = data.Errors,
                    Total = Total
                };

                return Json(result);

            }
            else
            {
                IList<CRM_UserLog> _userdata;
                if (kendoRequest.Filters.Count > 0)
                {
                     _userdata = this._UserBAL.LogOrganization_GetAllBAL(ref Total, CurrentUser.CompanyID.ToString(), SearchText, "ID", startRowIndex, request.Page, 20000);

                }
                else
                {
                     _userdata = this._UserBAL.LogOrganization_GetAllBAL(ref Total, CurrentUser.CompanyID.ToString(), SearchText, "ID", startRowIndex, request.Page, request.PageSize);

                }
                _userdata = _userdata.Distinct().ToList();

                var data = _userdata.ToDataSourceResult(kendoRequest);

                var result = new DataSourceResult()
                {
                    AggregateResults = data.AggregateResults,
                    Data = data.Data,
                    Errors = data.Errors,
                    Total = Total
                };
                return Json(result);

            }
        }
        [DontWrapResult]
        [ClaimsAuthorizeAttribute("CanViewUserErrorLog")]
        public ActionResult UserErrorLog_Read([DataSourceRequest] DataSourceRequest request)
        {
            var startRowIndex = (request.Page - 1) * request.PageSize;
            var SearchText = Request.Form["SearchText"];
            int Total = 0;
            if (request.PageSize == 0)
            {
                request.PageSize = 10;
            }
            var kendoRequest = new Kendo.Mvc.UI.DataSourceRequest
            {

                Filters = request.Filters,
                Sorts = request.Sorts,
                Groups = request.Groups,
                Aggregates = request.Aggregates
            };
            if (CurrentUser.CompanyID > 0)
            {

                //LogOrganization_GetAllBAL(ref int Total, string OrgID, string SearchText, string SortExpression, int StartRowIndex, int page, int PageSize)
                IList<CRM_UserLog> _userdata;
                if (kendoRequest.Filters.Count > 0)
                {
                    _userdata = this._UserBAL.ErrorLogOrganization_GetAllBAL(ref Total, CurrentUser.CompanyID.ToString(), SearchText, "ID", startRowIndex, request.Page, 20000);
                }
                else
                {
                    _userdata = this._UserBAL.ErrorLogOrganization_GetAllBAL(ref Total, CurrentUser.CompanyID.ToString(), SearchText, "ID", startRowIndex, request.Page, request.PageSize);

                }
                _userdata = _userdata.Distinct().ToList();
                var data = _userdata.ToDataSourceResult(kendoRequest);

                var result = new DataSourceResult()
                {
                    AggregateResults = data.AggregateResults,
                    Data = data.Data,
                    Errors = data.Errors,
                    Total = Total
                };
                return Json(result);

            }
            else
            {
                IList<CRM_UserLog> _userdata;
                if (kendoRequest.Filters.Count > 0)
                {
                    _userdata = this._UserBAL.ErrorLogOrganization_GetAllBAL(ref Total, CurrentUser.CompanyID.ToString(), SearchText, "ID", startRowIndex, request.Page, 20000);
                }
                else
                {
                    _userdata = this._UserBAL.ErrorLogOrganization_GetAllBAL(ref Total, CurrentUser.CompanyID.ToString(), SearchText, "ID", startRowIndex, request.Page, request.PageSize);

                }
                _userdata = _userdata.Distinct().ToList();
                var data = _userdata.ToDataSourceResult(kendoRequest);

                var result = new DataSourceResult()
                {
                    AggregateResults = data.AggregateResults,
                    Data = data.Data,
                    Errors = data.Errors,
                    Total = Total
                };
                return Json(result);

            }
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanEdirUserErrorLog")]
        public JsonResult EditStatusDone([DataSourceRequest]DataSourceRequest request, CRM_UserLog _objTask, string ID)
        {
            long _viewID = long.Parse(ID);
            _objTask.ResolvedBy = CurrentUser.NameIdentifierInt64;
            _objTask.ResolvedData = DateTime.Now;
            var _userdata = this._UserBAL.ErrorLogOrganization_GetAllBAL(_objTask,CurrentUser.CompanyID,_viewID);

            if (_userdata == -1)
            {
                ModelState.AddModelError(lr.ErrorServerError, lr.ResourceUpdateValidationError);
            }
            var resultData = new[] { _objTask };
            return Json(resultData, JsonRequestBehavior.AllowGet);
        }

    }
}