using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Kevin Kim & Yoonsuk Cho
/// PROG2370 Final Project
/// Dec 2016
///
/// This program is the class which is checking the collision with cars and frog 
/// in the Frogger Game.
/// </summary>


namespace KKYCAssignment
{

    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    class CollisionManager : GameComponent
    {

        private Frog myFrog;   // the object will occur collision 
        private Cars myCar;    // the object will occur collision 
        private SoundEffect soundEffect;   // click sound object
        private Game game;


        /// <summary>
        /// main constructor of this class
        /// </summary>
        /// <param name="game">Provides basic graphics device initialization, game logic, and rendering code.</param>
        /// <param name="myFrog">the frog checking the collision</param>
        /// <param name="myCar">the car checking the collision</param>
        /// <param name="soundEffect">the collision sound</param>

        public CollisionManager(Game game,
                                Frog myFrog,
                                Cars myCar,
                                SoundEffect soundEffect) : base(game)
        {
            // initialize all member variables
            this.game = game;
            this.myFrog = myFrog;
            this.myCar = myCar;
            this.soundEffect = soundEffect;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
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
            Rectangle frogRect = myFrog.GetBounds();
            Rectangle carRect = myCar.GetBounds();

            if (frogRect.Intersects(carRect))
            {
                //soundEffect.Play();
                myFrog.SetDead();
            }

            base.Update(gameTime);
        }
    }
}
