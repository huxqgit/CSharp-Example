using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Example.SystemThreadingTimer
{
    public class UnSafeThreadingTimer
    {
        private static int i = 0;
        private static System.Threading.Timer timer;
        private static object myLock = new object();
        private static int sleep;
        private static bool flag;
        public  static Stopwatch sw = new Stopwatch();

        static void Excute(object obj)
        {
            Thread.CurrentThread.IsBackground = false;
            int c;

            lock (myLock)
            {
                i++;
                c = i;
            }

            if (c == 80)
            {
                timer.Dispose();//执行Dispose后Timer就不会再申请新的线程了,但是还是会给Timmer已经激发的事件申请线程
                sw.Stop();
            }

            if (c < 80)
            {
                Console.WriteLine("Now:" + c.ToString());
            }
            else
            {
                Console.WriteLine("Now:" + c.ToString() + "-----------Timer已经Dispose耗时:" + sw.ElapsedMilliseconds.ToString() + "毫秒");
            }

            if (flag)
            {
                Thread.Sleep(sleep);//模拟花时间的代码
            }
            else
            {
                if (i <= 80)
                {
                    Thread.Sleep(sleep);//前80次模拟花时间的代码
                }
            }
        }

        public static void Init(int p_sleep, bool p_flag)
        {
            sleep = p_sleep;
            flag = p_flag;
            timer = new System.Threading.Timer(Excute, null, 0, 10);
        }
    }
}
