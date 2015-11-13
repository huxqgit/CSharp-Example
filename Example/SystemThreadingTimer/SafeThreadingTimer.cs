using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Example.SystemThreadingTimer
{
    public class SafeThreadingTimer
    {
        static int i = 0;
        static System.Threading.Timer timer;

        static bool flag = true;
        static object myLock = new object();

        static void Excute(object obj)
        {
            Thread.CurrentThread.IsBackground = false;

            lock (myLock)
            {
                if (!flag)
                {
                    return;
                }

                i++;

                if (i == 80)
                {
                    timer.Dispose();
                    flag = false;
                }
                Console.WriteLine("Now:" + i.ToString());
            }

            Thread.Sleep(1000);//模拟花时间的代码
        }

        public static void Init()
        {
            timer = new System.Threading.Timer(Excute, null, 0, 10);
        }
    }
}
