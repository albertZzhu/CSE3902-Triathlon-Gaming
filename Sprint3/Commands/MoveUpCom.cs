namespace Sprint3
{
	class MoveUpCom : ICommand
	{
		Player player;

		public MoveUpCom(Player p)
        {
			player = p;
        }
		void ICommand.Execute()
		{
			player.Move(2);
		}
	}
}
