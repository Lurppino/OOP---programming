using Raylib_cs;
using System.Numerics;

public class Game
{

    bool gameRunning;

    Tank player1Tank;
    Tank player2Tank;

    int player1Score = 0;
    int player2Score = 0;

    Rectangle obstacle1;
    Rectangle obstacle2;

    List<Bullet> bullets;



    public static void Main()
    {
        Game game = new Game();
        game.Run();
    }

    public void Run()
    {
        Init();
        GameLoop();
    }


    private void Init()
    {
        Raylib.InitWindow(800, 600, "Tank Game");
        Raylib.SetTargetFPS(60);

        player1Tank = new Tank(new Vector2(200, 300), Raylib_cs.Color.Blue);
        player2Tank = new Tank(new Vector2(600, 300), Raylib_cs.Color.Red);

        obstacle1 = new Rectangle(250, 150, 40, 300);
        obstacle2 = new Rectangle(510, 150, 40, 300);

        gameRunning = true;
        bullets = new List<Bullet>();
    }

    private void GameLoop()
    {
        while (!Raylib.WindowShouldClose() && gameRunning)
        {
            UpdateGame();
            DrawGame();
        }

        Raylib.CloseWindow();
    }

    private bool gameOverDisplayed = false;
    private void UpdateGame()
    {
        if (gameOverDisplayed)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.Enter))
            {
                ResetGame();
            }
            return; 
        }

        // Player 1 movement and angle update
        if (Raylib.IsKeyDown(KeyboardKey.W)) player1Tank.Move(0, -player1Tank.speed, -90f, obstacle1, obstacle2);
        if (Raylib.IsKeyDown(KeyboardKey.S)) player1Tank.Move(0, player1Tank.speed, 90f, obstacle1, obstacle2);
        if (Raylib.IsKeyDown(KeyboardKey.A)) player1Tank.Move(-player1Tank.speed, 0, 180f, obstacle1, obstacle2);
        if (Raylib.IsKeyDown(KeyboardKey.D)) player1Tank.Move(player1Tank.speed, 0, 0f, obstacle1, obstacle2);

        // Player 2 movement and angle update
        if (Raylib.IsKeyDown(KeyboardKey.I)) player2Tank.Move(0, -player2Tank.speed, -90f, obstacle1, obstacle2);
        if (Raylib.IsKeyDown(KeyboardKey.K)) player2Tank.Move(0, player2Tank.speed, 90f, obstacle1, obstacle2);
        if (Raylib.IsKeyDown(KeyboardKey.J)) player2Tank.Move(-player2Tank.speed, 0, 180f, obstacle1, obstacle2);
        if (Raylib.IsKeyDown(KeyboardKey.L)) player2Tank.Move(player2Tank.speed, 0, 0f, obstacle1, obstacle2);

        // Handle shooting
        if (Raylib.IsKeyPressed(KeyboardKey.E))
        {
            Bullet bullet = player1Tank.Shoot();
            bullets.Add(bullet);
        }
        if (Raylib.IsKeyPressed(KeyboardKey.U))
        {
            Bullet bullet = player2Tank.Shoot();
            bullets.Add(bullet);
        }

        // Update bullets
        List<Bullet> bulletsToRemove = new List<Bullet>();
        foreach (var bullet in bullets)
        {
            bullet.UpdateBullets();

            if (IsBulletCollidingWithTank(bullet, player1Tank))
            {
                bulletsToRemove.Add(bullet);
                player2Score++;  // Player 2 scores when hitting Player 1
            }
            if (IsBulletCollidingWithTank(bullet, player2Tank))
            {
                bulletsToRemove.Add(bullet);
                player1Score++;  // Player 1 scores when hitting Player 2
            }
            if (Raylib.CheckCollisionRecs(new Rectangle(bullet.position.X, bullet.position.Y, 5, 10), obstacle1) ||
                Raylib.CheckCollisionRecs(new Rectangle(bullet.position.X, bullet.position.Y, 5, 10), obstacle2))
            {
                bulletsToRemove.Add(bullet); // Remove bullets that hit obstacles
            }
        }

        // Remove bullets that collided
        foreach (var bullet in bulletsToRemove)
        {
            bullets.Remove(bullet);
        }

        // Check win conditions
        if (player1Score >= 50)
        {
            ShowGameOver("Player 1 Wins!");
            gameOverDisplayed = true;
        }
        else if (player2Score >= 50)
        {
            ShowGameOver("Player 2 Wins!");
            gameOverDisplayed = true;
        }
    }

    private bool IsBulletCollidingWithTank(Bullet bullet, Tank tank)
    {
        // Tank's bounding box
        float tankLeft = tank.position.X;
        float tankRight = tank.position.X + 40;
        float tankTop = tank.position.Y;
        float tankBottom = tank.position.Y + 40;

        // Bullet's bounding box
        float bulletLeft = bullet.position.X;
        float bulletRight = bullet.position.X + 5;  // Bullet width (adjust if needed)
        float bulletTop = bullet.position.Y;
        float bulletBottom = bullet.position.Y + 10;  // Bullet height (adjust if needed)

        // Debugging output to log the bullet and tank positions
        Console.WriteLine($"Tank: L={tankLeft}, R={tankRight}, T={tankTop}, B={tankBottom}");
        Console.WriteLine($"Bullet: L={bulletLeft}, R={bulletRight}, T={bulletTop}, B={bulletBottom}");

        // Check if the bullet intersects the tank's bounding box
        return bulletRight > tankLeft && bulletLeft < tankRight && bulletBottom > tankTop && bulletTop < tankBottom;
    }

    private void ShowGameOver(string message)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Raylib_cs.Color.DarkGreen);

        Raylib.DrawRectangleRec(obstacle1, Raylib_cs.Color.Maroon);
        Raylib.DrawRectangleRec(obstacle2, Raylib_cs.Color.Maroon);

        player1Tank.Draw();
        player2Tank.Draw();

        Raylib.EndDrawing();
    }
    private void ResetGame()
    {
        // Reset scores
        player1Score = 0;
        player2Score = 0;

        // Reset tank positions
        player1Tank.position = new Vector2(200, 300);
        player2Tank.position = new Vector2(600, 300);

        // Reset obstacles (if needed)
        obstacle1 = new Rectangle(250, 150, 40, 300);
        obstacle2 = new Rectangle(510, 150, 40, 300);

        // Clear the list of bullets
        bullets.Clear();
    }
    private void DrawGame()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Raylib_cs.Color.DarkGreen);

        Raylib.DrawRectangleRec(obstacle1, Raylib_cs.Color.Maroon);
        Raylib.DrawRectangleRec(obstacle2, Raylib_cs.Color.Maroon);

        player1Tank.Draw();
        player2Tank.Draw();

        // Draw player scores
        Raylib.DrawText($"Blue: {player1Score}", 20, 20, 20, Color.Blue);
        Raylib.DrawText($"Red: {player2Score}", 700, 20, 20, Color.Red);

        // Draw text "50 points to win" and "Press Enter to restart the game" at the top of the screen
        string centerText = "50 points to win";
        string restartText = "Press Enter to restart the game";

        int centerTextWidth = Raylib.MeasureText(centerText, 20);
        int restartTextWidth = Raylib.MeasureText(restartText, 20);

        // Center the text horizontally
        int centerX = (Raylib.GetScreenWidth() - centerTextWidth) / 2;
        int restartX = (Raylib.GetScreenWidth() - restartTextWidth) / 2;

        // Draw the centered text at the top of the screen (with a small vertical offset)
        Raylib.DrawText(centerText, centerX, 20, 20, Raylib_cs.Color.White);  // Top of the screen
        Raylib.DrawText(restartText, restartX, 50, 20, Raylib_cs.Color.White);  // Just below the first line

        // Draw bullets
        foreach (var bullet in bullets)
        {
            Raylib.DrawRectangle((int)bullet.position.X, (int)bullet.position.Y, 5, 10, Color.Yellow);
        }

        Raylib.EndDrawing();
    }


    public class Tank
    {
        public Vector2 position;
        public float speed;
        public float angle;
        public Color color;
        public float tankAngle;

        public Tank(Vector2 initialPosition, Color tankColor)
        {
            position = initialPosition;
            speed = 1.0f;
            angle = 0f;
            color = tankColor;
        }

        public void Move(float dx, float dy, float angle, Rectangle obstacle1, Rectangle obstacle2)
        {
            Vector2 newPosition = new Vector2(position.X + dx, position.Y + dy);
            Rectangle tankRect = new Rectangle(newPosition.X, newPosition.Y, 40, 40);

            // Constrain the tank's position within the window bounds
            if (newPosition.X >= 0 && newPosition.X <= 760 && newPosition.Y >= 0 && newPosition.Y <= 560)
            {
                if (!Raylib.CheckCollisionRecs(tankRect, obstacle1) && !Raylib.CheckCollisionRecs(tankRect, obstacle2))
                {
                    position = newPosition;
                    tankAngle = angle;
                }
            }
        }
        public Vector2 GetBulletDirection(float angle)
        {
            float radians = MathF.PI * angle / 180f;

            float directionX = MathF.Cos(radians);
            float directionY = MathF.Sin(radians);

            return new Vector2(directionX, directionY);
        }
        // Käytin tekoälyä tässä koska en millään saanut tankin kanuunaa toimimaan
        // Joten tässä se piirtää tankin kanuunan osoitammaan siihen suuntaan
        // Johon tankki liikkuu.
        public void Draw()
        {

            Vector2 tankSize = new Vector2(40, 40);
            Vector2 cannonSize = new Vector2(10, 30); 
            Vector2 tankOrigin = tankSize / 2; 
            Vector2 cannonOrigin = new Vector2(cannonSize.X / 2, cannonSize.Y / 2);

            Vector2 cannonOffset = GetCannonOffset(tankAngle);
            Vector2 cannonPosition = position + cannonOffset;

            Raylib.DrawRectanglePro(
                new Rectangle(position.X, position.Y, tankSize.X, tankSize.Y),
                tankOrigin,
                tankAngle,
                color
            );

            Raylib.DrawRectanglePro(
                new Rectangle(cannonPosition.X, cannonPosition.Y, cannonSize.X, cannonSize.Y),
                cannonOrigin,
                tankAngle + 90f,
                Color.DarkGray
            );


        }

        public Vector2 GetCannonOffset(float angle)
        {
            float offset = 20f;  

            if (angle == 0f) return new Vector2(offset, 0);      
            if (angle == 90f) return new Vector2(0, offset);
            if (angle == 180f) return new Vector2(-offset, 0);    
            if (angle == -90f) return new Vector2(0, -offset);  

            return Vector2.Zero;
        }
        // AI koodi loppuu

        public Bullet Shoot()
        {
            float bulletSpawnDistance = 20f; 

            Vector2 cannonOffset = GetCannonOffset(tankAngle) + GetBulletDirection(tankAngle) * bulletSpawnDistance;

            Vector2 bulletPosition = position + cannonOffset;

            Vector2 bulletDirection = GetBulletDirection(tankAngle);

            Bullet bullet = new Bullet(bulletPosition, bulletDirection);

            return bullet;
        }

    }
    public class Bullet
    {
        public Vector2 position;
        public Vector2 direction;
        public float speed;

        public Bullet(Vector2 initialPosition, Vector2 direction)
        {
            position = initialPosition;
            this.direction = direction;
            speed = 5f;
        }

        public void UpdateBullets()
        {
            position += direction * speed;
        }
        
        public Vector2 GetBulletDirection(float angle)
        {
            if (angle == 0f) return new Vector2(1, 0);
            if (angle == 90f) return new Vector2(0, 1);
            if (angle == 180f) return new Vector2(-1,0);
            if (angle == -90f) return new Vector2(0, -1);

            return Vector2.Zero;
        }
    }
}