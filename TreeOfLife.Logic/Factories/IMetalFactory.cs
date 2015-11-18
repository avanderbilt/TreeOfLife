using TreeOfLife.Model;

namespace TreeOfLife.Logic.Factories
{
    public interface IMetalFactory
    {
        Metal Create(string id, int keyScale, string name);
    }
}