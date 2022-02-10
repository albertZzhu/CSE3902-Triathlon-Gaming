using System;
using System.Collections;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
	class ProjectileSeq
	{
		private ArrayList list;

		public ProjectileSeq()
		{
			list = new ArrayList();
		}

		public void NewProjectile(Vector2 newLocation, int direction)
		{
			//, SpriteFactory.GetSprite("attackRight")
			switch (direction)
			{
				case 0:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("attackRight")));
					break;
				case 1:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("attackRight")));
					break;
				case 2:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("attackUp")));
					break;
				case 3:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("attackDown")));
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
