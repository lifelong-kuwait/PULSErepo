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
using TMS.Library.TMS.Organization;
using TMS.Web.Core;
using lr = Resources.Resources;
namespace TMS.Web.Controllers
{
    [SessionTimeout]
    public class InvoiceingController : TMSControllerBase
    {
        private readonly IBALUsers _UserBAL;
        private readonly IInvoiceingBAL _CustomerBAL;
       private PersonBAL _PersonBAL = new PersonBAL();
        public InvoiceingController(IBALUsers objUserBAL, IInvoiceingBAL customerBAL)
        {
            _UserBAL = objUserBAL; _CustomerBAL = customerBAL;
        }
        // GET: Invoiceing
        public ActionResult Index()
        {
            Session["InvoiceID"] = -1;
            Session["InoID"] = -1;
            Session["DepoID"] = -1;
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
                InvoiceHistory invoiceHistory = new InvoiceHistory();
                invoiceHistory.History_Name = "Invoice Create";
                invoiceHistory.Type = HistoryType.InvoiceCreate;
                invoiceHistory.Description = "";
                invoiceHistory.Invoice_Number = _invoice.ID;
                invoiceHistory.User_ID = CurrentUser.NameIdentifierInt64;
                invoiceHistory.Organization_ID = CurrentUser.CompanyID;
                invoiceHistory.Date_TIME = DateTime.Now;
                var x=_CustomerBAL.create_InvoiceHistoryBAL(invoiceHistory);
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
        public ActionResult Invoice_Update([DataSourceRequest] DataSourceRequest request, Invoice _invoice)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_invoice);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to insert Invoice " + DateTime.UtcNow, "", 0, "Invoice", "Invoice_Create", json.ToString(), CurrentUser.CompanyID);
                _invoice.Generated_By = CurrentUser.NameIdentifierInt64;
                _invoice.Generated_Date = DateTime.UtcNow;
                _invoice.Organization_ID = CurrentUser.CompanyID;
                var xx = _CustomerBAL.Update_InvoiceBAL(_invoice);
                InvoiceHistory invoiceHistory = new InvoiceHistory();
                invoiceHistory.History_Name = "Invoice Update";
                invoiceHistory.Type = HistoryType.InvoiceCreate;
                invoiceHistory.Description = "";
                invoiceHistory.Invoice_Number = _invoice.ID;
                invoiceHistory.User_ID = CurrentUser.NameIdentifierInt64;
                invoiceHistory.Organization_ID = CurrentUser.CompanyID;
                invoiceHistory.Date_TIME = DateTime.Now;
                var x = _CustomerBAL.create_InvoiceHistoryBAL(invoiceHistory);
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
        public ActionResult InvoiceDetail_Update([DataSourceRequest] DataSourceRequest request, InvoiceDetail _invoice)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_invoice);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to insert Invoice Detail at" + DateTime.UtcNow, "", 0, "Invoice", "InvoiceDetail_Create", json.ToString(), CurrentUser.CompanyID);
                var x = _CustomerBAL.Update_InvoiceDetailBAL(_invoice);
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
                ReIssued reIssued = new ReIssued();
                reIssued.Invoice_ID = Convert.ToInt64(_classID);
                reIssued.Re_Issued_By = CurrentUser.NameIdentifierInt64;
                reIssued.Re_Issued_Date = DateTime.Now;
                reIssued.Organization_ID = CurrentUser.CompanyID;
                reIssued.ID = _CustomerBAL.create_InvoiceReIssueBAL(reIssued);
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
        [DontWrapResult]
        public ActionResult InvoiceEdit(string Inoid)
        {
            if (string.IsNullOrEmpty(Inoid))
            {
                return RedirectPermanent(Url.Content("~/Invoiceing/Index"));
            }
            else
            {
                var data = _CustomerBAL.Read_InvoiceByIDBAL(Inoid);
                if (data.Referance_Number == null)
                {
                    ViewData["model"] = Url.Content("~/Invoiceing/Index");
                    return View("Static/NotFound");
                }
                else
                {
                    IList<InvoiceDetail> _person = this._CustomerBAL.Read_InvoiceDetailBAL(Convert.ToInt64(Inoid));
                    List<InvoiceDetail> subProducts = new List<InvoiceDetail>(_person);
                    data.invoiceDetailslist = subProducts;
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
        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonEmail")]
        public ActionResult InvoiceDeposit(string PersonID)
        {
            return PartialView("_InvoiceDeposit", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonEmail")]
        public ActionResult InvoiceDeposit_Read([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _Phone = _CustomerBAL.Read_InvoiceDepositBAL(PersonID);
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }
        [ClaimsAuthorize("CanAddEditCourse")]
        [DontWrapResult]
        public ActionResult InvoiceDeposit_Create([DataSourceRequest] DataSourceRequest request, DepositDetail _DepositDetail, string PersonID)
        {
            if (ModelState.IsValid)
            {
                var json = new JavaScriptSerializer().Serialize(_DepositDetail);
                _UserBAL.LogInsert(DateTime.Now.ToString(), "10", Logs.Insert_Success.ToString(), System.Environment.MachineName, "User tried to create Courses at" + DateTime.UtcNow + " with user id =" + CurrentUser.NameIdentifierInt64, "", 0, this.ControllerContext.RouteData.Values["controller"].ToString(), this.ControllerContext.RouteData.Values["action"].ToString(), json.ToString(), CurrentUser.CompanyID);
                
                _DepositDetail.Invoice_ID = PersonID;
                var x = this._CustomerBAL.InvoiceBalanceCheckBAL(_DepositDetail);
                var xx = this._CustomerBAL.InvoiceGrossTotalCheckBAL(_DepositDetail);
                double invoiceTotalPayment = Convert.ToDouble(x);
                double invoiceGrossTotal = Convert.ToDouble(xx);
                double balance = Math.Round(invoiceGrossTotal, 2)  - Math.Round(invoiceTotalPayment, 2);
                balance = Math.Round(balance, 2);
                if (balance == 0)
                {
                    ModelState.AddModelError(lr.PersonSkill, lr.FlagDuplicationCheck);
                }
                else if (balance >= _DepositDetail.Payment)
                {
                    _DepositDetail.Created_By = CurrentUser.NameIdentifierInt64;
                    _DepositDetail.Created_Date = DateTime.Now;
                    _DepositDetail.Organization_ID = CurrentUser.CompanyID;
                    _DepositDetail.ID = this._CustomerBAL.InvoicePaymentDepositeCreateBAL(_DepositDetail);
                }
                else
                {
                    ModelState.AddModelError(lr.ErrorServerError, lr.FlagDuplicationCheck);
                }
                //if (this._CustomerBAL.InvoiceBalanceCheckBAL(_DepositDetail) > 0)
                //{
                //    ModelState.AddModelError(lr.PersonSkill, lr.FlagDuplicationCheck);
                //}
                //else
                //{
                //    //_Course.ID = this._CourseBAL.TMS_Courses_CreateBAL(_Course);
                //    //string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                //    //if (string.IsNullOrEmpty(ip))
                //    //    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                //    //_objConfigurationBAL.Audit_CreateBAL(ip, DateTime.Now, CurrentUser.CompanyID, CurrentUser.NameIdentifierInt64, EventType.Create, System.Web.HttpContext.Current.Request.Browser.Browser);
                //}
            }

            var resultData = new[] { _DepositDetail };
            return Json(resultData.ToDataSourceResult(request, ModelState));
        }
        [DontWrapResult]
        [HttpPost]
        public void SetSessionDepositValues(string _InoID,string _DepositID)
        {
            Session["InoID"] = _InoID;
            Session["DepoID"] = _DepositID;
        }
        // [ClaimsAuthorize("CanPrintCertificates")]
        [DontWrapResult]
        //[HttpPost]
        public FileResult PrintDepositSlip_Read()
        {


            string _InvoiceID = System.Web.HttpContext.Current.Session["InoID"].ToString();
            string _DepositID = System.Web.HttpContext.Current.Session["DepoID"].ToString();
            if (_InvoiceID.Equals("-1")|| _DepositID.Equals("-1"))
            {
                Session["InoID"] = -1;
                Session["DepoID"] = -1;
                return null;
            }
            else
            {
                //ReIssued reIssued = new ReIssued();
                //reIssued.Invoice_ID = Convert.ToInt64(_classID);
                //reIssued.Re_Issued_By = CurrentUser.NameIdentifierInt64;
                //reIssued.Re_Issued_Date = DateTime.Now;
                //reIssued.Organization_ID = CurrentUser.CompanyID;
                //reIssued.ID = _CustomerBAL.create_InvoiceReIssueBAL(reIssued);
                ReportViewer ReportViewerRSFReports = new ReportViewer();
                ReportViewerRSFReports.Height = Unit.Parse("100%");
                ReportViewerRSFReports.Width = Unit.Parse("100%");
                ReportViewerRSFReports.CssClass = "table";
                var rptPath = Server.MapPath(@"../Report/INO_Deposit_Slips_For_Invoices.rdlc");
                ReportViewerRSFReports.LocalReport.ReportPath = rptPath;
                long cID = Convert.ToInt64(CurrentUser.CompanyID);
                DataTable dt = _CustomerBAL.GetInvoiceDepositReportsBAL(Convert.ToInt64(_InvoiceID), Convert.ToInt64(_DepositID), Convert.ToInt64(CurrentUser.CompanyID));
                ReportViewerRSFReports.ProcessingMode = ProcessingMode.Local;
                ReportViewerRSFReports.LocalReport.DataSources.Clear();
                ReportViewerRSFReports.LocalReport.EnableExternalImages = true;
                List<OrganizationModel> logoPath = _PersonBAL.GetOrganizationLogo(CurrentUser.CompanyID);
                ReportParameter paramLogo = new ReportParameter();
                paramLogo.Name = "Path";
                string imagePath = new Uri(Server.MapPath(@"~/" + logoPath.FirstOrDefault().Logo)).AbsoluteUri;
                paramLogo.Values.Add(imagePath);
                ReportViewerRSFReports.LocalReport.SetParameters(paramLogo);
                ReportViewerRSFReports.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                ReportViewerRSFReports.LocalReport.Refresh();
                byte[] mybytes = ReportViewerRSFReports.LocalReport.Render(format: "PDF", deviceInfo: "");
                Session["InoID"] = -1;
                Session["DepoID"] = -1;
                return File(mybytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Invoice.pdf");


            }


        }
        [ContentAuthorize]
        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonEmail")]
        public ActionResult InvoiceChanges(string PersonID)
        {
            return PartialView("_InvoiceChanges", PersonID);
        }

        [DontWrapResult]
        [ClaimsAuthorize("CanViewPersonEmail")]
        public ActionResult InvoiceChanges_Read([DataSourceRequest] DataSourceRequest request, string PersonID)
        {
            var _Phone = _CustomerBAL.Read_InvoiceChangesBAL(PersonID);
            return Json(_Phone.ToDataSourceResult(request, ModelState));
        }

    }
}