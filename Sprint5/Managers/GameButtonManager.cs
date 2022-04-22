using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
	class GameButtonManager
	{
		private Game1 game;

		private MouseState currentState;
		private MouseState prevState;

		private List<Button> buttonList;
		private GamePauseStartCom pauseStartCommand;
		private QuitCom exitCommand;

		public GameButtonManager(Game1 game)
		{
			this.game = game;
		}

		public void Initialize()
		{
			buttonList = new List<Button>();
			currentState = Mouse.GetState();

			pauseStartCommand = new GamePauseStartCom(game);
			exitCommand = new QuitCom();

			buttonList.Add(new StartPauseButton(pauseStartCommand));
			buttonList.Add(new StartExitButton(exitCommand));
		}

		public void Update(GameTime gameTime)
		{
			prevState = currentState;
			currentState = Mouse.GetState();

			Rectangle mouseRect = new Rectangle(currentState.X, currentState.Y, 1, 1);

			foreach (Button b in buttonList)
			{
				if (mouseRect.Intersects(b.GetRect())&& currentState.LeftButton == ButtonState.Pressed && !currentState.Equals(prevState))
				{
					b.Click();
					b.Update(gameTime);
				}
				if (game.level1.GetType().Equals(typeof(Level2))){
					b.ChangeGameMode();
				}
			}
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			foreach (Button b in buttonList)
			{
				b.Draw(gameTime, spriteBatch);
			}
		}
	}
}
