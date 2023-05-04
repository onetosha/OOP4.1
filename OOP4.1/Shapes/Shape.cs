namespace OOP4._1.Shapes
{
    abstract public class Shape
    {
        protected Graphics g;
        protected Point p;
        protected bool selected = false;
        public string color = "Red"; 
        public int height = 40;
        public Shape(Point click, Graphics graphics, string color)
        {
            this.p = click;
            this.g = graphics;
            this.color = color;
        }
        public abstract void Draw();
        public bool GetSelect()
        {
            return selected;
        }
        public void UnSelect()
        {
            selected = false;
        }
        public void ChangeSelect()
        {
            selected = !selected;
        }
        public Point GetPoint()
        {
            return p;
        }
        public bool CheckClick(Point point)
        {
            double length = Math.Sqrt(Math.Pow(point.X - p.X, 2) +  Math.Pow(point.Y - p.Y, 2));
            if (length <= height/2)
            {
                return true;
            }
            return false;
        }

        public int GetHeight()
        {
            return height;
        }

        public void Move(int x, int y)
        {
            p.X += x;
            p.Y += y;
        }
        public void ChangeSize(int size)
        {
            height += size;
        }
        public void ChangeColor(string color)
        { 
            this.color = color;
        }
    }
}
