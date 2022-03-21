namespace Sprint4
{
    class QuitCom : ICommand
	{
		void ICommand.ChangePlayer(Player player)
		{
			
		}
		public void Execute()
		{
			System.Windows.Forms.Application.Exit();
		}
	}
}
