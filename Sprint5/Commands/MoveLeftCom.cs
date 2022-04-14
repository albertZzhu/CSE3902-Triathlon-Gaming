using Sprint5.State_Machines;

namespace Sprint5
{
	class MoveLeftCom : ICommand
	{
		private Player player;
		public MoveLeftCom(Player player)
		{
			this.player = player;
		}

		public void ChangePlayer(Player player)
		{
			this.player = player;
		}
		public void Execute()
		{
			player.Move(FacingEnum.LEFT);
		}
	}
}
