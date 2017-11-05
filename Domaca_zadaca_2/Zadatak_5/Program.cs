using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_5
{
    class Program
    {
        static void Main(string[] args)
        {
            /** Stopwatch stopwatch = new Stopwatch();
             stopwatch.Start();
             LongOperation("A");
             LongOperation("B");
             LongOperation("C");
             LongOperation("D");
             LongOperation("E");
             stopwatch.Stop();
             Console.WriteLine(" Synchronous long operation calls finished {0} sec.",
                 stopwatch.Elapsed.TotalSeconds);

             Stopwatch stopwatch1 = new Stopwatch();
             stopwatch1.Start();
             Parallel.Invoke(() => LongOperation("A"),
             () => LongOperation("B"),
             () => LongOperation("C"),
             () => LongOperation("D"),
             () => LongOperation("E"));
             stopwatch1.Stop();
             Console.WriteLine(" Parallel long operation calls finished {0} sec.",
                 stopwatch1.Elapsed.TotalSeconds);

             int counter = 0;
             Parallel.For(0, 100000, (i) =>
             {
                 Thread.Sleep(1);
                 counter += 1;
             }) ;
             Console.WriteLine(" Counter should be 100000. Counter is {0}", counter);


             int counter1 = 0;
             object objectUsedForLock = new object();
             Parallel.For(0, 100000, (i)=>
             {
                 Thread.Sleep(1);
                 lock (objectUsedForLock)
                 {
                     counter1 += 1;
                 }
             }) ;

            
             Console.WriteLine(" Counter should be 100000. Counter is {0}", counter1); 

             List<int> results = new List<int>();
             Parallel.For(0, 100000, (i) =>
             {
                 Thread.Sleep(1);
                 results.Add(i * i);
             }) ;
             Console.WriteLine("Bag length should be 100000. Length is {0}",
                 results.Count); */

            ConcurrentBag<int> iterations = new ConcurrentBag<int>();
            Parallel.For(0, 100000, (i) =>
            {
                Thread.Sleep(1);
                iterations.Add(i);
            }) ;
            Console.WriteLine("Bag length should be 100000. Length is {0}",
                iterations.Count);



        }

        public static void LongOperation(string taskName)
        {
            Thread.Sleep(1000);
            Console.WriteLine("{0} Finished . Executing Thread : {1}", taskName,
            Thread.CurrentThread.ManagedThreadId);
        }
    }
}
