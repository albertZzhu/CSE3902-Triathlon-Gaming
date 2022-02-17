namespace Sprint2
{
	class PrevNPCCom : ICommand
	{
		private static int i = 0;
		void ICommand.Execute(Player player, ISprite item, ISprite block, NPC1 enemy)
		{
			i--;
			if (i < 0)
			{
				i = enemy.enemynum - 1;
			}
			enemy.SetIndx(i);
			enemy.SetI(0);
		}
	}
}
