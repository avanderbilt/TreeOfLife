using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TreeOfLife.Logic.Factories;
using TreeOfLife.Model;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Logic.Repositories
{
    public class HebrewLetterRepository : IHebrewLetterRepository
    {
        private readonly IReadOnlyCollection<HebrewLetter> _hebrewLetters;
        private readonly ITreeOfLifeSession _session;

        public HebrewLetterRepository(IHebrewLetterFactory hebrewLetterFactory, ITreeOfLifeSession session)
        {
            _session = session;

            _hebrewLetters = new ReadOnlyCollection<HebrewLetter>(new List<HebrewLetter>
            {
                hebrewLetterFactory.Create("HebrewLetters/1", 11, '\u05D0', 1, "Aleph", "Ox"),
                hebrewLetterFactory.Create("HebrewLetters/2", 12, '\u05D1', 2, "Beth", "House"),
                hebrewLetterFactory.Create("HebrewLetters/3", 13, '\u05D2', 3, "Gimel", "Camel"),
                hebrewLetterFactory.Create("HebrewLetters/4", 14, '\u05D3', 4, "Daleth", "Door"),
                hebrewLetterFactory.Create("HebrewLetters/5", 15, '\u05D4', 5, "He", "Window"),
                hebrewLetterFactory.Create("HebrewLetters/6", 16, '\u05D5', 6, "Vau", "Nail"),
                hebrewLetterFactory.Create("HebrewLetters/7", 17, '\u05D6', 7, "Zain", "Sword"),
                hebrewLetterFactory.Create("HebrewLetters/8", 18, '\u05D7', 8, "Cheth", "Fence"),
                hebrewLetterFactory.Create("HebrewLetters/9", 19, '\u05D8', 9, "Teth", "Serpent"),
                hebrewLetterFactory.Create("HebrewLetters/10", 20, '\u05D9', 10, "Yod", "Hand"),
                hebrewLetterFactory.Create("HebrewLetters/11", 21, '\u05DB', 11, "Kaph", "Palm"),
                hebrewLetterFactory.Create("HebrewLetters/12", 22, '\u05DC', 12, "Lamed", "Ox Goad"),
                hebrewLetterFactory.Create("HebrewLetters/13", 23, '\u05DE', 13, "Maim", "Water"),
                hebrewLetterFactory.Create("HebrewLetters/14", 24, '\u05E0', 14, "Nun", "Fish"),
                hebrewLetterFactory.Create("HebrewLetters/15", 25, '\u05E1', 15, "Samekh", "Prop"),
                hebrewLetterFactory.Create("HebrewLetters/16", 26, '\u05E2', 16, "Ayin", "Eye"),
                hebrewLetterFactory.Create("HebrewLetters/17", 27, '\u05E4', 17, "Pe", "Mouth"),
                hebrewLetterFactory.Create("HebrewLetters/18", 28, '\u05E6', 18, "Tzaddi", "Fish-Hook"),
                hebrewLetterFactory.Create("HebrewLetters/19", 29, '\u05E7', 19, "Qoph", "Back of Head"),
                hebrewLetterFactory.Create("HebrewLetters/20", 30, '\u05E8', 20, "Resh", "Head"),
                hebrewLetterFactory.Create("HebrewLetters/21", 31, '\u05E9', 21, "Shin", "Tooth"),
                hebrewLetterFactory.Create("HebrewLetters/22", 32, '\u05EA', 22, "Tau", "Tau (as Egyptian)")
            });
        }

        public void DeleteAll()
        {
            _session.DeleteAll<HebrewLetter>();
        }

        public IEnumerable<HebrewLetter> ReadAll()
        {
            return _session.Query<HebrewLetter>().OrderBy(l => l.Number);
        }

        public void StoreData()
        {
            _session.Store(_hebrewLetters);
        }

        public void Update(HebrewLetter letter)
        {
            _session.Update(letter);
        }
    }
}