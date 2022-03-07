using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Collision
{
	class Player2ProjectileHandler : ICollisionHandler<Iplayer, IProjectile>
	{
		public void Handle(Iplayer player, IProjectile projectile, Side.side side)
		{
			player.GoDamaged();
			projectile = null;
		}
	}
}
