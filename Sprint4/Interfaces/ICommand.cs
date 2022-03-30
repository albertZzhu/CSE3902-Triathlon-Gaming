namespace Sprint4
{
	interface ICommand // implement a concrete class for each Command the user can trigger:
					   // one for each different sprite that can be set and one to quit the game.
	{
		//operates on a dictionary object? "data driven..."
		//only function is execute?
		void ChangePlayer(Player player);
		void Execute();
	}
}
