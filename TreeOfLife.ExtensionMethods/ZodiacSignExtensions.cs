using System.Linq;
using Ninject;
using TreeOfLife.Logic;
using TreeOfLife.Model;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.ExtensionMethods
{
    public static class ZodiacSignExtensions
    {
        private static readonly IKernel Kernel;

        static ZodiacSignExtensions()
        {
            Kernel = new StandardKernel(new LogicModule(), new DataModule());
        }

        public static ZodiacSignWithPath GetZodiacSignWithPath(this ZodiacSign zodiacSign)
        {
            var pathRepository = Kernel.Get<IPathRepository>();
            var paths = pathRepository.ReadAll().ToList();
            var planetPath = paths.FirstOrDefault(p => p.KeyScale == zodiacSign.KeyScale);
            var terminalSephiroth = planetPath?.GetTerminalSephiroth();

            return new ZodiacSignWithPath
            {
                ZodiacSign = zodiacSign,
                Path = planetPath,
                TerminalSephiroth = terminalSephiroth
            };
        }

    }
}