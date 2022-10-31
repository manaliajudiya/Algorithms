using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppCore
{
    class clsTree
    {
        public void QMethod()
        {
            var x = new Queue<string>();
            x.Enqueue("1");
            x.Enqueue("2");
            x.Enqueue("3");
            string y = x.Dequeue();
            Console.WriteLine(y);


            Console.WriteLine("Count:" + x.Count);
            /*while(x.Count > 0)
            {
                Console.WriteLine("El:" + x.)
            }*/
        }

        public void TMethod()
        {
            int[] arr = new int[] { 2, 8, 5, 3, 9, 1 };
            TreeNode root = CreateBinaryTree(arr);
            Console.WriteLine("DFS");
            DFS(root);
            Console.WriteLine("BFS");
            BFS(root);
        }

        private void DFS(TreeNode root)
        {
            if (root != null)
            {
                Console.WriteLine(root.val);
                DFS(root.left);
                DFS(root.right);
            }
            else
            {
                Console.WriteLine("null");
            }
        }

        private void BFS(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var node = q.Dequeue();
                Console.WriteLine(node.val);


                TreeNode left = node.left;
                TreeNode right = node.right;

                if (node.left != null)
                {
                    q.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    q.Enqueue(node.right);
                }
            }
        }

        // Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public bool CheckSymmetric(TreeNode root)
        {
            Queue q = new Queue();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                TreeNode x = (TreeNode)q.Dequeue();
                Console.WriteLine(x.val);
            }
            return false;
        }

        //Create BST from Sorted Array
        private static int[] treeEl;
        public TreeNode CreateBinaryTree(int[] arr)
        {
            TreeNode root = new TreeNode();
            treeEl = arr;
            return helper(0, arr.Length - 1);
        }

        private TreeNode helper(int left, int right)
        {
            //Input : start , End position
            if (left > right) { return null; }

            //Select root index
            int r = (left + right) / 2;

            //Traversal
            TreeNode root = new TreeNode(treeEl[r]);
            root.left = helper(left, r - 1);
            root.right = helper(r + 1, right);

            return root;
        }

        //Use DFS.
        //1. right 2.left - Add only 1st of the level
        public IList<int> RightSideView(TreeNode root)
        {
            DFS_R(root,0);
            return nodes;
        }


        private List<int> nodes = new List<int>();
        private void DFS_R(TreeNode root, int l)
        {
            if (root != null)
            {
                //Add only first elements that comes(right)
                if (l == nodes.Count)
                {
                    nodes.Add(root.val);
                }
                //{ Console.WriteLine("val:" + root.val + ",l:" + l);}
                if (root.right != null) { DFS_R(root.right, l + 1); }
                if (root.left != null)
                {
                    //Console.WriteLine("left:" + root.left.val);
                    DFS_R(root.left, l + 1);

                }

            }

        }


    }
}
