using System;

namespace Snake
{
    public class Game
    {
        private ScoreBoard _scoreBoard;


        public Game()
        {
            _scoreBoard = new ScoreBoard(new Point(10, 10), "", ConsoleColor.Blue);
        }


        public void Run()
        {
            var quit = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Clear();
                Console.WriteLine("1. New game");
                Console.WriteLine("2. Score board");
                Console.WriteLine("3. Quit game");
                var playerInput = Console.ReadLine();
                switch(playerInput)
                {
                    case "1":
                        NewGame();
                        break;
                    case "2":
                        Console.Clear();
                        _scoreBoard.Draw();
                        Console.ReadKey();
                        break;
                    case "3":
                        quit = true;
                        break;
                    default:
                        continue;
                }
            } while (!quit);
        }

        public void NewGame()
        {
            var board = new Rectangle(new Point(3, 3), 40, 20, "#", ConsoleColor.Red);
            var snake = new Snake(new Point(10, 10), "@", ConsoleColor.Blue);
            var meal = new Meal(new Point(0, 0), "*", ConsoleColor.Green, 39, 19, 4, 4);

            Console.Write("What is you name: ");
            var playerName = Console.ReadLine();
            Console.Clear();

            board.Draw();
            meal.SetRandomPosition();
            meal.Draw();

            var lastDate = DateTime.Now;
            var frameDivider = 5.0;

            bool quit = false;
            while (!quit)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            snake.SetDirection(Snake.EMoveDirection.Up);
                            break;
                        case ConsoleKey.DownArrow:
                            snake.SetDirection(Snake.EMoveDirection.Down);
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.SetDirection(Snake.EMoveDirection.Left);
                            break;
                        case ConsoleKey.RightArrow:
                            snake.SetDirection(Snake.EMoveDirection.Right);
                            break;
                        case ConsoleKey.Escape:
                            quit = true;
                            break;
                        default:
                            continue;
                    }
                }

                // frame:
                var frameRate = 1000 / frameDivider;
                if ((DateTime.Now - lastDate).TotalMilliseconds >= frameRate)
                {
                    lastDate = DateTime.Now;

                    if (GameObject.IsColliding(snake, meal))
                    {
                        snake.Eat();
                        frameDivider += 0.1;
                        while (snake.IsOn(meal.Position))
                        {
                            meal.SetRandomPosition();
                        }
                        meal.Draw();
                    }

                    if (snake.IsSnakeBitSnake())
                    {
                        quit = true;
                    }
                    else if (board.IsColide(snake.Position))
                    {
                        quit = true;
                    }
                    snake.Move();
                    snake.Draw();
                }
            }
            Console.Clear();
            Console.WriteLine($"\n\n\n\n\n\n\n\t\tCongratulations! {playerName} your score is {snake.TailLenght}");
            Console.ReadLine();
            Console.Clear();
            _scoreBoard.AppendScore(playerName, snake.TailLenght);
            _scoreBoard.Draw();
            Console.ReadLine();
        }
    }
}
