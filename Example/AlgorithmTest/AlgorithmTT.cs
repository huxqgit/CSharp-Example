using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.AlgorithmTest
{
	/// <summary>
	/// 各种算法代码
	/// </summary>
	public class AlgorithmTT
	{
		/// <summary>
		/// 冒泡升序排序，适合一小组数字
		/// </summary>
		/// <param name="intArr">元素较少的整型数组</param>
		/// <returns>升序排列的整型数组</returns>
		public void BubbleSortIntArray(int[] intArr)
		{
			int[] sortArry = intArr;
			bool swapped = true;

			do 
			{
				swapped = false;
				for (int i = 0; i < sortArry.Length - 1; i++)
				{
					if (sortArry[i] > sortArry[i + 1])
					{
						int temp = sortArry[i];
						sortArry[i] = sortArry[i + 1];
						sortArry[i + 1] = temp;
						swapped = true;
					}
				}
			} while (swapped);

			//return sortArry;
		}

		/// <summary>
		/// 冒泡排序的泛型版本，适合任何对象，在调用时，为了匹配Func委托签名，必须实现委托的方法
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		/// <param name="sortArray">要排序的列表</param>
		/// <param name="comparison">必须引用一个方法，该方法有2个参数，如果第一个参数小于第二个参数，返回true</param>
		public static void BubbleSortGeneric<T>(IList<T> sortArray, Func<T, T, bool> comparison)
		{
			bool swapped = true;
			do
			{
				swapped = false;
				for (int i = 0; i < sortArray.Count - 1; i++)
				{
					if (comparison(sortArray[i + 1], sortArray[i]))
					{
						T temp = sortArray[i];
						sortArray[i] = sortArray[i + 1];
						sortArray[i + 1] = temp;
						swapped = true;
					}
				}
			} while (swapped);
		}

		public void algroTest()
		{
			//算法			
			int[] array = new int[] { 0, 5, 6, 2, 1, 4, 7, 10, 12 };
			BubbleSortIntArray(array); //普通调用
			foreach (var bb in array)
			{
				Console.Write("{0},", bb);
			}
			Console.WriteLine();

			AlgorithmTT.BubbleSortGeneric(array, Comparis); //泛型调用
			foreach (var bb in array)
			{
				Console.Write("{0},", bb);
			}

			Console.WriteLine();

			Test();

			Console.ReadKey();
		}

		private bool Comparis(int a, int b)
		{
			return a < b;
		}

		public void Test()
		{
			Employee[] employees = 
			{
				new Employee("aaa", 2000),
				new Employee("bbb", 1000),
				new Employee("ccc", 2500),
				new Employee("ddd", 100000.38m),
				new Employee("eee", 1234),
				new Employee("fff", 50000)
			};

			BubbleSortGeneric(employees, Employee.CompareSalary);
			foreach (var employee in employees)
			{
				Console.WriteLine(employee);
			}
		}

		
	}

	public class Employee
	{
		public string Name { get; private set; }
		public decimal Salary { get; private set; }

		public Employee(string name, decimal salary)
		{
			this.Name = name;
			this.Salary = salary;
		}

		public override string ToString()
		{
			return string.Format("{0}, {1:C}", Name, Salary);
		}

		public static bool CompareSalary(Employee e1, Employee e2)
		{
			return e1.Salary < e2.Salary;
		}
	}
}
