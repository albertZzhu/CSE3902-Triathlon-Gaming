namespace Sprint2
{
	class NextItemCom : ICommand
	{
		void ICommand.Execute(Player player, Item item, ISprite block, NPC1 enemy)
		{
			item.SetIndex(item.GetIndex()+1);
		}
	}
}