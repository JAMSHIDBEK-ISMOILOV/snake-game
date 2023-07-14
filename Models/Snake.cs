using System;
using ConsoleSnakeGame.Exception;

namespace ConsoleSnakeGame.Models
{
	public class Snake
	{
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

        // u -> up
        char key = 'u';

        // d -> down
        char dir = 'd';

        public List<Position> snakeBody { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Score { get; set; }

        public Snake()
        {
            X = 20;
            Y = 20;
            Score = 0;

            snakeBody = new List<Position>();
            snakeBody.Add(new Position(X, Y));
        }

        public void DrawSnake()
        {
            foreach (Position position in snakeBody)
            {
                Console.SetCursorPosition(position.X, position.Y);
                Console.Write("O");
            }
        }

        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }

        private void _Direction()
        {
            if (key == 'w' && dir != 'd')
            {
                dir = 'u';
            }

            else if (key == 's' && dir != 'u')
            {
                dir = 'd';
            }

            else if (key == 'd' && dir != 'l')
            {
                dir = 'r';
            }

            else if (key == 'a' && dir != 'r')
            {
                dir = 'l';
            }
        }

        public void MoveSnake()
        {
            _Direction(); 

            if (dir == 'u')
            {
                Y--;
            }

            else if (dir == 'd')
            {
                Y++;
            }

            else if (dir == 'r')
            {
                X++;
            }

            else if (dir == 'l')
            {
                X--;
            }

            snakeBody.Add(new Position(X, Y));
            snakeBody.RemoveAt(0);
            Thread.Sleep(100);
        }

        public void Eat(Position food1, Food food2)
        {
            Position head = snakeBody[snakeBody.Count - 1];

            if (head.X == food1.X && head.Y == food1.Y)
            {
                snakeBody.Add(new Position(X, Y));
                food2.FoodNewLocation();
                Score++;
            }
        }

        public void IsDead()
        {
            Position head = snakeBody[snakeBody.Count - 1];

            for (int i = 0; i < snakeBody.Count - 2; i++)
            {
                Position sb = snakeBody[i];

                if (head.X == sb.X && head.Y == sb.Y)
                {
                    throw new SnakeException("SIZ YUTQAZDINGIZ!");
                }
            }
        }

        public void HitWall(Canvas canvas)
        {
            Position head = snakeBody[snakeBody.Count - 1];

            if (head.X == canvas.Width || head.X <= 0 || head.Y == canvas.Height || head.Y <= 0)
            {
                throw new SnakeException("SIZ YUTQAZDINGIZ!");
            }
        }
    }
}

