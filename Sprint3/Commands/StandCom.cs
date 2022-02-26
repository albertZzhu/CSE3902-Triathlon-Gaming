using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
	class StandCom : ICommand
	{
		Player player;

		public StandCom(Player p)
        {
			player = p;
        }
		void ICommand.Execute()
		{
			player.GoStand();
		}
	}
}
