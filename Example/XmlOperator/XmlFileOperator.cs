using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Example.XmlOperator
{
    public class XmlFileOperator
    {
        /// <summary>
        /// 获取xml文件的内容
        /// </summary>
        /// <param name="xmlFile">xml文件</param>
        /// <returns></returns>
        public List<XmlNodeConfig> GetXmlList1(string xmlFile)
        {
            List<XmlNodeConfig> configList = new List<XmlNodeConfig>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile);
            //XmlNodeList xmlNodes = xmlDoc.SelectNodes("Settings/Set");
            XmlNodeList xmlNodes = xmlDoc.GetElementsByTagName("Log");
            if (xmlNodes == null)
            {
                return null;
            }

            foreach (XmlNode logNode in xmlNodes)
            {
                configList.Add(new XmlNodeConfig
                {
                    LogName = GetValueFromAttributes(logNode.Attributes["Name"]),
                    Url = GetValueFromAttributes(logNode.Attributes["Url"]),
                    SaveDays = GetValueFromAttributes(logNode.Attributes["SaveDays"]),
                    Interval = GetValueFromAttributes(logNode.Attributes["Interval"]),
                    BeginTime = GetValueFromAttributes(logNode.Attributes["BeginTime"]),
                    EndTime = GetValueFromAttributes(logNode.Attributes["EndTime"])
                });
            }

            return configList;
        }

        private static string GetValueFromAttributes(XmlAttribute att)
        {
            if (att == null)
            {
                return "";
            }
            else
            {
                return att.Value;
            }
        }

        public List<XmlNodeConfig> GetXmlList2(string xmlFile)
        {
            List<XmlNodeConfig> configList = new List<XmlNodeConfig>();
            XmlDocument xmlDoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;//忽略文档里面的注释
            XmlReader reader = XmlReader.Create(xmlFile, settings);
            xmlDoc.Load(reader);

            //得到"Set"节点
            XmlNode parentNode = xmlDoc.SelectSingleNode("Settings/Set");
            if (parentNode == null)
            {
                return null;
            }

            //得到"Set"节点的所有子节点
            XmlNodeList childNodes = parentNode.ChildNodes;
            if (childNodes == null)
            {
                return null;
            }

            foreach (XmlNode node in childNodes)
            {
                XmlNodeConfig config = new XmlNodeConfig();

                //将节点转换为元素，便于得到节点属性值
                XmlElement xe = (XmlElement)node;

                //得到node节点的所有子节点
                XmlNodeList subNode = xe.ChildNodes;

                config.LogName = xe.GetAttribute("Name").ToString();
                config.Url = subNode.Item(0).InnerText;
                config.SaveDays = subNode.Item(1).InnerText;
                config.Interval = subNode.Item(2).InnerText;
                config.BeginTime = subNode.Item(3).InnerText;
                config.EndTime = subNode.Item(4).InnerText;

                configList.Add(config);

            }

            reader.Close();

            return configList;
        }

        public void AddNodeToXml1(string xmlFile)
        {
            //加载xml文件，并选出要添加子节点的节点
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile);//不会覆盖原有内容
            //xmlDoc.LoadXml("<Settings><Set></Set></Settings>");//会覆盖原有内容
            XmlNode parentNode = xmlDoc.SelectSingleNode(@"Settings/Set");

            //创建节点，并设置节点属性
            XmlElement addNode = xmlDoc.CreateElement("Log");

            XmlAttribute addNodeName = xmlDoc.CreateAttribute("Name");
            addNodeName.InnerText = "全方位日志2";

            XmlAttribute addNodeUrl = xmlDoc.CreateAttribute("Url");
            addNodeUrl.InnerText = @"E:\vmware_linux_file\test\Working\TianJin\log2";

            XmlAttribute addNodeSaveDays = xmlDoc.CreateAttribute("SaveDays");
            addNodeSaveDays.InnerText = "5";

            addNode.SetAttributeNode(addNodeName);
            addNode.SetAttributeNode(addNodeUrl);
            addNode.SetAttributeNode(addNodeSaveDays);


            //将新建的子节点挂在到要加载的节点上
            parentNode.AppendChild(addNode);
            xmlDoc.Save(xmlFile);
        }

        public void AddNodeToXml2(string xmlFile)
        {
            //加载节点，并选出要添加子节点的节点
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile);
            XmlNode parentNode = xmlDoc.SelectSingleNode("Settings/Set");

            //创建一个节点，并设置节点属性
            XmlElement addNode = xmlDoc.CreateElement("Log");
            XmlAttribute addNodeName = xmlDoc.CreateAttribute("Name");
            addNodeName.InnerText = "全方位日志2";
            addNode.SetAttributeNode(addNodeName);

            //创建子节点
            XmlElement addNodeUrl = xmlDoc.CreateElement("Url");
            addNodeUrl.InnerText = @"E:\vmware_linux_file\test\Working\TianJin\log2";

            XmlElement addNodeSaveDays = xmlDoc.CreateElement("SaveDays");
            addNodeSaveDays.InnerText = "5";

            //将创建的子节点添加到创建的节点的下面
            addNode.AppendChild(addNodeUrl);
            addNode.AppendChild(addNodeSaveDays);

            //最后把创建的节点添加到要添加节点的节点下面
            parentNode.AppendChild(addNode);
            xmlDoc.Save(xmlFile);

        }

        public void DelNodeFromXml(string xmlFile)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile);

            // DocumentElement 获取xml文档对象的根XmlElement
            XmlElement xe = xmlDoc.DocumentElement;

            string strPath = "/Settings/Set/Log[@Name=\"全方位日志2\"]";
            XmlElement selectXe = (XmlElement)xe.SelectSingleNode(strPath);
            if (selectXe == null)
            {
                return;
            }
            selectXe.ParentNode.RemoveChild(selectXe);
            xmlDoc.Save(xmlFile);
        }

        public void UpdateNodeFromXml1(string xmlFile)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile);

            // DocumentElement 获取xml文档对象的根XmlElement
            XmlElement xe = xmlDoc.DocumentElement;

            string strPath = "/Settings/Set/Log[@Name=\"全方位日志1\"]";
            XmlElement selectXe = (XmlElement)xe.SelectSingleNode(strPath);

            if (selectXe.GetAttributeNode("Url") != null)
            {
                selectXe.GetAttributeNode("Url").InnerText = "xxxx";
                xmlDoc.Save(xmlFile);
            }
        }

        public void UpdateNodeFromXml2(string xmlFile)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFile);

            // DocumentElement 获取xml文档对象的根XmlElement
            XmlElement xe = xmlDoc.DocumentElement;

            string strPath = "/Settings/Set/Log[@Name=\"全方位日志1\"]";
            XmlElement selectXe = (XmlElement)xe.SelectSingleNode(strPath);

            if (selectXe.GetElementsByTagName("Url").Item(0) != null)
            {
                selectXe.GetElementsByTagName("Url").Item(0).InnerText = "xxxxx";
                xmlDoc.Save(xmlFile);
            }

        }
    }
}
