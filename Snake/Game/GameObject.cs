using System;

namespace Snake
{
    public abstract class GameObject
    {
        public Point Position { get; protected set; }
        protected string ObjSymbol;
        protected ConsoleColor ObjColor;

        public GameObject(Point point, string objSymbol, ConsoleColor objColor)
        {
            Position = point;
            ObjSymbol = objSymbol;
            ObjColor = objColor;
        }

        public static bool IsColliding(GameObject object1, GameObject object2)
        {
            return object1.Position.X == object2.Position.X && 
                object1.Position.Y == object2.Position.Y;
        }

        public abstract void Draw();
    }
}
