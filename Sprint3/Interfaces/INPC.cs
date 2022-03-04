using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint3
{
	interface INPC
	{
		void Move(int facing);

		void Update();

		void GoDamaged();

		public Vector2 GetLocation();
	}
}
