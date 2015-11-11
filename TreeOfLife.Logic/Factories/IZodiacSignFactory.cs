using TreeOfLife.Model;

namespace TreeOfLife.Logic.Factories
{
    public interface IZodiacSignFactory
    {
        ZodiacSign Create(string id, int keyScale, int number, string name, char glyph);
    }
}