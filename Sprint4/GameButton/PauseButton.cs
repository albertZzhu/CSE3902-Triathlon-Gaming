using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4.GameButton
{
	class PauseButton : Button
	{
		private event EventHandler click;
		private Texture2D texture;


		public PauseButton(Texture2D texture)
		{
			this.texture = texture;
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			
		}

		public override void Update(GameTime gameTime)
		{

		}

		public void PauseClick(object sender, EventArgs e)
		{

		}
	}
}
