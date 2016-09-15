using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using LabManager.Model;
using LabManager.Util;

namespace LabManager.View
{

    partial class MainView
    {
        bool isCursorShowed = true;
        TreeNode dragNode = null;
        TreeNode dragParent = null;
        //int dragNodeIndex = 0;
        TreeNode tempDropNode = null;
        public List<LocOperation> ListLocOperation { get; } = new List<LocOperation>();
        //public List<string> OperationStr { get; } = new List<string>();
        LocOperationType locOperType = LocOperationType.无操作;
        TreeNode oriNode;
        //TreeNode desNode;
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            dragNode = (TreeNode)e.Item;
            dragParent = dragNode.Parent;
            //dragNodeIndex = dragNode.Index;
            treeView.SelectedNode = dragNode;
            if (dragNode.Level == 2)
            {
                imageListDrag.Images.Clear();
                imageListDrag.ImageSize = new Size(this.dragNode.Bounds.Size.Width + this.treeView.Indent, this.dragNode.Bounds.Height);
                Bitmap bmp = new Bitmap(dragNode.Bounds.Width + treeView.Indent, dragNode.Bounds.Height);
                Graphics gfx = Graphics.FromImage(bmp);
                //gfx.DrawRectangle(new Pen(Color.Black), 0, 0, bmp.Width - 1, bmp.Height - 1);
                Rectangle rect = new Rectangle(treeView.Indent + 1, 1, bmp.Width - 2, bmp.Height - 2);
                gfx.FillRectangle(new LinearGradientBrush(rect, Color.FromArgb(220, 255, 248, 122), Color.FromArgb(220, 220, 0, 0), 0f), rect);
                gfx.DrawString(dragNode.Text,
                    treeView.Font,
                    new SolidBrush(Color.Black),
                    (float)treeView.Indent, 1.0f);
                imageListDrag.Images.Add(bmp);
                Point p = treeView.PointToClient(System.Windows.Forms.Control.MousePosition);
                int dx = p.X + treeView.Indent - dragNode.Bounds.Left;
                int dy = p.Y - dragNode.Bounds.Top;
                if (DragHelper.ImageList_BeginDrag(imageListDrag.Handle, 0, dx, dy))
                {
                    //dragNode.Parent.Collapse();
                    treeView.CollapseAll();
                    DragHelper.ShowCursor(0);
                    isCursorShowed = false;
                    treeView.Nodes[0].Expand();
                    treeView.SelectedNode = dragNode.Parent;
                    treeView.DoDragDrop(bmp, DragDropEffects.Move);
                    DragHelper.ImageList_EndDrag();

                }
            }
        }

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            // Compute drag position and move image
            Point formP = treeView.PointToClient(new Point(e.X, e.Y));

            DragHelper.ImageList_DragMove(formP.X - treeView.Left, formP.Y);

