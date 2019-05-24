using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMS.Web.Controllers
{
    public class TestSPController : Controller
    {
        // GET: TestSP
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult cerate()
        {
            return View();
        }

    }
}