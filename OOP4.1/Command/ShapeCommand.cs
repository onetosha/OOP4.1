using OOP4._1.Shapes;

namespace OOP4._1.Command
{
    public abstract class ShapeCommand
    {
        public abstract void Execute(Shape selection);
        public abstract void Unexecute();
        public abstract ShapeCommand Clone();
    }
}
