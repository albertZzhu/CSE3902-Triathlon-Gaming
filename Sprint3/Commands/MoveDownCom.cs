namespace Sprint3
{
	class MoveDownCom : ICommand
	{
		void ICommand.Execute(Player player)
		{
			player.Move(3);
		}
	}
}
