using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{ 
	interface Iitem : IGameObject
	{
		bool isDisappear();

		void goDisappear();

		Rectangle GetRect();
	}
}
