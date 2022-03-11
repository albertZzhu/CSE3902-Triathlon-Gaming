using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Sprint3.Collision
{
	class PlayerCollisionDetection
	{
		private string playerName;
		private INPC[] npcInRange;
		private IProjectile[] projectileInRange;
		private IBlock[] blockInRange;

		private Player2BlockHandler blockHandle;
		private Player2EnemyHandler enemyHandle;
		private Player2ProjectileHandler projectileHandle;

		public PlayerCollisionDetection(string playerName, CollisionHandlerDict dict)
		{
			this.playerName = playerName;


			this.blockHandle = dict.GetPlayer2Block(playerName);
			this.enemyHandle = dict.GetPlayer2NPC(playerName);
			this.projectileHandle = dict.GetPlayer2Projectile(playerName);
		}

		public void Detect(Iplayer player, IProjectile[] projectile, INPC[] npcInRange, IBlock[] blockInRange)
		{
			IBlock[] blockInRangeModified = blockInRange.Skip(1).ToArray();
			//this.projectileInRange = projectileInRange;

			foreach (INPC i in npcInRange)
			{
				if (player.GetRect().Intersects(i.GetRect()))
				{
					
					this.enemyHandle.Handle(player, i, Side.side.right);
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
					if (player.GetRect().Right >= b.GetRect().Left)
					{
						this.blockHandle.Handle(player, b, Side.side.right);
					}
					else
					{
						this.blockHandle.unHandle(player, b, Side.side.right);
					}
					if (player.GetRect().Left <= b.GetRect().Right)
					{
						this.blockHandle.Handle(player, b, Side.side.left);
					}
					else
					{
						this.blockHandle.unHandle(player, b, Side.side.left);
					}
					if (player.GetRect().Top <= b.GetRect().Bottom)
					{
						this.blockHandle.Handle(player, b, Side.side.up);
					}
					else
					{
						this.blockHandle.unHandle(player, b, Side.side.up);
					}
					if (player.GetRect().Bottom >= b.GetRect().Top)
					{
						this.blockHandle.Handle(player, b, Side.side.down);
					}
					else
					{
						this.blockHandle.unHandle(player, b, Side.side.down);
					}

				}
				else
				{
					if (!(player.GetRect().Right >= b.GetRect().Left))
					{
						this.blockHandle.unHandle(player, b, Side.side.right);
					}
					if (!(player.GetRect().Left <= b.GetRect().Right))
					{
						this.blockHandle.unHandle(player, b, Side.side.left);
					}
					if (!(player.GetRect().Top <= b.GetRect().Bottom))
					{
						this.blockHandle.unHandle(player, b, Side.side.up);
					}
					if (!(player.GetRect().Bottom >= b.GetRect().Top))
					{
						this.blockHandle.unHandle(player, b, Side.side.down);
					}
				}
			}
		}
	}
}