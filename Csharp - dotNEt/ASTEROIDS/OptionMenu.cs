using Raylib_cs;
using RayGuiCreator;
using System.Collections.Generic;

namespace ASTEROIDS
{
    public static class OptionsMenuScreen
    {
        public static void Draw(MenuCreator optionsMenu, Stack<GameState> stateStack)
        {
            Raylib.ClearBackground(Color.DarkGray);

            optionsMenu.ResetPosition();

            optionsMenu.Label("OPTIONS");
            optionsMenu.Label("Adjust your settings");

            if (optionsMenu.Button("Back"))
            {
                stateStack.Pop();
            }
        }
    }
}
