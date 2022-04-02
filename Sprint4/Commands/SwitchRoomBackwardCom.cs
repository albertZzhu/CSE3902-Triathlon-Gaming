namespace Sprint4
{
	class SwitchRoomBackwardCom : ICommand
	{
		private Level1 level1;
		public SwitchRoomBackwardCom(Level1 level)
		{
			this.level1 = level;
		}
		public void ChangePlayer(Player player)
		{
			
		}
		public void Execute()
		{
			level1.switchPre();
		}
	}
}