using Raylib_cs;
using RayGuiCreator;
using System;

namespace Valikkopeli
{
    public class PauseMenu
    {
        public event EventHandler BackButtonPressedEvent;

        private MenuCreator creator;

        public PauseMenu()
        {
            creator = new MenuCreator(
                300, // startX
                200, // startY
                200, // buttonWidth
                40,  // buttonHeight
                0,   // spacingX
                20   // spacingY
            );
        }

        public void DrawMenu()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Brown);

            creator.Label("Pause Menu");

            if (creator.Button("Back"))
            {
                BackButtonPressedEvent?.Invoke(this, EventArgs.Empty);
            }

            Raylib.EndDrawing();
        }
    }
}
