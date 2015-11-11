using Ninject.Extensions.Factory;
using Ninject.Modules;
using TreeOfLife.Logic.Factories;
using TreeOfLife.Logic.Repositories;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHebrewLetterRepository>().To<HebrewLetterRepository>();
            Bind<IPathRepository>().To<PathRepository>();
            Bind<IPlanetRepository>().To<PlanetRepository>();
            Bind<ISephiraRepository>().To<SephiraRepository>();
            Bind<IZodiacSignRepository>().To<ZodiacSignRepository>();
            Bind<IPathFactory>().ToFactory();
            Bind<IPlanetFactory>().ToFactory();
            Bind<IHebrewLetterFactory>().ToFactory();
            Bind<ISephiraFactory>().ToFactory();
            Bind<IZodiacSignFactory>().ToFactory();
            Bind<ITreeUtilities>().To<TreeUtilities>();
            Bind<ITree>().To<Tree>();
        }
    }
}