using System;
namespace ConsoleSnakeGame.Models
{
	public class Food
	{
		public Position foodPosition = new Position();

		Random random = new Random();
		Canvas canvas = new Canvas();

		public Food()
		{
			foodPosition.X = random.Next(5, canvas.Width);
			foodPosition.Y = random.Next(5, canvas.Height);
		}

		public void DrawFood()
		{
			Console.SetCursorPosition(foodPosition.X, foodPosition.Y);
			Console.Write("*");
		}

		public Position foodLocation()
		{
			return foodPosition;
		}

		public void FoodNewLocation()
		{
            foodPosition.X = random.Next(5, canvas.Width);
            foodPosition.Y = random.Next(5, canvas.Height);
        }
	}
}

