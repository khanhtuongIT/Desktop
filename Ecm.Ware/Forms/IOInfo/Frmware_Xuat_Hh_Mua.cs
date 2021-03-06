using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Ware.Forms
{
    public partial class Frmware_Xuat_Hh_Mua : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {

        public WareService.WareService objWareService = new SunLine.Ware.WareService.WareService();
        public RexService.RexService objRexService = new SunLine.Ware.RexService.RexService();
        public MasterService.MasterService objMasterService = new SunLine.Ware.MasterService.MasterService();

        DataSet ds_Ware_Xuat_Hh_Mua = new DataSet();
        DataSet ds_Ware_Xuat_Hh_Mua_Chitiet = new DataSet();
        DataSet dsRptware_Nxt_Hhmua;
        DataSet ds_Hanghoa_Mua;
        DataSet dsNhansu;

        object identity;

        #region local data
        bool Exists_Sys_Lognotify_Path = false;
        DataSet dsSys_Lognotify = null;

        string log_WARE_DM_HANGHOA_MUA = "init";
        string log_WARE_HANGHOA_DINHGIA = "init";
        string log_REX_NHANSU = "init";

        string Sys_Lognotify_Path = @"Resources\localdata\SYS_LOGNOTIFY.xml";
        string xml_WARE_DM_HANGHOA_MUA = @"Resources\localdata\WARE_DM_HANGHOA_MUA.xml";
        string xml_WARE_DG_HANGHOA_MUA = @"Resources\localdata\WARE_DG_HANGHOA_MUA.xml";
        string xml_REX_NHANSU = @"Resources\localdata\REX_NHANSU.xml";

        #endregion

        public Frmware_Xuat_Hh_Mua()
        {
            InitializeComponent();
            this.item_Query.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");

            //date mask
            dtNgay_Chungtu_Xuat.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Chungtu_Xuat.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            repositoryItemDateEdit_Ngay_Xuat_Hanghoa_Mua.Properties.Mask.UseMaskAsDisplayFormat = true;
            repositoryItemDateEdit_Ngay_Xuat_Hanghoa_Mua.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            //reset lookup edit as delete value
            lookUpEdit_Kho_Hanghoa_Mua_Nhap.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Kho_Hanghoa_Mua_Xuat.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Nhansu_Xuat.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Nhansu_Nhap.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);


            this.DisplayInfo();

        }
        void LoadMasterData()
        {
            string vlog_WARE_DM_HANGHOA_MUA = log_WARE_DM_HANGHOA_MUA;
            string vlog_REX_NHANSU = log_REX_NHANSU;

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

                    log_WARE_DM_HANGHOA_MUA = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_MUA'").Length > 0)
                    ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_MUA'")[0]["Last_Change"] : "";
                    log_REX_NHANSU = (dsSys_Lognotify.Tables[0].Select("Table_Name='REX_NHANSU'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='REX_NHANSU'")[0]["Last_Change"] : "";

                    vlog_WARE_DM_HANGHOA_MUA = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_MUA'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_MUA'")[0]["Last_Change"] : "";
                    vlog_REX_NHANSU = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='REX_NHANSU'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='REX_NHANSU'")[0]["Last_Change"] : "";
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

            //load data from local xml when last change at local differ from database

            if (vlog_WARE_DM_HANGHOA_MUA != log_WARE_DM_HANGHOA_MUA
                || !System.IO.File.Exists(xml_WARE_DM_HANGHOA_MUA)
                )
            {
                ds_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Hanghoa_Mua(); 
                ds_Hanghoa_Mua.WriteXml(xml_WARE_DM_HANGHOA_MUA, XmlWriteMode.WriteSchema);
            }
            else
            {
                if (ds_Hanghoa_Mua == null || ds_Hanghoa_Mua.Tables.Count == 0)
                {
                    ds_Hanghoa_Mua = new DataSet();
                    ds_Hanghoa_Mua.ReadXml(xml_WARE_DM_HANGHOA_MUA);
                }
            }
            if (vlog_REX_NHANSU != log_REX_NHANSU || !System.IO.File.Exists(xml_REX_NHANSU))
            {
                dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection();
                dsNhansu.WriteXml(xml_REX_NHANSU, XmlWriteMode.WriteSchema);
            }
            else if (dsNhansu == null || dsNhansu.Tables.Count == 0)
            {
                dsNhansu = new DataSet();
                dsNhansu.ReadXml(xml_REX_NHANSU);
            }

            //gridLookUpEdit_Hanghoa_Mua
            gridLookUpEdit_Hanghoa_Mua.DataSource = ds_Hanghoa_Mua.Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Mua.DataSource = ds_Hanghoa_Mua.Tables[0];

            //lookUpEdit_Nhansu_Kk
            lookUpEdit_Nhansu_Nhap.Properties.DataSource = dsNhansu.Tables[0];
            lookUpEdit_Nhansu_Xuat.Properties.DataSource = dsNhansu.Tables[0];
            gridLookUpEdit_Nhansu_Xuat.DataSource = dsNhansu.Tables[0];
        }


        public override void DisplayInfo()
        {
            try
            {
                LoadMasterData();

                //Get data Ware_Dm_Kho_Hanghoa_Mua
                DataSet dsKho_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_Mua();
                lookUpEdit_Kho_Hanghoa_Mua_Nhap.Properties.DataSource = dsKho_Hanghoa_Mua.Tables[0];
                lookUpEdit_Kho_Hanghoa_Mua_Xuat.Properties.DataSource = dsKho_Hanghoa_Mua.Tables[0];
                gridLookUpEdit_Kho_Hanghoa_Mua_Xuat.DataSource = dsKho_Hanghoa_Mua.Tables[0];

                //Get data Ware_Dm_Donvitinh
                gridLookUpEdit_Donvitinh.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().Tables[0];

                //Get data Ware_Nhap_Hh_Mua
                ds_Ware_Xuat_Hh_Mua = objWareService.Get_All_Ware_Xuat_Hh_Mua();
                dgware_Xuat_Hanghoa_Mua.DataSource = ds_Ware_Xuat_Hh_Mua;
                dgware_Xuat_Hanghoa_Mua.DataMember = ds_Ware_Xuat_Hh_Mua.Tables[0].TableName;

                this.DataBindingControl();

                this.ChangeStatus(false);

                this.gridView1.BestFitColumns();


                DisplayInfo2();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                ////GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }

        }

        void ClearDataBindings()
        {
            this.txtId_Xuat_Hh_Mua.DataBindings.Clear();
            this.txtSochungtu.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.dtNgay_Chungtu_Xuat.DataBindings.Clear();

            this.lookUpEdit_Kho_Hanghoa_Mua_Nhap.DataBindings.Clear();
            this.lookUpEdit_Kho_Hanghoa_Mua_Xuat.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Nhap.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Xuat.DataBindings.Clear();
        }
        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Xuat_Hh_Mua.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Mua, ds_Ware_Xuat_Hh_Mua.Tables[0].TableName + ".Id_Xuat_Hh_Mua");
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Mua, ds_Ware_Xuat_Hh_Mua.Tables[0].TableName + ".Sochungtu");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Mua, ds_Ware_Xuat_Hh_Mua.Tables[0].TableName + ".Ghichu");
                this.dtNgay_Chungtu_Xuat.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Mua, ds_Ware_Xuat_Hh_Mua.Tables[0].TableName + ".Ngay_Chungtu_Xuat");

                this.lookUpEdit_Kho_Hanghoa_Mua_Nhap.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Mua, ds_Ware_Xuat_Hh_Mua.Tables[0].TableName + ".Id_Kho_Hanghoa_Mua_Nhap");
                this.lookUpEdit_Kho_Hanghoa_Mua_Xuat.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Mua, ds_Ware_Xuat_Hh_Mua.Tables[0].TableName + ".Id_Kho_Hanghoa_Mua_Xuat");
                this.lookUpEdit_Nhansu_Nhap.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Mua, ds_Ware_Xuat_Hh_Mua.Tables[0].TableName + ".Id_Nhansu_Nhap");
                this.lookUpEdit_Nhansu_Xuat.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Mua, ds_Ware_Xuat_Hh_Mua.Tables[0].TableName + ".Id_Nhansu_Xuat");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

                ////GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public void ChangeStatus(bool editTable)
        {
            this.dgware_Xuat_Hanghoa_Mua.Enabled = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;

            this.lookUpEdit_Nhansu_Nhap.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Nhansu_Xuat.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Kho_Hanghoa_Mua_Nhap.Properties.ReadOnly = !editTable;
            //this.lookUpEdit_Kho_Hanghoa_Mua_Xuat.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Kho_Hanghoa_Mua_Xuat.Enabled = editTable;

            this.chkPrint_Save.Visible = editTable;

            this.dgware_Xuat_Hanghoa_Mua_Chitiet.EmbeddedNavigator.Enabled = editTable;
            this.gridView5.OptionsBehavior.Editable = editTable;
        }

        public void ResetText()
        {
            this.txtId_Xuat_Hh_Mua.EditValue = "";
            this.txtSochungtu.EditValue = "";
            this.txtGhichu.EditValue = "";
            this.lookUpEdit_Kho_Hanghoa_Mua_Nhap.EditValue = "";
            this.lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue = "";
            this.lookUpEdit_Nhansu_Nhap.EditValue = "";

            this.ds_Ware_Xuat_Hh_Mua_Chitiet = objWareService.Get_All_Ware_Xuat_Hh_Mua_Chitiet_By_Xuat_Hh_Mua(0);
            this.dgware_Xuat_Hanghoa_Mua_Chitiet.DataSource = ds_Ware_Xuat_Hh_Mua_Chitiet.Tables[0];
        }

        void DisplayInfo2()
        {
            try
            {
                identity = gridView1.GetFocusedRowCellValue("Id_Xuat_Hh_Mua");
                this.ds_Ware_Xuat_Hh_Mua_Chitiet = objWareService.Get_All_Ware_Xuat_Hh_Mua_Chitiet_By_Xuat_Hh_Mua(identity);
                this.dgware_Xuat_Hanghoa_Mua_Chitiet.DataSource = ds_Ware_Xuat_Hh_Mua_Chitiet;
                this.dgware_Xuat_Hanghoa_Mua_Chitiet.DataMember = ds_Ware_Xuat_Hh_Mua_Chitiet.Tables[0].TableName;
            }
            catch { }
        }

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                ////Kiem tra so luong ton
                if (e.Column.FieldName == "Soluong"
                    && "" + gridView5.GetFocusedRowCellValue("Soluong") != ""
                    && "" + gridView5.GetFocusedRowCellValue("Id_Hanghoa_Mua") != "")
                {
                    if (gridView5.GetFocusedRowCellValue("Id_Hanghoa_Mua") == null)
                    {
                        gridView5.CancelUpdateCurrentRow();
                        return;
                    }

                    if (Convert.ToInt32(gridView5.GetFocusedRowCellValue("Soluong")) <= 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("QUANLATY_NOT_AVAILABLE", new string[] { });
                        gridView5.CancelUpdateCurrentRow();
                        return;
                    }

                    DataRow[] sr_hh_nxt_ton = dsRptware_Nxt_Hhmua.Tables[0].Select("Id_Hanghoa_Mua = " + gridView5.GetFocusedRowCellValue("Id_Hanghoa_Mua")
                                + " and Soluong_Ton >= " + gridView5.GetFocusedRowCellValue("Soluong"));
                    if (sr_hh_nxt_ton == null || sr_hh_nxt_ton.Length == 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("QUANLATY_NOT_AVAILABLE", new string[] { });
                        gridView5.CancelUpdateCurrentRow();           
                        return;
                    }
                    else
                        gridView5.SetFocusedRowCellValue(gridView5.Columns["Barcode_Txt"], sr_hh_nxt_ton[0]["Barcode_Txt"]);
                }

                if (e.Column.FieldName == "Soluong" || e.Column.FieldName == "Dongia")
                {
                    if ("" + gridView5.GetFocusedRowCellValue("Soluong") != ""
                        && "" + gridView5.GetFocusedRowCellValue("Dongia") != "")
                        gridView5.SetFocusedRowCellValue(gridView5.Columns["Thanhtien"], Convert.ToDecimal(gridView5.GetFocusedRowCellValue("Soluong"))
                                                                     * Convert.ToDecimal(gridView5.GetFocusedRowCellValue("Dongia")));
                }
                else if (e.Column.FieldName == "Id_Hanghoa_Mua")
                {
                    if (gridLookUpEdit_Hanghoa_Mua.GetDisplayValueByKeyValue(e.Value) == null)
                        return;
                    DataRow[] dtr = ds_Hanghoa_Mua.Tables[0].Select("Id_Hanghoa_Mua = " + gridView5.GetFocusedRowCellValue("Id_Hanghoa_Mua"));
                    if (dtr == null || dtr.Length == 0)
                        return;
                    gridView5.SetFocusedRowCellValue(gridView5.Columns["Id_Donvitinh"], dtr[0]["Id_Donvitinh"]);
                    gridView5.SetFocusedRowCellValue(gridView5.Columns["Dongia"], dtr[0]["Dongia_Ban"]);

                    DataRow[] dtr_HhBan = dsRptware_Nxt_Hhmua.Tables[0].Select("Id_Hanghoa_Mua = " + gridView5.GetFocusedRowCellValue("Id_Hanghoa_Mua"));
                    if (dtr_HhBan.Length > 0)
                    {
                        gridView5.SetFocusedRowCellValue(gridView5.Columns["Soluong"], dtr_HhBan[0]["Soluong_Ton"]);
                    }
                    else
                        gridView5.SetFocusedRowCellValue(gridView5.Columns["Soluong"], 0);
                    //gridView5.SetFocusedRowCellValue(gridView5.Columns["Id_Donvitinh"]
                    //    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);

                    //gridView5.SetFocusedRowCellValue(gridView5.Columns["Barcode_Txt"]
                    //    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Barcode_Txt"]);
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message);
                gridView5.CancelUpdateCurrentRow();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                DisplayInfo2();
            }
        }


        #region Event Override
        public object InsertObject()
        {

            if (ds_Ware_Xuat_Hh_Mua_Chitiet.Tables[0].Rows.Count == 0)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa có hàng hóa, nhập lại thông tin hàng hóa");
                return false;
            }
            else
            {
                try
                {
                    WareService.Ware_Xuat_Hh_Mua objWare_Xuat_Hh_Mua = new SunLine.Ware.WareService.Ware_Xuat_Hh_Mua();
                    objWare_Xuat_Hh_Mua.Id_Xuat_Hh_Mua = -1;
                    objWare_Xuat_Hh_Mua.Sochungtu = txtSochungtu.EditValue;
                    objWare_Xuat_Hh_Mua.Ghichu = txtGhichu.EditValue;

                    objWare_Xuat_Hh_Mua.Ngay_Chungtu_Xuat = dtNgay_Chungtu_Xuat.EditValue;
                    if ("" + lookUpEdit_Kho_Hanghoa_Mua_Nhap.EditValue != "")
                        objWare_Xuat_Hh_Mua.Id_Kho_Hanghoa_Mua_Nhap = lookUpEdit_Kho_Hanghoa_Mua_Nhap.EditValue;
                    if ("" + lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue != "")
                        objWare_Xuat_Hh_Mua.Id_Kho_Hanghoa_Mua_Xuat = lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue;

                    if ("" + lookUpEdit_Nhansu_Nhap.EditValue != "")
                        objWare_Xuat_Hh_Mua.Id_Nhansu_Nhap = lookUpEdit_Nhansu_Nhap.EditValue;
                    if ("" + lookUpEdit_Nhansu_Xuat.EditValue != "")
                        objWare_Xuat_Hh_Mua.Id_Nhansu_Xuat = lookUpEdit_Nhansu_Xuat.EditValue;

                    identity = objWareService.Insert_Ware_Xuat_Hh_Mua(objWare_Xuat_Hh_Mua);
                    dgware_Xuat_Hanghoa_Mua_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();

                    if (identity != null)
                    {
                        foreach (DataRow dr in ds_Ware_Xuat_Hh_Mua_Chitiet.Tables[0].Rows)
                        {
                            dr["Id_Xuat_Hh_Mua"] = identity;
                        }
                        //update nhap_hh_mua_chitiet
                        objWareService.Update_Ware_Xuat_Hh_Mua_Chitiet_Collection(ds_Ware_Xuat_Hh_Mua_Chitiet);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return false;
                }
            }
        }

        public object UpdateObject()
        {
            try
            {
                WareService.Ware_Xuat_Hh_Mua objWare_Xuat_Hh_Mua = new SunLine.Ware.WareService.Ware_Xuat_Hh_Mua();
                objWare_Xuat_Hh_Mua.Id_Xuat_Hh_Mua = identity;
                objWare_Xuat_Hh_Mua.Sochungtu = txtSochungtu.EditValue;
                objWare_Xuat_Hh_Mua.Ghichu = txtGhichu.EditValue;

                objWare_Xuat_Hh_Mua.Ngay_Chungtu_Xuat = dtNgay_Chungtu_Xuat.EditValue;

                if ("" + lookUpEdit_Kho_Hanghoa_Mua_Nhap.EditValue != "")
                    objWare_Xuat_Hh_Mua.Id_Kho_Hanghoa_Mua_Nhap = lookUpEdit_Kho_Hanghoa_Mua_Nhap.EditValue;
                if ("" + lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue != "")
                    objWare_Xuat_Hh_Mua.Id_Kho_Hanghoa_Mua_Xuat = lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue;

                if ("" + lookUpEdit_Nhansu_Nhap.EditValue != "")
                    objWare_Xuat_Hh_Mua.Id_Nhansu_Nhap = lookUpEdit_Nhansu_Nhap.EditValue;
                if ("" + lookUpEdit_Nhansu_Xuat.EditValue != "")
                    objWare_Xuat_Hh_Mua.Id_Nhansu_Xuat = lookUpEdit_Nhansu_Xuat.EditValue;

                //update nhap_hh_mua
                objWareService.Update_Ware_Xuat_Hh_Mua(objWare_Xuat_Hh_Mua);

                //update nhap_hh_mua_chitiet
                dgware_Xuat_Hanghoa_Mua_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                foreach (DataRow dr in ds_Ware_Xuat_Hh_Mua_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Xuat_Hh_Mua"] = identity;
                }
                //ds_Donmuahang_Chitiet.RejectChanges();
                objWareService.Update_Ware_Xuat_Hh_Mua_Chitiet_Collection(ds_Ware_Xuat_Hh_Mua_Chitiet);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public object DeleteObject()
        {
            WareService.Ware_Xuat_Hh_Mua objWare_Xuat_Hh_Mua = new SunLine.Ware.WareService.Ware_Xuat_Hh_Mua();
            objWare_Xuat_Hh_Mua.Id_Xuat_Hh_Mua = gridView1.GetFocusedRowCellValue("Id_Xuat_Hh_Mua");

            return objWareService.Delete_Ware_Xuat_Hh_Mua(objWare_Xuat_Hh_Mua);
        }

        public override bool PerformAdd()
        {
            dtNgay_Chungtu_Xuat.EditValue = DateTime.Now;
            //Kiểm tra nếu nhân viên login không tồn tại trong kho hàng hóa mua thì access denied.
            lookUpEdit_Nhansu_Xuat.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            DataSet dsKho_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_MuaBy_Id_Nhansu(lookUpEdit_Nhansu_Xuat.EditValue);
            if (dsKho_Hanghoa_Mua.Tables[0].Rows.Count > 0)
                lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue = dsKho_Hanghoa_Mua.Tables[0].Rows[0]["Id_Kho_Hanghoa_Mua"];
            else
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                lookUpEdit_Nhansu_Xuat.EditValue = null;
                return false;
            }

            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            lookUpEdit_Nhansu_Xuat.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            lookUpEdit_Nhansu_Xuat.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_MuaBy_Id_Nhansu(
                lookUpEdit_Nhansu_Xuat.EditValue).Tables[0].Rows[0]["Id_Kho_Hanghoa_Mua"];
            txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_xuat_hh_mua", "Sochungtu", lookUpEdit_Kho_Hanghoa_Mua_Xuat.GetColumnValue("Ma_Kho_Hanghoa_Mua"));

            //get ds hang hoa ton trog ngay
            DateTime ngay_chungtu = dtNgay_Chungtu_Xuat.DateTime;
            dsRptware_Nxt_Hhmua = objWareService.Get_All_Ware_Nxt_Hhmua(new DateTime(ngay_chungtu.Year, ngay_chungtu.Month, ngay_chungtu.Day, 0, 0, 0)
                , new DateTime(ngay_chungtu.Year, ngay_chungtu.Month, ngay_chungtu.Day, 23, 0, 0)
                , lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue);
            gridLookUpEdit_Hanghoa_Mua.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue,
                                                                dtNgay_Chungtu_Xuat.EditValue).Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Mua.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue,
                                                                                            dtNgay_Chungtu_Xuat.EditValue).Tables[0];
            return true;
        }

        public override bool PerformEdit()
        {
            if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Xuat.EditValue))
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                return false;
            }

            //get ds hang hoa ton trog ngay
            DateTime ngay_chungtu = dtNgay_Chungtu_Xuat.DateTime;
            dsRptware_Nxt_Hhmua = objWareService.Get_All_Ware_Nxt_Hhmua(new DateTime(ngay_chungtu.Year, ngay_chungtu.Month, ngay_chungtu.Day, 0, 0, 0)
                , new DateTime(ngay_chungtu.Year, ngay_chungtu.Month, ngay_chungtu.Day, 23, 0, 0)
                , lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue);

            this.ChangeStatus(true);
            lookUpEdit_Kho_Hanghoa_Mua_Xuat.Enabled = false;
            gridLookUpEdit_Hanghoa_Mua.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue,
                                                                dtNgay_Chungtu_Xuat.EditValue).Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Mua.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue,
                                                                                            dtNgay_Chungtu_Xuat.EditValue).Tables[0];

            return true;
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;

                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(txtSochungtu, lblSochungtu.Text);
                hashtableControls.Add(lookUpEdit_Kho_Hanghoa_Mua_Xuat, lblId_Kho_Hanghoa_Mua_Xuat.Text);
                hashtableControls.Add(lookUpEdit_Nhansu_Xuat, lblId_Nhansu_Xuat.Text);               

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                dgware_Xuat_Hanghoa_Mua_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                if (gridView5.GetFocusedRowCellValue("Soluong").ToString() == "")
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng không được để rỗng, nhập lại số lượng");
                    return false;
                }

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Chungtu_Xuat, null))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Chungtu_Xuat, null)) //dtNgay_Chungtu_Nhap))
                        return false;
                    success = (bool)this.UpdateObject();
                }

                if (success)
                {
                    if (chkPrint_Save.Checked == true)
                        PerformPrintPreview();
                    this.DisplayInfo();

                }
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
                if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Xuat.EditValue))
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }

            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Xuat_Hh_Mua"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Xuat_Hh_Mua")   }) == DialogResult.Yes)
            {
                try
                {
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            WareService.Ware_Xuat_Hh_Mua ware_Xuat_Hh_Mua = new SunLine.Ware.WareService.Ware_Xuat_Hh_Mua();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Ware_Xuat_Hh_Mua.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Xuat_Hh_Mua.Id_Xuat_Hh_Mua = dr["Id_Xuat_Hh_Mua"];
                    ware_Xuat_Hh_Mua.Sochungtu = dr["Sochungtu"];
                    ware_Xuat_Hh_Mua.Ngay_Chungtu_Xuat = dr["Ngay_Chungtu_Xuat"];
                    ware_Xuat_Hh_Mua.Id_Kho_Hanghoa_Mua_Xuat = dr["Id_Kho_Hanghoa_Mua_Xuat"];
                    ware_Xuat_Hh_Mua.Id_Nhansu_Xuat = dr["Id_Nhansu_Xuat"];
                    ware_Xuat_Hh_Mua.Ghichu = dr["Ghichu"];
                }
                this.Dispose();
                this.Close();
                return ware_Xuat_Hh_Mua;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }

        public override bool PerformPrintPreview()
        {
            DataSets.DsXuat_Vattu dsWare_Xuat_Vattu = new SunLine.Ware.DataSets.DsXuat_Vattu();
            Reports.rptXuat_Vattu rptXuat_Vattu = new Reports.rptXuat_Vattu();
            GoobizFrame.Windows.Forms.FormReportWithHeader objFormReport = new GoobizFrame.Windows.Forms.FormReportWithHeader();
            objFormReport.Report = rptXuat_Vattu;
            rptXuat_Vattu.DataSource = dsWare_Xuat_Vattu;

            //Ware_Xuat_Vattu
            DataRow rWare_Xuat_Vattu = dsWare_Xuat_Vattu.Tables["ware_xuat_hh_mua"].NewRow();
            rWare_Xuat_Vattu["sochungtu"] = txtSochungtu.Text;
            rWare_Xuat_Vattu["ngay_chungtu_xuat"] = dtNgay_Chungtu_Xuat.EditValue;
            rWare_Xuat_Vattu["hoten_nhansu_xuat"] = lookUpEdit_Nhansu_Xuat.Text;
            rWare_Xuat_Vattu["hoten_nhansu_nhap"] = lookUpEdit_Nhansu_Nhap.Text;
            rWare_Xuat_Vattu["ten_kho_hanghoa_xuat"] = lookUpEdit_Kho_Hanghoa_Mua_Xuat.Text;
            rWare_Xuat_Vattu["ten_kho_hanghoa_nhap"] = lookUpEdit_Kho_Hanghoa_Mua_Nhap.Text;
            dsWare_Xuat_Vattu.Tables["ware_xuat_hh_mua"].Rows.Add(rWare_Xuat_Vattu);
            //Ware_Xuat_Vattu_Chitiet
            for (int i = 0; i < gridView5.RowCount; i++)
            {
                DataRow rWare_Xuat_Vattu_Chitiet = dsWare_Xuat_Vattu.Tables["ware_xuat_hh_mua_chitiet"].NewRow();
                rWare_Xuat_Vattu_Chitiet["id_xuat_hh_mua_chitiet"] = i + 1;
                rWare_Xuat_Vattu_Chitiet["id_xuat_hh_mua"] = gridView5.GetRowCellDisplayText(i, "Id_Xuat_Hh_Mua");
                rWare_Xuat_Vattu_Chitiet["ma_hanghoa"] = gridView5.GetRowCellDisplayText(i, gridColumn11);
                rWare_Xuat_Vattu_Chitiet["ten_hanghoa"] = gridView5.GetRowCellDisplayText(i, gridColumn14);
                rWare_Xuat_Vattu_Chitiet["ten_donvitinh"] = gridView5.GetRowCellDisplayText(i, "Id_Donvitinh");
                rWare_Xuat_Vattu_Chitiet["soluong"] = "0" + gridView5.GetRowCellDisplayText(i, "Soluong");
                dsWare_Xuat_Vattu.Tables["ware_xuat_hh_mua_chitiet"].Rows.Add(rWare_Xuat_Vattu_Chitiet);
            }
            dsWare_Xuat_Vattu.AcceptChanges();

            //rptXuat_Vattu.xrPictureBox1.Image = ERPMkg.Windows.MdiUtils.ThemeSettings.GetCompanyLogo();

            rptXuat_Vattu.CreateDocument();

            objFormReport.Text = this.Text + " [In]";
            objFormReport.printControl1.PrintingSystem = rptXuat_Vattu.PrintingSystem;
            objFormReport.MdiParent = this.MdiParent;
            objFormReport.Show();
            objFormReport.Activate();
            return true;
        }

        #endregion

        private void lookUpEdit_Kho_Hanghoa_Mua_Xuat_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                    txtSochungtu.EditValue = objWareService.GetNew_Sochungtu(
                        "ware_xuat_hh_mua"
                        , "Sochungtu"
                        , lookUpEdit_Kho_Hanghoa_Mua_Xuat.GetColumnValue("Ma_Kho_Hanghoa_Mua"));

               //get ds hang hoa ton trog ngay
                DateTime ngay_chungtu = dtNgay_Chungtu_Xuat.DateTime;

                dsRptware_Nxt_Hhmua = objWareService.Get_All_Ware_Nxt_Hhmua(new DateTime(ngay_chungtu.Year, ngay_chungtu.Month, ngay_chungtu.Day, 0, 0, 0)
                    , new DateTime(ngay_chungtu.Year, ngay_chungtu.Month, ngay_chungtu.Day, 23, 0, 0)
                    , lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue);
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.View)
                    return;

                gridLookUpEdit_Hanghoa_Mua.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue,
                                                                                dtNgay_Chungtu_Xuat.EditValue).Tables[0];
                gridLookUpEdit_Ma_Hanghoa_Mua.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue,
                                                                                                dtNgay_Chungtu_Xuat.EditValue).Tables[0];

            }
            catch { }
        }

        private void gridLookUpEdit_Hanghoa_Mua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Frmware_Nxt_Hhmua_Dialog frmware_Dm_Hanghoa_Mua_Dialog = new Frmware_Nxt_Hhmua_Dialog();
                frmware_Dm_Hanghoa_Mua_Dialog.Text = "Hàng hóa";
                GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Mua_Dialog);
                frmware_Dm_Hanghoa_Mua_Dialog.Id_Kho_Hanghoa_Mua = lookUpEdit_Kho_Hanghoa_Mua_Xuat.EditValue;
                frmware_Dm_Hanghoa_Mua_Dialog.Ngay_Kiemke_Hientai = dtNgay_Chungtu_Xuat.DateTime;
                frmware_Dm_Hanghoa_Mua_Dialog.ShowDialog();

                if (frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows != null
                    && frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows.Length > 0)
                {
                    int soluong_ton;
                    DataRow[] dtr = ds_Hanghoa_Mua.Tables[0].Select("Id_Hanghoa_Mua = " + frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[0]["Id_Hanghoa_Mua"]);

                    if (frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[0]["Soluong_Ton"].ToString() == "")
                        soluong_ton = Convert.ToInt32("0" + frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[0]["Soluong_Ton"]);
                    else
                        soluong_ton = Convert.ToInt32(frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[0]["Soluong_Ton"]);

                    if (soluong_ton > 0)
                    {                     
                        gridView5.SetFocusedRowCellValue(gridView5.Columns["Id_Hanghoa_Mua"]
                            , frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[0]["Id_Hanghoa_Mua"]);
                        gridView5.SetFocusedRowCellValue(gridView5.Columns["Id_Donvitinh"]
                            , frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[0]["Id_Donvitinh"]);
                        gridView5.SetFocusedRowCellValue(gridView5.Columns["Barcode_Txt"]
                            , frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[0]["Barcode_Txt"]);
                        gridView5.SetFocusedRowCellValue(gridView5.Columns["Soluong"]
                            , frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[0]["Soluong_Ton"]);

                        gridView5.SetFocusedRowCellValue(gridView5.Columns["Dongia_Ban"]
                            , dtr[0]["Dongia_Ban"]);
                        //gridView5.SetFocusedRowCellValue(gridView5.Columns["Thanhtien"],
                        //    Convert.ToDecimal(gridView5.GetFocusedRowCellValue("Soluong"))
                        //    * Convert.ToDecimal(gridView5.GetFocusedRowCellValue("Dongia")));
                    }

                    //gridLookUpEdit_Hanghoa_Mua.DataSource = frmware_Dm_Hanghoa_Mua_Dialog.Data.Tables[0];
                   
                    //object Id_Cuahang_Mua = gridView1.GetFocusedRowCellValue("Id_Cuahang_Mua");

                    if (frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows.Length > 1)
                    {
                        for (int i = 1; i < frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows.Length; i++)
                        {
                            DataRow nrow = ds_Ware_Xuat_Hh_Mua_Chitiet.Tables[0].NewRow();
                            //nrow["Id_Cuahang_Mua"] = Id_Cuahang_Mua;
                            nrow["Id_Hanghoa_Mua"] = frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[i]["Id_Hanghoa_Mua"];
                            nrow["Id_Donvitinh"] = frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[i]["Id_Donvitinh"];
                            nrow["Barcode_Txt"] = frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[i]["Barcode_Txt"];
                            nrow["Soluong"] = frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[i]["Soluong_Ton"];

                            dtr = ds_Hanghoa_Mua.Tables[0].Select("Id_Hanghoa_Mua = " + frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[i]["Id_Hanghoa_Mua"]);
                            nrow["Dongia"] = dtr[0]["Dongia_Ban"];

                            int soluong;
                            if (nrow["Soluong"].ToString() == "")
                                soluong = Convert.ToInt32("0" + nrow["Soluong"]);
                            else
                                soluong = Convert.ToInt32(nrow["Soluong"]);
                            if (soluong > 0)
                            {
                                nrow["Thanhtien"] = Convert.ToDecimal("0" + nrow["Soluong"]) + Convert.ToDecimal("0" + nrow["Dongia"]);
                                ds_Ware_Xuat_Hh_Mua_Chitiet.Tables[0].Rows.Add(nrow);
                            }
                        }
                    }
                }
            }
        }

        private void gridView5_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //Kiem tra so luong ton
            if (e.Column.FieldName == "Soluong"
                && "" + gridView5.GetFocusedRowCellValue("Soluong") != ""
                && "" + gridView5.GetFocusedRowCellValue("Id_Hanghoa_Mua") != "")
            {
                DataRow[] sr_hh_nxt_ton = dsRptware_Nxt_Hhmua.Tables[0].Select("Id_Hanghoa_Mua = " + gridView5.GetFocusedRowCellValue("Id_Hanghoa_Mua")
                            + " and Soluong_Ton >= " + gridView5.GetFocusedRowCellValue("Soluong"));
                if (sr_hh_nxt_ton == null || sr_hh_nxt_ton.Length == 0)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("QUANLATY_NOT_AVAILABLE", new string[] { });
                    gridView5.CancelUpdateCurrentRow();
                    return;
                }
                else
                    gridView5.SetFocusedRowCellValue(gridView5.Columns["Barcode_Txt"], sr_hh_nxt_ton[0]["Barcode_Txt"]);
            }
        }




    }
}

