using System.Linq;
using System.Web.Mvc;
using Ninject;
using TreeOfLife.ExtensionMethods;
using TreeOfLife.Logic;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Web.Controllers
{
    public class PlanetController : Controller
    {
        public static readonly IKernel Kernel;
        public static readonly IPlanetRepository PlanetRepository;

        static PlanetController()
        {
            Kernel = new StandardKernel(new LogicModule(), new DataModule());
            PlanetRepository = Kernel.Get<IPlanetRepository>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public string PlanetNames()
        {
            return
                (from p in PlanetRepository.ReadAll() orderby p.Name descending select p.Name).Aggregate(
                    (list, planet) => $"{planet}, {list}");
        }

        public ActionResult PlanetList()
        {
            return View(PlanetRepository.ReadAll());
        }

        public ActionResult PlanetListWithPaths()
        {
            var planets = PlanetRepository.ReadAll();
            var planetsWithPaths = PlanetRepository.ReadAll().Select(planet => planet.GetPlanetWithPath()).ToList();

            return View(planetsWithPaths);
        }
        public ActionResult PlanetaryMetals()
        {
            var planetsWithMetals = PlanetRepository.ReadAll().Select(planet => planet.GetPlanetWithMetal()).ToList();

            return View(planetsWithMetals);
        }
    }
}