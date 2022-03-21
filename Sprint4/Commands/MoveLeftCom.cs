namespace Sprint4
{
	class MoveLeftCom : ICommand
	{
		private Player player;
		public MoveLeftCom(Player player)
		{
			this.player = player;
		}

		void ICommand.ChangePlayer(Player player)
		{
			this.player = player;
		}
		void ICommand.Execute()
		{
			player.Move(1);
		}
	}
}
