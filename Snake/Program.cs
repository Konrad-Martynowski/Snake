﻿using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var game = new Game();
            game.Run();
            Console.ReadLine();
        }
    }
}
