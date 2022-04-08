using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
	class Player2DoorHandler
	{
		private SwitchRoomBackwardCom roomBackCommand;
		private SwitchRoomForwardCom roomForwardComand;
		private SwitchRoomUpwardCom roomUpwardComand;
		private SwitchRoomDownwardCom roomDownwardComand;


		public Player2DoorHandler(SwitchRoomBackwardCom roomBackCommand, SwitchRoomForwardCom roomForwardComand, SwitchRoomUpwardCom roomUpwardComand, SwitchRoomDownwardCom roomDownwardComand)
		{
			this.roomBackCommand = roomBackCommand;
			this.roomForwardComand = roomForwardComand;
			this.roomUpwardComand = roomUpwardComand;
			this.roomDownwardComand = roomDownwardComand;
		}

		public void Handle(Side.side side)
		{
			if (side == Side.side.right)
			{
				roomForwardComand.Execute();
			}else if(side == Side.side.left)
			{
				roomBackCommand.Execute();
			}else if (side == Side.side.up)
			{
				roomUpwardComand.Execute();
			}else if (side == Side.side.down)
			{
				roomDownwardComand.Execute();
			}
		}
	}
}
