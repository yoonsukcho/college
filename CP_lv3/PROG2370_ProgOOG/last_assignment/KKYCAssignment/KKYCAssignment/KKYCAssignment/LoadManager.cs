using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Kevin Kim & Yoonsuk Cho
/// PROG2370 Final Project
/// Dec 2016
///
/// This program is the class which is checking the flog is loading on the floatings 
/// in the Frogger Game.
/// </summary>


namespace KKYCAssignment
{

    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    class LoadManager : GameComponent
    {

        private Frog myFrog;   // the object will occur loading 
        private ArrayList flArr;    // the object will occur loading 
        private SoundEffect soundEffect;   // click sound object
        private Game game;
        private int cnt = 0;
        private bool isLoaded = false;
        private double mSec = 0d;


        /// <summary>
        /// main constructor of this class
        /// </summary>
        /// <param name="game">Provides basic graphics device initialization, game logic, and rendering code.</param>
        /// <param name="myFrog">the frog checking the loading</param>
        /// <param name="flArr">the floatings checking the loading</param>
        /// <param name="soundEffect">the loading sound</param>
        public LoadManager(Game game,
                           Frog myFrog,
                           ArrayList flArr,
                           SoundEffect soundEffect) : base(game)
        {
            // initialize all member variables
            this.game = game;
            this.myFrog = myFrog;
            this.flArr = flArr;
            this.cnt = flArr.Count;
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

            // check the status of loading
            // if it is loading on any floating in the same line
            // the frog is alive

            if (myFrog.GetCurrentLine() < 3 || myFrog.GetCurrentLine() > 7) return;
            if (myFrog.GetCurrentLine() != ((Floatings)flArr[0]).GetLine()) return;
            if (!myFrog.DoesMoveFinish()) return;
            isLoaded = false;

            // get bounds of objects which will collide
            Rectangle frogRect = myFrog.GetBounds();
            for (int i = 0; i < cnt; i++)
            {
                Rectangle floatingRect = ((Floatings)flArr[i]).GetBounds();

                mSec += gameTime.ElapsedGameTime.Milliseconds;

                if (frogRect.Intersects(floatingRect))
                {
                    //soundEffect.Play();
                    isLoaded = true;
                }
                else
                {
                    if (!isLoaded) isLoaded = false;
                }

            }

            if (!isLoaded)
            {
                myFrog.SetDead();
            }
            else
            {
                myFrog.SetLoaded(((Floatings)flArr[0]).GetSpeed());
            }

            base.Update(gameTime);
        }
    }
}
