namespace RandomArtScreensaver.Entities
{
    public class SaverSettings
    {
        public bool setWallpaper { get; set; } = false;
        public bool UseBack { get; set; } = true;
        public bool AllScreens { get; set; } = false;
        public Types.Warp warp { get; set; } = new Types.Warp();
        public Types.Plasma plasma { get; set; } = new Types.Plasma();
        public BackGround backGround { get; set; } = new BackGround();
        public Types.Light light = new Types.Light();
        public Types.Bubble bubble = new Types.Bubble();
        public Types.Scribble scribble = new Types.Scribble();
        public Types.Dot dot = new Types.Dot();
        public Types.Grow grow = new Types.Grow();
        public List<ArtType> artTypes { get; set; } = new List<ArtType> {
            new ArtType(ArtTypeEnum.Dots, 12, 10, true),//12, 100 - G
            new ArtType(ArtTypeEnum.Grow, 12, 10, true),//12, 100 - G
            new ArtType(ArtTypeEnum.Scribble, 12, 100, false),//12, 500 - G
            new ArtType(ArtTypeEnum.Light, 13, 1000, false),//13, 1000 - G
            new ArtType(ArtTypeEnum.Weeds, 12, 500, false),//12, 500 - G
            new ArtType(ArtTypeEnum.Bubbles, 13, 1000, false),//13, 1000 - G
            new ArtType(ArtTypeEnum.Warp, 13, 100 , false),//13, 500 - 
            new ArtType(ArtTypeEnum.Plasma, 13, 5000, false)//13, 5000 - 
        };
    }
}