using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabManager.Model
{
    public enum LocOperationType
    {
        无操作 = 0,
        添加 = 1,
        修改 = 2,
        删除 = 3,
        移动 = 4,
    }
    public class LocOperation
    {
        public LocOperationType Operation { get; set; }
        public int OperationNodeLevel { get; set; }
        public TreeNode OriLabNode { get; set; }
        public TreeNode OriLocNode { get; set; }
        public TreeNode DesLabNode { get; set; }
        public TreeNode DesLocNode { get; set; }
        public int OriLabIndex { get; set; }
        public int OriLocIndex { get; set; }
        public int DesLabIndex { get; set; }
        public int DesLocIndex { get; set; }
        //public LocOperation(LocOperationType operation,TreeNode oriParent, TreeNode oriNode,int oriIndex = 0, TreeNode desParent = null, TreeNode desNode = null, int desIndex = 0)
        //{
        //    Operation = operation;
        //    OriParent = oriParent;
        //    OriNode = oriNode;
        //    OriIndex = oriIndex;
        //    DesParent = desParent;
        //    DesNode = desNode;
        //    DesIndex = desIndex;
        //}
        public string GetInfoStr()
        {
            string info = "操作失败，请联系管理员";
            switch (Operation)
            {
                case LocOperationType.添加:
                    if (OperationNodeLevel == 1)
                        info = string.Format("添加实验室 {0}", OriLabNode.Text);
                    else
                        info = string.Format("添加位置 {0}({1})", OriLocNode.Text, OriLabNode.Text);
                    break;
                case LocOperationType.修改:
                    if (OperationNodeLevel == 0)
                        info = string.Format("修改课题组 {0} 为 {1}", OriLabNode.Text, DesLabNode.Text);
                    else if (OperationNodeLevel == 1)
                        info = string.Format("修改实验室 {0} 为 {1}", OriLabNode.Text, DesLabNode.Text);
                    else
                        info = string.Format("修改位置 {0} 为 {1}({2})", OriLocNode.Text, DesLocNode.Text, OriLabNode.Text);
                    break;
                case LocOperationType.删除:
                    if (OperationNodeLevel == 1)
                        info = string.Format("删除实验室 {0}", OriLabNode.Text);
                    else
                        info = string.Format("删除位置 {0}({1})", OriLocNode.Text, OriLabNode.Text);
                    break;
                case LocOperationType.移动:
                    info = string.Format("移动 {0}({1}) 到 {0}({2})", OriLocNode.Text, OriLabNode.Text, DesLabNode.Text);
                    break;
                default:
                    break;
            }
            return info;
        }
    }
}
