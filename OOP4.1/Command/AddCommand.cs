using OOP3;
using OOP4._1.Shapes;

namespace OOP4._1.Command
{
    public class AddCommand : ShapeCommand
    {
        private Container<Shape> _shapes;
        private Shape _selection;
        public AddCommand(Container<Shape> shapes)
        {
            _shapes = shapes;
        }
        public override void Execute(Shape selection)
        {
            _selection = selection;
            if (_selection != null && _shapes != null)
            {
                _shapes.Add(_selection);
            }
        }

        public override void Unexecute()
        {
            if (_selection != null && _shapes != null)
            {
                _shapes.Remove(_selection);
            }
        }

        public override ShapeCommand Clone()
        {
            return new AddCommand(_shapes);
        }
        ~AddCommand()
        {

        }
    }
}
