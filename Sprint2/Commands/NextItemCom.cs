namespace Sprint2
{
	class NextItemCom : ICommand
	{
		void ICommand.Execute(Player player, Item item, Block block, NPC1 enemy)
		{
			item.SwitchingForward();
		}
	}
}