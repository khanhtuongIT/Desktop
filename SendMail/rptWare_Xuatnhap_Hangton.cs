using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using GoobizFrame.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace SendMail
{
    public partial class rptWare_Xuatnhap_Hangton : DevExpress.XtraReports.UI.XtraReport
    {
        public rptWare_Xuatnhap_Hangton()
        {
            InitializeComponent();
        }

        public void sendMail()
        {
            ReportService.ReportService obj_report = new ReportService.ReportService();
            MasterService.MasterService objMasterService = new MasterService.MasterService();

            DateTime ngay_hientai = DateTime.Now;
            DateTime ngay_batdau = new DateTime(ngay_hientai.Year, ngay_hientai.Month, 1);
            DateTime ngay_ketthuc = new DateTime(ngay_hientai.Year, ngay_hientai.Month, DateTime.DaysInMonth(ngay_hientai.Year, ngay_hientai.Month));
            DataSet dsKho = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet();
            rptWare_Xuatnhap_Hangton _Rptware_Hangton = new rptWare_Xuatnhap_Hangton();
            DataSet dsHeso_Chuongtrinh = new DataSet();
            #region Thiết lập hệ số chương trình (Logo, thông tin công ty)
            using (dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));
                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);
                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData});
                _Rptware_Hangton.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _Rptware_Hangton.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion

            string path = @"D:\baocao_khohang\";
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            string smtpAddress = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Mail_Server"))[0]["Heso"].ToString(); //"smtp.longthanhmekong.com";
            int portNumber = Convert.ToInt32(dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Port"))[0]["Heso"]); //25;
            bool enableSSL = Convert.ToBoolean(dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "SSL"))[0]["Heso"]);// false;
            string emailFrom = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Email_Server"))[0]["Heso"].ToString(); //"info@longthanhmekong.com";
            string password = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Password_Email"))[0]["Heso"].ToString(); ///"leminhlong18072007";
                                                                                                                                                       ///
            foreach (DataRow row_kho in dsKho.Tables[0].Rows)
            {
                DataSet ds_hangton = obj_report.Rptware_Nhapxuatton(row_kho["Id_Cuahang_Ban"], ngay_batdau, ngay_ketthuc, null, null).ToDataSet();
                _Rptware_Hangton.xrTable_Kho.Text = row_kho["Ten_Cuahang_Ban"].ToString();
                _Rptware_Hangton.xrTable_Denngay.Text = DateTime.Today.ToString("dd/MM/yyyy");
                _Rptware_Hangton.xrTable_Ngay.Text = DateTime.Today.Day.ToString();
                _Rptware_Hangton.xrTable_Thang.Text = DateTime.Today.Month.ToString();
                _Rptware_Hangton.xrTable_Nam.Text = DateTime.Today.Year.ToString();
                _Rptware_Hangton.DataSource = ds_hangton;
                _Rptware_Hangton.CreateDocument();
                string file_name = row_kho["Ma_Cuahang_Ban"].ToString()  + "_"+ DateTime.Now.ToString("yyMMddHHmm");
                _Rptware_Hangton.ExportToPdf(path + file_name + ".pdf");
            
                //string smtpAddress = "smtp.longthanhmekong.com";
                //int portNumber = 25;
                //bool enableSSL = false;
                ////string emailFrom = "ltmekong.sys@gmail.com";
                ////string password = "11223300778899";
                //string emailFrom = "info@longthanhmekong.com";
                //string password = "leminhlong18072007";
                string subject = "BÁO CÁO TỒN KHO NGÀY " + DateTime.Now.ToString("dd/MM/yyyy");
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add("ltdung@longthanhmekong.com"); //hoangnhan1907@gmail.com
                    mail.Subject = subject;
                    mail.Body = "";
                    mail.IsBodyHtml = true;
                    // Can set to false, if you are sending pure text.
                    mail.Attachments.Add(new Attachment((path + file_name + ".pdf")));
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential("info", password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
            }
        }
    }
}
