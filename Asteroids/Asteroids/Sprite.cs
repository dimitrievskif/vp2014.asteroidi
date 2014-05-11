using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Asteroids
{
    public class Sprite
    {
        public float[] Position { get; set; }
        public float[] Velocity { get; private set; }
        public float Angle { get; private set; }
        public float AngleVelocity { get; private set; }
        public Bitmap Image { get; private set; }
        public int[] ImageCenter { get; private set; }
        public int[] ImageSize { get; private set; }
        public float Radius { get; private set; }
        public float Lifespan { get; private set; }
        public bool Animated { get; private set; }
        public int Age { get; private set; }

        public Sprite(float[] pos, float[] vel, float ang, float ang_vel, Bitmap img, ImageInfo info)
        {
            Position = pos;
            Velocity = vel;
            Angle = ang;
            Image = img;
            ImageCenter = info.Center;
            AngleVelocity = ang_vel;
            ImageSize = info.Size;
            Radius = info.Radius;
            Lifespan = info.Lifespan;
            Animated = info.Animated;
            Age = 0;

        }

        public void Draw(Graphics g)
        {
            /* Доколку сликата треба да се анимира (ова се однесува на сликата која се користи при експлозија на астероидите)
               со секое наредно повикување на овој метод се исцртува различен дел од сликата со што изгледа како да е анимирана. 
             * Бидејќи сликата е составена од 24 различни сликички со Age % 25 се добива индексот на сликата кој треба да се исцрта. */
            if (Animated)
            {
                int image_index = Age % 25;
                ImageCenter = new int[] { ImageCenter[0] + image_index * ImageSize[0], ImageCenter[1] };
                g.DrawImage(Image, Position[0] - 64, Position[1] - 64, new RectangleF(image_index * ImageSize[0], 0, 128, 128), GraphicsUnit.Pixel);
            }
            else
            {
                g.DrawImage(AdditionalFunctions.RotateImage(Image, Angle), Position[0], Position[1], ImageSize[0], ImageSize[1]);
            }
        }

        public bool Update()
        {
            Angle += AngleVelocity;
            Position[0] = (Position[0] + Velocity[0]) % Form1.WIDTH;
            Position[1] = (Position[1] + Velocity[1]) % Form1.HEIGHT;
            Age += 1;

            if (Age < Lifespan)
                return false;
            return true;
        }

        // Одредување судир меѓу објектите
        public bool Collide(object s)
        {
            if (s.GetType() == typeof(Sprite))
            {
                if (AdditionalFunctions.distance(new float[] { Position[0] + Radius, Position[1] + Radius }, new float[] { ((Sprite)s).Position[0] + ((Sprite)s).Radius, ((Sprite)s).Position[1] + ((Sprite)s).Radius}) <= Radius + ((Sprite)s).Radius)
                {
                    return true;
                }
            }
            else if (s.GetType() == typeof(Ship))
            {
                if (AdditionalFunctions.distance(new float[] { Position[0] + Radius, Position[1] + Radius }, new float[] { ((Ship)s).Position[0] + ((Ship)s).Radius, ((Ship)s).Position[1] + ((Ship )s).Radius }) <= Radius + ((Ship)s).Radius)
                    return true;
            }
            return false;
           
        }
    }
}
