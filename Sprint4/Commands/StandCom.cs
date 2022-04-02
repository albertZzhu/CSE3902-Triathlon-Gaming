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
		public void ChangePlayer(Player player)
		{
			this.player = player;
		}

		public void Execute()
		{
			player.GoStand();
		}
	}
}
