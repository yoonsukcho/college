using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KKYCAssignment
{
    public class Obstacles : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;

        public Obstacles(Game game, SpriteBatch spriteBatch, Texture2D tex) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
        }

        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();
            //spriteBatch
            spriteBatch.End();
            base.Draw(gameTime);
        }



    }
}
