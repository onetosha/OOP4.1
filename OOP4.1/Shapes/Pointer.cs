using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4._1.Shapes
{
    public class Pointer : Shape
    {
        Shape shape1;
        Shape shape2;
        Point p1;
        Point p2;
        public Pointer(Graphics graphics, string name)
        {
            p = new Point(0, 0);
            g = graphics;
            this.Name = name;
        }
        public void AddShapes(Shape s1, Shape s2)
        {
            shape1 = s1;
            shape2 = s2;
            p1 = s1.GetPoint();
            p2 = s2.GetPoint();
            s2.AddObserver(s1);
            //s1.AddObserver(s2);
        }
        public override void Save(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("P");
            streamWriter.WriteLine("{0} {1} {2} {3} {4} {5}", shape1.GetPoint().X, shape1.GetPoint().Y, shape2.GetPoint().X, shape2.GetPoint().Y, height, color);
        }
        public override void Load(StreamReader streamReader)
        {
            string[] values = streamReader.ReadLine().Split(' ');
            p1.X = int.Parse(values[0]);
            p1.Y = int.Parse(values[1]);
            p2.X = int.Parse(values[2]);
            p2.Y = int.Parse(values[3]);
            height = int.Parse(values[4]);
            color = values[5].ToString();
        }
        public override void Draw()
        {
            Point startPoint;
            Point endPoint;
            if (shape1 != null)
            {
                startPoint = shape1.GetPoint();
                endPoint = shape2.GetPoint();
            }
            else
            {
                startPoint = p1;
                endPoint = p2;
            }
            Pen pen = new Pen(Color.Black);
            pen.Width = 4;
            // Рисуем линию между начальной и конечной точками
            g.DrawLine(pen, startPoint, endPoint);
            g.DrawEllipse(pen, startPoint.X - 40 / 12, startPoint.Y - 40 / 12, 40 / 6, 40 / 6);
            return;
        }
        public void DeletePointer()
        {
            shape1.RemoveObservers();
            shape2.RemoveObservers();
            this.RemoveObservers();
        }
    }
}
