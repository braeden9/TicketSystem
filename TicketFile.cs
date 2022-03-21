using System;
using System.Collections.Generic;
using System.IO;

namespace TicketSysClasses
{
    class TicketFile
    {
        public string filePath { get; set; }
        public Int64 NextTicketID { get; set; } 
        public List<Ticket> Tickets { get; set; }

        public TicketFile(string ticketFilePath) {
            filePath = ticketFilePath;
            Tickets = new List<Ticket>();

            try {
                StreamReader sr = new StreamReader(filePath);
                NextTicketID = 0;
                while (!sr.EndOfStream)
                {
                    Ticket ticket = new Ticket();
                    string[] segments = sr.ReadLine().Split(",");
                    ticket.ticketID = Int64.Parse(segments[0]);
                    ticket.submitter = segments[1];
                    ticket.summary = segments[2];
                    ticket.status = segments[3];
                    ticket.priority = Int16.Parse(segments[4]);
                    ticket.assigned = segments[5];
                    foreach (string person in segments[6].Split("|")){
                        ticket.watching.Add(person);
                    }
                    Tickets.Add(ticket);
                    if (NextTicketID <= ticket.ticketID) {
                        NextTicketID = ticket.ticketID + 1;
                    }
                } 
                sr.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public void AddTicket(Ticket ticket) {
            try { 
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{ticket.ticketID},{ticket.submitter},{ticket.summary},{ticket.status},{ticket.priority},{ticket.assigned},{string.Join("|",ticket.watching)}");
                sw.Close();
                Tickets.Add(ticket);
                NextTicketID = NextTicketID + 1;
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }
    }
}