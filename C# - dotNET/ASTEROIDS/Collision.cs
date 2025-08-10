public class Collision
{
    public float Radius;

    public Collision(float radius)
    {
        Radius = radius;
    }

    public static bool CheckCollision(Transform tA, Collision cA, Transform tB, Collision cB)
    {
        return Raylib_cs.Raylib.CheckCollisionCircles(tA.Position, cA.Radius, tB.Position, cB.Radius);
    }
}
