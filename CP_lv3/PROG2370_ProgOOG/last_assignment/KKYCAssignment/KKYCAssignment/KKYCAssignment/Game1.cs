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
/// This program is the main program of
/// the Frogger Game.
/// </summary>

namespace KKYCAssignment
{
    /// <summary>
    /// This is the main type of this game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private StartScene startScene;
        private HelpScene helpScene;
        private ActionScene actionScene;
        private HowToScene howToScene;
        private HighScoreScene highScoreScene;
        private AboutScene aboutScene;
        private int STAGE_WIDTH = 448;
        private int STAGE_HEIGHT = 512;
        public static readonly int TIME_LEFT = 40000;
        public static Dictionary<char, Rectangle> FONT_FRAMES;

        private SoundEffectInstance startSound;
        private SoundEffectInstance actionSound;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";
            Content = new ResourceContentManager(this.Services, MyResources.ResourceManager);
            graphics.PreferredBackBufferWidth = STAGE_WIDTH;
            graphics.PreferredBackBufferHeight = STAGE_HEIGHT;

            int x = 0;
            int y = 0;

            // this is for our bit map font 
            char[] charArr = { '0', '1', '2', '3', '4',
                               '5', '6', '7', '8', '9',
                               'A', 'B', 'C', 'D', 'E',
                               'F', 'G', 'H', 'I', 'J',
                               'K', 'L', 'M', 'N', 'O',
                               'P', 'Q', 'R', 'S', 'T',
                               'U', 'V', 'W', 'X', 'Y',
                               'Z', '-', ' ', '©', '□',
                               ':', '/', '@', '#', '*',
                               '!', '$', '^', '(', ')' };

            FONT_FRAMES = new Dictionary<char, Rectangle>(50);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    FONT_FRAMES.Add(charArr[i * 10 + j], new Rectangle(x, y, ActionScene.UNIT, ActionScene.UNIT));
                    x += ActionScene.UNIT;
                }
                x = 0;
                y += ActionScene.UNIT;
            }

            //graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        /// <summary>
        /// hide all scenes of game
        /// </summary>
        private void hideAllScenes()
        {
            GameScene gs = null;
            foreach (GameComponent  item in Components )
            {

                if (item is GameScene )
                {
                    gs = (GameScene)item;
                    gs.hide();
                }
            }
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            startScene = new StartScene(this, spriteBatch);
            Components.Add(startScene);

            helpScene = new HelpScene(this, spriteBatch, graphics);
            Components.Add(helpScene);

            howToScene = new HowToScene(this, spriteBatch);
            Components.Add(howToScene);

            actionScene = new ActionScene(this, spriteBatch);
            Components.Add(actionScene);

            highScoreScene = new HighScoreScene(this, spriteBatch, graphics);
            Components.Add(highScoreScene);

            aboutScene = new AboutScene(this, spriteBatch);
            Components.Add(aboutScene);

            this.startSound = this.Content.Load<SoundEffect>("startSceneSound3").CreateInstance();
            this.actionSound = this.Content.Load<SoundEffect>("startOrActionSound").CreateInstance();

            startScene.show();
        }

        public bool SetHighScore(int score)
        {
            return highScoreScene.SetNewRecord(score);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            int selectedIndex = 0;
            KeyboardState ks = Keyboard.GetState();

            if (startScene.Enabled )
            {
                selectedIndex = startScene.Menu.SelectedIndex;
                actionSound.Stop();
                startSound.Play();
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    startSound.Stop();
                    actionSound.Play();
                    hideAllScenes();
                    actionScene.show();
                }
                if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    helpScene.show();
                }
                if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    howToScene.show();
                }
                if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    highScoreScene.show();
                }
                if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter))
                {
                    hideAllScenes();
                    aboutScene.show();
                }
                if (selectedIndex == 5 && ks.IsKeyDown(Keys.Enter))
                {
                    this.Exit();
                }

            }

            else if (actionScene.Enabled)
            {


                if (ks.IsKeyDown(Keys.Escape))
                {
                    bool isNew = SetHighScore(ActionScene.CURRENT_SCORE);

                    hideAllScenes();
                    startScene.show();
                    actionScene.RemoveAllComponents(1);
                    actionScene.Initialize();
                }
            }

            else if (helpScene.Enabled || howToScene.Enabled ||
                     highScoreScene.Enabled || aboutScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    hideAllScenes();
                    startScene.show();
                    actionScene.RemoveAllComponents(1);
                    actionScene.Initialize();
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
