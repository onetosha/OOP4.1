using OOP3;
using OOP4._1.Shapes;
using OOP4._1.Decorator;
using OOP4._1.Composite;
using System.Globalization;
using OOP4._1.Factory;
using System.IO;

namespace OOP4._1.Service
{
    public class ShapeService : Shape
    {
        private Container<Shape> shapes;
        StreamWriter streamWriter = null;
        const string filename = "D:/data.txt";
        bool ctrl = false;
        bool selectMany = false;
        public ShapeDecorator decorator;
        int panelWidth, panelHeight;
        public ShapeService(int panelWidth, int panelHeight)
        {
            this.panelWidth = panelWidth;
            this.panelHeight = panelHeight;
            shapes = new Container<Shape>();
        }
        public void Save()
        {
            try
            {
                streamWriter = new StreamWriter(filename);
                streamWriter.WriteLine("{0}", shapes.Count);

                foreach (Shape shape in shapes)
                {
                    shape.Save(streamWriter);
                }


            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }
        }

        public void Load(CShapeArray array)
        {
            array.LoadShapes(filename);
            shapes = array.GetShapes();
        }
        public override void Draw()
        {
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }
        public void Select(Point point)
        {
            if (!ctrl)
            {
                UnSelect();
            }
            foreach (var shape in shapes)
            {
                if (!(shape is ShapeDecorator) && shape.CheckClick(point))
                {
                    decorator = new ShapeDecorator(shape);
                    shapes.Add(decorator);
                    shapes.Remove(shape);
                    if (!selectMany)
                    {
                        break;
                    }
                }
            }
        }
        public void UnSelect()
        {
            foreach (var _shape in shapes)
            {
                if (_shape is ShapeDecorator decorator)
                {
                    shapes.Remove(decorator);
                    shapes.Add(decorator.GetShape());
                }
            }
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
                if (shape is ShapeDecorator)
                {
                    shapes.Remove(shape);
                }
            }
        }
        public override bool CheckClick(Point point)
        {
            foreach(var shape in shapes)
            {
                if (shape.CheckClick(point)) 
                    return true;
            }
            return false;
        }
        public override void Move(int x, int y)
        {
            foreach(Shape shape in shapes)
            {
                if (shape is ShapeDecorator && shape.CheckMovePosition(x, y, panelWidth, panelHeight))
                    shape.Move(x, y);
            }
        }
        public override void ChangeSize(int size)
        {
            foreach (var shape in shapes)
            {
                if (shape is ShapeDecorator && shape.CheckSizePosition(size, panelWidth, panelHeight))
                {
                    shape.ChangeSize(size);
                }
            }
        }
        public override void ChangeColor(string color)
        {
            foreach(var shape in shapes)
            {
                if (shape is ShapeDecorator)
                {
                    shape.ChangeColor(color);
                }
            }
        }
        public void Group(CGroup cGroup)
        {
            foreach (var shape in shapes)
            {
                if (shape is ShapeDecorator decorator)
                {
                    cGroup.AddShape(decorator.GetShape());
                    shapes.Remove(decorator);
                }
            }
            decorator = new ShapeDecorator(cGroup);
            shapes.Add(decorator);
        }
        public void DeGroup()
        {
            int j = shapes.Count;
            for (int i = 0; i < j; i++)
            {
                if (shapes.GetByIndex(i) is ShapeDecorator decorator)
                {
                    if (decorator.GetShape() is CGroup group)
                    {
                        foreach(var shape in group.GetShapes())
                        {
                            shapes.Add(new ShapeDecorator(shape));
                        }
                        j--;
                        shapes.RemoveByIndex(i);
                    }
                }
            }
        }
        public Container<Shape> GetShapes() 
        { 
            return shapes; 
        }
        ~ShapeService()
        {
            shapes.Clear();
        }
    }
}
