namespace Sprint4
{
	class SwitchRoomForwardCom : ICommand
	{
		private Level1 level1;
		public SwitchRoomForwardCom(Level1 level)
		{
			this.level1 = level;
		}
		public void ChangePlayer(Player player)
		{
		}
		public void Execute()
		{
			level1.switchNext();
		}
	}
}