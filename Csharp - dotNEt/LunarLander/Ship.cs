using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LunarLander
{
    internal class Ship
    {
        // MUUTTUJAT: 
        // Pelaajan sijainti
        public Vector2 position;
        public float gravity;
        // Onko moottori päällä ?
        public bool isMotorOn;
        // Moottorin voimakkuus
        public int motorPower;
        // Pelaajan nopeus, polttoaine ja kuinka nopeasti polttoaine kuluu
        public float speed;
        public int fuelAmount = 350;
        public int fuelConsumption = 1;
        public Ship(Vector2 startPosition, float gravity, int motorPower)
        {
            this.position = startPosition;
            this.gravity = gravity;
            this.motorPower = motorPower;
            this.speed = 0f;
        }
        public void Update()
        {
            // Kun pelaaja painaa nappia (esim nuoli ylös)
            // ja polttoainetta on jäljellä, lisää
            // kiihtyvyys nopeuteen
            if (Raylib.IsKeyDown(KeyboardKey.Up) && fuelAmount > 0)
            {
                speed -= motorPower * 0.005f;
                fuelAmount -= fuelConsumption;
            }
            speed += gravity;
            position.Y += speed;
        }

        public void Draw()
        {
            // Piirrä alus: käytä kolmiota tai muita muotoja
            Raylib.DrawTriangle(new Vector2(position.X, position.Y - 20),
                                new Vector2(position.X - 10, position.Y + 10),
                                new Vector2(position.X + 10, position.Y + 10),
                                Raylib_cs.Color.White);

            // Piirrä moottorin liekki
            if (Raylib.IsKeyDown(KeyboardKey.Up) && fuelAmount > 0)
            {
                Raylib.DrawTriangle(new Vector2(position.X, position.Y + 15),
                                    new Vector2(position.X - 5, position.Y + 25),
                                    new Vector2(position.X + 5, position.Y + 25),
                                    Color.Orange);
            }

            // Piirrä polttoaineen tilanne
            Raylib.DrawText($"Fuel: {fuelAmount}", 10, 10, 20, Color.White);
            Raylib.DrawText($"Speed: {speed}", 10,30, 20, Color.White);
        }
    }
}
