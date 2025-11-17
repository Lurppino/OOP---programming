using Raylib_cs;
using System;
using System.IO;

public static class Textures
{
    public static Texture2D Ship_Blue;
    public static Texture2D Ship_Green;
    public static Texture2D Ship_Red;
    public static Texture2D Ship_Yellow;

    public static Texture2D Laser;
    public static Texture2D UFO;

    public static Texture2D MeteorSmall;
    public static Texture2D MeteorMedium;
    public static Texture2D MeteorLarge;

    public static void Load()
    {
        Ship_Blue = LoadTextureSafe("Assets/Sprites/playerShip1_blue.png");
        Ship_Green = LoadTextureSafe("Assets/Sprites/playerShip1_green.png");
        Ship_Red = LoadTextureSafe("Assets/Sprites/playerShip1_red.png");
        Ship_Yellow = LoadTextureSafe("Assets/Sprites/playerShip1_orange.png");

        Laser = LoadTextureSafe("Assets/Sprites/laserBlue01.png");
        UFO = LoadTextureSafe("Assets/Sprites/ufoGreen.png");

        MeteorSmall = LoadTextureSafe("Assets/Sprites/meteorBrown_tiny1.png");
        MeteorMedium = LoadTextureSafe("Assets/Sprites/meteorBrown_med1.png");
        MeteorLarge = LoadTextureSafe("Assets/Sprites/meteorBrown_big1.png");
    }

    private static Texture2D LoadTextureSafe(string path)
    {

        if (!File.Exists(path))
        {
            Console.WriteLine("Cannot find texture at: " + Path.GetFullPath(path));
            return default;
        }

        var tex = Raylib.LoadTexture(path);
        Console.WriteLine($"Loaded texture: {path} ID = {tex.Id}");
        return tex;
    }


    public static void Unload()
    {
        Raylib.UnloadTexture(Ship_Blue);
        Raylib.UnloadTexture(Ship_Green);
        Raylib.UnloadTexture(Ship_Red);
        Raylib.UnloadTexture(Ship_Yellow);

        Raylib.UnloadTexture(Laser);
        Raylib.UnloadTexture(UFO);

        Raylib.UnloadTexture(MeteorSmall);
        Raylib.UnloadTexture(MeteorMedium);
        Raylib.UnloadTexture(MeteorLarge);
    }
}
