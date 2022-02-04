using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class MNASprite : ISprite
    {
        private Texture2D sprite;
        private bool visible;
        private Vector2 pos;
        private int x = 0;

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            //this isn't working i dont think
            if (pos.Equals(null))
                pos = position;
            if (IsVisible())
                spriteBatch.Draw(sprite, pos, Color.White);
        }

        public void Update()
        {
            //to bounce back and forth, use screen size?
            //GraphicsDevice.DisplayMode.Width
            //GraphicsDevice.DisplayMode.Height
            if (IsVisible())
            {
                if (x < 500)
                {
                    pos.X++;
                    x++;
                }
                else
                    pos.X--;
                if (pos.X == 0)
                    x = 0;
            }
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
        public MNASprite()
        {

        }

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
