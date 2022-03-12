using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3
{
	class Projectile : IProjectile
	{
		private ISprite sprite;
		private Vector2 location;
		private int direction;  //facing variable, 0 means right, 1 means left, 2 means upward, 3 means downward
		private bool dead;

		public Projectile(Vector2 newLocation, int direction, ISprite sprite)
		{
			this.location = newLocation;
			this.direction = direction;
			this.sprite = sprite;
			this.dead = false;
		}

		public bool isDead()
		{
			return this.dead;
		}

		public void die()
		{
			this.dead = true;
		}

		public Rectangle GetRect()
		{
			Rectangle opt = new Rectangle((int)this.location.X, (int)this.location.Y, (int)this.sprite.getSize().X, (int)this.sprite.getSize().Y);
			return opt;
		}
		public void Update(GameTime gameTime)
		{
			if (!dead)
			{
				switch (direction)
				{
					case 0:
						location = new Vector2(location.X + 5, location.Y);
						break;
					case 1:
						location = new Vector2(location.X - 5, location.Y);
						break;
					case 2:
						location = new Vector2(location.X, location.Y - 5);
						break;
					case 3:
						location = new Vector2(location.X, location.Y + 5);
						break;
					//left for dragon use, don't care about this part.
					case 10:
						location = new Vector2(location.X + 5, location.Y - 3);
						break;
					case -10:
						location = new Vector2(location.X + 5, location.Y + 3);
						break;
					case 11:
						location = new Vector2(location.X - 5, location.Y - 3);
						break;
					case -9:
						location = new Vector2(location.X - 5, location.Y + 3);
						break;
					case 12:
						location = new Vector2(location.X - 3, location.Y - 5);
						break;
					case -8:
						location = new Vector2(location.X + 3, location.Y - 5);
						break;
					case 13:
						location = new Vector2(location.X - 3, location.Y + 5);
						break;
					case -7:
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