using OOP3;
using OOP4._1.Composite;
using OOP4._1.Decorator;
using OOP4._1.Service;
using OOP4._1.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4._1.Observer
{
    public class TreeViewObserver : CObject, ICObserver
    {
        private TreeView _treeView;
        public TreeViewObserver(TreeView treeView)
        {
            _treeView = treeView;
        }
        private void ProcessNode(TreeNode treeNode, Container<Shape> shapes)
        {
            foreach (Shape shape in shapes)
            {
                TreeNode _treeNode = new TreeNode(shape.Who());
                if (shape is ShapeDecorator)
                {
                    _treeNode.BackColor = Color.Gray;
                    _treeView.SelectedNode = _treeNode;
                }
                if (shape is CGroup cGroup)
                {
                    ProcessNode(_treeNode, cGroup.GetShapes());
                }
                treeNode.Nodes.Add(_treeNode);
            }
        }
        public string GetSelectedName()
        {
            if (_treeView.SelectedNode == null)
                return String.Empty;
            return _treeView.SelectedNode.Text;
        }
        public void OnSubjectChanged(CObject cObject)
        {
            _treeView.Nodes.Clear();
            TreeNode treeNode = new TreeNode("Фигуры");
            if (cObject is ShapeService shapeService)
            {
                ProcessNode(treeNode, shapeService.GetShapes());
            }
            _treeView.Nodes.Add(treeNode);
            _treeView.ExpandAll();
        }
        public void OnSubjectSelect(CObject cObject)
        {
            int i = 0;
            foreach(TreeNode node in _treeView.Nodes[0].Nodes)
            {
                if (node.Text == cObject.Who())
                {
                    _treeView.SelectedNode = _treeView.Nodes[0].Nodes[i];
                }
                i++;
            }
        }
        public void NodesToWhite()
        {
            ChangeNodeColor(_treeView.Nodes[0]);
        }
        private void ChangeNodeColor(TreeNode treeNode)
        {
            foreach (TreeNode _node in treeNode.Nodes)
            {
                if (_node.Nodes.Count > 1)
                {
                    ChangeNodeColor(_node);
                }
                _node.BackColor = Color.White;
            }
        }

        public void OnSubjectMove(int x, int y)
        {
            return;
        }
    }
}
