namespace Sprint3
{
	class MoveRightCom : ICommand
	{
		Player player;
		
		public MoveRightCom(Player p)
        {
			player = p;
        }
		void ICommand.Execute()
		{
			player.Move(0);
		}
	}
}
