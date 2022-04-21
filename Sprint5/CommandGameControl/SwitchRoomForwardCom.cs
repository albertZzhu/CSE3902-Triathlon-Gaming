namespace Sprint5
{
	public class SwitchRoomForwardCom : IGameControlCom
	{
		private Level level1;
		public SwitchRoomForwardCom(Level level)
		{
			this.level1 = level;
		}

		public void Execute()
		{
			level1.SwitchRoom(1);
		}
	}
}