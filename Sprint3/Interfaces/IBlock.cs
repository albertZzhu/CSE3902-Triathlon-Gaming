using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3
{
	interface IBlock
	{
		void Reset();

		void Update(GameTime gameTime);

		void Draw(SpriteBatch spriteBatch);

		Rectangle GetRect();
	}
}