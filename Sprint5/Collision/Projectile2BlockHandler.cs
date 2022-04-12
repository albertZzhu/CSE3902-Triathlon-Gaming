using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4.Collision
{
	class Projectile2BlockHandler : ICollisionHandler<IProjectile, IBlock>
	{
		public Projectile2BlockHandler()
		{

		}

		public void Handle(IProjectile projectile, IBlock block, Side.side side)
		{
			projectile.die();
		}
	}
}