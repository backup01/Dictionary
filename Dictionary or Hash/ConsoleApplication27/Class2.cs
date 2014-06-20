using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27
{
    public class Hash
    {
        public Node head;
        public class Node
        {
            public string key;
            public int inf;
            public Node next;
           

            public Node(string key, int inf, Node next)
            {
                this.key = key;
                this.inf = inf;
                this.next = next;
            }
        }
        private Node[] array;
        int size;

        public Hash()
        {
            // this.size = 10241;
            this.size = 7;
            array = new Node[size];
        }

        public int HashFunc(string key)
        {
            int m = 0, N = key.Length;
            for (int i = 0; i < N; i++)
            {
                m += i * (int)key[i];
                m %= size;
            }
            return m;
        }

        public void Insert(string key, int inf)
        {
            int m = HashFunc(key);
            Node p = array[m];
            bool x = false;
            while ((p != null) && (!x))
                if (p.key == key)
                {
                    x = true;
                    p.inf = inf;
                }
                else p = p.next;
            array[m] = new Node(key, inf, array[m]);
        }

        public void Delete(string key)
        {
            int m = HashFunc(key);
            if (array[m] == null) throw new IndexOutOfRangeException();
            if (array[m].key == key) array[m] = array[m].next;
            else
            {
                Node p = array[m];
                bool x = false;
                while ((p.next != null) && (!x))
                    if (p.next.key == key)
                        x = true;
                    else p = p.next;
                if (x)
                    p.next = p.next.next;
            }
        }

        public int Search(string key)
        {
            int m = HashFunc(key);
            Node p = array[m];
            int res = 0;
            bool x = false;
            while ((p != null) && (!x))
                if (p.key == key)
                {
                    x = true;
                    res = p.inf;
                }
                else p = p.next;
            return res;
        }

        public void Print() 
        {
            for (int i = 0; i < size; i++)
            {
                Node p = array[i];
                Console.Write("{0}\t", i);
                while (p != null)
                {
                    Console.Write("({0}, {1}) ", p.key, p.inf);
                    p = p.next;
                }
                Console.WriteLine();
            }
                
        }
    }
}

