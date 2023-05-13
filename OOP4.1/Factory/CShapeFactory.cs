using OOP4._1.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4._1.Factory
{
    public abstract class CShapeFactory
    {
        public abstract Shape CreateShape(char code);
    }
}
