using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// Kevin Kim & Yoonsuk Cho
/// PROG2370 Assignment 4
/// Nov 2016
/// 
/// This program is the bat component of 
/// the Ping Pong Game.
/// </summary>
/// 
namespace KKYCAssignment4
{
    /// <summary>
    /// This is the bat class for this game.
    /// </summary>
    public class MovingBats : DrawableGameComponent
    {

        private SpriteBatch spriteBatch;
        private Texture2D batTexture;
        private Sides side;    // left or right side
        private Vector2 batPosition;

        private int maxDown = 0;
        private int batSpeed = 7;

        private Keys upKey;
        private Keys downKey;

        private Game game;
        private int heightLimit = 0;

        /// <summary>
        /// main constructor of class
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="batTexture"></param>
        /// <param name="side">Sides.LEFT bat or Sides.RIGHT bat</param>
        /// <param name="upKey"></param>
        /// <param name="downKey"></param>
        /// <param name="heightLimit"></param>
        public MovingBats(Game game, 
                          SpriteBatch spriteBatch, 
                          Texture2D batTexture, 
                          Sides side, 
                          Keys upKey, 
                          Keys downKey, 
                          int heightLimit) : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.batTexture = batTexture;
            this.side = side;
            this.upKey = upKey;
            this.downKey = downKey;
            this.heightLimit = heightLimit;

            initializeBat();

            // maximum down position of bat component
            maxDown = game.GraphicsDevice.Viewport.Height - batTexture.Height - heightLimit;

        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here

            // control this component using given control keys
            if (Keyboard.GetState().IsKeyDown(upKey))
            {
                if (batPosition.Y > 0) batPosition.Y -= batSpeed;

            }
            if (Keyboard.GetState().IsKeyDown(downKey))
            {
                if (batPosition.Y < maxDown) batPosition.Y += batSpeed;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(batTexture, batPosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// initialize the position of bat 
        /// </summary>
        public void initializeBat()
        {
            if (side == Sides.LEFT) batPosition.X = 0;
            else batPosition.X = game.GraphicsDevice.Viewport.Width - batTexture.Width;
            batPosition.Y = (game.GraphicsDevice.Viewport.Height - heightLimit) / 2 - batTexture.Height / 2;
        }

        /// <summary>
        /// get this components boundary
        /// </summary>
        /// <returns>Rectangle shape of this component</returns>
        public Rectangle getBound()
        {
            return new Rectangle((int)batPosition.X, (int)batPosition.Y, batTexture.Width, batTexture.Height);
        }

    }
}
