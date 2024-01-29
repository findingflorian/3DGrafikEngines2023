using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace _3DEngine.Manager
{
    public partial class ComponentManager : FlowLayoutPanel
    {

        public static ComponentManager? Instance = null;
        public ContextMenuStrip contextMenuStrip2;
        private Form1 form1;
        public ComponentManager()
        {
            InitializeComponent();
            ComponentManager.Instance = this;
        }

        public ComponentManager(Form1 form) //GameObject übergeben
        {
            InitializeComponent();
            ComponentManager.Instance = this;
            form1 = form;
            this.InitView();

        }
        public void InitView()
        {
            contextMenuStrip2 = new ContextMenuStrip();

            ToolStripMenuItem toolStripMenuItemAdd = new ToolStripMenuItem("Add Mesh Renderer");
            contextMenuStrip2.Items.Add(toolStripMenuItemAdd);
            toolStripMenuItemAdd.Click += new EventHandler(click_add);

            ToolStripMenuItem toolStripMenuItemDel = new ToolStripMenuItem("Remove Mesh Renderer");
            contextMenuStrip2.Items.Add(toolStripMenuItemDel);
            toolStripMenuItemDel.Click += new EventHandler(click_del);

            //contextMenuStrip2.Show(); //keine Ahnung wieso das nicht funktioniert
            this.ContextMenuStrip = contextMenuStrip2;

        }



        public void click_add(object? sender, EventArgs e)
        {

            MeshRenderer meshRenderer = new MeshRenderer(); // Instantiate the MeshRenderer

            //ComponentManager.Instance.displayComponents(e as GameObject);
            form1.AddMeshRenderer(meshRenderer);

        }


        public void click_del(object? sender, EventArgs e)
        {
            form1.RemoveMeshRenderer();
        }
        public void displayComponents(GameObject gameObject)
        {
            this.Controls.Clear(); //clear controls
            foreach (UserControl control in gameObject.componentList) //loop trough GameObject
            {
                control.Width = this.Width;
                this.Controls.Add(control);
            }
        }

        public void removeComponents(GameObject gameObject)
        {

            foreach (UserControl control in gameObject.componentList) //loop trough GameObject
            {
                if (control is MeshRenderer)
                {
                    this.Controls.Remove(control);
                }
            }
        }

    }
}
