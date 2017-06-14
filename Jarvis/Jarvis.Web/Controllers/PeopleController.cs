using Jarvis.Web.Models.ViewModels;
using System.Web.Mvc;

namespace Jarvis.Web.Controllers
{
    [RoutePrefix("people")]
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        [Route("{id:int}/edit")]
        [Route("create")]
        public ActionResult Manage(int id = 0)
        {
            ItemViewModel<int> model = new ItemViewModel<int>();
            model.Item = id;
            return View();
        }
    }
}