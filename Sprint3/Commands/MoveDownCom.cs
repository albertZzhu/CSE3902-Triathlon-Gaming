namespace Sprint3
{
	class MoveDownCom : ICommand
	{
		Player player;
		
		public MoveDownCom(Player p)
        {
			player = p;
        }
		void ICommand.Execute()
		{
			player.Move(3);
		}
	}
}
