using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Net;
using System.Xml.Serialization;
using SyonOnline.ServiceFacade.Interface;
using System.Net.Http;

//using System.Web.Services.Protocols;

namespace SyonOnline.ServiceFacade
{
    public class Util
    {
        /*
        private static readonly string testarNaUrl2 = ConfigurationManager.AppSettings["testarNaUrl2"];
 
        private static readonly string urlAdquirencia = ConfigurationManager.AppSettings["urlAdquirencia"];
        private static readonly string urlAdquirenciaV2 = ConfigurationManager.AppSettings["urlAdquirenciaV2"];
        private static readonly string urlDatacash = ConfigurationManager.AppSettings["urlDatacash"];
        private static readonly string urlKomerci = ConfigurationManager.AppSettings["urlKomerci"];
 
        private static readonly string url2Adquirencia = ConfigurationManager.AppSettings["url2Adquirencia"];
        private static readonly string url2AdquirenciaV2 = ConfigurationManager.AppSettings["url2AdquirenciaV2"];
        private static readonly string url2Datacash = ConfigurationManager.AppSettings["url2Datacash"];
        private static readonly string url2Komerci = ConfigurationManager.AppSettings["url2Komerci"];
  
        public static string GetUrlAdquirencia()
        {
            if (testarNaUrl2 == "0")
            {
                return urlAdquirencia;
            }
 
            return url2Adquirencia;
        }
 
        public static string GetUrlAdquirenciaV2()
        {
            if (testarNaUrl2 == "0")
            {
                return urlAdquirenciaV2;
            }
 
            return url2AdquirenciaV2;
        }
 
        public static string GetUrlDatacash()
        {
            if (testarNaUrl2 == "0")
            {
                return urlDatacash;
            }
 
            return url2Datacash;
        }
 
        public static string GetUrlKomerci()
        {
            if (testarNaUrl2 == "0")
            {
                return urlKomerci;
            }
 
            return url2Komerci;
        }
 */
        public static T Deserialize<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T result;
            using (TextReader reader = new StringReader(xml))
            {
                result = (T)serializer.Deserialize(reader);
            }
 
            return result;
        }
 
        public static string Serialize<T>(T request)
        {
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("", "");
 
            XmlSerializer xsSubmit = new XmlSerializer(typeof(T));
            var subReq = request;
            var xml = "";
 
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww, new XmlWriterSettings { OmitXmlDeclaration = true }))
                {
                    xsSubmit.Serialize(writer, subReq, xmlSerializerNamespaces);
                    xml = sww.ToString(); // Your XML
                }
            }
 
            return xml;
        }
 
       /* public static string PostXMLData(string destinationUrl, string requestXml, IServiceFacade service)
        {
            var horaInicial = DateTime.Now;
            
            new HttpClient().PostAsync(destinationUrl, );

            WebRequest request = (WebRequest)WebRequest.Create(destinationUrl);
            byte[] bytes;
            bytes = Encoding.ASCII.GetBytes(requestXml);
            request.ContentType = "text/xml; encoding='utf-8'";
            request.ContentLength = bytes.Length;
            request.Method = "POST";
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
            HttpWebResponse response;
 
            Util.SaveXmlRequest(requestXml, service.GetTestId(), service.GetMethodName());
 
            response = (HttpWebResponse)request.GetResponse();
 
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
                string responseStr = new StreamReader(responseStream).ReadToEnd();
 
                Util.SaveXmlResponse(responseStr, horaInicial, service.GetTestId(), service.GetMethodName());
 
                return responseStr;
            }
 
            return null;
        }
 
        public static void SaveXmlResponse(string xml, DateTime horaInicial, string testId, string methodName)
        {
            Warning.SecondsExecution = (DateTime.Now - horaInicial).TotalSeconds;
 
            Console.WriteLine(string.Format("Tempo : {0}", Warning.SecondsExecution));
 
            SaveXml(xml, "Response",  testId,  methodName);
        }
 
        public static void SaveXmlRequest(string xml, string testId, string methodName)
        {
            SaveXml(xml, "Request",  testId,  methodName);
        }
 
        private static void SaveXml(string xml, string type, string testId, string methodName)
        {
            var baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
 
            var testResults = Path.Combine(baseDirectory, "Test Results");
 
            Directory.CreateDirectory(testResults);
 
            var fullName = GetNextFileName(Path.Combine(testResults, string.Concat(testId, "-", type, "-", methodName, ".xml")));
 
            File.WriteAllText(fullName, xml);
        }
 
        private static string GetNextFileName(string fileName)
        {
            string extension = Path.GetExtension(fileName);
 
            int i = 0;
            while (File.Exists(fileName))
            {
                if (i == 0)
                    fileName = fileName.Replace(extension, "(" + ++i + ")" + extension);
                else
                    fileName = fileName.Replace("(" + i + ")" + extension, "(" + ++i + ")" + extension);
            }
 
            return fileName;
        }
 
        public static string GetUrlService<TServiceFacase, TService>(object type, object service) where TServiceFacase : IServiceFacade
        {
            var url = string.Empty;
 
            url = ((IServiceFacade)type).GetUrl();
 
            if (string.IsNullOrEmpty(url) && service != null)
            {
                url = ((SoapHttpClientProtocol)service).Url;
            }
 
            Console.WriteLine(string.Format("Data Hora : {0}", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")));
 
            Console.WriteLine(string.Format("URL Serviço : {0}", url));
 
            return url;
        }
 */
    }
 
}
