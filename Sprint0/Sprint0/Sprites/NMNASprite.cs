using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class NMNASprite : ISprite
    {   
        private Texture2D sprite;
        private bool visible = false;

        //is it ok to set the texture in the constructor?
        public NMNASprite()
        {

        }

        //not in interface
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (IsVisible())
                spriteBatch.Draw(sprite, new Vector2(400, 200), Color.White);
        }

        public void Update()
        {
            //no update necessary as it is not moving nor animating
        }

        public bool IsVisible()
        {
            return visible;
        }

        public bool SetVisible(bool value)
        {
            visible = value;
            return true;
        }

        //not in interface...
        public bool SetSprite(Texture2D newSprite)
        {
            sprite = newSprite;
            return true;
        }

        public Texture2D GetSprite()
        {
            return sprite;
        }
    }
}
