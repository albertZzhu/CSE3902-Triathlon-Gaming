using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;


namespace Sprint4.Collision
{
	class ProjectileCollisionDetection
	{
		private string projectileName;
		private IBlock[] blockInRange;

		private Projectile2BlockHandler blockHandle;

		public ProjectileCollisionDetection(string projectileName, CollisionHandlerDict dict)
		{
			this.projectileName = projectileName;


			this.blockHandle = dict.GetProjectile2Block(projectileName);
		}

		public void Detect(IProjectile projectile, IBlock[] blockInRange)
		{
			IBlock[] blockInRangeModified = blockInRange.Skip(1).ToArray();
			this.blockInRange = blockInRange;

			foreach (IBlock b in blockInRangeModified)
			{
				if (projectile.GetRect().Intersects(b.GetRect()))
				{
					this.blockHandle.Handle(projectile, b, Side.side.right);
				}
			}
		}
	}
}