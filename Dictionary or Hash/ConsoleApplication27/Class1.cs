using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication27
{
    public class Tree
    {
        public Node head;
        public class Node
        {
            public string key;
            public int inf;
            public Node left;
            public Node right;
            public Node parent;
            public Node next;
            public Node(string key, int inf, Node left, Node right, Node parent)
            {
                this.key = key;
                this.inf = inf;
                this.left = left;
                this.right = right;
                this.parent = parent;
            }

            public void WriteNode(StreamWriter w)
            {
                if (this != null)
                {
                    w.WriteLine(Convert.ToString(key) + "[label = \"" + Convert.ToString(key) + ":" + inf + "\"];");
                    if (left != null)
                    {
                        w.WriteLine(Convert.ToString(key) + "->" + Convert.ToString(left.key) + ";");
                        left.WriteNode(w);
                    }
                    if (right != null)
                    {
                        w.WriteLine(Convert.ToString(key) + "->" + Convert.ToString(right.key) + ";");
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

        public void Insert(string key, int inf)
        {
            if (root == null)
                root = new Node(key, inf, null, null, null);
            else
            {
                Node p = root;
                bool ok = false;
                while (!ok)
                {
                    if (key.CompareTo(p.key) > 0)
                        if (p.right == null)
                        {
                            p.right = new Node(key, inf, null, null, p);
                            ok = true;
                        }
                        else p = p.right;
                    else
                        if (key.CompareTo(p.key) < 0)
                            if (p.left == null)
                            {
                                p.left = new Node(key, inf, null, null, p);
                                ok = true;
                            }
                            else p = p.left;
                        else
                        {
                            p.inf = inf;
                            ok = true;
                        }
                }
            }
        }

        public void GoWidth()
        {
            FileStream f = new FileStream("output.txt", FileMode.Create);
            StreamWriter w = new StreamWriter(f);
            w.WriteLine("digraph G {");
            root.WriteNode(w);

            int k = 1;

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            Node x;
            while (queue.Count != 0)
            {
                x = queue.Dequeue();

                 w.WriteLine(Convert.ToString(x.inf) + "[" + "label" + "=" + "\"" + Convert.ToString(x.inf) + "," + k + "\"" + "]");
                k++;

                if (x.left != null)
                    queue.Enqueue(x.left);
                if (x.right != null)
                    queue.Enqueue(x.right);
            }

            w.WriteLine("}");
            w.Close();
            f.Close();
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

        private Node Find(ref Node t, string k)
        {
            if ((t == null) || (k == t.key))
                return t;
            else
                if (k.CompareTo(t.key) < 0)
                    return Find(ref t.left, k);
                else return Find(ref t.right, k);
        }

        public Node Find(string key)
        {
            return Find(ref root, key);
        }

        public int Search(string key)
        {
            Node p = Find(key);
            if (p == null) return 0;
            return p.inf;
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
                z.key = y.key;
            z.inf = y.inf;
        }
        

        public void Delete(string key)
        {
            Node p = Find(key);
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

