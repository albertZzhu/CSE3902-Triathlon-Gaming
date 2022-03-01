using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3
{
	class Projectile
	{
		private ISprite sprite;
		private Vector2 location;
		private Facing facing;

		public Projectile(Vector2 newLocation, Facing facing, ISprite sprite)
		{
			this.location = newLocation;
			this.facing = facing;
			this.sprite = sprite;
		}

		public void Update()
		{
			
				if (facing == Facing.RIGHT)
					location = new Vector2(location.X + 5, location.Y);
				else if (facing == Facing.LEFT)
					location = new Vector2(location.X - 5, location.Y);
				else if (facing == Facing.DOWN)
					location = new Vector2(location.X, location.Y - 5);
				else if (facing == Facing.UP)
					location = new Vector2(location.X, location.Y + 5);
			sprite.Update();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			sprite.Draw(spriteBatch, location);
		}
	}
}
