using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5.Collision
{
	class NPC2ProjectileHandler : ICollisionHandler<INPC, IProjectile>
	{
		public NPC2ProjectileHandler()
		{

		}

		public void Handle(INPC enemy, IProjectile projectile, SideEnum side)
		{
			if (!enemy.isDead())
			{
				enemy.GoDamaged();
				projectile.die();
				Inventory.AddScore();
				Inventory.AddHiScore();
				SoundManager.Instance.PlaySound("EnemyHit");
			}
		}
	}
}