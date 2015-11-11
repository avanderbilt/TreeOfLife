namespace TreeOfLife.Model
{
    public class ZodiacSignWithPath
    {
        public ZodiacSign ZodiacSign { get; set; }
        public Path Path { get; set; }
        public SephiraPair TerminalSephiroth { get; set; }

        public override string ToString()
        {
            var zodiacSignString = ZodiacSign.ToString();

            var pathString = string.Empty;

            if (Path != null)
                pathString =
                    $"Path {Path.Number}, from {TerminalSephiroth.From.Name} ({TerminalSephiroth.From.KeyScale}) " +
                    $"to {TerminalSephiroth.To.Name} ({TerminalSephiroth.To.KeyScale}).";

            return $"{zodiacSignString}, {pathString}";
        }
    }
}