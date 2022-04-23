using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.State_Machines;

namespace Sprint5
{
	interface Iplayer : IGameObject
	{
		void Move(FacingEnum facing);

		Rectangle GetRect();

		ISprite GetSprite();

		void GoDamaged();

		void GoStand();

		void Reset();

		PlayerStateMachine GetState();

		void moveLock(FacingEnum direction);

		void moveunLock(FacingEnum direction);

		bool IfAttacking();

		bool IfDie();

		Vector2 GetLocation();
	}
}