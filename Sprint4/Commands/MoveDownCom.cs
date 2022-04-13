namespace Sprint4
{
	class MoveDownCom : ICommand
	{
		private Player player;
		public MoveDownCom(Player player)
		{
			this.player = player;
		}

		public void ChangePlayer(Player player)
		{
			this.player = player;
		}
		public void Execute()
		{
			player.Move(State_Machines.Facing.DOWN);
		}
	}
}
