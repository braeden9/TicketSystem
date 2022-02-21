using System;
using System.IO;
using System.Collections.Generic;

namespace ticketSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "tickets.csv";

            StreamReader sr = new StreamReader(file);
            Int64 nextTicketID = 0;
            while (!sr.EndOfStream) {
                Int64 Id = Int64.Parse(sr.ReadLine().Split(",")[0]);
                if (Id > nextTicketID) {
                    nextTicketID = Id + 1;
                }
            }
            sr.Close();
            
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

                    using (FileStream fs = new FileStream(file,FileMode.Append, FileAccess.Write)) {
                        using (StreamWriter sw = new StreamWriter(fs)) {
                            sw.WriteLine($"{ticketID},{summary},{status},{priority},{submitter},{assigned},{watching}");
                            sw.Close();
                        }
                        fs.Close();
                    }
                    nextTicketID += 1;
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
