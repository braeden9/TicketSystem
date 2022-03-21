using System;
using System.Collections.Generic;
using System.IO;

namespace TicketSysClasses
{
    class TicketFile
    {
        public string filePath { get; set; }
        public Int64 NextTicketID { get; set; } 
        public List<Bug> Bugs { get; set; }
        public List<Enchancement> Enchancements { get; set; }
        public List<Task> Tasks { get; set; }

        public TicketFile(string ticketFilePath) {
            filePath = ticketFilePath;
            Bugs = new List<Bug>();
            Enchancements = new List<Enchancement>();
            Tasks = new List<Task>();
            
            try {
                StreamReader sr = new StreamReader(filePath + "\\bugs.csv");
                NextTicketID = 0;
                while (!sr.EndOfStream)
                {
                    Bug ticket = new Bug();
                    string[] segments = sr.ReadLine().Split(",");
                    ticket.ticketID = Int64.Parse(segments[0]);
                     if (NextTicketID <= ticket.ticketID) { NextTicketID = ticket.ticketID + 1; }
                    ticket.submitter = segments[1];
                    ticket.summary = segments[2];
                    ticket.status = segments[3];
                    ticket.priority = Int16.Parse(segments[4]);
                    ticket.assigned = segments[5];
                    foreach (string person in segments[6].Split("|")){
                        ticket.watching.Add(person);
                    }
                    ticket.severity = Int16.Parse(segments[7]);
                    Bugs.Add(ticket);
                } 
                sr.Close();
                StreamReader sr2 = new StreamReader(filePath + "\\enchancements.csv");
                while (!sr2.EndOfStream)
                {
                    Enchancement ticket = new Enchancement();
                    string[] segments = sr2.ReadLine().Split(",");
                    ticket.ticketID = Int64.Parse(segments[0]);
                     if (NextTicketID <= ticket.ticketID) { NextTicketID = ticket.ticketID + 1; }
                    ticket.submitter = segments[1];
                    ticket.summary = segments[2];
                    ticket.status = segments[3];
                    ticket.priority = Int16.Parse(segments[4]);
                    ticket.assigned = segments[5];
                    foreach (string person in segments[6].Split("|")){
                        ticket.watching.Add(person);
                    }
                    ticket.software = segments[7];
                    ticket.cost = Int16.Parse(segments[8]);
                    ticket.reason = segments[9];
                    ticket.estimate = Int16.Parse(segments[10]);
                    Enchancements.Add(ticket);
                } 
                sr2.Close();
                StreamReader sr3 = new StreamReader(filePath + "\\tasks.csv");
                while (!sr3.EndOfStream)
                {
                    Task ticket = new Task();
                    string[] segments = sr3.ReadLine().Split(",");
                    ticket.ticketID = Int64.Parse(segments[0]);
                     if (NextTicketID <= ticket.ticketID) { NextTicketID = ticket.ticketID + 1; }
                    ticket.submitter = segments[1];
                    ticket.summary = segments[2];
                    ticket.status = segments[3];
                    ticket.priority = Int16.Parse(segments[4]);
                    ticket.assigned = segments[5];
                    foreach (string person in segments[6].Split("|")){
                        ticket.watching.Add(person);
                    }
                    ticket.projectName = segments[7];
                    ticket.dueDate = DateTime.Parse(segments[8]);
                    Tasks.Add(ticket);
                } 
                sr3.Close();
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public void AddBug(Bug b) {
            try { 
                StreamWriter sw = new StreamWriter(filePath + "\\bugs.csv", true);
                sw.WriteLine($"{b.ticketID},{b.submitter},{b.summary},{b.status},{b.priority},{b.assigned},{string.Join("|",b.watching)},{b.severity}");
                sw.Close();
                Bugs.Add(b);
                NextTicketID = NextTicketID + 1;
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }
        public void AddEnchancement(Enchancement e) {
            try { 
                StreamWriter sw = new StreamWriter(filePath + "\\enchancements.csv", true);
                sw.WriteLine($"{e.ticketID},{e.submitter},{e.summary},{e.status},{e.priority},{e.assigned},{string.Join("|",e.watching)},{e.software},{e.cost},{e.reason},"
                    + $"{e.estimate}");
                sw.Close();
                Enchancements.Add(e);
                NextTicketID = NextTicketID + 1;
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }
        public void AddTask(Task t) {
            try { 
                StreamWriter sw = new StreamWriter(filePath + "\\tasks.csv", true);
                sw.WriteLine($"{t.ticketID},{t.submitter},{t.summary},{t.status},{t.priority},{t.assigned},{string.Join("|",t.watching)},{t.projectName},{t.dueDate}");
                sw.Close();
                Tasks.Add(t);
                NextTicketID = NextTicketID + 1;
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }
    }
}