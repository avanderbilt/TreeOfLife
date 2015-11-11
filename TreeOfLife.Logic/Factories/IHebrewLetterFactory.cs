using TreeOfLife.Model;

namespace TreeOfLife.Logic.Factories
{
    public interface IHebrewLetterFactory
    {
        HebrewLetter Create(string id, int keyScale, char letter, int number, string name, string meaning);
    }
}