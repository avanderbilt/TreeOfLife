using Ninject.Modules;
using TreeOfLife.Data;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Logic
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITreeOfLifeDatabase>().To<TreeOfLifeDatabase>();
            Bind<ITreeOfLifeSession>().To<TreeOfLifeSession>();
        }
    }
}