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
        private const int MAX_PARTICLES = 100;
        Camera camera;

        Texture2D m_textureAsset;

        //State 
        SplitterParticle[] m_particles = new SplitterParticle[MAX_PARTICLES];

        public SplitterSystem(Viewport viewport, ContentManager content)
        {
            camera = new Camera(viewport);

            for (int i = 0; i < MAX_PARTICLES; i++)
            {
                m_particles[i] = new SplitterParticle(i);
            }

            m_textureAsset = content.Load<Texture2D>("spark");
        }

        //internal void LoadContent(Microsoft.Xna.Framework.Content.ContentManager a_content)
        //{
        //    m_textureAsset = a_content.Load<Texture2D>("spark");
        //}

        internal void UpdateAndDraw(float a_elapsedTime, Vector2 a_padPosition, /*float a_halfPadSize,*/ SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int i = 0; i < MAX_PARTICLES; i++)
            {

                //Updatera partikeln
                m_particles[i].Update(a_elapsedTime, new Vector2(/*-a_halfPadSize + 2.0f * a_halfPadSize * */(float)i / (float)MAX_PARTICLES, 0), i);

                //Rita bara ut levande partiklar
                if (m_particles[i].IsAlive())
                {

                    //Viewpositioner
                    Vector2 viewCenterPosition = camera.toViewCoordinates(a_padPosition.X + m_particles[i].m_position.X,
                                                                            a_padPosition.Y + m_particles[i].m_position.Y);

                    //Räkna ut storleken
                    Rectangle destinationRectangle = new Rectangle((int)viewCenterPosition.X - 16, (int)viewCenterPosition.Y - 16, 32, 32);

                    //Blenda ut färgen
                    float a = m_particles[i].GetVisibility();
                    Color particleColor = new Color(a, a, a, a);
                    
                    //rita ut partikeln
                    spriteBatch.Draw(m_textureAsset, destinationRectangle, particleColor);
                    
                }
            }
            spriteBatch.End();
        }
    }
}
