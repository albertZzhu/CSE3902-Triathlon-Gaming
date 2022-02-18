using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace Sprint2
{
	class ProjectileSeq
	{
		private ArrayList list;

		public ProjectileSeq()
		{
			list = new ArrayList();
		}

		public void NewProjectile(Vector2 newLocation, int direction, int sprite)
		{
			switch (sprite)
			{
				case 1:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("distantAttackRight")));
					break;
				case 2:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("glassBlock")));
					break;
				case 3:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("distantAttackRight")));
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
