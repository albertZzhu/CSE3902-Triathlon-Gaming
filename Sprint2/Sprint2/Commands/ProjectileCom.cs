namespace Sprint2
{
	class ProjectileCom : ICommand
	{
		void ICommand.Execute(Player player, ISprite item, ISprite block, NPC1 enemy)
		{
			player.DistantAttack();
		}
	}
}
