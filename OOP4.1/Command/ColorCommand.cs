using OOP4._1.Shapes;

namespace OOP4._1.Command
{
    public class ColorCommand : ShapeCommand
    {
        private Shape _selection;
        private string _newcolor;
        private string _oldcolor;
        public ColorCommand(string newcolor)
        {
            _selection = null;
            _newcolor = newcolor;
        }
        public override ShapeCommand Clone()
        {
            return new ColorCommand(_newcolor);
        }

        public override void Execute(Shape selection)
        {
            _selection = selection;
            _oldcolor = _selection.GetColor();
            if (_selection != null)
            {
                _selection.ChangeColor(_newcolor);
            }
        }

        public override void Unexecute()
        {
            if (_selection != null)
            {
                _selection.ChangeColor(_oldcolor);
            }
        }
        ~ColorCommand()
        {

        }
    }
}
