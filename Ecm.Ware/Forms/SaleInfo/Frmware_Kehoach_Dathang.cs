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
    public partial class Frmware_Kehoach_Dathang : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        //DataSet ds_Hdbanhang = new DataSet();
        DataSet ds_Hdbanhang_Chitiet = new DataSet();
        //DataSet ds_Hanghoa_Ban_after_Thongke = new DataSet();
        //DataSet ds_Khachhang;
        //DataSet ds_Nhansu;
        DataSet ds_Donvitinh;

        //double thanhtien;
        //object identity;
        object id_nhansu_current;
        //object id_khuvuc;
        //public DataRow[] _selectedRows;
        object Id_Khachhang = null;

        public Frmware_Kehoach_Dathang()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            xtraTabControl_Main.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            //DisplayInfo();

            dtNgay_Chungtu_View.EditValue = objWareService.GetServerDateTime();
            barSystem.Visible = false;
        }

        public Frmware_Kehoach_Dathang(object id_khachhang)
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            xtraTabControl_Main.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            Id_Khachhang = id_khachhang;
            //DisplayInfo();
            dtNgay_Chungtu_View.EditValue = objWareService.GetServerDateTime();
            #region Gán quyền thao tác trên form
            //btnAdd.Enabled = EnableAdd;
            #endregion
        }

        void LoadMasterData()
        {
            DataSet ds_collection = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            LookupEdit_Nhansu.Properties.DataSource = ds_collection.Tables[0];

            ds_collection = objMasterService.Get_All_Ware_Dm_Hanghoa().ToDataSet();
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_collection.Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = ds_collection.Tables[0];

            ds_collection = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
            if (ds_collection.Tables[0].Rows.Count > 0 &&
                "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
            {
                DataSet dsCuahang = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet();
                DataRow row = dsCuahang.Tables[0].NewRow();
                row["Id_Cuahang_Ban"] = -1;
                row["Ma_Cuahang_Ban"] = "All";
                row["Ten_Cuahang_Ban"] = "Tất cả";
                dsCuahang.Tables[0].Rows.Add(row);
                lookUpEditKhuvuc_View.Properties.DataSource = dsCuahang.Tables[0];
                lookUpEditKhuvuc_View.EditValue = Convert.ToInt64(-1);
                LookupEdit_Nhansu.Properties.ReadOnly = false;
            }
            else
            {
                DataSet dsCuahang = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current, false).ToDataSet();
                lookUpEditKhuvuc_View.Properties.DataSource = dsCuahang.Tables[0];

                LookupEdit_Nhansu.EditValue = Convert.ToInt64(id_nhansu_current);
                LookupEdit_Nhansu.Properties.ReadOnly = true;
            }
            //ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            ds_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
            //ds_Hanghoa_Ban_after_Thongke = objWareService.Get_All_Ware_Dm_Hanghoa_Ban_Dinhgia_After_Thongke(lookUpEditKhuvuc_View.EditValue).ToDataSet();
            //ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            gridLookupEdit_Donvitinh.DataSource = ds_Donvitinh.Tables[0];
        }

        public override void DisplayInfo()
        {
            //Set lại trạng thái form là view
            FormState = GoobizFrame.Windows.Forms.FormState.View;
            try
            {
                LoadMasterData();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        private void Frmware_Hdbanhang_noVAT_Hhban_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime date_from = new DateTime(dtNgay_Chungtu_View.DateTime.Year, dtNgay_Chungtu_View.DateTime.Month, 1);
            DateTime date_to = new DateTime(dtNgay_Chungtu_View.DateTime.Year, dtNgay_Chungtu_View.DateTime.Month, DateTime.DaysInMonth(dtNgay_Chungtu_View.DateTime.Year, dtNgay_Chungtu_View.DateTime.Month));
            ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_Dudoan_Dathang(date_from, date_to, lookUpEditKhuvuc_View.EditValue, LookupEdit_Nhansu.EditValue).ToDataSet();
            dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet.Tables[0];
            gvHdbang_Chitiet.BestFitColumns();
            gvHdbang_Chitiet.ExpandAllGroups();
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}