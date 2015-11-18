using TreeOfLife.Model;

namespace TreeOfLife.Logic.Factories
{
    public interface IElementFactory
    {
        Element Create(string id, int keyScale, string name, string symbol);
    }
}