using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
	class NpcProjectileSeq
	{
		public List<IProjectile> list;

		public NpcProjectileSeq()
		{
			list = new List<IProjectile>();
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
				//left for dragon use, don't care this part.
				case 10:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[0])));
					break;
				case -10:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[0])));
					break;
				case 11:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[1])));
					break;
				case -9:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[1])));
					break;
				case 12:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[2])));
					break;
				case -8:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[2])));
					break;
				case 13:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[3])));
					break;
				case -7:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[3])));
					break;
				default:
					break;
			}

		}
		public List<IProjectile> GetProjList()
		{
			return this.list;
		}
		public void Update(GameTime gameTime)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (!list[i].isDead())
				{
					list[i].Update(gameTime);
				}
				else
				{
					list.Remove(list[i]);
				}
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