using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.State_Machines;


namespace Sprint5
{
	class MoveableBlock : IBlock
	{
		private Vector2 location;
		private ISprite blockSprite = new Sprite();
		private String blockTexture;
		private bool canMoveUp = true;
		private bool canMoveDown = true;
		private bool canMoveRight = true;
		private bool canMoveLeft = true;
		private int speed = 10;
		private Facing facingState = Facing.RIGHT;

		public void SetLocation(Vector2 newLocation)
		{
			location = newLocation;
		}

		public void moveLock(Facing direction)
		{
			switch (direction)
			{
				case Facing.RIGHT:
					canMoveRight = false;
					break;
				case Facing.LEFT:
					canMoveLeft = false;
					break;
				case Facing.UP:
					canMoveUp = false;
					break;
				case Facing.DOWN:
					canMoveDown = false;
					break;
			}
			if (!(this.canMoveRight && this.canMoveLeft && this.canMoveUp && this.canMoveDown))
			{
				Move((Facing)((int)facingState % 2 == 0 ? (int)facingState + 1 : (int)facingState - 1));
			}
		}

		public void moveunLock(Facing direction)
		{
			switch (direction)
			{
				case Facing.RIGHT:
					canMoveRight = true;
					break;
				case Facing.LEFT:
					canMoveLeft = true;
					break;
				case Facing.UP:
					canMoveUp = true;
					break;
				case Facing.DOWN:
					canMoveDown = true;
					break;
			}
		}

		public void Move(Facing facing)
		{
			switch (facing)
			{
				case Facing.RIGHT:
					if(canMoveRight)
					{
						location.X += speed;
						facingState = facing;
					}
					break;
				case Facing.LEFT:
					if(canMoveLeft)
					{
						location.X -= speed;
						facingState = facing;
					}
					break;
				case Facing.UP:
					if (canMoveUp)
					{
						location.Y -= speed;
						facingState = facing;
					}
					break;
				case Facing.DOWN:
					if(canMoveDown)
					{
						location.Y += speed;
						facingState = facing;
					}
					break;
			}
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
