using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3
{
	interface Iplayer
	{
		void Move(int facing);

		Vector2 GetLocation();

		ISprite GetSprite();

		void GoDamaged();

		void GoStand();

		void Reset();

		void Update(GameTime gameTime);

		void Draw(SpriteBatch spriteBatch);

	}
}
