using _3DEngine.Manager;
using ObjLoader.Loader.Data.Elements;
using ObjLoader.Loader.Data.VertexData;
using ObjLoader.Loader.Loaders;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DEngine
{
    public partial class MeshRenderer : UserControl, IRenderAble
    {
        GameObject? gameObj = null;
        LoadResult modelData = null;

        public MeshRenderer()
        {
            InitializeComponent();
        }

        public MeshRenderer(GameObject gameObj)
        {
            InitializeComponent();
            this.gameObj = gameObj;

        }


        public void onClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            GameObject gameObj = e.Node as GameObject;
            if (gameObj != null)
            {
                ComponentManager.Instance.displayComponents(gameObj);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "obj files (*.obj)|*.obj|All files (*.*)|*.*"; // zeigt nur OBJ Dateien an
            DialogResult result = this.openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                string path = this.openFileDialog1.FileName;
                string name = Path.GetFileNameWithoutExtension(path);
                var objLoaderFactory = new ObjLoaderFactory();
                var objLoader = objLoaderFactory.Create();
                var fileStream = new FileStream(path, FileMode.Open);
                this.modelData = objLoader.Load(fileStream);
                fileStream.Close();
                this.buildDataInformation();
            }
        }
        private void buildDataInformation()
        {
            this.textBox2.Text = "";
            this.textBox2.Text += String.Format($"Anzahl Objekte: {this.modelData.Groups.Count}") + Environment.NewLine;
            this.textBox2.Text += String.Format($"Anzahl Vertices: {this.modelData.Vertices.Count}") + Environment.NewLine;
            int count = 1;

            foreach (Group group in this.modelData.Groups)
            {
                this.textBox2.Text += String.Format($"{group.Name} {count}") + Environment.NewLine;
                this.textBox2.Text += String.Format($"Faces: {group.Faces.Count}") + Environment.NewLine;
                this.textBox2.Text += String.Format($"Vertices: {group.Faces.Count * 3}") + Environment.NewLine;
                this.textBox2.Text += String.Format($"Texture missing: {((group.Material?.DiffuseTextureMap != null) ? "Yes" : "No")}");
                count++;
            }
        }

        public void doRender()
        {
            if (modelData == null) return;

            foreach (Group group in modelData?.Groups)
            {
                GL.Begin(PrimitiveType.Triangles);
                foreach (Face triangle in group.Faces)
                {
                    GL.Vertex3(
                        this.modelData.Vertices[triangle[0].VertexIndex - 1].X,
                        this.modelData.Vertices[triangle[0].VertexIndex - 1].Y,
                        this.modelData.Vertices[triangle[0].VertexIndex - 1].Z);

                    GL.Vertex3(
                        this.modelData.Vertices[triangle[1].VertexIndex - 1].X,
                        this.modelData.Vertices[triangle[1].VertexIndex - 1].Y,
                        this.modelData.Vertices[triangle[1].VertexIndex - 1].Z);

                    GL.Vertex3(
                        this.modelData.Vertices[triangle[2].VertexIndex - 1].X,
                        this.modelData.Vertices[triangle[2].VertexIndex - 1].Y,
                        this.modelData.Vertices[triangle[2].VertexIndex - 1].Z);
                }
                GL.End();
            }
        }

        private void drawVertex(Vertex vertex)
        {
            
        }
        private void MeshRendererMenu_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
