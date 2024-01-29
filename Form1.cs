using _3DEngine.Manager;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.WinForms;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Xml.Linq;
using Microsoft.VisualBasic.ApplicationServices;


namespace _3DEngine
{
    public partial class Form1 : Form
    {

        //ComponentManager componentManager = new ComponentManager();
        double fps = 25;
        public static Matrix4 projection = Matrix4.Identity;
        public Form1()
        {
            InitializeComponent();
            this.sceneManager1.Nodes.Clear();
            this.sceneManager1.InitNodes();
            InitTimer();
            this.componentManager1.GetForm(this);

        }


        private void InitTimer()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = (int)(1000 / fps);
            timer.Tick += (sender, e) =>
            {
                glControl1.Invalidate();
            };
            timer.Start();
        }

        public void onComponentManagerMouse(object sender, MouseEventArgs e)
        {
            componentManager1.MouseDown += onComponentManagerClick;
        }
        public void onComponentManagerClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                componentManager1.InitView();
            }
        }
        private void glControl1_Resize(object sender, EventArgs e)
        {
            glControl1.MakeCurrent();    // Tell OpenGL to use MyGLControl.

            // Update OpenGL on the new size of the control.
            GL.Viewport(0, 0, glControl1.ClientSize.Width, glControl1.ClientSize.Height);

            float aspect = (float)glControl1.ClientSize.Width / (float)glControl1.ClientSize.Height;
            Form1.projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), aspect, 0.1f, 100f);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1f * aspect, 1f * aspect, -1f, 1f, 0.1f, 100f);

        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            GL.ClearColor(Color4.MidnightBlue);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            this.glControl1.MakeCurrent();
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color4.MidnightBlue);

            this.sceneManager1.doRenderScene();

            glControl1.SwapBuffers();    // Display the result.
        }

        public void AddMeshRenderer(UserControl controlMesh)
        {
            GameObject gameObj = (GameObject)this.sceneManager1.SelectedNode;
            gameObj.componentList.Add(controlMesh);
            this.componentManager1.displayComponents(gameObj);
            //componentManager.Controls.Add(controlMesh);
        }

        public void RemoveMeshRenderer()
        {

            GameObject gameObj = (GameObject)this.sceneManager1.SelectedNode;


            this.componentManager1.removeComponents(gameObj);




            //this.componentManager1.displayComponents(gameObj);
        }

        private void sceneManager1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void meshRenderer2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            fps = (double)numericUpDown1.Value;
        }

        private void transformation1_Load(object sender, EventArgs e)
        {

        }
    }
}