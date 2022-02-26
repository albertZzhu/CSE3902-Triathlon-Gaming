namespace Sprint3
{
	class NextItemCom : ICommand
	{
		Item item;
		public NextItemCom(Item i)
        {
			item = i;
        }
		void ICommand.Execute()
		{
			item.SwitchingForward();
		}
	}
}