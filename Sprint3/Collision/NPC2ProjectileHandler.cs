using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Collision
{
	class NPC2ProjectileHandler : ICollisionHandler<INPC, IProjectile>
	{

		public void Handle(INPC enemy, IProjectile projectile, Side side)
		{
			enemy.GoDamaged();
			projectile = null;
		}
	}
}
