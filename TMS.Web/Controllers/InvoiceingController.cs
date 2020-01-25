using Abp.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using TMS.Business.Interfaces.Invoiceing;
using TMS.Business.Interfaces.TMS;
using TMS.Business.Interfaces.TMS.Program;
using TMS.Business.TMS;
using TMS.Library;
using TMS.Library.Entities.Invoice;
using TMS.Library.Entities.TMS.Program;
using TMS.Library.TMS;
using TMS.Web.Core;

namespace TMS.Web.Controllers
{
    [SessionTimeout]
    public class InvoiceingController : TMSControllerBase
    {
        private readonly IBALUsers _UserBAL;
        private readonly IInvoiceingBAL _CustomerBAL;
        public InvoiceingController(IBALUsers objUserBAL, IInvoiceingBAL customerBAL)
        {
            _UserBAL = objUserBAL; _CustomerBAL = customerBAL;
        }
        // GET: Invoiceing
        public ActionResult Index()
        {
            Session["InvoiceID"] = -1;
            return View();
        }
        [DontWrapResult]
        public ActionResult Invoice_Create([DataSourceRequest] DataSourceRequest request, Invoice _invoice)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_invoice);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to insert Invoice " + DateTime.UtcNow, "", 0, "Invoice", "Invoice_Create", json.ToString(), CurrentUser.CompanyID);

