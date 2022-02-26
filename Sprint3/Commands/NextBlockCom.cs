namespace Sprint3
{
	class NextBlockCom : ICommand
	{
		Block block;

		public NextBlockCom(Block b)
        {
			block = b;
        }
		void ICommand.Execute()
		{
			block.SwitchingForward();
		}
	}
}
