namespace Sprint2
{
	class DamageCom : ICommand
	{
		void ICommand.Execute(Player player, Item item, Block block, NPC1 enemy)
		{
			player.GoDamaged();
		}
	}
}