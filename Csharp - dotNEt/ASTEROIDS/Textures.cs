using Raylib_cs;

public static class Textures
{
    public static Texture2D Ship_Blue;
    public static Texture2D Ship_Green;
    public static Texture2D Ship_Red;
    public static Texture2D Ship_Orange;

    public static Texture2D Laser;

    public static Texture2D UFO;

    public static Texture2D MeteorSmall;
    public static Texture2D MeteorMedium;
    public static Texture2D MeteorLarge;

    public static void Load()
    {
        Ship_Blue = Raylib.LoadTexture("Assets/Sprites/playerShip1_blue.png");
        Ship_Green = Raylib.LoadTexture("Assets/Sprites/playerShip1_green.png");
        Ship_Red = Raylib.LoadTexture("Assets/Sprites/playerShip1_red.png");
        Ship_Orange = Raylib.LoadTexture("Assets/Sprites/playerShip1_orange.png");

        Laser = Raylib.LoadTexture("Assets/Sprites/laserBlue01.png");

        UFO = Raylib.LoadTexture("Assets/Sprites/ufoGreen.png");

        MeteorSmall = Raylib.LoadTexture("Assets/Sprites/meteorBrown_tiny1.png");
        MeteorMedium = Raylib.LoadTexture("Assets/Sprites/meteorBrown_med1.png");
        MeteorLarge = Raylib.LoadTexture("Assets/Sprites/meteorBrown_big1.png");
    }
}
}