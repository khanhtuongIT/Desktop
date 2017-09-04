using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Hanghoa_Ban_Dialog :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        DataSet dsWare_Dm_Nhom_Hanghoa_Ban;
        DataSet dsDm_Donvitinh;
        DataSet dsWare_Dm_Loai_Hanghoa_Ban;
        public DataRow[] SelectedRows = null;
        DataTable data_hanghoa = new DataTable();


        #region local data
        //bool Exists_Sys_Lognotify_Path = false;
        //DataSet dsSys_Lognotify = null;
        //string log_WARE_DM_HANGHOA_BAN = "init";
        //string log_WARE_HANGHOA_DINHGIA = "init";
        //string Sys_Lognotify_Path = @"Resources\localdata\SYS_LOGNOTIFY.xml";
        //string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\WARE_DM_HANGHOA_BAN.xml";
        //string xml_WARE_DG_HANGHOA_BAN = @"Resources\localdata\WARE_DG_HANGHOA_BAN.xml";

        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";
        string xml_WARE_DM_NHOM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Nhom_Hanghoa_Ban.xml";
        //string xml_WARE_DM_LOAI_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Loai_Hanghoa_Ban.xml";
        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_ware_dm_donvitinh;
        DateTime dtlc_ware_dm_nhom_hanghoa_ban;
        //DateTime dtlc_ware_dm_loai_hanghoa_ban;
        #endregion


        object _id_loai_hanghoa;
        public object Id_Loai_Hanghoa
        {
            get { return _id_loai_hanghoa; }
            set
            {
                _id_loai_hanghoa = value;
                //   DisplayInfo();
            }
        }


        object id_cuahang_ban;
        public object Id_Cuahang_Ban
        {
            get { return id_cuahang_ban; }
            set
            {
                id_cuahang_ban = value;
                //   DisplayInfo();
            }
        }

        object ngay_chungtu;
        public object Ngay_Chungtu
        {
            get { return ngay_chungtu; }
            set
            {
                ngay_chungtu = value;
                //DisplayInfo();
            }
        }

        public Frmware_Dm_Hanghoa_Ban_Dialog()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                //System.IO.Directory.Delete(@"Resources\localdata", true);
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            LoadMasterData();    
            DisplayInfo();
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

        void LoadMasterData()
        {
            #region code ole, not use
            /*
            string vlog_WARE_DM_HANGHOA_BAN = log_WARE_DM_HANGHOA_BAN;
            Exists_Sys_Lognotify_Path = System.IO.File.Exists(Sys_Lognotify_Path);

            if (Exists_Sys_Lognotify_Path)
            {
                #region Exists_Sys_Lognotify_Path
                //get last change at local
                dsSys_Lognotify = new DataSet();
                dsSys_Lognotify.ReadXml(Sys_Lognotify_Path);

                //write new log change from database --> write to local last change
                DataSet dsSys_Lognotify_db = objMasterService.GetAll_Sys_Lognotify();
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

                    log_WARE_DM_HANGHOA_BAN = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'").Length > 0)
                    ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'")[0]["Last_Change"] : "";

                    vlog_WARE_DM_HANGHOA_BAN = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'")[0]["Last_Change"] : "";

                }
                #endregion
            }
            else
            {
                #region ! Exists_Sys_Lognotify_Path
                //load last change
                dsSys_Lognotify = objMasterService.GetAll_Sys_Lognotify();
                dsSys_Lognotify.AcceptChanges();
                dsSys_Lognotify.WriteXml(Sys_Lognotify_Path, XmlWriteMode.WriteSchema);

                #endregion
            }
            */
            #endregion

            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables(
                  "[ware_dm_hanghoa_ban], [ware_dm_donvitinh], [ware_dm_nhom_hanghoa_ban]").ToDataSet();

            dtlc_ware_dm_nhom_hanghoa_ban   = GetLastChange_FrmLognotify("WARE_DM_NHOM_HANGHOA_BAN");
            dtlc_ware_dm_hanghoa_ban        = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");
            dtlc_ware_dm_donvitinh          = GetLastChange_FrmLognotify("WARE_DM_DONVITINH");

            //load data from local xml when last change at local differ from database
            if (DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN)) > 0
                || !System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN))
            {
                ds_Collection = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                ds_Collection.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (ds_Collection == null || ds_Collection.Tables.Count == 0)
            {
                ds_Collection = new DataSet();
                ds_Collection.ReadXml(xml_WARE_DM_HANGHOA_BAN);
            }
            if (DateTime.Compare(dtlc_ware_dm_nhom_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_NHOM_HANGHOA_BAN)) > 0
                 || !System.IO.File.Exists(xml_WARE_DM_NHOM_HANGHOA_BAN))
            {
                dsWare_Dm_Nhom_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet();
                dsWare_Dm_Nhom_Hanghoa_Ban.WriteXml(xml_WARE_DM_NHOM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (dsWare_Dm_Nhom_Hanghoa_Ban == null || dsWare_Dm_Nhom_Hanghoa_Ban.Tables.Count == 0)
            {
                dsWare_Dm_Nhom_Hanghoa_Ban = new DataSet();
                dsWare_Dm_Nhom_Hanghoa_Ban.ReadXml(xml_WARE_DM_NHOM_HANGHOA_BAN);
            }
            if (DateTime.Compare(dtlc_ware_dm_donvitinh, System.IO.File.GetLastWriteTime(xml_WARE_DM_DONVITINH)) > 0
              || !System.IO.File.Exists(xml_WARE_DM_DONVITINH))
            {
                dsDm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                dsDm_Donvitinh.WriteXml(xml_WARE_DM_DONVITINH, XmlWriteMode.WriteSchema);
            }
            else if (dsDm_Donvitinh == null || dsDm_Donvitinh.Tables.Count == 0)
            {
                dsDm_Donvitinh = new DataSet();
                dsDm_Donvitinh.ReadXml(xml_WARE_DM_DONVITINH);
            }
            //if (DateTime.Compare(dtlc_ware_dm_loai_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_LOAI_HANGHOA_BAN)) > 0
            //      || !System.IO.File.Exists(xml_WARE_DM_LOAI_HANGHOA_BAN))
            //{
            //    dsWare_Dm_Loai_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet();
            //    dsWare_Dm_Loai_Hanghoa_Ban.WriteXml(xml_WARE_DM_DONVITINH, XmlWriteMode.WriteSchema);
            //}
            //else if (dsWare_Dm_Loai_Hanghoa_Ban == null || dsWare_Dm_Loai_Hanghoa_Ban.Tables.Count == 0)
            //{
            //    dsWare_Dm_Loai_Hanghoa_Ban = new DataSet();
            //    dsWare_Dm_Loai_Hanghoa_Ban.ReadXml(xml_WARE_DM_LOAI_HANGHOA_BAN);
            //}
            dsWare_Dm_Loai_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet();
            gridLookUpEdit_Nhom_Hanghoa_Ban.DataSource  = dsWare_Dm_Nhom_Hanghoa_Ban.Tables[0];
            gridLookUp_Nhom_Hanghoa_Ban.DataSource = dsWare_Dm_Nhom_Hanghoa_Ban.Tables[0];

            ds_Collection.Tables[0].Columns.Add("Chon", typeof(bool));
            dgware_Dm_Hanghoa_Ban.DataSource = ds_Collection;
            dgware_Dm_Hanghoa_Ban.DataMember = ds_Collection.Tables[0].TableName;
            gridLookUp_Donvitinh.DataSource = dsDm_Donvitinh.Tables[0];
        }

        public override void DisplayInfo()
        {
            try
            {
                if ("" + _id_loai_hanghoa != "")
                {

                    data_hanghoa.Columns.Add("Id_Hanghoa_Ban");
                    data_hanghoa.Columns.Add("Ma_Hanghoa_Ban");
                    data_hanghoa.Columns.Add("Id_Menu");
                    data_hanghoa.Columns.Add("Ten_Hanghoa_Ban");
                    data_hanghoa.Columns.Add("Dongia_Ban");
                    data_hanghoa.Columns.Add("Id_Donvitinh");
                    data_hanghoa.Columns.Add("Id_Loai_Hanghoa_Ban");
                    data_hanghoa.Columns.Add("Size");
                    data_hanghoa.Columns.Add("Quycach");
                    data_hanghoa.Columns.Add("Barcode_Txt");
                    data_hanghoa.Columns.Add("Chon", typeof(bool));
                    foreach (DataRow dr in ds_Collection.Tables[0].Select("Id_Nhom_Hanghoa_Ban = " + _id_loai_hanghoa))
                    {
                        data_hanghoa.ImportRow(dr);
                    }
                    gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = data_hanghoa;
                    dgware_Dm_Hanghoa_Ban.DataSource = data_hanghoa;

                    DataTable data_danhmuc = new DataTable();
                    data_danhmuc.Columns.Add("Ma_Loai_Hanghoa_Ban");
                    data_danhmuc.Columns.Add("Ten_Loai_Hanghoa_Ban");
                    data_danhmuc.Columns.Add("Id_Nhom_Hanghoa_Ban");
                    data_danhmuc.Columns.Add("Id_Loai_Hanghoa_Ban");

                    foreach (DataRow dr in dsWare_Dm_Loai_Hanghoa_Ban.Tables[0].Select("Id_Nhom_Hanghoa_Ban = " + _id_loai_hanghoa))
                    {
                        data_danhmuc.ImportRow(dr);
                    }

                    dgware_Dm_Loai_Hanghoa_Ban.DataSource = data_danhmuc;
                }
                else
                {
                    gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = dsWare_Dm_Loai_Hanghoa_Ban.Tables[0];
                    dgware_Dm_Loai_Hanghoa_Ban.DataSource = dsWare_Dm_Loai_Hanghoa_Ban.Tables[0];

                }
              

                this.gridView1.BestFitColumns();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override bool PerformSaveChanges()
        {
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Ma_Hanghoa_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Ten_Hanghoa_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Id_Loai_Hanghoa_Ban"], "");
            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;
            try
            {
                dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
                ds_Collection.Tables[0].Columns["Ma_Hanghoa_Ban"].Unique = true;
                objMasterService.Update_Ware_Dm_Hanghoa_Ban_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { gridView1.Columns["Ma_Hanghoa_Ban"].Caption, gridView1.Columns["Ma_Hanghoa_Ban"].Caption });
                    return false;
                }
                //MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return true;
        }

        public override object PerformSelectOneObject()
        {
            dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
             if("" + _id_loai_hanghoa != "")
            {
                SelectedRows = data_hanghoa.Select("Chon = true");
            }
             else
            {
                SelectedRows = ds_Collection.Tables[0].Select("Chon = true");
            }
            this.Close();
            return base.PerformSelectOneObject();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Chon")          
                gridView1.GetDataRow(gridView1.FocusedRowHandle).AcceptChanges();            
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            object id2 = gridView2.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban");

            gridView1.Columns["Id_Loai_Hanghoa_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
               gridView1.Columns["Id_Loai_Hanghoa_Ban"],
               gridView2.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban"));
        }
    }
}

