﻿namespace Sprint3
{
	interface IController
	{
		//if pressed? need getState
		//cannot declare instance variables in an interface. want KeyboardState obj (more generally tho)

		//Called in initialize
		void InitializeController();

		//Updates inputs
		//called in update
		void CompareStates(Player player, Item item, Block block, NPC1 enemy);


	}
}
