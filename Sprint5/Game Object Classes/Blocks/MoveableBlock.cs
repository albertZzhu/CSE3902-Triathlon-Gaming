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
		private bool canMoveUp = true;
		private bool canMoveDown = true;
		private bool canMoveRight = true;
		private bool canMoveLeft = true;
		private int speed = 10;
		private FacingEnum facingState = FacingEnum.RIGHT;

		public void SetLocation(Vector2 newLocation)
		{
			location = newLocation;
		}

		public void moveLock(FacingEnum direction)
		{
			switch (direction)
			{
				case FacingEnum.RIGHT:
					canMoveRight = false;
					break;
				case FacingEnum.LEFT:
					canMoveLeft = false;
					break;
				case FacingEnum.UP:
					canMoveUp = false;
					break;
				case FacingEnum.DOWN:
					canMoveDown = false;
					break;
			}
			if (!(this.canMoveRight && this.canMoveLeft && this.canMoveUp && this.canMoveDown))
			{
				Move((FacingEnum)((int)facingState % 2 == 0 ? (int)facingState + 1 : (int)facingState - 1));
			}
		}


		public bool GetMoveLockState(FacingEnum facing)
		{
			bool opt = false;
			switch (facing)
			{
				case FacingEnum.RIGHT:
					opt = canMoveRight;
					break;
				case FacingEnum.LEFT:
					opt = canMoveLeft;
					break;
				case FacingEnum.UP:
					opt = canMoveUp;
					break;
				case FacingEnum.DOWN:
					opt = canMoveDown;
					break;
			}
			return opt;
		}

		public void moveunLock(FacingEnum direction)
		{
			switch (direction)
			{
				case FacingEnum.RIGHT:
					canMoveRight = true;
					break;
				case FacingEnum.LEFT:
					canMoveLeft = true;
					break;
				case FacingEnum.UP:
					canMoveUp = true;
					break;
				case FacingEnum.DOWN:
					canMoveDown = true;
					break;
			}
		}

		public void Move(FacingEnum facing)
		{
			switch (facing)
			{
				case FacingEnum.RIGHT:
					if(canMoveRight)
					{
						location.X += speed;
						facingState = facing;
					}
					break;
				case FacingEnum.LEFT:
					if(canMoveLeft)
					{
						location.X -= speed;
						facingState = facing;
					}
					break;
				case FacingEnum.UP:
					if (canMoveUp)
					{
						location.Y -= speed;
						facingState = facing;
					}
					break;
				case FacingEnum.DOWN:
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
