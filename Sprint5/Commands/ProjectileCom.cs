using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
	class ProjectileCom : ICommand
	{
		private Player player;

		public ProjectileCom(Player player)
		{
			this.player = player;
		}
		public void ChangePlayer(Player player)
		{
			this.player = player;
		}
		public void Execute()
		{
			player.setFireball(0);
		}
	}
}
