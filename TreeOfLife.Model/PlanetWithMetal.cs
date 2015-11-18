namespace TreeOfLife.Model
{
    public class PlanetWithMetal
    {
        public Planet Planet { get; set; }
        public Metal Metal { get; set; }

        public override string ToString()
        {
            var planetString = Planet.ToString();
            var metalString = string.Empty;

            if (Metal != null)
                metalString = Metal.ToString();

            return $"{planetString}, {metalString}";
        }
    }
}