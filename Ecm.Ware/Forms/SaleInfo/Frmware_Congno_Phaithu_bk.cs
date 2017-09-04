using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Congno_Phaithu_bk : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
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

        public Frmware_Congno_Phaithu_bk()
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
                DataTable dtb = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0];
                lookUpEdit_Khachhang.Properties.DataSource = dtb;
                lookUpEdit_Ten_Khachhang.Properties.DataSource = dtb;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        void DisplayInfo_Details()
        {
            //if (dtNgay_Chungtu_View.EditValue == null) return;
            ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Congno_Phaithu(dtNgay_Chungtu_View.DateTime, lookUpEdit_Ten_Khachhang.EditValue, lookUpEdit_Nhansu_Banhang.EditValue).ToDataSet();
            this.dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet.Tables[0];
            gridView_Chitiet.BestFitColumns();
            gridView_Chitiet.ExpandAllGroups();
        }

        private void Frmware_Hdbanhang_noVAT_Hhban_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
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

    }
}