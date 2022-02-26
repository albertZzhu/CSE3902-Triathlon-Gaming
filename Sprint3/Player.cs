using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3
{
	public class Player : IGameObject
	{
		private ISprite sprite = new Sprite();
		private Vector2 location = new Vector2(50, 50);
		private PlayerStateMechine state;
		private ProjectileSeq proj;
		private int boundWidth;//Get the width of the current window so the figure can go back when hit the boundary
		private int boundHeight;//Get the height of the current window so the figure can go back when hit the boundary
		private int spriteNum;

		public Player(int boundWidth, int boundHeight)
		{
			state = new PlayerStateMechine(this);
			this.proj = new ProjectileSeq();
			this.boundWidth = boundWidth;
			this.boundHeight = boundHeight;
		}

		public void GoStand()
		{
			state.changeMovingState(false);
		}

		//positive x, increment to the right. negative x, decrement to the left.
		//positive y, increment down. negative y, decrement up. 
		//x could be 1 for walking or 5 for sprinting 
		public void Move(int facing)
		{
			//location = new Vector2(location.X + x, location.Y + y);
			//return location;
			state.ChangeFacing(facing);
			state.changeMovingState(true);
			switch (facing)
			{
				case 0:
					if (location.X + 10 < boundWidth - 20)
					{
						location = new Vector2(location.X + 10, location.Y);
					}
					break;
				case 1:
					if (location.X - 10 > 0)
					{
						location = new Vector2(location.X - 10, location.Y);
					}
					break;
				case 2:
					if (location.Y - 10 > 0)
					{
						location = new Vector2(location.X, location.Y - 10);
					}
					break;
				case 3:
					if (location.Y + 10 < boundHeight - 30)
					{
						location = new Vector2(location.X, location.Y + 10);
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

		public Vector2 GetLocation()
		{
			return location;
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
			proj.Update();
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
