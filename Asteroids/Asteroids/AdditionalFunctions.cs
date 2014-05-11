using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Asteroids
{
    // Функции за ротација на слика, претворање агол во вектор и одредување растојание меѓу два објекта
    public class AdditionalFunctions
    {

        public static Image RotateImage(Image img, float rotationAngle)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(img, 0, 0, img.Width, img.Height);
            gfx.Dispose();

            return bmp;
        }

        public static float[] angleToVector(float angle)
        {
            return new float[] { (float)Math.Cos(Convert.ToDouble(angle)), (float)Math.Sin(Convert.ToDouble(angle)) };
        }

        public static float distance(float[] p1, float[] p2)
        {
            return (float)Math.Sqrt(Convert.ToDouble((p1[0] - p2[0]) * (p1[0] - p2[0]) + (p1[1] - p2[1]) * (p1[1] - p2[1])));
        }
    }
}
