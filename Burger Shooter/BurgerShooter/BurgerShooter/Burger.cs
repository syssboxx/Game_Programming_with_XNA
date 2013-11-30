using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BurgerShooter
{
    /// <summary>
    /// A class for a burger
    /// </summary>
    public class Burger
    {
        #region Fields

        // graphic and drawing info
        Texture2D sprite;
        Rectangle drawRectangle;
        Texture2D frenchFriesSprite;

        // burger stats
        int health =GameConstants.BURGER_INITIAL_HEALTH;

        // shooting support
        bool canShoot = true;
        int elapsedCooldownTime = 0;

               

        #endregion

        #region Constructors

        /// <summary>
        ///  Constructs a burger
        /// </summary>
        /// <param name="contentManager">the content manager for loading content</param>
        /// <param name="spriteName">the sprite name</param>
        /// <param name="x">the x location of the center of the burger</param>
        /// <param name="y">the y location of the center of the burger</param>
        public Burger(ContentManager contentManager, string spriteName, int x, int y)
        {
            LoadContent(contentManager, spriteName, x, y);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the collision rectangle for the burger
        /// </summary>
        public Rectangle CollisionRectangle
        {
            get { return drawRectangle; }
        }

        public int Health
        {
            get { return health;}
            set
            {
                health = value;
                if (health<0)
                {
                    health = 0;
                }
            }
        }
        #endregion

        #region Private properties

        /// <summary>
        /// Gets and sets the x location of the center of the burger
        /// </summary>
        private int X
        {
            get { return drawRectangle.Center.X; }
            set
            {
                drawRectangle.X = value - drawRectangle.Width / 2;

                // clamp to keep in range
                if (drawRectangle.X < 0)
                {
                    drawRectangle.X = 0;
                }
                else if (drawRectangle.X > GameConstants.WINDOW_WIDTH - drawRectangle.Width)
                {
                    drawRectangle.X = GameConstants.WINDOW_WIDTH - drawRectangle.Width;
                }
            }
        }

        /// <summary>
        /// Gets and sets the y location of the center of the burger
        /// </summary>
        private int Y
        {
            get { return drawRectangle.Center.Y; }
            set
            {
                drawRectangle.Y = value - drawRectangle.Height / 2;

                // clamp to keep in range
                if (drawRectangle.Y < 0)
                {
                    drawRectangle.Y = 0;
                }
                else if (drawRectangle.Y > GameConstants.WINDOW_HEIGHT - drawRectangle.Height)
                {
                    drawRectangle.Y = GameConstants.WINDOW_HEIGHT - drawRectangle.Height;
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Updates the burger's location based on gamepad. Also fires 
        /// french fries as appropriate
        /// </summary>
        /// <param name="gameTime">game time</param>
        /// <param name="gamepad">the current state of the gamepad</param>
        /// <param name="soundBank">the sound bank</param>
        public void Update(GameTime gameTime, GamePadState gamepad,
            SoundBank soundBank)
        {
            KeyboardState keyboard = Keyboard.GetState();

            //move the burger with left arrow (or move burger using thumbstick deflection)
            if (health > 0)
            {
                if (keyboard.IsKeyDown(Keys.Left))
                {
                    drawRectangle.X -= 5;
                }
                else if (keyboard.IsKeyDown(Keys.Right))
                {
                    drawRectangle.X += 5;
                }

                if (drawRectangle.X<0)
                {
                    drawRectangle.X = 0;
                }
                if (drawRectangle.X>GameConstants.WINDOW_WIDTH-drawRectangle.Width)
                {
                    drawRectangle.X = GameConstants.WINDOW_WIDTH-drawRectangle.Width;
                }

                // burger should only respond to input if it still has health
                if (keyboard.IsKeyDown(Keys.Space) && canShoot)
                {
                    canShoot = false;
                    frenchFriesSprite = Game1.GetProjectileSprite(ProjectileType.FrenchFries);
                    Projectile burgerProjectile = new Projectile(ProjectileType.FrenchFries, frenchFriesSprite, 
                                                                 drawRectangle.X + drawRectangle.Width / 2, drawRectangle.Y + drawRectangle.Height / 2,
                                                                 -1 * GameConstants.FRENCH_FRIES_PROJECTILE_OFFSET);
                    soundBank.PlayCue("BurgerShot");

                    //add projectile to the list
                    Game1.AddProjectile(burgerProjectile);
                                        
                }
                if (!canShoot)
                {
                    elapsedCooldownTime+= gameTime.ElapsedGameTime.Milliseconds;
                    if (elapsedCooldownTime>=GameConstants.BURGER_COOLDOWN_MILLISECONDS || keyboard.IsKeyUp(Keys.Space))
                    {
                        canShoot = true;
                        elapsedCooldownTime = 0;
                    }
                }
               
            }
            
            // update shooting allowed
           
            // timer concept (for animations) introduced in Chapter 7

            // shoot if appropriate

        }

        /// <summary>
        /// Draws the burger
        /// </summary>
        /// <param name="spriteBatch">the sprite batch to use</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, drawRectangle, Color.White);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Loads the content for the burger
        /// </summary>
        /// <param name="contentManager">the content manager to use</param>
        /// <param name="spriteName">the name of the sprite for the burger</param>
        /// <param name="x">the x location of the center of the burger</param>
        /// <param name="y">the y location of the center of the burger</param>
        private void LoadContent(ContentManager contentManager, string spriteName,
            int x, int y)
        {
            // load content and set remainder of draw rectangle
            sprite = contentManager.Load<Texture2D>(spriteName);
            drawRectangle = new Rectangle(x - sprite.Width / 2,
                y - sprite.Height / 2, sprite.Width,
                sprite.Height);
        }

        #endregion
    }
}
