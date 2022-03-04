using System;
using System.Collections.Generic;
using System.Text;

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

		public PlayerCollisionDetection(string playerName, Iplayer player, INPC[] npcInRange, IProjectile[] projectileInRange, IBlock[] blockInRange)
		{
			this.playerName = playerName;
			this.player = player;
			this.npcInRange = npcInRange;
			this.projectileInRange = projectileInRange;
			this.blockInRange = blockInRange;

			this.blockHandle = CollisionHandlerDict.GetPlayer2Block(playerName);
			this.enemyHandle = CollisionHandlerDict.GetPlayer2NPC(playerName);
			this.projectileHandle = CollisionHandlerDict.GetPlayer2Projectile(playerName);
		}

		public void Detect()
		{
			foreach(INPC i in npcInRange)
		}
	}
}
