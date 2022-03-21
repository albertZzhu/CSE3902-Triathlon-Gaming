using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Collision
{
	class Player2EnemyHandler : ICollisionHandler<Iplayer, INPC>
	{
		public Player2EnemyHandler()
		{

		}

		public void Handle(Iplayer player, INPC enemy, Side.side side)
		{
			if (!enemy.isDead())
			{
				player.GoDamaged();
			}
		}
	}
}