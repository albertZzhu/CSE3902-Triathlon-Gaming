using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class Player

        //forwardsSprite
        //sideSprite
    {
        private ISprite sprite = new Sprite();
        private Vector2 location = new Vector2(400, 200);
        public Player()
        {
            //how in the world does the sprite factory interact with this?
        }

        public void SetSprite(ISprite spr)
        {
            sprite = spr;
        }

        public ISprite GetSprite()
        {
            return sprite;
        }

        public void Update(GameTime gameTime)
        {
            
            sprite.Update();
        }

        //maybe get location here???
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

    }
}
