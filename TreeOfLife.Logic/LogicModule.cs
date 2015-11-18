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
            Bind<IElementFactory>().ToFactory();
            Bind<IElementRepository>().To<ElementRepository>();
            Bind<IHebrewLetterFactory>().ToFactory();
            Bind<IHebrewLetterRepository>().To<HebrewLetterRepository>();
            Bind<IPathFactory>().ToFactory();
            Bind<IPathRepository>().To<PathRepository>();
            Bind<IPlanetFactory>().ToFactory();
            Bind<IPlanetRepository>().To<PlanetRepository>();
            Bind<ISephiraFactory>().ToFactory();
            Bind<ISephiraRepository>().To<SephiraRepository>();
            Bind<ITree>().To<Tree>();
            Bind<ITreeUtilities>().To<TreeUtilities>();
            Bind<IZodiacSignFactory>().ToFactory();
            Bind<IZodiacSignRepository>().To<ZodiacSignRepository>();
            Bind<IMetalFactory>().ToFactory();
            Bind<IMetalRepository>().To<MetalRepository>();
        }
    }
}