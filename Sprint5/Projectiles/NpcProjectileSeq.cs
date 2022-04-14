using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.State_Machines;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
	class NpcProjectileSeq
	{
		public List<IProjectile> list;

		public NpcProjectileSeq()
		{
			list = new List<IProjectile>();
		}

		public void NewProjectile(Vector2 newLocation, FacingEnum direction, List<string> fireballHolder)
		{
			//, SpriteFactory.GetSprite("attackRight")
			switch (direction)
			{
				case FacingEnum.RIGHT:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[0])));
					break;
				case FacingEnum.LEFT:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[1])));
					break;
				case FacingEnum.UP:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[2])));
					break;
				case FacingEnum.DOWN:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[3])));
					break;
				//left for dragon use, don't care this part.
				case FacingEnum.NORTHEAST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[0])));
					break;
				case FacingEnum.SOUTHEAST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[0])));
					break;
				case FacingEnum.NORTHWEST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[1])));
					break;
				case FacingEnum.SOUTHWEST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[1])));
					break;
				case FacingEnum.NNWEST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[2])));
					break;
				case FacingEnum.NNEAST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[2])));
					break;
				case FacingEnum.SSWEST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[3])));
					break;
				case FacingEnum.SSEAST:
					list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite(fireballHolder[3])));
					break;
				default:
					break;
			}

		}
		public List<IProjectile> GetProjList()
		{
			return list;
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