using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
	class Projectile2Com : ICommand
	{
		private Player player;

		public Projectile2Com(Player player)
		{
			this.player = player;
		}
		public void ChangePlayer(Player player)
		{
			this.player = player;
		}
		public void Execute()
		{
			player.setFireball(1);
		}
	}
}