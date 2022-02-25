namespace Sprint3
{
	class MoveRightCom : ICommand
	{
		void ICommand.Execute(Player player, Item item, Block block, NPC1 enemy)
		{
			player.Move(0);
		}
	}
}
