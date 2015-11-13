/***********************************************************************
 * name: 线程池测试
 * description：验证线程池的最大工作线程数和最小空闲线程数。
 * 这个例子让线程池申请800个线程，其中设置最大工作线程数为500，
 * 800个线程任务每个都要执行100000000毫秒目的是让线程不会释放，
 * 并且让用户选择，是否预先申请500个空闲线程免受那半秒钟的延迟时间，
 * 其结果可想而知当线程申请到500的时候，线程池达到了最大工作线程数，
 * 剩余的300个申请进入漫长的等待时间。
 * date: 2015-06-25
************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Example.ThreadPoolTest
{
    public class ThreadPoolTT
    {
        private static int workThread = 1; //工作线程数
        private static int MaxThreadCount = 800; //最大线程数

        public ThreadPoolTT()
        {

        }

        private static void OutPut(object obj)
        {
            Console.WriteLine("申请了: {0}个工作线程", workThread);
            workThread++;
            Thread.Sleep(100000000); //设置一个很大的等待时间，让每个申请的线程都一直执行
        }

        public void Test()
        {            
            Console.Write("是否先申请500个空闲线程以保证前500个线程在线程池中开始就有线程用(Y/N)?");
            //如果这里选择N，那么前两个任务是用的线程池默认空闲线程（可以用ThreadPool.GetMinThreads得到系统默认最小空闲线程数为2）申请立即得到满足，然而由于每个线程等待时间非常大都不会释放当前自己持有的线程，因此线程池中已无空闲线程所用，后面的任务需要在线程池中申请新的线程，那么新申请的每个线程在线程池中都要隔半秒左右的时间才能得到申请（原因请见下面的注释）

            string key = Console.ReadLine();
            if (key.ToLower() == "y")
            {
                ThreadPool.SetMinThreads(500, 10);
                //设置最大空闲线程为500，就好像我告诉系统给我预先准备500个线程我来了就直接用，因为这样就不用现去申请了，在线程池中每申请一个新的线程.NET Framework 会安排一个间隔时间，目前是半秒，以后的版本MS有可能会改

                int a, b;
                ThreadPool.GetMaxThreads(out a, out b);
                Console.WriteLine("线程池默认最大工作线程数：" + a.ToString() + "    默认最大异步 I/O 线程数：" + b.ToString());
                Console.WriteLine("需要向系统申请" + MaxThreadCount.ToString() + "个工作线程");

                //由于ThreadPool.GetMaxThreads返回的默认最大工作线程数为500（这个值要根据你计算机的配置来决定），那么向线程池申请大于500个线程的时候，500之后的线程会进入线程池的等待队列，等待前面500个线程某个线程执行完后来唤醒等待队列的某个线程 
                for (int j = 0; j <= MaxThreadCount - 1; j++)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(OutPut));
                    Thread.Sleep(10);
                }

                Console.ReadLine();
            }
        }
    }
}
