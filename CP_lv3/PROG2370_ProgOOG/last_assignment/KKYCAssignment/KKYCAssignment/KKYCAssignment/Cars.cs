using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Kevin Kim & Yoonsuk Cho
/// PROG2370 Final Project
/// Dec 2016
///
/// This program is the car class of
/// the Frogger Game.
/// </summary>


namespace KKYCAssignment
{

    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Cars : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D catTex;
        private Vector2 position;
        private int line;
        private int speed;
        private float space;
        private float rotation;
        private double mSec = 0d;

        /// <summary>
        /// main constructor of this class
        /// </summary>
        /// <param name="game">Provides basic graphics device initialization, game logic, and rendering code.</param>
        /// <param name="spriteBatch">Enables a group of sprites to be drawn using the same settings</param>
        /// <param name="catTex">texture of various car image</param>
        /// <param name="line">the line which is this car located</param>
        /// <param name="speed">the speed of this car</param>
        /// <param name="space">the space between cars</param>
        public Cars(Game game,  
                    SpriteBatch spriteBatch,
                    Texture2D catTex, 
                    int line, 
                    int speed, 
                    float space) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.catTex = catTex;
            this.line = line;
            this.space = space;
            this.speed = speed;
            if (speed > 0)
            {
                this.rotation = 0;
                position.X = -catTex.Width;
            }
            else
            {
                this.rotation = (float)Math.PI;
                position.X = (int)Shared.stage.X + catTex.Width;
            }
            position.Y = ActionScene.UNIT * (line + 0.5f);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            mSec += gameTime.ElapsedGameTime.Milliseconds;
            if (mSec < 1000 * space) return;

            position.X += speed;
            if (position.X > (int)Shared.stage.X + catTex.Width)
                position.X = catTex.Width * -1;
            if (position.X < (catTex.Width * -1))
                position.X = (int)Shared.stage.X + catTex.Width;
            base.Update(gameTime);
        }

        /// <summary>
        /// Called when the DrawableGameComponent needs to be drawn. 
        /// Override this method with component-specific drawing code
        /// </summary>
        /// <param name="gameTime">Time passed since the last call to Draw.</param>
        public override void Draw(GameTime gameTime)
        {
            if (mSec < 1000 * space) return;

            spriteBatch.Begin();
            spriteBatch.Draw(catTex, position, 
                             new Rectangle(0, 0, catTex.Width, catTex.Height), 
                             Color.White, 
                             rotation, 
                             new Vector2(24, 24), 
                             1f, 
                             SpriteEffects.None, 
                             0);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// set this speed
        /// </summary>
        /// <param name="speed">its speed</param>
        public void SetSpeed(int speed)
        {
            this.speed = 0; ;
        }

        /// <summary>
        /// get the boundary of this image
        /// </summary>
        /// <returns>the boundary of this image</returns>
        public Rectangle GetBounds()
        {
            return new Rectangle((int)position.X + 12, (int)position.Y + 12, catTex.Width - 24, 24);
        }

    }
}
