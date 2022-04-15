namespace Sprint5
{
	public class SwitchRoomForwardCom : IGameControlCom
	{
		private Level1 level1;
		public SwitchRoomForwardCom(Level1 level)
		{
			this.level1 = level;
		}

		public void Execute()
		{
			level1.SwitchRoom(1);
		}
	}
}