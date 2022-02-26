namespace Sprint3
{
    class AttackCom : ICommand
    {
        Player player;
        public void Execute()
        {
            player.GoAttack();
        }

        public AttackCom(Player p)
        {
            player = p;
        }
    }
}