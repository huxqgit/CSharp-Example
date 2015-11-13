using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.XmlOperator
{
    public class XmlNodeConfig
    {
        public XmlNodeConfig()
        {

        }

        //public string LogName { get; set; }
        //public string Url { get; set; }
        //public string SaveDays { get; set; }
        //public string Interval { get; set; }
        //public string BeginTime { get; set; }
        //public string EndTime { get; set; }

        private string logName;
        public string LogName
        {
            get { return logName; }
            set { logName = value; }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        private string saveDays;
        public string SaveDays
        {
            get { return saveDays; }
            set { saveDays = value; }
        }

        private string interval;
        public string Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        private string beginTime;
        public string BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }

        private string endTime;
        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
    }
}
