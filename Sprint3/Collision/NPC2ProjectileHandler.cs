using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Collision
{
	class NPC2ProjectileHandler : ICollisionHandler<INPC, IProjectile>
	{
		public NPC2ProjectileHandler()
		{

		}

		public void Handle(INPC enemy, IProjectile projectile, Side.side side)
		{
			enemy.GoDamaged();
			projectile = null;
		}
	}
}