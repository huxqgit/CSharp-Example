using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

namespace Example.MethodInfoTest
{
	public class ScriptCall : IDisposable
	{


		private Assembly assembly;
		private CompilerParameters parameters;
		private CSharpCodeProvider provider;
		private CompilerResults result;
		public string compileErrInfo;

		private bool isCompileSucc;
		public string SourceText { get; set; }
		

		public ScriptCall(string scriptFile)
		{
			SourceText = File.ReadAllText(scriptFile);			
		}

		/// <summary>
		/// 准备编译器
		/// </summary>
		public void createCompiler()
		{
			isCompileSucc = false;

			//1>实例化C#代码服务提供对象
			provider = new CSharpCodeProvider();

			//2>声明编译器参数
			string path = Path.Combine(Path.GetTempPath(), "ScriptTT.exe");
			parameters = new CompilerParameters();			
			parameters.OutputAssembly = path;
			parameters.GenerateExecutable = true;
			parameters.GenerateInMemory = true;
		}

		/// <summary>
		/// 执行脚本方法
		/// </summary>
		public void Invoke()
		{
			if (!isCompileSucc || assembly == null)
			{
				Console.WriteLine("未编译");
				return;
			}

			MethodInfo method = assembly.EntryPoint;
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters != null && parameters.Length > 0)
			{
				//程序参数
				List<string> paramList = new List<string>();
				object[] objParameters = new object[] { paramList.ToArray() };

				//将执行cs脚本的Main方法
				method.Invoke(null, objParameters); 
				
			}
			else
			{
				method.Invoke(null, null);
			}
			
		}

		/// <summary>
		/// 动态编译
		/// </summary>
		/// <returns></returns>
		public bool Compile()
		{
			try
			{
				compileErrInfo = "";				

				//3>动态编译
				result = provider.CompileAssemblyFromSource(parameters, new string[] { SourceText });
				if (result.Errors.Count > 0)
				{
					isCompileSucc = false;
					Console.Write("编译出错！");
					StringBuilder builder = new StringBuilder();
					foreach (CompilerError error in result.Errors)
					{
						builder.Append(error.ToString());
						builder.Append("\r\n");                                                                                 
					}
					compileErrInfo = builder.ToString();					
				}
				else
				{
					isCompileSucc = true;
					assembly = result.CompiledAssembly;
				}				

				return isCompileSucc;
			}
			catch (System.Exception ex)
			{
				return false;
			}
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
