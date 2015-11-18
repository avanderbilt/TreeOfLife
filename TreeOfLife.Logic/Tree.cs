using System.Collections.Generic;
using TreeOfLife.Model;
using TreeOfLife.Model.Interfaces;

namespace TreeOfLife.Logic
{
    public class Tree : ITree
    {
        public Tree(IHebrewLetterRepository hebrewLetterRepository, ISephiraRepository sephiraRepository,
            IPlanetRepository planetRepository, IZodiacSignRepository zodiacSignRepository,
            IPathRepository pathRepository, IElementRepository elementRepository, IMetalRepository metalRepository)
        {
            Paths = pathRepository.ReadAll();
            Sephiroth = sephiraRepository.ReadAll();
            HebrewLetters = hebrewLetterRepository.ReadAll();
            Planets = planetRepository.ReadAll();
            ZodiacSigns = zodiacSignRepository.ReadAll();
            Elements = elementRepository.ReadAll();
            Metals = metalRepository.ReadAll();
        }

        public IEnumerable<HebrewLetter> HebrewLetters { get; }
        public IEnumerable<Path> Paths { get; }
        public IEnumerable<Planet> Planets { get; }
        public IEnumerable<Sephira> Sephiroth { get; }
        public IEnumerable<ZodiacSign> ZodiacSigns { get; }
        public IEnumerable<Element> Elements { get; }
        public IEnumerable<Metal> Metals { get; }
    }
}