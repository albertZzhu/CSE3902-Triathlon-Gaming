namespace Sprint4
{
	class AttackCom : ICommand
	{
		private Player player;
		public AttackCom(Player player)
		{
			this.player = player;
		}
		public void ChangePlayer(Player player)
        {
			this.player = player;
        }
		public void Execute()
		{
			player.GoAttack();
		}
	}
}