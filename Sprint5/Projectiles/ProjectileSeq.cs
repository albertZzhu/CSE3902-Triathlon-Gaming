using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.State_Machines;
using System.Collections;
using System.Collections.Generic;

namespace Sprint5
{
	class ProjectileSeq
	{
		private List<Projectile> list;
		float bias = 30;
		float biasfireball = 16;
		public ProjectileSeq()
		{
			list = new List<Projectile>();
		}

		public void NewProjectile(Vector2 newLocation, FacingEnum direction, int sprite)
		{
			switch (sprite)
			{ //add more
				case (int)ProjectileEnum.SPEAR:
					{
						SoundManager.Instance.PlaySound("Spear");
						switch (direction)
						{
							case FacingEnum.RIGHT:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("right_projectile")));
								break;
							case FacingEnum.LEFT:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("left_projectile")));
								break;
							case FacingEnum.UP:
								list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), direction, SpriteFactory.GetSprite("up_projectile")));
								break;
							case FacingEnum.DOWN:
								list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), direction, SpriteFactory.GetSprite("down_projectile")));
								break;
						}
					}
					break;
				case (int)ProjectileEnum.FIREBALL:
					{
						SoundManager.Instance.PlaySound("Fireball");
						switch (direction)
						{
							case FacingEnum.RIGHT:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("fireballright")));
								break;
							case FacingEnum.LEFT:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("fireballleft")));
								break;
							case FacingEnum.UP:
								list.Add(new Projectile(new Vector2(newLocation.X - biasfireball, newLocation.Y), direction, SpriteFactory.GetSprite("fireballup")));
								break;
							case FacingEnum.DOWN:
								list.Add(new Projectile(new Vector2(newLocation.X - biasfireball, newLocation.Y), direction, SpriteFactory.GetSprite("fireballdown")));
								break;
						}
					}
					break;
				case (int)ProjectileEnum.BOOMERANG:
					{
						SoundManager.Instance.PlaySound("Boomerang");
						switch (direction)
						{
							case FacingEnum.RIGHT:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("boomerang")));
								break;
							case FacingEnum.LEFT:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("boomerang")));
								break;
							case FacingEnum.UP:
								list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), direction, SpriteFactory.GetSprite("boomerang")));
								break;
							case FacingEnum.DOWN:
								list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), direction, SpriteFactory.GetSprite("boomerang")));
								break;
						}
					}
					break;
				default:
					break;

			}

		}

		public void Update(GameTime gametime)
		{
			for(int i=0;i<list.Count;i++)
			{
				if (!list[i].isDead())
				{
					list[i].Update(gametime);
				}
				else
				{
					list.Remove(list[i]);
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (Projectile p in list)
			{
				p.Draw(spriteBatch);
			}
		}
		public List<Projectile> GetProjList()
		{
			return list;
		}
	}
}