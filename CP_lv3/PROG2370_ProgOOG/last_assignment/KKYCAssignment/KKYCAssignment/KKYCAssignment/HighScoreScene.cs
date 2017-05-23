using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

/// <summary>
/// Kevin Kim & Yoonsuk Cho
/// PROG2370 Final Project
/// Dec 2016
///
/// This program is the scene of high score page of
/// the Frogger Game.
/// </summary>


namespace KKYCAssignment
{
    /// <summary>
    /// This is a game component that inherited GameScene.
    /// </summary>
    public class HighScoreScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Texture2D fontTex;
        private GraphicsDeviceManager graphics;
        private ScoreRecords[] topScores;
        private string FILE_NAME = "highScoreList";
        private int xPos = 0;
        private int yPos = 0;

        /// <summary>
        /// main constructor of this class
        /// </summary>
        /// <param name="game">Provides basic graphics device initialization, game logic, and rendering code.</param>
        /// <param name="spriteBatch">Enables a group of sprites to be drawn using the same settings</param>
        /// <param name="graphics">to set basic graphic </param>
        public HighScoreScene(Game game, SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
            : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            fontTex = game.Content.Load<Texture2D>("letter_ww");
            topScores = Load();
            ActionScene.HIGH_SCORE = topScores[0].Score;
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
        /// try to set new record
        /// if it is higher than last score
        /// the last score is replaced wuth new record, 
        /// and sort the list
        /// </summary>
        /// <param name="score">last score</param>
        /// <returns>whether it is higher than last recorded score</returns>

        public bool SetNewRecord(int score)
        {
            bool isRegistered = false;
            if (topScores[9].Score < score)
            {
                isRegistered = true;
                topScores[9].Score = score;
                topScores[9].Time = DateTime.Now.ToString();
            }

            Array.Sort(topScores);
            Save(topScores);
            return isRegistered;
        }
        /// <summary>
        /// save the score infofrmation to the file
        /// </summary>
        /// <param name="scores"> top ten score list</param>
        private void Save(ScoreRecords[] scores)
        {
            try
            {
                StreamWriter sw = new StreamWriter(FILE_NAME);
                foreach (ScoreRecords score in scores)
                {
                    sw.WriteLine(score.Score + "-" + score.Time);
                }
                sw.Close();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// load the score information from the file
        /// </summary>
        /// <returns>top ten score list</returns>
        private ScoreRecords[] Load()
        {
            topScores = new ScoreRecords[10];
            try
            {
                StreamReader sr = new StreamReader(FILE_NAME);
                int i = 0;
                while (!sr.EndOfStream)
                {
                    string strLine = sr.ReadLine();
                    topScores[i] = new ScoreRecords();
                    topScores[i].Score = Int32.Parse(strLine.Split('-')[0]);
                    topScores[i].Time = strLine.Split('-')[1];
                    i++;
                }
                sr.Close();
            }
            catch (Exception)
            {
                for (int i = 0; i < topScores.Length; i++)
                {
                    topScores[i] = new ScoreRecords();
                    topScores[i].Score = 0;
                }
            }

            return topScores;
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        /// <summary>
        /// Called when the DrawableGameComponent needs to be drawn. 
        /// Override this method with component-specific drawing code
        /// </summary>
        /// <param name="gameTime">Time passed since the last call to Draw.</param>
        public override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            char[] titleArr = "HIGH SCORE LIST".ToString().ToCharArray();
            xPos = (int)Shared.stage.X / 2 - 120;
            for (int j = 0; j < titleArr.Count(); j++)
            {
                Rectangle fontRect = Game1.FONT_FRAMES[titleArr[j]];
                spriteBatch.Draw(fontTex, new Vector2(xPos + j * 16, 35), fontRect, Color.Red);
            }

            yPos = 85;

            for (int i = 0; i < topScores.Length; i++)
            {

                string scoreStr = ((i == 9) ? (i + 1).ToString() : ("0" + (i + 1))) + " - " + SetLeftPad(topScores[i].ToString(), 27);
                char[] topScoresArr = scoreStr.ToCharArray();
                xPos = 30;
                for (int j = 0; j < topScoresArr.Count(); j++)
                {
                    Rectangle fontRect = Game1.FONT_FRAMES[topScoresArr[j]];
                    spriteBatch.Draw(fontTex, new Vector2(xPos + j * 11, yPos), fontRect, Color.Yellow, 0f, new Vector2(0,0), 0.7f, SpriteEffects.None, 0f);
                }
                yPos += 25;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// adjust the right alignment
        /// </summary>
        /// <param name="str">target strings</param>
        /// <param name="digits">the right padding size</param>
        /// <returns></returns>
        private string SetLeftPad(string str, int digits)
        {
            if (str.Length < digits)
            {
                int cnt = digits - str.Length;
                for (int i = 0; i < cnt; i++)
                {
                    str = " " + str;
                }
            }
            return str;
        }

    }

    /// <summary>
    /// this class is the unit of score information
    /// implemented sorting function of array
    /// </summary>
    class ScoreRecords : IComparable
    {

        private string time;
        private int score;
        public int Score
        {
            get
            {
                return score;
            }

            set
            {
                score = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }
        /// <summary>
        /// to implement the Array.sort method
        /// </summary>
        /// <param name="obj">compare object</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (this.score > ((ScoreRecords)obj).Score) return -1;
            else if (this.score < ((ScoreRecords)obj).Score) return 1;
            return 0;
        }
        /// <summary>
        /// overriding toString function
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return score.ToString() + " " + time;
        }

    }



}
