using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication24
{
    public class Tree
    {
        public class Node
        {
            public int inf;
            public Node left;
            public Node right;
            public Node parent;
            public Node(int inf, Node left, Node right, Node parent)
            {
                this.inf = inf;
                this.left = left;
                this.right = right;
                this.parent = parent;
            }

            public void WriteNode(StreamWriter w)
            {
                if (this != null)
                {
                    if (left != null)
                    {
                        w.WriteLine(Convert.ToString(inf) + "->" + Convert.ToString(left.inf) + ";");
                        left.WriteNode(w);
                    }
                    if (right != null)
                    {
                        w.WriteLine(Convert.ToString(inf) + "->" + Convert.ToString(right.inf) + ";");
                        right.WriteNode(w);
                    }
                }
            }

        }

        public Node root;

        public Tree()
        {
            root = null;
        }
 
        public void Insert(int inf)
        {
            if (root == null)
                root = new Node(inf, null, null, null);
            else
            {
                Node p = root;
                bool ok = false;
                while (!ok)
                {
                    if (inf > p.inf)
                        if (p.right == null)
                        {
                            p.right = new Node(inf, null, null, p);
                            ok = true;
                        }
                        else p = p.right;
                    else
                        if (inf < p.inf)
                            if (p.left == null)
                            {
                                p.left = new Node(inf, null, null, p);
                                ok = true;
                            }
                            else p = p.left;
                        else
                            ok = true;
                }
            }
        }

        public Node Minimum(Node x)
        {
            Node p = x;
            while (p.left != null)
                p = p.left;
            return p;
        }
    
        public Node Maximum(Node x)
        {
            Node p = x;
            while (p.right != null)
                p = p.right;
            return p;
        }

        private Node Search(ref Node t, int k)
        {
            if ((t == null) || (k == t.inf))
                return t;
            else
                if (k < t.inf)
                    return Search(ref t.left, k);
                else return Search(ref t.right, k);
        }

        public Node Search(int inf)
        {
            return Search(ref root, inf);
        }

        public Node Successor(Node p)
        {
            Node x = p;
            if (x.right != null)
                return Minimum(x.right);
            Node y = x.parent;
            while ((y != null) && (x == y.right))
            {
                x = y;
                y = y.parent;
            }
            return y;
        }

        public Node Predecessor(Node p)
        {
            Node x = p;
            if (x.left != null)
                return Maximum(x.left);
            Node y = x.parent;
            while ((y != null) && (x == y.left))
            {
                x = y;
                y = y.parent;
            }
            return y;
        }

        public Node Parent(Node p, int n)
        {            
            Node x = p;
            for (int i = 0; i < n; i++)
                if (x != null)
                    x = x.parent;
            return x;            
        }

        public void Delete(Node z)
        {
            Node x, y;
            if ((z.left == null) || (z.right == null))
                y = z;
            else y = Successor(z);
            if (y.left != null)
                x = y.left;
            else x = y.right;
            if (x != null)
                x.parent = y.parent;
            if (y.parent == null)
                root = x;
            else
                if (y == y.parent.left)
                    y.parent.left = x;
                else y.parent.right = x;
            if (y != z)
                z.inf = y.inf;
        }

        public void Delete(int inf)
        {
            Node p = Search(inf);
            Delete(p);
        }

        public void WriteTree(string path)
        {
            FileStream f = new FileStream(path, FileMode.Create);
            StreamWriter w = new StreamWriter(f);
            w.WriteLine("digraph G {");
            root.WriteNode(w);
            w.WriteLine("}");
            w.Close();
            f.Close();
        }


    }
}
