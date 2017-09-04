using System;
using System.IO;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using Ecm.Service;
using Ecm.Service.Sys;

namespace Ecm.Webservice
{
   

    /// <summary>
    /// Summary description for SystemService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class SystemService : System.Web.Services.WebService
    {
        //Connection
        System.Data.OleDb.OleDbConnection sqlConnection = DbConnection.OleDbConnection;
        #region Khai báo các đối tượng
        Sys_Service _Sys_Service;
        Ecm.Service.MasterTables.Rex.Rex_Dm_Heso_Chuongtrinh_Service _Rex_Dm_Heso_Chuongtrinh_Service;
        #endregion
        public SystemService()
        {

            #region Khởi tạo các đối tượng service - ware
            //master
            _Sys_Service = new Sys_Service(sqlConnection);
            #endregion

            _Rex_Dm_Heso_Chuongtrinh_Service = new Ecm.Service.MasterTables.Rex.Rex_Dm_Heso_Chuongtrinh_Service(sqlConnection);
        }

        #region Datetime

        [WebMethod]
        public static DateTime GetServerDateTime()
        {
            return DateTime.Now;
        }

        public static TimeZone CurrentTimeZone
        {

            get { return TimeZone.CurrentTimeZone; }

        }

        #endregion

        [WebMethod(Description = "Upload file")]
        public string UploadFile(byte[] f, string fileName, string profile)
        {

            // the byte array argument contains the content of the file

            // the string argument contains the name and extension

            // of the file passed in the byte array

            try
            {
                if (!Directory.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/UserProfiles/" + profile + "/")))
                    Directory.CreateDirectory(System.Web.Hosting.HostingEnvironment.MapPath("~/UserProfiles/" + profile + "/"));
                // instance a memory stream and pass the
                // byte array to its constructor
                MemoryStream ms = new MemoryStream(f);
                // instance a filestream pointing to the
                // storage folder, use the original file name
                // to name the resulting file
                FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath("~/UserProfiles/" + profile + "/") + fileName, FileMode.Create);
                // write the memory stream containing the original
                // file as a byte array to the filestream
                ms.WriteTo(fs);
                // clean up
                ms.Close();
                fs.Close();
                fs.Dispose();
                // return OK if we made it this far
                return "OK";
            }
            catch (Exception ex)
            {
                // return the error message if the operation fails
                return ex.Message.ToString();
            }
        }

        [WebMethod]
        public string[] GetConfigFiles(string profile)
        {
            if (Directory.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/UserProfiles/" + profile + "/")))
                return Directory.GetFiles(System.Web.Hosting.HostingEnvironment.MapPath("~/UserProfiles/" + profile + "/"));
            else
                return null;
        }

        [WebMethod()]
        public byte[] DownloadFile(string FName, string profile)
        {
            if (Directory.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/UserProfiles/" + profile + "/")))
            {
                System.IO.FileStream fs1 = null;
                fs1 = System.IO.File.Open(
                    System.Web.Hosting.HostingEnvironment.MapPath("~/UserProfiles/" + profile + "/") + FName
                    , FileMode.Open
                    , FileAccess.Read);
                byte[] b1 = new byte[fs1.Length];
                fs1.Read(b1, 0, (int)fs1.Length);
                fs1.Close();
                return b1;
            }
            else
                return null;
        }

        #region Sys_Service
        //[WebMethod]
        //public string Get_Rex_Dm_Heso_Chuongtrinh_Collection3()
        //{
        //    return _Sys_Service.Get_Rex_Dm_Heso_Chuongtrinh_Collection3();
        //}

        //[WebMethod]
        //public object Update_Sys_Dm_Heso_Chuongtrinh_Collection(DataSet dsCollection)
        //{
        //    return _Sys_Service.Update_Sys_Dm_Heso_Chuongtrinh_Collection(dsCollection);
        //}

        [WebMethod]
        public string GetPath()
        {
            return System.Web.Hosting.HostingEnvironment.MapPath(@"~/Resources/Database.config");
        }
        #endregion

        #region Rex_Dm_Heso_Chuongtrinh
        [WebMethod(Description = "Trả về danh sách hệ số chương trình được Serialize thành DataSet")]
        public string Get_Rex_Dm_Heso_Chuongtrinh_Collection3()
        {
            return _Rex_Dm_Heso_Chuongtrinh_Service.GetDs_Rex_Dm_Heso_Chuongtrinh_Collection();

        }

        [WebMethod(Description = "Trả về danh sách hệ số chương trình bởi nhóm hệ số được Serialize thành DataSet")]
        public string Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso(object nhom)
        {
            return _Rex_Dm_Heso_Chuongtrinh_Service.GetAll_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso(nhom);

        }

        [WebMethod(Description = "Insert một đối tượng Rex_Dm_Heso_Chuongtrinh vào bảng rex_dm_heso_chuongtrinh")]
        public object Insert_Rex_Dm_Heso_Chuongtrinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Chuongtrinh Rex_Dm_Heso_Chuongtrinh)
        {
            return _Rex_Dm_Heso_Chuongtrinh_Service.Insert_Rex_Dm_Heso_Chuongtrinh(Rex_Dm_Heso_Chuongtrinh);
        }

        [WebMethod(Description = "Update một đối tượng Rex_Dm_Heso_Chuongtrinh vào bảng rex_dm_heso_chuongtrinh")]
        public object Update_Rex_Dm_Heso_Chuongtrinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Chuongtrinh Rex_Dm_Heso_Chuongtrinh)
        {
            return _Rex_Dm_Heso_Chuongtrinh_Service.Update_Rex_Dm_Heso_Chuongtrinh(Rex_Dm_Heso_Chuongtrinh);
        }

        [WebMethod(Description = "Delete một đối tượng Rex_Dm_Heso_Chuongtrinh vào bảng rex_dm_heso_chuongtrinh")]
        public object Delete_Rex_Dm_Heso_Chuongtrinh(Ecm.Domain.MasterTables.Rex.Rex_Dm_Heso_Chuongtrinh Rex_Dm_Heso_Chuongtrinh)
        {
            return _Rex_Dm_Heso_Chuongtrinh_Service.Delete_Rex_Dm_Heso_Chuongtrinh(Rex_Dm_Heso_Chuongtrinh);
        }

        [WebMethod(Description = "Cập nhật một dataset Rex_Dm_Heso_Chuongtrinh vào trong bảng Rex_Dm_Heso_Chuongtrinh")]
        public object Update_Rex_Dm_Heso_Chuongtrinh_Collection(DataSet ds_Rex_Dm_Heso_Chuongtrinh)
        {
            return _Rex_Dm_Heso_Chuongtrinh_Service.Update_Rex_Dm_Heso_Chuongtrinh_Collection(ds_Rex_Dm_Heso_Chuongtrinh);
        }
        #endregion

    }


}