            // Get actual drop node
            TreeNode dropNode = this.treeView.GetNodeAt(this.treeView.PointToClient(new Point(e.X, e.Y)));
            if (dropNode == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            e.Effect = DragDropEffects.Move;

            // if mouse is on a new node select it
            //if (this.tempDropNode != dropNode)
            if (dropNode.Level == 1)
            {
                DragHelper.ImageList_DragShowNolock(false);
                this.treeView.SelectedNode = dropNode;
                DragHelper.ImageList_DragShowNolock(true);
                tempDropNode = dropNode;
            }

            // Avoid that drop node is child of drag node 
            TreeNode tmpNode = dropNode;
            while (tmpNode.Parent != null)
            {
                if (tmpNode.Parent == this.dragNode) e.Effect = DragDropEffects.None;
                tmpNode = tmpNode.Parent;
            }

        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            // Unlock updates
            DragHelper.ImageList_DragLeave(this.treeView.Handle);

            // Get drop node
            //TreeNode dropNode = this.treeView1.GetNodeAt(this.treeView1.PointToClient(new Point(e.X, e.Y)));
            TreeNode dropNode = treeView.SelectedNode;
            LocOperation operation = new LocOperation();
            operation.Operation = LocOperationType.移动;
            operation.OperationNodeLevel = 2;
            operation.OriLabNode = (TreeNode)dragNode.Parent.Clone();
            operation.OriLabIndex = dragNode.Parent.Index;
            operation.OriLocNode = (TreeNode)dragNode.Clone();
            operation.OriLocIndex = dragNode.Index;

            // If drop node isn't equal to drag node, add drag node as child of drop node
            //if (this.dragNode != dropNode)

            if (dropNode.Level > 0 && dropNode.Parent != dragNode.Parent && dropNode != dragNode.Parent)
            {
                // Remove drag node from parent
                if (this.dragNode.Parent == null)
                {
                    this.treeView.Nodes.Remove(this.dragNode);
                }
                else
                {
                    this.dragNode.Parent.Nodes.Remove(this.dragNode);
                }

                // Add drag node to drop node
                if (dropNode.Level == 1)
                {
                    dropNode.Nodes.Add(this.dragNode);
                    dropNode.ExpandAll();
                    treeView.SelectedNode = dragNode;
                }
                else
                {
                    dropNode.Parent.Nodes.Add(dragNode);
                    dropNode.Parent.ExpandAll();
                    treeView.SelectedNode = dragNode;
                }
                operation.DesLabNode = (TreeNode)dropNode.Clone();
                operation.DesLabIndex = dropNode.Index;
                operation.DesLocNode = (TreeNode)dragNode.Clone();
                operation.DesLocIndex = dragNode.Index;
                ListLocOperation.Add(operation);
                listBox.Items.Add(ListLocOperation.Last().GetInfoStr());
                //添加移动操作

                toolBtnRedo.Enabled = true;
                toolBtnSave.Enabled = true;
                // Set drag node to null
                this.dragNode = null;

                // Disable scroll timer
                timerDrag.Enabled = false;
            }
            else
            {
                dragNode.Parent.Expand();
                treeView.SelectedNode = dragNode;
            }
            DragHelper.ShowCursor(1);
            isCursorShowed = true;
        }

        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            DragHelper.ImageList_DragEnter(this.treeView.Handle, e.X - this.treeView.Left,
                e.Y - this.treeView.Top);
            timerDrag.Enabled = true;
            if (isCursorShowed)
            {
                DragHelper.ShowCursor(0);
                isCursorShowed = false;
            }

        }

        private void treeView1_DragLeave(object sender, EventArgs e)
        {
            DragHelper.ImageList_DragLeave(this.treeView.Handle);
            timerDrag.Enabled = false;
            if (!isCursorShowed)
            {
                DragHelper.ShowCursor(1);
                isCursorShowed = true;
            }

        }

        private void treeView1_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effect == DragDropEffects.Move)
            {
                // Show pointer cursor while dragging
                e.UseDefaultCursors = false;
                treeView.Cursor = Cursors.Default;
            }
            else e.UseDefaultCursors = true;
        }
        private void timerDrag_Tick(object sender, EventArgs e)
        {
            // get node at mouse position
            Point pt = PointToClient(System.Windows.Forms.Control.MousePosition);
            TreeNode node = this.treeView.GetNodeAt(pt);

            if (node == null) return;

            // if mouse is near to the top, scroll up
            if (pt.Y < 30)
            {
                // set actual node to the upper one
                if (node.PrevVisibleNode != null)
                {
                    node = node.PrevVisibleNode;

                    // hide drag image
                    DragHelper.ImageList_DragShowNolock(false);
                    // scroll and refresh
                    node.EnsureVisible();
                    this.treeView.Refresh();
                    // show drag image
                    DragHelper.ImageList_DragShowNolock(true);

                }
            }
            // if mouse is near to the bottom, scroll down
            else if (pt.Y > this.treeView.Size.Height - 30)
            {
                if (node.NextVisibleNode != null)
                {
                    node = node.NextVisibleNode;

                    DragHelper.ImageList_DragShowNolock(false);
                    node.EnsureVisible();
                    this.treeView.Refresh();
                    DragHelper.ImageList_DragShowNolock(true);
                }
            }
        }
        private void toolBtnAdd_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;
            treeView.LabelEdit = true;
            if (selectedNode == null)
            {
                return;
            }
            int maxLocId = GetMaxLocId(treeView.Nodes);
            if (selectedNode.Level == 0)
            {
                oriNode = selectedNode.Nodes.Add("新实验室");
                oriNode.Tag = maxLocId + 1;
                selectedNode.Expand();
                treeView.SelectedNode = oriNode;
                oriNode.BeginEdit();
                locOperType = LocOperationType.添加;
                //newLabCount++;
            }
            else if (selectedNode.Level == 1)
            {
                oriNode = selectedNode.Nodes.Add("新存放位置");
                oriNode.Tag = maxLocId + 1;
                selectedNode.Expand();
                treeView.SelectedNode = oriNode;
                oriNode.BeginEdit();
                locOperType = LocOperationType.添加;
                //newLocCount++;
            }
            else if (selectedNode.Level == 2)
            {
                oriNode = selectedNode.Parent.Nodes.Add("新存放位置");
                oriNode.Tag = maxLocId + 1;
                selectedNode.Parent.Expand();
                treeView.SelectedNode = oriNode;
                oriNode.BeginEdit();
                locOperType = LocOperationType.添加;
                //newLocCount++;
            }
        }
        private void toolBtnMod_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;
            treeView.LabelEdit = true;
            if (selectedNode == null)
            {
                return;
            }
            selectedNode.BeginEdit();
            oriNode = selectedNode;
            locOperType = LocOperationType.修改;
        }
        private void toolBtnDel_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView.SelectedNode;
            if (selectedNode == null)
            {
                return;
            }
            if (selectedNode.Level == 2)
            {
                int chemCount = LocationDAL.GetChemCountOfLoc((int)selectedNode.Tag);
                if (chemCount > 0)
                    MessageBox.Show(string.Format("该位置有{0}个药品正在使用，不可删除", chemCount), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    LocOperation operation = new LocOperation();
                    operation.Operation = LocOperationType.删除;
                    operation.OperationNodeLevel = 2;
                    operation.OriLabNode = (TreeNode)selectedNode.Parent.Clone();
                    operation.OriLabIndex = selectedNode.Parent.Index;
                    operation.OriLocNode = (TreeNode)selectedNode.Clone();
                    operation.OriLocIndex = selectedNode.Index;
                    ListLocOperation.Add(operation);

                    listBox.Items.Add(ListLocOperation.Last().GetInfoStr());
                    selectedNode.Remove();
                    toolBtnRedo.Enabled = true;
                    toolBtnSave.Enabled = true;
                }
            }
            else if (selectedNode.Level == 1)
            {
                int childCount = selectedNode.Nodes.Count;
                if (childCount > 0)
                    MessageBox.Show(string.Format("该实验室有{0}个位置正在使用，不可删除", childCount), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    LocOperation operation = new LocOperation();
                    operation.Operation = LocOperationType.删除;
                    operation.OperationNodeLevel = 1;
                    operation.OriLabNode = (TreeNode)selectedNode.Clone();
                    operation.OriLabIndex = selectedNode.Index;
                    ListLocOperation.Add(operation);
                    listBox.Items.Add(ListLocOperation.Last().GetInfoStr());
                    selectedNode.Remove();
                    toolBtnRedo.Enabled = true;
                    toolBtnSave.Enabled = true;
                }
            }
        }
        private void toolBtnRedo_Click(object sender, EventArgs e)
        {
            if (ListLocOperation.Count > 0)
            {
                //修改节点回原状态
                LocOperation lastOperation = ListLocOperation.Last();
                switch (lastOperation.Operation)
                {
                    case LocOperationType.添加:
                        if (lastOperation.OperationNodeLevel == 1)
                        {
                            treeView.Nodes[0].Nodes[lastOperation.OriLabIndex].Remove();
                            if (treeView.Nodes[0].Nodes.Count == 0 || lastOperation.OriLabIndex == 0)
                                treeView.SelectedNode = treeView.Nodes[0].Nodes[lastOperation.OriLabIndex];
                            else
                                treeView.SelectedNode = treeView.Nodes[0].Nodes[lastOperation.OriLabIndex - 1];
                        }
                        else
                        {
                            treeView.Nodes[0].Nodes[lastOperation.OriLabIndex].Nodes[lastOperation.OriLocIndex].Remove();
                            if (treeView.Nodes[0].Nodes[lastOperation.OriLabIndex].Nodes.Count == 0 || lastOperation.OriLocIndex == 0)
                                treeView.SelectedNode = treeView.Nodes[0].Nodes[lastOperation.OriLabIndex];
                            else
                                treeView.SelectedNode = treeView.Nodes[0].Nodes[lastOperation.OriLabIndex].Nodes[lastOperation.OriLocIndex - 1];
                        }
                        break;
                    case LocOperationType.修改:
                        if (lastOperation.OperationNodeLevel == 0)
                        {
                            treeView.Nodes[0].Text = lastOperation.OriLabNode.Text;
                            treeView.SelectedNode = treeView.Nodes[0];
                        }
                        else if (lastOperation.OperationNodeLevel == 1)
                        {
                            treeView.Nodes[0].Nodes[lastOperation.OriLabIndex].Text = lastOperation.OriLabNode.Text;
                            treeView.SelectedNode = treeView.Nodes[0].Nodes[lastOperation.OriLabIndex];
                        }
                        else
                        {
                            treeView.Nodes[0].Nodes[lastOperation.OriLabIndex].Nodes[lastOperation.OriLocIndex].Text =
                                lastOperation.OriLocNode.Text;
                            treeView.SelectedNode = treeView.Nodes[0].Nodes[lastOperation.OriLabIndex].Nodes[lastOperation.OriLocIndex];
                        }
                        break;
                    case LocOperationType.删除:
                        if (lastOperation.OperationNodeLevel == 1)
                        {
                            treeView.Nodes[0].Nodes.Insert(lastOperation.OriLabIndex, lastOperation.OriLabNode);

                            treeView.SelectedNode = treeView.Nodes[0].Nodes[lastOperation.OriLabIndex];
                        }
                        else
                        {
                            treeView.Nodes[0].Nodes[lastOperation.OriLabIndex].Nodes.Insert(lastOperation.OriLocIndex, lastOperation.OriLocNode);
                            treeView.SelectedNode = treeView.Nodes[0].Nodes[lastOperation.OriLabIndex].Nodes[lastOperation.OriLocIndex];
                        }
                        break;
                    case LocOperationType.移动:
                        treeView.Nodes[0].Nodes[lastOperation.OriLabIndex].Nodes.Insert(lastOperation.OriLocIndex, lastOperation.OriLocNode);
                        treeView.Nodes[0].Nodes[lastOperation.DesLabIndex].Nodes.RemoveAt(lastOperation.DesLocIndex);
                        treeView.SelectedNode = treeView.Nodes[0].Nodes[lastOperation.OriLabIndex].Nodes[lastOperation.OriLocIndex];
                        break;
                    default:
                        break;
                }
                //
                listBox.Items.RemoveAt(listBox.Items.Count - 1);
                ListLocOperation.Remove(lastOperation);
                if (ListLocOperation.Count == 0)
                {
                    toolBtnRedo.Enabled = false;
                    toolBtnSave.Enabled = false;
                }
            }
        }
        private void toolBtnSave_Click(object sender, EventArgs e)
        {
            TreeNode reNode = GetReNode(treeView.Nodes[0]);
            if (reNode != null)
            {
                MessageBox.Show(string.Format("存在重复位置名：{0}，请修改后保存", reNode.Text), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult res = MessageBox.Show("该操作无法撤销，请谨慎操作", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.OK)
            {
                int count = 0;
                foreach (LocOperation operation in ListLocOperation)
                {
                    count++;
                    LocationDAL.UpdateLoc(operation);
                    toolStripProgressBar1.Value = count / ListLocOperation.Count * toolStripProgressBar1.Maximum;
                }
                ListLocOperation.Clear();
                listBox.Items.Clear();
                toolBtnRedo.Enabled = false;
                toolBtnSave.Enabled = false;
                MessageBox.Show("操作成功执行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private int GetMaxLocId(TreeNodeCollection nodeCollection)
        {
            if (nodeCollection.Count > 0)
            {
                int max = (int)nodeCollection[0].Tag;
                foreach (TreeNode node in nodeCollection)
                {
                    if ((int)node.Tag > max)
                        max = (int)node.Tag;
                    int temp = GetMaxLocId(node.Nodes);
                    if (temp > max)
                        max = temp;
                }
                return max;
            }
            return 0;
        }
        private void treeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (locOperType == LocOperationType.添加)
            {
                if (e.Label != null)
                {
                    oriNode.Text = e.Label;
                }
                LocOperation operation = new LocOperation();
                operation.Operation = LocOperationType.添加;
                operation.OperationNodeLevel = oriNode.Level;
                switch (operation.OperationNodeLevel)
                {
                    case 1:
                        operation.OriLabNode = (TreeNode)oriNode.Clone();
                        operation.OriLabIndex = oriNode.Index;
                        break;
                    case 2:
                        operation.OriLabNode = (TreeNode)oriNode.Parent.Clone();
                        operation.OriLabIndex = oriNode.Parent.Index;
                        operation.OriLocNode = (TreeNode)oriNode.Clone();
                        operation.OriLocIndex = oriNode.Index;
                        break;
                    default:
                        break;
                }
                ListLocOperation.Add(operation);
                listBox.Items.Add(ListLocOperation.Last().GetInfoStr());
            }
            else if (locOperType == LocOperationType.修改)
            {
                if (e.Label != null)
                {
                    LocOperation operation = new LocOperation();
                    operation.Operation = LocOperationType.修改;
                    operation.OperationNodeLevel = oriNode.Level;
                    switch (operation.OperationNodeLevel)
                    {
                        case 0:
                            operation.OriLabNode = (TreeNode)oriNode.Clone();
                            operation.DesLabNode = (TreeNode)oriNode.Clone();
                            operation.DesLabNode.Text = e.Label;
                            break;
                        case 1:
                            operation.OriLabNode = (TreeNode)oriNode.Clone();
                            operation.OriLabIndex = oriNode.Index;
                            operation.DesLabNode = (TreeNode)oriNode.Clone();
                            operation.DesLabNode.Text = e.Label;
                            operation.DesLabIndex = oriNode.Index;
                            break;
                        case 2:
                            operation.OriLabNode = (TreeNode)oriNode.Parent.Clone();
                            operation.OriLabIndex = oriNode.Parent.Index;
                            operation.OriLocNode = (TreeNode)oriNode.Clone();
                            operation.OriLocIndex = oriNode.Index;
                            operation.DesLocNode = (TreeNode)oriNode.Clone();
                            operation.DesLocNode.Text = e.Label;
                            operation.DesLocIndex = oriNode.Index;
                            break;
                        default:
                            break;
                    }
                    ListLocOperation.Add(operation);
                    listBox.Items.Add(ListLocOperation.Last().GetInfoStr());
                }
            }
            locOperType = LocOperationType.无操作;
            toolBtnAdd.Enabled = true;
            toolBtnMod.Enabled = true;
            toolBtnDel.Enabled = true;
            if (ListLocOperation.Count > 0)
            {
                toolBtnRedo.Enabled = true;
                toolBtnSave.Enabled = true;
            }
            treeView.LabelEdit = false;


        }
        private void treeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            toolBtnAdd.Enabled = false;
            toolBtnMod.Enabled = false;
            toolBtnDel.Enabled = false;
            toolBtnRedo.Enabled = false;
            toolBtnSave.Enabled = false;
        }
        private bool IsExist(TreeNode node)
        {
            bool ret = false;
            foreach (TreeNode item in node.Parent.Nodes)
            {
                if (item != node && item.Text == node.Text)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        private TreeNode GetReNode(TreeNode node)
        {
            TreeNode reNode = null;
            foreach (TreeNode item in node.Nodes)
            {
                for (int i = item.Index; i < node.Nodes.Count; i++)
                {
                    if (item.Text == node.Nodes[i].Text && item != node.Nodes[i])
                        return item;
                }
                if (item.Nodes.Count > 0)
                    reNode = GetReNode(item);
            }
            return reNode;
        }
    }
}
