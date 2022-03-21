using System;
using System.Collections.Generic;

namespace TicketSysClasses
{
    public class Ticket
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
        public string Display() {
            return $"Id: {ticketID}\nSubmitter: {submitter}\nSummary: {summary}\nStatus: {status}\nPrioity: {priority}\nAssigned: {assigned}\nWatching: {string.Join(", ", watching)}\n";
        }
    }
}