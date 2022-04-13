using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint4.State_Machines;

namespace Sprint4
{
	interface Iplayer : IGameObject
	{
		void Move(Facing facing);

		Rectangle GetRect();

		ISprite GetSprite();

		void GoDamaged();

		void GoStand();

		void Reset();

		void moveLock(Facing direction);

		void moveunLock(Facing direction);

		bool IfAttacking();

		bool IfDie();

		Vector2 GetLocation();
	}
}