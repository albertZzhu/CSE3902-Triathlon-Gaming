using Sprint3.PlayerFiles;
namespace Sprint3
{
	class NextNPCCom : ICommand
	{
		private static int i = 0;
		void ICommand.Execute(Player player, Item item, Block block, NPC1 enemy)
		{
			i++;
			if (i == enemy.GetEnemyNum())
			{
				i = 0;
			}
			enemy.SetIndx(i);
			enemy.SetI(0);
		}
	}
}
