using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Node
    {
        public int Data { get; set; }

        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node() 
        {
            Data = 0;
            Left = null;
            Right = null;
        }

        public Node(int data)
        {
            this.Data = data;
            Left = null;
            Right = null;
        }

        public override string ToString() 
        {
            return Data.ToString();
        }
    }
}
