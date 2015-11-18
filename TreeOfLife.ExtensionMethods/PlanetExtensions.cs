using System.Linq;
using Ninject;
using TreeOfLife.Logic;
using TreeOfLife.Model;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.ExtensionMethods
{
    public static class PlanetExtensions
    {
        private static readonly IKernel Kernel;

        static PlanetExtensions()
        {
            Kernel = new StandardKernel(new LogicModule(), new DataModule());
        }

        public static PlanetWithPath GetPlanetWithPath(this Planet planet)
        {
            var pathRepository = Kernel.Get<IPathRepository>();
            var paths = pathRepository.ReadAll().ToList();
            var planetPath = paths.FirstOrDefault(p => p.KeyScale == planet.KeyScale);
            var terminalSephiroth = planetPath?.GetTerminalSephiroth();

            return new PlanetWithPath
            {
                Planet = planet,
                Path = planetPath,
                TerminalSephiroth = terminalSephiroth
            };
        }
    }
}