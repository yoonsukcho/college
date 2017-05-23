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
/// This program is the supper class of all scenes in 
/// this Frogger Game.
/// </summary>

namespace KKYCAssignment
{
    /// <summary>
    /// This is a game component that inherited DrawableGameComponent.
    /// </summary>
    public abstract  class GameScene : DrawableGameComponent
    {
        private List<GameComponent> components;

        /// <summary>
        /// make and return the list include all components in this components
        /// </summary>
        public List<GameComponent> Components
        {
            get { return components; }
            set { components = value; }
        }

        /// <summary>
        /// set show this scene
        /// </summary>
        public virtual void show()
        {
            this.Enabled = true;
            this.Visible = true;
        }

        /// <summary>
        /// set hide this scene
        /// </summary>
        public virtual void hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }
        /// <summary>
        /// constructor of this class
        /// </summary>
        /// <param name="game">Provides basic graphics device initialization, game logic, and rendering code.</param>
        public GameScene(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            components = new List<GameComponent>();
            hide();
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
            foreach (GameComponent  item in components )
            {
                if (item.Enabled )
                {
                    item.Update(gameTime );
                }
            }

            base.Update(gameTime);
        }
        /// <summary>
        /// Allows the game component to draw.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            
            DrawableGameComponent comp = null;
            foreach (GameComponent  item in components )
            {
                if (item is DrawableGameComponent )
                {
                    comp = (DrawableGameComponent)item;
                    if (comp.Visible )
                    {
                        comp.Draw(gameTime);
                    }
                }
                
            }

            base.Draw(gameTime);
        }
    }
}
