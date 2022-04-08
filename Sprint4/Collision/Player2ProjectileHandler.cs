using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4.Collision
{
	class Player2ProjectileHandler : ICollisionHandler<Iplayer, IProjectile>
	{
		private ResetCom resetCommand;
		public Player2ProjectileHandler(ResetCom resetCommand)
		{
			this.resetCommand = resetCommand;
		}

		public void Handle(Iplayer player, IProjectile projectile, Side.side side)
		{
			if (!projectile.isDead())
			{
				if (player.IfDie())
				{
					lose.SetLoseCondition(true);
					resetCommand.Execute();
				}
				else
				{
					player.GoDamaged();
					projectile.die();
				}
			}
		}
	}
}