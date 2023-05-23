using System.Drawing;

namespace OOP4._1.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(Point click, Graphics graphics, string color, string name)
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
            Point[] vertices = new Point[3];
            double angle = Math.PI / 6;
            for (int i = 0; i < 3; i++)
            {
                double x = p.X + height * Math.Cos(angle) / 1.6;
                double y = p.Y + (height * Math.Sin(angle) + 9) / 1.7;
                vertices[i] = new Point((int)x, (int)y);
                angle += 2 * Math.PI / 3;
            }
            g.DrawPolygon(pen, vertices);
        }
        public override void Save(StreamWriter stream)
        {
            stream.WriteLine("T");
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
