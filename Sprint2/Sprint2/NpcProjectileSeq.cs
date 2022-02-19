using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
	class NpcProjectileSeq
	{
		private ArrayList list;

		public NpcProjectileSeq()
		{
			list = new ArrayList();
		}

		public void NewProjectile(Vector2 newLocation, int direction, List<string> fireballHolder)
		{
			//, SpriteFactory.GetSprite("attackRight")
			switch (direction)
			{
				case 0:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[0])));
					break;
				case 1:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[1])));
					break;
				case 2:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[2])));
					break;
				case 3:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[3])));
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
