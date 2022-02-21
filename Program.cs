using System;
using System.IO;

namespace ticketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.csv";
            Int64 nextTicketID = 1;
            string resp = "";
            
            do {
                Console.WriteLine("1. Create ticket");
                Console.WriteLine("2. Display tickets");
                resp = Console.ReadLine();
                
                Console.Clear();

                if (resp == "1") {
                    Int64 ticketID = nextTicketID;

                    Console.WriteLine("Who are you?");
                    string submitter = Console.ReadLine();

                    Console.WriteLine("Please explain your issue.");
                    string summary = Console.ReadLine();

                    string status = "Open";

                    Console.WriteLine("How big is this issue? (1-Low, 2-Med, 3-High)");
                    string priorityResp = Console.ReadLine();
                    string priority = priorityResp == "3" ? "High" : priorityResp == "2" ? "Med" : "Low";
                    
                    Console.WriteLine("Who is assigned to this?");
                    string assigned = Console.ReadLine();

                    Console.WriteLine("Who is watching this? (Seperate with comma)");
                    string watching = Console.ReadLine().Replace(',','|');

                    StreamWriter sw = new StreamWriter(file);
                    sw.WriteLine($"{ticketID},{summary},{status},{priority},{submitter},{assigned},{watching}");
                    sw.Close();
                }

            } while (resp == "1" || resp == "2");
        }
    }
}
