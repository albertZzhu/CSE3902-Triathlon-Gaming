namespace Sprint3
{
	class DamageCom : ICommand
	{
		void ICommand.Execute(Player player)
		{
			player.GoDamaged();
		}
	}
}