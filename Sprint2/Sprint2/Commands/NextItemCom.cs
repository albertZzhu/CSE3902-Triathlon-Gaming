namespace Sprint2
{
	class NextItemCom : ICommand
	{
		void ICommand.Execute(Player player, Item item, Block block, NPC1 enemy)
		{
			int i = item.GetIndex() + 1;
			if (i < item.GetItemList().Count - 1)
				item.SetIndex(i);
			else
				item.SetIndex(0);
		}
	}
}