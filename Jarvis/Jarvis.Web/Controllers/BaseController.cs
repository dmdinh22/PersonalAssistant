using Jarvis.Web.Models.ViewModels;
using System.Web.Mvc;

namespace Jarvis.Web.Controllers
{
    public class BaseController : Controller
    {
        public new ViewResult View()
        {
            BaseViewModel model = GetViewModel<BaseViewModel>();
            DecorateViewModel<BaseViewModel>(model);
            return base.View(model);
        }

        protected T GetViewModel<T>() where T : BaseViewModel, new()
        {
            T model = new T();
            return model;
        }

        protected T DecorateViewModel<T>(T model) where T : BaseViewModel
        {
            return model;
        }
    }
}