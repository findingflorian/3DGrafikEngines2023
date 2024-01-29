using _3DEngine.Manager;
using OpenTK.Graphics.OpenGL4;
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
        public static bool meshrendereractive = false;
        public Form1()
        {
            InitializeComponent();
            this.sceneManager1.Nodes.Clear();
            this.sceneManager1.InitNodes();

        }
        public void meshRendererActive()
        {
            meshRenderer2.Visible = true;
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

        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color4.MidnightBlue);
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
            foreach (UserControl User in gameObj.componentList)
            {
                if (User is MeshRenderer)
                {

                    this.componentManager1.removeComponents(gameObj);
                }

            }

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
    }
}