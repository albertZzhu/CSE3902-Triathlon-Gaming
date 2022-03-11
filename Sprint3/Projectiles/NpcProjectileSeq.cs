using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
	class NpcProjectileSeq
	{
		public List<Projectile> list;

		public NpcProjectileSeq()
		{
			list = new List<Projectile>();
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
		public List<Projectile> GetProjList()
		{
			return this.list;
		}
		public void Update(GameTime gameTime)
		{
			foreach (Projectile p in list)
			{
				p.Update(gameTime);
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