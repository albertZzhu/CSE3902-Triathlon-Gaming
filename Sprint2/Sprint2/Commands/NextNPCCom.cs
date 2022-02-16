namespace Sprint2
{
	class NextNPCCom : ICommand
	{
		private static int i = 0;
		void ICommand.Execute(Player player, ISprite item, ISprite block, NPC1 enemy)
		{
			i++;
			if (i == enemy.enemynum)
			{
				i = 0;
			}
			enemy.SetIndx(i);
			enemy.SetI(0);
		}
	}
}
