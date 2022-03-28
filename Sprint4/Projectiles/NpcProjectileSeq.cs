using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint4.State_Machines;
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

		public void NewProjectile(Vector2 newLocation, Facing direction, List<string> fireballHolder)
		{
			//, SpriteFactory.GetSprite("attackRight")
			switch (direction)
			{
				case Facing.RIGHT:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[0])));
					break;
				case Facing.LEFT:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[1])));
					break;
				case Facing.UP:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[2])));
					break;
				case Facing.DOWN:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[3])));
					break;
				//left for dragon use, don't care this part.
				case Facing.NORTHEAST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[0])));
					break;
				case Facing.SOUTHEAST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[0])));
					break;
				case Facing.NORTHWEST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[1])));
					break;
				case Facing.SOUTHWEST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[1])));
					break;
				case Facing.NNWEST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[2])));
					break;
				case Facing.NNEAST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[2])));
					break;
				case Facing.SSWEST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[3])));
					break;
				case Facing.SSEAST:
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