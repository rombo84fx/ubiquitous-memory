using System;
using System.Diagnostics;
using System.Text;
using System.IO;

namespace ImplementDiagnosticsInAnApplication
{
    class Program
    {
        #region Example 3-45 Using the Debug class

        //static void Main(string[] args)
        //{
        //    Debug.WriteLine("Starting application");
        //    Debug.Indent();
        //    int i = 1 + 2;
        //    Debug.Assert(i == 3);
        //    Debug.WriteLineIf(i > 0, "i is greater than 0");
        //}

        #endregion Example 3-45 Using the Debug class

        #region Example 3-46 Using the TraceSource class

        //static void Main(string[] args)
        //{
        //    TraceSource traceSource = new TraceSource("myTraceSource",
        //        SourceLevels.All);

        //    traceSource.TraceInformation("Tracing application...");
        //    traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");
        //    traceSource.TraceData(TraceEventType.Information, 1,
        //        new object[] { "a", "b", "c" });

        //    traceSource.Flush();
        //    traceSource.Close();
        //}

        #endregion Example 3-46 Using the TraceSource class

        #region Example 3-47 Configuring TraceListener

        //static void Main(string[] args)
        //{
        //    Stream outputFile = File.Create("tracefile.txt");
        //    TextWriterTraceListener textListener =
        //        new TextWriterTraceListener(outputFile);

        //    TraceSource traceSource = new TraceSource("myTraceSource",
        //        SourceLevels.All);

        //    traceSource.Listeners.Clear();
        //    traceSource.Listeners.Add(textListener);

        //    traceSource.TraceInformation("Trace output");

        //    traceSource.Flush();
        //    traceSource.Close();
        //}

        #endregion Example 3-47 Configuring TraceListener

        #region Example 3-49 Writing data to the event log

        //static void Main(string[] args)
        //{
        //    if (!EventLog.SourceExists("MySource"))
        //    {
        //        EventLog.CreateEventSource("MySource", "MyNewLog");
        //        Console.WriteLine("CreatedEventSource");
        //        Console.WriteLine("Please restart application");
        //        Console.ReadKey();
        //        return;
        //    }

        //    EventLog myLog = new EventLog();
        //    myLog.Source = "MySource";
        //    myLog.WriteEntry("Log event!");

        //} 

        #endregion Example 3-49 Writing data to the event log

        #region Example 3-50 Reading data from the event log

        //static void Main(string[] args)
        //{

        //    EventLog log = new EventLog("MyNewLog");

        //    EventLogEntry last = log.Entries[log.Entries.Count - 1];
        //    Console.WriteLine($"Index: {last.Index}");
        //    Console.WriteLine($"Source: {last.Source}");
        //    Console.WriteLine($"Type: {last.EntryType}");
        //    Console.WriteLine($"Time: {last.TimeWritten}");
        //    Console.WriteLine($"Message: {last.Message}");
        //}

        #endregion

        #region Example 3-51 Subscribing data to event log

        //static void Main(string[] args)
        //{

        //    EventLog applicationLog = new EventLog("Application", ".", "testEventLogEvent");
        //    applicationLog.EntryWritten += (sender, e) =>
        //    {
        //        Console.WriteLine(e.Entry.Message);
        //    };
        //    applicationLog.EnableRaisingEvents = true;
        //    applicationLog.WriteEntry("Test message", EventLogEntryType.Information);
        //    Console.ReadKey();
        //}

        #endregion

        #region Example 3-52 Using the StopWatch class

        //const int numberOfIterations = 100000;

        //static void Main(string[] args)
        //{
        //    Stopwatch sw = new Stopwatch();
        //    sw.Start();
        //    Algorithm1();
        //    sw.Stop();

        //    Console.WriteLine(sw.Elapsed);

        //    sw.Reset();
        //    sw.Start();
        //    Algorithm2();
        //    sw.Stop();

        //    Console.WriteLine(sw.Elapsed);
        //    Console.WriteLine("Ready...");
        //    Console.ReadLine();
        //}

        //private static void Algorithm2()
        //{
        //    string result = "";

        //    for (int x = 0; x < numberOfIterations; x++)
        //    {
        //        result += 'a';
        //    }
        //}

        //private static void Algorithm1()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    for (int x = 0; x < numberOfIterations; x++)
        //    {
        //        sb.Append('a');
        //    }

        //    string result = sb.ToString();
        //}

        #endregion Example 3-52 Using the StopWatch class

        #region Example 3-53 Reading data from a performance counter

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Press escape key to stop");
        //    using (PerformanceCounter pc = new PerformanceCounter("Memory", "Available Bytes"))
        //    {
        //        string text = "Available memory: ";
        //        Console.WriteLine(text);
        //        do
        //        {
        //            while (!Console.KeyAvailable)
        //            {
        //                Console.WriteLine(pc.RawValue);
        //                Console.SetCursorPosition(text.Length, Console.CursorTop);
        //            }
        //        } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        //    }
        //}

        #endregion Example 3-53 Reading data from a performance counter

        #region Example 3-54 Creating and using performance counters

        //static void Main(string[] args)
        //{
        //    if (CreatePerformanceCounters())
        //    {
        //        Console.WriteLine("Created performance counters");
        //        Console.WriteLine("Please restart application");
        //        Console.ReadKey();
        //        return;
        //    }

        //    var totalOperationsCounter = new PerformanceCounter(
        //        "MyCategory",
        //        "# operations executed",
        //        "",
        //        false);

        //    var operationsPerSecondCounter = new PerformanceCounter(
        //        "MyCategory",
        //        "# operations / sec",
        //        "",
        //        false);

        //    totalOperationsCounter.Increment();
        //    operationsPerSecondCounter.Increment();
        //}

        //private static bool CreatePerformanceCounters()
        //{
        //    if (!PerformanceCounterCategory.Exists("MyCategory"))
        //    {
        //        CounterCreationDataCollection counters =
        //            new CounterCreationDataCollection
        //            {
        //                new CounterCreationData(
        //                    "# operations executed",
        //                    "Total number of operations executed",
        //                    PerformanceCounterType.NumberOfItems32),
        //                new CounterCreationData(
        //                    "# operations / sec",
        //                    "Number of operations executed per second",
        //                    PerformanceCounterType.RateOfCountsPerSecond32)
        //            };

        //        PerformanceCounterCategory.Create("MyCategory",
        //            "Sample category for Code project", PerformanceCounterCategoryType.Unknown, counters);

        //        return true;
        //    }

        //    return false;
        //}

        #endregion Example 3-54 Creating and using performance counters
    }
}