namespace Sprint2
{
	class AttackCom : ICommand
	{
		void ICommand.Execute(Player player, Item item, Block block, NPC1 enemy)
		{
			player.GoAttack();
		}
	}
}