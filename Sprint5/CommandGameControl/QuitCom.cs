namespace Sprint5
{
    class QuitCom : IGameControlCom
	{
		public void Execute()
		{
			System.Windows.Forms.Application.Exit();
		}
	}
}
