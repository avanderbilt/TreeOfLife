using TreeOfLife.Model;

namespace TreeOfLife.Logic.Factories
{
    public interface IPlanetFactory
    {
        Planet Create(string id, int keyScale, string name, char glyph);
    }
}