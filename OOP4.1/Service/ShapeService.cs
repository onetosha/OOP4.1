using OOP3;
using OOP4._1.Shapes;
using System.Security.Cryptography.X509Certificates;

namespace OOP4._1.Service
{
    public class ShapeService
    {
        private Container<Shape> shapes;
        bool ctrl = false;
        bool selectMany = false;
        public ShapeService()
        {
            shapes = new Container<Shape>();
        }
        public void DrawShapes()
        {
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }
        public void AddOrSelect(Shape shape)
        {
            if (!ctrl)
                UnSelect();
            if (isSelect(shape.GetPoint()))
                return;
            if (!ctrl)
            {
                shape.ChangeSelect();
                shapes.Add(shape);
            }

        }
        private bool isSelect(Point point)
        {
            bool result = false;
            foreach (var shape in shapes)
            {
                if (shape.CheckClick(point) == true && shape.GetSelect() == false)
                {
                    shape.ChangeSelect();
                    result = true;
                    if (!selectMany)
                    {
                        break;
                    }
                }
            }
            return result;
        }

        public void UnSelect()
        {
            foreach (var shape in shapes)
                shape.UnSelect();
        }
        public void DeleteAllShapes()
        {
            shapes.Clear();
        }
        public void ChangeControl()
        {
            ctrl = !ctrl;
        }
        public void ChangeSelectMany()
        {
            selectMany = !selectMany;
        }

        public void DeleteSelectedShapes()
        {
            foreach(var shape in shapes)
            {
                if (shape.GetSelect() == true)
                {
                    shapes.Remove(shape);
                }
            }
        }
        private bool CheckPosition(int x, int y, int width, int height)
        {
            foreach (var shape in shapes)
            {
                if (shape.GetSelect() == true)
                {
                    if ((shape.GetPoint().X + shape.GetHeight() / 2 + x < width) && (shape.GetPoint().Y + shape.GetHeight() / 2 + y < height) && (shape.GetPoint().X - shape.GetHeight() / 2 + x > 0) && (shape.GetPoint().Y - shape.GetHeight() / 2 + y > 0))
                        continue;
                    else
                        return false;
                }
            }
            return true;
        }
        public void MoveShape(int x, int y, int width, int height)
        {
            if (!CheckPosition(x, y, width, height))
            { 
                return;
            }
            foreach(var shape in shapes)
            {
                if (shape.GetSelect())
                {
                    shape.Move(x, y);
                }
            }
        }
        public void ResizeShape(int resize, int width, int height)
        {
            if (!CheckPosition(resize, resize, width, height))
            {
                return;
            }
            foreach(var shape in shapes)
            { 
                if (shape.GetSelect())
                {
                    shape.ChangeSize(resize);
                }
            }
        }
        public void ChangeColor(string color)
        {
            foreach(var shape in shapes)
            {
                if (shape.GetSelect())
                {
                    shape.ChangeColor(color);
                }
            }
        }
    }
}
