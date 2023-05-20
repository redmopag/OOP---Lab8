using Project.Source.Shapes;
using Project.Source.Utils;
using Project.Source.Utils.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Source
{
    internal class Tree : CSubject, IObserver
    {
        private TreeView _tree;

        public Tree(TreeView tree)
        {
            _tree = tree;
            _tree.CheckBoxes = true;
        }
        private void processNode(TreeNode node, BaseShape shape)
        {
            TreeNode newNode = new TreeNode();
            if (shape is CDecorator decorator)
            {
                shape = decorator.getShape();
                newNode.Checked = true;
            }
            if (shape is CComposite group)
            {
                for (int i = 0; i < group.Count; ++i)
                    processNode(newNode, group.getShape(i));
                for (int i = 0; i < newNode.Nodes.Count; ++i)
                    newNode.Nodes[i].Checked = false;
                newNode.Text = group.className();
                newNode.Tag = group;
            }
            else
            {
                newNode.Text = shape.className();
                newNode.Tag = shape;
            }
            node.Nodes.Add(newNode);
        }
        public void subjectChange(CSubject subject)
        {
            if(subject is Container container)
            {
                _tree.Nodes.Clear();
                TreeNode node = new TreeNode();
                for (int i = 0; i < container.Count; ++i)
                    processNode(node, container.getShape(i));
                node.Text = "Tree";
                _tree.Nodes.Add(node);
                _tree.ExpandAll();
            }
        }
        public TreeNode getNodes() { return _tree.Nodes[0]; }
    }
}
