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
        public int width;
        public int height;
        private float scale;
        public const int level_width = 10;
        public const int level_height = 10;
        private float scaleX;
        private float scaleY;

        public Camera(Viewport viewport)
        {
            this.width = viewport.Width;
            this.height = viewport.Height;
        }

        public void setDimensions()
        {
            scaleX = (float)width / (float)level_width;
            scaleY = (float)height / (float)level_height;

            scale = scaleX;
            if (scaleY < scaleX)
            {
                scale = scaleY;
            }
        }

        public Vector2 toViewCoordinates(float modelX, float modelY)
        {
            Vector2 view = new Vector2(modelX * scaleX, modelY * scaleY);

            return view;
        }

        public float getScale()
        {
            return scale;
        }
    }
}