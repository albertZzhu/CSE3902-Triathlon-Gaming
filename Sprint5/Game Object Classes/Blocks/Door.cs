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
		private SideEnum side;
		private bool locked;

		public Door(String spriteName, Vector2 newLocation, SideEnum side, bool locked)
		{
			blockSprite = SpriteFactory.GetSprite(spriteName);
			location = newLocation;
			this.side = side;
			this.locked = locked;
		}

		public void UnlockDoor()
        {
			if (Inventory.KeyCount() > 0)
			{
				Inventory.SubtractKeys();
				SetBlock("rightgate");
				locked = false;
			}
        }

		public bool IsLocked()
        {
			return locked;
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

		public SideEnum DoorSide()
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
