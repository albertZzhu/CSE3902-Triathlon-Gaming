namespace Sprint3
{
	class AttackCom : ICommand
	{
		private Player player;
		public AttackCom(Player player)
		{
			this.player = player;
		}
		void ICommand.ChangePlayer(Player player)
        {
			this.player = player;
        }
		void ICommand.Execute()
		{
			player.GoAttack();
		}
	}
}