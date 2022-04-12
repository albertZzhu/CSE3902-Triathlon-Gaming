using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
	class Projectile3Com : ICommand
	{
		private Player player;

		public Projectile3Com(Player player)
		{
			this.player = player;
		}
		public void ChangePlayer(Player player)
		{
			this.player = player;
		}
		public void Execute()
		{
			player.setFireball(2);
		}
	}
}