using System.Web.Mvc;

namespace Jarvis.Web.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            return View();
        }
    }
}