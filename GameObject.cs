using _3DEngine.Manager;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine
{
    public class GameObject : TreeNode
    {
        public List<UserControl> componentList = new List<UserControl>();

        public GameObject(string text) : base(text)
        {

            BasicInformation component = new BasicInformation(this);
            component.Dock = DockStyle.None;
            componentList.Add(component);



            MeshRenderer meshRenderer = new MeshRenderer(this);
            meshRenderer.Dock = DockStyle.None;
            //componentList.Add(meshRenderer);

            Transformation transformationComp = new Transformation(this);
            component.Dock = DockStyle.None;
            componentList.Add(transformationComp);

        }


        public void doRender(Matrix4 parentTransformation)
        {

            foreach (var component in componentList)
            {
                (component as MeshRenderer)?.doRender(parentTransformation);
            }
        }
        public Matrix4 getTransformation()
        {
            foreach (var component in componentList)
            {
                if (component as Transformation != null)
                {
                    return (component as Transformation).localTransform;
                }
            }
            return Matrix4.Identity;
        }

    }
}
