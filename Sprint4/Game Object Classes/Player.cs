﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint4.State_Machines;
using System.Collections;
using System.Collections.Generic;

namespace Sprint4
{
	public class Player : Iplayer
	{
		private ISprite sprite = new Sprite();
		private Vector2 location;
		public PlayerStateMachine state;
		private ProjectileSeq proj;
		private int boundWidth;//Get the width of the current window so the figure can go back when hit the boundary
		private int boundHeight;//Get the height of the current window so the figure can go back when hit the boundary
		private int spriteNum;
		private int velocity = 5;

		private bool canMoveUp = true;
		private bool canMoveDown = true;
		private bool canMoveRight = true;
		private bool canMoveLeft = true;

		public Player(int boundWidth, int boundHeight, Vector2 spawnLocation, int spawnHealth)
		{
			state = new PlayerStateMachine(this, spawnHealth);
			proj = new ProjectileSeq();
			location = spawnLocation;

			//this.level = level;

			this.boundWidth = boundWidth;
			this.boundHeight = boundHeight;
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
				Move((Facing)(this.state.FacingState() % 2 == 0 ? this.state.FacingState() + 1 : this.state.FacingState() - 1));
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
		public PlayerStateMachine GetState()
        {
			return state;
        }

		public bool IfAttacking()
		{
			return state.IsAttacking();
		}
		public bool IfDie()
		{
			return state.IfDie();
		}
		public void GoStand()
		{
			state.changeMovingState(false);
		}
		internal List<Projectile> GetSeqList()
		{
			
				return proj.GetProjList();
		}
		//positive x, increment to the right. negative x, decrement to the left.
		//positive y, increment down. negative y, decrement up. 
		//x could be 1 for walking or 5 for sprinting 
		public void Move(Facing facing)
		{
			state.ChangeFacing(facing);
			state.changeMovingState(true);
			switch (facing)
			{
				case Facing.RIGHT:
					if (location.X + 10 < boundWidth - 20&&canMoveRight)
					{
						location = new Vector2(location.X + velocity, location.Y);
					}
					break;
				case Facing.LEFT:
					if (location.X - 10 > 0&&canMoveLeft)
					{
						location = new Vector2(location.X - velocity, location.Y);
					}
					break;
				case Facing.UP:
					if (location.Y - 10 > 0&&canMoveUp)
					{
						location = new Vector2(location.X, location.Y - velocity);
					}
					break;
				case Facing.DOWN:
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
			proj.NewProjectile(new Vector2(location.X + 15, location.Y + 15), (Facing)state.FacingState(), spriteNum);
		}

		public void SetLocation(Vector2 newLocation)
		{
			location = newLocation;
		}

		public Vector2 GetLocation()
		{
			return location;
		}

		public Rectangle GetRect()
		{
			Rectangle opt = new Rectangle((int)location.X, (int)location.Y, (int)sprite.getSize().X, (int)sprite.getSize().Y);
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
			SetLocation(new Vector2(100, 250));
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
			spriteNum = i;
		}
	}
}