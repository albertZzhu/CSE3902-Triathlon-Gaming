namespace Sprint5
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
			player.Move(FacingEnum.DOWN);
		}
	}
}
