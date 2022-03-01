using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3.PlayerFiles

{
	public class Player
	{
		private ISprite sprite = new Sprite();

		private PlayerStateMachine state;

		public Player(Vector2 bounds)
		{
			state = new PlayerStateMachine(this, bounds);
		}

		public void Move()
		{
			state.Move();
		}

		public void SetLocation(Vector2 newLocation)
		{
			state.SetLocation(newLocation);
		}

		public Vector2 GetLocation()
		{
			return state.GetLocation();
		}


		public void SetSprite(ISprite spr)
		{
			sprite = spr;
		}

		/*public ISprite GetSprite()
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
		}*/

		public void Reset()
        {
			state.ResetLocation();
			state.GetFacingMachine().SetFacing("right");
        }
		public void Update(GameTime gameTime)
		{
			state.Update(gameTime);
			sprite.Update();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch, state.GetLocation());
			//proj.Draw(spriteBatch);
		}

		/*public void setFireball(int i)
        {
			this.spriteNum = i;
        }*/
	}
}
