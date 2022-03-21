using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
	class Projectile3Com : ICommand
	{
		private Player player;

		public Projectile3Com(Player player)
		{
			this.player = player;
		}
		void ICommand.ChangePlayer(Player player)
		{
			this.player = player;
		}
		void ICommand.Execute()
		{
			player.setFireball(2);
		}
	}
}