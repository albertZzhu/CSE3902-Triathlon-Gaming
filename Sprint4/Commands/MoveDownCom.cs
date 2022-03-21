namespace Sprint4
{
	class MoveDownCom : ICommand
	{
		private Player player;
		public MoveDownCom(Player player)
		{
			this.player = player;
		}

		void ICommand.ChangePlayer(Player player)
		{
			this.player = player;
		}
		void ICommand.Execute()
		{
			player.Move(3);
		}
	}
}
