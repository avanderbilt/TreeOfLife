namespace TreeOfLife.Model
{
    public class PathWithHebrewLetter
    {
        public Path Path { get; set; }
        public HebrewLetter HebrewLetter { get; set; }
        public SephiraPair TerminalSephiroth { get; set; }

        public override string ToString()
        {
            return
                $"Path {Path.Number} - {HebrewLetter.Letter} ({HebrewLetter.Name}) - from {TerminalSephiroth.From.Name} " +
                $"({TerminalSephiroth.From.KeyScale}) to {TerminalSephiroth.To.Name} ({TerminalSephiroth.To.KeyScale}).";
        }
    }
}