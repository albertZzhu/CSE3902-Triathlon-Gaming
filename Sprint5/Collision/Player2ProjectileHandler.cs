using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5.Collision
{
	class Player2ProjectileHandler : ICollisionHandler<Iplayer, IProjectile>
	{
		private ResetCom resetCommand;
		public Player2ProjectileHandler(ResetCom resetCommand)
		{
			this.resetCommand = resetCommand;
		}

		public void Handle(Iplayer player, IProjectile projectile, SideEnum side)
		{
			if (!projectile.isDead())
			{
				if (player.IfDie())
				{
					Lose.SetLoseCondition(true);
					resetCommand.Execute();
					SoundManager.Instance.LoseMusic();
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