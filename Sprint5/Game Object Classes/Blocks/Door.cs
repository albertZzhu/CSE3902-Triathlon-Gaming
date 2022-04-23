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

		public Door(String spriteName, Vector2 newLocation, SideEnum side)
		{
			blockSprite = SpriteFactory.GetSprite(spriteName);
			location = newLocation;
			this.side = side;
			if(spriteName.Equals("rightgate") || spriteName.Equals("leftgate") || spriteName.Equals("topgate") || spriteName.Equals("bottomgate")||spriteName.Equals("bottomarch")||spriteName.Equals("toparch"))
				locked = false;
			else
				locked = true;
		}

		public void UnlockDoor()
        {
			if (IsLocked() && Inventory.KeyCount() > 10)
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
