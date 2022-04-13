using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.State_Machines;
using System.Collections.Generic;

namespace Sprint5
{

	interface INPC : IGameObject
	{
		bool isDead();

		void Move(Facing facing);

		void die();


		void GoDamaged();

		Rectangle GetRect();
	}
}