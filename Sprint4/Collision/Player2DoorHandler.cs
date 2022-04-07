using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4.Collision
{
	class Player2DoorHandler
	{
		private SwitchRoomBackwardCom roomBackCommand;
		private SwitchRoomForwardCom roomForwardComand;

		public Player2DoorHandler(SwitchRoomBackwardCom roomBackCommand, SwitchRoomForwardCom roomForwardComand)
		{
			this.roomBackCommand = roomBackCommand;
			this.roomForwardComand = roomForwardComand;

		}

		public void Handle(Side.side side)
		{
			if (side == Side.side.right)
			{
				roomForwardComand.Execute();
			}else if(side == Side.side.left)
			{
				roomBackCommand.Execute();
			}
		}
	}
}
