using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

using System.Net;
using System.Net.Mail;

namespace Ecm.Ware.Forms.SaleInfo
{
    public partial class Frmware_Hanghoa_Tra : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.ReportService objReportService = new Ecm.WebReferences.Classes.ReportService();

        DataSet ds_Hanghoatra = new DataSet();
        DataSet ds_Hanghoatra_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Ban_after_Thongke = new DataSet();
        DataSet ds_Khachhang;
        DataSet ds_Nhansu;
        DataSet ds_Donvitinh;

        double thanhtien;
        object identity;
        object id_nhansu_current;
        object id_khuvuc;
        object id_cap;

        public DataRow[] _selectedRows;
        object Id_Khachhang = null;

        public Frmware_Hanghoa_Tra()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            xtraTabControl_Main.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            //DisplayInfo();
            item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            dtNgay_Chungtu_View.EditValue = objWareService.GetServerDateTime();
            #region Gán quyền thao tác trên form
            //btnAdd.Enabled = EnableAdd;
            item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            #endregion
        }

        public Frmware_Hanghoa_Tra(object id_Khachhang)
        {
            InitializeComponent();
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            xtraTabControl_Main.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            Id_Khachhang = id_Khachhang;
            //DisplayInfo();
            item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            dtNgay_Chungtu_View.EditValue = objWareService.GetServerDateTime();
            #region Gán quyền thao tác trên form
            //btnAdd.Enabled = EnableAdd;
            #endregion
        }

        void LoadMasterData()
        {
        }

        void Load_GridView()
        {
        }

        #region Event Override

        public override void DisplayInfo()
        {
            //Set lại trạng thái form là view
            FormState = GoobizFrame.Windows.Forms.FormState.View;
            try
            {
                this.lookUpEditKhuvuc_View.DataBindings.Clear();
                ResetText();
                LoadMasterData();
                Load_GridView();
                this.ChangeStatus(false);
                btnSend.Enabled = false;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        public override void ClearDataBindings()
        {
            this.txtId_Hdbanhang.DataBindings.Clear();
            this.gridLookupEdit_Chungtuthamchieu.DataBindings.Clear();
            this.txtSotien.DataBindings.Clear();
            this.dtNgay_Chungtuthamchieu.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Banhang.DataBindings.Clear();
            lookupEdit_MaKhachhang.DataBindings.Clear();
            
            txtLydo.DataBindings.Clear();
            chkDinhluong.DataBindings.Clear();
            txtHotro.DataBindings.Clear();
            txtCongno.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {   /*chua co id_chungtuthamchieu - ngay_thamchieu*/
                this.txtId_Hdbanhang.DataBindings.Add("EditValue", ds_Hanghoatra, ds_Hanghoatra.Tables[0].TableName + ".Id_Hdbanhang");
                this.gridLookupEdit_Chungtuthamchieu.DataBindings.Add("EditValue", ds_Hanghoatra, ds_Hanghoatra.Tables[0].TableName + ".?");
                this.txtSotien.DataBindings.Add("EditValue", ds_Hanghoatra, ds_Hanghoatra.Tables[0].TableName + ".Sotien");
                this.dtNgay_Chungtuthamchieu.DataBindings.Add("EditValue", ds_Hanghoatra, ds_Hanghoatra.Tables[0].TableName + ".?");
                this.lookUpEdit_Nhansu_Banhang.DataBindings.Add("EditValue", ds_Hanghoatra, ds_Hanghoatra.Tables[0].TableName + ".Id_Nhansu_Bh");
                lookupEdit_MaKhachhang.DataBindings.Add("EditValue", ds_Hanghoatra, ds_Hanghoatra.Tables[0].TableName + ".Id_Khachhang");
                txtLydo.DataBindings.Add("EditValue", ds_Hanghoatra, ds_Hanghoatra.Tables[0].TableName + ".Ghichu_Edit");
                chkDinhluong.DataBindings.Add("EditValue", ds_Hanghoatra, ds_Hanghoatra.Tables[0].TableName + ".Tinh_Dinhluong");
                txtHotro.DataBindings.Add("EditValue", ds_Hanghoatra, ds_Hanghoatra.Tables[0].TableName + ".Chiphi_Vanchuyen");
                txtCongno.DataBindings.Add("EditValue", ds_Hanghoatra, ds_Hanghoatra.Tables[0].TableName + ".Sotien_Congno");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override void ChangeStatus(bool editTable)
        {
                gvHanghoatra_Chitiet.OptionsBehavior.Editable = editTable;

        }

        public override void ResetText()
        {
            txtCongno.EditValue = null;
            this.txtId_Hdbanhang.EditValue = null;
            this.txtSotien.EditValue = null;
            lookupEdit_MaKhachhang.EditValue = null;
            lookUpEdit_Nhansu_Banhang.EditValue = null;
            dtNgay_Chungtuthamchieu.EditValue = null;
            gridLookupEdit_Chungtuthamchieu.EditValue = null;
           
            txtLydo.EditValue = null;
            chkDinhluong.EditValue = null;
            txtHotro.EditValue = null;
          
                  /* ----chua co ware cho grid hang hoa tra----*/
               // this.ds_Hanghoatra_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(-1).ToDataSet();
                this.dgware_Hanghoatra_Chitiet.DataSource = ds_Hanghoatra_Chitiet.Tables[0];
           
        }

        public object InsertObject()
        {
            return null;
        }

        public object UpdateObject()
        {
            return null;
        }

        public object DeleteObject()
        {
            return null;
        }

        public override bool PerformAdd()
        {
            return base.PerformAdd();
        }

        public override bool PerformEdit()
        {
            return base.PerformEdit();
        }

        public override bool PerformCancel()
        {
            return base.PerformCancel();
        }

        public override object PerformSelectOneObject()
        {
            return base.PerformSelectOneObject();
        }

        public override bool PerformSave()
        {
            return base.PerformSave();
        }

        public override bool PerformDelete()
        {
            return base.PerformDelete();
        }

        public override bool PerformPrintPreview()
        {
            return base.PerformPrintPreview();
        }

        #endregion

        #region Even

        #endregion


    }
}
