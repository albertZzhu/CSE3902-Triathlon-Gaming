using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace Sprint2
{
	class ProjectileSeq
	{
		private ArrayList list;
		float bias = 30;
		public ProjectileSeq()
		{
			list = new ArrayList();
		}

		public void NewProjectile(Vector2 newLocation, int direction, int sprite)
		{
			switch (sprite)
			{ //add more
				case 0:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("projectileRight")));
					break;
				case 1:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("fireballright")));
					break;
				case 2:
					list.Add(new Projectile(new Vector2(newLocation.X - bias,newLocation.Y), direction, SpriteFactory.GetSprite("sword")));
					break;
				case 3:
					list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), direction, SpriteFactory.GetSprite("projectileRight")));
					break;
				default:
					break;

			}

		}

		public void Update()
		{
			foreach (Projectile p in list)
			{
				p.Update();
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (Projectile p in list)
			{
				p.Draw(spriteBatch);
			}
		}
	}
}
