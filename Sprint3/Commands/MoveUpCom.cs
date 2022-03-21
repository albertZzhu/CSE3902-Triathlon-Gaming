namespace Sprint3
{
	class MoveUpCom : ICommand
	{
		void ICommand.Execute(Player player)
		{
			player.Move(2);
		}
	}
}
