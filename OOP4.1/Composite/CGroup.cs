using OOP3;
using OOP4._1.Shapes;
using System.IO;

namespace OOP4._1.Composite
{
    public class CGroup : Shape
    {
        private Container<Shape> _shapes;
        public CGroup(Graphics graphics)
        {
            g = graphics;
            _shapes = new Container<Shape>();
        }
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }
        public Container<Shape> GetShapes()
        {
            return _shapes;
        }
        public override void Draw()
        {
            foreach(var shape in _shapes)
            {
                shape.Draw();
            }
        }
        public override void Move(int x, int y)
        {
            foreach(var shape in _shapes)
            {
                shape.Move(x, y);
            }
        }
        public override void ChangeColor(string color)
        {
            foreach (var shape in _shapes)
            {
                shape.ChangeColor(color);
            }
        }
        public override bool CheckMovePosition(int x, int y, int panelWidth, int panelHeight)
        {
            foreach (var shape in _shapes)
            {
                if (shape.CheckMovePosition(x, y, panelWidth, panelHeight) == false)
                {
                    return false;
                }
            }
            return true;
        }
        public override bool CheckSizePosition(int resize, int panelWidth, int panelHeight)
        {
            foreach (var shape in _shapes)
            {
                if (shape.CheckSizePosition(resize, panelWidth, panelHeight) == false)
                {
                    return false;
                }
            }
            return true;
        }
        public override void ChangeSize(int size)
        {
            foreach(var shape in _shapes)
            {
                shape.ChangeSize(size);
            }
        }
        public override bool CheckClick(Point point)
        {
            foreach (var shape in _shapes)
            {
                if (shape.CheckClick(point))
                {
                    return true;
                }
            }
            return false;
        }
        public override Graphics GetGraphics()
        {
            return g;
        }
        public override void Save(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("G");
            streamWriter.WriteLine("{0}", _shapes.Count);
            foreach (Shape shape in _shapes)
            {
                shape.Save(streamWriter);
            }
        }
        ~CGroup() 
        {
            _shapes.Clear();
        }
    }
}
