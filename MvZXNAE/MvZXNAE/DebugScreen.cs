using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using static MvZXNAE.GameMain;
using Microsoft.Xna.Framework.Graphics;

namespace MvZXNAE
{
    public class DebugScreen
    {
        public static void debugScreen()
        {
            MouseState ms = Mouse.GetState();
            spriteBatch.DrawString(defaultFont, $"Mouse position: x:{ms.X} y:{ms.Y}\nGraphic: {GraphicsAdapter.DefaultAdapter.Description}\nFPS:", Vector2.Zero, Color.Black);
        }
    }
}
