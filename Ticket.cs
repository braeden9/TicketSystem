using System;
using System.Collections.Generic;

namespace TicketSysClasses
{
    public abstract class Ticket
    {
        public Int64 ticketID { get; set; }
        public string submitter { get; set; }
        public string summary { get; set; }
        public string status { get; set; }
        public int priority { get; set; }
        public string assigned { get; set; }
        public List<string> watching { get; set; }
        public Ticket() {
            watching = new List<string>();
        }
        public virtual string Display() {
            return $"Id: {ticketID}\nSubmitter: {submitter}\nSummary: {summary}\nStatus: {status}\nPrioity: {priority}\nAssigned: {assigned}\n"
                + $"Watching: {string.Join(", ", watching)}\n";
        }
    }

    public class Bug : Ticket
    {
        public int severity { get; set; }
        public override string Display() {
            return $"Id: {ticketID}\nSubmitter: {submitter}\nSummary: {summary}\nStatus: {status}\n"
                + $"Prioity: {priority}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\nSeverity: {severity}";
        }
    } 

    public class Enchancement : Ticket
    {
        public string software { get; set; }
        public Int16 cost { get; set; }
        public string reason { get; set; }
        public Int16 estimate { get; set; }
        public override string Display() {
            return $"Id: {ticketID}\nSubmitter: {submitter}\nSummary: {summary}\nStatus: {status}\nPrioity: {priority}\nAssigned: {assigned}\n"
            + $"Watching: {string.Join(", ", watching)}\nSoftware: {software}\nCost: {cost}\nReason: {reason}\nEstimate: {estimate}";
        }
    }

    public class Task : Ticket
    {
        public string projectName { get; set; }
        public DateTime dueDate { get; set; }
        public override string Display() {
            return $"Id: {ticketID}\nSubmitter: {submitter}\nSummary: {summary}\nStatus: {status}\nPrioity: {priority}\nAssigned: {assigned}\n"
            + $"Watching: {string.Join(", ", watching)}\n";
        }
    }
}