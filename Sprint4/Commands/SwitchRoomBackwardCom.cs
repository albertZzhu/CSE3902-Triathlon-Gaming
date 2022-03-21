namespace Sprint4
{
	class SwitchRoomBackwardCom : ICommand
	{
		private Level1 level1;
		public SwitchRoomBackwardCom(Level1 level)
		{
			this.level1 = level;
		}
		void ICommand.ChangePlayer(Player player)
		{
			
		}
		void ICommand.Execute()
		{
			level1.switchPre();
			level1.loadRoom();
		}
	}
}