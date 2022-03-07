using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3.Collision
{
	class ProjectileCollisionDetection
	{
		private string projectileName;
		private IProjectile projectile;
		private IBlock[] blockInRange;

		private Projectile2BlockHandler blockHandle;

		public ProjectileCollisionDetection(string projectileName, IProjectile p)
		{
			this.projectileName = projectileName;
			this.projectile = p;


			this.blockHandle = CollisionHandlerDict.GetProjectile2Block(projectileName);
		}

		public void Detect(IBlock[] blockInRange)
		{
			this.blockInRange = blockInRange;

			foreach (IBlock b in blockInRange)
			{
				if (this.projectile.GetRect().Intersects(b.GetRect()))
				{
					this.blockHandle.Handle(this.projectile, b, Side.side.right);
				}
			}
		}
	}
}
