namespace RandomArtScreensaver.Entities
{
    public class ArtType
    {
        public ArtTypeEnum Type { get; set; }
        public int Percentage { get; set; }
        public int Speed { get; set; }
        public bool Alpha { get; set; }

        public ArtType(ArtTypeEnum type, int percentage, int speed, bool alpha)
        {
            Type = type;
            Percentage = percentage;
            Speed = speed;
            Alpha = alpha;
        }

        // Override ToString for easier debugging or display
        public override string ToString()
        {
            return $"{Type}: {Percentage}% @ {Speed}";
        }
    }
    public enum ArtTypeEnum
    {
        Dots = 0,
        Grow = 1,
        Scribble = 2,
        Light = 3,
        Weeds = 4,
        Bubbles = 5,
        Warp = 6,
        Plasma = 7,
    }
}