using System;
using System.Collections.Generic;

namespace Snake
{
    public class Snake : GameObject
    {
        public int TailLenght
        {
            get
            {
                return _tail.Count;
            }
        }

        private bool _getEaten = false;
        private EMoveDirection _direction;
        private List<Point> _tail;

        public Snake(Point point, string objSymbol, ConsoleColor objColor, EMoveDirection initDirection=EMoveDirection.Right) 
            : base(point, objSymbol, objColor)
        {
            _direction = initDirection;
            _tail = new List<Point>();

            _tail.Add(new Point(Position.X - 4, Position.Y));
            _tail.Add(new Point(Position.X - 3, Position.Y));
            _tail.Add(new Point(Position.X - 2, Position.Y));
            _tail.Add(new Point(Position.X - 1, Position.Y));
        }

        public enum EMoveDirection
        {
            Up,
            Down,
            Left,
            Right
        }

        public bool IsSnakeBitSnake()
        {
            foreach (var tp in _tail)
            {
                if (tp == Position)
                    return true;
            }
            return false;
        }

        public void Move()
        {
            var lastHeadPos = new Point(Position.X, Position.Y);
            switch (_direction)
            {
                case EMoveDirection.Up:
                    Position.Y--;
                    break;
                case EMoveDirection.Down:
                    Position.Y++;
                    break;
                case EMoveDirection.Left:
                    Position.X--;
                    break;
                case EMoveDirection.Right:
                    Position.X++;
                    break;
            }
            _tail.Add(lastHeadPos);

            var lastTailPos = _tail[0];
            Console.SetCursorPosition(lastTailPos.X, lastTailPos.Y);
            Console.Write(" ");
            if(!_getEaten)
            {
                _tail.Remove(lastTailPos);
            }
            _getEaten = false;
        }



        public void SetDirection(EMoveDirection direction)
        {
            switch (_direction)
            {
                case EMoveDirection.Up:
                    if (direction != EMoveDirection.Down)
                    {
                        _direction = direction;
                    }
                    break;
                case EMoveDirection.Down:
                    if (direction != EMoveDirection.Up)
                    {
                        _direction = direction;
                    }
                    break;
                case EMoveDirection.Left:
                    if (direction != EMoveDirection.Right)
                    {
                        _direction = direction;
                    }
                    break;
                case EMoveDirection.Right:
                    if (direction != EMoveDirection.Left)
                    {
                        _direction = direction;
                    }
                    break;
            }
        }
        public void Eat()
        {
            _getEaten = true;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = ObjColor;
            Console.WriteLine(ObjSymbol);
        }

        public bool IsOn(Point point)
        {
            if (Position.X == point.X && Position.Y == point.Y) return true;

            foreach (var snakeTailPos in _tail)
            {
                if (snakeTailPos.X == point.X && snakeTailPos.Y == point.Y) return true;
            }

            return false;
        }
    }
}
