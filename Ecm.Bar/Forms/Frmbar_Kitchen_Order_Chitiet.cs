using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.Bar.Forms
{
    public partial class Frmbar_Kitchen_Order_Chitiet : GoobizFrame.Windows.Forms.FormUpdateWithToolbar, GoobizFrame.Windows.Forms.IFormSystemOptions
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();
        DataSet dsKitchen_Order_Chitiet = new DataSet();
        DataSet dsPrinters = new DataSet();

        DataSet dsSys_Lognotify = null;
        DateTime dtlc_bar_table_order_chitiet;
        DateTime dtlc_bar_rent_checkin_table_hanghoa;
        DateTime dtlc_bar_table_order_chitiet_temp = DateTime.Now;
        DateTime dtlc_bar_rent_checkin_table_hanghoa_temp = DateTime.Now;

        public Frmbar_Kitchen_Order_Chitiet()
        {
            InitializeComponent();
            this.BarSystem.Visible = false;
            DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                txtPc_Code.Text = GoobizFrame.Windows.Public.HardwareInformation.GetLongProcessorId().ToString();
                txtPc_Name.Text = System.Windows.Forms.SystemInformation.ComputerName;
                lookUpEdit_Cuahang_Ban.EditValue = Convert.ToInt64(
                     GoobizFrame.Windows.MdiUtils.ThemeSettings.GetValue("HostConfiguration", "Location", "Id_Cuahang_Ban"));

                lookUpEdit_Cuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
                dsPrinters = objBarService.GetPrinter_From_Bar_Kitchen_Printer(txtPc_Code.Text).ToDataSet();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(FetchData2Print));
                t.Start();
                dgBar_Kitchen_Printer.RefreshDataSource();
            }
            catch (Exception ex)
            {
                // GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(),"");
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Warning,
                   ex.Message, ex.ToString());
            }
        }

        void FetchData2Print()
        {
            lock (this)
            {
                LoadData();
                try
                {
                    if (DateTime.Compare(dtlc_bar_table_order_chitiet, dtlc_bar_table_order_chitiet_temp) != 0
                        || DateTime.Compare(dtlc_bar_rent_checkin_table_hanghoa, dtlc_bar_rent_checkin_table_hanghoa_temp) != 0)
                    {
                        dsPrinters = objBarService.GetPrinter_From_Bar_Kitchen_Printer(txtPc_Code.Text).ToDataSet();
                        dsKitchen_Order_Chitiet = objBarService.FetchPrinter_Bar_Kitchen_Order_Chitiet(txtPc_Code.Text, lookUpEdit_Cuahang_Ban.EditValue).ToDataSet();
                        //dgBar_Kitchen_Printer.DataSource = dsKitchen_Order_Chitiet.Tables[0];                        
                        dtlc_bar_table_order_chitiet_temp = dtlc_bar_table_order_chitiet;
                        dtlc_bar_rent_checkin_table_hanghoa_temp = dtlc_bar_rent_checkin_table_hanghoa;

                        if (dsKitchen_Order_Chitiet.Tables[0].Rows.Count > 0)
                            foreach (DataRow drprinter in dsPrinters.Tables[0].Rows)
                            {
                                DataRow[] sdrKitchen_Order = dsKitchen_Order_Chitiet.Tables[0].Select(string.Format("Printer = '{0}'", drprinter["Printer"]));
                                if (sdrKitchen_Order.Length > 0)
                                {
                                    DataSets.DsBar_Kitchen_Order_Chitiet dsKitchen_Order = new Ecm.Bar.DataSets.DsBar_Kitchen_Order_Chitiet();
                                    Reports.RptBar_Kitchen_Order_Chitiet rptKitchen_Order = new Ecm.Bar.Reports.RptBar_Kitchen_Order_Chitiet();

                                    foreach (DataRow drKitchen_Order in sdrKitchen_Order)
                                        dsKitchen_Order.Tables[0].ImportRow(drKitchen_Order);
                                    rptKitchen_Order.DataSource = dsKitchen_Order;
                                    rptKitchen_Order.PrinterName = "" + drprinter["Printer"];

                                    var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptKitchen_Order);
                                    reportPrintTool.Print();
                                }
                            }
                    }
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status =
                       new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Warning, ex.Message, ex.ToString());
                }
            }
        }

        /// <summary>
        /// Truy xuat DateTime thay doi du lieu cuoi cung
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
        private DateTime GetLastChange_FrmLognotify(string table_name)
        {
            try
            {
                return Convert.ToDateTime(dsSys_Lognotify.Tables[0].Select(string.Format("Table_Name='{0}'", table_name))[0]["Last_Change"]);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new DateTime(2010, 01, 01);
            }
        }

        void LoadData()
        {
            try
            {
                if (!System.IO.Directory.Exists(@"Resources\localdata"))
                    System.IO.Directory.CreateDirectory(@"Resources\localdata");
                dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[BAR_TABLE_ORDER_CHITIET],[BAR_RENT_CHECKIN_TABLE_HANGHOA]").ToDataSet();

                dtlc_bar_table_order_chitiet = GetLastChange_FrmLognotify("BAR_TABLE_ORDER_CHITIET");
                dtlc_bar_rent_checkin_table_hanghoa = GetLastChange_FrmLognotify("BAR_RENT_CHECKIN_TABLE_HANGHOA");
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}