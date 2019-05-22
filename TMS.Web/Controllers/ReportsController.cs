using Abp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Telerik.Reporting.Cache.Interfaces;
using Telerik.Reporting.Services.Engine;
using Telerik.Reporting.Services.WebApi;
using TMS.Web;

namespace TMS.Reporting.Controllers
{
    public class ReportsController : ReportsControllerBase
    {
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        protected override IReportResolver CreateReportResolver()
        {
            var reportsPath = HttpContext.Current.Server.MapPath("~/Reports");
            return new ReportFileResolver(reportsPath).AddFallbackResolver(new ReportTypeResolver());
        }
        [DontWrapResult]
        [ActivityAuthorize]
        [ClaimsAuthorize("CanAddEditUsers")]
        protected override ICache CreateCache()
        {
            return Telerik.Reporting.Services.Engine.CacheFactory.CreateFileCache();
        }
    }
}