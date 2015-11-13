using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Example.XmlOperator;
using Example.ThreadPoolTest;
using Example.SystemThreadingTimer;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Data;
using System.Security.Cryptography;
using Example.ZipHelper;
using System.IO.Compression;
using System.Collections;
using Example.ThreadShare;
using Example.MessageQueueTest;
using Example.FileOperator;
using Example.MethodInfoTest;
using Example.StringTest;
using Example.AlgorithmTest;


namespace Example
{
    class Program
    {                
        static void Main(string[] args)
        {
            //操作xml文件
            //XmlOperatorProgram xmlOperator = new XmlOperatorProgram();

            //ThreadPoolTT threadPoolTest = new ThreadPoolTT();
            //threadPoolTest.Test();

            //Threading.Timer测试
            //ThreadingTimerProgram.Test();

            ////转换
            //int intNum =10111;
            //Console.WriteLine(intNum.ToString("D5"));
            //Console.WriteLine(intNum.ToString().PadLeft(5, '0'));//推荐

			//LogHelper.Instance.WriteLog("2222222222");
			//SysLog.Instance.WriteLog("1111");

	
			////MethodInfoTest
			//string scriptFile = @"Config\ScriptTT.cs";

			//ScriptCall sc = new ScriptCall(scriptFile);
			//sc.createCompiler();
			//if (!sc.Compile())
			//{
			//	Console.WriteLine(sc.compileErrInfo);
			//}
			//else
			//{
			//	Console.WriteLine("编译成功!");
			//	sc.Invoke();
			//}


			//StringTT strTT = new StringTT();
			//strTT.StrTest();

            //AlgorithmTT alg = new AlgorithmTT();
            //alg.algroTest();
			

            //int[] a = new int[]{0,2,4,6,8};
            //Test(a);

            //foreach (int b in a)
            //{
            //    Console.Write("{0},", b);
            //}

            string str = "8613526415213";
            string rr = "";
            char[] arr = str.ToCharArray();
            foreach (char cc in arr)
            {
                rr += string.Format(@"{0}.", cc.ToString());
            }
            rr = rr.TrimEnd('.');

            str = ReverseStr(rr);
            
            Console.ReadKey();
        }

        private static string ReverseStr(string str)
        {
            char[] arr = str.ToCharArray();           
            Array.Reverse(arr);
            return new string(arr);
        }


		private static void Test(int[] a)
		{
			a[0] = 1;
			a[1] = 3;
			a[2] = 5;
			a[3] = 7;
			a[4] = 9;
		}
		
    }

    
}
