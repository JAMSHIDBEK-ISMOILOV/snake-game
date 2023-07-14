using ConsoleSnakeGame.Models;

bool finished = false;

Canvas canvas = new Canvas();
Snake snake = new Snake();
Food food = new Food();

Console.WriteLine("\t ENTERNI BOSING!");
Console.Read();

while (!finished)
{
    try
    {
        canvas.DrawCanvas();
        Console.SetCursorPosition(90, 5);
        Console.Write("Ball: {0}", snake.Score);
        snake.Input();
        food.DrawFood();
        snake.DrawSnake();
        snake.MoveSnake();
        snake.Eat(food.foodLocation(), food);
        snake.IsDead();
        snake.HitWall(canvas);
    }
    catch (Exception ex)
    {
        Console.Clear();
        Console.WriteLine(ex.Message);
        Console.WriteLine("BOSHIDAN O'YNAMOQCHIMISIZ? (h/y)");

        char c = char.Parse(Console.ReadLine());
        switch (c)
        {
            case 'h':
                snake.X = 20;
                snake.Y = 20;
                snake.Score = 0;
                snake.snakeBody.RemoveRange(0, snake.snakeBody.Count - 1);
                break;

            case 'y':
                finished = true;
                break;
        }
    }
}






