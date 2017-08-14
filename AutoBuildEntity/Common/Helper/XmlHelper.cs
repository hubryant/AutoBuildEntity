using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AutoBuildEntity.Common.Helper
{
    public class XmlHelper
    {
        /// <summary>
        /// 将xml字符串反序列化对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="xml">xml字符串</param>
        /// <returns></returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmlS = new XmlSerializer(type);
                    return xmlS.Deserialize(sr);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 对象序列化成xml字符串
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="obj">被序列化的对象</param>
        /// <param name="encodingName">xml编码格式：utf-8,gbk,gb2312</param>
        /// <param name="xmlRootName">xml根节点名称</param>
        /// <returns></returns>
        public static string Serializer(Type type, object obj, string encodingName = "utf-8"
            , string xmlRootName = "")
        {

            XmlSerializer xmlS = string.IsNullOrWhiteSpace(xmlRootName)
                ? new XmlSerializer(type)
                : new XmlSerializer(type, new XmlRootAttribute(xmlRootName));

            try
            {
                using (MemoryStream Stream = new MemoryStream())
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Encoding = Encoding.GetEncoding(encodingName);
                    settings.OmitXmlDeclaration = false; // 是否生成<?xml version="1.0" encoding="utf-8"?>                    
                    settings.WriteEndDocumentOnClose = true;
                    settings.Indent = true; // 自动格式化，缩进对齐

                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add(string.Empty, string.Empty); // 去除默认生成的命名空间：xmlns:xsd和xmlns:xsi

                    XmlWriter xWr = XmlWriter.Create(Stream, settings);
                    xmlS.Serialize(xWr, obj, ns);

                    Stream.Position = 0;
                    using (StreamReader sr = new StreamReader(Stream, Encoding.GetEncoding(encodingName)))
                    {
                        string str = sr.ReadToEnd();
                        return str;
                    }
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}
