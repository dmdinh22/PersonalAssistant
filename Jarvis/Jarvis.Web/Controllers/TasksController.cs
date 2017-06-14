using System.Web.Mvc;

namespace Jarvis.Web.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index()
        {
            return View();
        }
    }
}