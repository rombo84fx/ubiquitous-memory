using System;
using System.Diagnostics;

namespace ImplementDiagnosticsInAnApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Writing data to the event log

            if (!EventLog.SourceExists("MySource"))
            {
                EventLog.CreateEventSource("MySource", "MyNewLog");
                Console.WriteLine("CreatedEventSource");
                Console.WriteLine("Please restart application");
                Console.ReadKey();
                return;
            }

            EventLog myLog = new EventLog();
            myLog.Source = "MySource";
            myLog.WriteEntry("Log event!");

            #endregion
        }
    }
}
