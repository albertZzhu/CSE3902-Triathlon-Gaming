namespace Sprint3
{
	class AttackCom : ICommand
	{
		void ICommand.Execute(Player player)
		{
			player.GoAttack();
		}
	}
}