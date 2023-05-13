using OOP4._1.Composite;
using OOP4._1.Shapes;

namespace OOP4._1.Decorator
{
    public class ShapeDecorator : Shape
    {
        private Shape _shape;
        public ShapeDecorator(Shape shape)
        {
            _shape = shape;
            g = shape.GetGraphics();
        }
        public Shape GetShape()
        {
            return _shape;
        }
        public override void ChangeColor(string color)
        {
            _shape.ChangeColor(color);
        }
        public override void ChangeSize(int size)
        {
            _shape.ChangeSize(size);
        }
        public override void Draw()
        {
            if (_shape is CGroup group)
            {
                foreach(var shape in group.GetShapes())
                {
                    ShapeDecorator decorator = new ShapeDecorator(shape);
                    decorator.Draw();
                }
            }
            else
            {
                Pen pen = new Pen(Color.Black);
                pen.Width = 2;
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawRectangle(pen, _shape.GetPoint().X - (_shape.GetHeight() + 8) / 2, _shape.GetPoint().Y - (_shape.GetHeight() + 8) / 2, _shape.GetHeight() + 8, _shape.GetHeight() + 8);
                _shape.Draw();
            }
        }
        public override void Move(int x, int y)
        {
            _shape.Move(x, y);
        }
        public override bool CheckMovePosition(int x, int y, int width, int height)
        {
            return _shape.CheckMovePosition(x, y, width, height);
        }
        public override bool CheckSizePosition(int resize, int width, int height)
        {
            return _shape.CheckSizePosition(resize, width, height);
        }
        public override void Save(StreamWriter stream)
        {
            _shape.Save(stream);
        }

        public override void Load(StreamReader stream)
        {
            _shape.Load(stream);
        }
    }
}
