namespace Sprint2
{
	class NextBlockCom : ICommand
	{
		void ICommand.Execute(Player player, ISprite item, Block block, NPC1 enemy)
		{
			block.SwitchingForward();
		}
	}
}
