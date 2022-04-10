using System.Collections.Generic;

namespace Snake
{
	public class Figure
	{
		protected List<Point> pList;
		
		public void Draw()
		{
			foreach (var point in pList)
			{
				point.Draw();
			}
		}
	}
}