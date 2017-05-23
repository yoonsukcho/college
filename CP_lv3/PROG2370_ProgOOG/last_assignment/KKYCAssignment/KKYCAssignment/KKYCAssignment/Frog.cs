using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Threading;

/// <summary>
/// Kevin Kim & Yoonsuk Cho
/// PROG2370 Final Project
/// Dec 2016
///
/// This program is the frog class of
/// the Frogger Game.
/// </summary>


namespace KKYCAssignment
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Frog : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D frogTex;
        private Texture2D frogGoal;
        private Texture2D frogDeath;
        private Texture2D frogSkeleton;
        private ActionScene actionScene;
        private Vector2 position;
        private Vector2 initPosition;
        private Vector2 speed = new Vector2(4, 4);
        private int areaX = 96;
        // this frames is to show frog jumping animation
        private List<Rectangle> frames;
        // this frames is to show frog dead animation
        private List<Rectangle> frames3Cut;
        private SoundEffect jumpSound;
        private SoundEffect deadSound;
        private SoundEffect arrivalSound;
        private SoundEffectInstance jumpSoundInst;
        private SoundEffectInstance stageClearSoundInst;

        private int currentFrame = -1;
        private int[] frameOrder = { 2, 1, 0, 1, 2 };
        private bool isPressed = false;
        private enum DIRECTION { STOP, UP, DOWN, RIGHT, LEFT};
        private float rotation = 0f;
        private int direction;
        private float accuMoveX = 0;
        private float accuMoveY = 0;
        private int LOW_LIMIT = 0;
        private int[] goalInSlot = new int[]{ 0, 0, 0, 0, 0 };
        private bool isAlive = true;
        private double mSec = 0d;
        private int speedChg = 0;

        private readonly int GO_FWD = 10;
        private readonly int FILL_SLOT = 50;
        private readonly int COMP_LEVEL = 5000;

        /// <summary>
        /// main constructor of this class
        /// </summary>
        /// <param name="game">Provides basic graphics device initialization, game logic, and rendering code.</param>
        /// <param name="spriteBatch">Enables a group of sprites to be drawn using the same settings</param>
        /// <param name="frogTex">texture of normal frog image</param>
        /// <param name="frogGoal">texture of frog image which is goaled in</param>
        /// <param name="frogDeath">texture of frog image which is dying</param>
        /// <param name="frogSkeleton">texture of frog image which is dead</param>
        /// <param name="actionScene">the scene which is include in</param>
        /// <param name="jumpSound">jump sound</param>
        /// <param name="deadSound">dead sound</param>
        public Frog(Game game, 
                    SpriteBatch spriteBatch, 
                    Texture2D frogTex, 
                    Texture2D frogGoal, 
                    Texture2D frogDeath,
                    Texture2D frogSkeleton,
                    ActionScene actionScene,
                    SoundEffect jumpSound,
                    SoundEffect deadSound) : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            this.frogTex = frogTex;
            this.frogGoal = frogGoal;
            this.frogDeath = frogDeath;
            this.frogSkeleton = frogSkeleton;
            this.actionScene = actionScene;
            this.jumpSound = jumpSound;
            this.deadSound = deadSound;
            jumpSoundInst = deadSound.CreateInstance();
            this.arrivalSound = game.Content.Load<SoundEffect>("arrivalSound");
            this.stageClearSoundInst = game.Content.Load<SoundEffect>("nextStageSound").CreateInstance();

            LOW_LIMIT = (int)(ActionScene.UNIT * 14.5);
            initPosition = new Vector2(ActionScene.UNIT * 7,
                                       LOW_LIMIT);
            position = initPosition;
            direction = -1;
            currentFrame = -1;
            // frames for jumping animation
            frames = new List<Rectangle>(5);
            int moveDis = 48;
            for (int i = 0; i < 5; i++)
            {
                frames.Add(new Rectangle(areaX, 0, 48, 48));
                if (areaX == 0 || areaX == 96)
                    moveDis *= -1;

                areaX += moveDis; 

            }

            // frames for dying animation
            frames3Cut = new List<Rectangle>(3);
            moveDis = 48;
            for (int i = 0; i < 3; i++)
            {
                frames3Cut.Add(new Rectangle(i * moveDis, 0, 48, 48));
            }

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
        /// check the direction which key is pressed
        /// and set the all image control values
        /// </summary>
        private void CheckDirection()
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Right))
            {
                if (position.Y >= ActionScene.UNIT * 3.5)
                {
                    direction = (int)DIRECTION.RIGHT;
                    currentFrame = 0;
                    isPressed = true;
                    rotation = (float)Math.PI / 2;
                    jumpSound.Play();
                }
            }
            if (ks.IsKeyDown(Keys.Left))
            {
                if (position.Y >= ActionScene.UNIT * 3.5)
                {
                    direction = (int)DIRECTION.LEFT;
                    currentFrame = 0;
                    isPressed = true;
                    rotation = (float)Math.PI / 2 * 3;
                    jumpSound.Play();
                }
            }
            if (ks.IsKeyDown(Keys.Up))
            {
                direction = (int)DIRECTION.UP;
                currentFrame = 0;
                isPressed = true;
                rotation = 0f;
                jumpSound.Play();
            }
            if (ks.IsKeyDown(Keys.Down))
            {
                direction = (int)DIRECTION.DOWN;
                currentFrame = 0;
                isPressed = true;
                rotation = (float)Math.PI;
                jumpSound.Play();
            }
        }

        /// <summary>
        /// check the which slot is already occupied
        /// </summary>
        /// <returns>whether it is occupied</returns>
        private bool IsBlockSlot()
        {
            if (position.X < ActionScene.UNIT * 0.5) return true;
            if (position.X > ActionScene.UNIT * 1.5 && 
                position.X < ActionScene.UNIT * 3.5) return true;
            if (position.X > ActionScene.UNIT * 4.5 && 
                position.X < ActionScene.UNIT * 6.5) return true;
            if (position.X > ActionScene.UNIT * 7.5 && 
                position.X < ActionScene.UNIT * 9.5) return true;
            if (position.X > ActionScene.UNIT * 10.5 && 
                position.X < ActionScene.UNIT * 12.5) return true;
            if (position.X > ActionScene.UNIT * 13.5) return true;
            if (goalInSlot[0] == 1 && 
                (position.X > ActionScene.UNIT * 0.5 && 
                position.X < ActionScene.UNIT * 1.5)) return true;
            if (goalInSlot[1] == 1 && 
                (position.X > ActionScene.UNIT * 3.5 && 
                position.X < ActionScene.UNIT * 4.5)) return true;
            if (goalInSlot[2] == 1 && 
                (position.X > ActionScene.UNIT * 6.5 && 
                position.X < ActionScene.UNIT * 7.5)) return true;
            if (goalInSlot[3] == 1 && 
                (position.X > ActionScene.UNIT * 9.5 && 
                position.X < ActionScene.UNIT * 10.5)) return true;
            if (goalInSlot[4] == 1 && 
                (position.X > ActionScene.UNIT * 12.5 && 
                position.X < ActionScene.UNIT * 13.5)) return true;

            return false;
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (!isAlive)
            {
                this.speedChg = 0;
                return;
            }
            if (!isPressed) CheckDirection();

            if (currentFrame == 0) currentFrame++;
            else if (currentFrame == 4) currentFrame--;

            if (actionScene.GetLeftTime() == 0)
            {
                SetDead();
                return;
            }

            // TODO: Add your update code here
            if (DoesMoveFinish())
            {
                if (direction == (int)DIRECTION.UP)
                {
                    if (ActionScene.CURRENT_SCORE > ActionScene.HIGH_SCORE)
                        ActionScene.HIGH_SCORE = ActionScene.CURRENT_SCORE;
                    if (position.Y > ActionScene.UNIT * 3.5)
                    {
                        ActionScene.CURRENT_SCORE += GO_FWD;
                    }

                }

                currentFrame = -1;
                isPressed = false;
                direction = (int)DIRECTION.STOP;
                accuMoveX = 0;
                accuMoveY = 0;
            }


            if (GetBounds().X < 8 || GetBounds().X > (int)Shared.stage.X)
            {
                SetDead();
            }

            position.X += speedChg;

            if (direction == (int)DIRECTION.UP)
            {
                position.Y -= speed.Y;
                accuMoveY += speed.Y;
                if (IsBlockSlot())
                {
                    if (position.Y < ActionScene.UNIT * 3.5)
                    {
                        position.Y = (int)(ActionScene.UNIT * 3.5);
                    }
                }
                else
                {
                    if (position.Y < ActionScene.UNIT * 2.5)
                    {
                        position.Y = (int)(ActionScene.UNIT * 2.5);
                    }

                }
            }

            if (direction == (int)DIRECTION.DOWN)
            {
                position.Y += speed.Y;
                accuMoveY += speed.Y;
                if (position.Y > LOW_LIMIT)
                {
                    position.Y = LOW_LIMIT;
                }
            }

            if (direction == (int)DIRECTION.RIGHT)
            {
                if (position.Y >= ActionScene.UNIT * 3.5)
                {
                    position.X += speed.X;
                    accuMoveX += speed.X;
                    if (position.X > Shared.stage.X - ActionScene.UNIT)
                    {
                        position.X = Shared.stage.X - ActionScene.UNIT;
                    }
                }
            }

            if (direction == (int)DIRECTION.LEFT)
            {
                if (position.Y >= ActionScene.UNIT * 3.5)
                {
                    position.X -= speed.X;
                    accuMoveX += speed.X;
                    if (position.X < ActionScene.UNIT)
                    {
                        position.X = ActionScene.UNIT;
                    }
                }
            }

            if (position.Y == ActionScene.UNIT * 2.5)
            {

                if ((position.X > ActionScene.UNIT * 0.5 && 
                    position.X < ActionScene.UNIT * 1.5)) goalInSlot[0] = 1;
                if ((position.X > ActionScene.UNIT * 3.5 && 
                    position.X < ActionScene.UNIT * 4.5)) goalInSlot[1] = 1;
                if ((position.X > ActionScene.UNIT * 6.5 && 
                    position.X < ActionScene.UNIT * 7.5)) goalInSlot[2] = 1;
                if ((position.X > ActionScene.UNIT * 9.5 && 
                    position.X < ActionScene.UNIT * 10.5)) goalInSlot[3] = 1;
                if ((position.X > ActionScene.UNIT * 12.5 && 
                    position.X < ActionScene.UNIT * 13.5)) goalInSlot[4] = 1;

                if (jumpSoundInst.State == SoundState.Playing) jumpSoundInst.Stop();

                arrivalSound.Play();
                this.speedChg = 0;
                position = initPosition;
                ActionScene.CURRENT_SCORE += FILL_SLOT * actionScene.GetLeftTime();

                actionScene.ResetTimeLeft();

            }
            if (ActionScene.CURRENT_SCORE > ActionScene.HIGH_SCORE)
                ActionScene.HIGH_SCORE = ActionScene.CURRENT_SCORE;

            base.Update(gameTime);
        }

        /// <summary>
        /// check the slot states and 
        /// judge this level is completed
        /// </summary>
        /// <returns>is completed this level</returns>
        public bool IsLevelComplete()
        {

            if (goalInSlot[0] == 1 && 
                goalInSlot[1] == 1 && 
                goalInSlot[2] == 1 && 
                goalInSlot[3] == 1 && 
                goalInSlot[4] == 1)
            {

                if (stageClearSoundInst.State == SoundState.Stopped) stageClearSoundInst.Play();

                ActionScene.CURRENT_SCORE += COMP_LEVEL;
                if (ActionScene.CURRENT_SCORE > ActionScene.HIGH_SCORE)
                    ActionScene.HIGH_SCORE = ActionScene.CURRENT_SCORE;
                goalInSlot[0] = 0;
                goalInSlot[1] = 0;
                goalInSlot[2] = 0;
                goalInSlot[3] = 0;
                goalInSlot[4] = 0;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Called when the DrawableGameComponent needs to be drawn. 
        /// Override this method with component-specific drawing code
        /// </summary>
        /// <param name="gameTime">Time passed since the last call to Draw.</param>
        public override void Draw(GameTime gameTime)
        {
            if (ActionScene.FROG_LIVES == 0) return;

            spriteBatch.Begin();
            // when frog is aliving
            if (isAlive)
            {
                if (currentFrame >= 0)
                {
                    spriteBatch.Draw(frogTex,
                                     position,
                                     frames.ElementAt<Rectangle>(currentFrame),
                                     Color.White,
                                     rotation,
                                     new Vector2(frogTex.Width / 6, frogTex.Height / 2),
                                     1f,
                                     SpriteEffects.None,
                                     0);
                }
                else
                {
                    spriteBatch.Draw(frogTex,
                                     position,
                                     frames.ElementAt<Rectangle>(0),
                                     Color.White,
                                     rotation,
                                     new Vector2(frogTex.Width / 6, frogTex.Height / 2),
                                     1f,
                                     SpriteEffects.None,
                                     0);
                }
            }
            // while the frog is dying
            else
            {
                mSec += gameTime.ElapsedGameTime.Milliseconds;
                
                if (mSec <= 200)
                {
                    spriteBatch.Draw(frogDeath,
                                     position,
                                     frames3Cut.ElementAt<Rectangle>(0),
                                     Color.White,
                                     0,
                                     new Vector2(frogDeath.Width / 6, frogDeath.Height / 2),
                                     1f,
                                     SpriteEffects.None,
                                     0);
                }
                if (mSec > 200 && mSec <= 400)
                {
                    spriteBatch.Draw(frogDeath,
                                     position,
                                     frames3Cut.ElementAt<Rectangle>(1), 
                                     Color.White,
                                     0,
                                     new Vector2(frogDeath.Width / 6, frogDeath.Height / 2),
                                     1f,
                                     SpriteEffects.None,
                                     0);
                }
                if (mSec > 400 && mSec <= 600)
                {
                    spriteBatch.Draw(frogDeath,
                                     position,
                                     frames3Cut.ElementAt<Rectangle>(2),
                                     Color.White,
                                     0,
                                     new Vector2(frogDeath.Width / 6, frogDeath.Height / 2),
                                     1f,
                                     SpriteEffects.None,
                                     0);
                }
                if (mSec > 600 && mSec <= 800)
                {
                    spriteBatch.Draw(frogSkeleton,
                                     position,
                                     new Rectangle(0,0, frogSkeleton.Width, frogSkeleton.Height),
                                     Color.White,
                                     0,
                                     new Vector2(frogSkeleton.Width / 2, frogSkeleton.Height / 2),
                                     1f,
                                     SpriteEffects.None,
                                     0);
                }
                if (mSec > 800)
                {
                    ActionScene.FROG_LIVES--;
                    isAlive = true;
                    position = initPosition;
                    mSec = 0;
                    accuMoveX = ActionScene.UNIT;
                    accuMoveY = ActionScene.UNIT;
                }
            }
           
            // when the frog goal in
            if (goalInSlot[0] == 1)
            {
                spriteBatch.Draw(frogGoal, 
                                 new Vector2(ActionScene.UNIT * 0.5f, ActionScene.UNIT * 2), 
                                 Color.White);
            }
            if (goalInSlot[1] == 1)
            {
                spriteBatch.Draw(frogGoal, 
                                 new Vector2(ActionScene.UNIT * 3.5f, ActionScene.UNIT * 2), 
                                 Color.White);
            }
            if (goalInSlot[2] == 1)
            {
                spriteBatch.Draw(frogGoal, 
                                 new Vector2(ActionScene.UNIT * 6.5f, ActionScene.UNIT * 2), 
                                 Color.White);
            }
            if (goalInSlot[3] == 1)
            {
                spriteBatch.Draw(frogGoal, 
                                 new Vector2(ActionScene.UNIT * 9.5f, ActionScene.UNIT * 2), 
                                 Color.White);
            }
            if (goalInSlot[4] == 1)
            {
                spriteBatch.Draw(frogGoal, 
                                 new Vector2(ActionScene.UNIT * 12.5f, ActionScene.UNIT * 2), 
                                 Color.White);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// get the boundary of this image
        /// </summary>
        /// <returns>the boundary of this image</returns>
        public Rectangle GetBounds()
        {
            return new Rectangle((int)position.X + 6, (int)position.Y + 6, 32, 32);
        }
        /// <summary>
        /// set this frog is dead
        /// </summary>
        public void SetDead()
        {
            isAlive = false;
            actionScene.ResetTimeLeft();
            if (jumpSoundInst.State == SoundState.Stopped) jumpSoundInst.Play();
        }

        /// <summary>
        /// when this frog is loaded on the floatings
        /// </summary>
        /// <param name="speedChg">the speed of floatings</param>
        public void SetLoaded(int speedChg)
        {
            this.speedChg = speedChg;
        }

        /// <summary>
        /// when this frog is unloaded from the floatings
        /// </summary>
        /// <param name="speedChg">the speed of floatings</param>
        public void SetUnloaded(int speedChg)
        {
            this.speedChg = 0;
        }

        /// <summary>
        /// get the current y position of this frog
        /// </summary>
        /// <returns>the line this frog is located</returns>
        public int GetCurrentLine()
        {
            return (int)(position.Y / ActionScene.UNIT);
        }

        /// <summary>
        /// check this fros is moving or not
        /// </summary>
        /// <returns>is moving now</returns>
        public bool DoesMoveFinish()
        {
            if (accuMoveX >= ActionScene.UNIT || accuMoveY >= ActionScene.UNIT) return true;
            return false;
        }


    }
}
