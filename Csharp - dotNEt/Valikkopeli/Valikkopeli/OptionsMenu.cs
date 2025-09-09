using Raylib_cs;
using RayGuiCreator;
using System;

namespace Valikkopeli
{
    public class OptionsMenu
    {
        public event EventHandler BackButtonPressedEvent;

        private MenuCreator creator;

        public OptionsMenu()
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
            Raylib.ClearBackground(Color.DarkBlue);

            creator.Label("Options Menu");

            if (creator.Button("Back"))
            {
                BackButtonPressedEvent?.Invoke(this, EventArgs.Empty);
            }

            Raylib.EndDrawing();
        }
    }
}
