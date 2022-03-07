using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3.Collision
{
	class NPCCollisionDetection
	{
		private string NPCName;
		private INPC npc;
		private IProjectile[] projectileInRange;
		private IBlock[] blockInRange;

		private NPC2BlockHandler blockHandle;
		private NPC2ProjectileHandler projectileHandle;

		public NPCCollisionDetection(string NPCName, INPC npc)
		{
			this.NPCName = NPCName;
			this.npc = npc;


			this.blockHandle = CollisionHandlerDict.GetNPC2Block(NPCName);
			this.projectileHandle = CollisionHandlerDict.GetNPC2Projectile(NPCName);
		}

		public void Detect(IProjectile[] projectileInRange, IBlock[] blockInRange)
		{
			this.projectileInRange = projectileInRange;
			this.blockInRange = blockInRange;

			foreach (IProjectile p in projectileInRange)
			{
				if (this.npc.GetRect().Intersects(p.GetRect()))
				{
					this.projectileHandle.Handle(this.npc, p, Side.side.right);
				}
			}

			foreach (IBlock b in blockInRange)
			{
				if (this.npc.GetRect().Intersects(b.GetRect()))
				{
					this.blockHandle.Handle(this.npc, b, Side.side.right);
				}
			}
		}
	}
}
