using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;

namespace Ecm.Service.Soap
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CompressionExtensionAttribute : SoapExtensionAttribute
    {

        private int priority;

        // Override the base class properties
        public override Type ExtensionType
        {
            get { return typeof(CompressionExtension); }
        }

        public override int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

    }

    /// <summary>
    /// Compression extension
    /// </summary>
    public class CompressionExtension : SoapExtension
    {
        Stream oldStream;
        Stream newStream;

        /// <summary>
        /// Get initializer
        /// </summary>
        /// <param name="methodInfo">LogicalMethodInfo</param>
        /// <param name="attribute">SoapExtensionAttribute</param>
        /// <returns></returns>
        public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
        {
            return attribute;
        }

        /// <summary>
        /// Get the Type
        /// </summary>
        /// <param name="t">Type</param>
        /// <returns></returns>
        public override object GetInitializer(Type t)
        {
            return typeof(CompressionExtension);
        }

        /// <summary>
        /// Get the CompressionExtensionAttribute
        /// </summary>
        /// <param name="initializer">Object</param>
        public override void Initialize(object initializer)
        {
            CompressionExtensionAttribute attribute = (CompressionExtensionAttribute)initializer;
            return;
        }

        /// <summary>
        /// Process the SOAP Message
        /// </summary>
        /// <param name="message">SoapMessage</param>
        public override void ProcessMessage(SoapMessage message)
        {
            // Check for the various SOAP Message Stages 
            switch (message.Stage)
            {
                case SoapMessageStage.BeforeSerialize:
                    break;

                case SoapMessageStage.AfterSerialize:
                    //Zip(); // zip the contents of the SOAP Body after it has been serialized
                    break;

                case SoapMessageStage.BeforeDeserialize:
                    //Unzip(); // unzip the contents of the SOAP Body before it is deserialized
                    break;

                case SoapMessageStage.AfterDeserialize:
                    break;

                default:
                    throw new Exception("invalid stage");
            }
        }

        /// <summary>
        /// Gives us the ability to get hold of the RAW SOAP message
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <returns></returns>
        public override Stream ChainStream(Stream stream)
        {
            oldStream = stream;
            newStream = new MemoryStream();
            return newStream;
        }

        /// <summary>
        /// Utility method to copy streams
        /// </summary>
        /// <param name="from">Stream</param>
        /// <param name="to">Stream</param>
        void Copy(Stream from, Stream to)
        {
            TextReader reader = new StreamReader(from);
            TextWriter writer = new StreamWriter(to);

            writer.WriteLine(reader.ReadToEnd());
            writer.Flush();
        }

        /// <summary>
        /// Zip the SOAP Body
        /// </summary>
        private void Zip()
        {
            newStream.Position = 0;

            // Zip the SOAP Body
            newStream = ZipSoap(newStream);

            // Copy the streams
            Copy(newStream, oldStream);
        }

        /// <summary>
        /// The actual ZIP method
        /// </summary>
        /// <param name="stringToZip">String</param>
        /// <returns></returns>
        private byte[] Zip(string stringToZip)
        {
            byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToZip);
            MemoryStream ms = new MemoryStream();

            // Check the #ziplib docs for more information
            ZipOutputStream zipOut = new ZipOutputStream(ms);
            ZipEntry ZipEntry = new ZipEntry("ZippedFile");
            zipOut.PutNextEntry(ZipEntry);
            zipOut.SetLevel(9);
            zipOut.Write(inputByteArray, 0, inputByteArray.Length);
            zipOut.Finish();
            zipOut.Close();

            // Return the zipped contents
            return ms.ToArray();
        }

        /// <summary>
        /// Select and Zip the appropriate parts of the SOAP message
        /// </summary>
        /// <param name="streamToZip">Stream</param>
        /// <returns></returns>
        public MemoryStream ZipSoap(Stream streamToZip)
        {
            streamToZip.Position = 0;

            // Load a XML Reader
            XmlTextReader reader = new XmlTextReader(streamToZip);
            XmlDocument dom = new XmlDocument();
            dom.Load(reader);

            // Load a NamespaceManager to enable XPath selection
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(dom.NameTable);
            nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            XmlNode node = dom.SelectSingleNode("//soap:Body", nsmgr);

            // Select the contents within the method defined in the SOAP body
            node = node.FirstChild.FirstChild;

            // Check if there are any nodes selected
            while (node != null)
            {
                if (node.InnerXml.Length > 0)
                {
                    // Zip the data
                    byte[] outData = Zip(node.InnerXml);

                    // Convert it to Base64 for transfer over the internet
                    node.InnerXml = Convert.ToBase64String(outData);
                }

                // Move to the next parameter
                node = node.NextSibling;
            }

            MemoryStream ms = new MemoryStream();

            // Save the updated data
            dom.Save(ms);
            ms.Position = 0;

            return ms;
        }

        /// <summary>
        /// Unzip the SOAP Body
        /// </summary>
        private void Unzip()
        {
            MemoryStream unzipedStream = new MemoryStream();

            TextReader reader = new StreamReader(oldStream);
            TextWriter writer = new StreamWriter(unzipedStream);
            writer.WriteLine(reader.ReadToEnd());
            writer.Flush();

            // Unzip the SOAP Body
            unzipedStream = UnzipSoap(unzipedStream);

            // Copy the streams
            Copy(unzipedStream, newStream);

            newStream.Position = 0;
        }

        /// <summary>
        /// Actual Unzip logic
        /// </summary>
        /// <param name="stringToUnzip">String</param>
        /// <returns></returns>
        private byte[] Unzip(string stringToUnzip)
        {
            // Decode the Base64 encoding
            byte[] inputByteArray = Convert.FromBase64String(stringToUnzip);
            MemoryStream ms = new MemoryStream(inputByteArray);
            MemoryStream ret = new MemoryStream();

            // Refer to #ziplib documentation for more info on this
            ZipInputStream zipIn = new ZipInputStream(ms);
            ZipEntry theEntry = zipIn.GetNextEntry();
            Byte[] buffer = new Byte[2048];
            int size = 2048;

            while (true)
            {
                size = zipIn.Read(buffer, 0, buffer.Length);
                if (size > 0) ret.Write(buffer, 0, size);
                else break;
            }

            return ret.ToArray();
        }

        /// <summary>
        /// Unzip the SOAP Body
        /// </summary>
        /// <param name="streamToUnzip">Stream</param>
        /// <returns></returns>
        public MemoryStream UnzipSoap(Stream streamToUnzip)
        {
            streamToUnzip.Position = 0;

            // Load a XmlReader
            XmlTextReader reader = new XmlTextReader(streamToUnzip);
            XmlDocument dom = new XmlDocument();
            dom.Load(reader);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(dom.NameTable);
            nsmgr.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");

            // Select the SOAP Body node 
            XmlNode node = dom.SelectSingleNode("//soap:Body", nsmgr);
            node = node.FirstChild.FirstChild;

            // Check if node exists
            while (node != null)
            {
                if (node.InnerXml.Length > 0)
                {
                    // Send the node's contents to be unziped
                    byte[] outData = Unzip(node.InnerXml);
                    string sTmp = Encoding.UTF8.GetString(outData);
                    node.InnerXml = sTmp;
                }

                // Move to the next parameter
                node = node.NextSibling;
            }

            MemoryStream ms = new MemoryStream();

            dom.Save(ms);
            ms.Position = 0;

            return ms;
        }
    }
}