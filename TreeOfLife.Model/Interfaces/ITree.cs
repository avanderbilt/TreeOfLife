using System.Collections.Generic;

namespace TreeOfLife.Model.Interfaces
{
    public interface ITree
    {
        IEnumerable<HebrewLetter> HebrewLetters { get; }
        IEnumerable<Path> Paths { get; }
        IEnumerable<Planet> Planets { get; }
        IEnumerable<Sephira> Sephiroth { get; }
        IEnumerable<ZodiacSign> ZodiacSigns { get; }
    }
}