using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3.Collision
{
	class PlayerCollisionDetection
	{
		private string playerName;
		private Iplayer player;
		private INPC[] npcInRange;
		private IProjectile[] projectileInRange;
		private IBlock[] blockInRange;

		private Player2BlockHandler blockHandle;
		private Player2EnemyHandler enemyHandle;
		private Player2ProjectileHandler projectileHandle;

		public PlayerCollisionDetection(string playerName, Iplayer player)
		{
			this.playerName = playerName;
			this.player = player;


			this.blockHandle = CollisionHandlerDict.GetPlayer2Block(playerName);
			this.enemyHandle = CollisionHandlerDict.GetPlayer2NPC(playerName);
			this.projectileHandle = CollisionHandlerDict.GetPlayer2Projectile(playerName);
		}

		public void Detect(INPC[] npcInRange, IProjectile[] projectileInRange, IBlock[] blockInRange)
		{
			this.npcInRange = npcInRange;
			this.projectileInRange = projectileInRange;
			this.blockInRange = blockInRange;

			foreach (INPC i in npcInRange)
			{
				if (this.player.GetRect().Intersects(i.GetRect()))
				{
					this.enemyHandle.Handle(this.player, i, Side.side.right);
				}
			}

			foreach (IProjectile p in projectileInRange)
			{
				if (this.player.GetRect().Intersects(p.GetRect()))
				{
					this.projectileHandle.Handle(this.player, p, Side.side.right);
				}
			}

			foreach (IBlock b in blockInRange)
			{
				if (this.player.GetRect().Intersects(b.GetRect()))
				{
					this.blockHandle.Handle(this.player, b, Side.side.right);
				}
			}
		}
	}
}