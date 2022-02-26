namespace Sprint3
{
	class NextNPCCom : ICommand
	{
		//This should probably be an interface type
		NPC1 enemy;
		private static int i = 0;
		public NextNPCCom(NPC1 e)
        {
			enemy = e;
        }
		void ICommand.Execute()
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
