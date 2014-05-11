using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asteroids
{
    public class ImageInfo
    {
        public int[] Center { get; private set; }
        public int[] Size { get; private set; }
        public float Radius { get; private set; }
        public float Lifespan { get; private set; }
        public bool Animated { get; private set; }

        public ImageInfo(int[] center, int[] size, float radius = 0, float lifespan = 0, bool animated = false)
        {
            Center = center;
            Size = size;
            Radius = radius;
            if (lifespan != 0)
                Lifespan = lifespan;
            else
                Lifespan = float.MaxValue;
            Animated = animated;
        }
    }
}
