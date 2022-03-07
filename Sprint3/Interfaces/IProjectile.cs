using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint3
{
	interface IProjectile
	{
		void Update();

		void Draw(SpriteBatch spriteBatch);

		Rectangle GetRect();
	}
}
