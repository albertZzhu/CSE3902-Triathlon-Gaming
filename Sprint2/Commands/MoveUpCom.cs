namespace Sprint2
{
	class MoveUpCom : ICommand
	{
		void ICommand.Execute(Player player, Item item, Block block, NPC1 enemy)
		{
			player.Move(2);
		}
	}
}
