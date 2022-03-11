using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
	class ProjectileCom : ICommand
	{
		private Player player;

		public ProjectileCom(Player player)
		{
			this.player = player;
		}
		void ICommand.ChangePlayer(Player player)
		{
			this.player = player;
		}
		void ICommand.Execute()
		{
			player.setFireball(0);
		}
	}
}
