using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using static MvZXNAE.GameMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace MvZXNAE
{
    public class DebugScreen
    {
        public static void debugScreen()
        {
            MouseState ms = Mouse.GetState();
            spriteBatch.DrawString(defaultFont, $"Mouse position\n    x:{ms.X} y:{ms.Y}\nGraphic\n    \nFPS:", Vector2.Zero, Color.Black);
        }
    }
}
