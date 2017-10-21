using System;
using Domaca_zadaca1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<string> list = new GenericList<string>();

            list.Add("Ante");
            list.Add("Luka");
            list.Add("Marko");
            list.Add("Matea");
            list.Add("Ana");
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(list.Contains("ante"));
            Console.WriteLine(list.Contains("Marko"));
            Console.WriteLine(list.IndexOf("Ana"));
            Console.WriteLine(list.Count);
            Console.WriteLine(list.RemoveAt(1));
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine(list.IndexOf("Ana"));
            Console.WriteLine(list.Count);
        }
}
}
