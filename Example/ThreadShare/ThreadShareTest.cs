using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Example.ThreadShare
{
    public class ThreadShareTest
    {
        public void Test()
        {
            for (int i = 0; i < 5; i++ )
            {
                Thread th1 = new Thread(new ParameterizedThreadStart(Test1));
                th1.Start(i);
            }
            

            //Thread th2 = new Thread(new ThreadStart(Test2));
            //th2.Start();

            Console.ReadLine();
            
        }

        private void Test1(object obj)
        {
            lock (this)
            {     
            for (int i = 0; i < 5; i++ )
            {
                
                    int num = (int)obj;
                    Console.WriteLine("线程" + num.ToString() + " 改写前 ************" + ShareClass.shareCount);
                    Thread.Sleep(2000);
                    ShareClass.shareCount++;
                    ShareClass.shareArryList.Add(new byte[] { byte.Parse(i.ToString()) });
                    Console.WriteLine("线程" + num.ToString() + " 改写后 ============" + ShareClass.shareCount);    
                
            }
            }
        }

        private void Test2()
        {
            for (int i = 0; i < 5; i++ )
            {
                lock (this)
                {
                    ShareClass.shareCount++;
                    ShareClass.shareArryList.Add(new byte[] { byte.Parse(i.ToString()) });                
                }
                

                Console.WriteLine("线程2 ============" + ShareClass.shareCount);
            }  
        }
    }
}
