using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public interface ISprite //should i make a sprite base class?
    {
        //public bool SetSprite(Texture2D newSprite);

        //public Texture2D GetSprite();

        public bool IsVisible();

        public bool SetVisible(bool value);

        public void Update();

        //public void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
