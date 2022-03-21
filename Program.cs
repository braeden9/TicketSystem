using System;
using System.IO;
using System.Collections.Generic;

namespace TicketSysClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.csv";
            
            string resp = "";
            
            do {
                Console.WriteLine("1. Create ticket");
                Console.WriteLine("2. Display tickets");
                Console.WriteLine("Anything else to quit");
                resp = Console.ReadLine();
                
                Console.Clear();

                if (resp == "1") {
                    Ticket ticket = new Ticket();

                    ticket.ticketID = 1;
                    Console.WriteLine("Who are you?");
                    ticket.submitter = Console.ReadLine();

                    Console.WriteLine("Please explain your issue.");
                    ticket.summary = Console.ReadLine();

                    ticket.status = "Open";

                    Console.WriteLine("How big is this issue? (1-Low, 2-Med, 3-High)");
                    ticket.priority = Int16.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Who is assigned to this?");
                    ticket.assigned = Console.ReadLine();

                    string watchInput;
                    do {
                        Console.WriteLine("Who is watching this? (Enter when done)");
                        watchInput = Console.ReadLine();
                        if (watchInput != "") {                        
                            ticket.watching.Add(Console.ReadLine());
                        }                    
                    } while (watchInput != "");

                    if (ticket.watching.Count == 0) {
                        ticket.watching.Add("none");
                    }

                } else if (resp == "2") {
                    StreamReader sr2 = new StreamReader(file);
                    Console.WriteLine("Id, Summary, Status, Priority, Writter, Assigned, Watching");
                    while (!sr2.EndOfStream) {
                        string line = sr2.ReadLine();
                        Console.WriteLine(line.Replace(",",", ").Replace("|"," & "));
                    }
                    sr2.Close();
                    Console.WriteLine("");
                }

            } while (resp == "1" || resp == "2");
        }
    }
}
