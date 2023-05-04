namespace OOP4._1.Shapes
{
    public class CCircle : Shape
    {
        public CCircle(Point click, Graphics graphics, string color) : base(click, graphics, color)
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
            g.DrawEllipse(pen, p.X - height/2, p.Y - height/2, height, height);
            if (selected)
            {
                pen.Width = 2;
                pen.Color = Color.Black;
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawRectangle(pen, p.X - (height + 8) / 2, p.Y - (height + 8) / 2, (height + 8), height + 8);
            }
        }
    }
}
