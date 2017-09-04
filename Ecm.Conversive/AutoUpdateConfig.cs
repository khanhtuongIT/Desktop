using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace SunLine.Conversive
{
    public class AutoUpdateConfig
    {
        public enum AvailableConfigNodes
        {
            AvailableVersionNode,
            AppFileURL,
        }

        private string _AvailableVersion;
        public string AvailableVersion
        { 
            get { return _AvailableVersion; } 
            set { _AvailableVersion = value; } 
        }

        private string _AppFileURL;
        public string AppFileURL
        { 
            get { return _AppFileURL; } 
            set { _AppFileURL = value; } 
        }

        /// <summary>
        /// LoadConfig: Invoke this method when you are ready to populate this object
        /// </summary>
        public bool LoadConfig(string url, string user, string pass)
        {
            try
            {
                //Load the xml config file
                XmlDocument XmlDoc = new XmlDocument();
                HttpWebResponse Response;
                HttpWebRequest Request;
                //Retrieve the File

                Request = (HttpWebRequest)HttpWebRequest.Create(url);
                Request.Headers.Add("Translate: f");
                if (user != null && user != "")
                    Request.Credentials = new NetworkCredential(user, pass);
                else
                    Request.Credentials = CredentialCache.DefaultCredentials;

                Response = (HttpWebResponse)Request.GetResponse();

                Stream respStream = null;
                respStream = Response.GetResponseStream();

                //Load the XML from the stream
                XmlDoc.Load(respStream);

                //Parse out the AvailableVersion
                XmlNode AvailableVersionNode = XmlDoc.SelectSingleNode(@"//AvailableVersion");
                this.AvailableVersion = AvailableVersionNode.InnerText;

                //Parse out the AppFileURL
                XmlNode AppFileURLNode = XmlDoc.SelectSingleNode(@"//AppFileURL");
                this.AppFileURL = AppFileURLNode.InnerText;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed to read the config file at: " + url);
                Debug.WriteLine("Make sure that the config file is present and has a valid format");
                //MessageBox.Show("Failed to read the config file at: " + url ); 
                //MessageBox.Show("Make sure that the config file is present and has a valid format");
                return false;
            }
            return true;
        }//LoadConfig(string url, string user, string pass)


    }//class AutoUpdateConfig
}
