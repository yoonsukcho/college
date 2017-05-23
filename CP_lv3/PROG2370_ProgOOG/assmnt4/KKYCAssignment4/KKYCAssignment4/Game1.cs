using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// Kevin Kim & Yoonsuk Cho
/// PROG2370 Assignment 4
/// Nov 2016
///
/// This program is the main program of
/// the Ping Pong Game.
/// </summary>


namespace KKYCAssignment4
{

    public enum Sides { LEFT, RIGHT };

    /// <summary>
    /// This is the main class for this game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D boardTexture;
        private Rectangle scorebarRect;

        // collect control keys
        private readonly Keys LEFT_UP = Keys.A;
        private readonly Keys LEFT_DOWN = Keys.Z;
        private readonly Keys RIGHT_UP = Keys.Up;
        private readonly Keys RIGHT_DOWN = Keys.Down;
        private readonly Keys INIT_GAME = Keys.Space;
        private readonly Keys NEW_BALL = Keys.Enter;

        // game components
        private Scoreboard scoreboard;
        private MovingBall ball;
        private MovingBats leftBat;
        private MovingBats rightBat;

        private string winner = "";
        private bool isFinish = false;
        private SoundEffect applauseSound;

        // player names
        private string leftPlayer = "Kevin Kim";
        private string rightPlayer = "Yoonsuk Cho";

        // to check to prevent of bouncing ball inside bat boundary
        public static int intervalCheck = 0;


        /// <summary>
        /// main constructor of class
        /// </summary>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            boardTexture = Content.Load<Texture2D>("images/Scorebar");

            // get scoreboard size & position inforamtion from main form.
            scorebarRect = new Rectangle(0, 
                                         graphics.PreferredBackBufferHeight - boardTexture.Height, 
                                         graphics.PreferredBackBufferWidth, 
                                         graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // load contents of game resource 
            SpriteFont ballGameFont = Content.Load<SpriteFont>("fonts/SpriteFont1");
            Texture2D ballTexture = Content.Load<Texture2D>("images/Ball");
            SoundEffect dingSound = Content.Load<SoundEffect>("sounds/ding");
            SoundEffect clickSound = Content.Load<SoundEffect>("sounds/click");
            applauseSound = Content.Load<SoundEffect>("sounds/applause1");

            // for prevent to overlap scoreboard and bat
            int heightLimit = boardTexture.Height + 1;

            // initialize game components
            leftBat = new MovingBats(this, 
                                     spriteBatch, 
                                     Content.Load<Texture2D>("images/BatLeft"),
                                     Sides.LEFT, 
                                     LEFT_UP, 
                                     LEFT_DOWN, 
                                     heightLimit);
            rightBat = new MovingBats(this, 
                                      spriteBatch, 
                                      Content.Load<Texture2D>("images/BatRight"),
                                      Sides.RIGHT, 
                                      RIGHT_UP, 
                                      RIGHT_DOWN, 
                                      heightLimit);
            scoreboard = new Scoreboard(this, 
                                        spriteBatch, 
                                        boardTexture, 
                                        ballGameFont, 
                                        leftPlayer, 
                                        rightPlayer);
            ball = new MovingBall(this, 
                                  spriteBatch, 
                                  ballTexture, 
                                  heightLimit, 
                                  scoreboard,
                                  dingSound,
                                  clickSound, 
                                  NEW_BALL);

            CollisionManager leftCM = new CollisionManager(this, ball, leftBat, clickSound);
            CollisionManager rightCM = new CollisionManager(this, ball, rightBat, clickSound);

            this.Components.Add(leftBat);
            this.Components.Add(rightBat);
            this.Components.Add(ball);
            this.Components.Add(scoreboard);
            this.Components.Add(leftCM);
            this.Components.Add(rightCM);

            initializeGame();

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here

            // During the game time, one player gets 2 points, 
            // it makes game finished, then show game result message
            if (!isFinish)
            {
                if (scoreboard.LeftPoint == 2 || scoreboard.RightPoint == 2)
                {
                    applauseSound.Play();
                    isFinish = true;
                    if (scoreboard.LeftPoint == 2) winner = leftPlayer;
                    if (scoreboard.RightPoint == 2) winner = rightPlayer;
                    scoreboard.CenterMessage = winner + " wins." + "\nPress Space to restart.";
                }
            }
            else
            {
                // if game finishes, play again with INIT_GAME key
                if (Keyboard.GetState().IsKeyDown(INIT_GAME)) initializeGame();
            }

            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }

        /// <summary>
        /// reset game
        /// </summary>
        public void initializeGame()
        {
            scoreboard.RightPoint = 0;
            scoreboard.LeftPoint = 0;
            scoreboard.CenterMessage = "";
            leftBat.initializeBat();
            rightBat.initializeBat();
            isFinish = false;

        }


    }
}
