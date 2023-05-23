using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4._1.Shapes
{
    public class Pointer : Shape
    {
        Shape shape1;
        Shape shape2;
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
            shape2.AddObserver(shape1);
        }
        public override void Save(StreamWriter streamWriter)
        {
            streamWriter.WriteLine("P");
            streamWriter.WriteLine("{0} {1} {2} {3}", p.X, p.Y, height, color);
        }
        public override void Draw()
        {
            return;
        }
        public override void Load(StreamReader streamReader)
        {
            string[] values = streamReader.ReadLine().Split(' ');
            p.X = int.Parse(values[0]);
            p.Y = int.Parse(values[1]);
            height = int.Parse(values[2]);
            color = values[3].ToString();
        }
        public void DeletePointer()
        {
            shape2.RemoveObservers();
        }
    }
}
