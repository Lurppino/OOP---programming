using RayGuiCreator;
using Raylib_cs;
using System.Collections.Generic;
using static ASTEROIDS.Program;

namespace ASTEROIDS
{
    public static class MainMenuScreen
    {
        static MultipleChoiceEntry shipColorChoices =
            new MultipleChoiceEntry(new string[] { "Blue", "Green", "Red", "Yellow" });

        public static void Draw(MenuCreator mainMenu, Stack<GameState> stateStack, System.Action restartGame)
        {
            Raylib.ClearBackground(Color.Black);
            mainMenu.ResetPosition();

            mainMenu.Label("ASTEROIDS", true);
            mainMenu.Label("Use arrows to move, Space to shoot", true);

            mainMenu.Label("Ship Color:", true);

            int oldX = mainMenu.drawX;
            int oldY = mainMenu.drawY;
            mainMenu.drawX = oldX + 250;
            mainMenu.drawY = oldY;
            mainMenu.DropDown(shipColorChoices, oldX + 250, oldY);
            mainMenu.drawX = oldX;
            mainMenu.drawY = oldY + 40;

            Program.SelectedShipColor = (ShipColor)shipColorChoices.GetIndex();

            if (mainMenu.Button("Start Game"))
            {
                restartGame();
                stateStack.Push(GameState.GameLoop);
            }

            if (mainMenu.Button("Options"))
            {
                stateStack.Push(GameState.OptionsMenu);
            }

            if (mainMenu.Button("Quit"))
            {
                stateStack.Push(GameState.Quit);
            }
            mainMenu.EndMenu();
        }

    }
}
