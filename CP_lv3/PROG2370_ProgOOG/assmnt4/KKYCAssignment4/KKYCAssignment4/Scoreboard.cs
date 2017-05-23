using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


/// <summary>
/// Kevin Kim & Yoonsuk Cho
/// PROG2370 Assignment 4
/// Nov 2016
/// 
/// This program is the score component of 
/// the Ping Pong Game.
/// </summary>
/// 
namespace KKYCAssignment4
{

    /// <summary>
    /// This is the Scoreboard class for this game.
    /// </summary>
    public class Scoreboard : DrawableGameComponent
    {

        private SpriteBatch spriteBatch;
        private Texture2D boardTexture;
        private Point boardPosition;
        private Point boardSize;
        private SpriteFont boardFont;
        private Viewport viewport;

        // position information of each message
        private Vector2 leftPosition;
        private Vector2 rightPosition;
        private Vector2 centerPosition;

        // contents of each message
        private string leftPlayer;
        private int leftPoint = 0;
        private string rightPlayer;
        private int rightPoint = 0;
        private string centerMessage;

        private readonly int STR_MARGIN = 3;

        /// <summary>
        /// main constructor of class
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="boardTexture"></param>
        /// <param name="boardFont"></param>
        /// <param name="leftPlayer">leftPlayer name</param>
        /// <param name="rightPlayer">rightPlayer name</param>
        public Scoreboard(Game game,
                          SpriteBatch spriteBatch,
                          Texture2D boardTexture,
                          SpriteFont boardFont,
                          string leftPlayer, 
                          string rightPlayer) : base(game)
        {
            this.viewport = game.GraphicsDevice.Viewport;
            this.spriteBatch = spriteBatch;
            this.boardTexture = boardTexture;
            this.boardFont = boardFont;
            this.leftPlayer = leftPlayer;
            this.rightPlayer = rightPlayer;

            boardPosition.X = 0;
            boardPosition.Y = viewport.Height - boardTexture.Height;

            boardSize = new Point(boardTexture.Width, boardTexture.Height);

            centerMessage = "";
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here
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
            spriteBatch.Draw(boardTexture, new Rectangle(boardPosition, boardSize), Color.White);
            spriteBatch.DrawString(boardFont, leftPlayer + ": " + leftPoint, leftPosition, Color.Black);
            spriteBatch.DrawString(boardFont, rightPlayer + ": " + rightPoint, rightPosition, Color.Black);
            spriteBatch.DrawString(boardFont, CenterMessage, centerPosition, Color.Blue);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        /// <summary>
        /// to control property of left player's point
        /// </summary>
        public int LeftPoint
        {
            get
            {
                return leftPoint;
            }

            set
            {
                leftPoint = value;
                Vector2 sizeStr = boardFont.MeasureString(leftPlayer + ": " + leftPoint);
                leftPosition.X = 0;
                leftPosition.Y = viewport.Height - boardTexture.Height / 2 - sizeStr.Y / 2 - STR_MARGIN;
            }
        }
        /// <summary>
        /// to control property of right player's point
        /// </summary>
        public int RightPoint
        {
            get
            {
                return rightPoint;
            }

            set
            {
                rightPoint = value;
                Vector2 sizeStr = boardFont.MeasureString(rightPlayer + ": " + rightPoint);
                rightPosition.X = viewport.Width - sizeStr.X;
                rightPosition.Y = viewport.Height - boardTexture.Height / 2 - sizeStr.Y / 2 - STR_MARGIN;
            }
        }
        /// <summary>
        /// to control property of center message
        /// </summary>
        public string CenterMessage
        {
            get
            {
                return centerMessage;
            }

            set
            {
                centerMessage = value;
                Vector2 sizeStr = boardFont.MeasureString(centerMessage);
                centerPosition.X = viewport.Width / 2 - sizeStr.X / 2;
                centerPosition.Y = viewport.Height - boardTexture.Height / 2 - sizeStr.Y / 2 - STR_MARGIN;
            }
        }

        
    }
}
