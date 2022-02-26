namespace Sprint3
{
	class MoveLeftCom : ICommand
	{
		Player player;
		public MoveLeftCom(Player p)
        {
			player = p;
        }
		void ICommand.Execute()
		{
			player.Move(1);
		}
	}
}
