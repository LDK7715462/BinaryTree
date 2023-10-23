using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class BSTree
    {
        public Node Root { get; set; }
        public BSTree()
        {
            Root = null;
        }

        #region -----FUNCTIONS-----

        #region Add/Insert

        public void Add(int data)
        {//UI Call
            Node node = new Node(data);

            if (Root == null)
            { 
                Root = node;
            }
            else
            {
                InsertNode(Root, node);
            }
        }
        private void InsertNode(Node tree, Node node) 
        {// Recursive method used to traverse the tree
            //1. Compare node for less than node in tree
            if(node.Data <  tree.Data)
            {
                if(tree.Left == null)
                {// 2. left is empty, insert node
                    tree.Left = node;
                }
                else
                {// 3. left not empty, traverse tree using recursive call
                    InsertNode(tree.Left, node);
                }
            }
            // 4. Compare node for greater than node in tree
            if(node.Data > tree.Data)
            {
                if(tree.Right == null)
                {// 5. right is empty, insert node
                    tree.Right = node;
                }
                else 
                { // 6. Right not emptry, traverse tree using recursive call
                    InsertNode(tree.Right, node);
                }
            }
        }
        #endregion

        #region Delete

        private Node Delete(Node tree, Node node)
        {
            if (tree == null)
            {// 1. reache4d null side of tree, return to unload stack
                return tree;
            }
            if (node.Data < tree.Data)
            {// 2. traverse left side to find node
                tree.Left = Delete(tree.Left, node);
            }
            else if (node.Data > tree.Data)
            {// 3. Traverse right side to find node
                tree.Right = Delete(tree.Right, node);
            }
            else
            {// 4. found node to delete
                //Check if node has only one child, or no child
                if (tree.Left == null)
                {// 5. Pull right side of tree up
                    return tree. Right;
                }
                else if (tree.Right == null)
                {
                    return tree.Left;
                }
                else
                {/* 7. node has two leaf nodes, get the InOrder successor node
                  * (the smallest), therefore t5raverse the right side and replace 
                  the node found with the current node */
                    tree.Data = MinValue(tree.Right);
                    // 8. traverse the right side of the tree to delete the InOrder successor
                    tree.Right = Delete(tree.Right, node);
                }
            }
            return tree;
        }

        private int MinValue(Node node)
        {// Finds the minimum node in the right side of the tree
            int minval = node.Data;
            while(node.Left != null)
            {// traverse the tree replacing the minVal with the node on the left side of the tree
                minval = node.Left.Data;
                node = node.Left;
            }
            return minval;
        }

        public string Remove(int data)
        {
            Node node = new Node(data);
            node = Search(Root, node);
            if   (node != null)
            {
                Root = Delete(Root, node);
                return "Target:" + data.ToString() + ", NODE removed";
            }
            else
            {
                return "Target:" + data.ToString() + ", NODE not found";
            }
        }

        #endregion

        #region Search

        private Node Search(Node tree, Node node)
        {
            if (tree != null)
            {// 1. Have not reached the end of the branch
                if (node.Data == tree.Data)
                {// 2. found node
                    return tree;
                }
                if (node.Data < tree.Data)
                {// 3. traverse left side
                    return Search(tree.Left, node);
                }
                else
                {// 4. traverse right side
                    return Search(tree.Right, node);
                }
            }// 5. not found
            return null;     
        }

        public string Find(int data)
        {
            Node node = new Node(data);
            node = Search(Root, node);
            if(node != null)
            {
                return "Target" + data.ToString() + " NODE found:" + node.ToString();
            }
            else
            {
                return "Target" + data.ToString() + " NODE not found or tree empty";
            }
        }
        #endregion

        #region Find Tree Depth
        private int TreeDepth(Node treeDepth)
        {
            if (treeDepth == null)
                return 0;

            int leftDepth = TreeDepth(treeDepth.Left);
            int rightDepth = TreeDepth(treeDepth.Right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }
        #endregion

        
        #endregion

        #region -----TRAVERSALS-----

        #region PreOrder
        private string TraversePreOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if(node != null)
            {
                sb.Append(node.ToString() + " ");
                sb.Append(TraversePreOrder(node.Left));
                sb.Append(TraversePreOrder(node.Right));
            }
            return sb.ToString();
        }
        public string PreOrder()
        {
            StringBuilder sb = new StringBuilder();

            if (Root == null)
            {
                sb.Append("Tree is Empty");
            }
            else
            {
                sb.Append(TraversePreOrder(Root));
            }
            return sb.ToString();
        }
        #endregion

        #region InOrder
        private string TraverseInOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append(TraverseInOrder(node.Left));
                sb.Append(node.ToString() + " ");
                sb.Append(TraverseInOrder(node.Right));
            }
            return sb.ToString();
        }
        public string InOrder()
        {
            StringBuilder sb = new StringBuilder();

            if (Root == null)
            {
                sb.Append("Tree is Empty");
            }
            else
            {
                sb.Append(TraverseInOrder(Root));
            }
            return sb.ToString();
        }
        #endregion

        #region PostOrder
        private string TraversePostOrder(Node node)
        {
            StringBuilder sb = new StringBuilder();

            if (node != null)
            {
                sb.Append(TraversePostOrder(node.Left));
                sb.Append(TraversePostOrder(node.Right));
                sb.Append(node.ToString() + " ");
            }
            return sb.ToString();
        }
        public string PostOrder()
        {
            StringBuilder sb = new StringBuilder();

            if (Root == null)
            {
                sb.Append("Tree is Empty");
            }
            else
            {
                sb.Append(TraversePostOrder(Root));
            }
            return sb.ToString();
        }

        #endregion
        #endregion
    }
}
