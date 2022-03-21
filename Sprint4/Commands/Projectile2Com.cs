using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
	class Projectile2Com : ICommand
	{
		private Player player;

		public Projectile2Com(Player player)
		{
			this.player = player;
		}
		void ICommand.ChangePlayer(Player player)
		{
			this.player = player;
		}
		void ICommand.Execute()
		{
			player.setFireball(1);
		}
	}
}