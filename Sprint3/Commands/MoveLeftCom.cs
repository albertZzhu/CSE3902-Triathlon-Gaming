using Sprint3.PlayerFiles;
namespace Sprint3
{
	class MoveLeftCom : ICommand
	{
		void ICommand.Execute(Player player, Item item, Block block, NPC1 enemy)
		{
			player.Move();
		}
	}
}
