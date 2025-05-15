using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace RandomArtScreensaver
{
    public class SaverSettings {
        public bool setWallpaper { get; set; } = false;
        public bool UseBack { get; set; } = true;
        public bool AllScreens { get; set; } = false;
        public Warp warp { get; set; } = new Warp();
        public Plasma plasma { get; set; } = new Plasma();
        public BackGround backGround { get; set; } = new BackGround();
        public Light light = new Light();
        public Bubble bubble = new Bubble();
        public Scribble scribble = new Scribble();
        public List<ArtType> artTypes { get; set; } = new List<ArtType> {
            new ArtType(artType.Dots, 12, 100),//12, 100 - G
            new ArtType(artType.Grow, 12, 100),//12, 100 - G
            new ArtType(artType.Scribble, 12, 100),//12, 500 - G
            new ArtType(artType.Light, 13, 1000),//13, 1000 - G
            new ArtType(artType.Weeds, 12, 500),//12, 500 - G
            new ArtType(artType.Bubbles, 13, 1000),//13, 1000 - G
            new ArtType(artType.Warp, 13, 100),//13, 500 - 
            new ArtType(artType.Plasma, 13, 5000)//13, 5000 - 
        };
    }
    public class Warp {
        public int Angles { get; set; } = 50; //4-100
        public bool Rand { get; set; } = true;
        public bool Smooth { get; set; } = true;
        public int Speed { get; set; } = 20; //1-250
    }
    public class Plasma {
        public int Type { get; set; } = 0; //0=Rand, 1=Mirror, 2=Normal
        public bool ColorRand { get; set; } = true;
        public bool ColorVRand { get; set; } = true;
        public int ColorV { get; set; } = 255; //Color Variation 0-255
        public int Color { get; set; } = 4; //ColorAmount 1-8
        public int Transition { get ; set; } = 100; //how smooth between scenes
    }
    public class BackGround {
        public int R { get; set; } = 0; //0-255
        public int G { get; set; } = 0; //0-255
        public int B { get; set; } = 0; //0-255
        public bool Rand { get; set; } = false;
    }
    public class ArtType {
        public artType Type { get; set; }
        public int Percentage { get; set; }
        public int Speed { get; set; } 

        public ArtType(artType type, int percentage, int speed)
        {
            Type = type;
            Percentage = percentage;
            Speed = speed;
        }

        // Override ToString for easier debugging or display
        public override string ToString()
        {
            return $"{Type}: {Percentage}% @ {Speed}";
        }
    }
    public class Light {
        public decimal Transparent { get; set; } = (decimal)0.0; //0-99%
        public decimal Center { get; set; } = (decimal)0.0; //0-100%
    }
    public class Bubble {
        public decimal Transparent { get; set; } = (decimal)0.5;//0-99%
        public decimal Center { get; set; } = (decimal)0.2; //1-99%
    }
    public class Scribble {
        public int Length { get; set; } = 4;
    }
}