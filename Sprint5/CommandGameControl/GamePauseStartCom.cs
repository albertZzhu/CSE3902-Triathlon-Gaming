using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5{

	class GamePauseStartCom : IGameControlCom
	{
		private Game1 game;


		public GamePauseStartCom(Game1 game)
		{
			this.game = game;
		}

		public void Execute()
		{
			game.isPaused = !game.isPaused;
			if (game.isPaused)
            {
				SoundManager.Instance.PauseSound("DungeonTheme");
            }
            else
            {
				SoundManager.Instance.PlaySound("DungeonTheme");
			}
		}
	}
}
