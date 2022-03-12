using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Sprint3.Collision
{
	class NPCCollisionDetection
	{
		private string NPCName;
		private IProjectile[] projectileInRange;
		private IBlock[] blockInRange;

		private NPC2BlockHandler blockHandle;
		private NPC2ProjectileHandler projectileHandle;

		public NPCCollisionDetection(string NPCName, CollisionHandlerDict dict)
		{
			this.NPCName = NPCName;


			this.blockHandle = dict.GetNPC2Block(NPCName);
			this.projectileHandle = dict.GetNPC2Projectile(NPCName);
		}

		public void Detect(INPC npc, IProjectile[] projectileInRange, IBlock[] blockInRange)
		{
			this.projectileInRange = projectileInRange;
			this.blockInRange = blockInRange;
			IBlock[] blockInRangeModified = blockInRange.Skip(1).ToArray();

			foreach (IProjectile p in projectileInRange)
			{
				if (npc.GetRect().Intersects(p.GetRect()))
				{
					this.projectileHandle.Handle(npc, p, Side.side.right);
				}
			}

			foreach (IBlock b in blockInRangeModified)
			{
				if (npc.GetRect().Intersects(b.GetRect()))
				{
					this.blockHandle.Handle(npc, b, Side.side.right);
				}
			}
		}
	}
}