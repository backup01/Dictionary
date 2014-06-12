using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication26
{
    class Hash
    {
        class Node
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
            this.size = 10241;
            array = new Node[size];
        }

        public int HashFunc(string key)
        {
            int m = 0, N = key.Length;
            for (int i = 0; i < m; i++)
            {
                m += i * (int)key[i];
                m %= size;
            }
            return m;
        }

        public void HashInsert(string key,int inf)
        {
            int m=HashFunc(key);
            Node p=array[m];
            bool x=false;
            while ((p!=null)&&(!x))
                if (p.key==key)
                {
                    x=true;
                    p.inf=inf;
                }
                else p=p.next;
            array[m]=new Node(key,inf,array[m]);
        }

        public void HashDelete(string key)
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

        public int HashSearch(string key)
        {
            int m = HashFunc(key);
            Node p = array[m];
            int res = 0;
            bool x = false;
            while ((p!=null)&&(!x))
                if (p.key==key)
                {
                    x=true;
                    res=p.inf;
                }
                else p=p.next;
            return res;
        }
    }
}

