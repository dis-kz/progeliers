using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDimon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, bro! Enter your name, please...");
            string s = Console.ReadLine();

            Console.WriteLine($"I'm happy greeting you, Mr.{s}!");
        }
    }
}
