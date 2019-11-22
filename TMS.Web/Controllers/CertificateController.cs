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
using System.Web.UI.WebControls;
using TMS.Business.Interfaces.TMS.Program;
using TMS.Business.TMS;
using TMS.Library.Entities.TMS.Program;
using TMS.Web.Core;

namespace TMS.Web.Controllers
{
    [SessionTimeout]
    public class CertificateController : TMSControllerBase
    {
        private readonly IClassBAL _ClassBAL;
        private  PersonBAL _CourseBAL=new PersonBAL();
        public CertificateController(IClassBAL IClassBAL)
        {
          
            _ClassBAL = IClassBAL;
        }
        // GET: Certificate
        [ClaimsAuthorize("CanPrintCertificates")]
        public ActionResult Index()
        {
            Session["ClassId"] = -1;
            Session["PersonId"] = -1;
            Session["IsDigital"] = -1;
            Session["certificateID"] = -1;
            return View();
        }
        [ClaimsAuthorize("CanViewProgramTrainee")]
        [DontWrapResult]
        public ActionResult ManageTrainee(long? ClassId)
        {
            return PartialView("_ManageTrainee", ClassId);
        }

        [ClaimsAuthorize("CanViewProgramTrainee")]
        [DontWrapResult]
        public ActionResult ManageTrainee_Read([DataSourceRequest] DataSourceRequest request, long? ClassID,long? certificateId)
        {
            ViewData["ClassTraineeClassIdCreating"] = ClassID;
            long val = 0;
            //IList<ClassTraineeMapping> obj=null;
            if (ClassID==null)
            {

            }
            else
            {
                val =Convert.ToInt64(ClassID);
            
            if (CurrentUser.CompanyID > 0)
            {
                    long cID = Convert.ToInt64(certificateId);
                return Json(_ClassBAL.ClassTraineeMappingCertificate_GetAllBALOrganization(CurrentCulture, val, CurrentUser.CompanyID,cID).ToDataSourceResult(request, ModelState));
            }
            else
            {
                return Json(_ClassBAL.ClassTraineeMapping_GetAllBAL(CurrentCulture, val).ToDataSourceResult(request, ModelState));
            }
            }
            return null;
        }
        [ClaimsAuthorize("CanPrintCertificates")]
        [DontWrapResult]
        [HttpPost]
        public void SetSessionValues(string _classID, string _personID, string IsDigital, string certificateID)
        {
            Session["ClassId"]  =_classID;
            Session["PersonId"] = _personID;
            Session["IsDigital"] = IsDigital;
            Session["certificateID"] = certificateID;
        }
       // [ClaimsAuthorize("CanPrintCertificates")]
        [DontWrapResult]
        //[HttpPost]
        public FileResult Print_Read()
        {
          
             string _classID = System.Web.HttpContext.Current.Session["ClassId"].ToString();
            string _personID= System.Web.HttpContext.Current.Session["PersonId"].ToString();
            string IsDigital= System.Web.HttpContext.Current.Session["IsDigital"].ToString();
            string certificateID = System.Web.HttpContext.Current.Session["certificateID"].ToString();
            if (_classID.Equals(-1) || _personID.Equals(-1) || IsDigital.Equals(-1) || certificateID.Equals(-1))
            {
                return null;
            }
            else
            { 
            int IsDigitalINT = Convert.ToInt32(IsDigital);
            long certificateIDLong = Convert.ToInt64(certificateID);
            if (IsDigitalINT==1)
            { 
            ReportViewer ReportViewerRSFReports = new ReportViewer();
            ReportViewerRSFReports.Height = Unit.Parse("100%");
            ReportViewerRSFReports.Width = Unit.Parse("100%");
            ReportViewerRSFReports.CssClass = "table";
            var rptPath = Server.MapPath(@"../Report/Tran_CertificatePrinting.rdlc");
            ReportViewerRSFReports.LocalReport.ReportPath = rptPath;
            long cID = Convert.ToInt64(CurrentUser.CompanyID);
            DataTable dt = _CourseBAL.GetCertificateReports(_personID, Convert.ToInt64(_classID), cID, "en-us",Convert.ToInt64(CurrentUser.NameIdentifierInt64), certificateIDLong);
            ReportViewerRSFReports.ProcessingMode = ProcessingMode.Local;
            ReportViewerRSFReports.LocalReport.DataSources.Clear();
            ReportViewerRSFReports.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dt));
            ReportViewerRSFReports.LocalReport.Refresh();
            byte[] mybytes = ReportViewerRSFReports.LocalReport.Render(format: "PDF", deviceInfo: ""); //for exporting to PDF  
                //Response.Clear();
                //Response.Buffer = true;
                //Response.Charset = "";
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.ContentType = "application/pdf";
                //Response.AppendHeader("Content-Disposition", "attachment; filename=RDLC.pdf");
                //Response.BinaryWrite(mybytes);
                //string pdfPath = @"~\TempReports\Certificate.pdf";       // Path to export Report.

                //System.IO.FileStream pdfFile = new System.IO.FileStream(pdfPath, System.IO.FileMode.Create);
                //pdfFile.Write(mybytes, 0, mybytes.Length);
                //pdfFile.Close();
                //Response.Flush();
                //Response.End();
                return File(mybytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Certificate.pdf");
                //return new JsonResult()
                //{
                //    Data = mybytes,
                //    MaxJsonLength = Int32.MaxValue
                //};
            }
            else
            {
                ReportViewer ReportViewerRSFReports = new ReportViewer();
                ReportViewerRSFReports.Height = Unit.Parse("100%");
                ReportViewerRSFReports.Width = Unit.Parse("100%");
                ReportViewerRSFReports.CssClass = "table";
                var rptPath = Server.MapPath(@"../Report/Tran_CertificateSimplePrint.rdlc");
                ReportViewerRSFReports.LocalReport.ReportPath = rptPath;
                long cID = Convert.ToInt64(CurrentUser.CompanyID);
                DataTable dt = _CourseBAL.GetCertificateReports(_personID, Convert.ToInt64(_classID), cID, "en-us", Convert.ToInt64(CurrentUser.NameIdentifierInt64), certificateIDLong);
                ReportViewerRSFReports.ProcessingMode = ProcessingMode.Local;
                ReportViewerRSFReports.LocalReport.DataSources.Clear();
                ReportViewerRSFReports.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", dt));
                ReportViewerRSFReports.LocalReport.Refresh();
                Byte[] mybytes = ReportViewerRSFReports.LocalReport.Render(format: "PDF", deviceInfo: ""); //for exporting to PDF  
                                                                                                           //Response.Clear();
                                                                                                           //Response.Buffer = true;
                                                                                                           //Response.Charset = "";
                                                                                                           //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                                                                                                           //Response.ContentType = "application/pdf";
                                                                                                           //Response.AppendHeader("Content-Disposition", "attachment; filename=RDLC.pdf");
                                                                                                           //Response.BinaryWrite(mybytes);
                                                                                                           //Response.Flush();
                                                                                                           //Response.End();
                                                                                                           //return Response;
                                                                                                           //return new JsonResult()
                                                                                                           //{
                                                                                                           //    Data = mybytes,
                                                                                                           //    MaxJsonLength = Int32.MaxValue
                                                                                                           //};
                Session["ClassId"] = -1;
                Session["PersonId"] = -1;
                Session["IsDigital"] = -1;
                Session["certificateID"] = -1;
                return File(mybytes, System.Net.Mime.MediaTypeNames.Application.Octet, "Certificate.pdf");
            }
            }
            
            // return Json(mybytes, JsonRequestBehavior.AllowGet,max);
            //byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\Users\SynergicProfessional\Desktop\VenueMatrixReport.pdf");
            //string fileName = "VenueMatrixReport.pdf";
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        //public void SavePDF(ReportViewer viewer, string savePath)

        //{
        //    byte[] Bytes = viewer.LocalReport.Render(format: "PDF", deviceInfo: "");

        //    using (FileStream stream = new FileStream(savePath, FileMode.Create))
        //    {
        //        stream.Write(Bytes, 0, Bytes.Length);
        //    }
        //}
    }
}