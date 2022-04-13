using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{ 
	public interface Iitem : IGameObject
	{
		public string GetItemTexture();
		bool isDisappear();

		void goDisappear();

		Rectangle GetRect();
	}
}
