﻿namespace Sprint4
{
	class MoveRightCom : ICommand
	{
		private Player player;
		public MoveRightCom(Player player)
		{
			this.player = player;
		}
		public void ChangePlayer(Player player)
		{
			this.player = player;
		}
		public void Execute()
		{
			player.Move(State_Machines.Facing.RIGHT);
		}
	}
}
