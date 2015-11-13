using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Logger
{
    /// <summary>
    /// 日志消息类型枚举
    /// </summary>
    public enum MsgType
    {
        Unknown,    //未知信息类型日志记录
        Info,       //普通信息类型日志记录
        Warning,    //告警信息类型日志记录
        Error,      //错误信息类型日志记录
        Success     //成功信息日志记录
    }
}
