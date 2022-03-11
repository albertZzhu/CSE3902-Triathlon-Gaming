namespace Sprint3
{
	class SwitchRoomBackwardCom : ICommand
	{
		public Level1 level1;
		public SwitchRoomBackwardCom(Level1 level)
		{
			this.level1 = level;
		}
		void ICommand.Execute(Player player)
		{
			level1.switchPre();
			level1.loadRoom();
		}
	}
}