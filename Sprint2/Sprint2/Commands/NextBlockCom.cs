namespace Sprint2
{
	class NextBlockCom : ICommand
	{
		void ICommand.Execute(Player player, Item item, ISprite block, NPC1 enemy)
		{
			block.Update();
		}
	}
}
