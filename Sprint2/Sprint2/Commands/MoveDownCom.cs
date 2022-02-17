namespace Sprint2
{
	class MoveDownCom : ICommand
	{
		void ICommand.Execute(Player player, ISprite item, Block block, NPC1 enemy)
		{
			player.Move(3);
		}
	}
}
