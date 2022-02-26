namespace Sprint3
{
	class PrevNPCCom : ICommand
	{
		//Should have a "cycle NPCs" command because this 'i' should be the same 'i' that is in Next NPC
		private static int i = 0;
		NPC1 enemy;

		public PrevNPCCom(NPC1 e)
        {
			enemy = e;
        }
		void ICommand.Execute()
		{
			i--;
			if (i < 0)
			{
				i = enemy.GetEnemyNum() - 1;
			}
			enemy.SetIndx(i);
			enemy.SetI(0);
		}
	}
}
