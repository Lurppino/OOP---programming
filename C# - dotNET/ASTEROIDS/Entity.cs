using Raylib_cs;

namespace ASTEROIDS
{
    public class Entity
    {
        public Transform Transform;
        public Collision Collision;

        public Entity(Transform transform, Collision collision = null)
        {
            Transform = transform;
            Collision = collision;
        }

        public virtual void Update()
        {
            Transform.Move();
        }

        public virtual void Draw()
        {
            if (Collision != null)
            {
                Raylib.DrawCircleV(Transform.Position, Collision.Radius, Color.Gray);
            }
            else
            {
                Raylib.DrawCircleV(Transform.Position, 10f, Color.Gray);
            }
        }
    }
}
