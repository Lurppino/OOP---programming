﻿using System;
using System.IO;
using System.Numerics;
using Raylib_cs;

namespace ASTEROIDS
{
    internal class Program
    {
        static Music music;
        static Sound shootSound;

        public static int ScreenWidth = 800;
        public static int ScreenHeight = 600;
        public static List<Bullet> enemyBullets = new List<Bullet>();

        public static Vector2 PlayerPosition => player.position;

        public static float Deg2Rad = (float)(Math.PI / 180.0f);
        public static int Score = 0;

        static Player player;
        static List<Asteroid> asteroids = new List<Asteroid>();
        static Random rng = new Random();
        static List<Bullet> bullets = new List<Bullet>();
        static List<Enemy> enemies = new List<Enemy>();

        static void Main()
        {
            Raylib.InitWindow(ScreenWidth, ScreenHeight, "Asteroids");
            Raylib.InitAudioDevice();  // Initialize audio device

            string musicPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Assets", "Audio", "Music.mp3");
            Console.WriteLine("Attempting to load music from: " + Path.GetFullPath(musicPath));

            string shootSoundPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Assets", "Audio", "Shoot.mp3");



            Console.WriteLine("Attempting to load music from: " + Path.GetFullPath(musicPath));

            if (!File.Exists(musicPath))
            {
                Console.WriteLine("Error: Music file not found.");
                return;
            }

            music = Raylib.LoadMusicStream(musicPath);
            Raylib.SetMusicVolume(music, 0.2f);

            shootSound = Raylib.LoadSound(shootSoundPath);
            Raylib.SetSoundVolume(shootSound, 0.3f);

            Raylib.PlayMusicStream(music);
            

            Raylib.SetTargetFPS(60);  

            RestartGame();

            while (!Raylib.WindowShouldClose())
            {
                if (player.IsDead)
                {
                    RestartGame();
                }

                player.Update();
                UpdateBullets();

                if (Raylib.IsKeyPressed(KeyboardKey.Space))
                {
                    ShootBullet();
                    Raylib.PlaySound(shootSound);
                }

                CheckCollisions();

                if (asteroids.Count == 0)
                {
                    OnAllAsteroidsDestroyed();
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);

                player.Draw();
                DrawBullets();
                DrawAsteroids();
                DrawEnemies();

                Raylib.DrawText($"Score: {Score}", ScreenWidth - 100, 10, 20, Color.Gray);
                Raylib.EndDrawing();

                Raylib.UpdateMusicStream(music);  // Update the music stream to play it
            }

            Raylib.UnloadMusicStream(music);  // Unload the music stream when done
            Raylib.CloseAudioDevice();  // Close the audio device
        }

        static void UpdateBullets()
        {
            foreach (Bullet b in bullets)
                b.Update();
            bullets.RemoveAll(b => b.IsDead());

            foreach (Bullet b in enemyBullets)
                b.Update();
            enemyBullets.RemoveAll(b => b.IsDead());
        }

        static void ShootBullet()
        {
            float angleRad = player.rotation * Program.Deg2Rad;
            Vector2 direction = new Vector2((float)Math.Sin(angleRad), (float)-Math.Cos(angleRad));
            bullets.Add(new Bullet(player.position, direction, 5f));
        }

        static void CheckCollisions()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Update();
                enemy.Draw();

                float dist = Vector2.Distance(enemy.position, player.position);
                if (dist < 20f + player.Size / 2f)
                {
                    player.IsDead = true;
                    return;
                }
            }

            foreach (Asteroid asteroid in asteroids)
            {
                float dist = Vector2.Distance(asteroid.position, player.position);
                if (dist < asteroid.Size + player.Size / 2f)
                {
                    player.IsDead = true;
                    return;
                }
            }

            foreach (Bullet bullet in bullets.ToList())
            {
                foreach (Asteroid asteroid in asteroids.ToList())
                {
                    float dist = Vector2.Distance(bullet.position, asteroid.position);
                    if (dist < asteroid.Size)
                    {
                        asteroid.BreakIntoSmallerPieces(asteroids, rng);
                        bullets.Remove(bullet);
                        Score += 10;
                        break;
                    }
                }
            }
        }

        static void DrawBullets()
        {
            foreach (Bullet b in bullets)
                b.Draw();
            foreach (Bullet b in enemyBullets)
                b.Draw();
        }

        static void DrawAsteroids()
        {
            foreach (Asteroid asteroid in asteroids)
            {
                asteroid.Update();
                asteroid.Draw();
            }
        }

        static void DrawEnemies()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Update();
                enemy.Draw();
            }
        }

        static void OnAllAsteroidsDestroyed()
        {
            Score += 100;

            SpawnAsteroids(5 + Score / 100);

            int enemiesToAdd = 1 + Score / 200;
            for (int i = 0; i < enemiesToAdd; i++)
            {
                enemies.Add(new Enemy(new Vector2(rng.Next(ScreenWidth), rng.Next(ScreenHeight))));
            }
        }

        static void RestartGame()
        {
            player = new Player(new Vector2(ScreenWidth / 2f, ScreenHeight / 2f));
            player.IsDead = false;
            asteroids.Clear();
            bullets.Clear();
            enemyBullets.Clear();
            enemies.Clear();
            Score = 0;
            SpawnAsteroids(5);
            enemies.Add(new Enemy(new Vector2(100, 100)));
        }

        static void SpawnAsteroids(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Vector2 pos = new Vector2(rng.Next(ScreenWidth), rng.Next(ScreenHeight));
                float size = rng.Next(20, 40);
                Vector2 dir = new Vector2(
                    (float)(rng.NextDouble() * 2 - 1),
                    (float)(rng.NextDouble() * 2 - 1)
                );
                dir = Vector2.Normalize(dir) * 2f;

                asteroids.Add(new Asteroid(pos, size, dir));
            }
        }
    }
}
