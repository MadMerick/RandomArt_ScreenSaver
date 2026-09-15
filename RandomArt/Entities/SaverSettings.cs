using Newtonsoft.Json;

namespace RandomArtScreensaver.Entities
{
    public class SaverSettings
    {
        public bool setWallpaper { get; set; } = false;
        public bool UseBack { get; set; } = true;
        public bool AllScreens { get; set; } = false;
        public Types.Warp warp { get; set; } = new Types.Warp();
        public Types.Plasma plasma { get; set; } = new Types.Plasma();
        public Types.Parabola parabola { get; set; } = new Types.Parabola();
        public BackGround backGround { get; set; } = new BackGround();
        public Types.Light light = new Types.Light();
        public Types.Bubble bubble = new Types.Bubble();
        public Types.Scribble scribble = new Types.Scribble();
        public Types.Dot dot = new Types.Dot();
        public Types.Grow grow = new Types.Grow();
        public List<ArtType> artTypes { get; set; } = new List<ArtType> {
            new ArtType(ArtTypeEnum.Dots, 11, 10, true),//11
            new ArtType(ArtTypeEnum.Grow, 11, 10, true),//11
            new ArtType(ArtTypeEnum.Scribble, 11, 100, false),//11
            new ArtType(ArtTypeEnum.Light, 11, 1000, false),//11
            new ArtType(ArtTypeEnum.Weeds, 11, 500, false),//11
            new ArtType(ArtTypeEnum.Bubbles, 11, 1000, false),//11
            new ArtType(ArtTypeEnum.Warp, 11, 10 , true),//11
            new ArtType(ArtTypeEnum.Plasma, 11, 5000, false),//11
            new ArtType(ArtTypeEnum.Parabola, 12, 10, false)//12 - same speed as Warp for now
        };
    }
}