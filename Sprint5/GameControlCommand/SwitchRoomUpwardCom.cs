using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
	public class SwitchRoomUpwardCom : IGameControlCom
	{
		
			private Level1 level1;
			public SwitchRoomUpwardCom(Level1 level)
			{
				this.level1 = level;
			}
	
			public void Execute()
			{
				level1.SwitchRoom(0);
			}
	}
}
