using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Example.FileOperator
{
    public class FileTest
    {
        public void Test()
        {
            List<string> dataFiles = GetDataFiles(new DirectoryInfo(@"E:\TempData1"), "*.log", 5);
            foreach (string file in dataFiles)
            {
                List<string> contentList = new List<string>(File.ReadAllLines(file));
                int i = 1;
                foreach (string line in contentList)
                {
                    Console.WriteLine(i.ToString() + ": " + line);
                    i++;
                }

                //File.Delete(file);
            }
        }

        /// <summary>
        /// 获取指定目录下、回溯分钟之前的、指定文件后缀的所有的文件, directory: 路径, pattern: 文件后缀，backMinutes：回溯分钟
        /// </summary>
        /// <param name="directory">路径</param>
        /// <param name="pattern">文件后缀</param>
        /// <returns></returns>
        private List<string> GetDataFiles(DirectoryInfo directory, string pattern, int backMinutes)
        {
            List<string> list = new List<string>();

            Int64 boundaryTime = Int64.Parse(DateTime.Now.AddMinutes(-backMinutes).ToString("yyyyMMddHHmm"));
            if (directory.Exists || pattern.Trim() != string.Empty)
            {
                foreach (FileInfo info in directory.GetFiles(pattern))
                {
                    Int64 createTime = Int64.Parse(info.LastWriteTime.ToString("yyyyMMddHHmm"));
                    if (createTime < boundaryTime)
                    {
                        list.Add(info.FullName.ToString());
                    }
                }
            }

            return list;
        }
    }
}
