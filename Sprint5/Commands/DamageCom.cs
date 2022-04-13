﻿namespace Sprint5
{
	class DamageCom : ICommand
	{
		private Player player;
		public DamageCom(Player player)
		{
			this.player = player;
		}
		public void ChangePlayer(Player player)
		{
			this.player = player;
		}

		public void Execute()
		{
			player.GoDamaged();
			SoundManager.Instance.PlaySound("PlayerDamaged");
		}
	}
}