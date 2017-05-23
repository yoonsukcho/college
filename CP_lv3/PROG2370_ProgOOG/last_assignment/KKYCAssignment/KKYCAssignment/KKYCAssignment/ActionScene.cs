using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using KKYCAssignment;
using System.Collections;

/// <summary>
/// Kevin Kim & Yoonsuk Cho
/// PROG2370 Final Project
/// Dec 2016
///
/// This program is the main scene of
/// the Frogger Game.
/// </summary>


namespace KKYCAssignment
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class ActionScene : GameScene
    {
        // basic unit size of this game
        public readonly static int UNIT = 32;
        // score variable 
        public static int CURRENT_SCORE = 0;
        public static int HIGH_SCORE = 0;
        // initial frog count
        public static int FROG_LIVES = 3;

        private SpriteBatch spriteBatch;
        private Game game;
        private Frog frog;
        private Cars cars;
        private Scoreboard scoreboard;
        private CollisionManager cms;
        private LoadManager lms;

        private Floatings floatings;
        private Texture2D texBg;
        private int currentLevel = 1;
        private Hashtable GAME_LEVEL = new Hashtable();
        private Random random;
        private int mSec = 0;
        private int chg = 1;
        // check the top target slots
        public static bool[] areLoaded = new bool[5];

        /// <summary>
        /// main constructor of this class
        /// </summary>
        /// <param name="game">Provides basic graphics device initialization, game logic, and rendering code.</param>
        /// <param name="spriteBatch">Enables a group of sprites to be drawn using the same settings</param>

        public ActionScene(Game game, SpriteBatch spriteBatch)
            : base(game)
        {
            // TODO: Construct any child components here
            this.game = game;
            this.spriteBatch = spriteBatch;
            random = new Random();

            GAME_LEVEL.Add(1, new int[10, 2] { { 4, 1 }, { 3, -1 }, 
                                               { 3, 1 }, { 4, -1 }, 
                                               { 3, 1 },
                                               { 1, -1 }, { 1, 1 }, 
                                               { 1, -1 }, { 1, 1 }, 
                                               { 1, -1 } });
            //GAME_LEVEL.Add(1, new int[10, 2] { { 4, 1 }, { 3, -2 },
            //                                   { 3, 1 }, { 4, -1 },
            //                                   { 3, 1 },
            //                                   { 2, -3 }, { 2, 3 },
            //                                   { 2, -2 }, { 2, 2 },
            //                                   { 1, -1 } });
            GAME_LEVEL.Add(2, new int[10, 2] { { 3, 4 }, { 3, -3 }, 
                                               { 2, 2 }, { 3, -3 }, 
                                               { 3, 2 }, 
                                               { 2, -3 }, { 3, 3 }, 
                                               { 2, -3 }, { 3, 4 }, 
                                               { 2, 5 } });
            GAME_LEVEL.Add(3, new int[10, 2] { { 3, 4 }, { 2, -3 }, 
                                               { 2, 3 }, { 2, -4 },
                                               { 2, 4 }, 
                                               { 3, -4 }, { 2, 8 }, 
                                               { 3, -7 }, { 3, 6 }, 
                                               { 3, -3 } });

            Initialize();

        }

        /// <summary>
        /// make level up when it finishs to fill all slots
        /// </summary>
        public void AddLevel()
        {
            currentLevel++;
            RemoveAllComponents(currentLevel);
            Initialize();
            //Console.WriteLine(currentLevel);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            if (currentLevel > GAME_LEVEL.Count) currentLevel = GAME_LEVEL.Count;

            frog = new Frog(game,
                            spriteBatch,
                            game.Content.Load<Texture2D>("frog_grn_v"),
                            game.Content.Load<Texture2D>("frog_goal"),
                            game.Content.Load<Texture2D>("death1"),
                            game.Content.Load<Texture2D>("skeleton"),
                            this,
                            game.Content.Load<SoundEffect>("jumpSound"),
                            game.Content.Load<SoundEffect>("deadSound"));

            for (int i = 0; i < 5; i++)
            {
                int cnt = ((int[,])GAME_LEVEL[currentLevel])[i, 0];
                int speed = ((int[,])GAME_LEVEL[currentLevel])[i, 1];
                ArrayList floatArr = new ArrayList();
                for (int j = 0; j < cnt; j++)
                {
                    float space = random.Next(20, 27) / 10f;
                    floatings = new Floatings(game,
                                              spriteBatch,
                                              game.Content.Load<Texture2D>("logs"), 
                                              i + 3, 
                                              speed,
                                              space / Math.Abs(speed) * j);
                    //Console.WriteLine("floatings : space {0:G}, line {1}", space, i);
                    this.Components.Add(floatings);
                    floatArr.Add(floatings);
                }
                lms = new LoadManager(game, frog, floatArr, null);
                this.Components.Add(lms);
            }

            for (int i = 5; i < 10; i++)
            {
                int cnt = ((int[,])GAME_LEVEL[currentLevel])[i, 0];
                int speed = ((int[,])GAME_LEVEL[currentLevel])[i, 1];
                for (int j = 0; j < cnt; j++)
                {
                    float space = random.Next(12, 18) / 10f;
                    cars = new Cars(game,
                                    spriteBatch,
                                    game.Content.Load<Texture2D>("car" + (i-4)),
                                    i + 4,
                                    speed,
                                    space / Math.Abs(speed) * j);
                    //Console.WriteLine("cars : space {0:G}, line {1}", space, i);

                    this.Components.Add(cars);
                    cms = new CollisionManager(game, frog, cars, null);
                    this.Components.Add(cms);

                }
            }

            texBg = game.Content.Load<Texture2D>("bg");
            this.Components.Add(frog);

            scoreboard = new Scoreboard(game, spriteBatch, game.Content.Load<Texture2D>("letter_ww"));
            this.Components.Add(scoreboard);

            base.Initialize();
        }
        /// <summary>
        /// initialize all components with given level
        /// (finish level or new start)
        /// </summary>
        /// <param name="level">set this game level</param>
        public void RemoveAllComponents(int level)
        {
            List<GameComponent> comps = this.Components.ToList();
            foreach (GameComponent comp in comps)
            {
                this.Components.Remove(comp);
            }
            currentLevel = level;
            ResetTimeLeft();
            if (level == 1)
            {
                CURRENT_SCORE = 0;
                FROG_LIVES = 3;
            }

        }

        /// <summary>
        /// reset the time of each stage
        /// </summary>
        public void ResetTimeLeft()
        {
            scoreboard.ResetTimeLeft();
        }

        /// <summary>
        /// get the left time of this stage
        /// </summary>
        /// <returns></returns>
        public int GetLeftTime()
        {
            return scoreboard.GetLeftTime();
        }

        /// <summary>
        /// initialize all components
        /// (new start)
        /// </summary>
        public void RemoveAllComponents()
        {
            RemoveAllComponents(1);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            if (frog.IsLevelComplete()) AddLevel();

            if (FROG_LIVES == 0)
            {
                List<GameComponent> comps = this.Components.ToList();
                foreach (GameComponent comp in comps)
                {
                    if (comp is Cars)
                    {
                        ((Cars)comp).SetSpeed(0);
                    }
                    if (comp is Floatings)
                    {
                        ((Floatings)comp).SetSpeed(0);
                    }

                }

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Called when the DrawableGameComponent needs to be drawn. 
        /// Override this method with component-specific drawing code
        /// </summary>
        /// <param name="gameTime">Time passed since the last call to Draw.</param>
        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();
            spriteBatch.Draw(texBg, new Rectangle(0, 0, texBg.Width, texBg.Height), Color.White);
            int xPos = 6;
            // show frog live status
            if (FROG_LIVES > 0)
            {
                for (int i = 0; i < FROG_LIVES; i++)
                {
                    spriteBatch.Draw(game.Content.Load<Texture2D>("frogLives"), new Vector2(xPos + i * 16, 480), new Rectangle(0, 0, texBg.Width, texBg.Height), Color.White);
                }

            }
            else
            {
                // when no more frog live, show 'GAME OVER'
                // with time interval
                if (mSec < 35)
                {
                    char[] notice = "GAME OVER".ToCharArray();
                    xPos = (int)Shared.stage.X / 2 - 8 * notice.Count();
                    int i = 0;
                    while (i < notice.Count())
                    {
                            Rectangle fontRect = Game1.FONT_FRAMES[notice[i]];
                            spriteBatch.Draw(game.Content.Load<Texture2D>("letter_ww"), new Vector2(xPos + i * 16, 251), fontRect, Color.Yellow);
                            i++;
                    }
                } 
                mSec += chg;

                if (mSec < 1)
                {
                    chg *= -1;
                }
                if (mSec > 50)
                {
                    chg *= -1;
                }
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        //private void 

    }
}