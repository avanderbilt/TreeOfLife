using TreeOfLife.Model;

namespace TreeOfLife.Logic.Factories
{
    public interface IZodiacSignFactory
    {
        ZodiacSign Create(string id, int keyScale, string name, char glyph);
    }
}