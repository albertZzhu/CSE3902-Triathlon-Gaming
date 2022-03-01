using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint3.PlayerFiles;

namespace Sprint3.PlayerFiles
{
	class PlayerStateMachine
	{

		private Player player;

		private IState state;

		private Vector2 location;
		private Vector2 bounds;

		private PlayerFacingMachine facing = new PlayerFacingMachine();


		public PlayerStateMachine(Player play, Vector2 bound)
		{
			this.player = play;
			location = new Vector2(50, 50);
			bounds = bound;
		}

		public PlayerFacingMachine GetFacingMachine()
        {
			return facing;
        }

		public Vector2 GetLocation()
        {
			return location;
        }

		public void SetLocation(Vector2 newLocation)
        {
			location = newLocation;
        }

		public void ResetLocation()
        {
			location = new Vector2(50, 50);

		}

		//not sure if this function is bad to have or not
		public Player GetPlayer()
        {
			return player;
        }

		public void Move()
        {
			state = new PlayerMovingState(this);
			state.Move(); //pass gametime? how does it move. it has access to these methods...
			//change location?
        }

		public void Attack()
        {
			state = new PlayerAttackState(this);
			state.Attack();
        }

		public void Update(GameTime gameTime)
		{
			
		}
	}
}

