using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint5
{
	public class Door : IBlock
	{
		private Vector2 location;
		private ISprite blockSprite = new Sprite();
		private Side.side side;

		public Door(String spriteName, Vector2 newLocation, Side.side side)
		{
			blockSprite = SpriteFactory.GetSprite(spriteName);
			location = newLocation;
			this.side = side;
		}

		public void SetLocation(Vector2 newLocation)
		{
			location = newLocation;
		}

		public Rectangle GetRect()
		{
			return new Rectangle((int)location.X, (int)location.Y, (int)blockSprite.getSize().X, (int)blockSprite.getSize().Y);
		}

		public void SetBlock(String blockTexture)
		{
			blockSprite = SpriteFactory.GetSprite(blockTexture);
		}

		public Side.side DoorSide()
		{
			return side;
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
