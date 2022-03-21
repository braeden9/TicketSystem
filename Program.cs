using System;
using System.IO;

namespace TicketSysClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            string ticketFilePath = Directory.GetCurrentDirectory();
            TicketFile ticketFile = new TicketFile(ticketFilePath);

            string resp = "";
            
            do {
                Console.WriteLine("1. Create ticket");
                Console.WriteLine("2. Display tickets");
                Console.WriteLine("Anything else to quit");
                resp = Console.ReadLine();
                
                Console.Clear();

                if (resp == "1") {
                    Console.WriteLine("What type would you like to make? (1-Bug/Defect 2-Enchancement 3-Task)");
                    resp = Console.ReadLine();
                    switch (resp)
                    {
                        case "1": 
                            Bug bug = new Bug();

                            bug.ticketID = ticketFile.NextTicketID;
                            Console.WriteLine("Who are you?");
                            bug.submitter = Console.ReadLine();

                            Console.WriteLine("Please explain your issue.");
                            bug.summary = Console.ReadLine();

                            bug.status = "Open";

                            Console.WriteLine("What is the priority? (1-Low, 2-Med, 3-High)");
                            bug.priority = Int16.Parse(Console.ReadLine());
                            
                            Console.WriteLine("Who is assigned to this?");
                            bug.assigned = Console.ReadLine();

                            string watchInput;
                            do {
                                Console.WriteLine("Who is watching this? (Enter when done)");
                                watchInput = Console.ReadLine();
                                if (watchInput != "") {                        
                                    bug.watching.Add(watchInput);
                                }                    
                            } while (watchInput != "");

                            if (bug.watching.Count == 0) {
                                bug.watching.Add("none");
                            }

                            Console.WriteLine("What is the severity? (1-Low, 2-Med, 3-High)");
                            bug.severity = Int16.Parse(Console.ReadLine());

                            ticketFile.AddBug(bug);
                            break;
                        case "2":
                            Enchancement enchancement = new Enchancement();

                            enchancement.ticketID = ticketFile.NextTicketID;
                            Console.WriteLine("Who are you?");
                            enchancement.submitter = Console.ReadLine();

                            Console.WriteLine("Please explain your issue.");
                            enchancement.summary = Console.ReadLine();

                            enchancement.status = "Open";

                            Console.WriteLine("What is the priority? (1-Low, 2-Med, 3-High)");
                            enchancement.priority = Int16.Parse(Console.ReadLine());
                            
                            Console.WriteLine("Who is assigned to this?");
                            enchancement.assigned = Console.ReadLine();

                            do {
                                Console.WriteLine("Who is watching this? (Enter when done)");
                                watchInput = Console.ReadLine();
                                if (watchInput != "") {                        
                                    enchancement.watching.Add(watchInput);
                                }                    
                            } while (watchInput != "");

                            if (enchancement.watching.Count == 0) {
                                enchancement.watching.Add("none");
                            }

                            Console.WriteLine("What is the software?");
                            enchancement.software = Console.ReadLine();
                            
                            Console.WriteLine("What is the cost?");
                            enchancement.cost = Int16.Parse(Console.ReadLine());

                            Console.WriteLine("What is the reason to this?");
                            enchancement.reason = Console.ReadLine();

                            Console.WriteLine("What is the estimate?");
                            enchancement.estimate = Int16.Parse(Console.ReadLine());

                            ticketFile.AddEnchancement(enchancement);
                            break;
                        case "3":
                            Task task = new Task();

                            task.ticketID = ticketFile.NextTicketID;
                            Console.WriteLine("Who are you?");
                            task.submitter = Console.ReadLine();

                            Console.WriteLine("Please explain your issue.");
                            task.summary = Console.ReadLine();

                            task.status = "Open";

                            Console.WriteLine("What is the priority? (1-Low, 2-Med, 3-High)");
                            task.priority = Int16.Parse(Console.ReadLine());
                            
                            Console.WriteLine("Who is assigned to this?");
                            task.assigned = Console.ReadLine();

                            do {
                                Console.WriteLine("Who is watching this? (Enter when done)");
                                watchInput = Console.ReadLine();
                                if (watchInput != "") {                        
                                    task.watching.Add(watchInput);
                                }                    
                            } while (watchInput != "");

                            if (task.watching.Count == 0) {
                                task.watching.Add("none");
                            }

                            Console.WriteLine("What is the name/title");
                            task.projectName = Console.ReadLine();

                            Console.WriteLine("What is the due date? (MM/DD/YYYY HH:MM AM/PM)");
                            task.dueDate = DateTime.Parse(Console.ReadLine());

                            ticketFile.AddTask(task);
                            resp = "1";
                            break;
                        default:
                            Console.WriteLine("That type does not exists. Please try again.");
                            resp = "1";
                            break;
                    }
                } else if (resp == "2") {
                    Console.Clear();
                    foreach(Bug b in ticketFile.Bugs) {
                        Console.WriteLine(b.Display());
                    }
                    foreach(Enchancement e in ticketFile.Enchancements) {
                        Console.WriteLine(e.Display());
                    }
                    foreach(Task t in ticketFile.Tasks) {
                        Console.WriteLine(t.Display());
                    }
                }

            } while (resp == "1" || resp == "2");
        }
    }
}
