namespace OOP4._1.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(Point click, Graphics graphics, string color) : base(click, graphics, color)
        {
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
                double x = p.X + (height * Math.Cos(angle) / 1.5);
                double y = p.Y + (height * Math.Sin(angle) / 1.5);
                vertices[i] = new Point((int)x, (int)y);
                angle += 2 * Math.PI / 3;
            }
            g.DrawPolygon(pen, vertices);
            if (selected)
            {
                pen.Width = 2;
                pen.Color = Color.Black;
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawRectangle(pen, p.X - (height + 16) / 2, p.Y - (height + 26) / 2, (height + 16), height + 12);
            }
        }
    }
}
