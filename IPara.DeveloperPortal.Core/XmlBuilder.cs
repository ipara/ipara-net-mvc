﻿using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace IPara.DeveloperPortal.Core
{
    /// <summary>
    /// Istekleri XML olarak oluşturucak sınıftır.
    /// Xml olarak istenen request sınıflarında istekleri xml şeklinde kullanmamıza olanak sağlar. 
    /// </summary>
    public class XmlBuilder
    {
        /// <summary>
        /// Obje olarak verilen nesneyi xml formatına çevirmeye olanak sağlayan metodu temsil eder.
        /// bu metod sadece demo sayfalarda kullanılır. Herhangi bir api çağrısında kullanılmaz.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string GetXMLFromObject(object o)
        {
            StringWriter sw = new();
            XmlTextWriter tw = null;
            try
            {
                XmlSerializer serializer = new(o.GetType());
                tw = new XmlTextWriter(sw);
                serializer.Serialize(tw, o);
            }
            catch (Exception)
            {
                return string.Empty;
            }
            finally
            {
                sw.Close();
                if (tw != null)
                {
                    tw.Close();
                }
            }
            return sw.ToString();
        }

        /// <summary>
        /// Parametre olarak verilen request sınıfını xml tipine çevirmemizi sağlar.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static StringContent SerializeToXMLString(BaseRequest request)
        {
            XmlSerializerNamespaces ns = new();
            ns.Add("", "");
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(request.GetType());
            serializer.Serialize(stringwriter, request, ns);
            var str = stringwriter.ToString().Replace("utf-16", "utf-8");
            return new StringContent(str, Encoding.UTF8, "application/xml");
        }

        /// <summary>
        /// Xml olarak verilen parametreyi object olarak çıktısını vermeye yarayan metoddur.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string xmlString)
        {
            try
            {
                XmlSerializer xs = new(typeof(T));
                MemoryStream memoryStream = new(StringToUTF8ByteArray(xmlString));
                XmlTextWriter xmlTextWriter = new(memoryStream, Encoding.UTF8);

                return (T)Convert.ChangeType(xs.Deserialize(memoryStream), typeof(T));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Xml parametresi olarak verilen string metnini byte array olarak döndürmeye olanak sağlar.
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static Byte[] StringToUTF8ByteArray(String xmlString)
        {
            UTF8Encoding encoding = new();
            Byte[] byteArray = encoding.GetBytes(xmlString);
            return byteArray;
        }

    }
}
