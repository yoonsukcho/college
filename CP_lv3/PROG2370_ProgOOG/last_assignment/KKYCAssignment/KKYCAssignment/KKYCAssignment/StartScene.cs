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

/// <summary>
/// Kevin Kim & Yoonsuk Cho
/// PROG2370 Final Project
/// Dec 2016
///
/// This program is the start scene of
/// the Frogger Game.
/// </summary>


namespace KKYCAssignment
{
    /// <summary>
    /// This is a game component that inherited GameScene class.
    /// </summary>
    public class StartScene : GameScene 
    {
        private MenuComponent menu;
        private Game game;

        public MenuComponent Menu
        {
            get { return menu; }
            set { menu = value; }
        }

        private SpriteBatch spriteBatch;
        string[] menuItems = {"START GAME",
                             "HELP",
                             "HOW TO PLAY",
                             "HIGH SCORE",
                             "ABOUT",
                             "QUIT"};


        /// <summary>
        /// main constructor of this class
        /// </summary>
        /// <param name="game">Provides basic graphics device initialization, game logic, and rendering code.</param>
        /// <param name="spriteBatch">Enables a group of sprites to be drawn using the same settings</param>
        public StartScene(Game game, SpriteBatch spriteBatch)
            : base(game)
        {
            // TODO: Construct any child components here
            this.game = game;
            this.spriteBatch = spriteBatch;
            menu = new MenuComponent(game, spriteBatch, menuItems);
            this.Components.Add(menu);
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
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(game.Content.Load<Texture2D>("startSceneImg"), new Vector2(0, 0), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
