using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
	interface Iplayer : IGameObject
	{
		void Move(int facing);

		Rectangle GetRect();

		ISprite GetSprite();

		void GoDamaged();

		void GoStand();

		void Reset();

		void moveLock(int direction);

		void moveunLock(int direction);
	}
}