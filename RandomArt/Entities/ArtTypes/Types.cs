namespace RandomArtScreensaver.Entities.Types
{
    public class Light
    {
        public decimal Transparent { get; set; } = (decimal)0.0; //0-99%
        public decimal Center { get; set; } = (decimal)0.1; //0-100%
    }
    public class Bubble
    {
        public decimal Transparent { get; set; } = (decimal)0.5; //0-99%
        public decimal Center { get; set; } = (decimal)0.3; //1-99%
    }
    public class Scribble
    {
        public int Length { get; set; } = 4; //1-100
    }
    public class Dot
    {
        public bool Large { get; set; } = true;
        public int SplashSize { get; set; } = 250; //1-500;
    }
    public class Grow
    {
        public bool Large { get; set; } = true;
        public int SplashSize { get; set; } = 50; //1-100;
    }
    public class Warp
    {
        public int Angles { get; set; } = 50; //4-100
        public bool Rand { get; set; } = true;
        public bool Smooth { get; set; } = true;
        public int Speed { get; set; } = 10; //1-250
    }
    public class Plasma
    {
        public int Type { get; set; } = 0; //0=Rand, 1=Mirror, 2=Normal
        public bool ColorRand { get; set; } = true;
        public bool ColorVRand { get; set; } = true;
        public int ColorV { get; set; } = 255; //Color Variation 0-255
        public int Color { get; set; } = 4; //ColorAmount 1-4
        public int TransitionSpeed { get; set; } = 75; //how smooth between scenes
        public int TransitionCount { get; set; } = 50; //1-100
    }
}