                _invoice.Generated_By = CurrentUser.NameIdentifierInt64;
                _invoice.Generated_Date = DateTime.UtcNow;
                _invoice.Organization_ID = CurrentUser.CompanyID;
                _invoice.ID = _CustomerBAL.create_InvoiceBAL(_invoice);
                var InvoiceIDd = _invoice.ID;
                var resultData2 = new[] { InvoiceIDd };
                return Json(new { success = true, responseText = InvoiceIDd }, JsonRequestBehavior.AllowGet);
            }
            var InvoiceID = _invoice.ID;
            var resultData = new[] { InvoiceID };
            return Json(new { success = false, responseText = InvoiceID }, JsonRequestBehavior.AllowGet);

            //return Json(resultData.ToDataSourceResult(request, ModelState));
        }
        [DontWrapResult]
        public ActionResult InvoiceDetail_Create([DataSourceRequest] DataSourceRequest request, InvoiceDetail _invoice)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_invoice);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to insert Invoice Detail at" + DateTime.UtcNow, "", 0, "Invoice", "InvoiceDetail_Create", json.ToString(), CurrentUser.CompanyID);
                _invoice.ID = _CustomerBAL.create_InvoiceDetailBAL(_invoice);
                var InvoiceIDd = _invoice.ID;
                var resultData2 = new[] { InvoiceIDd };
                return Json(new { success = true, responseText = InvoiceIDd }, JsonRequestBehavior.AllowGet);
            }
            var InvoiceID = _invoice.ID;
            var resultData = new[] { InvoiceID };
            return Json(new { success = false, responseText = InvoiceID }, JsonRequestBehavior.AllowGet);

            //return Json(resultData.ToDataSourceResult(request, ModelState));
        }
        [DontWrapResult]
        [HttpPost]
        public void SetSessionValues(string _InoID)
        {
            Session["InvoiceID"] = _InoID;
        }
        // [ClaimsAuthorize("CanPrintCertificates")]
        [DontWrapResult]
        //[HttpPost]
        public FileResult PrintInvoice_Read()
        {

            string _classID = System.Web.HttpContext.Current.Session["InvoiceID"].ToString();
            if (_classID.Equals("-1"))
            {
                Session["InvoiceID"] = -1;
                return null;
            }
            else
            {

                ReportViewer ReportViewerRSFReports = new ReportViewer();
                ReportViewerRSFReports.Height = Unit.Parse("100%");
                ReportViewerRSFReports.Width = Unit.Parse("100%");
                ReportViewerRSFReports.CssClass = "table";
                var rptPath = Server.MapPath(@"../Report/INO_InvoiceRecipt.rdlc");
                ReportViewerRSFReports.LocalReport.ReportPath = rptPath;
                long cID = Convert.ToInt64(CurrentUser.CompanyID);
                DataTable dt = _CustomerBAL.GetInvoiceReportsBAL(Convert.ToInt64(_classID), Convert.ToInt64(CurrentUser.CompanyID));
                ReportViewerRSFReports.ProcessingMode = ProcessingMode.Local;
                ReportViewerRSFReports.LocalReport.DataSources.Clear();
                ReportViewerRSFReports.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                ReportViewerRSFReports.LocalReport.Refresh();
                byte[] mybytes = ReportViewerRSFReports.LocalReport.Render(format: "PDF", deviceInfo: "");
                Session["InvoiceID"] = -1;
                return File(mybytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Invoice.pdf");


            }

        }
        public ActionResult InvoiceGrid()
        {
            return View();
        }
        [DontWrapResult]
        public ActionResult Invoice_Read([DataSourceRequest] DataSourceRequest request)
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
            IList<Invoice> _person;
            if (kendoRequest.Filters.Count > 0)
            {
                _person = _CustomerBAL.Read_InvoiceBAL(ref Total, CurrentCulture, SearchText, GridHelper.GetSortExpression(request, "ID").ToString(), startRowIndex, request.Page, 10000, CurrentUser.CompanyID);

            }
            else
            {
                _person = this._CustomerBAL.Read_InvoiceBAL(ref Total, CurrentCulture, SearchText, GridHelper.GetSortExpression(request, "ID").ToString(), startRowIndex, request.Page, request.PageSize, CurrentUser.CompanyID);

            }
            _person = _person.Distinct().ToList();
            var data = _person.ToDataSourceResult(kendoRequest);
            var result = new DataSourceResult()
            {
                AggregateResults = data.AggregateResults,
                Data = data.Data,
                Errors = data.Errors,
                Total = Total
            };
            return Json(result);
        }
        [DontWrapResult]
        public ActionResult InvoiceDetail_Read([DataSourceRequest] DataSourceRequest request, long InvoiceID)
        {

            IList<InvoiceDetail> _person = this._CustomerBAL.Read_InvoiceDetailBAL(InvoiceID);
            var kendoRequest = new Kendo.Mvc.UI.DataSourceRequest
            {
                Filters = request.Filters,
                Sorts = request.Sorts,
                Groups = request.Groups,
                Aggregates = request.Aggregates
            };

            _person = _person.Distinct().ToList();
            var data = _person.ToDataSourceResult(kendoRequest);
            var result = new DataSourceResult()
            {
                AggregateResults = data.AggregateResults,
                Data = data.Data,
                Errors = data.Errors,
            };
            return Json(result);
        }
        [DontWrapResult]
        public ActionResult InvoiceDetail(string Inoid)
        {
            if (string.IsNullOrEmpty(Inoid))
            {
                return RedirectPermanent(Url.Content("~/Invoiceing/Index"));
            }
            else
            {
                var data = _CustomerBAL.Read_InvoiceByIDBAL(Inoid);
                if (data == null)
                {
                    ViewData["model"] = Url.Content("~/Invoiceing/Index");
                    return View("Static/NotFound");
                }
                else
                {
                    _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.View_Success.ToString(), System.Environment.MachineName, "User tried to View Persons Detail " + DateTime.UtcNow, "", 0, "People", "Detail", Inoid.ToString(), CurrentUser.CompanyID);
                    ViewData["model"] = data;
                    return View();
                }
            }
        }
        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonEmail")]
        public ActionResult InvoiceHistory(string PersonID)
        {
            return PartialView("_InvoiceHistoryRead", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonEmail")]
        public ActionResult InvoiceHistoryRead([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _Phone = _CustomerBAL.Read_InvoiceHistoryBAL(PersonID);
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }
        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonEmail")]
        public ActionResult InvoiceReIssued(string PersonID)
        {
            return PartialView("_InvoiceReIssued", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonEmail")]
        public ActionResult InvoiceReIssuedRead([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _Phone = _CustomerBAL.Read_InvoiceReIssuedByBAL(PersonID);
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }
    }
}