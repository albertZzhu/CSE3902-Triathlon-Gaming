using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
    interface ILevel
    {
        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);
    }
}