using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    internal class Program
    {
        private static BSTree bstree = new BSTree();
         private  static void LessonNotesOrder()
        {
            Console.WriteLine("*** Displaying traversal Orders ***");
            bstree.Add(8);
            bstree.Add(3);
            bstree.Add(10);
            bstree.Add(1);
            bstree.Add(6);
            bstree.Add(14);
            bstree.Add(4);
            bstree.Add(7);
            bstree.Add(13);

            Console.WriteLine("- PreOrder");
            Console.WriteLine( bstree.PreOrder());
            Console.WriteLine("\nInOrder");
            Console.WriteLine(bstree.InOrder());
            Console.WriteLine("\nPostOrder");
            Console.WriteLine(bstree.PostOrder());
        }

        private static void CheckDelete()
        {
            Console.WriteLine("*** Insert Data ***");
            bstree.Add(8);
            bstree.Add(3);
            bstree.Add(6);
            bstree.Add(1);
            bstree.Add(4);
            bstree.Add(7);
            bstree.Add(10);
            bstree.Add(14);
            bstree.Add(13);

            Console.WriteLine("- PreOrder");
            Console.WriteLine(bstree.PreOrder());
            Console.WriteLine();
            Console.WriteLine("- Tree Depth");
            //Console.WriteLine(bstree.TreeDepth());

            Console.WriteLine("- Delete");
            Console.WriteLine(bstree.Remove(8));
            Console.WriteLine("- PreOrder");
            Console.WriteLine(bstree.PreOrder());
        }

        private static void FindOps()
        {
            Console.WriteLine("*** Insert Data ***");
            bstree.Add(100);
            bstree.Add(50);
            bstree.Add(20);
            bstree.Add(30);
            bstree.Add(150);
            bstree.Add(125);
            bstree.Add(175);

            Console.WriteLine("- PreOrder");
            Console.WriteLine(bstree.PreOrder());
            Console.WriteLine();
            Console.WriteLine("*** Testing Find ***");
            bstree.Add(50);
            bstree.Add(100);
            bstree.Add(175);
            bstree.Add(200);
            Console.WriteLine("- Tree Depth");
            //Console.WriteLine(bstree.TreeDepth());
        }

        static void Main(string[] args)
        {
            LessonNotesOrder();

            CheckDelete();

            FindOps();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}
