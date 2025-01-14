
#region variables

int playerHP = 150;
int orcHP = 150;

string orcName = "Orc";
string playerName = "Sigismund(You)";

Random rand = new Random();
#endregion

#region Loop
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("You are a Space Marine belonging to the black templars legion, and you have been sent to eliminate an orc that is harassing the villagers of a small village.");
Console.WriteLine("You find the orc in the nearby forest and rush into battle!");
Console.ResetColor();
Console.WriteLine("--------------------------------------------------------------");

while (playerHP > 0 && orcHP > 0)
{
    //Pelin tilanne
    Console.WriteLine($"{playerName}: {playerHP}  {orcName}: {orcHP}");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("1 - Attack with your power sword");
    Console.WriteLine("2 - Block with your shield");
    Console.ResetColor();
    Console.Write("What do you want to do? ");
    string playerChoice = Console.ReadLine();

    if (playerChoice == "1")
    {
        int playerDamage = rand.Next(10, 21);
        orcHP -= playerDamage;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You attack the {orcName} and deal {playerDamage} damage!");
        Console.ResetColor();
    }
    else if (playerChoice == "2")
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You raise your shield and block the next attack.");
        Console.ResetColor();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input, try again.");
        Console.ResetColor();
    }

    if (orcHP > 0)
    {
        int orcDamage = rand.Next(10, 21); 
       if (playerChoice == "2")
        {
            orcDamage /= 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"The {orcName} attacks but you block with your shield reducing the damage to {orcDamage}");
            Console.ResetColor();
        }
       else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"The {orcName} attacks you dealing {orcDamage} damage!");
            Console.ResetColor();
        }
        playerHP -= orcDamage;
    }
    if (playerHP <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You watch as the orc lunges forward but you slip and the orcs sword goes through your chestplate. You watch as the orc grins at you and then you feel the world around you darken into nothingness...");
        Console.WriteLine("You have been defeated!");
        Console.ResetColor();
        break;
    }
    else if(orcHP <= 0)
    {
        Console.ForegroundColor= ConsoleColor.Green;
        Console.WriteLine("You watch as the orc lunges forward but you duck its attack into a riposte and cut its head clean off, blood splurting everywhere.");
        Console.WriteLine("You are victorious!");
        Console.ResetColor();
    }
}
#endregion