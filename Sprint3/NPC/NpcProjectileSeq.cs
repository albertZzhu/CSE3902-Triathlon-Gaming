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
		private ArrayList list;

		public NpcProjectileSeq()
		{
			list = new ArrayList();
		}

		public void NewProjectile(Vector2 newLocation, Facing facing, List<string> fireballHolder)
		{
			//, SpriteFactory.GetSprite("attackRight")
			switch (facing)
			{
				case Facing.RIGHT:
					list.Add(new Projectile(newLocation, facing, SpriteFactory.GetSprite(fireballHolder[0])));
					break;
				case Facing.LEFT:
					list.Add(new Projectile(newLocation, facing, SpriteFactory.GetSprite(fireballHolder[1])));
					break;
				case Facing.UP:
					list.Add(new Projectile(newLocation, facing, SpriteFactory.GetSprite(fireballHolder[2])));
					break;
				case Facing.DOWN:
					list.Add(new Projectile(newLocation, facing, SpriteFactory.GetSprite(fireballHolder[3])));
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
