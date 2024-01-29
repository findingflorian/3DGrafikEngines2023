using _3DEngine.Manager;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.WinForms;
using System.Windows.Forms;


namespace _3DEngine
{
    public partial class Form1 : Form
    {
        ComponentManager componentManager = new ComponentManager();
        public Form1()
        {
            InitializeComponent();
            this.sceneManager1.Nodes.Clear();
            this.sceneManager1.InitNodes();
            this.sceneManager1.comMgr = this.componentManager;
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            glControl1.MakeCurrent();    // Tell OpenGL to use MyGLControl.

            // Update OpenGL on the new size of the control.
            GL.Viewport(0, 0, glControl1.ClientSize.Width, glControl1.ClientSize.Height);

        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color4.MidnightBlue);
            glControl1.SwapBuffers();    // Display the result.
        }

        private void sceneManager1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}