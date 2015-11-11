﻿namespace TreeOfLife.Model
{
    public class HebrewLetter : Entity
    {
        public HebrewLetter(string id, int keyScale, char letter, int number, string name, string meaning)
            : base(id, keyScale, number)
        {
            Letter = letter;
            Name = name;
            Meaning = meaning;
        }

        public char Letter { get; }
        public string Meaning { get; }
        public string Name { get; }

        public override string ToString()
        {
            return $"{Letter} {Name} ({Meaning})";
        }
    }
}