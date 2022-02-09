using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public interface ISprite
    {

        public void Update();

        public void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
