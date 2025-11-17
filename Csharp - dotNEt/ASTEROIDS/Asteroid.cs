using Raylib_cs;
using System;
using System.Numerics;
using System.Collections.Generic;
using LukaLib;

namespace ASTEROIDS
{
    internal class Asteroid : Entity
    {
        public float Size;
        public Color AsteroidColor = Color.Gray;
        private Random rng = new Random();

        public Asteroid(Vector2 position, float size, Vector2 direction)
            : base(new Transform2d(position), new Collision2d(size))
        {
            Size = size;
            Transform.Velocity = Vector2.Normalize(direction) * 50f;
        }

        public override void Update()
        {
            Transform.Move();
        }

        public override void Draw()
        {
            Texture2D tex;

            if (Size <= 20)
                tex = Textures.MeteorMedium;
            else if (Size <= 35)
                tex = Textures.MeteorLarge;
            else
                tex = Textures.MeteorLarge;

            Raylib.DrawTexturePro(
                tex,
                new Rectangle(0, 0, tex.Width, tex.Height),
                new Rectangle(
                    Transform.Position.X,
                    Transform.Position.Y,
                    tex.Width,
                    tex.Height
                ),
                new Vector2(tex.Width / 2f, tex.Height / 2f),
                0f,
                Color.White
            );
        }


        public void BreakIntoSmallerPieces(List<Asteroid> asteroids)
        {
            if (Size <= 20)
            {
                asteroids.Remove(this);
                return;
            }

            asteroids.Remove(this);

            for (int i = 0; i < 2; i++)
            {
                Vector2 randomDirection = new Vector2(
                    (float)(rng.NextDouble() * 2 - 1),
                    (float)(rng.NextDouble() * 2 - 1)
                );

                if (randomDirection == Vector2.Zero)
                    randomDirection = new Vector2(1, 0);

                randomDirection = Vector2.Normalize(randomDirection) * 2f;

                asteroids.Add(new Asteroid(Transform.Position, Size / 2, randomDirection));
            }
        }
    }
}
