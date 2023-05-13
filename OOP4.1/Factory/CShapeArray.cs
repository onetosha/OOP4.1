using OOP3;
using OOP4._1.Composite;
using OOP4._1.Shapes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OOP4._1.Factory
{
    public class CShapeArray
    {
        Container<Shape> shapes;
        Graphics g;
        public CShapeArray(Graphics graphics) 
        {
            this.g = graphics;
            shapes = new Container<Shape>();
        }
        public Container<Shape> GetShapes()
        {
            return shapes;
        }
        public void LoadShapes(string filename)
        {
            CMyShapeFactory factory = new CMyShapeFactory(g);
            StreamReader streamReader = null;
            int count;
            Shape shape;
            try
            {
                streamReader = new StreamReader(filename);
                count = int.Parse(streamReader.ReadLine());
                for (int i  = 0; i < count; i++)
                {
                    char code = char.Parse(streamReader.ReadLine());
                    shape = factory.CreateShape(code);

                    if (shape is CGroup group)
                    {
                        streamReader = LoadGroup(filename, streamReader, factory, group);
                        shapes.Add(shape);
                    }
                    else if (shape != null)
                    {
                        shape.Load(streamReader);
                        shapes.Add(shape);
                    }
                }
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }
        }
        public StreamReader LoadGroup(string filename, StreamReader streamReader, CMyShapeFactory factory, CGroup group)
        {
            int count = int.Parse(streamReader.ReadLine());
            Shape shape;
            for (int j = 0; j < count; j++)
            {
                char code = char.Parse(streamReader.ReadLine());
                shape = factory.CreateShape(code);
                if (shape is CGroup cGroup)
                {
                    streamReader = LoadGroup(filename, streamReader, factory, cGroup);
                }
                shape.Load(streamReader);
                group.AddShape(shape);
            }
            return streamReader;
        }
    }
}
