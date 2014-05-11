using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Asteroids
{
    public class Ship
    {
        public float[] Position { get; private set; }
        public float[] Velocity { get; set; }
        public bool Thrust { get; set; }
        public float Angle { get; private set; }
        public float AngleVelocity { get; set; }
        public Bitmap ImageShip { get; private set; }
        public Bitmap ImageThrust { get; private set; }
        public int[] ImageCenter { get; private set; }
        public int[] ImageSize { get; private set; }
        public float Radius { get; private set; }

        public Ship(float[] pos, float[] vel, float angle, Bitmap image, Bitmap imageTh, ImageInfo info)
        {
            Position = pos;
            Velocity = vel;
            Thrust = false;
            Angle = angle;
            AngleVelocity = 0;
            ImageShip = image;
            ImageThrust = imageTh;
            ImageCenter = info.Center;
            ImageSize = info.Size;
            Radius = info.Radius;
        }

        public void Draw(Graphics g)
        {
            if (Thrust)
            {
                g.DrawImage(AdditionalFunctions.RotateImage(ImageThrust, Angle), Position[0], Position[1]);
            }
            else
            {
                g.DrawImage(AdditionalFunctions.RotateImage(ImageShip, Angle), Position[0], Position[1]);
            }

        }

        public void Update()
        {
            Angle += AngleVelocity;
            Position[0] = (Position[0] + Velocity[0]) % Form1.WIDTH;
            Position[1] = (Position[1] + Velocity[1]) % Form1.HEIGHT;
            if (Thrust)
            {
                float[] acc = AdditionalFunctions.angleToVector((float)Math.PI / 180 * Angle);
                Velocity[0] += acc[0] * 0.1f;
                Velocity[1] += acc[1] * 0.1f;
            }

            Velocity[0] *= 0.99f;
            Velocity[1] *= 0.99f;
            if (Position[0] <= 0)
                Position[0] = Form1.WIDTH - 50;
            if (Position[1] <= 0)
                Position[1] = Form1.HEIGHT - 50;
        }

        public void increment_ang_vel()
        {
            AngleVelocity += 2;
        }

        public void decrement_ang_vel()
        {
            AngleVelocity -= 2;
        }

        public void Shoot(Bitmap image)
        {
            float[] forward = AdditionalFunctions.angleToVector((float)Math.PI / 180 * Angle);
            float[] missile_pos = new float[] { Position[0] + Radius, Position[1] + Radius};
            float[] missile_vel = new float[] { Velocity[0] + 6 * forward[0],Velocity[1] + 6 * forward[1]};
            if(image.Tag == "player1")
                Form1.TheGame.MissileGroup1.Add(new Sprite(missile_pos, missile_vel, Angle, 0, image, Form1.MissileInfo));
            else
                Form1.TheGame.MissileGroup2.Add(new Sprite(missile_pos, missile_vel, Angle, 0, image, Form1.MissileInfo));
        }

      
    }
}
