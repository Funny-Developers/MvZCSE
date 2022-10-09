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
        GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static SpriteFont defaultFont;
        Color backgoundColor;
        SoundEffect menuBGM;
        SoundEffectInstance bgmInstance;

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
            buttonNormal = Content.Load<Texture2D>("ButtonNormal");//��ť����
            buttonMoveOver = Content.Load<Texture2D>("ButtonMoveOver");//�����ͣ����ť
            buttonPressed = Content.Load<Texture2D>("ButtonPressed");//��ť����
            button = buttonNormal;
            buttonRect = new Rectangle(300, 200, 128, 128);
            menuBGM = Content.Load<SoundEffect>("MainMenu");
            bgmInstance = menuBGM.CreateInstance();
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
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)//�ж��Ƿ�����������
            {
                backgoundColor = Color.Red;//����������Ϊ��ɫ
                if (buttonRect.Contains(mouseState.X, mouseState.Y))//�ж�����Ƿ��ƶ�����ť�ϲ��Ұ���
                {
                    button = buttonPressed;//����ť����Ϊ����״̬
                }
            }
            else
            {
                if (buttonRect.Contains(mouseState.X, mouseState.Y))//�ж�����Ƿ��ƶ�����ť��
                {
                    button = buttonMoveOver;//����ť����Ϊ��ͣ״̬
                }
                else//��겻�ڰ�ť��
                {
                    button = buttonNormal;//����ť����Ϊ����״̬
                }
                backgoundColor = Color.CornflowerBlue;//�ſ��������ָ�����ɫ 
            }
            if (bgmInstance.State == SoundState.Stopped) bgmInstance.Play();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            bool isF3Down = false;
            KeyboardState keyboardState = Keyboard.GetState(PlayerIndex.One);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (keyboardState.IsKeyDown(Keys.F3))
            {
                isF3Down = !isF3Down;
            }
            debugScreen(isF3Down);
            spriteBatch.Draw(button, buttonRect, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        void debugScreen(bool e)
        {
            MouseState mouseState = Mouse.GetState();
            if (e) spriteBatch.DrawString(defaultFont, $"v1.0\nMouse position: x:{mouseState.X} y:{mouseState.Y}\nGraphic: {GraphicsAdapter.DefaultAdapter.Description}\nFPS:", Vector2.Zero, Color.Black);
            else spriteBatch.DrawString(defaultFont, "v1.0", Vector2.Zero, Color.Black);
        }
    }
}
