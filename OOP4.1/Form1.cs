using OOP4._1.Service;
using OOP4._1.Shapes;

namespace OOP4._1
{
    public partial class Form1 : Form
    {
        ShapeService shapeService = new ShapeService();
        ShapeCreator shapeCreator;
        Bitmap map;
        bool ctrl = false;
        string color = "Black";
        static string[] colors = { "Black", "Blue", "Red", "Green", "Purple" };
        public Form1()
        {
            InitializeComponent();
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
            if (e.KeyCode == Keys.A)
            {
                shapeService.MoveShape(-5, 0, paintField.Width, paintField.Height);
            }
            if (e.KeyCode == Keys.S)
            {
                shapeService.MoveShape(0, 5, paintField.Width, paintField.Height);
            }
            if (e.KeyCode == Keys.D)
            {
                shapeService.MoveShape(5, 0, paintField.Width, paintField.Height);
            }
            if (e.KeyCode == Keys.W)
            {
                shapeService.MoveShape(0, -5, paintField.Width, paintField.Height);
            }
            if (e.KeyCode == Keys.E)
            {
                shapeService.ResizeShape(1, paintField.Width, paintField.Height);
            }
            if (e.KeyCode == Keys.Q)
            {
                shapeService.ResizeShape(-1, paintField.Width, paintField.Height);
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
            if (comboBoxShapes.SelectedIndex == 0)
                shapeService.AddOrSelect(shapeCreator.CreateCircle(e.Location, color));
            else if (comboBoxShapes.SelectedIndex == 1)
                shapeService.AddOrSelect(shapeCreator.CreateSquare(e.Location, color));
            else if (comboBoxShapes.SelectedIndex == 2)
                shapeService.AddOrSelect(shapeCreator.CreateTriangle(e.Location, color));
            paintField.Invalidate();
        }

        private void paintField_Paint(object sender, PaintEventArgs e)
        {
            Graphics.FromImage(map).Clear(Color.LightGray);
            shapeService.DrawShapes();
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
            shapeService.ChangeColor(color);
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
    }
}