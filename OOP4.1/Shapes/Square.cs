using System.Drawing;

namespace OOP4._1.Shapes
{
    public class Square : Shape
    {
        public Square(Point click, Graphics graphics, string color, string name)
        {
            this.p = click;
            this.g = graphics;
            this.color = color;
            this.Name = name;
        }
        public override void Draw()
        {
            Pen pen = new Pen(Color.Black);
            pen.Width = 4;
            if (color == "Blue")
                pen.Color = Color.Blue;
            else if (color == "Red")
                pen.Color = Color.Red;
            else if (color == "Green")
                pen.Color = Color.Green;
            else if (color == "Purple")
                pen.Color = Color.Purple;
            g.DrawRectangle(pen, p.X - height / 2, p.Y - height / 2, height, height);
        }
        public override void Save(StreamWriter stream)
        {
            stream.WriteLine("S");
            stream.WriteLine("{0} {1} {2} {3}", p.X, p.Y, height, color);
        }

        public override void Load(StreamReader stream)
        {
            string[] values = stream.ReadLine().Split(' ');
            p.X = int.Parse(values[0]);
            p.Y = int.Parse(values[1]);
            height = int.Parse(values[2]);
            color = values[3].ToString();
        }
    }
}
