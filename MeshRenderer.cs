using _3DEngine.Manager;
using ImageMagick;
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

    public enum RENDER_TYPE
    {
        LINE,
        GEOMETRY_WITH_COLOR,
        GEOMETRY_WITH_TEXTURE
    }

    public struct VAO_INFO
    {
        public RENDER_TYPE _renderType;
        public int _vaoHandle;
        public int _triangleVBOHandle;
        public int _lineVBOHandle;
        public Vec3 _color;
        public int _textureHandle;
        public int _vertexCnt;

    }

    public partial class MeshRenderer : UserControl, IRenderAble
    {
        GameObject? gameObj = null;
        LoadResult modelData = null;

        private List<VAO_INFO> vaoList = new List<VAO_INFO>();

        private int triangleVboHandle = 0;
        private int TriangleVaoHandle = 0;
        private int textureHandle = 0;
        private int lineVboHandle = 0;
        private int lineVaoHandle;
        public int triangleVertexCnt = 0;
        Shader shaderHost;
        public Vec3 color;
        private int lineVertexCnt = 0;
        private Transformation transformation;
        public MeshRenderer()
        {
            InitializeComponent();
            this.shaderHost = new Shader(@".\Shader\vertex.shader", @".\Shader\fragment.shader");
        }

        public MeshRenderer(GameObject gameObj)
        {
            InitializeComponent();
            this.gameObj = gameObj;
            this.shaderHost = new Shader(@".\Shader\vertex.shader", @".\Shader\fragment.shader");

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
                string fullPath = Path.GetDirectoryName(path);
                var objLoaderFactory = new ObjLoaderFactory();
                var objLoader = objLoaderFactory.Create();
                var fileStream = new FileStream(path, FileMode.Open);
                this.modelData = objLoader.Load(fileStream);
                fileStream.Close();
                this.buildDataInformation();
                this.buildVBO(fullPath);

            }
        }

        private void buildVBO(string fullPath)
        {
            if (this.modelData != null)
            {
                this.vaoList.Clear();


                List<float> tmpBufferData = new List<float>();

                //loop over groups
                foreach (Group group in this.modelData.Groups)
                {

                    if (group.Material == null) //check for Material
                    {
                        continue;
                    }

                    if (group.Material.DiffuseTextureMap != null) //texture Data
                    {
                        VAO_INFO vaoInfo = new VAO_INFO();

                        vaoInfo._renderType = RENDER_TYPE.GEOMETRY_WITH_TEXTURE;
                        vaoInfo._triangleVBOHandle = GL.GenBuffer();
                        vaoInfo._vaoHandle = GL.GenVertexArray();//new VAO

                        GL.BindVertexArray(vaoInfo._vaoHandle); //active VAO
                        GL.BindBuffer(BufferTarget.ArrayBuffer, vaoInfo._triangleVBOHandle);

                        MagickImage img = new MagickImage(fullPath + "/" + group.Material.DiffuseTextureMap);
                        int textureHandle = GL.GenTexture();
                        GL.ActiveTexture(TextureUnit.Texture0);
                        GL.BindTexture(TextureTarget.Texture2D, textureHandle);
                        vaoInfo._textureHandle = textureHandle;
                        byte[]? imgData = img.GetPixels().ToByteArray("RGBa");
                        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, img.Width, img.Height, 0,
                        PixelFormat.Rgba, PixelType.UnsignedByte, imgData);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.LinearMipmapLinear);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
                        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
                        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

                        foreach (Face face in group.Faces)
                        {
                            for (int vIdx = 0; vIdx < 3; vIdx++)
                            {
                                vaoInfo._vertexCnt++;

                                tmpBufferData.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].X);
                                tmpBufferData.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Y);
                                tmpBufferData.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Z);

                                tmpBufferData.Add(modelData.Textures[face[vIdx].TextureIndex - 1].X);
                                tmpBufferData.Add(modelData.Textures[face[vIdx].TextureIndex - 1].Y);

                            }
                        }

                        float[] vertexData = tmpBufferData.ToArray(); // convert to Array
                                                                      //vertex + texture Data
                                                                      //array to GL
                                                                      // sizeof(float) returns byte length of float
                                                                      //BufferUsageHint - Buffer more efficient
                        GL.BufferData(BufferTarget.ArrayBuffer, vertexData.Length * sizeof(float), vertexData, BufferUsageHint.StaticDraw);
                        //sends UV coordinates 0 = index, 3 for the vertices count, sizeof(float)
                        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
                        GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
                        GL.EnableVertexAttribArray(0);
                        GL.EnableVertexAttribArray(1);


                        GL.BindVertexArray(0);
                        this.vaoList.Add(vaoInfo);

                        GL.BindBuffer(BufferTarget.ArrayBuffer, this.lineVboHandle);
                        tmpBufferData.Clear();
                    }
                    else if (group.Material.DiffuseColor.X != 0 && group.Material.DiffuseColor.Y != 0 && group.Material.DiffuseColor.Z != 0)
                    {
                        VAO_INFO vaoInfo = new VAO_INFO();

                        vaoInfo._renderType = RENDER_TYPE.GEOMETRY_WITH_COLOR;
                        vaoInfo._color = group.Material.DiffuseColor;
                        vaoInfo._triangleVBOHandle = GL.GenBuffer();
                        vaoInfo._vaoHandle = GL.GenVertexArray(); // NEW VAO

                        foreach (Face face in group.Faces) //loop over faces
                        {
                            for (int vIdx = 0; vIdx < 3; vIdx++)
                            {
                                this.triangleVertexCnt++;
                                tmpBufferData.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].X);
                                tmpBufferData.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Y);
                                tmpBufferData.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Z);
                            }

                        }
                        this.vaoList.Add(vaoInfo); //add group buffer handle objects to list
                        tmpBufferData.Clear();
                    }
                  /*  else
                    {
                        this.triangleVboHandle = GL.GenBuffer();
                        this.TriangleVaoHandle = GL.GenVertexArray();
                        GL.BindVertexArray(this.TriangleVaoHandle);
                        GL.BindBuffer(BufferTarget.ArrayBuffer, this.triangleVboHandle);



                        foreach (Face face in group.Faces)
                        {
                            for (int vIdx = 0; vIdx < 3; vIdx++)
                            {
                                this.triangleVertexCnt++;
                                tmpBufferData.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].X);
                                tmpBufferData.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Y);
                                tmpBufferData.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Z);
                            }
                        }

                        float[] fullVertexData = tmpBufferData.ToArray();

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
                        tmpBufferData.Clear();


                        foreach (Face face in group.Faces)
                        {
                            for (int vIdx = 0; vIdx < 3; vIdx++)
                        {

                            tmpBufferData.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].X);
                            tmpBufferData.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Y);
                            tmpBufferData.Add(modelData.Vertices[face[vIdx].VertexIndex - 1].Z);
                            if (vIdx == 2)
                            {
                                tmpBufferData.Add(modelData.Vertices[face[0].VertexIndex - 1].X);
                                tmpBufferData.Add(modelData.Vertices[face[0].VertexIndex - 1].Y);
                                tmpBufferData.Add(modelData.Vertices[face[0].VertexIndex - 1].Z);
                            }
                            else
                            {
                                tmpBufferData.Add(modelData.Vertices[face[vIdx + 1].VertexIndex - 1].X);
                                tmpBufferData.Add(modelData.Vertices[face[vIdx + 1].VertexIndex - 1].Y);
                                tmpBufferData.Add(modelData.Vertices[face[vIdx + 1].VertexIndex - 1].Z);
                            }
                            this.lineVertexCnt += 6;

                            }
                        }



                        fullVertexData = tmpBufferData.ToArray();
                        GL.BufferData(BufferTarget.ArrayBuffer, fullVertexData.Length * sizeof(float), fullVertexData, BufferUsageHint.StaticDraw);
                        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
                        GL.EnableVertexAttribArray(0);

                    }
                  */

                }
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

            foreach (VAO_INFO vaoItem in vaoList)
            {
                GL.BindVertexArray(vaoItem._vaoHandle);

                switch (vaoItem._renderType)
                {
                    case RENDER_TYPE.GEOMETRY_WITH_TEXTURE:
                        GL.ActiveTexture(TextureUnit.Texture0);
                        GL.BindTexture(TextureTarget.Texture2D, vaoItem._textureHandle);
                        this.shaderHost.SetInt("useTexture", 1);
                        GL.DrawArrays(PrimitiveType.Triangles, 0, vaoItem._vertexCnt);
                        break;
                    case RENDER_TYPE.GEOMETRY_WITH_COLOR:
                        this.shaderHost.SetInt("useTexture", 0);
                        GL.PolygonOffset(1.0f, 1f);
                        GL.Enable(EnableCap.PolygonOffsetFill);
                        this.shaderHost.SetVector3("color", new Vector3(vaoItem._color.X, vaoItem._color.Y, vaoItem._color.Z));
                        GL.DrawArrays(PrimitiveType.Triangles, 0, vaoItem._vertexCnt);
                        GL.Disable(EnableCap.PolygonOffsetFill);
                        break;
                    case RENDER_TYPE.LINE:
                        this.shaderHost.SetVector3("color", new Vector3(Color4.Black.R, Color4.Black.G, Color4.Black.B));
                        GL.LineWidth(1.0f);
                        GL.DrawArrays(PrimitiveType.Lines, 0, vaoItem._vertexCnt);
                        break;

                }
            }
           /* this.shaderHost.SetVector3("color", new Vector3(this.color.X, this.color.Y, this.color.Z));

            GL.BindVertexArray(this.TriangleVaoHandle);

            GL.PolygonOffset(1.0f, 1f);
            GL.Enable(EnableCap.PolygonOffsetFill);

            GL.DrawArrays(PrimitiveType.Triangles, 0, this.triangleVertexCnt);

            GL.Disable(EnableCap.PolygonOffsetFill);

            GL.BindVertexArray(this.lineVaoHandle);
            this.shaderHost.SetVector3("color", new Vector3(Color4.Black.R, Color4.Black.G, Color4.Black.B));
            GL.LineWidth(1.0f);
            GL.DrawArrays(PrimitiveType.Lines, 0, this.lineVertexCnt);*/

        }

        private void drawVertex(Vertex vertex)
        {

        }
        private void MeshRendererMenu_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
