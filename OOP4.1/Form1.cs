
using OOP4._1.Factory;
using OOP4._1.Observer;
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
        TreeViewObserver observer;
        public Form1()
        {
            InitializeComponent();
            observer = new TreeViewObserver(treeShapes);
            shapeService = new ShapeService(observer, paintField.Width, paintField.Height);
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

                shapeService.Move(-5, 0);
            }
            if (e.KeyCode == Keys.S)
            {
                shapeService.Move(0, 5);
            }
            if (e.KeyCode == Keys.D)
            {
                shapeService.Move(5, 0);
            }
            if (e.KeyCode == Keys.W)
            {
                shapeService.Move(0, -5);
            }

            if (e.KeyCode == Keys.E)
            {
                shapeService.ChangeSize(1);
            }

            if (e.KeyCode == Keys.Q)
            {
                shapeService.ChangeSize(-1);
            }
            if (e.KeyCode == Keys.G)
            {
                shapeService.Group(shapeCreator.CreateCGroup());
            }
            if (e.KeyCode == Keys.R)
            {
                shapeService.DeGroup();
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
                if (comboBoxShapes.SelectedIndex == 0)
                    shapeService.Add(shapeCreator.CreateCircle(e.Location, color));
                else if (comboBoxShapes.SelectedIndex == 1)
                    shapeService.Add(shapeCreator.CreateSquare(e.Location, color));
                else if (comboBoxShapes.SelectedIndex == 2)
                    shapeService.Add(shapeCreator.CreateTriangle(e.Location, color));
            }
            if (comboBoxShapes.SelectedIndex == 3 && shapeService.CountSelected() == 2)
                shapeService.AddPointer(shapeCreator.CreatePointer());
           
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
            shapeService.NotifyEveryone();
        }

        private void treeShapes_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            observer.NotifyEveryone();
            if (!ctrl)
                observer.NodesToWhite();
            e.Node.BackColor = Color.Gray;
        }
    }
}