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
    public class InvoiceingController : Controller
    {
        // GET: Invoiceing
        public ActionResult Index()
        {
            return View();
        }
    }
}