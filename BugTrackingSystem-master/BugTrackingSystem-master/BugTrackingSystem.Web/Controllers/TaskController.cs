using System.Web.Mvc;

namespace BugTrackingSystem.Web.Controllers
{
    public class TaskController : Controller
    {
        //
        // GET: /Task/
        public ActionResult Task()
        {
            return View();
        }
    }
}