using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using static MvZXNAE.GameMain;


namespace MvZXNAE
{
    public class TitleScreen : DrawableGameComponent
    {
        public TitleScreen(Game game) : base(game)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
        
        protected override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            Game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(defaultFont, "Made with XNA Framework 4.0", Vector2.Zero, Color.White);
            base.Draw(gameTime);
        }
    }
}
