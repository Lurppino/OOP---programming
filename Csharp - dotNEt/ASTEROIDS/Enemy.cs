using Raylib_cs;
using System.Numerics;
using LukaLib;

namespace ASTEROIDS
{
    internal class Enemy : Entity
    {
        public float MaxSpeed = 90f;

        public Enemy(Vector2 position)
            : base(new Transform2d(position), new Collision2d(20f)) 
        {
            Transform.Velocity = Vector2.Zero;
        }

        public override void Update()
        {
            Vector2 direction = Program.PlayerPosition - Transform.Position;
            if (direction != Vector2.Zero)
            {
                direction = Vector2.Normalize(direction);
                Transform.Velocity = direction * MaxSpeed;
            }

            Transform.Move();
        }

        public override void Draw()
        {
            Texture2D tex = Textures.UFO;

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

    }
}
