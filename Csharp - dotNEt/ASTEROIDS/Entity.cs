using Raylib_cs;
using LukaLib;

namespace ASTEROIDS
{
    public class Entity
    {
        public Transform2d Transform;  
        public Collision2d Collision;

        public Entity(Transform2d transform, Collision2d collision = null) 
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
