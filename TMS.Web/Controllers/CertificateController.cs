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
                return Json(_ClassBAL.ClassTraineeMappingCertificate_GetAllBALOrganization(CurrentCulture, val, CurrentUser.CompanyID).ToDataSourceResult(request, ModelState));
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
        public ActionResult Print_Read(string _classID,string _personID,int IsDigital,long certificateID)
        {
            if(IsDigital==1)
            { 
            ReportViewer ReportViewerRSFReports = new ReportViewer();
            ReportViewerRSFReports.Height = Unit.Parse("100%");
            ReportViewerRSFReports.Width = Unit.Parse("100%");
            ReportViewerRSFReports.CssClass = "table";
            var rptPath = Server.MapPath(@"../Report/Tran_CertificatePrinting.rdlc");
            ReportViewerRSFReports.LocalReport.ReportPath = rptPath;
            long cID = Convert.ToInt64(CurrentUser.CompanyID);
            DataTable dt = _CourseBAL.GetCertificateReports(_personID, Convert.ToInt64(_classID), cID, "en-us",Convert.ToInt64(CurrentUser.NameIdentifierInt64));
            ReportViewerRSFReports.ProcessingMode = ProcessingMode.Local;
            ReportViewerRSFReports.LocalReport.DataSources.Clear();
            ReportViewerRSFReports.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            ReportViewerRSFReports.LocalReport.Refresh();
            Byte[] mybytes = ReportViewerRSFReports.LocalReport.Render(format: "PDF", deviceInfo: ""); //for exporting to PDF  
             
            return new JsonResult()
            {
                Data = mybytes,
                MaxJsonLength = Int32.MaxValue
            };
            }else
            {
                ReportViewer ReportViewerRSFReports = new ReportViewer();
                ReportViewerRSFReports.Height = Unit.Parse("100%");
                ReportViewerRSFReports.Width = Unit.Parse("100%");
                ReportViewerRSFReports.CssClass = "table";
                var rptPath = Server.MapPath(@"../Report/Tran_CertificateSimplePrint.rdlc");
                ReportViewerRSFReports.LocalReport.ReportPath = rptPath;
                long cID = Convert.ToInt64(CurrentUser.CompanyID);
                DataTable dt = _CourseBAL.GetCertificateReports(_personID, Convert.ToInt64(_classID), cID, "en-us", Convert.ToInt64(CurrentUser.NameIdentifierInt64));
                ReportViewerRSFReports.ProcessingMode = ProcessingMode.Local;
                ReportViewerRSFReports.LocalReport.DataSources.Clear();
                ReportViewerRSFReports.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                ReportViewerRSFReports.LocalReport.Refresh();
                Byte[] mybytes = ReportViewerRSFReports.LocalReport.Render(format: "PDF", deviceInfo: ""); //for exporting to PDF  

                return new JsonResult()
                {
                    Data = mybytes,
                    MaxJsonLength = Int32.MaxValue
                };
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