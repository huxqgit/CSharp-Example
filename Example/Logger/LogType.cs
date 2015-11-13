using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Logger
{
    public enum LogType
    {
        Hourly,     //每小时创建一个新的日志文件
        Daily,      //每天创建一个新的日志文件
        Weekly,     //每周创建一个新的日志文件
        Monthly,    //每月创建一个新的日志文件
        Annually,   //每年创建一个新的日志文件
        Default     //程序每次运行时创建一个新的日志文件
    }
}
