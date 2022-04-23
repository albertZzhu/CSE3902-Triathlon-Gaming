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
			int[] handleList = new int[] { 1, 1, 1, 1 };
			IBlock[] blockInRangeModified = blockInRange.Skip(1).ToArray();

			foreach (IProjectile p in projectileInRange)
			{
				if (npc.GetRect().Intersects(p.GetRect()))
				{
					projectileHandle.Handle(npc, p, SideEnum.right);
				}
			}
			if (!npc.GetType().Equals(typeof(NPCwithAstar)))
			{
				foreach (IBlock b in blockInRangeModified)
				{
					if (npc.GetRect().Intersects(b.GetRect())&&(b.GetType().Equals(typeof(Block))|| b.GetType().Equals(typeof(MoveableBlock))))
					{
						Rectangle result = Rectangle.Intersect(npc.GetRect(), b.GetRect());
						int playerX = npc.GetRect().X + npc.GetRect().Width / 2;
						int playerY = npc.GetRect().Y + npc.GetRect().Height / 2;
						int blockX = b.GetRect().X + b.GetRect().Width / 2;
						int blockY = b.GetRect().Y + b.GetRect().Height / 2;

						if (result.Width < Math.Max(npc.GetRect().Width, b.GetRect().Width) && result.Height <= (npc.GetRect().Height + b.GetRect().Height))
						{
							if (playerX < blockX)
							{
								handleList[0] = 0;
							}
							else
							{
								handleList[1] = 0;
							}
						}
						if (result.Height < Math.Max(npc.GetRect().Height, b.GetRect().Height) && result.Width <= (npc.GetRect().Width + b.GetRect().Width))
						{
							if (playerY > blockY)
							{
								handleList[2] = 0;
							}
							else
							{
								handleList[3] = 0;
							}
						}
					}
				}
				blockHandle.Handle(npc, handleList);
			}
		}
	}
}