using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bombApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Please, enter the list of wires: ");
            BombService bombService = new BombService(Console.ReadLine().Split(new char[] { ',' }));
            Console.WriteLine(bombService.defuse());
            Console.ReadKey();
        }
    }
}
