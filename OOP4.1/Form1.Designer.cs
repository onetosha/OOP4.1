namespace OOP4._1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            paintField = new PictureBox();
            panel2 = new Panel();
            comboBoxShapes = new ComboBox();
            btnDelete = new Button();
            cbSelectMany = new CheckBox();
            comboBoxColor = new ComboBox();
            checkBox1 = new CheckBox();
            label2 = new Label();
            blbShape = new Label();
            panel1 = new Panel();
            btnLoad = new Button();
            btnSave = new Button();
            btnDeGroup = new Button();
            btnGroup = new Button();
            treeShapes = new TreeView();
            ((System.ComponentModel.ISupportInitialize)paintField).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // paintField
            // 
            paintField.Location = new Point(0, 0);
            paintField.Name = "paintField";
            paintField.Size = new Size(517, 372);
            paintField.TabIndex = 2;
            paintField.TabStop = false;
            paintField.Paint += paintField_Paint;
            paintField.MouseClick += paintField_MouseClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(paintField);
            panel2.Location = new Point(366, 8);
            panel2.Name = "panel2";
            panel2.Size = new Size(517, 375);
            panel2.TabIndex = 9;
            // 
            // comboBoxShapes
            // 
            comboBoxShapes.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxShapes.FormattingEnabled = true;
            comboBoxShapes.Items.AddRange(new object[] { "Круг", "Квадрат", "Треугольник", "Стрелка" });
            comboBoxShapes.Location = new Point(26, 49);
            comboBoxShapes.Name = "comboBoxShapes";
            comboBoxShapes.Size = new Size(173, 23);
            comboBoxShapes.TabIndex = 4;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(26, 211);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(173, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // cbSelectMany
            // 
            cbSelectMany.AutoSize = true;
            cbSelectMany.Location = new Point(26, 170);
            cbSelectMany.Name = "cbSelectMany";
            cbSelectMany.Size = new Size(292, 19);
            cbSelectMany.TabIndex = 1;
            cbSelectMany.Text = "Выделять несколько объектов при пересечении";
            cbSelectMany.UseVisualStyleBackColor = true;
            cbSelectMany.CheckedChanged += cbSelectMany_CheckedChanged;
            // 
            // comboBoxColor
            // 
            comboBoxColor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxColor.FormattingEnabled = true;
            comboBoxColor.Items.AddRange(new object[] { "Черный", "Синий", "Красный", "Зеленый", "Фиолетовый" });
            comboBoxColor.Location = new Point(26, 94);
            comboBoxColor.Name = "comboBoxColor";
            comboBoxColor.Size = new Size(173, 23);
            comboBoxColor.TabIndex = 6;
            comboBoxColor.SelectedIndexChanged += comboBoxColor_SelectedIndexChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(26, 145);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(97, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Работает Ctrl";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += cbCtrl_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 73);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 7;
            label2.Text = "Цвет";
            // 
            // blbShape
            // 
            blbShape.AutoSize = true;
            blbShape.Location = new Point(26, 28);
            blbShape.Name = "blbShape";
            blbShape.Size = new Size(47, 15);
            blbShape.TabIndex = 5;
            blbShape.Text = "Фигура";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLoad);
            panel1.Controls.Add(btnSave);
            panel1.Controls.Add(btnDeGroup);
            panel1.Controls.Add(btnGroup);
            panel1.Controls.Add(blbShape);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(comboBoxColor);
            panel1.Controls.Add(cbSelectMany);
            panel1.Controls.Add(btnDelete);
            panel1.Controls.Add(comboBoxShapes);
            panel1.Location = new Point(22, 8);
            panel1.Name = "panel1";
            panel1.Size = new Size(326, 375);
            panel1.TabIndex = 8;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(26, 324);
            btnLoad.Margin = new Padding(3, 2, 3, 2);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(173, 22);
            btnLoad.TabIndex = 11;
            btnLoad.Text = "Загрузить";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(25, 298);
            btnSave.Margin = new Padding(3, 2, 3, 2);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(173, 22);
            btnSave.TabIndex = 10;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnDeGroup
            // 
            btnDeGroup.Location = new Point(26, 269);
            btnDeGroup.Name = "btnDeGroup";
            btnDeGroup.Size = new Size(173, 23);
            btnDeGroup.TabIndex = 9;
            btnDeGroup.Text = "Разгруппировать";
            btnDeGroup.UseVisualStyleBackColor = true;
            btnDeGroup.Click += btnDeGroup_Click;
            // 
            // btnGroup
            // 
            btnGroup.Location = new Point(26, 240);
            btnGroup.Name = "btnGroup";
            btnGroup.Size = new Size(173, 23);
            btnGroup.TabIndex = 8;
            btnGroup.Text = "Группировать";
            btnGroup.UseVisualStyleBackColor = true;
            btnGroup.Click += btnGroup_Click;
            // 
            // treeShapes
            // 
            treeShapes.Location = new Point(889, 8);
            treeShapes.Name = "treeShapes";
            treeShapes.Size = new Size(121, 375);
            treeShapes.TabIndex = 10;
            treeShapes.NodeMouseClick += treeShapes_NodeMouseClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 392);
            Controls.Add(treeShapes);
            Controls.Add(panel2);
            Controls.Add(panel1);
            KeyPreview = true;
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)paintField).EndInit();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox paintField;
        private Panel panel2;
        private ComboBox comboBoxShapes;
        private Button btnDelete;
        private CheckBox cbSelectMany;
        private ComboBox comboBoxColor;
        private CheckBox checkBox1;
        private Label label2;
        private Label blbShape;
        private Panel panel1;
        private Button btnGroup;
        private Button btnDeGroup;
        private Button btnLoad;
        private Button btnSave;
        private TreeView treeShapes;
    }
}