namespace Sprint3
{
	class DamageCom : ICommand
	{
		private Player player;
		public DamageCom(Player player)
		{
			this.player = player;
		}
		void ICommand.ChangePlayer(Player player)
		{
			this.player = player;
		}

		void ICommand.Execute()
		{
			player.GoDamaged();
		}
	}
}