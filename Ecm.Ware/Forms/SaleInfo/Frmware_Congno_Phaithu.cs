using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Congno_Phaithu : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.ReportService objReportService = new Ecm.WebReferences.Classes.ReportService();

        DataSet ds_Hdbanhang_Chitiet = new DataSet();
        //DataSet ds_Khachhang;
        DataSet ds_Nhansu;
        //DataSet ds_Donvitinh;

        object id_nhansu_current;
        //public DataRow[] _selectedRows;

        public Frmware_Congno_Phaithu()
        {
            InitializeComponent();
            xtraTabControl_Main.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            lookUpEdit_Nhansu_Banhang.EditValue = Convert.ToInt64(id_nhansu_current);
            dtNgay_Chungtu_View.EditValue = DateTime.Now;
            //DisplayInfo();
            barSystem.Visible = false;
        }

        public override void DisplayInfo()
        {
            try
            {
                //DataSet ds_collection = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
                //if (ds_collection.Tables[0].Rows.Count > 0 &&
                //    "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
                //{
                //    DataSet dsCuahang = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet();
                //    DataRow row = dsCuahang.Tables[0].NewRow();
                //    row["Id_Cuahang_Ban"] = -1;
                //    row["Ma_Cuahang_Ban"] = "All";
                //    row["Ten_Cuahang_Ban"] = "Tất cả";
                //    dsCuahang.Tables[0].Rows.Add(row);
                //    lookUpEditKhuvuc_View.Properties.DataSource = dsCuahang.Tables[0];
                //    lookUpEditKhuvuc_View.EditValue = Convert.ToInt64(-1);
                //}
                //else
                //{
                //    DataSet dsCuahang = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current).ToDataSet();
                //    lookUpEditKhuvuc_View.Properties.DataSource = dsCuahang.Tables[0];
                //}
                ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                //ds_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                ////ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                lookUpEdit_Nhansu_Banhang.Properties.DataSource = ds_Nhansu.Tables[0];

                DataTable dtb = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current, false).ToDataSet().Tables[0];
                lookUpEdit_TenKV.Properties.DataSource  = dtb;
                lookUpEditCuahang_Ban.Properties.DataSource = dtb;                
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        void DisplayInfo_Details()
        {
            try
            {
                //if (dtNgay_Chungtu_View.EditValue == null) return;
                DateTime ngay_bd = new DateTime(dtNgay_Chungtu_View.DateTime.Year, dtNgay_Chungtu_View.DateTime.Month, 1, 0, 0, 1);
                DateTime ngay_kt = new DateTime(dtNgay_Chungtu_View.DateTime.Year, dtNgay_Chungtu_View.DateTime.Month, 1, 23, 59, 59).AddMonths(1).AddDays(-1);
                ds_Hdbanhang_Chitiet = objReportService.Rpt_Congno_Chitiet_Khuvuc(ngay_bd, ngay_kt, lookUpEdit_Ten_Khachhang.EditValue, lookUpEditCuahang_Ban.EditValue).ToDataSet();
                this.dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet.Tables[0];
                gridView_Chitiet.BestFitColumns();
                gridView_Chitiet.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void Frmware_Hdbanhang_noVAT_Hhban_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (lookUpEdit_TenKV.EditValue == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Vui lòng chọn Khu vực.", "Thông tin...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DisplayInfo_Details();
        }

        private void lookUpEdit_Khachhang_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_Ten_Khachhang.EditValue = lookUpEdit_Khachhang.EditValue; 
        }

        private void lookUpEdit_Khachhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_Khachhang.EditValue = null;
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lookUpEditCuahang_Ban_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dtb = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc_Id_Nhansu(lookUpEditCuahang_Ban.EditValue, lookUpEdit_Nhansu_Banhang.EditValue).ToDataSet().Tables[0];
            lookUpEdit_Khachhang.Properties.DataSource = dtb;
            lookUpEdit_Ten_Khachhang.Properties.DataSource = dtb;
            
            lookUpEdit_TenKV.EditValue = lookUpEditCuahang_Ban.EditValue;
        }

        private void gridView_Chitiet_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            GridView view = sender as GridView;
            DataView dv = view.DataSource as DataView;
            if ((string)dv[e.ListSourceRow]["Diengiai"].ToString().Trim() == "")
            {
                e.Visible = false;
                e.Handled = true;
            }

        }

        private void gridView_Chitiet_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            //GridView currentView = sender as GridView;
            //System.Collections.Hashtable ht = currentView.GetGroupSummaryValues(0);
            //Text = "";
            //// Iterate through group summaries. 
            //foreach (System.Collections.DictionaryEntry entry in ht)
            //{
            //    DevExpress.XtraGrid.GridGroupSummaryItem sumItem = entry.Key as DevExpress.XtraGrid.GridGroupSummaryItem;
            //    object val = entry.Value;
            //    // Get the summry item's Tag property and summary value. 
            //    Text += sumItem.Tag.ToString() + ": " + val.ToString() + "\t";
            //}


            decimal sotien_no = Convert.ToDecimal("0" + bandedGridColumn3.SummaryItem.SummaryValue);
            e.TotalValue = sotien_no;
        }

    }
}