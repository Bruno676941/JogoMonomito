using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoMonomito
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello, World!");

            List<string> lista = new List<string>();

            lista.Add("Item 1");
            lista.Add("Item 2");
            lista.Add("Item 3");

            foreach (var item in lista)
            {
                System.Console.WriteLine(item);
            }

        }
    }
}
