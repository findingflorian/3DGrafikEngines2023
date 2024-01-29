using _3DEngine.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            component.Dock = DockStyle.Top;
            componentList.Add(component);
            


            MeshRenderer meshRenderer = new MeshRenderer(this);
            meshRenderer.Dock = DockStyle.Bottom;
            //componentList.Add(meshRenderer);

        }

      
    }
}
