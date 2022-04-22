using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Sprint5.Collision
{
	class PlayerCollisionDetection
	{

		private Player2BlockHandler blockHandle;
		private Player2EnemyHandler enemyHandle;
		private Player2ProjectileHandler projectileHandle;
		private Player2ItemHandler itemHandle;
		private Player2DoorHandler doorHandle;
		private Player2MoveableBlockHandler moveableBlockHandler;
		private MoveableBlock2BlockHandler block2Block;


		public PlayerCollisionDetection(string playerName, CollisionHandlerDict dict)
		{
			blockHandle = dict.GetPlayer2Block(playerName);
			enemyHandle = dict.GetPlayer2NPC(playerName);
			projectileHandle = dict.GetPlayer2Projectile(playerName);
			itemHandle = dict.GetPlayer2Item(playerName);
			doorHandle = dict.GetPlayer2Door(playerName);
			moveableBlockHandler = dict.GetPlayer2MoveableBlock(playerName);
			block2Block = dict.GetBlock2Block(playerName);
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
					
					enemyHandle.Handle(player, i, SideEnum.right);
				}
			}

			foreach (IProjectile p in projectile)
			{
				if (player.GetRect().Intersects(p.GetRect()))
				{
					projectileHandle.Handle(player, p, SideEnum.right);
				}
			}


			foreach (IBlock b in blockInRangeModified)
			{
				if (player.GetRect().Intersects(b.GetRect()))
				{
					if (b.GetType().Equals(typeof(Door)))
					{
						doorHandle.Handle(((Door)b).DoorSide(), (Door)b);
					}
					else if (b.GetType().Equals(typeof(Sand)))
					{
						
					}else if (b.GetType().Equals(typeof(MoveableBlock)))
					{
						if (((MoveableBlock)b).GetMoveLockState((FacingEnum)player.GetState().FacingState()))
						{
							moveableBlockHandler.Handle(player, (MoveableBlock)b);
							int[] blockHandleList = new int[] { 1, 1, 1, 1 };
							foreach (IBlock a in blockInRangeModified)
							{
								if (b != a && b.GetRect().Intersects(a.GetRect()))
								{
									Rectangle result = Rectangle.Intersect(b.GetRect(), a.GetRect());
									int block1X = a.GetRect().X + a.GetRect().Width / 2;
									int block1Y = a.GetRect().Y + a.GetRect().Height / 2;
									int block2X = b.GetRect().X + b.GetRect().Width / 2;
									int block2Y = b.GetRect().Y + b.GetRect().Height / 2;
									if (result.Width < Math.Max(b.GetRect().Width, a.GetRect().Width) && result.Height <= (b.GetRect().Height + a.GetRect().Height))
									{
										if (block2X < block1X)
										{
											blockHandleList[0] = 0;
										}
										else
										{
											blockHandleList[1] = 0;
										}
									}
									if (result.Height < Math.Max(b.GetRect().Height, a.GetRect().Height) && result.Width <= (b.GetRect().Width + a.GetRect().Width))
									{
										if (block2Y > block1Y)
										{
											blockHandleList[2] = 0;
										}
										else
										{
											blockHandleList[3] = 0;
										}
									}
								}
							}
							//to fill
							block2Block.Handle((MoveableBlock)b, blockHandleList);
						}
						else
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
					else
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
					itemHandle.Handle(player, i, SideEnum.right);
				}
			}
		}
	}
}