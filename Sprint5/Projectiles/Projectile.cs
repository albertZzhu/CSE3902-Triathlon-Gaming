using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint4.State_Machines;

namespace Sprint4
{
	class Projectile : IProjectile
	{
		private ISprite sprite;
		private Vector2 location;
		private Facing direction; 
		private bool dead;

		public Projectile(Vector2 newLocation, Facing direction, ISprite sprite)
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
					case Facing.RIGHT:
						location = new Vector2(location.X + 5, location.Y);
						break;
					case Facing.LEFT:
						location = new Vector2(location.X - 5, location.Y);
						break;
					case Facing.UP:
						location = new Vector2(location.X, location.Y - 5);
						break;
					case Facing.DOWN:
						location = new Vector2(location.X, location.Y + 5);
						break;
					//left for dragon use, don't care about this part.
					case Facing.NORTHEAST:
						location = new Vector2(location.X + 5, location.Y - 3);
						break;
					case Facing.SOUTHEAST:
						location = new Vector2(location.X + 5, location.Y + 3);
						break;
					case Facing.NORTHWEST:
						location = new Vector2(location.X - 5, location.Y - 3);
						break;
					case Facing.SOUTHWEST:
						location = new Vector2(location.X - 5, location.Y + 3);
						break;
					case Facing.NNWEST:
						location = new Vector2(location.X - 3, location.Y - 5);
						break;
					case Facing.NNEAST:
						location = new Vector2(location.X + 3, location.Y - 5);
						break;
					case Facing.SSWEST:
						location = new Vector2(location.X - 3, location.Y + 5);
						break;
					case Facing.SSEAST:
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