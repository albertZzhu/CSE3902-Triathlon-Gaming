using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint5
{
	public class Block : IBlock
	{
		private Vector2 location;
		private ISprite blockSprite = new Sprite();
		private String blockTexture;

		public void SetLocation(Vector2 newLocation)
		{
			location = newLocation;
		}

		public Rectangle GetRect()
		{
			Rectangle opt = new Rectangle((int)location.X, (int)location.Y, (int)blockSprite.getSize().X, (int)blockSprite.getSize().Y);
			return opt;
		}

		public Vector2 GetLocation()
		{
			return location;
		}

		public ISprite GetItem()
		{
			return blockSprite;
		}
		public void SetBlock(String blockTexture)
		{
			blockSprite = SpriteFactory.GetSprite(blockTexture);
		}

		public void Update(GameTime gameTime)
		{
			blockSprite.Update();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			blockSprite.Draw(spriteBatch, location);
		}
	}
}
