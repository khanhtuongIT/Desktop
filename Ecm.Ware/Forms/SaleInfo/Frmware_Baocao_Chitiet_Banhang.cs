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
    public partial class Frmware_Baocao_Chitiet_Banhang : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.ReportService objReportService = new Ecm.WebReferences.Classes.ReportService();

        DataSet ds_Hdbanhang_Chitiet = new DataSet();
        DataSet ds_Khachhang;
        DataSet ds_Nhansu;
        DataSet ds_Donvitinh;

        object id_nhansu_current;
        //public DataRow[] _selectedRows;

        public Frmware_Baocao_Chitiet_Banhang()
        {
            InitializeComponent();
            //if (!System.IO.Directory.Exists(@"Resources\localdata"))
            //    System.IO.Directory.CreateDirectory(@"Resources\localdata");
            xtraTabControl_Main.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            lookUpEdit_Nhansu_Banhang.EditValue = Convert.ToInt64(id_nhansu_current);
            //DisplayInfo();
            barSystem.Visible = false;
            dtNgay_Chungtu_View.DateTime = DateTime.Now;
        }

        public override void DisplayInfo()
        {
            try
            {
                lookUpEditKhuvuc_View.Properties.DataSource = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current, false).ToDataSet().Tables[0];
                ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                //ds_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                ////ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();

                lookUpEdit_Nhansu_Banhang.Properties.DataSource = ds_Nhansu.Tables[0];
                //gridLookupEdit_Donvitinh.DataSource = ds_Donvitinh.Tables[0];

                DataSet ds_Role = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
                if (ds_Role.Tables[0].Rows.Count > 0 &&
                    "" + ds_Role.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
                {
                    lookUpEdit_Nhansu_Banhang.Properties.ReadOnly = false;
                }
                else
                {
                    lookUpEdit_Nhansu_Banhang.Properties.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        void DisplayInfo_Details()
        {
            if (dtNgay_Chungtu_View.EditValue == null) return;
            DateTime date_from = new DateTime(dtNgay_Chungtu_View.DateTime.Year, dtNgay_Chungtu_View.DateTime.Month, 1, 01, 00, 01);
            DateTime date_to = new DateTime(dtNgay_Chungtu_View.DateTime.Year, dtNgay_Chungtu_View.DateTime.Month, DateTime.DaysInMonth(dtNgay_Chungtu_View.DateTime.Year, dtNgay_Chungtu_View.DateTime.Month), 23, 59, 59);
            ds_Hdbanhang_Chitiet = objReportService.RptWare_Hdbanhang_ByLoaihanghoa(date_from, date_to, lookUpEdit_Doituong.EditValue, lookUpEdit_Nhansu_Banhang.EditValue, null).ToDataSet();
            this.dgware_Hdbanhang_Chitiet.DataSource = ds_Hdbanhang_Chitiet.Tables[0];
            gvHdbang_Chitiet.BestFitColumns();
            gvHdbang_Chitiet.ExpandAllGroups();
        }

        private void Frmware_Hdbanhang_noVAT_Hhban_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DisplayInfo_Details();
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lookUpEditKhuvuc_View_EditValueChanged(object sender, EventArgs e)
        {
            if ("" + lookUpEditKhuvuc_View.EditValue == "") return;
            lookUpEdit_Doituong.Properties.DataSource = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc_Id_Nhansu(lookUpEditKhuvuc_View.EditValue, id_nhansu_current).ToDataSet().Tables[0];
        }

        private void lookUpEdit_Doituong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_Doituong.EditValue = null;
        }

    }
}