using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using Ecm.Domain.License;
using Ecm.Service.License;

namespace Ecm.Webservice
{
    /// <summary>
    /// Summary description for LicenseService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LicenseService : System.Web.Services.WebService
    {

        System.Data.OleDb.OleDbConnection sqlConnection = DbConnection.OleDbConnection;

        private Lic_Host_Service objLic_Host_Service;
        private Lic_Customers_Service _Lic_Customers_Service;
        private Lic_Pc_Appmgr_Service _Lic_Pc_Appmgr_Service;
        private Lic_Pc_Dev_Service _Lic_Pc_Dev_Service;
        private Lic_Products_Service _Lic_Products_Service;
        private Lic_Register_Service _Lic_Register_Service;


        public LicenseService()
        {

            this.objLic_Host_Service = new Lic_Host_Service(sqlConnection);
            this._Lic_Products_Service = new Lic_Products_Service(sqlConnection);
            this._Lic_Customers_Service = new Lic_Customers_Service(sqlConnection);
            this._Lic_Register_Service = new Lic_Register_Service(sqlConnection);
            this._Lic_Pc_Appmgr_Service = new Lic_Pc_Appmgr_Service(sqlConnection);
            this._Lic_Pc_Dev_Service = new Lic_Pc_Dev_Service(sqlConnection);
        }

        #region Lic_Host_Service
        [WebMethod]
        public void Insert_Lic_Host(object Mac, object Host, object Ip4, object UserName, object Desktop_Bmp, object Runtime, object Codebase)
        {
            try
            {
                Lic_Host objLicense_Host = new Lic_Host();
                objLicense_Host.Mac = Mac;
                objLicense_Host.Host = Host;
                objLicense_Host.Ip4 = Ip4;
                objLicense_Host.UserName = UserName;
                objLicense_Host.Desktop_Bmp = Desktop_Bmp;
                objLicense_Host.Runtime = Runtime;
                objLicense_Host.Codebase = Codebase;

                objLic_Host_Service.Insert_Lic_Host(objLicense_Host);
            }
            catch (Exception ex)
            { throw ex; }
        }

        [WebMethod]
        public string Get_All_Lic_Host()
        {
            return objLic_Host_Service.Get_All_Lic_Host();
        }

        [WebMethod]
        public void WriteLicenseHelper(object LogInfo)
        {
            System.IO.File.AppendAllText(System.Web.Hosting.HostingEnvironment.MapPath(@"~/Resources/Licenses.txt")
             , LogInfo + "\r\n");
        }

        #endregion

        #region Lic_Products_Service
        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Delete_Lic_Products(Lic_Products lic_Products)
        {
            return this._Lic_Products_Service.Delete_Lic_Products(lic_Products);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Delete_Lic_Products_PassText(object Product_Gui)
        {
            Lic_Products products = new Lic_Products();
            products.Product_Gui = Product_Gui;
            return this._Lic_Products_Service.Delete_Lic_Products(products);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public string Get_All_Lic_Products()
        {
            return this._Lic_Products_Service.Get_All_Lic_Products();
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Get_Lic_Products_ByPK(object Product_Gui)
        {
            return this._Lic_Products_Service.Get_Lic_Products_ByPK(Product_Gui);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Insert_Lic_Products(Lic_Products lic_Products)
        {
            return this._Lic_Products_Service.Insert_Lic_Products(lic_Products);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Insert_Lic_Products_PassText(object Product_Gui, object Product_Name, object Product_Version, object Release_Date)
        {
            Lic_Products products = new Lic_Products();
            products.Product_Gui = Product_Gui;
            products.Product_Name = Product_Name;
            products.Product_Version = Product_Version;
            products.Release_Date = Release_Date;
            return this._Lic_Products_Service.Insert_Lic_Products(products);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Update_Lic_Products(Lic_Products lic_Products)
        {
            return this._Lic_Products_Service.Update_Lic_Products(lic_Products);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Update_Lic_Products_PassText(object Product_Gui, object Product_Name, object Product_Version, object Release_Date)
        {
            Lic_Products products = new Lic_Products();
            products.Product_Gui = Product_Gui;
            products.Product_Name = Product_Name;
            products.Product_Version = Product_Version;
            products.Release_Date = Release_Date;
            return this._Lic_Products_Service.Update_Lic_Products(products);
        }
        #endregion

        #region Lic_Register_Service
        [WebMethod]
        public object Delete_Lic_Register_PassText(object Reg_Code)
        {
            Lic_Register register = new Lic_Register();
            register.Reg_Code = Reg_Code;
            return this._Lic_Register_Service.Delete_Lic_Register(register);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public string Get_All_Lic_Register()
        {
            return this._Lic_Register_Service.Get_All_Lic_Register();
        }

        [WebMethod]
        public string Get_Lic_Register_PassText(object Reg_Code, object Pc_Code)
        {
            Lic_Register register = new Lic_Register();
            register.Reg_Code = Reg_Code;
            register.Pc_Code = Pc_Code;
            return this._Lic_Register_Service.Get_Lic_Register(register);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Insert_Lic_Register(Lic_Register lic_Register)
        {
            return this._Lic_Register_Service.Insert_Lic_Register(lic_Register);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Insert_Lic_Register_PassText(object Reg_Code, object Pc_Code, object Product_Gui, object Customer_Code, object Pc_Name, object User_Name, object Serial_Number, object Runtype, object Expired_Date, object Install_Date, object Reg_Date)
        {
            Lic_Register register = new Lic_Register();
            register.Reg_Code = Reg_Code;
            register.Pc_Code = Pc_Code;
            register.Product_Gui = Product_Gui;
            register.Customer_Code = Customer_Code;
            register.Pc_Name = Pc_Name;
            register.User_Name = User_Name;
            register.Serial_Number = Serial_Number;
            register.Runtype = Runtype;
            register.Expired_Date = Expired_Date;
            register.Install_Date = Install_Date;
            register.Reg_Date = Reg_Date;
            return this._Lic_Register_Service.Insert_Lic_Register(register);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Update_Lic_Register(Lic_Register lic_Register)
        {
            return this._Lic_Register_Service.Update_Lic_Register(lic_Register);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Update_Lic_Register_PassText(object Reg_Code, object Pc_Code, object Product_Gui, object Customer_Code, object Pc_Name, object User_Name, object Serial_Number, object Runtype, object Expired_Date, object Install_Date, object Reg_Date)
        {
            Lic_Register register = new Lic_Register();
            register.Reg_Code = Reg_Code;
            register.Pc_Code = Pc_Code;
            register.Product_Gui = Product_Gui;
            register.Customer_Code = Customer_Code;
            register.Pc_Name = Pc_Name;
            register.User_Name = User_Name;
            register.Serial_Number = Serial_Number;
            register.Runtype = Runtype;
            register.Expired_Date = Expired_Date;
            register.Install_Date = Install_Date;
            register.Reg_Date = Reg_Date;
            return this._Lic_Register_Service.Update_Lic_Register(register);
        }

        #endregion

        #region Lic_Customers_Service
        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public string Get_All_Lic_Customers()
        {
            return this._Lic_Customers_Service.Get_All_Lic_Customers();
        }

        [WebMethod]
        public string Get_Lic_Customers_ByPK_PassText(object Customer_Code, object Product_Gui)
        {
            return this._Lic_Customers_Service.Get_Lic_Customers_ByPK(Customer_Code, Product_Gui);
        }

        [WebMethod]
        public string Get_Lic_Customers_ByProduct(object Product_Gui)
        {
            return this._Lic_Customers_Service.Get_Lic_Customers_ByProduct(Product_Gui);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Insert_Lic_Customers(Lic_Customers lic_Customers)
        {
            return this._Lic_Customers_Service.Insert_Lic_Customers(lic_Customers);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Insert_Lic_Customers_PassText(object Customer_Code, object Product_Gui, object Runtype, object Noseats, object Expired_Date, object Email, object Create_Date)
        {
            Lic_Customers customers = new Lic_Customers();
            customers.Customer_Code = Customer_Code;
            customers.Product_Gui = Product_Gui;
            customers.Runtype = Runtype;
            customers.Noseats = Noseats;
            customers.Expired_Date = Expired_Date;
            customers.Email = Email;
            customers.Create_Date = Create_Date;
            return this._Lic_Customers_Service.Insert_Lic_Customers(customers);
        }


        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Update_Lic_Customers(Lic_Customers lic_Customers)
        {
            return this._Lic_Customers_Service.Update_Lic_Customers(lic_Customers);
        }

        [WebMethod]
        public object Update_Lic_Customers_PassText(object Customer_Code, object Product_Gui, object Runtype, object Noseats, object Expired_Date, object Email)
        {
            Lic_Customers customers = new Lic_Customers();
            customers.Customer_Code = Customer_Code;
            customers.Product_Gui = Product_Gui;
            customers.Runtype = Runtype;
            customers.Noseats = Noseats;
            customers.Expired_Date = Expired_Date;
            customers.Email = Email;
            return this._Lic_Customers_Service.Update_Lic_Customers(customers);
        }

        #endregion

        #region Lic_Pc_Appmgr_Service
        [WebMethod]
        public string Get_Lic_Pc_Appmgr_PassText(string Pc_Code)
        {
            Lic_Pc_Appmgr appmgr = new Lic_Pc_Appmgr();
            appmgr.Pc_Code = Pc_Code;
            return this._Lic_Pc_Appmgr_Service.Get_Lic_Pc_Appmgr_ByPK(appmgr);
        }

        #endregion

        #region Lic_Pc_Dev_Service
        [WebMethod]
        public string Get_Lic_Pc_Dev_PassText(string Pc_Code)
        {
            Lic_Pc_Dev dev = new Lic_Pc_Dev();
            dev.Pc_Code = Pc_Code;
            return this._Lic_Pc_Dev_Service.Get_Lic_Pc_Dev_ByPK(dev);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Insert_Lic_Pc_Appmgr_PassText(object Pc_Code, object Pc_Name, object User_Name)
        {
            Lic_Pc_Appmgr appmgr = new Lic_Pc_Appmgr();
            appmgr.Pc_Code = Pc_Code;
            appmgr.Pc_Name = Pc_Code;
            appmgr.User_Name = User_Name;
            return this._Lic_Pc_Appmgr_Service.Insert_Lic_Pc_Appmgr(appmgr);
        }

        [WebMethod(Description = "Trả về một dataset Bar_Table_Order")]
        public object Insert_Lic_Pc_Dev_PassText(object Pc_Code, object Pc_Name, object User_Name, object Ip4, object Runtime, object EntryAssembly)
        {
            Lic_Pc_Dev dev = new Lic_Pc_Dev();
            dev.Pc_Code = Pc_Code;
            dev.Pc_Name = Pc_Name;
            dev.User_Name = User_Name;
            dev.Ip4 = Ip4;
            dev.Runtime = Runtime;
            dev.EntryAssembly = EntryAssembly;
            return this._Lic_Pc_Dev_Service.Insert_Lic_Pc_Dev(dev);
        }
        #endregion









    }
}
