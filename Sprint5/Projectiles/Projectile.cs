using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.State_Machines;

namespace Sprint5
{
	class Projectile : IProjectile
	{
		private ISprite sprite;
		private Vector2 location;
		private FacingEnum direction; 
		private bool dead;

		public Projectile(Vector2 newLocation, FacingEnum direction, ISprite sprite)
		{
			location = newLocation;
			this.direction = direction;
			this.sprite = sprite;
			dead = false;
		}

		public bool isDead()
		{
			return dead;
		}

		public void die()
		{
			dead = true;
		}

		public Rectangle GetRect()
		{
			Rectangle opt = new Rectangle((int)location.X, (int)location.Y, (int)sprite.getSize().X, (int)sprite.getSize().Y);
			return opt;
		}
		public void Update(GameTime gameTime)
		{
			if (!dead)
			{
				switch (direction)
				{
					case FacingEnum.RIGHT:
						location = new Vector2(location.X + 5, location.Y);
						break;
					case FacingEnum.LEFT:
						location = new Vector2(location.X - 5, location.Y);
						break;
					case FacingEnum.UP:
						location = new Vector2(location.X, location.Y - 5);
						break;
					case FacingEnum.DOWN:
						location = new Vector2(location.X, location.Y + 5);
						break;
					//left for dragon use, don't care about this part.
					case FacingEnum.NORTHEAST:
						location = new Vector2(location.X + 5, location.Y - 3);
						break;
					case FacingEnum.SOUTHEAST:
						location = new Vector2(location.X + 5, location.Y + 3);
						break;
					case FacingEnum.NORTHWEST:
						location = new Vector2(location.X - 5, location.Y - 3);
						break;
					case FacingEnum.SOUTHWEST:
						location = new Vector2(location.X - 5, location.Y + 3);
						break;
					case FacingEnum.NNWEST:
						location = new Vector2(location.X - 3, location.Y - 5);
						break;
					case FacingEnum.NNEAST:
						location = new Vector2(location.X + 3, location.Y - 5);
						break;
					case FacingEnum.SSWEST:
						location = new Vector2(location.X - 3, location.Y + 5);
						break;
					case FacingEnum.SSEAST:
						location = new Vector2(location.X + 3, location.Y + 5);
						break;
					default:
						break;
				}
				sprite.Update();
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			if (!dead)
			{
				sprite.Draw(spriteBatch, location);
			}
		}
	}
}