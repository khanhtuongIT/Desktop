using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using GoobizFrame.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Web.UI;
using System.Globalization;

namespace SendMail
{
    class Program
    {
        public static void Main(string[] args)
        {
            new Send_Mail().Run();
        }
    }

    class Send_Mail
    {
        public void Run()
        {
            RexService.RexService obj = new RexService.RexService();
            ReportService.ReportService obj_report = new ReportService.ReportService();
            MasterService.MasterService obj_Master = new MasterService.MasterService();

            DataSet dsNhansuSale = obj.Get_All_Rex_Nhansu_Collection().ToDataSet();
            DataRow[] dtr = dsNhansuSale.Tables[0].Select("Email is not null ", "");

            DataSet dsHeso_Chuongtrinh = obj_Master.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet();
            string smtpAddress = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Mail_Server"))[0]["Heso"].ToString(); //"smtp.longthanhmekong.com";
            int portNumber = Convert.ToInt32(dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Port"))[0]["Heso"]); //25;
            bool enableSSL = Convert.ToBoolean(dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "SSL"))[0]["Heso"]);// false;
            string emailFrom = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Email_Server"))[0]["Heso"].ToString(); //"info@longthanhmekong.com";
            string password = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "Password_Email"))[0]["Heso"].ToString(); ///"leminhlong18072007";

            Console.Write("Begin Send mail!");
            foreach (DataRow row_nhansu in dtr)
            {
                string emailTo = row_nhansu["Email"].ToString();
                string emailCC = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyEmail"))[0]["Heso"].ToString();

                // send mail công nợ
                string subject = "CÔNG NỢ ĐẾN HẠN NGÀY " + DateTime.Now.ToString("dd/MM/yyyy");
                DataSet dsCongno = obj_report.RptCongno_Sendmail(row_nhansu["Id_Nhansu"]).ToDataSet();
                string body = ConvertDataTableToHTML(dsCongno.Tables[0]);
                if (dsCongno.Tables[0].Rows.Count > 0)
                    using (MailMessage mail = new MailMessage())
                    {
                        //emailTo = "hoangnhan1907@gmail.com";
                        mail.From = new MailAddress(emailFrom);
                        mail.To.Add(emailTo);
                        mail.CC.Add(emailCC);
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = true;
                        //mail.Attachments.Add(new Attachment("D:\\donhang\\" + txtSochungtu.Text + ".pdf"));
                        //mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));
                        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                        {
                            smtp.Credentials = new NetworkCredential("info", password);
                            smtp.EnableSsl = enableSSL;
                            smtp.Send(mail);
                        }
                    }

                //send mail đơn hàng dự kiến
                string subject2 = "ĐƠN HÀNG DỰ KIẾN NGÀY " + DateTime.Now.ToString("dd/MM/yyyy");
                DataSet dsDonhang_dukien = obj_report.Ware_Hdbanhang_Chitiet_Dudoan_Dathang_SenMail(row_nhansu["Id_Nhansu"]).ToDataSet();
                string body2 = ConvertDataTableToHTML_dukien(dsDonhang_dukien.Tables[0]);

                if (dsDonhang_dukien.Tables[0].Rows.Count > 0)
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(emailFrom);
                        mail.To.Add(emailTo);
                        mail.CC.Add(emailCC);
                        mail.Subject = subject2;
                        mail.Body = body2;
                        mail.IsBodyHtml = true;
                        using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                        {
                            smtp.Credentials = new NetworkCredential("info", password);
                            smtp.EnableSsl = enableSSL;
                            smtp.Send(mail);
                        }
                    }
            }

            //// send mail tồn kho
            //string subject3 = "BÁO CÁO TỒN KHO NGÀY " + DateTime.Now.ToString("dd/MM/yyyy");
            //DateTime ngay_hientai = DateTime.Now;
            //DateTime ngay_batdau = new DateTime(ngay_hientai.Year, ngay_hientai.Month, 1);
            //DateTime ngay_ketthuc = new DateTime(ngay_hientai.Year, ngay_hientai.Month, DateTime.DaysInMonth(ngay_hientai.Year, ngay_hientai.Month));
            //DataSet dsKho = obj_Master.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet();
            //string body3 = "";
            //DataSet dsLoai_Hanghoa = obj_Master.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet();
            //foreach (DataRow row_kho in dsKho.Tables[0].Rows)
            //{
            //    body3 += "<p>" + row_kho["Ten_Cuahang_Ban"] + "<p/>";                
            //    foreach (DataRow row_loai_Hang in dsLoai_Hanghoa.Tables[0].Rows)
            //    {
            //        DataSet ds_hangton = obj_report.Rptware_Nhapxuatton_mail(row_kho["Id_Cuahang_Ban"], ngay_batdau, ngay_ketthuc, row_loai_Hang["Id_Loai_Hanghoa_Ban"]).ToDataSet();
            //        if (ds_hangton.Tables[0].Rows.Count > 0)
            //        {
            //            body3 += "\n" + row_loai_Hang["Ten_Loai_Hanghoa_Ban"] + "\n";                
            //            body3 += ConvertDataTableToHTML_Tonkho(ds_hangton.Tables[0]);
            //        }
            //    }
            //}
            //using (MailMessage mail = new MailMessage())
            //{
            //    mail.From = new MailAddress(emailFrom);
            //    //mail.To.Add("hoangnhan1907@gmail.com");
            //    mail.To.Add("ltdung@longthanhmekong.com");
            //    mail.Subject = subject3;
            //    mail.Body = body3;
            //    mail.IsBodyHtml = true;
            //    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            //    {
            //        smtp.Credentials = new NetworkCredential("info", password);
            //        smtp.EnableSsl = enableSSL;
            //        smtp.Send(mail);
            //    }
            //}

            rptWare_Xuatnhap_Hangton baocao_hangton = new rptWare_Xuatnhap_Hangton();
            baocao_hangton.sendMail();
        }

        public static string ConvertDataTableToHTML_Tonkho(DataTable dt)
        {
            //string html = "</br></br>" + ten_kho + "</br>";
            string html = "<table width='100%' border=1 >";
            //add header row
            html += "<tr align='center' height='30px' bgcolor='#CCC'>";
            for (int i = 0; i < dt.Columns.Count - 1; i++)
                html += "<td >" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";

            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr height='25px' align='center'>";
                for (int j = 0; j < dt.Columns.Count - 1; j++)
                {
                    if (j == 2)
                        html += "<td align='left' >" + dt.Rows[i][j].ToString() + "</td>";
                    else
                        if (j == 4)
                            html += "<td align='right' >" + dt.Rows[i][j].ToString() + "</td>";
                        else
                            html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                }
                html += "</tr>";
            }

            html += "<tr align='center' height='30px' bgcolor='#CCC'>";
            html += "<td colspan='4'> Tổng cộng";
            html += "</td>";
            html += "<td> ";
            html += String.Format("{0:n}", dt.Compute("sum(Soluong_Ton)", ""));
            html += "</td>";
            html += "</tr>";
            html += "</table></br></br>";
            return html;
        }

        public static string ConvertDataTableToHTML(DataTable dt)
        {
            string html = "<table width='100%' border=1 >";
            //add header row
            html += "<tr align='center' height='30px' bgcolor='#CCC'>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime ngay_thutien = DateTime.ParseExact(dt.Rows[i][3].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                TimeSpan time = DateTime.Now - ngay_thutien;
                int day = time.Days / 3;
                switch (day)
                {
                    case 0:
                        html += "<tr height='25px'>";
                        break;
                    case 1:
                        html += "<tr height='25px' bgcolor='#fcff00'>";
                        break;
                    case 2:
                        html += "<tr height='25px' bgcolor='#22ff75'>";
                        break;
                    default:
                        html += "<tr height='25px' bgcolor='#ff6c6c'>";
                        break;
                }
                //html += "<tr height='25px'>";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                }
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }

        public static string ConvertDataTableToHTML_dukien(DataTable dt)
        {
            string html = "<table width='100%' border=1 >";
            //add header row
            html += "<tr align='center' height='30px' bgcolor='#CCC'>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr>";
            //add rows
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    html += "<tr height='25px'>";
            //    for (int j = 0; j < dt.Columns.Count; j++)
            //    {
            //        html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
            //    }
            //    html += "</tr>";
            //}

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime ngay_dathang = DateTime.ParseExact(dt.Rows[i][3].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                TimeSpan time = DateTime.Now - ngay_dathang;
                int day = time.Days / 3;
                switch (day)
                {
                    case 0:
                        html += "<tr height='25px'>";
                        break;
                    case 1:
                        html += "<tr height='25px' bgcolor='#fcff00'>";
                        break;
                    case 2:
                        html += "<tr height='25px' bgcolor='#22ff75'>";
                        break;
                    default:
                        html += "<tr height='25px' bgcolor='#ff6c6c'>";
                        break;
                }
                //html += "<tr height='25px'>";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                }
                html += "</tr>";
            }
            html += "</table>";
            return html;
        }


    }

}
