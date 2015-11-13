using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;

namespace Example.ZipHelper
{
    public class ZipTest
    {
        public void Test()
        {
            ZipTest zz = new ZipTest();
            string[] files = new string[2];
            files[0] = @"TextFile1.txt";
            files[1] = @"TextFile2.txt";

            string zipFile = @"D:\投诉打点二阶段\EomsService\TextFile.zip";

            zz.FileToZip(files, zipFile, false);
        }

        /// <summary>
        /// 将参数1指定的文件添加到参数2指定的压缩文件中，参数3用于指定添加完成后是否删除参数1的文件
        /// </summary>
        /// <param name="files"></param>
        /// <param name="ZipFileName"></param>
        /// <returns></returns>
        public void FileToZip(string[] files, string ZipFileName, bool isDelSour)
        {
            
            
            try
            {
                string zipPath = Path.GetDirectoryName(ZipFileName);
                if (!Directory.Exists(zipPath))
                {
                    Directory.CreateDirectory(zipPath);
                }

                using (ZipFile zip = ZipFile.Create(ZipFileName))
                {
                    zip.BeginUpdate();
                    ZipEntry e = new ZipEntry("a");

                    //添加文件
                    foreach (string sourFile in files)
                    {
                        if (File.Exists(sourFile))
                        {
                            zip.Add(sourFile);

                            if (isDelSour)
                            {
                                File.Delete(sourFile);
                            }
                        }
                    }

                    zip.CommitUpdate();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
