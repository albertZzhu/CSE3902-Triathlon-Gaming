namespace Sprint2
{
	class MoveRightCom : ICommand
	{
		void ICommand.Execute(Player player, ISprite item, ISprite block, NPC1 enemy)
		{
			player.Move(0);
		}
	}
}
