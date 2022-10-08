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

namespace MvZXNAE
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameMain : Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static SpriteFont defaultFont;
        Color backgoundColor;

        Texture2D buttonNormal;
        Texture2D buttonMoveOver;
        Texture2D buttonPressed;
        Rectangle buttonRect;
        Texture2D button;

        public GameMain()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            defaultFont = Content.Load<SpriteFont>("DebugScreenFont");
            buttonNormal = Content.Load<Texture2D>("ButtonNormal");//按钮正常
            buttonMoveOver = Content.Load<Texture2D>("ButtonMoveOver");//鼠标悬停到按钮
            buttonPressed = Content.Load<Texture2D>("ButtonPressed");//按钮按下
            button = buttonNormal;
            buttonRect = new Rectangle(300, 200, 128, 128);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState(PlayerIndex.One);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) Exit();
            if (keyboardState.IsKeyDown(Keys.F11))
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                if (graphics.IsFullScreen == true)
                {
                    graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                    graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                }
                else
                {
                    graphics.PreferredBackBufferWidth = 800;
                    graphics.PreferredBackBufferHeight = 600;
                }
                graphics.ApplyChanges();
            }

            MouseState mouseState = Mouse.GetState();//获取鼠标状态
            if (mouseState.LeftButton == ButtonState.Pressed)//判断是否按下了鼠标左键
            {
                backgoundColor = Color.Red;//将背景设置为红色
                if (buttonRect.Contains(mouseState.X, mouseState.Y))//判断鼠标是否移动到按钮上并且按下
                {
                    button = buttonPressed;//将按钮设置为按下状态
                }
            }
            else
            {
                if (buttonRect.Contains(mouseState.X, mouseState.Y))//判断鼠标是否移动到按钮上
                {
                    button = buttonMoveOver;//将按钮设置为悬停状态
                }
                else//鼠标不在按钮上
                {
                    button = buttonNormal;//将按钮设置为正常状态
                }
                backgoundColor = Color.CornflowerBlue;//放开鼠标左键恢复成蓝色 
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            DebugScreen.debugScreen();
            spriteBatch.Draw(button, buttonRect, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
