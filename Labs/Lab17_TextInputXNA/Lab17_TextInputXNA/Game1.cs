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

namespace Lab17_TextInputXNA
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;
        const int MOVEMENT_STEP = 10;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D woman;
        Rectangle drawRect;
        SpriteFont font;
        Vector2 fontPosition;

        int offScreenCount = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            woman = this.Content.Load<Texture2D>("spider");
            drawRect = new Rectangle(WINDOW_WIDTH / 2-woman.Width/2, WINDOW_HEIGHT / 2-woman.Height/2, woman.Width, woman.Height);
            font = Content.Load<SpriteFont>("Arial");
            fontPosition = new Vector2(WINDOW_WIDTH / 5, WINDOW_HEIGHT / 10);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.A)||key.IsKeyDown(Keys.Left))
            {
                drawRect.X -= MOVEMENT_STEP;
            }
            if (key.IsKeyDown(Keys.D) || key.IsKeyDown(Keys.Right))
            {
                drawRect.X += MOVEMENT_STEP;
            }
            if (key.IsKeyDown(Keys.W) || key.IsKeyDown(Keys.Up))
            {
                drawRect.Y -= MOVEMENT_STEP;
            }
            if (key.IsKeyDown(Keys.S) || key.IsKeyDown(Keys.Down))
            {
                drawRect.Y += MOVEMENT_STEP;
            }
            if (key.IsKeyDown(Keys.Space))
            {
                drawRect.X = WINDOW_WIDTH/2 - drawRect.Width / 2;
                drawRect.Y = WINDOW_HEIGHT/2 - drawRect.Height / 2;
            }
            key = Keyboard.GetState();

            //calculate offscreen numbers
            if (drawRect.Left<0 || drawRect.Right>WINDOW_WIDTH || drawRect.Top<0 || drawRect.Bottom>WINDOW_HEIGHT )
            {
                offScreenCount++;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(woman, drawRect, Color.White);
            spriteBatch.DrawString(font, "Number of times the asset has gone off the screen : "+offScreenCount, fontPosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
