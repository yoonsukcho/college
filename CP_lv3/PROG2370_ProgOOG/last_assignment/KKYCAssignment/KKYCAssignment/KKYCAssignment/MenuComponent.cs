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
/// This program is the menu component class of
/// the Frogger Game.
/// </summary>


namespace KKYCAssignment
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class MenuComponent : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private List<string> menuItems;
        private int selectedIndex = 0;
        private Texture2D fontTex;

        /// <summary>
        /// get and set the selected index of menu items
        /// </summary>
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; }
        }
        private Vector2 position;
        private Color regularColor = Color.White;
        private Color hilightColor = Color.Red;
        private KeyboardState oldState; // why? .... later

        /// <summary>
        /// main constructor of this class
        /// </summary>
        /// <param name="game">Provides basic graphics device initialization, game logic, and rendering code.</param>
        /// <param name="spriteBatch">Enables a group of sprites to be drawn using the same settings</param>
        /// <param name="menus">string array of its menus</param>
        public MenuComponent(Game game, SpriteBatch spriteBatch,
            string[] menus)
            : base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            menuItems = new List<string>();
            for (int i = 0; i < menus.Length ; i++)
            {
                menuItems.Add(menus[i]);
            }
            position = new Vector2(Shared.stage.X/2, Shared.stage.Y/2);
            fontTex = game.Content.Load<Texture2D>("letter_ww");

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
            KeyboardState ks = Keyboard.GetState();

            //This will not really work!!
            if (ks.IsKeyDown (Keys.Down) && oldState.IsKeyUp(Keys.Down ))
            {
                selectedIndex++;
                if (selectedIndex == menuItems.Count )
                {
                    selectedIndex = 0;
                }
            }
            if (ks.IsKeyDown(Keys.Up ) && oldState.IsKeyUp(Keys.Up ))
            {
                selectedIndex--;
                if (selectedIndex == -1)
                {
                    selectedIndex = menuItems.Count - 1;
                }
            }
            oldState = ks;

            base.Update(gameTime);
        }

        /// <summary>
        /// Called when the DrawableGameComponent needs to be drawn. 
        /// Override this method with component-specific drawing code
        /// </summary>
        /// <param name="gameTime">Time passed since the last call to Draw.</param>
        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = position;
            spriteBatch.Begin();
            int yPos = 300;
            for (int i = 0; i < menuItems.Count ; i++)
            {
                if (selectedIndex == i)
                {

                    char[] menuItem = menuItems[i].ToCharArray();
                    int xPos = 30;
                    for (int j = 0; j < menuItem.Count(); j++)
                    {
                        Rectangle fontRect = Game1.FONT_FRAMES[menuItem[j]];
                        spriteBatch.Draw(fontTex, new Vector2(xPos + j * 16, yPos), fontRect, hilightColor);
                    }
                }
                else
                {
                    char[] menuItem = menuItems[i].ToCharArray();
                    int xPos = 30;
                    for (int j = 0; j < menuItem.Count(); j++)
                    {
                        Rectangle fontRect = Game1.FONT_FRAMES[menuItem[j]];
                        spriteBatch.Draw(fontTex, new Vector2(xPos + j * 16, yPos), fontRect, regularColor);
                    }
                }
                yPos += 32;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
