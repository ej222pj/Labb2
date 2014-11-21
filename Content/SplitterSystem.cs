using Labb1.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb2.Content
{
    class SplitterSystem
    {
        private SplitterParticle[] particles;
        private int maxPartical = 100;
        private float time = 0;
        private static float runTime = 3;
        private static float maxSpeed = 0.3f;

        private Camera camera;
        public SplitterSystem(Viewport viewPort)
        {
            camera = new Camera(viewPort.Width, viewPort.Height);

            particles = new SplitterParticle[maxPartical];

            spawnNewSystem();
        }
        private void spawnNewSystem()
        {
            Random rand = new Random();

            for (int i = 0; i < maxPartical; i++)
            {
                Vector2 direction = new Vector2(((float)rand.NextDouble() - 0.5f), ((float)rand.NextDouble() - 0.5f));
                direction.Normalize();
                direction = direction * ((float)rand.NextDouble() * maxSpeed);

                particles[i] = new SplitterParticle(direction);
            }
        }
        public void Update(float timeElapsed)
        {
            time += timeElapsed;

            for (int i = 0; i < maxPartical; i++)
            {
                particles[i].Update(timeElapsed);
            }

            if (time > runTime)
            {
                time = 0;
                spawnNewSystem();
            }
        }
        public void Draw(SpriteBatch spriteBatch, Texture2D splitterTexture)
        {
            for (int i = 0; i < maxPartical; i++)
            {
                particles[i].Draw(spriteBatch, splitterTexture, camera);
            }
        }
    }
}
