namespace Sprint3
{
	class MoveLeftCom : ICommand
	{
		void ICommand.Execute(Player player)
		{
			player.Move(1);
		}
	}
}
