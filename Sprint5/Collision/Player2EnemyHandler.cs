using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5.Collision
{
	class Player2EnemyHandler : ICollisionHandler<Player, INPC>
	{
		private ResetCom resetCommand;
		public Player2EnemyHandler(ResetCom resetCommand)
		{
			this.resetCommand = resetCommand;
		}

		public void Handle(Player player, INPC enemy, SideEnum side)
		{
			resetCommand.ChangePlayer(player);
			if (!enemy.isDead())
			{
				if (player.IfAttacking())
				{
					enemy.GoDamaged();
					Inventory.AddScore();
					Inventory.AddHiScore();
					SoundManager.Instance.PlaySound("EnemyHit");
				}
				else
				{
					if (player.IfDie())
					{
						Lose.SetLoseCondition(true);
						resetCommand.Execute();
						SoundManager.Instance.LoseMusic();
					}
					else
					{
						ICommand tempCom = new DamageCom(player);
						tempCom.Execute();
					}
				}
			}
		}
	}
}