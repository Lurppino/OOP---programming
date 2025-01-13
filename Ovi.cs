using System.Reflection.Emit;

namespace Ovi_Enum
{
    internal class Program
    {
        enum Door
        {
            Open,
            Closed,
            Locked
        }
        static void Main(string[] args)
        {
            Door doorState = Door.Locked;


            while (true)
            {
                Console.WriteLine($"The door is currently {doorState}. What would you like to do?");
                Console.WriteLine("Commands: Open, Close, Lock, Unlock, Exit");
                string command = Console.ReadLine()?.Trim().ToLower();
                Console.WriteLine("---------------------------------");

                switch (command)
                {
                    case "open":
                        if (doorState == Door.Closed)
                        {
                            doorState = Door.Open;
                            Console.WriteLine("You opened the door.");
                            Console.WriteLine("---------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("You can't open the door right now.");
                            Console.WriteLine("---------------------------------");
                        }
                        break;

                    case "close":
                        if (doorState == Door.Open)
                        {
                            doorState = Door.Closed;
                            Console.WriteLine("You closed the door.");
                            Console.WriteLine("---------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("You can't close the door right now.");
                            Console.WriteLine("---------------------------------");
                        }
                        break;
                    case "unlock":
                        if (doorState == Door.Locked)
                        {
                            doorState = Door.Closed;
                            Console.WriteLine("You unlock the door");
                            Console.WriteLine("---------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("You can't unlock the door right now.");
                            Console.WriteLine("---------------------------------");
                        }
                        break;
                    case "lock":
                        if (doorState == Door.Closed)
                        {
                            doorState = Door.Locked;
                            Console.WriteLine("You lock the door.");
                            Console.WriteLine("---------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("You can't lock the door right now");
                            Console.WriteLine("---------------------------------");
                        }
                        break;
                    case "exit":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        Console.WriteLine("---------------------------------");
                        break;

                }
            }
        }

    }
}
