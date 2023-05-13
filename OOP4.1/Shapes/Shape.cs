namespace OOP4._1.Shapes
{
    abstract public class Shape
    {
        public Graphics g;
        protected Point p;
        protected bool selected = false;
        public string color = "Red"; 
        public int height = 40;
        public abstract void Draw();
        virtual public Point GetPoint()
        {
            return p;
        }
        virtual public Graphics GetGraphics()
        {
            return g;
        }
        virtual public bool CheckClick(Point point)
        {
            double length = Math.Sqrt(Math.Pow(point.X - p.X, 2) +  Math.Pow(point.Y - p.Y, 2));
            if (length <= height/2)
            {
                return true;
            }
            return false;
        }

        virtual public int GetHeight()
        {
            return height;
        }
        virtual public string GetColor()
        {
            return color;
        }

        virtual public void Move(int x, int y)
        {
            p.X += x;
            p.Y += y;
        }
        virtual public void ChangeSize(int size)
        {
            height += size;
        }
        virtual public void ChangeColor(string color)
        { 
            this.color = color;
        }
        virtual public bool CheckMovePosition(int x, int y, int panelWidth, int panelHeight)
        {
            if ((p.X + this.height / 2 + x < panelWidth) && (p.Y + this.height / 2 + y < panelHeight) && (p.X - this.height / 2 + x > 0) && (p.Y - this.height / 2 + y > 0))
                return true;
            else
                return false;
        }
        virtual public bool CheckSizePosition(int resize, int panelWidth, int panelHeight)
        {
            if ((p.X + (this.height + resize) / 2 < panelWidth) && (p.Y + (this.height + resize) / 2 < panelHeight) && (p.X - (this.height + resize) / 2 > 0) && (p.Y - (this.height + resize) / 2 > 0))
                return true;
            else
                return false;
        }

        virtual public void Load(StreamReader streamReader)
        {
            return;
        }
        virtual public void Save(StreamWriter streamWriter)
        {
            return;
        }

    }
}
