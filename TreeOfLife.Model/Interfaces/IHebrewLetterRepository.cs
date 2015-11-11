using System.Collections.Generic;

namespace TreeOfLife.Model.Interfaces
{
    public interface IHebrewLetterRepository : IRepository
    {
        IEnumerable<HebrewLetter> ReadAll();
        void Update(HebrewLetter letter);
    }
}