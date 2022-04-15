namespace Sprint5
{
    class QuitCom : IGameControlCom, ICommand
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
