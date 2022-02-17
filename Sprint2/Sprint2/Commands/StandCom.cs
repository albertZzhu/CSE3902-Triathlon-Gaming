namespace Sprint2
{
	class StandCom : ICommand
	{
		void ICommand.Execute(Player player, ISprite item, Block block, NPC1 enemy)
		{
			player.GoStand();
		}
	}
}
