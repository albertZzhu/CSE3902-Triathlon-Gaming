using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint3
{
	public interface IProjectile : IGameObject
	{
		bool isDead();

		void die();

		Rectangle GetRect();
	}
}