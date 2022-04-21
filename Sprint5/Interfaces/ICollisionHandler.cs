using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5.Collision
{
	interface ICollisionHandler<T, U>
	{
		void Handle(T t, U u, SideEnum side);
	}
}