namespace Sprint2
{
	class QuitCom : ICommand
	{
		public void Execute(Player player, ISprite item, Block block, NPC1 enemy)
		{
			System.Windows.Forms.Application.Exit();
		}
	}
}
