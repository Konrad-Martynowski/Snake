using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Snake
{
    public class ScoreBoard : GameObject
    {
        private XElement _xml;
        private string _fileName;

        public ScoreBoard(Point point, string objSymbol, ConsoleColor objColor) : base(point, objSymbol, objColor)
        {
            _fileName = "scores.xml";
            InitFIle();
        }

        public override void Draw()
        {
            var topPlayers = (
                from p in _xml.Elements()
                orderby (int)p.Element("points")
                select p).Reverse().Take(10);

            Console.ForegroundColor = ObjColor;
            var y = Position.Y;
            foreach (var p in topPlayers)
            {
                var name = p.Element("name").Value;
                var points = p.Element("points").Value;
                var line = string.Concat(Enumerable.Repeat(".", 40 - name.Length));

                Console.SetCursorPosition(Position.X, y);
                Console.WriteLine($"{name}{line}{points}");
                y++;
            }
        }

        public void AppendScore(string name, int points)
        {
            _xml.Add(new XElement("player",
                new XElement("name", name),
                new XElement("points", points)));
            _xml.Save(_fileName);
        }

        private void InitFIle()
        {
            var curDir = Directory.GetCurrentDirectory();
            var scoresFilePatch = Path.Combine(curDir, _fileName);

            if (!File.Exists(scoresFilePatch))
                using (var f = new StreamWriter(_fileName))
                {
                    f.Write("<scores></scores>");
                }

            _xml = XElement.Load(scoresFilePatch);
        }
    }
}
