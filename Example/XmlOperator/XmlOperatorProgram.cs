using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.XmlOperator
{
    public class XmlOperatorProgram
    {
        /// <summary>
        /// 操作Xml文件
        /// </summary>
        public XmlOperatorProgram()
        {
            XmlFileOperator FileHandle = new XmlFileOperator();
            /************************************************************************/
            /*                          样式1                                       */
            /************************************************************************/
            //读取
            string xmlFile1 = System.Configuration.ConfigurationManager.AppSettings["配置文件1"];
            List<XmlNodeConfig> configList1 = FileHandle.GetXmlList1(xmlFile1);

            //增加节点
            FileHandle.AddNodeToXml1(xmlFile1);

            //删除节点
            //FileHandle.DelNodeFromXml(xmlFile1);

            //更新节点
            FileHandle.UpdateNodeFromXml1(xmlFile1);



            /************************************************************************/
            /*                          样式2                                       */
            /************************************************************************/
            //读取
            string xmlFile2 = System.Configuration.ConfigurationManager.AppSettings["配置文件2"];
            //List<XmlNodeConfig> configList2 = new XmlFileOperator().GetXmlList2(xmlFile2);

            //增加节点
            //FileHandle.AddNodeToXml2(xmlFile2);

            //删除节点
            //FileHandle.DelNodeFromXml(xmlFile2);

            //更新节点
            //FileHandle.UpdateNodeFromXml2(xmlFile2);
        }            
    }
}
