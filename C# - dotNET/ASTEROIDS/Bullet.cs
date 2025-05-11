using Raylib_cs;
using System.Numerics;

namespace ASTEROIDS
{
    public class Bullet : Entity
    {
        public float Speed = 5f;

        public Bullet(Vector2 position, Vector2 direction, float speed) : base(position, 0f)
        {
            velocity = direction * speed;
        }

        public override void Update()
        {
            position += velocity;
        }

        public override void Draw()
        {
            Raylib.DrawCircleV(position, 5f, Color.White);
        }

        public bool IsDead()
        {
            return position.X < 0 || position.X > Program.ScreenWidth || position.Y < 0 || position.Y > Program.ScreenHeight;
        }
    }
}
