using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication15
{
    class Program
    {
        static void Main(string[] args)
        {
           MyList L=new MyList();
           Console.WriteLine("enter list");
           string A =Convert.ToString(Console.ReadLine());
           string[] tmp = A.Split(' ');
           for (int i = 0; i < tmp.Length; i++)
           {
               L.Add(Convert.ToInt32(tmp[i]));
               L.Print();
               Console.WriteLine("print done");
           }
           Console.ReadLine();
        }
    }
}
