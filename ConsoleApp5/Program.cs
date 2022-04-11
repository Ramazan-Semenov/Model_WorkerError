using System;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {


            //    if (!EventLog.Exists("Application", "LAPTOP-86BFKAJP"))
            //    {
            //        Console.WriteLine("The log does not exist!");
            //        return;
            //    }

            //    EventLog myLog = new EventLog();
            //    myLog.Log = "Application";
            //    myLog.MachineName = "LAPTOP-86BFKAJP";
            //    Console.WriteLine("There are " + myLog.Entries.Count + " entr[y|ies] in the Application log:");

            //foreach (EventLogEntry entry in myLog.Entries)
            //{
            //    Console.WriteLine("\tEntry: " + entry.Message);
            //}

            //// check for Demo event log source existence
            //// create it if it not exist

            //if (!EventLog.SourceExists("Demo"))
            //{
            //    EventLog.CreateEventSource("Demo", "Demo");
            //}
            //   Console.WriteLine(  EventLog.LogNameFromSourceName("ConsoleApp5", "LAPTOP-86BFKAJP"));
            //EventLog.WriteEntry("AnySource", "writing error to demo log.", EventLogEntryType.Error);
            //Console.WriteLine("Monitoring of Application event log began...");
            //Console.WriteLine(@"Press 'q' and 'Enter' to quit");

            //while (Console.Read() != 'q')
            //{
            //    // Now we will monitor the new entries that will be written.
            //    // When you create an EntryWrittenEventHandler delegate
            //    // you identify the method that will handle the event.
            //    myLog.EntryWritten += new EntryWrittenEventHandler(OnEntryWritten);

            //    // EnableRaisingEvents gets or sets a value indicating whether the
            //    // EventLog instance receives EntryWritten event notifications.
            //    myLog.EnableRaisingEvents = true;Application Error
            //}



            EventLog log = new EventLog("Application");
            var entries = log.Entries.Cast<EventLogEntry>()
                                     .Where(x => x.Source == "Application Error" && x.Message.Contains("ConsoleApp5.exe"))
                                     .Select(x => new
                                     {
                                         x.MachineName,
                                         x.Site,
                                         x.Source,
                                         x.Message
                                     }).ToList();

            foreach (var item in entries)
            {
                Console.WriteLine(item);
            }
            Console.Read();



        }
        public static void OnEntryWritten(Object source, EntryWrittenEventArgs e)
        {
            Console.WriteLine("written entry: " + e.Entry.Message);
        }
    }

    class dfg
    {
        public string df { get; set; }
    }

}
