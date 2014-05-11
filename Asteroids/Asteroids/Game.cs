using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Asteroids
{
    public class Game
    {
        public bool Multiplayer { get; set; }
        public bool Started { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public int Lifes1 { get; set; }
        public int Lifes2 { get; set; }
        public int Difficulty { get; set; }
        public int PackageFrequency { get; set; }
        public Bitmap PackageTime { get; set; }
        public Bitmap PackageLife { get; set; }
        public List<Sprite> MissileGroup1 { get; set; }
        public List<Sprite> MissileGroup2 { get; set; }
        public List<Sprite> RockGroup { get; set; }
        public List<Sprite> ExplosionGroup { get; set; }
        public List<Sprite> PackageGroup { get; set; }
        public Bitmap MissileImage1 { get; set; }
        public Bitmap MissileImage2 { get; set; }
        public Bitmap AsteroidImage { get; set; }
        public Bitmap ShipImage { get; set; }
        public Bitmap ThrustShipImage { get; set; }
        public Bitmap ExplosionImage { get; set; }
        public ImageInfo MissileInfo { get; set; }
        public ImageInfo AsteroidInfo { get; set; }
        public ImageInfo ShipInfo { get; set; }
        public ImageInfo ExplosionInfo { get; set; }
        public ImageInfo PackageInfo { get; set; }
        public Ship Ship1 { get; set; }
        public Ship Ship2 { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }

        public Game(bool Multyplayer, int Difficulty, Bitmap PackageLife, Bitmap PackageTime, Bitmap MissileImage1, Bitmap MissileImage2,ImageInfo MissileInfo, Bitmap ShipImage, Bitmap ThrustShipImage, ImageInfo ShipInfo,  Bitmap AsteroidImage, ImageInfo AsteroidInfo, ImageInfo PackageInfo, Bitmap ExplosionImage, ImageInfo ExplosionInfo, Ship Ship1, Ship Ship2, string PLayer1, string Player2)
        {
            Started = false;
            Score1 = 0;
            Score2 = 0;
            Lifes1 = 3;
            Lifes2 = 3;
            PackageFrequency = 15;
            MissileGroup1 = new List<Sprite>();
            MissileGroup2 = new List<Sprite>();
            PackageGroup = new List<Sprite>();
            RockGroup = new List<Sprite>();
            ExplosionGroup = new List<Sprite>();
            this.Multiplayer = Multyplayer;
            this.Difficulty = Difficulty;
            this.PackageLife = PackageLife;
            this.PackageTime = PackageTime;
            this.MissileImage1 = MissileImage1;
            this.MissileImage2 = MissileImage2;
            this.MissileInfo = MissileInfo;
            this.ShipImage = ShipImage;
            this.ThrustShipImage = ThrustShipImage;
            this.ShipInfo = ShipInfo;
            this.AsteroidImage = AsteroidImage;
            this.AsteroidInfo = AsteroidInfo;
            this.PackageInfo = PackageInfo;
            this.ExplosionImage = ExplosionImage;
            this.ExplosionInfo = ExplosionInfo;
            this.Ship1 = Ship1;
            this.Ship2 = Ship2;
            this.Player1 = Player1;
            this.Player2 = Player2;
        }

        // Одредување минимален број поени кои треба да се постигнат во зависност од избраната тежина
        public int GameAim()
        {
            if (Difficulty == 3)
                return 20;
            else if (Difficulty == 2)
                return 40;
            else if (Difficulty == 1)
                return 70;
            return 0;
        }

        /*  Метод за рестартирање на играта, враќање на бројот на поени на 0, чистење на листите со куршуми, пакети и астероиди
            и запирање на леталото */
        public void RestartGame()
        {
            Score1 = 0;
            Score2 = 0;
            Lifes1 = 3;
            Lifes2 = 3;
            PackageFrequency = 15;
            MissileGroup1.Clear();
            MissileGroup2.Clear();
            PackageGroup.Clear();
            RockGroup.Clear();
            ExplosionGroup.Clear();
            Started = true;
            Ship1.Velocity = new float[] { 0, 0 };
            Ship1.Thrust = false;
            Ship1.AngleVelocity = 0;
            if (Multiplayer)
            {
                Ship2.Velocity = new float[] { 0, 0 };
                Ship2.Thrust = false;
                Ship2.AngleVelocity = 0;
            }
        }

    }
}
