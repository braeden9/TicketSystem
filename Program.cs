using System;

namespace ticketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string resp = "";
            do {
                Console.WriteLine("1. Create ticket");
                Console.WriteLine("2. Display tickets");
                resp = Console.ReadLine();
            } while(resp == "1" || resp == "2");
        }
    }
}
