using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
	class ProjectileCom : ICommand
	{
		Player player;

		public ProjectileCom(Player p)
        {
			player = p;
        }

		void ICommand.Execute()
		{
			player.setFireball(0);
		}
	}
}
