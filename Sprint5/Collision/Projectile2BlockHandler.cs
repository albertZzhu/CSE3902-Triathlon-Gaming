using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5.Collision
{
	class Projectile2BlockHandler : ICollisionHandler<IProjectile, IBlock>
	{
		public Projectile2BlockHandler()
		{

		}

		public void Handle(IProjectile projectile, IBlock block, SideEnum side)
		{
			projectile.die();
		}
	}
}