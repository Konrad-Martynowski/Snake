using System;
using System.Collections.Generic;

namespace Snake
{
    public class Rectangle : GameObject
    {
        private int _width;
        private int _height;
        private List<Point> _positions;

        public Rectangle(Point initialPoint, int width, int height, string objSymbol, ConsoleColor objColor)
            : base(initialPoint, objSymbol, objColor)
        {
            _width = width;
            _height = height;
            _positions = new List<Point>();
        }

        public override void Draw()
        {
            Console.ForegroundColor = ObjColor;
            // Draw horizontal top
            Console.SetCursorPosition(Position.X, Position.Y);
            for (int i = 0; i <= _width; i++)
            {
                Console.Write(ObjSymbol);
                _positions.Add(new Point(Position.X + i, Position.Y));
            }
            // Draw vertical right
            Console.SetCursorPosition(Position.X + _width, Position.Y);
            for (int i = 0; i <= _height; i++)
            {
                Console.SetCursorPosition(Position.X + _width, Position.Y + i);
                _positions.Add(new Point(Position.X + _width, Position.Y + i));
                Console.Write(ObjSymbol);
            }
            // Draw horizontal bottom
            Console.SetCursorPosition(Position.X, Position.Y);
            for (int i = 0; i <= _height; i++)
            {
                Console.SetCursorPosition(Position.X, Position.Y + i);
                _positions.Add(new Point(Position.X, Position.Y + i));
                Console.Write(ObjSymbol);
            }
            // Draw vertical left
            Console.SetCursorPosition(Position.X, Position.Y + _height);
            for (int i = 0; i <= _width; i++)
            {
                Console.SetCursorPosition(Position.X + i, Position.Y + _height);
                _positions.Add(new Point(Position.X + i, Position.Y + _height));
                Console.Write(ObjSymbol);
            }
        }

        public bool IsColide(Point point)
        {
            foreach (var p in _positions)
            {
                if (p == point)
                    return true;
            }
            return false;
        }
    }
}
