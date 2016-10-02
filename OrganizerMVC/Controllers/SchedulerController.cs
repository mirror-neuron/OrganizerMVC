using System.Web.Mvc;
using OrganizerMVC.Models;

namespace OrganizerMVC.Controllers
{
    public class SchedulerController : Controller
    {
        // GET: Scheduler
        public ActionResult Index()
        {
            return View(new ImproperCalendarEvent());
        }
    }
}