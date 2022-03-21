using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
	
	class StandCom : ICommand
	{
		private Player player;

		public StandCom(Player player)
		{
			this.player = player;
		}
		void ICommand.ChangePlayer(Player player)
		{
			this.player = player;
		}

		void ICommand.Execute()
		{
			player.GoStand();
		}
	}
}
