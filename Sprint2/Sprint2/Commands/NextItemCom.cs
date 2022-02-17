namespace Sprint2
{
	class NextItemCom : ICommand
	{
		void ICommand.Execute(Player player, ISprite item, Block block, NPC1 enemy)
		{
			item.Update();
		}
	}
}