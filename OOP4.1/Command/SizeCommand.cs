using OOP4._1.Shapes;

namespace OOP4._1.Command
{
    public class SizeCommand : ShapeCommand
    {
        private Shape _selection;
        private int _dsize;

        public SizeCommand(int dsize)
        {
            _selection = null;
            _dsize = dsize;
        }

        public override ShapeCommand Clone()
        {
            return new SizeCommand(_dsize);
        }

        public override void Execute(Shape selection)
        {
            _selection = selection;
            if (_selection != null)
            {
                _selection.ChangeSize(_dsize);
            }
        }

        public override void Unexecute()
        {
            if( _selection != null )
            {
                _selection.ChangeSize(-_dsize);
            }
        }
        ~SizeCommand()
        {

        }
    }
}
