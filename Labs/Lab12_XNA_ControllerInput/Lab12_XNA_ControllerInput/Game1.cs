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
using ExplodingTeddies;

namespace Lab12_XNA_ControllerInput
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        TeddyBear bear;
        TeddyBear newBear;
        Explosion explosion;

        // thumbstick movement
        const int THUMBSTICK_DEFLECTION_AMOUNT = 20;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;

            IsMouseVisible = true;
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
            bear = new TeddyBear(this.Content, WINDOW_WIDTH, WINDOW_HEIGHT, "teddybear", WINDOW_WIDTH / 2, WINDOW_HEIGHT / 2, new Vector2(1, 1));
            explosion = new Explosion(this.Content);
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
            bear.Update();
            explosion.Update(gameTime);

            GamePadState gamepad = GamePad.GetState(PlayerIndex.One);

            if (gamepad.IsConnected)
            {
                //Spawning a new teddy bear when B button is pressed
                if (gamepad.Buttons.B==ButtonState.Pressed)
                {
                    //create random X and Y for the new bear
                    // create random velocity for the new bear
                    Random rand=new Random();
                    int newBearX = rand.Next(WINDOW_WIDTH);
                    int newBearY = rand.Next(WINDOW_HEIGHT);

                    float newVelocityX = rand.Next(-2, 2);
                    float newVelocityY = rand.Next(-2, 2);

                    bear.Active = false;
                    newBear = new TeddyBear(this.Content, WINDOW_WIDTH/2, WINDOW_HEIGHT/2, "teddybear", newBearX, newBearY, new Vector2(newVelocityX,newVelocityY));

                }

                //Explode the teddy bear when A button pressed
                if (gamepad.Buttons.A == ButtonState.Pressed)
                {
                    //start playing the explosion at the center of the teddy bear and replace the current teddy bear
                    bear.Active = false;
                    explosion.Play(bear.DrawRectangle.Center.X, bear.DrawRectangle.Center.Y);
                    
                } 
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
            bear.Draw(spriteBatch);
            explosion.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
