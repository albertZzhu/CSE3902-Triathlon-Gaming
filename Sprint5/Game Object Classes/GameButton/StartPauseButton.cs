using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
	class StartPauseButton : Button
	{		
		private Vector2 location;
		private ISprite buttonFigure;
		private bool isStopped;

		private IGameControlCom pauseStartCom;

		public StartPauseButton(IGameControlCom pauseStartCom)
		{
			location = new Vector2(600,0);
			buttonFigure = SpriteFactory.GetSprite("pauseButton");
			this.pauseStartCom = pauseStartCom;

			isStopped = false;
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			buttonFigure.Draw(spriteBatch, location);
		}

		public override void Update(GameTime gameTime)
		{
			if (isStopped) buttonFigure = SpriteFactory.GetSprite("playButton");
			else buttonFigure = SpriteFactory.GetSprite("pauseButton");
		}

		public override void ChangeGameMode()
		{
			location = new Vector2(1400, 0);
		}

		public override void Click()
		{
			isStopped = !isStopped;
			pauseStartCom.Execute();
		}

		public override Rectangle GetRect()
		{
			return new Rectangle((int)location.X, (int)location.Y, (int)buttonFigure.getSize().X, (int)buttonFigure.getSize().Y);
		}
	}
}
