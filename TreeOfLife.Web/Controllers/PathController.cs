using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using TreeOfLife.ExtensionMethods;
using TreeOfLife.Logic;
using TreeOfLife.Model;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Web.Controllers
{
    public class PathController : Controller
    {
        public static readonly IKernel Kernel;
        public static readonly IPathRepository PathRepository;

        static PathController()
        {
            Kernel = new StandardKernel(new LogicModule(), new DataModule());
            PathRepository = Kernel.Get<IPathRepository>();
        }

        // GET: Path
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PathList()
        {
            var paths = PathRepository.ReadAll().ToList();
            var pathsWithHebrewLetters = new List<PathWithHebrewLetter>();

            foreach (var path in paths)
            {
                pathsWithHebrewLetters.Add(path.GetPathWithHebrewLetter());
            }

            return View(pathsWithHebrewLetters);
        }
    }
}