using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication24
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree t = new Tree();//Задача 18.8(нахождение минимального элемента дерева)
            int n = 50;
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                t.Insert(rnd.Next(1, 100));
            t.Insert(10);
            int min = t.Minimum(t.root).inf;
            t.GoWidth();
            Console.WriteLine(min);

            int p = t.Parent(t.Search(10), 2).inf;//проверка правильности метода Parent
            Console.WriteLine(p);
            Console.ReadKey();
        }
    }
}