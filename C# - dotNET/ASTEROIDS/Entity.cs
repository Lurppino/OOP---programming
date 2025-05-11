using ASTEROIDS;
using System.Numerics;

public abstract class Entity
{
    public Vector2 position;
    public Vector2 velocity;
    public float rotation;
    public float radius;

    public Entity(Vector2 position, float rotation)
    {
        this.position = position;
        this.rotation = rotation;
        this.velocity = Vector2.Zero;
        this.radius = 10f;
    }

    public virtual void Update()
    {
        position += velocity;
        WrapAroundScreen();
    }

    public abstract void Draw(); 

    protected void WrapAroundScreen()
    {
        if (position.X > Program.ScreenWidth) position.X = 0;
        else if (position.X < 0) position.X = Program.ScreenWidth;
        if (position.Y > Program.ScreenHeight) position.Y = 0;
        else if (position.Y < 0) position.Y = Program.ScreenHeight;
    }
}
