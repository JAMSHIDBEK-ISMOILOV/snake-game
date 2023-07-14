using System;
namespace ConsoleSnakeGame.Exception
{
	public class SnakeException : ApplicationException
	{
		public SnakeException(string message)
			: base(message)
		{
			
		}
	}
}

