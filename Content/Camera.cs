using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb1.Content
{
    class Camera
    {
        public static int border = 10;
        private float scale;

        public Camera(int width, int height)
        {
            int scaleX = (width - border * 2);
            int scaleY = (height - border * 2);

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }
        public Rectangle scaleSplitter(float xPos, float yPos, float splitterSize)
        {
            int vSize = (int)(splitterSize * scale);

            int vX = (int)(xPos * scale + border);
            int vY = (int)(yPos * scale + border);

            return new Rectangle(vX, vY, vSize, vSize);
        }
    }
}