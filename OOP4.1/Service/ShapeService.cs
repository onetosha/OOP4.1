using OOP3;
using OOP4._1.Shapes;
using OOP4._1.Decorator;
using OOP4._1.Composite;
using System.Globalization;
using OOP4._1.Factory;
using System.IO;
using OOP4._1.Observer;

namespace OOP4._1.Service
{
    public class ShapeService : Shape, ICObserver
    {
        private Container<Shape> shapes;
        StreamWriter streamWriter = null;
        const string filename = "D:/data.txt";
        bool ctrl = false;
        bool selectMany = false;
        public ShapeDecorator decorator;
        private TreeViewObserver treeViewObserver;
        int panelWidth, panelHeight;
        public ShapeService(TreeViewObserver treeViewObserver, int panelWidth, int panelHeight)
        {
            shapes = new Container<Shape>();
            this.treeViewObserver = treeViewObserver;
            treeViewObserver.AddObserver(this);
            this.AddObserver(treeViewObserver);
            this.panelWidth = panelWidth;
            this.panelHeight = panelHeight;
        }
        public void Add(Shape shape)
        {
            shape.AddObserver(treeViewObserver);
            decorator = new ShapeDecorator(shape);
            shapes.Remove(shape);
            shapes.Add(decorator);
            this.NotifyEveryone();
            decorator.NotifyEveryoneSelect();
        }
        public void AddPointer(Shape Pointer)
        {
            int s1 = -1;
            int s2 = -1;
            int i = 0;
            foreach (Shape shape in shapes)
            {
                if (shape is ShapeDecorator && s1 == -1)
                    s1 = i;
                else if (shape is ShapeDecorator)
                {
                    s2 = i;
                }
                i++;
            }
            if (Pointer is Pointer p)
            {
                p.AddShapes(shapes.GetByIndex(s2), shapes.GetByIndex(s1));
            }
            shapes.Add(Pointer);
            this.NotifyEveryone();

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
        public override void ChangeColor(string color)
        {
            foreach (var shape in shapes)
            {
                if (shape is ShapeDecorator)
                {
                    shape.ChangeColor(color);
                }
            }
        }
        public bool CheckClick(Point point)
        {
            if (!ctrl)
            {
                UnSelect();
            }
            if (Select(point))
            {
                return true;
            }
            return false;
        }
        public bool Select(Point point)
        {
            bool result = false;
            foreach (var shape in shapes)
            {
                if (!(shape is ShapeDecorator) && shape.CheckClick(point))
                {
                    decorator = new ShapeDecorator(shape);
                    shapes.Remove(shape);
                    shapes.Add(decorator);
                    this.NotifyEveryone();
                    result = true;
                    if (!selectMany)
                        return result;
                }
            }
            return result;
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
            NotifyEveryone();
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
            for(int i = 0; i < shapes.Count;)
            {
                if (shapes.GetByIndex(i) is ShapeDecorator)
                {
                    if (shapes.GetByIndex(i) is Pointer p)
                    {
                        p.DeletePointer();
                    }

                    shapes.RemoveByIndex(i);
                    //count++;
                    continue;
                }
                ++i;
            }
            this.NotifyEveryone();
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
            cGroup.AddObserver(treeViewObserver);
            this.NotifyEveryone();
            decorator.NotifyEveryoneSelect();
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
            this.NotifyEveryone();
        }
        public Container<Shape> GetShapes() 
        { 
            return shapes; 
        }
        public int CountSelected()
        {
            int i = 0;
            foreach (Shape shape in shapes)
            {
                if (shape is ShapeDecorator)
                {
                    i++;
                }
            }
            return i;
        }
        public void OnSubjectChanged(CObject who)
        {
            string name = treeViewObserver.GetSelectedName();

            if (ctrl == false)
                UnSelect();
            foreach (Shape shape in shapes)
            {
                if (!(shape is ShapeDecorator) && shape.Who() == name)
                {
                    decorator = new ShapeDecorator(shape);
                    shapes.Remove(shape);
                    shapes.Add(decorator);
                }
            }    
        }
        public void OnSubjectSelect(CObject who)
        {

        }

        public void OnSubjectMove(int x, int y)
        {
        }
        ~ShapeService()
        {
            shapes.Clear();
        }
    }
}
