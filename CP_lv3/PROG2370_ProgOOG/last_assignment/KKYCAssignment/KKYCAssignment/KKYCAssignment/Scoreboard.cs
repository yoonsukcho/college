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
/// This program is the main program of
/// the Frogger Game.
/// </summary>

namespace KKYCAssignment
{
    public class Scoreboard : DrawableGameComponent
    {

        private Texture2D fontTex;
        private SpriteBatch spriteBatch;
        private int timeLeft = Game1.TIME_LEFT;

        public Scoreboard(Game game, SpriteBatch spriteBatch, Texture2D fontTex) : base(game)
        {
            this.fontTex = fontTex;
            this.spriteBatch = spriteBatch;
            Initialize();
        }


        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            char[] yourScore = "YOUR SCORE".ToCharArray();
            int xPos = 30;
            for (int i = 0; i < yourScore.Count(); i++)
            {
                Rectangle fontRect = Game1.FONT_FRAMES[yourScore[i]];

                spriteBatch.Draw(fontTex, new Vector2(xPos + i * 16, -5), fontRect, Color.White);
            }
            char[] yourScoreNum = ActionScene.CURRENT_SCORE.ToString().ToCharArray();
            xPos = 30 + (yourScore.Count() - yourScoreNum.Count()) * 16;
            for (int i = 0; i < yourScoreNum.Count(); i++)
            {
                Rectangle fontRect = Game1.FONT_FRAMES[yourScoreNum[i]];
                spriteBatch.Draw(fontTex, new Vector2(xPos + i * 16, 15), fontRect, Color.Red);
            }
            char[] highScore = "HIGH SCORE".ToCharArray();
            xPos = (int)Shared.stage.X - ((highScore.Count() + 1) * 16);
            for (int i = 0; i < highScore.Count(); i++)
            {
                Rectangle fontRect = Game1.FONT_FRAMES[highScore[i]];

                spriteBatch.Draw(fontTex, new Vector2(xPos + i * 16, -5), fontRect, Color.White);
            }
            char[] highScoreNum = SetLeftPad(ActionScene.HIGH_SCORE.ToString(), 6).ToCharArray();
            xPos = (int)Shared.stage.X - ((highScoreNum.Count() + 2) * 16);
            for (int i = 0; i < highScoreNum.Count(); i++)
            {
                Rectangle fontRect = Game1.FONT_FRAMES[highScoreNum[i]];
                spriteBatch.Draw(fontTex, new Vector2(xPos + i * 16, 15), fontRect, Color.Red);
            }


            if (ActionScene.FROG_LIVES > 0)
            {
                timeLeft -= gameTime.ElapsedGameTime.Milliseconds;
                char[] timeLeftArr = GetLeftTime().ToString().ToCharArray();
                xPos = (int)Shared.stage.X - 110;
                for (int i = 0; i < timeLeftArr.Count(); i++)
                {
                    Rectangle fontRect = Game1.FONT_FRAMES[timeLeftArr[i]];
                    spriteBatch.Draw(fontTex, new Vector2(xPos + i * 16, 486), fontRect, Color.Yellow);
                }

            }

            spriteBatch.End();
        }

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

        public int GetLeftTime()
        {
            return (int)(timeLeft / 1000);
        }

        public void ResetTimeLeft()
        {
            this.timeLeft = Game1.TIME_LEFT; 
        }


    }



}