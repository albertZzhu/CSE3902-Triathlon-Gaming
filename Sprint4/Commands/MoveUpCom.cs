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
		void ICommand.ChangePlayer(Player player)
		{
			this.player = player;
		}
		void ICommand.Execute()
		{
			player.Move(Facing.UP);
		}
	}
}
