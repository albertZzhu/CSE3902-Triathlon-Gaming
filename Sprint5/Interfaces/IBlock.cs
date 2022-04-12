using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
	public interface IBlock : IGameObject
	{

		Rectangle GetRect();
		void SetLocation(Vector2 newLocation);
		void SetBlock(String blockTexture);
	}
}