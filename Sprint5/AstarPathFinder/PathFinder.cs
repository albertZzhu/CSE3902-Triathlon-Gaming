using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Sprint5.AstarPathFinder
{
	class PathFinder
	{
		private Node start;
		private Node end;
		private Node nodeFind;
		private List<Node> invalidNode;
		private List<Node> openSet;
		private List<Node> closeSet;
		private List<FacingEnum> route = new List<FacingEnum>();
		public PathFinder()
		{

		}

		public List<FacingEnum> Start(Vector2 start, Vector2 target, IBlock[] blocks)
		{
			this.invalidNode = new List<Node>();
			this.openSet = new List<Node>();
			this.closeSet = new List<Node>();
			this.end = Position2Node(target);
			this.start = Position2Node(start);
			this.start.Cost = GetCost(this.start);
			//this.route.Add(FacingEnum.UP);
			foreach (IBlock b in blocks)
			{
				this.invalidNode.Add(Position2Node(new Vector2(b.GetRect().X+10, b.GetRect().Y+10)));
			}
			openSet.Add(this.start);
			while ((nodeFind = isNotFind()) == null&&this.openSet.Count!=0)
			{
				VisitPoint(GetLeastCostNode());
			}
			if((nodeFind = isNotFind()) != null){
				route = ExtractRoute(nodeFind);
			}
			return route;
		}

		private List<FacingEnum> ExtractRoute(Node point)
		{
			List<FacingEnum> opt = new List<FacingEnum>();
			while (point.parent != null)
			{
				Node temp = point.parent;
				int xDiff = temp.x - point.x;
				int yDiff = temp.y - point.y;
				if (xDiff != 0)
				{
					if (xDiff == 1)
					{
						opt.Insert(0, FacingEnum.LEFT);
					}
					else
					{
						opt.Insert(0, FacingEnum.RIGHT);
					}
				}
				else
				{
					if (yDiff == 1)
					{
						opt.Insert(0, FacingEnum.UP);
					}
					else
					{
						opt.Insert(0, FacingEnum.DOWN);
					}
				}
				point = temp;
			}
			return opt;
		}

		private Node Position2Node(Vector2 pos)
		{
			return new Node((int)(pos.X-100)/50, (int)(pos.Y - 100) / 50);
		}

		private int GetCost(Node point)
		{
			return ((Math.Abs(point.x - start.x) + Math.Abs(point.y - start.y))) 
				+(Math.Abs(point.x - end.x) + Math.Abs(point.y - end.y));
		}

		private void VisitPoint(Node point)
		{
			openSet.Remove(point);
			closeSet.Add(point);
			FindOpen(new Node(point.x + 1, point.y), point);
			FindOpen(new Node(point.x - 1, point.y), point);
			FindOpen(new Node(point.x, point.y + 1), point);
			FindOpen(new Node(point.x, point.y - 1), point);
		}

		private Node GetLeastCostNode()
		{
			Node opt = openSet[0];
			foreach(Node n in openSet)
			{
				if (n.Cost < opt.Cost)
				{
					opt = n;
				}
			}
			return opt;
		}

		private void FindOpen(Node openNode, Node parentNode)
		{
			if (isValid(openNode))
			{
				//if (openNode.Cost > parentNode.Cost)
				
					
				if (!isInOpenSet(openNode))
				{
					openNode.parent = parentNode;
					openNode.Cost = GetCost(openNode);
					openSet.Add(openNode);
				}
				
			}
		}

		private bool isInOpenSet(Node point)
		{
			foreach (Node n in openSet)
			{
				if (n.x == point.x && n.y == point.y)
				{
					return true;
				}
			}
			return false;
		}

		private bool isValid(Node point)
		{
			if (point.x < 0 || point.y < 0 || point.x > 11 || point.y > 6)
			{
				return false;
			}
			foreach (Node n in closeSet)
			{
				if (n.x == point.x && n.y == point.y)
				{
					return false;
				}
			}
			foreach (Node n in invalidNode)
			{
				if (n.x == point.x && n.y == point.y)
				{
					return false;
				}
			}
			return true;
		}

		private Node isNotFind()
		{
			foreach(Node n in closeSet)
			{
				if (n.x == end.x && n.y == end.y)
				{
					return n;
				}
			}
			return null;
		}
		
	}
}
