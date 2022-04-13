using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Sprint5.Collision
{
	class NPCCollisionDetection
	{

		private NPC2BlockHandler blockHandle;
		private NPC2ProjectileHandler projectileHandle;

		public NPCCollisionDetection(string NPCName, CollisionHandlerDict dict)
		{
			blockHandle = dict.GetNPC2Block(NPCName);
			projectileHandle = dict.GetNPC2Projectile(NPCName);
		}

		public void Detect(INPC npc, IProjectile[] projectileInRange, IBlock[] blockInRange)
		{
			IBlock[] blockInRangeModified = blockInRange.Skip(1).ToArray();

			foreach (IProjectile p in projectileInRange)
			{
				if (npc.GetRect().Intersects(p.GetRect()))
				{
					projectileHandle.Handle(npc, p, Side.side.right);
				}
			}

			foreach (IBlock b in blockInRangeModified)
			{
				if (npc.GetRect().Intersects(b.GetRect()))
				{
					blockHandle.Handle(npc, b, Side.side.right);
				}
			}
		}
	}
}