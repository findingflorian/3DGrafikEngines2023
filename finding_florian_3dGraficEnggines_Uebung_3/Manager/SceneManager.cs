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
    public partial class SceneManager : TreeView
    {
        public ComponentManager? comMgr = null;
        public SceneManager()
        {
            InitializeComponent();
            DragandDrop();

        }

        public TreeNode node1;
        public ContextMenuStrip contextMenuStrip1;
        public void InitNodes()
        {
            this.Nodes.Clear();
            node1 = new TreeNode();
            node1.Text = "Root";
            this.Nodes.Add(node1);


            contextMenuStrip1 = new ContextMenuStrip();

            ToolStripMenuItem toolStripMenuItemAdd = new ToolStripMenuItem("Add");
            contextMenuStrip1.Items.Add(toolStripMenuItemAdd);
            toolStripMenuItemAdd.Click += new EventHandler(click_handler_add);

            ToolStripMenuItem toolStripMenuItemDel = new ToolStripMenuItem("Del");
            contextMenuStrip1.Items.Add(toolStripMenuItemDel);
            toolStripMenuItemDel.Click += new EventHandler(click_handler_del);

            if (SelectedNode != null)
                SelectedNode.ContextMenuStrip = contextMenuStrip1;
            else
                this.ContextMenuStrip = contextMenuStrip1;

            this.NodeMouseClick += new TreeNodeMouseClickEventHandler(onNodeMouseClick);
        }



        private void onNodeMouseClick(object? sender, TreeNodeMouseClickEventArgs e)
        {
            GameObject gameObj = e.Node as GameObject;
            if (gameObj != null)
            {
                ComponentManager.Instance.displayComponents(gameObj);
            }
        }

        public void addNewNode(TreeNode? parentNode)
        {
            this.Nodes.Add(parentNode);
        }
        private void click_handler_add(object? sender, EventArgs e)
        {
            GameObject node = new GameObject("GameObject");
            this.SelectedNode.Nodes.Add(node);

            ContextMenuStrip menuStrip = contextMenuStrip1;
            node.ContextMenuStrip = menuStrip;
        }

        private void click_handler_del(object? sender, EventArgs e)
        {
            if (SelectedNode != node1)
                SelectedNode.Nodes.Remove(SelectedNode);
        }
        private void DragandDrop()
        {
            this.AllowDrop = true;
            this.Dock = DockStyle.Fill;

            this.ItemDrag += new ItemDragEventHandler(treeView1_ItemDrag);
            this.DragEnter += new DragEventHandler(treeView1_DragEnter);
            this.DragOver += new DragEventHandler(treeView1_DragOver);
            this.DragDrop += new DragEventHandler(treeView1_DragDrop);

        }

        public void doRenderScene()
        {
            if (node1.Nodes.Count > 0)
            {
                foreach (TreeNode node in node1.Nodes)
                {
                    if (node is GameObject gameobj) renderGameObject(gameobj);
                }
            }
        }

        private void renderGameObject(GameObject node)
        {
            GameObject gameobj = node as GameObject;
            if (gameobj != null)
            {
                gameobj.doRender();


                foreach (GameObject child in node.Nodes)
                {
                    renderGameObject(child);
                }
            }

        }

        #region Drag and Drop


        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.
            else if (e.Button == MouseButtons.Right)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        // Set the target drop effect to the effect 
        // specified in the ItemDrag event handler.
        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        // Select the node under the mouse pointer to indicate the 
        // expected drop location.
        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = this.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            this.SelectedNode = this.GetNodeAt(targetPoint);
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = this.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = this.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(GameObject));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                }

                // If it is a copy operation, clone the dragged node 
                // and add it to the node at the drop location.
                else if (e.Effect == DragDropEffects.Copy)
                {
                    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                }

                // Expand the node at the location 
                // to show the dropped node.
                targetNode.Expand();
            }
        }

        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }

        #endregion

    }
}
