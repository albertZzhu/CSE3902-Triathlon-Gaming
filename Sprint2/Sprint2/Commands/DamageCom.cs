namespace Sprint2
{
	class DamageCom : ICommand
	{
		void ICommand.Execute(Player player, ISprite item, ISprite block, NPC1 enemy)
		{
			player.GoDamaged();
		}
	}
}