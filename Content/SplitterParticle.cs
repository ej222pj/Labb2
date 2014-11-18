using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb2.Content
{
    class SplitterParticle
    {
        public static Vector2 GRAVITY = new Vector2(0, -2.3f);
        public static float MAX_LIFE = 1.0f;
        public static float DELAY_MAX = 1.0f;
        public static float MIN_SPEED = 0.1f;
        public static float MAX_SPEED = 0.3f;
        public Vector2 startPosision;
        private static Random m_rand = new Random();

        //State
        public float m_life = 0;
        public float m_delay;
        public Vector2 m_position;
        private Vector2 m_particleSpeed;

        public SplitterParticle(int a_randomSeed)
        {
            startPosision = new Vector2(0.5f, 0.5f);
            RespawnParticle(startPosision, a_randomSeed);
            m_life = 0;
        }

        private void RespawnParticle(Vector2 a_position, int a_randomSeed)
        {
            Random r = new Random(a_randomSeed);

            m_delay = (float)r.NextDouble() * DELAY_MAX;
            m_life = MAX_LIFE;
            m_position = a_position;
            m_particleSpeed = GetRandomSpeed(a_randomSeed);
        }

        internal void Update(float a_elapsedTime, Vector2 a_respawnPosition, int a_randomSeed)
        {
            //dra bort liv
            m_life -= a_elapsedTime;

            //har partikeln dött?
            if (m_life < 0.0f)
            {
                //Om vi inte längre lever väntar vi m_delay innan vi respawnar
                if (m_delay > 0)
                {
                    m_delay -= a_elapsedTime;
                    return;
                }
                RespawnParticle(a_respawnPosition, a_randomSeed);
            }

            //v1 = v0 + a *t
            m_particleSpeed = m_particleSpeed + GRAVITY * a_elapsedTime;

            //s1 = s0 + var * t
            m_position = m_position + m_particleSpeed * a_elapsedTime;
        }

        private Vector2 GetRandomSpeed(int a_randomSeed)
        {
            //skapa en random utifrån seed
            Random rand = new Random(a_randomSeed);

            //x och yield får värden mellan -1 och 1
            float x = (float)(rand.NextDouble() * 2.0 - 1.0);
            float y = (float)(rand.NextDouble() * 2.0 - 1.0);

            //skapa och normalisera en vektor
            Vector2 ret = new Vector2(x, y);
            ret.Normalize(); // Vektorn får längden 1.

            float speed = (float)rand.NextDouble();

            //hastighet mellan MIN_SPEED och MAX_SPEED
            ret = ret * (MIN_SPEED + speed * (MAX_SPEED - MIN_SPEED));

            return ret;
        }

        public bool IsAlive()
        {
            return m_life > 0;
        }

        public float GetVisibility()
        {
            return m_life / MAX_LIFE;
        }
    }
}
