namespace Sprint2
{
	interface ICommand // implement a concrete class for each Command the user can trigger:
					   // one for each different sprite that can be set and one to quit the game.
	{
		//operates on a dictionary object? "data driven..."
		//only function is execute?

		void Execute(Player player, ISprite item, Block block, NPC1 enemy);
	}
}
