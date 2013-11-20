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

namespace Lab15
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

        // random texture support
        const int NUM_TEXTURES = 3;
        Random rand = new Random();
        List<Texture2D> textures = new List<Texture2D>();

        // drawing support
        const int MAX_TEXTURES = 100000;
        List<Texture2D> drawTextures = new List<Texture2D>();
        List<Rectangle> drawRectangles = new List<Rectangle>();

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

            // STUDENTS: Use a for loop to load each of the teddy bear textures and 
            // add them to the textures list
            for (int i = 0; i < NUM_TEXTURES; i++)
            {
                textures.Add(Content.Load<Texture2D>("teddybear" + i));
            }

            // STUDENTS: Use a for loop to add one of each of the textures to the 
            // drawTextures list, adding a corresponding random draw rectangle to 
            // the drawRectangles list by calling the GetRandomDrawRectangle method
            for (int i = 0; i < textures.Count; i++)
            {
                drawTextures.Add(textures[i]);
                drawRectangles.Add(GetRandomDrawRectangle(textures[i]));
            }

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

            GamePadState gamepad = GamePad.GetState(PlayerIndex.One);
            MouseState mouse = Mouse.GetState();
            KeyboardState key = Keyboard.GetState();

            // STUDENTS: While the gamepad is connected, the A button is pressed, and
            // the drawTextures count is less than MAX_TEXTURES, add a random
            // texture to the drawTextures list and add a corresponding random
            // draw rectangle to the drawRectangles list by calling the 
            // GetRandomDrawRectangle method. You also need to get the current
            // gamepad state at the end of the loop body

            //if not gamepad connected I use the RIGHT BUTTON instead
            if (gamepad.IsConnected && gamepad.Buttons.A==ButtonState.Pressed && (drawTextures.Count <MAX_TEXTURES))
            {
              drawTextures.Add(textures[rand.Next(NUM_TEXTURES)]);
              drawRectangles.Add(GetRandomDrawRectangle(textures[rand.Next(NUM_TEXTURES)]));
              gamepad = GamePad.GetState(PlayerIndex.One);
            }
            else
            {
                if (mouse.RightButton == ButtonState.Pressed || key.IsKeyDown(Keys.A) && (drawTextures.Count <MAX_TEXTURES))
	            {
                    drawTextures.Add(textures[rand.Next(NUM_TEXTURES)]);
                    drawRectangles.Add(GetRandomDrawRectangle(textures[rand.Next(NUM_TEXTURES)]));
                    key=Keyboard.GetState();
                    mouse = Mouse.GetState();
                    
		 
	            }
            }
            // STUDENTS: While the gamepad is connected, the B button is pressed,
            // and the drawTextures list isn't empty, remove the last texture from the 
            // drawTextures list and the last rectangle from the drawRectangles list. 
            // You also need to get the current gamepad state at the end of the loop body

            //if not gamepad connected I use the RIGHT BUTTON instead
            if (((gamepad.IsConnected && gamepad.Buttons.B==ButtonState.Pressed)||(mouse.LeftButton==ButtonState.Pressed)||(key.IsKeyDown(Keys.B))) && (drawTextures.Count!=0))
            {
                drawTextures.RemoveAt(drawTextures.Count-1);
                drawRectangles.RemoveAt(drawRectangles.Count-1);
                key=Keyboard.GetState();
                mouse = Mouse.GetState();
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

            // STUDENTS: Use a for loop to draw each of the textures in the drawTextures list 
            // using the corresponding elements from the drawRectangles list for the Draw calls
            spriteBatch.Begin();
                
            for (int i = 0; i < drawTextures.Count; i++)
            {
                spriteBatch.Draw(drawTextures[i], drawRectangles[i], Color.White); 
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Gets and returns a random draw rectangle for the given sprite
        /// </summary>
        /// <param name="sprite">the sprite</param>
        /// <returns>the random darw rectangle</returns>
        private Rectangle GetRandomDrawRectangle(Texture2D sprite)
        {
            // STUDENTS: Replace the 2 zeros below with random  X and Y locations
            // for the draw rectangle. Make sure the entire sprite is inside the
            // window
            return new Rectangle(rand.Next(WINDOW_WIDTH-sprite.Width), rand.Next(WINDOW_HEIGHT-sprite.Height), sprite.Width, sprite.Height);
        }
    }
}
