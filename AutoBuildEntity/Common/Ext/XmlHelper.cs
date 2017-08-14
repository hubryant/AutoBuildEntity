using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AutoBuildEntity.Common.Ext
{
    public static class XmlHelper
    {
        /// <summary>
        /// XML序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <param name="isnamespaces">是否需要命名空间true：需要 false:不需要</param>
        /// <returns></returns>
        public static string XmlSerializer<T>(this T o, bool isnamespaces) where T : class
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(o.GetType());

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineChars = "\r\n";
            settings.Encoding = Encoding.UTF8;
            settings.IndentChars = "   ";

            //不生成声明头
            settings.OmitXmlDeclaration = !isnamespaces;

            MemoryStream w = new MemoryStream();

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (XmlWriter writer = XmlWriter.Create(w, settings))
            {
                serializer.Serialize(writer, o, namespaces);
                writer.Close();
            }

            return Encoding.UTF8.GetString(w.ToArray());
        }

        /// <summary>
        /// XML反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="XmlString"></param>
        /// <returns></returns>
        public static T XmlDeserialize<T>(this string XmlString)
        {
            if (string.IsNullOrEmpty(XmlString))
                throw new ArgumentNullException("s");

            XmlSerializer mySerializer = new XmlSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(XmlString)))
            {
                using (StreamReader sr = new StreamReader(ms, Encoding.UTF8))
                {
                    return (T)mySerializer.Deserialize(sr);
                }
            }
        }
    }
}
