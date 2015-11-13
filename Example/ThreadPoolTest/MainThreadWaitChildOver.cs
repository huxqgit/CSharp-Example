using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Example.ThreadPoolTest
{
    class MainThreadWaitChildOver
    {
        List<ManualResetEvent> manualEvents = new List<ManualResetEvent>();

        public void Test()
        {
            Console.WriteLine("#########################");
            for (int i = 0; i < 10; i++)
            {
                ManualResetEvent mre = new ManualResetEvent(false);
                manualEvents.Add(mre);

                Param pra = new Param();
                pra.mrEvent = mre;
                pra.praData = i;

                ThreadPool.QueueUserWorkItem(ThreadMethod, pra);
            }

            WaitHandle.WaitAll(manualEvents.ToArray());
            Console.WriteLine("#########################");
            Console.ReadKey();
        }

        static void ThreadMethod(object obj)
        {
            Thread.Sleep(10000);
            Param pra = (Param)obj;
            pra.mrEvent.Set();
            Console.WriteLine("Thread execute at {0}", pra.praData);
        }
    }

    public class Param
    {
        public ManualResetEvent mrEvent;
        public int praData;
    }
}
