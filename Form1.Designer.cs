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
            TreeNode treeNode1 = new TreeNode("Root");
            TreeNode treeNode2 = new TreeNode("Root");
            TreeNode treeNode3 = new TreeNode("Root");
            TreeNode treeNode4 = new TreeNode("Root");
            toolStrip1 = new ToolStrip();
            tableLayoutPanel1 = new TableLayoutPanel();
            treeView1 = new SceneManager();
            tableLayoutPanel2 = new TableLayoutPanel();
            sceneManager1 = new SceneManager();
            basicInformation1 = new BasicInformation();
            meshRenderer2 = new MeshRenderer();
            glControl1 = new OpenTK.WinForms.GLControl();
            componentManager1 = new ComponentManager(this);
            tableLayoutPanel2.SuspendLayout();
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
            // treeView1
            // 
            treeView1.AllowDrop = true;
            treeView1.Dock = DockStyle.Fill;
            treeView1.LineColor = Color.Empty;
            treeView1.Location = new Point(3, 3);
            treeView1.Name = "treeView1";
            treeNode1.Name = "";
            treeNode1.Text = "Root";
            treeNode2.Name = "";
            treeNode2.Text = "Root";
            treeNode3.Name = "";
            treeNode3.Text = "Root";
            treeView1.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            treeView1.Size = new Size(194, 250);
            treeView1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
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
            // sceneManager1
            // 
            sceneManager1.AllowDrop = true;
            sceneManager1.Dock = DockStyle.Fill;
            sceneManager1.Location = new Point(3, 3);
            sceneManager1.Name = "sceneManager1";
            treeNode4.Name = "";
            treeNode4.Text = "Root";
            sceneManager1.Nodes.AddRange(new TreeNode[] { treeNode4 });
            sceneManager1.Size = new Size(167, 251);
            sceneManager1.TabIndex = 1;
            sceneManager1.AfterSelect += sceneManager1_AfterSelect;
            // 
            // basicInformation1
            // 
            basicInformation1.BackColor = SystemColors.ActiveCaption;
            basicInformation1.Location = new Point(3, 3);
            basicInformation1.Name = "basicInformation1";
            basicInformation1.Size = new Size(150, 92);
            basicInformation1.TabIndex = 1;
            // 
            // meshRenderer2
            // 
            meshRenderer2.BackColor = Color.DarkCyan;
            meshRenderer2.Location = new Point(3, 101);
            meshRenderer2.Name = "meshRenderer2";
            meshRenderer2.Size = new Size(170, 197);
            meshRenderer2.TabIndex = 3;
            meshRenderer2.MouseClick += meshRenderer2_MouseClick;
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
            glControl1.Profile = OpenTK.Windowing.Common.ContextProfile.Core;
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
        private ComponentManager componentManager1;
    }
}