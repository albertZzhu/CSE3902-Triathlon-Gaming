namespace Sprint5
{
	public class SwitchRoomBackwardCom : IGameControlCom
	{
		private Level level1;
		public SwitchRoomBackwardCom(Level level)
		{
			this.level1 = level;
		}

		public void Execute()
		{
			level1.SwitchRoom(3);
		}
	}
}