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
/// This program is the floating class of
/// the Frogger Game.
/// </summary>


namespace KKYCAssignment
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>

    class Floatings : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D floatingTex;
        private Vector2 position;
        private int line;
        private int speed;
        private float space;
        private double mSec = 0d;

        /// <summary>
        /// main constructor of this class
        /// </summary>
        /// <param name="game">Provides basic graphics device initialization, game logic, and rendering code.</param>
        /// <param name="spriteBatch">Enables a group of sprites to be drawn using the same settings</param>
        /// <param name="floatingTex">texture of floatings image</param>
        /// <param name="line">the line which is this floatings located</param>
        /// <param name="speed">the speed of this floatings</param>
        /// <param name="space">the space between floatings</param>
        public Floatings(Game game, 
                         SpriteBatch spriteBatch, 
                         Texture2D floatingTex, 
                         int line, 
                         int speed, 
                         float space) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.floatingTex = floatingTex;
            this.line = line;
            this.speed = speed;
            this.space = space;

            if (speed > 0)
            {
                position.X = -floatingTex.Width;
            }
            else
            {
                position.X = (int)Shared.stage.X + floatingTex.Width;
            }
            position.Y = ActionScene.UNIT * line;
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
            if (position.X > (int)Shared.stage.X + floatingTex.Width)
                position.X = floatingTex.Width * -1;
            if (position.X < (floatingTex.Width * -1))
                position.X = (int)Shared.stage.X + floatingTex.Width;

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
            spriteBatch.Draw(floatingTex, position, new Rectangle(0, 0, floatingTex.Width, floatingTex.Height), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// get the boundary of this image
        /// </summary>
        /// <returns>the boundary of this image</returns>
        public Rectangle GetBounds()
        {
            return new Rectangle((int)position.X + 32, (int)position.Y, floatingTex.Width - 16, floatingTex.Height);
        }
        /// <summary>
        /// get its speed
        /// </summary>
        /// <returns>its speed</returns>
        public int GetSpeed()
        {
            return speed;
        }

        /// <summary>
        /// set its speed
        /// </summary>
        /// <param name="speed">the speed of this floating</param>
        public void SetSpeed(int speed)
        {
            this.speed = 0; ;
        }

        /// <summary>
        /// get this floatings y position
        /// </summary>
        /// <returns>the line where this floating is located</returns>
        public int GetLine()
        {
            return line;
        }


    }
}
