using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint4
{

	interface INPC : IGameObject
	{
		bool isDead();

		void Move(int facing);

		void die();


		void GoDamaged();

		Rectangle GetRect();
	}
}