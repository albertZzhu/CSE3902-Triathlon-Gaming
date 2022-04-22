using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.State_Machines;
using System.Collections.Generic;

namespace Sprint5
{

	public interface INPC : IGameObject
	{
		List<string> GetNPCHolder();

		bool isDead();

		void Move(FacingEnum facing);

		void die();

		void moveLock(FacingEnum direction);

		void moveunLock(FacingEnum direction);

		void GoDamaged();

		void BouncedBack();

		Rectangle GetRect();

		void SetNpc(ISprite npc);
	}
}