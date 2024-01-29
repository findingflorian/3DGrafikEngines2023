using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DEngine.Manager
{
    public partial class ComponentManager : FlowLayoutPanel
    {

        public static ComponentManager? Instance = null;
        public ComponentManager()
        {
            InitializeComponent();
            ComponentManager.Instance = this;
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
    }
}
