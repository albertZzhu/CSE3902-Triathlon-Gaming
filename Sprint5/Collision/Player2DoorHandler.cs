using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
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

		public void Handle(SideEnum side, Door door)
		{
			if (!door.IsLocked())
			{
				if (side == SideEnum.right)
				{
					roomForwardComand.Execute();
				}
				else if (side == SideEnum.left)
				{
					roomBackCommand.Execute();
				}
				else if (side == SideEnum.up)
				{
					roomUpwardComand.Execute();
				}
				else if (side == SideEnum.down)
				{
					roomDownwardComand.Execute();
				}
			}
            else
            {
				door.UnlockDoor();
            }
		}
	}
}
