using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;


namespace Sprint5.Collision
{
	class ProjectileCollisionDetection
	{

		private Projectile2BlockHandler blockHandle;

		public ProjectileCollisionDetection(string projectileName, CollisionHandlerDict dict)
		{
			blockHandle = dict.GetProjectile2Block(projectileName);
		}

		public void Detect(IProjectile projectile, IBlock[] blockInRange)
		{
			IBlock[] blockInRangeModified = blockInRange.Skip(1).ToArray();

			foreach (IBlock b in blockInRangeModified)
			{
				if ((new Rectangle(projectile.GetRect().X, projectile.GetRect().Y, 20, 20)).Intersects(b.GetRect())&&
					(b.GetType().Equals(typeof(Block))|| b.GetType().Equals(typeof(MoveableBlock))))
				{
					blockHandle.Handle(projectile, b, Side.side.right);
				}
			}
		}
	}
}