using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication27
{
    class Program
    {
        static void Main(string[] args)
        {
            Hash H = new Hash();
            H.Insert("London", 14);
            H.Insert("New York", 14);
            H.Insert("York New", 14);
            H.Insert("Chicago", 14);
            H.Insert("Moskow", 14);
            H.Insert("Voronezh", 14);
            H.Insert("Amsterdam", 14);

            H.Delete("London");
            /*Console.WriteLine(H.Search("New York"));
            Console.WriteLine(H.Search("York New"));
            Console.WriteLine(H.Search("Chicago"));
            Console.WriteLine(H.Search("London"));
            Console.WriteLine(H.Search("Moskow"));
            Console.WriteLine(H.Search("Voronezh"));*/
            H.Print();
            Console.ReadLine();
        }
    }
}