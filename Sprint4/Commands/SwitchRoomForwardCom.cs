namespace Sprint4
{
	class SwitchRoomForwardCom : ICommand
	{
		private Level1 level1;
		public SwitchRoomForwardCom(Level1 level)
		{
			this.level1 = level;
		}
		void ICommand.ChangePlayer(Player player)
		{
			
		}
		void ICommand.Execute()
		{
			level1.switchNext();
			level1.loadRoom();
		}
	}
}