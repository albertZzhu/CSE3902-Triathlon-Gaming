using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
	class StartExitButton : Button
	{
		private Vector2 location;
		private ISprite buttonFigure;

		private IGameControlCom exitCom;

		public StartExitButton(IGameControlCom exitCom)
		{
			location = new Vector2(700, 0);
			buttonFigure = SpriteFactory.GetSprite("exitButton");
			this.exitCom = exitCom;
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			buttonFigure.Draw(spriteBatch, location);
		}

		public override void Update(GameTime gameTime)
		{
			
		}

		public override void Click()
		{
			exitCom.Execute();
		}

		public override Rectangle GetRect()
		{
			return new Rectangle((int)location.X, (int)location.Y, (int)buttonFigure.getSize().X, (int)buttonFigure.getSize().Y);
		}
	}
}
