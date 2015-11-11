using System.Linq;
using Ninject;
using TreeOfLife.Logic;
using TreeOfLife.Model;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.ExtensionMethods
{
    public static class PathExtensions
    {
        private static readonly IKernel Kernel;

        static PathExtensions()
        {
            Kernel = new StandardKernel(new LogicModule(), new DataModule());
        }

        public static SephiraPair GetTerminalSephiroth(this Path path)
        {
            var sephiraRepository = Kernel.Get<ISephiraRepository>();

            var sephiroth = sephiraRepository.ReadAll().ToList();

            var pair = new SephiraPair
            {
                From = sephiroth.First(s => s.KeyScale == path.From),
                To = sephiroth.First(s => s.KeyScale == path.To)
            };

            return pair;
        }

        public static PathWithHebrewLetter GetPathWithHebrewLetter(this Path path)
        {
            var hebrewLetterRepository = Kernel.Get<IHebrewLetterRepository>();
            var hebrewLetters = hebrewLetterRepository.ReadAll();
            var hebrewLetter = hebrewLetters.First(l => l.KeyScale == path.KeyScale);

            return new PathWithHebrewLetter
            {
                Path = path,
                HebrewLetter = hebrewLetter,
                TerminalSephiroth = path.GetTerminalSephiroth()
            };
        }
    }
}