using Raylib_cs;
using System.Numerics;
using LukaLib;

namespace ASTEROIDS
{
    internal class Bullet : Entity
    {
        public float Speed;

        public Bullet(Vector2 position, Vector2 direction, float speed)
            : base(new Transform2d(position), new Collision2d(5f))
        {
            Speed = speed;
            Transform.Velocity = Vector2.Normalize(direction) * 200f;
            Transform.WrapsAround = false; 
        }

        public override void Update()
        {
            Transform.Move();
        }

        public override void Draw()
        {
            Texture2D tex = Textures.Laser;

            float angleRadians = MathF.Atan2(Transform.Velocity.Y, Transform.Velocity.X) + MathF.PI / 2;

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
                angleRadians * (180f / MathF.PI),
                Color.White
            );
        }



        public bool IsDead()
        {
            
            return Transform.Position.X < 0 || Transform.Position.X > Program.ScreenWidth ||
                   Transform.Position.Y < 0 || Transform.Position.Y > Program.ScreenHeight;
        }
    }
}
