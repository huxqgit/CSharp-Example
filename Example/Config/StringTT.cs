using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.StringTest
{
	public class StringTT
	{
		public void StrTest()
		{
			string str = string.Format("${0}.{1, 3:00}", 1, 5); //$1. 05
			Console.WriteLine(str);
		}
	}
}
