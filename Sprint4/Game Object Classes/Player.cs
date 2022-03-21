using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;

namespace Sprint4
{
	public class Player : Iplayer
	{
		private ISprite sprite = new Sprite();
		private Vector2 location = new Vector2(100, 250);
		private PlayerStateMechine state;
		private ProjectileSeq proj;
		private int boundWidth;//Get the width of the current window so the figure can go back when hit the boundary
		private int boundHeight;//Get the height of the current window so the figure can go back when hit the boundary
		private int spriteNum;
		private int velocity = 5;

		private bool canMoveUp = true;
		private bool canMoveDown = true;
		private bool canMoveRight = true;
		private bool canMoveLeft = true;

		public Player(int boundWidth, int boundHeight)
		{
			state = new PlayerStateMechine(this);
			this.proj = new ProjectileSeq();
			this.boundWidth = boundWidth;
			this.boundHeight = boundHeight;
		}

		public void moveLock(int direction)
		{
			switch (direction)
			{
				case 0:
					this.canMoveRight = false;
					break;
				case 1:
					this.canMoveLeft = false;
					break;
				case 2:
					this.canMoveUp = false;
					break;
				case 3:
					this.canMoveDown = false;
					break;
			}
		}

		public void moveunLock(int direction)
		{
			switch (direction)
			{
				case 0:
					this.canMoveRight = true;
					break;
				case 1:
					this.canMoveLeft = true;
					break;
				case 2:
					this.canMoveUp = true;
					break;
				case 3:
					this.canMoveDown = true;
					break;
			}
		}

		public void GoStand()
		{
			state.changeMovingState(false);
		}
		internal List<Projectile> GetSeqList()
		{
			
				return this.proj.GetProjList();
		}
		//positive x, increment to the right. negative x, decrement to the left.
		//positive y, increment down. negative y, decrement up. 
		//x could be 1 for walking or 5 for sprinting 
		public void Move(int facing)
		{
			state.ChangeFacing(facing);
			state.changeMovingState(true);
			switch (facing)
			{
				case 0:
					if (location.X + 10 < boundWidth - 20&&canMoveRight)
					{
						location = new Vector2(location.X + velocity, location.Y);
					}
					break;
				case 1:
					if (location.X - 10 > 0&&canMoveLeft)
					{
						location = new Vector2(location.X - velocity, location.Y);
					}
					break;
				case 2:
					if (location.Y - 10 > 0&&canMoveUp)
					{
						location = new Vector2(location.X, location.Y - velocity);
					}
					break;
				case 3:
					if (location.Y + 10 < boundHeight - 30&&canMoveDown)
					{
						location = new Vector2(location.X, location.Y + velocity);
					}
					break;
				default:
					break;
			}
		}

		public void DistantAttack()
		{
			this.proj.NewProjectile(new Vector2(location.X + 15, location.Y + 15), state.FacingState(), this.spriteNum);
		}

		public void SetLocation(Vector2 newLocation)
		{
			location = newLocation;
		}

		public Rectangle GetRect()
		{
			Rectangle opt = new Rectangle((int)this.location.X, (int)this.location.Y, (int)this.sprite.getSize().X, (int)this.sprite.getSize().Y);
			return opt;
		}


		public void SetSprite(ISprite spr)
		{
			sprite = spr;
		}

		public ISprite GetSprite()
		{
			return sprite;
		}

		public void GoAttack()
		{
			state.Attack();
		}

		public void GoDamaged()
		{
			state.Damaged();
		}

		public void Reset()
		{
			SetLocation(new Vector2(50, 50));
			state.ChangeFacing(0);
			spriteNum = 0;
		}
		public void Update(GameTime gameTime)
		{
			state.Update(gameTime);
			sprite.Update();
			proj.Update(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch, location);
			proj.Draw(spriteBatch);
		}

		public void setFireball(int i)
		{
			this.spriteNum = i;
		}
	}
}