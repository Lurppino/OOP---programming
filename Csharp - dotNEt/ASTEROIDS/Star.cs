using System.Numerics;
using Raylib_cs;

class Star
{
    public Vector2 Position;
    public float Radius;
    public Color Color;

    private static Random rng = new Random();
    private byte baseBrightness;
    private int twinkleDirection = 1;

    public Star(int screenWidth, int screenHeight)
    {
        Position = new Vector2(rng.Next(screenWidth), rng.Next(screenHeight));
        Radius = rng.Next(1, 3);
        byte brightness = (byte)rng.Next(150, 256);
        Color = new Color((int)brightness, (int)brightness, (int)brightness, 255);
    }

    public void Update()
    {
        baseBrightness += (byte)(twinkleDirection * rng.Next(1, 3));

        if (baseBrightness >= 255) twinkleDirection = -1;
        if (baseBrightness <= 150) twinkleDirection = 1;

        Color = new Color((int)baseBrightness, (int)baseBrightness, (int)baseBrightness, 255);
    }

    public void Draw()
    {
        Raylib.DrawCircleV(Position, Radius, Color);
    }
}
