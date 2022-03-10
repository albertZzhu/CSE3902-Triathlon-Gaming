using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Collision
{
	class CollisionHandlerDict
	{
		private static Dictionary<string, Player2EnemyHandler> player2NPCList;
		private static Dictionary<string, Player2BlockHandler> player2BlockList;
		private static Dictionary<string, Player2ProjectileHandler> player2ProjectileList;
		private static Dictionary<string, NPC2BlockHandler> NPC2BlockList;
		private static Dictionary<string, NPC2ProjectileHandler> NPC2ProjectileList;
		private static Dictionary<string, Projectile2BlockHandler> projectile2BlockList;

		public CollisionHandlerDict()
		{

		}

		public static void Initialize()
		{
			player2NPCList = new Dictionary<string, Player2EnemyHandler>();
			player2BlockList = new Dictionary<string, Player2BlockHandler>();
			player2ProjectileList = new Dictionary<string, Player2ProjectileHandler>();
			NPC2BlockList = new Dictionary<string, NPC2BlockHandler>();
			NPC2ProjectileList = new Dictionary<string, NPC2ProjectileHandler>();
			projectile2BlockList = new Dictionary<string, Projectile2BlockHandler>();
		}

		public void AddHandler(string playerName, Player2EnemyHandler handler)
		{
			player2NPCList.Add(playerName, handler);
		}

		public void AddHandler(string playerName, Player2BlockHandler handler)
		{
			player2BlockList.Add(playerName, handler);
		}

		public void AddHandler(string playerName, Player2ProjectileHandler handler)
		{
			player2ProjectileList.Add(playerName, handler);
		}

		public void AddHandler(string NPCname, NPC2BlockHandler handler)
		{
			NPC2BlockList.Add(NPCname, handler);
		}

		public void AddHandler(string NPCname, NPC2ProjectileHandler handler)
		{
			NPC2ProjectileList.Add(NPCname, handler);
		}

		public void AddHandler(string Projectilename, Projectile2BlockHandler handler)
		{
			projectile2BlockList.Add(Projectilename, handler);
		}

		public static Player2EnemyHandler GetPlayer2NPC(string name)
		{
			return player2NPCList[name];
		}

		public static Player2BlockHandler GetPlayer2Block(string name)
		{
			return player2BlockList[name];
		}

		public static Player2ProjectileHandler GetPlayer2Projectile(string name)
		{
			return player2ProjectileList[name];
		}

		public static NPC2BlockHandler GetNPC2Block(string name)
		{
			return NPC2BlockList[name];
		}

		public static NPC2ProjectileHandler GetNPC2Projectile(string name)
		{
			return NPC2ProjectileList[name];
		}

		public static Projectile2BlockHandler GetProjectile2Block(string name)
		{
			return projectile2BlockList[name];
		}
	}
}