using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4.Collision
{
	class Player2EnemyHandler : ICollisionHandler<Player, INPC>
	{
		private ResetCom resetCommand;
		public Player2EnemyHandler(ResetCom resetCommand)
		{
			this.resetCommand = resetCommand;
		}

		public void Handle(Player player, INPC enemy, Side.side side)
		{
			resetCommand.ChangePlayer(player);
			if (!enemy.isDead())
			{
				if (player.IfAttacking())
				{
					enemy.die();
				}
				else
				{
					if (player.IfDie())
					{
						resetCommand.Execute();
					}
					else
					{
						player.GoDamaged();
					}
				}
			}
		}
	}
}