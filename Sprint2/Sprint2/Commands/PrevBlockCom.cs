namespace Sprint2
{
	class PrevBlockCom : ICommand
	{
		void ICommand.Execute(Player player, ISprite item, ISprite block, NPC1 enemy)
		{
			block.Update();
		}
	}
}
