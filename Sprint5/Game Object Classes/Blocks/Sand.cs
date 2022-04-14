using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
    public class Sand : IBlock
    {
		private Vector2 location;
		private ISprite sandSprite = new Sprite();
		private String sandTexture;

		public void SetLocation(Vector2 newLocation)
		{
			location = newLocation;
		}

		public Rectangle GetRect()
		{
			Rectangle opt = new Rectangle((int)location.X, (int)location.Y, (int)sandSprite.getSize().X, (int)sandSprite.getSize().Y);
			return opt;
		}

		public Vector2 GetLocation()
		{
			return location;
		}

		public ISprite GetItem()
		{
			return sandSprite;
		}
		public void SetBlock(String sandTexture)
		{
			sandSprite = SpriteFactory.GetSprite(sandTexture);
		}

		public void Update(GameTime gameTime)
		{
			sandSprite.Update();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			sandSprite.Draw(spriteBatch, location);
		}
	}
}
