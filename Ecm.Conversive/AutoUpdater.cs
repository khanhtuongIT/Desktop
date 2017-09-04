/*
 * AutoUpdater.cs
 * This class is the main component of the AutoUpdater
 *  
 * Copyright 2004 Conversive, Inc.
 * 
 */

/*
 * Conversive's C# AutoUpdater Component
 * Copyright 2004 Conversive, Inc.
 * 
 * This is a component which allows automatic software updates.
 * It is written in C# and was developed by Conversive, Inc. on April 14th 2004.
 * 
 * The C# AutoUpdater Component is licensed under the LGPL:
 * ------------------------------------------------------------------------
 * 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 * 
 * ------------------------------------------------------------------------
 */

using System;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Net;

using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

using System.Management;

namespace SunLine.Conversive
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class AutoUpdater: Component
	{
        private Type updateType = null;
		public AutoUpdater()
		{
			//
			// If it was easy, anybody could do it!
			//
		}

		private string _LoginUserName;
		[DefaultValue(@"")]
		[Description("The UserName to authenticate with."), 
		Category("AutoUpdater Configuration")]
		public string LoginUserName 
		{ get { return _LoginUserName; } set { _LoginUserName = value; } }

		private string _LoginUserPass;
		[DefaultValue(@"")]
		[Description("The Password to authenticate with."), 
		Category("AutoUpdater Configuration")]
		public string LoginUserPass 
		{ get { return _LoginUserPass; } set { _LoginUserPass = value; } }

		private string _ConfigURL;
		[DefaultValue(@"http://localhost/UpdateConfig.xml")]
		[Description("The URL Path to the configuration file."), 
		Category("AutoUpdater Configuration")]
		public string ConfigURL 
		{ get { return _ConfigURL; } set { _ConfigURL = value; } }

		private bool _AutoRestart;//If true, the app will restart automatically, if false the app will use the RestartForm to prompt the user, if RestartForm is null, it doesn't restart
		[DefaultValue(false)]
		[Description("Set to True if you want the app to restart automatically, set to False if you want to use the RestartForm to prompt the user, if RestartForm is null, the app will not restart."), 
		Category("AutoUpdater Configuration")]
		public bool AutoRestart 
		{ get { return _AutoRestart; } set { _AutoRestart = value; } }

		private Form _RestartForm;
		public Form RestartForm 
		{ get { return _RestartForm; } set { _RestartForm = value; } }


		/// <summary>
		/// TryUpdate: Invoke this method when you are ready to run the update checking thread
		/// </summary>
		public void TryUpdate()
		{
			Thread backgroundThread = new Thread(new ThreadStart(this.updateThread));
			backgroundThread.IsBackground = true;
			backgroundThread.Start();
		}//TryUpdate()

        public void TryUpdate(Type updateType)
        {
            this.updateType = updateType;
            Thread backgroundThread = new Thread(new ThreadStart(this.updateThread));
            backgroundThread.IsBackground = true;
            backgroundThread.Start();
        }//TryUpdate()

		/// <summary>
		/// updateThread: This is the Thread that runs for checking updates against the config file
		/// </summary>
		private void updateThread()
		{
            string stUpdateName = "Update";
			AutoUpdateConfig config = new AutoUpdateConfig();
			
			//For using untrusted SSL Certificates
			System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();

			//Do the load of the config file
			if(config.LoadConfig(this.ConfigURL, this.LoginUserName, this.LoginUserPass))
			{
				//Check the file for an update
                System.Reflection.Assembly assembly = null;
                assembly = (updateType != null)
                    ? System.Reflection.Assembly.GetAssembly(updateType)
                    : System.Reflection.Assembly.GetEntryAssembly();
                Version vCurrent = assembly.GetName().Version;
				Version vConfig = new Version(config.AvailableVersion);
				if(vConfig > vCurrent)
				{
                    //GoobizFrame.Windows.Forms.UserMessage.Show("Msg00009", new string[] {vConfig.ToString(), config.AppFileURL});
					DirectoryInfo diDest = new DirectoryInfo(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
					string stPath = diDest.Parent.FullName + System.IO.Path.DirectorySeparatorChar + stUpdateName + ".zip";
                    DirectoryInfo diPath = new DirectoryInfo(stPath);
					//There is a new version available
					if(this.downloadFile(config.AppFileURL, stPath))
					{
						//MessageBox.Show("Downloaded New File");
						string stDest = diDest.Parent.FullName + System.IO.Path.DirectorySeparatorChar + stUpdateName + System.IO.Path.DirectorySeparatorChar;
						//Extract Zip File
						this.unzip(stPath, stDest);
                        //copy all new file to executable path
                        DirectoryInfo diNewDest = new DirectoryInfo(stDest);
                        foreach (FileInfo file in diNewDest.GetFiles())
                        {
                            try
                            {
                                File.Copy(file.FullName, diDest.FullName + "\\" + file.Name, true);
                            }
                            catch(Exception ex)
                            {
                                continue; 
                            }
                        }

						//Delete Zip File
						File.Delete(stPath);
					
                        //Restart App if Necessary
						//If true, the app will restart automatically, if false the app will use the RestartForm to prompt the user, if RestartForm is null, it doesn't restart
                        //if (this.AutoRestart || (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00010", new string[] { }) == DialogResult.Yes))
                        //{
                        //    this.restart();
                        //}
						//else don't restart
					}
					//else
					//	MessageBox.Show("Didn't Download File");
					
				}
				//else
				//	MessageBox.Show("No New Version Available, Web Version: " + vConfig.ToString() + ", Current Version: " +  vCurrent.ToString());
			}
			//else
			//	MessageBox.Show("Problem loading config file, from: " + this.ConfigURL);

            //GoobizFrame.Windows.Forms.UserMessage.Show("Msg00011", new string[] {"cập nhật phiên bản phần mềm" });

		}//updateThread()

		/// <summary>
		/// downloadFile: Download a file from the specified url and copy it to the specified path
		/// </summary>
		private bool downloadFile(string url, string path)
		{
			try
			{
				//create web request/response
				HttpWebResponse Response;
				HttpWebRequest Request;

				Request = (HttpWebRequest)HttpWebRequest.Create(url);
				Request.Headers.Add("Translate: f");
				if(this.LoginUserName != null && this.LoginUserName != "")
					Request.Credentials = new NetworkCredential(this.LoginUserName, this.LoginUserPass);
				else
					Request.Credentials = CredentialCache.DefaultCredentials;

				Response = (HttpWebResponse)Request.GetResponse();

				Stream respStream = null;
				respStream = Response.GetResponseStream();

				//Do the Download
				byte[] buffer = new byte[4096];
				int length;

				FileStream fs = File.Open(path, FileMode.Create, FileAccess.Write);
			
				length = respStream.Read(buffer, 0, 4096);
				while(length > 0)
				{
					fs.Write(buffer, 0, length);
					length = respStream.Read(buffer, 0, 4096);
				}
				fs.Close();	
			}
			catch(Exception e)
			{
				//MessageBox.Show("Problem copying file from: " + url + " to: " + path);
				if(File.Exists(path))
					File.Delete(path);
				return false;
			}
			return true;
		}//downloadFile(string url, string path)

		/// <summary>
		/// unzip: Open the zip file specified by stZipPath, into the stDestPath Directory
		/// </summary>
		private void unzip(string stZipPath, string stDestPath)
		{
			ZipInputStream s = new ZipInputStream(File.OpenRead(stZipPath));
		
			ZipEntry theEntry;
			while ((theEntry = s.GetNextEntry()) != null) 
			{
			
				string fileName = stDestPath + Path.GetDirectoryName(theEntry.Name) + System.IO.Path.DirectorySeparatorChar + Path.GetFileName(theEntry.Name);
			
				//create directory for file (if necessary)
				Directory.CreateDirectory(Path.GetDirectoryName(fileName));
			
				if (!theEntry.IsDirectory) 
				{
					FileStream streamWriter = File.Create(fileName);
				
					int size = 2048;
					byte[] data = new byte[2048];
					while (true) 
					{
						size = s.Read(data, 0, data.Length);
						if (size > 0) 
						{
							streamWriter.Write(data, 0, size);
						} 
						else 
						{
							break;
						}
					}
				
					streamWriter.Close();
				}
			}
			s.Close();
		}//unzip(string stZipPath, string stDestPath)

		/// <summary>
		/// restart: Restart the app, the AppStarter will be responsible for actually restarting the main application.
		/// </summary>
		private void restart()
		{
            Application.ThreadExit += new EventHandler(Application_ThreadExit);
			Environment.ExitCode = 2; //the surrounding AppStarter must look for this to restart the app.
			Application.Exit();
		}

        void Application_ThreadExit(object sender, EventArgs e)
        {
           DirectoryInfo diDest = new DirectoryInfo(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location));
           string stPath = diDest.Parent.FullName + System.IO.Path.DirectorySeparatorChar + "Update";
           string dirName = diDest.FullName; // beware the double quotes!
           this.CopyDirectory(stPath, diDest.FullName);
        }//restart()

        void CopyDirectory(string Src,string Dst)
        {
            String[] Files;

            if(Dst[Dst.Length-1]!=Path.DirectorySeparatorChar) 
                Dst+=Path.DirectorySeparatorChar;
            if(!Directory.Exists(Dst)) Directory.CreateDirectory(Dst);
            Files=Directory.GetFileSystemEntries(Src);
            foreach(string Element in Files)
            {
                // Sub directories
                if(Directory.Exists(Element)) 
                    CopyDirectory(Element,Dst+Path.GetFileName(Element));
                // Files in directory
                else 
                    File.Copy(Element,Dst+Path.GetFileName(Element),true);
             }
         }


	}//class AutoUpdater

	public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
	{
		public TrustAllCertificatePolicy()
		{}

		public bool CheckValidationResult(ServicePoint sp,
			System.Security.Cryptography.X509Certificates.X509Certificate cert,WebRequest req, int problem)
		{
			return true;
		}
	}//class TrustAllCertificatePolicy
}//namespace Conversive.AutoUpdater
