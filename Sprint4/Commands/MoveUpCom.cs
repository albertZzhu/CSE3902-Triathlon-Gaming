using Sprint4.State_Machines;

namespace Sprint4
{
	class MoveUpCom : ICommand
	{
		private Player player;

		public MoveUpCom(Player player)
		{
			this.player = player;
		}
		public void ChangePlayer(Player player)
		{
			this.player = player;
		}
		public void Execute()
		{
			player.Move(Facing.UP);
		}
	}
}
