using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree t = new Tree();
            int n = 50;
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                t.Insert(rnd.Next(1, 200),"a");
            t.Insert(1,"b");
            t.Delete(1);
            int min = t.Minimum(t.root).key;
            Console.WriteLine(min);
            Console.ReadKey();
        }
    }
}