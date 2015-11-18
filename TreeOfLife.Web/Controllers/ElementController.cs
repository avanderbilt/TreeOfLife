using System.Web.Mvc;
using Ninject;
using TreeOfLife.Logic;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Web.Controllers
{
    public class ElementController : Controller
    {
        public static readonly IKernel Kernel;
        public static readonly IElementRepository ElementRepository;

        static ElementController()
        {
            Kernel = new StandardKernel(new LogicModule(), new DataModule());
            ElementRepository = Kernel.Get<IElementRepository>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ElementList()
        {
            return View(ElementRepository.ReadAll());
        }

    }
}