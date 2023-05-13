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
                    shape = new Square(new Point(0, 0), g, "Black");
                    break;
                case 'C':
                    shape = new CCircle(new Point(0, 0), g, "Black");
                    break;
                case 'T':
                    shape = new Triangle(new Point(0, 0), g, "Black");
                    break;
                case 'G':
                    shape = new CGroup(g);
                    break;
                default:
                    break;
            }
            return shape;
        }
    }
}
