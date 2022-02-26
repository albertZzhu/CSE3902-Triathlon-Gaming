namespace Sprint3
{
	class DamageCom : ICommand
	{
		Player player;
		public DamageCom(Player p)
        {
			player = p;
        }
		void ICommand.Execute()
		{
			player.GoDamaged();
		}
	}
}