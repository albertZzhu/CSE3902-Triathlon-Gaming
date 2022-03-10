﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3
{
	public interface IGameObject
	{

		public void Update(GameTime gameTime);

		public void Draw(SpriteBatch spriteBatch);
	}
}