using OOP4._1.Composite;
using OOP4._1.Shapes;

namespace OOP4._1.Service
{
    public class ShapeCreator
    {
        private Graphics g;
        public ShapeCreator(Graphics g)
        {
            this.g = g;
        }
        public CCircle CreateCircle(Point click, string color)
        {
            return new CCircle(click, this.g, color);
        }
        public Triangle CreateTriangle(Point click, string color)
        {
            return new Triangle(click, this.g, color);
        }
        public Square CreateSquare(Point click, string color)
        {
            return new Square(click, this.g, color);
        }
        public CGroup CreateCGroup()
        {
            return new CGroup(this.g);
        }
    }
}
