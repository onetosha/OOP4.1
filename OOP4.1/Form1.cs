using OOP4._1.Command;
using OOP4._1.Factory;
using OOP4._1.Service;
using OOP4._1.Shapes;

namespace OOP4._1
{
    public partial class Form1 : Form
    {
        ShapeService shapeService;
        ShapeCreator shapeCreator;
        Bitmap map;
        bool ctrl = false;
        string color = "Black";
        static string[] colors = { "Black", "Blue", "Red", "Green", "Purple" };
        Dictionary<Keys, ShapeCommand> commands = new Dictionary<Keys, ShapeCommand>()
        {
            { Keys.A, new MoveCommand(-10, 0) },
            { Keys.D, new MoveCommand(10, 0) },
            { Keys.W, new MoveCommand(0, -10) },
            { Keys.S, new MoveCommand(0, 10) },
            { Keys.Q, new SizeCommand(-1) },
            { Keys.E, new SizeCommand(1) },
        };
        Stack<ShapeCommand> history = new Stack<ShapeCommand>();
        public Form1()
        {
            InitializeComponent();
            shapeService = new ShapeService(paintField.Width, paintField.Height);
            map = new Bitmap(paintField.Width, paintField.Height);
            shapeCreator = new ShapeCreator(Graphics.FromImage(map));
            comboBoxShapes.SelectedIndex = 0;
            comboBoxColor.SelectedIndex = 0;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                ctrl = true;
                shapeService.ChangeControl();
            }
            if (e.KeyCode == Keys.Delete)
            {
                shapeService.DeleteSelectedShapes();
            }
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D || e.KeyCode == Keys.W || e.KeyCode == Keys.E || e.KeyCode == Keys.Q)
            {
                ShapeCommand command = commands[e.KeyCode];
                ShapeCommand newcommand = command.Clone();
                newcommand.Execute(shapeService);
                history.Push(newcommand);
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) != Keys.Control && ctrl)
            {
                ctrl = false;
                shapeService.ChangeControl();
            }
        }

        private void paintField_MouseClick(object sender, MouseEventArgs e)
        {
            if (!shapeService.CheckClick(e.Location) && !ctrl)
            {
                ShapeCommand command = new AddCommand(shapeService.GetShapes());
                if (comboBoxShapes.SelectedIndex == 0)
                    command.Execute(shapeCreator.CreateCircle(e.Location, color));
                else if (comboBoxShapes.SelectedIndex == 1)
                    command.Execute(shapeCreator.CreateSquare(e.Location, color));
                else if (comboBoxShapes.SelectedIndex == 2)
                    command.Execute(shapeCreator.CreateTriangle(e.Location, color));
                history.Push(command);
            }
            if (shapeService.CheckClick(e.Location))
            {
                shapeService.Select(e.Location);
            }
        }

        private void paintField_Paint(object sender, PaintEventArgs e)
        {
            Graphics.FromImage(map).Clear(Color.LightGray);
            shapeService.Draw();
            paintField.Image = map;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Graphics.FromImage(map).Clear(Color.LightGray);
            shapeService.DeleteAllShapes();
        }

        private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            color = colors[comboBoxColor.SelectedIndex];
            ShapeCommand command = new ColorCommand(color);
            command.Execute(shapeService);
            history.Push(command);
        }

        private void cbSelectMany_CheckedChanged(object sender, EventArgs e)
        {
            shapeService.ChangeSelectMany();
        }

        private void cbCtrl_CheckedChanged(object sender, EventArgs e)
        {
            ctrl = !ctrl;
            shapeService.ChangeControl();
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            shapeService.Group(shapeCreator.CreateCGroup());
        }

        private void btnDeGroup_Click(object sender, EventArgs e)
        {
            shapeService.DeGroup();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            shapeService.Save();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            CShapeArray array = new CShapeArray(Graphics.FromImage(map));
            shapeService.Load(array);
        }
    }
}