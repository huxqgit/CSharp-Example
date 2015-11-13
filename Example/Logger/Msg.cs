using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Logger
{
    /// <summary>
    /// 日志记录对象
    /// </summary>
    public class Msg
    {
        private DateTime dateTime;  //日志记录时间
        private string text;    //日志记录内容
        private MsgType type;   //日志记录类型

        /// <summary>
        /// 创建新的日志记录实例;日志记录的内容为空,消息类型为MsgType.Unknown,日志时间为当前时间
        /// </summary>
        public Msg()
            : this("", MsgType.Unknown)
        {

        }

        /// <summary>
        /// 创建新的日志记录实例;日志时间为当前时间
        /// </summary>
        /// <param name="t">日志记录的文本内容</param>
        /// <param name="p">日志记录的消息类型</param>
        public Msg(string t, MsgType p)
            : this(DateTime.Now, t, p)
        {

        }

        /// <summary>
        /// 创建新的日志记录实例;
        /// </summary>
        /// <param name="dt">日志记录的时间</param>
        /// <param name="t">日志记录的文本内容</param>
        /// <param name="p">日志记录的消息类型</param>
        public Msg(DateTime dt, string t, MsgType p)
        {
            dateTime = dt;
            type = p;
            text = t;
        }

        /// <summary>
        /// 获取或设置日志记录的时间
        /// </summary>
        public DateTime Datetime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }

        /// <summary>
        /// 获取或设置日志记录的文本内容
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        /// <summary>
        /// 获取或设置日志记录的消息类型
        /// </summary>
        public MsgType Type
        {
            get { return type; }
            set { type = value; }
        }

        public new string ToString()
        {
            return dateTime.ToString() + "\t" + text + System.Environment.NewLine;
        }
    }

}
