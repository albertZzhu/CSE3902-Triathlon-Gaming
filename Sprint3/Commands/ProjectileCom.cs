using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
	class ProjectileCom : ICommand
	{
		void ICommand.Execute(Player player)
		{
			player.setFireball(0);
		}
	}
}
