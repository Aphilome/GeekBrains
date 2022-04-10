using System;
using System.Collections.Generic;

namespace Snake
{
	class Program
	{
		static void Main()
		{
			//Отрисовка рамочки
			HorizontalLine topLine = new HorizontalLine( 0, 8, 0, '+' );
			HorizontalLine bottomLine = new HorizontalLine( 0, 8, 4, '+' );
			VerticalLine leftLine = new VerticalLine( 0, 4, 0, '+' );
			VerticalLine rightLine = new VerticalLine( 0, 4, 8, '+' );
			topLine.Draw();
			bottomLine.Draw();
			leftLine.Draw();
			rightLine.Draw();


			// HorizontalLine hLine = new HorizontalLine(5,10, 8, '+');
			// hLine.Draw();
			// VerticalLine vLine = new VerticalLine(12,22, 5, '+');
			// vLine.Draw();
			
			//Отрисовка точек
			Point point = new Point(4, 5, '*');
			Snake snake = new Snake(point, 4, Direction.RIGHT);
			snake.Draw();
		}
	}
}
