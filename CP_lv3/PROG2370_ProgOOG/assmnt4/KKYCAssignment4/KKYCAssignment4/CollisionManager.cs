using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

/// <summary>
/// Kevin Kim & Yoonsuk Cho
/// PROG2370 Assignment 4
/// Nov 2016
/// 
/// This program is the collision manager of 
/// the Ping Pong Game.
/// </summary>
/// 
namespace KKYCAssignment4
{
    class CollisionManager : GameComponent
    {

        private MovingBall myBall;   // the object will occur collision 
        private MovingBats myBat;    // the object will occur collision 
        private SoundEffect click;   // click sound object
        private Game game;

        /// <summary>
        /// main constructor of CollisionManager class
        /// </summary>
        /// <param name="game">game frame</param>
        /// <param name="myBall">ball object</param>
        /// <param name="myBat">bat object</param>
        /// <param name="click">sound object when it collides</param>
        public CollisionManager(Game game, 
                                MovingBall myBall, 
                                MovingBats myBat, 
                                SoundEffect click) : base(game)
        {
            // initialize all member variables
            this.game = game;
            this.myBall = myBall;
            this.myBat = myBat;
            this.click = click;
        }

        public override void Initialize()
        {
            base.Initialize();
        }
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // get bounds of objects which will collide
            Rectangle BallRect = myBall.getBound();
            Rectangle BatRect = myBat.getBound();

            // add interval time to last intersect occurance
            // if last intersect occured less than .5 sec ago, 
            // intersect method won't be called
            // to prevent of bouncing ball inside bat boundary
            Game1.intervalCheck += gameTime.ElapsedGameTime.Milliseconds;

            if (BatRect.Intersects(BallRect) && Game1.intervalCheck > 500)
            {
                // make sounds and change the ball direction (because the ball and tha bat collided)
                Game1.intervalCheck = 0;
                click.Play();
                myBall.BallSpeedX *= -1;
            }

            base.Update(gameTime);
        }
    }
}
