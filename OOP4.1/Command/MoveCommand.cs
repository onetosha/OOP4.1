using OOP4._1.Shapes;

namespace OOP4._1.Command
{
    public class MoveCommand : ShapeCommand
    {
        private Shape _selection;
        private int _dx;
        private int _dy;
        public MoveCommand(int dx, int dy)
        {
            _selection = null;
            _dx = dx;
            _dy = dy;
        }

        public override ShapeCommand Clone()
        {
            return new MoveCommand(_dx, _dy);
        }

        public override void Execute(Shape selection)
        {
            _selection = selection;
            if (_selection != null)
            {
                _selection.Move(_dx, _dy);
            }
        }

        public override void Unexecute()
        {
            if(_selection != null)
            {
                _selection.Move(-_dx, -_dy);
            }
        }
        ~MoveCommand()
        {

        }
    }
}
