namespace Sprint4
{
	class MoveRightCom : ICommand
	{
		private Player player;
		public MoveRightCom(Player player)
		{
			this.player = player;
		}
		void ICommand.ChangePlayer(Player player)
		{
			this.player = player;
		}
		void ICommand.Execute()
		{
			player.Move(0);
		}
	}
}
