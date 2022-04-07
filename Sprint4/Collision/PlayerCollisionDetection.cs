using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Sprint4.Collision
{
	class PlayerCollisionDetection
	{

		private Player2BlockHandler blockHandle;
		private Player2EnemyHandler enemyHandle;
		private Player2ProjectileHandler projectileHandle;
		private Player2ItemHandler itemHandle;
		private Player2DoorHandler doorHandle;


		public PlayerCollisionDetection(string playerName, CollisionHandlerDict dict)
		{
			blockHandle = dict.GetPlayer2Block(playerName);
			enemyHandle = dict.GetPlayer2NPC(playerName);
			projectileHandle = dict.GetPlayer2Projectile(playerName);
			itemHandle = dict.GetPlayer2Item(playerName);
			doorHandle = dict.GetPlayer2Door(playerName);
		}

		public void Detect(Player player, IProjectile[] projectile, INPC[] npcInRange, IBlock[] blockInRange, Iitem[] itemInRange)
		{
			IBlock[] blockInRangeModified = blockInRange.Skip(1).ToArray();
			//this.projectileInRange = projectileInRange;
			int[] handleList = new int[] { 1, 1, 1, 1 };

			foreach (INPC i in npcInRange)
			{
				if (player.GetRect().Intersects(i.GetRect()))
				{
					
					enemyHandle.Handle(player, i, Side.side.right);
				}
			}

			foreach (IProjectile p in projectile)
			{
				if (player.GetRect().Intersects(p.GetRect()))
				{
					projectileHandle.Handle(player, p, Side.side.right);
				}
			}


			foreach (IBlock b in blockInRangeModified)
			{
				if (player.GetRect().Intersects(b.GetRect()))
				{
					if (b.GetType().Equals(typeof(Door)))
					{
						doorHandle.Handle(((Door)b).DoorSide());
					}
					else if(b.GetType().Equals(typeof(Block)))
					{ 
						Rectangle result = Rectangle.Intersect(player.GetRect(), b.GetRect());
						int playerX = player.GetRect().X + player.GetRect().Width / 2;
						int playerY = player.GetRect().Y + player.GetRect().Height / 2;
						int blockX = b.GetRect().X + b.GetRect().Width / 2;
						int blockY = b.GetRect().Y + b.GetRect().Height / 2;

						if (result.Width < Math.Max(player.GetRect().Width, b.GetRect().Width) && result.Height <= (player.GetRect().Height + b.GetRect().Height))
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
						if (result.Height < Math.Max(player.GetRect().Height, b.GetRect().Height) && result.Width <= (player.GetRect().Width + b.GetRect().Width))
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
				
			}
			blockHandle.Handle(player, handleList);

			foreach (Iitem i in itemInRange)
			{
				if (player.GetRect().Intersects(i.GetRect()))
				{
					itemHandle.Handle(player, i, Side.side.right);
				}
			}
		}
	}
}