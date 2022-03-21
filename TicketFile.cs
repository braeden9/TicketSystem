using System;
using System.Collections.Generic;
using System.IO;

namespace TicketSysClasses
{
    class TicketFile
    {
        public string filePath { get; set; }
        public List<Ticket> Tickets { get; set; }

        public TicketFile(string ticketFilePath) {
            filePath = ticketFilePath;
            Tickets = new List<Ticket>();

            try {
                StreamReader sr = new StreamReader(filePath);
                while (!sr.EndOfStream)
                {
                    Ticket ticket = new Ticket();
                    string[] segments = sr.ReadLine().Split(",");
                    ticket.ticketID = Convert.ToInt64(segments[0]);
                    ticket.submitter = segments[1];
                    ticket.summary = segments[2];
                    ticket.priority = Convert.ToInt16(segments[3]);
                    ticket.assigned = segments[4];
                    foreach (string person in segments[5].Split("|")){
                        ticket.watching.Add(person);
                    }
                    Tickets.Add(ticket);
                } 
                sr.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public void AddTicket(Ticket ticket) {
            try { 
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{ticket.ticketID},{ticket.submitter},{ticket.summary},{ticket.priority},{ticket.assigned},{string.Join("|",ticket.watching)}");
                sw.Close();
                Tickets.Add(ticket);
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }
    }
}