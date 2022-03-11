using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint3
{

	interface INPC : IGameObject
	{
		bool isDead();

		void Move(int facing);


		void GoDamaged();

		Rectangle GetRect();
	}
}