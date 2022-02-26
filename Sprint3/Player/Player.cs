using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3
{
	public class Player
	{
		private ISprite sprite = new Sprite();
		//Location data should be in statemachine?
		private Vector2 location = new Vector2(50, 50);
		private PlayerStateMechine state;
		//this probably shouldn't be in the player class
		private ProjectileSeq proj;
		private int boundWidth;//Get the width of the current window so the figure can go back when hit the boundary
		private int boundHeight;//Get the height of the current window so the figure can go back when hit the boundary
		//put a description here for this?
		private int spriteNum;

		public Player(int boundWidth, int boundHeight)
		{
			//initialize position with this statemachine call?
			state = new PlayerStateMechine(this);
			this.proj = new ProjectileSeq();
			this.boundWidth = boundWidth;
			this.boundHeight = boundHeight;
		}

		public void GoStand()
		{
			state.ChangeMovingState(false);
		}

		//positive x, increment to the right. negative x, decrement to the left.
		//positive y, increment down. negative y, decrement up. 
		//x could be 1 for walking or 5 for sprinting 
		public void Move(string facing)
		{
			//location = new Vector2(location.X + x, location.Y + y);
			//return location;
			state.ChangeFacing(facing);
			state.ChangeMovingState(true);
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
			state.ChangeFacing("right");
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
