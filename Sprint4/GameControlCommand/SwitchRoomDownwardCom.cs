using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4.Commands
{
	class SwitchRoomDownwardCom : IGameControlCom
	{

		private Level1 level1;
		public SwitchRoomDownwardCom(Level1 level)
		{
			this.level1 = level;
		}

		public void Execute()
		{
		}
	}
}
