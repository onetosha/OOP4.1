using OOP4._1.Composite;
using OOP4._1.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4._1.Factory
{
    public class CMyShapeFactory : CShapeFactory
    {
        public Graphics g;
        private int num1 = 1, num2 = 1, num3 = 1, num4 = 1, num5 = 1;
        public CMyShapeFactory(Graphics graphics) 
        {
            g = graphics;
        }
        public override Shape CreateShape(char code)
        {
            Shape shape = null;
            switch (code)
            {
                case 'S':
                    shape = new Square(new Point(0, 0), g, "Black", "Квадрат" + num1.ToString());
                    num1++;
                    break;
                case 'C':
                    shape = new CCircle(new Point(0, 0), g, "Black", "Круг" + num2.ToString());
                    num2++;
                    break;
                case 'T':
                    shape = new Triangle(new Point(0, 0), g, "Black", "Треугольник" + num3.ToString());
                    num3++;
                    break;
                case 'G':
                    shape = new CGroup(g, "Группа " + num4.ToString());
                    num4++;
                    break;
                case 'P':
                    shape = new Pointer(g, "Стрелка " + num5.ToString());
                    num5++;
                    break;
                default:
                    break;
            }
            return shape;
        }
    }
}
