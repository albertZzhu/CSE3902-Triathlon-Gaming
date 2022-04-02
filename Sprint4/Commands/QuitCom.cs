namespace Sprint4
{
    class QuitCom : ICommand
	{
		public void ChangePlayer(Player player)
		{
			
		}
		public void Execute()
		{
			System.Windows.Forms.Application.Exit();
		}
	}
}
