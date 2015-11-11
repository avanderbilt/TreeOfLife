using TreeOfLife.Model;

namespace TreeOfLife.Logic.Factories
{
    public interface IPathFactory
    {
        Path Create(string id, int keyScale, int number, int from, int to);
    }
}