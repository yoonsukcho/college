using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

/// <summary>
/// Kevin Kim & Yoonsuk Cho
/// PROG2370 Assignment 4
/// Nov 2016
/// 
/// This program is the ball component of 
/// the Ping Pong Game.
/// </summary>
/// 
namespace KKYCAssignment4
{
    /// <summary>
    /// This is the ball class for this game.
    /// </summary>
    public class MovingBall : DrawableGameComponent
    {

        private SpriteBatch spriteBatch;
        private Texture2D ballTexture;
        private Vector2 ballPosition;
        private Point ballSize;
        private SoundEffect ding;
        private SoundEffect click;
        private bool isMoving = false;
        private bool isPressing = false;
        private int ballSpeedX = 0;
        private int ballSpeedY = 0;
        private Scoreboard scoreboard;
        private Keys NEW_BALL;
        private int WINNING_POINT = 2;

        // to set maximun position of ball component
        private int rightEnd = 0;
        private int bottomEnd = 0;

        /// <summary>
        /// main constructor of class
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="ballTexture"></param>
        /// <param name="heightLimit">margin to prevent overlap ball and scoreboard</param>
        /// <param name="scoreboard"></param>
        /// <param name="ding"></param>
        /// <param name="click"></param>
        public MovingBall(Game game,
                          SpriteBatch spriteBatch,
                          Texture2D ballTexture,
                          int heightLimit,
                          Scoreboard scoreboard,
                          SoundEffect ding,
                          SoundEffect click,
                          Keys newBall) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.ballTexture = ballTexture;
            this.scoreboard = scoreboard;
            this.ding = ding;
            this.click = click;
            this.NEW_BALL = newBall;

            rightEnd = game.GraphicsDevice.Viewport.Width;
            bottomEnd = game.GraphicsDevice.Viewport.Height - heightLimit;
            ballSize = new Point(ballTexture.Width, ballTexture.Height);

            initializeBall();
        }


        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            // if game finishes, nothing changes 
            if (scoreboard.LeftPoint == WINNING_POINT || scoreboard.RightPoint == WINNING_POINT) return;

            if (Keyboard.GetState().IsKeyDown(NEW_BALL) && !isPressing && !isMoving)
            {
                isMoving = true;
                isPressing = true;
                // when game starts, initialize ball direction and angle randomly (slope 0.5~1.5)
                Random rndDeg = new Random();
                // ball speed is various from 3 to 9
                ballSpeedX = rndDeg.Next(3, 10);
                ballSpeedY = rndDeg.Next(3, 10);

            }

            // for prevent to press dup keys
            if (Keyboard.GetState().IsKeyUp(NEW_BALL)) isPressing = false;

            if (isMoving)
            {
                ballPosition.X += ballSpeedX;
                ballPosition.Y += ballSpeedY;

                // when ball is out
                if (ballPosition.X < ballTexture.Width * -1)
                {
                    ding.Play();
                    scoreboard.RightPoint++;
                    isMoving = false;
                    initializeBall();
                }
                if (ballPosition.X > rightEnd)
                {
                    ding.Play();
                    scoreboard.LeftPoint++;
                    isMoving = false;
                    initializeBall();
                }

                // to make ball bounce on top and bottom
                if (ballPosition.Y < 0)
                {
                    click.Play();
                    ballPosition.Y = 0;
                    ballSpeedY *= -1; 
                }
                if (ballPosition.Y > bottomEnd - ballTexture.Height)
                {
                    click.Play();
                    ballPosition.Y = bottomEnd - ballTexture.Height;
                    ballSpeedY *= -1;
                }


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
            spriteBatch.Draw(ballTexture, ballPosition, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// initialize ball position and playing time of this ball
        /// </summary>
        public void initializeBall()
        {
            // move the ball at the center of game board
            ballPosition.X = rightEnd / 2 - ballTexture.Width / 2;
            ballPosition.Y = bottomEnd / 2 - ballTexture.Height / 2;

            // initialize this ball's game time
            Game1.intervalCheck = 0;
        }
        /// <summary>
        /// get this components adjusted boundary
        /// </summary>
        /// <returns>Rectangle shape of this component</returns>
        public Rectangle getBound()
        {
            // make 1 pixel smaller the boundary of ball
            return new Rectangle((int)ballPosition.X + 1, (int)ballPosition.Y + 1, ballSize.X - 2, ballSize.Y - 2);
        }
        /// <summary>
        /// to control property of the speed(direction) of ball movement
        /// </summary>
        public int BallSpeedX
        {
            get
            {
                return ballSpeedX;
            }

            set
            {
                ballSpeedX = value;
            }
        }

    }
}
