namespace Sprint5
{
	public class SwitchRoomBackwardCom : IGameControlCom
	{
		private Level1 level1;
		public SwitchRoomBackwardCom(Level1 level)
		{
			this.level1 = level;
		}

		public void Execute()
		{
			level1.SwitchRoom(3);
		}
	}
}