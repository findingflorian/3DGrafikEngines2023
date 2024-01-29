using _3DEngine.Manager;
using ObjLoader.Loader.Data;
using ObjLoader.Loader.Data.Elements;
using ObjLoader.Loader.Data.VertexData;
using ObjLoader.Loader.Loaders;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
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

        private int triangleVboHandle;
        private int TriangleVaoHandle;
        private int textureHandle;
        private int lineVboHandle;
        private int lineVaoHandle;
        public int triangleVertexCnt = 0;
        Shader shaderHost;
        public Vec3 color;
        private int lineVertexCnt = 0;
        private Transformation transformation;
        public MeshRenderer()
        {
            InitializeComponent();
            this.shaderHost = new Shader(@"./Shader/vertex.shader", @"./Shader/fragment.shader");
        }

        public MeshRenderer(GameObject gameObj)
        {
            InitializeComponent();
            this.gameObj = gameObj;
            this.shaderHost = new Shader(@"./Shader/vertex.shader", @"./Shader/fragment.shader");
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
                this.buildVBO();

            }
        }

        private void buildVBO()
        {
            if (this.modelData != null)
            {
                this.triangleVboHandle = GL.GenBuffer();
                this.TriangleVaoHandle = GL.GenVertexArray();
                GL.BindVertexArray(this.TriangleVaoHandle);
                GL.BindBuffer(BufferTarget.ArrayBuffer, this.triangleVboHandle);
                List<float> tmpVertexList = new List<float>();

                foreach (Group group in this.modelData.Groups)
                {
                    foreach (Face face in group.Faces)
                    {
                        for (int vIdx = 0; vIdx < 3; vIdx++)
                        {
                            this.triangleVertexCnt++;
                            tmpVertexList.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].X);
                            tmpVertexList.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Y);
                            tmpVertexList.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Z);
                        }
                    }
                }
                float[] fullVertexData = tmpVertexList.ToArray();

                //array to GL
                // sizeof(float) returns byte length of float
                //BufferUsageHint - Buffer more efficient
                GL.BufferData(BufferTarget.ArrayBuffer, fullVertexData.Length * sizeof(float), fullVertexData, BufferUsageHint.StaticDraw);
                //sends UV coordinates 0 = index, 3 for the vertices count, sizeof(float)
                GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

                GL.EnableVertexAttribArray(0);

                this.lineVboHandle = GL.GenBuffer();
                this.lineVaoHandle = GL.GenVertexArray();
                GL.BindVertexArray(this.lineVaoHandle);

                GL.BindBuffer(BufferTarget.ArrayBuffer, this.lineVboHandle);
                tmpVertexList.Clear();

                foreach (Group group in this.modelData.Groups) // loop over groups
                {
                    foreach (Face face in group.Faces) //loop over faces
                    {
                        for (int vIdx = 0; vIdx < 3; vIdx++)
                        {

                            tmpVertexList.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].X);
                            tmpVertexList.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Y);
                            tmpVertexList.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Z);
                            if (vIdx == 2)
                            {
                                tmpVertexList.Add(modelData.Vertices[face[0].VertexIndex - 1].X);
                                tmpVertexList.Add(modelData.Vertices[face[0].VertexIndex - 1].Y);
                                tmpVertexList.Add(modelData.Vertices[face[0].VertexIndex - 1].Z);
                            }
                            else
                            {
                                tmpVertexList.Add(modelData.Vertices[face[vIdx + 1].VertexIndex - 1].X);
                                tmpVertexList.Add(modelData.Vertices[face[vIdx + 1].VertexIndex - 1].Y);
                                tmpVertexList.Add(modelData.Vertices[face[vIdx + 1].VertexIndex - 1].Z);
                            }
                            this.lineVertexCnt += 6;
                        }

                    }

                }

                fullVertexData = tmpVertexList.ToArray();
                GL.BufferData(BufferTarget.ArrayBuffer, fullVertexData.Length * sizeof(float), fullVertexData, BufferUsageHint.StaticDraw);
                GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
                GL.EnableVertexAttribArray(0);
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

                if (group.Material?.DiffuseTextureMap == null && group.Material?.DiffuseColor != null)
                {
                    this.color = new Vec3(group.Material.DiffuseColor.X, group.Material.DiffuseColor.Y, group.Material.DiffuseColor.Z);
                }
            }
        }

        public void doRender(Matrix4 transformation)
        {

            if (modelData == null) return;

            this.shaderHost.Use(); //activate Shader
            this.shaderHost.SetMatrix4("transformation", transformation);
            this.shaderHost.SetMatrix4("projection", Form1.projection);
            this.shaderHost.SetVector3("color", new Vector3(this.color.X, this.color.Y, this.color.Z));

            GL.BindVertexArray(this.TriangleVaoHandle);

            GL.PolygonOffset(1.0f, 1f);
            GL.Enable(EnableCap.PolygonOffsetFill);

            GL.DrawArrays(PrimitiveType.Triangles, 0, this.triangleVertexCnt);

            GL.Disable(EnableCap.PolygonOffsetFill);

            GL.BindVertexArray(this.lineVaoHandle);
            this.shaderHost.SetVector3("color", new Vector3(Color4.Black.R, Color4.Black.G, Color4.Black.B));
            GL.LineWidth(1.0f);
            GL.DrawArrays(PrimitiveType.Lines, 0, this.lineVertexCnt);


        }

        private void drawVertex(Vertex vertex)
        {

        }
        private void MeshRendererMenu_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
