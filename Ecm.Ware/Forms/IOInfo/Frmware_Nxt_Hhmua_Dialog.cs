using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Nxt_Hhmua_Dialog :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet ds_Collection = new DataSet();
        public DataRow[] SelectedRows = null;
        object id_kho_hanghoa_mua;
        public object Id_Kho_Hanghoa_Mua
        {
            get { return id_kho_hanghoa_mua; }
            set
            {
                id_kho_hanghoa_mua = value;
            }
        }

        DateTime ngay_kiemke_hientai;
        public DateTime Ngay_Kiemke_Hientai
        {
            get { return ngay_kiemke_hientai; }
            set 
            { 
                ngay_kiemke_hientai = value;
                DisplayInfo();
            }
        }

        #region local data
        bool Exists_Sys_Lognotify_Path = false;
        DataSet dsSys_Lognotify = null;

        string log_WARE_DM_HANGHOA_MUA = "init";
        string log_WARE_HANGHOA_DINHGIA = "init";

        string Sys_Lognotify_Path = @"Resources\localdata\SYS_LOGNOTIFY.xml";
        string xml_WARE_DM_HANGHOA_MUA = @"Resources\localdata\WARE_DM_HANGHOA_MUA.xml";
        string xml_WARE_DG_HANGHOA_MUA = @"Resources\localdata\WARE_DG_HANGHOA_MUA.xml";

        #endregion  

        #region  Initialize

        public Frmware_Nxt_Hhmua_Dialog()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");

            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DisplayInfo();

        }
        void LoadMasterData()
        {
            string vlog_WARE_DM_HANGHOA_MUA = log_WARE_DM_HANGHOA_MUA;

            Exists_Sys_Lognotify_Path = System.IO.File.Exists(Sys_Lognotify_Path);

            if (Exists_Sys_Lognotify_Path)
            {
                #region Exists_Sys_Lognotify_Path
                //get last change at local
                dsSys_Lognotify = new DataSet();
                dsSys_Lognotify.ReadXml(Sys_Lognotify_Path);

                //write new log change from database --> write to local last change
                DataSet dsSys_Lognotify_db = objMasterService.GetAll_Sys_Lognotify().ToDataSet();
                DataRow[] sdr = dsSys_Lognotify_db.Tables[0].Select("Table_Name = 'Ware_Hanghoa_Dinhgia'");
                if (sdr != null && sdr.Length > 0)
                {
                    sdr[0].Delete();
                    dsSys_Lognotify_db.AcceptChanges();
                }
                bool haschange_atlast = false;
                foreach (DataRow dr in dsSys_Lognotify_db.Tables[0].Rows)
                {
                    sdr = dsSys_Lognotify.Tables[0].Select("Table_Name = '" + dr["table_name"] + "'");
                    if (sdr == null || sdr.Length == 0)
                        haschange_atlast = true;
                    else if ("" + sdr[0]["Last_Change"] != "" + dr["Last_Change"])
                        haschange_atlast = true;

                    if (haschange_atlast) break;
                }

                if (haschange_atlast)
                {
                    dsSys_Lognotify_db.WriteXml(Sys_Lognotify_Path, XmlWriteMode.WriteSchema);

                    log_WARE_DM_HANGHOA_MUA = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_MUA'").Length > 0)
                    ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_MUA'")[0]["Last_Change"] : "";

                    vlog_WARE_DM_HANGHOA_MUA = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_MUA'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_MUA'")[0]["Last_Change"] : "";
                }
                #endregion
            }
            else
            {
                #region ! Exists_Sys_Lognotify_Path
                //load last change
                dsSys_Lognotify = objMasterService.GetAll_Sys_Lognotify().ToDataSet();
                dsSys_Lognotify.AcceptChanges();
                dsSys_Lognotify.WriteXml(Sys_Lognotify_Path, XmlWriteMode.WriteSchema);

                #endregion
            }

            //load data from local xml when last change at local differ from database
            if (vlog_WARE_DM_HANGHOA_MUA != log_WARE_DM_HANGHOA_MUA
                || !System.IO.File.Exists(xml_WARE_DM_HANGHOA_MUA)
                )
            {
                ds_Collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Mua().ToDataSet();
                ds_Collection.WriteXml(xml_WARE_DM_HANGHOA_MUA, XmlWriteMode.WriteSchema);
            }
            else
            {
                if (ds_Collection == null || ds_Collection.Tables.Count == 0)
                {
                    ds_Collection = new DataSet();
                    ds_Collection.ReadXml(xml_WARE_DM_HANGHOA_MUA);
                }
            }

            dgware_Dm_Hanghoa_Mua.DataSource = ds_Collection;
            dgware_Dm_Hanghoa_Mua.DataMember = ds_Collection.Tables[0].TableName;
        }

#endregion

        #region override

        public override void DisplayInfo()
        {
            try
            {
                LoadMasterData();

                //Get data Ware_Dm_Loai_Hanghoa_Mua
                DataSet dsWare_Dm_Loai_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Mua().ToDataSet();
                gridLookUpEdit_Loai_Hanghoa_Mua.DataSource = dsWare_Dm_Loai_Hanghoa_Mua.Tables[0];
                dgware_Dm_Loai_Hanghoa_Mua.DataSource = dsWare_Dm_Loai_Hanghoa_Mua.Tables[0];

                //gridLookUpEdit_Nhom_Hanghoa_Mua
                DataSet dsWare_Dm_Nhom_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Mua().ToDataSet();
                gridLookUpEdit_Nhom_Hanghoa_Mua.DataSource = dsWare_Dm_Nhom_Hanghoa_Mua.Tables[0];
                gridLookUpEdit_Nhom_Hanghoa_Mua2.DataSource = dsWare_Dm_Nhom_Hanghoa_Mua.Tables[0];

                //Get data Ware_Dm_Hanghoa_Mua
                if (id_kho_hanghoa_mua != null)
                    ds_Collection = objWareService.Get_All_Ware_Nxt_Hhmua(objWareService.GetServerDateTime()
                    , (ngay_kiemke_hientai == null) ? objWareService.GetServerDateTime() : ngay_kiemke_hientai.AddMinutes(-1)
                    , id_kho_hanghoa_mua).ToDataSet();
                dgware_Dm_Hanghoa_Mua.DataSource = ds_Collection;
                dgware_Dm_Hanghoa_Mua.DataMember = ds_Collection.Tables[0].TableName;

                //lookUpEdit_Donvitinh
                DataSet dsDm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                gridLookUpEdit_Donvitinh.DataSource = dsDm_Donvitinh.Tables[0];

                ds_Collection.Tables[0].Columns.Add("Chon", typeof(bool));

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
 
            }

        }

        public override object PerformSelectOneObject()
        {
            this.DoClickEndEdit(dgware_Dm_Hanghoa_Mua); 
            SelectedRows = ds_Collection.Tables[0].Select("Chon = true");
            this.Close();
            return base.PerformSelectOneObject();
        }
        #endregion

        #region Even


        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridView1.Columns["Id_Loai_Hanghoa_Mua"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                gridView1.Columns["Id_Loai_Hanghoa_Mua"],
                gridView2.GetFocusedRowCellValue("Id_Loai_Hanghoa_Mua"));
        }
        #endregion

    }
}