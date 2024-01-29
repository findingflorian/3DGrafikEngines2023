using _3DEngine.Manager;

namespace _3DEngine
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
            components = new System.ComponentModel.Container();
            toolStrip1 = new ToolStrip();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            numericUpDown1 = new NumericUpDown();
            sceneManager1 = new SceneManager();
            glControl1 = new OpenTK.WinForms.GLControl();
            componentManager1 = new ComponentManager();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Bottom;
            toolStrip1.Location = new Point(0, 425);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.Size = new Size(200, 100);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(numericUpDown1, 0, 1);
            tableLayoutPanel2.Controls.Add(sceneManager1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Left;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 60.6666679F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 39.3333321F));
            tableLayoutPanel2.Size = new Size(173, 425);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Dock = DockStyle.Left;
            numericUpDown1.Location = new Point(3, 260);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.Value = new decimal(new int[] { 25, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // sceneManager1
            // 
            sceneManager1.AllowDrop = true;
            sceneManager1.Dock = DockStyle.Fill;
            sceneManager1.Location = new Point(3, 3);
            sceneManager1.Name = "sceneManager1";
            sceneManager1.Size = new Size(167, 251);
            sceneManager1.TabIndex = 3;
            // 
            // glControl1
            // 
            glControl1.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            glControl1.APIVersion = new Version(3, 3, 0, 0);
            glControl1.Dock = DockStyle.Fill;
            glControl1.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            glControl1.IsEventDriven = true;
            glControl1.Location = new Point(173, 0);
            glControl1.Name = "glControl1";
            glControl1.Profile = OpenTK.Windowing.Common.ContextProfile.Compatability;
            glControl1.Size = new Size(627, 425);
            glControl1.TabIndex = 5;
            glControl1.Text = "glControl1";
            glControl1.Paint += glControl1_Paint;
            glControl1.Resize += glControl1_Resize;
            // 
            // componentManager1
            // 
            componentManager1.Dock = DockStyle.Right;
            componentManager1.Location = new Point(600, 0);
            componentManager1.Name = "componentManager1";
            componentManager1.Size = new Size(200, 425);
            componentManager1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(componentManager1);
            Controls.Add(glControl1);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(toolStrip1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStrip toolStrip1;
        private TableLayoutPanel tableLayoutPanel1;
        private SceneManager treeView1;
        private TableLayoutPanel tableLayoutPanel2;
        private SceneManager sceneManager1;
        private OpenTK.WinForms.GLControl glControl1;
        private BasicInformation basicInformation1;
        private MeshRenderer meshRenderer2;
        private NumericUpDown numericUpDown1;
        private ComponentManager componentManager1;
        private Transformation transformation1;
    }
}