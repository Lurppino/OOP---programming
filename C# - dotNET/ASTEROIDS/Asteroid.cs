using Raylib_cs;
using System;
using System.Numerics;
using System.Collections.Generic;

namespace ASTEROIDS
{
    class Asteroid : Entity
    {
        public float Size;
        public Color AsteroidColor = Color.Gray;

        public Asteroid(Vector2 position, float size, Vector2 direction) : base(position, 0f)
        {
            Size = size;
            radius = size;
            velocity = direction;
        }

        public override void Update()
        {
            position += velocity;
            WrapAroundScreen();
        }

        public override void Draw()
        {
            Raylib.DrawCircleV(position, Size, AsteroidColor);
        }

        public void BreakIntoSmallerPieces(List<Asteroid> asteroids, Random rng)
        {
            if (Size <= 20)
            {
                asteroids.Remove(this);
                return;
            }

            asteroids.Remove(this);
            asteroids.Add(new Asteroid(position, Size / 2, new Vector2((float)(rng.NextDouble() * 2 - 1), (float)(rng.NextDouble() * 2 - 1))));
            asteroids.Add(new Asteroid(position, Size / 2, new Vector2((float)(rng.NextDouble() * 2 - 1), (float)(rng.NextDouble() * 2 - 1))));
        }
    }
}
