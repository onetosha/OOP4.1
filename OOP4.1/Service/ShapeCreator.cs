using OOP4._1.Composite;
using OOP4._1.Shapes;
using System.Xml.Linq;

namespace OOP4._1.Service
{
    public class ShapeCreator
    {
        private Graphics g;
        private int num1 = 0, num2 = 0, num3 = 0, num4 = 0, num5 = 0;
        public ShapeCreator(Graphics g)
        {
            this.g = g;
        }
        public CCircle CreateCircle(Point click, string color)
        {
            num1++;
            return new CCircle(click, this.g, color, "Круг " + num1.ToString());
        }
        public Triangle CreateTriangle(Point click, string color)
        {
            num2++;
            return new Triangle(click, this.g, color, "Треугольник " + num2.ToString());
        }
        public Square CreateSquare(Point click, string color)
        {
            num3++;
            return new Square(click, this.g, color, "Квадрат " + num3.ToString());
        }
        public CGroup CreateCGroup()
        {
            num4++;
            return new CGroup(this.g, "Группа " + num4.ToString());
        }
        public Pointer CreatePointer()
        {
            num5++;
            return new Pointer(this.g, "Стрелка " + num5.ToString());
        }
    }
}
