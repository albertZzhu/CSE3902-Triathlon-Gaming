namespace Sprint2
{
	class ResetCom : ICommand
	{
		public void Execute(Player player, ISprite item, ISprite block, NPC1 enemy)
		{
			System.Windows.Forms.Application.Exit();
		}
	}
}
