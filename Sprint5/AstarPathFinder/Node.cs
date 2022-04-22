using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5.AstarPathFinder
{
	class Node
	{
		public int x
		{
			get;set;
		}
		public int y
		{
			get;set;
		}
		public Node parent
		{
			get;set;
		}
		public int Cost
		{
			get;set;
		}
		public Node(int x, int y)
		{
			this.x = x;
			this.y = y;
			this.Cost = 999;
			this.parent = null;
		}
	}
}
