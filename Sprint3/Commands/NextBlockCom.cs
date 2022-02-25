namespace Sprint3
{
	class NextBlockCom : ICommand
	{
		void ICommand.Execute(Player player, Item item, Block block, NPC1 enemy)
		{
			block.SwitchingForward();
		}
	}
}
