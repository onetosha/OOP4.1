namespace OOP4._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<CCircle> listCircles= new List<CCircle>();
        bool ctrl = false;
        bool flagctrl = false;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red);
            foreach(var circle in listCircles)
            {
                if (circle.color == "Red")
                    pen.Color = Color.Red;
                else
                    pen.Color = Color.Black;
                e.Graphics.DrawEllipse(pen, circle.x - circle.radius, circle.y - circle.radius, circle.radius * 2, circle.radius * 2);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (ctrl == false)
            {
                foreach (var circle in listCircles)
                {
                    circle.color = "Black";
                }
                CCircle cCircle = new CCircle(e.X, e.Y);
                listCircles.Add(cCircle);
            }
            else
            {
                foreach (var circle in listCircles)
                {
                    if (Math.Pow(e.X - circle.x, 2) + Math.Pow(e.Y - circle.y, 2) <= Math.Pow(circle.radius, 2) && circle.color != "Red")
                    {
                        circle.color = "Red";
                        if (checkBox2.Checked)
                            break;
                    }
                }
            }
            Refresh();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < listCircles.Count; i++)
                {
                    if (listCircles[i].color == "Red")
                    {
                        listCircles.Remove(listCircles[i]);
                        i--;
                    }
                }
                Refresh();
            }
            if (ModifierKeys == Keys.Control)
            {
                flagctrl = !flagctrl;
                checkBox1.Checked = !checkBox1.Checked;
                if(flagctrl)
                    ctrl = !ctrl;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (flagctrl == false)
                ctrl = !ctrl;
        }
    }
}