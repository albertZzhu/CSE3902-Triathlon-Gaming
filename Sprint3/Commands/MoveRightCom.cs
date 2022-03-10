namespace Sprint3
{
	class MoveRightCom : ICommand
	{
		void ICommand.Execute(Player player)
		{
			player.Move(0);
		}
	}
}
