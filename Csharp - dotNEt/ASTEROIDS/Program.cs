using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Raylib_cs;
using LukaLib;

namespace ASTEROIDS
{
    internal class Program
    {
        static Music music;
        static Sound shootSound;

        public static int ScreenWidth = 800;
        public static int ScreenHeight = 600;
        public static List<Bullet> enemyBullets = new List<Bullet>();

        
        public static Vector2 PlayerPosition => player.Transform.Position;

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
            Raylib.InitAudioDevice();

            
            string musicPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Assets", "Audio", "Music.mp3");
            if (!File.Exists(musicPath))
            {
                Console.WriteLine("Error: Music file not found.");
                return;
            }
            music = Raylib.LoadMusicStream(musicPath);
            Raylib.SetMusicVolume(music, 0.2f);
            Raylib.PlayMusicStream(music);

            
            string shootSoundPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "Assets", "Audio", "Shoot.mp3");
            if (!File.Exists(shootSoundPath))
            {
                Console.WriteLine("Error: Shoot sound file not found.");
                return;
            }
            shootSound = Raylib.LoadSound(shootSoundPath);
            Raylib.SetSoundVolume(shootSound, 0.3f);

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
                UpdateAndDrawAsteroids();
                DrawEnemies();

                Raylib.DrawText($"Score: {Score}", ScreenWidth - 100, 10, 20, Color.Gray);
                Raylib.EndDrawing();

                Raylib.UpdateMusicStream(music);
            }

            Raylib.UnloadMusicStream(music);
            Raylib.UnloadSound(shootSound);
            Raylib.CloseAudioDevice();
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
            float angleRad = player.Transform.RotationRadians;
            Vector2 direction = player.Transform.Direction; 
            bullets.Add(new Bullet(player.Transform.Position, direction, 5f));
        }

        static void CheckCollisions()
        {
            
            foreach (Enemy enemy in enemies)
            {
                enemy.Update();

                if (Collision2d.CheckCollision2d(enemy.Transform, enemy.Collision,
                                                 player.Transform, player.Collision))
                {
                    player.IsDead = true;
                    return;
                }
            }

            foreach (Asteroid asteroid in asteroids)
            {
                if (Collision2d.CheckCollision2d(asteroid.Transform, asteroid.Collision,
                                                 player.Transform, player.Collision))
                {
                    player.IsDead = true;
                    return;
                }
            }

           
            foreach (Bullet bullet in bullets.ToArray())
            {
                foreach (Asteroid asteroid in asteroids.ToArray())
                {
                    if (Collision2d.CheckCollision2d(bullet.Transform, bullet.Collision,
                                                     asteroid.Transform, asteroid.Collision))
                    {
                        asteroid.BreakIntoSmallerPieces(asteroids);
                        bullets.Remove(bullet);
                        Score += 10;
                        break;
                    }
                }
            }
        }

        /*static void CheckCollisions()
        {
            
            foreach (Enemy enemy in enemies)
            {
                enemy.Update();

                float dist = Vector2.Distance(enemy.Transform.Position, player.Transform.Position);
                if (dist < enemy.Collision.Radius + player.Collision.Radius)
                {
                    player.IsDead = true;
                    return;
                }
            }

            
            foreach (Asteroid asteroid in asteroids)
            {
                float dist = Vector2.Distance(asteroid.Transform.Position, player.Transform.Position);
                if (dist < asteroid.Collision.Radius + player.Collision.Radius)
                {
                    player.IsDead = true;
                    return;
                }
            }

            
            foreach (Bullet bullet in bullets.ToArray())
            {
                foreach (Asteroid asteroid in asteroids.ToArray())
                {
                    float dist = Vector2.Distance(bullet.Transform.Position, asteroid.Transform.Position);
                    if (dist < asteroid.Collision.Radius)
                    {
                        asteroid.BreakIntoSmallerPieces(asteroids);
                        bullets.Remove(bullet);
                        Score += 10;
                        break;
                    }
                }
            }
        }*/

        static void DrawBullets()
        {
            foreach (Bullet b in bullets)
                b.Draw();
            foreach (Bullet b in enemyBullets)
                b.Draw();
        }

        static void UpdateAndDrawAsteroids()
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
                enemy.Draw();
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
