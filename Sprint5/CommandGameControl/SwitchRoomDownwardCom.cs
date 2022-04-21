using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
	public class SwitchRoomDownwardCom : IGameControlCom
	{

		private Level level1;
		public SwitchRoomDownwardCom(Level level)
		{
			this.level1 = level;
		}

		public void Execute()
		{
			level1.SwitchRoom(2);
		}
	}
}
