using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{

	class InventoryCom : IGameControlCom
	{
		private Game1 game;
		public InventoryCom(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			//maybe call itemselect openmenu
		}
	}
}
