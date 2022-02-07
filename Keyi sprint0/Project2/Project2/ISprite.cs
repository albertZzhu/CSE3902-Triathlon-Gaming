using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project2
{
    interface ISprite
    {
        void update();

        void draw(SpriteBatch spriteBatch, Vector2 location);

    }
}
