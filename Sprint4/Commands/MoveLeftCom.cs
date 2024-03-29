﻿using Sprint4.State_Machines;

namespace Sprint4
{
	class MoveLeftCom : ICommand
	{
		private Player player;
		public MoveLeftCom(Player player)
		{
			this.player = player;
		}

		public void ChangePlayer(Player player)
		{
			this.player = player;
		}
		public void Execute()
		{
			player.Move(Facing.LEFT);
		}
	}
}
