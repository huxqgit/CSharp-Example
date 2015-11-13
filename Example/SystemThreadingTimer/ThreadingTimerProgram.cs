using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.SystemThreadingTimer
{
    public class ThreadingTimerProgram
    {
        public static void Test()
        {
            Console.Write("是否使用安全方法(Y/N)?");
            string key = Console.ReadLine();
            if (key.ToLower() == "y")
            {
                SafeThreadingTimer.Init();
            }
            else
            {
                Console.Write("请输入Timmer响应事件的等待时间(毫秒):");//这个时间直接决定了前80个任务的执行时间，因为等待时间越短，每个任务就可以越快执行完，那么80个任务中就有越多的任务可以用到前面任务执行完后释放掉的线程，也就有越多的任务不必去线程池申请新的线程避免多等待半秒钟的申请时间
                string sleep = Console.ReadLine();
                Console.Write("申请了80个线程后Timer剩余激发的线程请求是否需要等待时间(Y/N)?");//这里可以发现选Y或者N只要等待时间不变，最终Timer激发线程的次数都相近，说明Timer的确在执行80次的Dispose后就不再激发新的线程了
                key = Console.ReadLine();
                bool flag = false;
                if (key.ToLower() == "y")
                {
                    flag = true;
                }

                UnSafeThreadingTimer.sw.Start();
                UnSafeThreadingTimer.Init(Convert.ToInt32(sleep), flag);
            }

            Console.ReadLine();
        }
    }
}
