using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Collision
{
	interface ICollisionHandler<T, U>
	{
		void Handle(T t,U u, Side.side side);
	}
}
