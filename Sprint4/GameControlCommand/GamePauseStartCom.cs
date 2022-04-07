using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4{

	class GamePauseStartCom : IGameControlCom
	{
		private Game1 game;


		public GamePauseStartCom(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			this.game.isPaused = !this.game.isPaused;
		}
	}
}
