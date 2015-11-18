﻿namespace TreeOfLife.Model
{
    public class ZodiacSign : Entity
    {
        public ZodiacSign(string id, int keyScale, string name, char glyph) : base(id, keyScale)
        {
            Glyph = glyph;
            Name = name;
        }

        public char Glyph { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Glyph} {Name}";
        }
    }
}