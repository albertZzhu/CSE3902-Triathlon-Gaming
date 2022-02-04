using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Sprites
{
    class TextSprite : ISprite
    {
        private SpriteFont fontText;
        private bool visible;

        //default constructor
        public TextSprite()
        {
        }

        //populate fontText property constructor
        public TextSprite(SpriteFont text) {
            fontText = text;
            }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, String text)
        {
            spriteBatch.DrawString(fontText, text, location, Color.LightBlue);
        }

        public void Update()
        {
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

        public bool SetSprite(SpriteFont text)
        {
            fontText = text;
            return true;
        }

        public SpriteFont GetSprite()
        {
            return fontText;
        }
    }
}
