using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication26
{
    class Program
    {
        public static void Main(string[] args)
        {
            Hash H = new Hash();
            H.HashInsert("New York", 14);
            H.HashInsert("Chicago", 17);
            H.HashInsert("London", 74);
            H.HashInsert("Moskow", 255);
            H.HashInsert("Voronezh", 139);

            H.HashDelete("London");
            Console.WriteLine(H.HashSearch("Voronezh"));
            Console.ReadLine(); 
        }

    }
}