using TreeOfLife.Model;

namespace TreeOfLife.Logic.Factories
{
    public interface ISephiraFactory
    {
        Sephira Create(string id, int keyScale, int number, string name, string meaning);
    }
}