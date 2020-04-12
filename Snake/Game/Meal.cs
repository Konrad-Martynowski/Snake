using System;

namespace Snake
{
    public class Meal : GameObject
    {
        private int _maxRandX;
        private int _maxRandY;
        private int _minRandX;
        private int _minRandY;
        private Random rnd = new Random();

        public Meal(Point point, string objSymbol, ConsoleColor objColor, int maxRandX, int maxRandY, int minRandX, int minRandY) 
            : base(point, objSymbol, objColor)
        {
            _maxRandX = maxRandX;
            _maxRandY = maxRandY;
            _minRandX = minRandX;
            _minRandY = minRandY;
        }

        public void SetRandomPosition()
        {
            Position.X = rnd.Next(_minRandX, _maxRandX);
            Position.Y = rnd.Next(_minRandY, _maxRandY);
        }

        public override void Draw()
        {
            Console.ForegroundColor = ObjColor;
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.WriteLine(ObjSymbol);
        }
    }
}
