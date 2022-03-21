using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4.Collision
{
	class Player2ProjectileHandler : ICollisionHandler<Iplayer, IProjectile>
	{
		public Player2ProjectileHandler()
		{

		}

		public void Handle(Iplayer player, IProjectile projectile, Side.side side)
		{
			player.GoDamaged();
			//projectile.die();
		}
	}
}