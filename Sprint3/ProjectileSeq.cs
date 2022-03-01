using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace Sprint3
{
	class ProjectileSeq
	{
		private ArrayList list;
		float bias = 30;
		float biasfireball = 16;
		public ProjectileSeq()
		{
			list = new ArrayList();
		}

		public void NewProjectile(Vector2 newLocation, Facing facing, int sprite)
		{
			switch (sprite)
			{ //add more
				case 2:
					{
						switch (facing)
						{
							case Facing.RIGHT:
								list.Add(new Projectile(newLocation, facing, SpriteFactory.GetSprite("projectileRight")));
								break;
							case Facing.LEFT:
								list.Add(new Projectile(newLocation, facing, SpriteFactory.GetSprite("projectileLeft")));
								break;
							case Facing.UP:
								list.Add(new Projectile(new Vector2(newLocation.X -bias, newLocation.Y), facing, SpriteFactory.GetSprite("projectileUp")));
								break;
							case Facing.DOWN:
								list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), facing, SpriteFactory.GetSprite("projectileDown")));
								break;
						}
					}
					break;
				case 0:
					{
						switch (facing)
						{
							case Facing.RIGHT:
								list.Add(new Projectile(newLocation, facing, SpriteFactory.GetSprite("fireballright")));
								break;
							case Facing.LEFT:
								list.Add(new Projectile(newLocation, facing, SpriteFactory.GetSprite("fireballleft")));
								break;
							case Facing.UP:
								list.Add(new Projectile(new Vector2(newLocation.X - biasfireball, newLocation.Y), facing, SpriteFactory.GetSprite("fireballup")));
								break;
							case Facing.DOWN:
								list.Add(new Projectile(new Vector2(newLocation.X - biasfireball, newLocation.Y), facing, SpriteFactory.GetSprite("fireballdown")));
								break;
						}
					}
					break;
                case 1:
					{
						switch (facing)
						{
							case Facing.RIGHT:
								list.Add(new Projectile(newLocation, facing, SpriteFactory.GetSprite("heart")));
								break;
							case Facing.LEFT:
								list.Add(new Projectile(newLocation, facing, SpriteFactory.GetSprite("heart")));
								break;
							case Facing.UP:
								list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), facing, SpriteFactory.GetSprite("heart")));
								break;
							case Facing.DOWN:
								list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), facing, SpriteFactory.GetSprite("heart")));
								break;
						}
					}
					break;
				default:
					break;

			}

		}

		public void Update()
		{
			foreach (Projectile p in list)
			{
				p.Update();
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (Projectile p in list)
			{
				p.Draw(spriteBatch);
			}
		}
	}
}
