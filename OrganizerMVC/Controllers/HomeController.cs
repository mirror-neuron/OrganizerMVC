using System.Web.Mvc;

namespace OrganizerMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "Главная.";

            return View("Index");
        }
    }
}
