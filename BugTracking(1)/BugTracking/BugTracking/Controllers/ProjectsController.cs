using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracking.Controllers
{
    public class ProjectsController : Controller
    {
        //
        // GET: /Projects/
        public ActionResult Projects()
        {
            return View();
        }
	}
}