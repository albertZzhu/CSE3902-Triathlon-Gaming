namespace Sprint2
{
	class MoveUpCom : ICommand
	{
		void ICommand.Execute(Player player, ISprite item, ISprite block, NPC1 enemy)
		{
			player.Move(2);
		}
	}
}
