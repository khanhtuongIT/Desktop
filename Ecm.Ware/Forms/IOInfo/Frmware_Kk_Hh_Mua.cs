using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Ware.Forms
{
    public partial class Frmware_Kiemke_Hanghoa_Mua : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public WareService.WareService objWareService = new SunLine.Ware.WareService.WareService();
        public RexService.RexService objRexService = new SunLine.Ware.RexService.RexService();
        public MasterService.MasterService objMasterService = new SunLine.Ware.MasterService.MasterService();

        DataSet ds_Kk_Hh_Mua = new DataSet();
        DataSet ds_Kk_Hh_Mua_Chitiet = new DataSet();
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
        public Frmware_Kiemke_Hanghoa_Mua()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");

            //date mask
            dtNgay_Kk.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Kk.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetLongDateTimeFormat();

            repositoryItemDateEdit_Ngay_Nhap_Hh_Mua.Properties.Mask.UseMaskAsDisplayFormat = true;
            repositoryItemDateEdit_Ngay_Nhap_Hh_Mua.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetLongDateTimeFormat();
            //reset lookup edit as delete value
            lookUpEdit_Kho_Hanghoa_Mua.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Nhansu_Kk.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);

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
            lookUpEdit_Nhansu_Kk.Properties.DataSource = dsNhansu.Tables[0];
            gridLookUpEdit_Nhansu_Kk.DataSource = dsNhansu.Tables[0];

        }
        public override void DisplayInfo()
        {
            try
            {
                LoadMasterData();

                //Get data Ware_Dm_Kho_Hanghoa_Mua
                DataSet dsKho_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_Mua();
                lookUpEdit_Kho_Hanghoa_Mua.Properties.DataSource = dsKho_Hanghoa_Mua.Tables[0];
                gridLookUpEdit_Kho_Hanghoa_Mua1.DataSource = dsKho_Hanghoa_Mua.Tables[0];


                //Get data Ware_Dm_Donvitinh
                gridLookUpEdit_Donvitinh.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().Tables[0];

                //Get data Ware_Kkp_Hh_Mua
                ds_Kk_Hh_Mua = objWareService.Get_All_Ware_Kk_Hh_Mua();
                dgware_Kk_Hh_Mua.DataSource = ds_Kk_Hh_Mua;
                dgware_Kk_Hh_Mua.DataMember = ds_Kk_Hh_Mua.Tables[0].TableName;

                this.DataBindingControl();

                this.ChangeStatus(false);

                this.gridView2.BestFitColumns();

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
            this.txtId_Kk_Hh_Mua.DataBindings.Clear();
            this.txtSochungtu.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.dtNgay_Kk.DataBindings.Clear();

            this.lookUpEdit_Kho_Hanghoa_Mua.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Kk.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Kk_Hh_Mua.DataBindings.Add("EditValue", ds_Kk_Hh_Mua, ds_Kk_Hh_Mua.Tables[0].TableName + ".Id_Kk_Hh_Mua");
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Kk_Hh_Mua, ds_Kk_Hh_Mua.Tables[0].TableName + ".Sochungtu");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Kk_Hh_Mua, ds_Kk_Hh_Mua.Tables[0].TableName + ".Ghichu");
                this.dtNgay_Kk.DataBindings.Add("EditValue", ds_Kk_Hh_Mua, ds_Kk_Hh_Mua.Tables[0].TableName + ".Ngay_Kk");

                this.lookUpEdit_Kho_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Kk_Hh_Mua, ds_Kk_Hh_Mua.Tables[0].TableName + ".Id_Kho_Hanghoa_Mua");
                this.lookUpEdit_Nhansu_Kk.DataBindings.Add("EditValue", ds_Kk_Hh_Mua, ds_Kk_Hh_Mua.Tables[0].TableName + ".Id_Nhansu_Kk");
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
            this.dgware_Kk_Hh_Mua.Enabled = !editTable;
            this.txtSochungtu.Properties.ReadOnly = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.dtNgay_Kk.Properties.ReadOnly = !editTable;

            this.lookUpEdit_Nhansu_Kk.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Kho_Hanghoa_Mua.Properties.ReadOnly = !editTable;

            this.dgware_Kk_Hh_Mua_Chitiet.EmbeddedNavigator.Enabled = editTable;
            this.gridView2.OptionsBehavior.Editable = editTable;
            this.chkPrint_Save.Enabled = editTable;
        }

        public void ResetText()
        {
            this.txtId_Kk_Hh_Mua.EditValue = "";
            this.txtSochungtu.EditValue = "";
            this.txtGhichu.EditValue = "";
            this.lookUpEdit_Kho_Hanghoa_Mua.EditValue = "";
            //this.lookUpEdit_Nguoi_Nhan_Hanghoa_Mua.EditValue = null;

            this.ds_Kk_Hh_Mua_Chitiet = objWareService.Get_All_Ware_Kk_Hh_Mua_Chitiet_By_Kk_Hh_Mua(0);
            this.dgware_Kk_Hh_Mua_Chitiet.DataSource = ds_Kk_Hh_Mua_Chitiet.Tables[0];
        }

        void DisplayInfo2()
        {
            try
            {
                identity = gridView1.GetFocusedRowCellValue("Id_Kk_Hh_Mua");

                this.ds_Kk_Hh_Mua_Chitiet = objWareService.Get_All_Ware_Kk_Hh_Mua_Chitiet_By_Kk_Hh_Mua(identity);
                this.dgware_Kk_Hh_Mua_Chitiet.DataSource = ds_Kk_Hh_Mua_Chitiet;
                this.dgware_Kk_Hh_Mua_Chitiet.DataMember = ds_Kk_Hh_Mua_Chitiet.Tables[0].TableName;

                gridView2.BestFitColumns();

                //neu chung tu da duoc xac nhan thi cho phep in
                if (Convert.ToInt64(gridView1.GetFocusedRowCellValue("Doc_Process_Status")) != 2)
                    this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                else
                    this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            }
            catch { }
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
            try
            {
                WareService.Ware_Kk_Hh_Mua objWare_Kk_Hh_Mua = new SunLine.Ware.WareService.Ware_Kk_Hh_Mua();
                objWare_Kk_Hh_Mua.Id_Kk_Hh_Mua = -1;
                objWare_Kk_Hh_Mua.Sochungtu = txtSochungtu.EditValue;
                objWare_Kk_Hh_Mua.Ghichu = txtGhichu.EditValue;
                objWare_Kk_Hh_Mua.Ngay_Kk = dtNgay_Kk.EditValue;

                if ("" + lookUpEdit_Kho_Hanghoa_Mua.EditValue != "")
                    objWare_Kk_Hh_Mua.Id_Kho_Hanghoa_Mua = lookUpEdit_Kho_Hanghoa_Mua.EditValue;
                if ("" + lookUpEdit_Nhansu_Kk.EditValue != "")
                    objWare_Kk_Hh_Mua.Id_Nhansu_Kk = lookUpEdit_Nhansu_Kk.EditValue;

                identity = objWareService.Insert_Ware_Kk_Hh_Mua(objWare_Kk_Hh_Mua);

                if (identity != null)
                {
                    dgware_Kk_Hh_Mua_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    foreach (DataRow dr in ds_Kk_Hh_Mua_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Kk_Hh_Mua"] = identity;
                    }
                    //update donmuahang_chitiet
                    objWareService.Update_Ware_Kk_Hh_Mua_Chitiet_Collection(ds_Kk_Hh_Mua_Chitiet);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                WareService.Ware_Kk_Hh_Mua objWare_Kk_Hh_Mua = new SunLine.Ware.WareService.Ware_Kk_Hh_Mua();
                objWare_Kk_Hh_Mua.Id_Kk_Hh_Mua = gridView1.GetFocusedRowCellValue("Id_Kk_Hh_Mua");
                objWare_Kk_Hh_Mua.Sochungtu = txtSochungtu.EditValue;
                objWare_Kk_Hh_Mua.Ghichu = txtGhichu.EditValue;
                objWare_Kk_Hh_Mua.Ngay_Kk = dtNgay_Kk.EditValue;

                if ("" + lookUpEdit_Kho_Hanghoa_Mua.EditValue != "")
                    objWare_Kk_Hh_Mua.Id_Kho_Hanghoa_Mua = lookUpEdit_Kho_Hanghoa_Mua.EditValue;
                if ("" + lookUpEdit_Nhansu_Kk.EditValue != "")
                    objWare_Kk_Hh_Mua.Id_Nhansu_Kk = lookUpEdit_Nhansu_Kk.EditValue;
                //update donmuahang
                objWareService.Update_Ware_Kk_Hh_Mua(objWare_Kk_Hh_Mua);

                //update donmuahang_chitiet
                dgware_Kk_Hh_Mua_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                foreach (DataRow dr in ds_Kk_Hh_Mua_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Kk_Hh_Mua"] = gridView1.GetFocusedRowCellValue("Id_Kk_Hh_Mua");
                }
                //ds_Donmuahang_Chitiet.RejectChanges();
                objWareService.Update_Ware_Kk_Hh_Mua_Chitiet_Collection(ds_Kk_Hh_Mua_Chitiet);

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
            WareService.Ware_Kk_Hh_Mua objWare_Kk_Hh_Mua = new SunLine.Ware.WareService.Ware_Kk_Hh_Mua();
            objWare_Kk_Hh_Mua.Id_Kk_Hh_Mua = gridView2.GetFocusedRowCellValue("Id_Kk_Hh_Mua");

            return objWareService.Delete_Ware_Kk_Hh_Mua(objWare_Kk_Hh_Mua);
        }

        public override bool PerformAdd()
        {
            dtNgay_Kk.EditValue = DateTime.Now;
            //Kiểm tra nếu nhân viên login không tồn tại trong kho hàng hóa mua thì access denied.
            lookUpEdit_Nhansu_Kk.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            DataSet ds_Kho_Hanghoa = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_MuaBy_Id_Nhansu(lookUpEdit_Nhansu_Kk.EditValue);
            if (ds_Kho_Hanghoa.Tables[0].Rows.Count > 0)
                lookUpEdit_Kho_Hanghoa_Mua.EditValue = ds_Kho_Hanghoa.Tables[0].Rows[0]["Id_Kho_Hanghoa_Mua"];
            else
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                lookUpEdit_Nhansu_Kk.EditValue = null;
                return false;
            }

            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            txtSochungtu.EditValue = objWareService.GetNew_Sochungtu(
                        "Ware_Kk_Hh_Mua"
                        , "sochungtu"
                        , lookUpEdit_Kho_Hanghoa_Mua.GetColumnValue("Ma_Kho_Hanghoa_Mua"));
            return true;
        }

        public override bool PerformEdit()
        {
            if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Kk.EditValue))
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                return false;
            }
            else
            {
                WareService.DocumentProcessStatus DocumentProcessStatus = new SunLine.Ware.WareService.DocumentProcessStatus();
                DocumentProcessStatus.Tablename = "Ware_Kk_Hh_Mua";
                DocumentProcessStatus.PK_Name = "Id_Kk_Hh_Mua";
                DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Kk_Hh_Mua");
                DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != SunLine.Ware.WareService.EDocumentProcessStatus.NewDoc)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                    return false;
                }
            }

            gridLookUpEdit_Hanghoa_Mua.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(lookUpEdit_Kho_Hanghoa_Mua.EditValue, dtNgay_Kk.EditValue).Tables[0];
            this.ChangeStatus(true);
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
                hashtableControls.Add(lookUpEdit_Kho_Hanghoa_Mua, lblId_Kho_Hanghoa_Mua.Text);
                hashtableControls.Add(lookUpEdit_Nhansu_Kk, lblNhansu_Kk.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = (bool)this.UpdateObject();
                }

                if (success)
                {
                    if (chkPrint_Save.Checked)
                        PerformPrintPreview();
                    chkPrint_Save.Checked = false;
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
                if (!GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Kk.EditValue))
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }
                else
                {
                    WareService.DocumentProcessStatus DocumentProcessStatus = new SunLine.Ware.WareService.DocumentProcessStatus();
                    DocumentProcessStatus.Tablename = "Ware_Kk_Hh_Mua";
                    DocumentProcessStatus.PK_Name = "Id_Kk_Hh_Mua";
                    DocumentProcessStatus.Identity = gridView2.GetFocusedRowCellValue("Id_Kk_Hh_Mua");
                    DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                    if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != SunLine.Ware.WareService.EDocumentProcessStatus.NewDoc)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                        return false;
                    }
                }

            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Kk_Hh_Mua"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Kk_Hh_Mua")   }) == DialogResult.Yes)
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
            WareService.Ware_Kk_Hh_Mua ware_Kk_Hh_Mua = new SunLine.Ware.WareService.Ware_Kk_Hh_Mua();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Kk_Hh_Mua.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Kk_Hh_Mua.Id_Kk_Hh_Mua = dr["Id_Kk_Hh_Mua"];
                    ware_Kk_Hh_Mua.Sochungtu = dr["Sochungtu"];
                    ware_Kk_Hh_Mua.Ngay_Kk = dr["Ngay_Kk"];
                    ware_Kk_Hh_Mua.Id_Kho_Hanghoa_Mua = dr["Ngay_Kk"];
                    ware_Kk_Hh_Mua.Id_Nhansu_Kk = dr["Id_Nhansu_Kk"];
                    ware_Kk_Hh_Mua.Ghichu = dr["Ghichu"];
                }
                this.Dispose();
                this.Close();
                return ware_Kk_Hh_Mua;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }

        public override bool PerformTest()
        {
            Frmware_ChangeDocStatus_Dialog objFrmware_ChangeDocStatus_Dialog = new Frmware_ChangeDocStatus_Dialog();
            objFrmware_ChangeDocStatus_Dialog.TableName = "Ware_Kk_Hh_Mua";
            objFrmware_ChangeDocStatus_Dialog.PK_Name = "Id_Kk_Hh_Mua";
            objFrmware_ChangeDocStatus_Dialog.Identity = gridView2.GetFocusedRowCellValue("Id_Kk_Hh_Mua");
            objFrmware_ChangeDocStatus_Dialog.Text = "Kiểm tra phiếu kiểm kê";
            objFrmware_ChangeDocStatus_Dialog.NEWDocumentProcessStatus = SunLine.Ware.WareService.EDocumentProcessStatus.TestDoc;
            objFrmware_ChangeDocStatus_Dialog.ShowDialog();
            DisplayInfo();
            return base.PerformTest();
        }

        public override bool PerformVerify()
        {
            Frmware_ChangeDocStatus_Dialog objFrmware_ChangeDocStatus_Dialog = new Frmware_ChangeDocStatus_Dialog();
            objFrmware_ChangeDocStatus_Dialog.TableName = "Ware_Kk_Hh_Mua";
            objFrmware_ChangeDocStatus_Dialog.PK_Name = "Id_Kk_Hh_Mua";
            objFrmware_ChangeDocStatus_Dialog.Identity = gridView2.GetFocusedRowCellValue("Id_Kk_Hh_Mua");
            objFrmware_ChangeDocStatus_Dialog.Text = "Xác nhận phiếu kiểm kê";
            objFrmware_ChangeDocStatus_Dialog.NEWDocumentProcessStatus = SunLine.Ware.WareService.EDocumentProcessStatus.VerifyDoc;
            objFrmware_ChangeDocStatus_Dialog.ShowDialog();
            DisplayInfo();
            return base.PerformVerify();
        }

        public override bool PerformPrintPreview()
        {
            DataSets.dsKk_Hh_Mua dsWare_Kk_Hh_Mua = new SunLine.Ware.DataSets.dsKk_Hh_Mua();
            Reports.rptWare_Kk_Hh_Mua rptWare_Kk_Hh_Mua = new SunLine.Ware.Reports.rptWare_Kk_Hh_Mua();

            GoobizFrame.Windows.Forms.FormReportWithHeader objFormReport = new GoobizFrame.Windows.Forms.FormReportWithHeader();
            objFormReport.Report = rptWare_Kk_Hh_Mua;
            rptWare_Kk_Hh_Mua.DataSource = dsWare_Kk_Hh_Mua;

            //Ware_Kk_Hh_Mua
            DataRow drWare_Kk_Hh_Mua = dsWare_Kk_Hh_Mua.Tables["ware_kk_hh_mua"].NewRow();
            drWare_Kk_Hh_Mua["sochungtu"] = this.txtSochungtu.EditValue;
            drWare_Kk_Hh_Mua["ngay_kk"] = this.dtNgay_Kk.EditValue;
            drWare_Kk_Hh_Mua["ten_khohang"] = this.lookUpEdit_Kho_Hanghoa_Mua.GetColumnValue("Ten_Kho_Hanghoa_Mua");
            drWare_Kk_Hh_Mua["ghichu"] = this.txtGhichu.EditValue;           
            drWare_Kk_Hh_Mua["ten_nhansu_kk"] = this.lookUpEdit_Nhansu_Kk.GetColumnValue("Hoten_Nhansu");
            dsWare_Kk_Hh_Mua.Tables["ware_kk_hh_mua"].Rows.Add(drWare_Kk_Hh_Mua);

            //Ware_Kk_Hh_Mua_Chitiet
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                DataRow rWare_Kk_Hh_Mua_Chitiet = dsWare_Kk_Hh_Mua.Tables["ware_kk_hh_mua_chitiet"].NewRow();
                rWare_Kk_Hh_Mua_Chitiet["ma_hanghoa_mua"] = gridView2.GetRowCellDisplayText(i, gridColumn16);
                rWare_Kk_Hh_Mua_Chitiet["ten_hanghoa_mua"] = gridView2.GetRowCellDisplayText(i, gridColumn4);
                rWare_Kk_Hh_Mua_Chitiet["ten_donvitinh"] = gridView2.GetRowCellDisplayText(i, "Id_Donvitinh");
                rWare_Kk_Hh_Mua_Chitiet["soluong"] = gridView2.GetRowCellValue(i, "Soluong");
                rWare_Kk_Hh_Mua_Chitiet["soluong_doichieu"] = gridView2.GetRowCellValue(i, "Soluong_Doichieu");
                rWare_Kk_Hh_Mua_Chitiet["Barcode_Txt"] = gridView2.GetRowCellValue(i, "Barcode_Txt");
                rWare_Kk_Hh_Mua_Chitiet["ghichu"] = gridView2.GetRowCellValue(i, "Ghichu");
                dsWare_Kk_Hh_Mua.Tables["ware_kk_hh_mua_chitiet"].Rows.Add(rWare_Kk_Hh_Mua_Chitiet);
            }
            dsWare_Kk_Hh_Mua.AcceptChanges();
            rptWare_Kk_Hh_Mua.CreateDocument();
            objFormReport.Text = this.Text + " [In]";
            objFormReport.printControl1.PrintingSystem = rptWare_Kk_Hh_Mua.PrintingSystem;
            objFormReport.MdiParent = this.MdiParent;
            objFormReport.Show();
            objFormReport.Activate();
            //dgware_Kk_Hh_Mua_Chitiet.ShowPrintPreview();
            return base.PerformPrintPreview();
        }
        #endregion

        private void chkShowPreview_CheckedChanged(object sender, EventArgs e)
        {
            gridView1.OptionsView.ShowPreview = chkShowPreview.Checked;
        }

        private void lookUpEdit_Kho_Hanghoa_Mua_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                    txtSochungtu.EditValue = objWareService.GetNew_Sochungtu(
                        "Ware_Kk_Hh_Mua"
                        , "sochungtu"
                        , lookUpEdit_Kho_Hanghoa_Mua.GetColumnValue("Ma_Kho_Hanghoa_Mua"));

                //DataSet dsHanghoa_Mua = objMasterService.Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(lookUpEdit_Kho_Hanghoa_Mua.EditValue, dtNgay_Kk.EditValue);
                //gridLookUpEdit_Hanghoa_Mua.DataSource = dsHanghoa_Mua.Tables[0];
                //gridLookUpEdit_Ma_Hanghoa_Mua.DataSource = dsHanghoa_Mua.Tables[0];
            }
            catch { }
        }

        private void gridLookUpEdit_Hanghoa_Mua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Frmware_Nxt_Hhmua_Dialog frmware_Nxt_Hhmua_Dialog = new Frmware_Nxt_Hhmua_Dialog();
                frmware_Nxt_Hhmua_Dialog.Text = "Hàng hóa";
                frmware_Nxt_Hhmua_Dialog.Id_Kho_Hanghoa_Mua = lookUpEdit_Kho_Hanghoa_Mua.EditValue;
                frmware_Nxt_Hhmua_Dialog.Ngay_Kiemke_Hientai = dtNgay_Kk.DateTime;
                GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Nxt_Hhmua_Dialog);
                frmware_Nxt_Hhmua_Dialog.ShowDialog();

                if (frmware_Nxt_Hhmua_Dialog.SelectedRows != null
                    && frmware_Nxt_Hhmua_Dialog.SelectedRows.Length > 0)
                {
                    //gridLookUpEdit_Hanghoa_Mua.DataSource = frmware_Nxt_Hhmua_Dialog.Data.Tables[0];

                    gridView2.SetFocusedRowCellValue(gridView2.Columns["Id_Hanghoa_Mua"]
                        , frmware_Nxt_Hhmua_Dialog.SelectedRows[0]["Id_Hanghoa_Mua"]);
                    gridView2.SetFocusedRowCellValue(gridView2.Columns["Id_Donvitinh"]
                        , frmware_Nxt_Hhmua_Dialog.SelectedRows[0]["Id_Donvitinh"]);
                    gridView2.SetFocusedRowCellValue(gridView2.Columns["Barcode_Txt"]
                       , frmware_Nxt_Hhmua_Dialog.SelectedRows[0]["Barcode_Txt"]);

                    //object Id_Cuahang_Mua = gridView1.GetFocusedRowCellValue("Id_Cuahang_Mua");
                    if (frmware_Nxt_Hhmua_Dialog.SelectedRows.Length > 1)
                    {
                        for (int i = 1; i < frmware_Nxt_Hhmua_Dialog.SelectedRows.Length; i++)
                        {
                            DataRow nrow = ds_Kk_Hh_Mua_Chitiet.Tables[0].NewRow();
                            //nrow["Id_Cuahang_Mua"] = Id_Cuahang_Mua;
                            nrow["Id_Hanghoa_Mua"] = frmware_Nxt_Hhmua_Dialog.SelectedRows[i]["Id_Hanghoa_Mua"];
                            nrow["Id_Donvitinh"] = frmware_Nxt_Hhmua_Dialog.SelectedRows[i]["Id_Donvitinh"];
                            nrow["Barcode_Txt"] = frmware_Nxt_Hhmua_Dialog.SelectedRows[i]["Barcode_Txt"];
                            ds_Kk_Hh_Mua_Chitiet.Tables[0].Rows.Add(nrow);
                        }
                    }
                }
            }
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Id_Hanghoa_Mua")
            {
                try
                {
                    gridView2.SetFocusedRowCellValue(gridView2.Columns["Id_Donvitinh"]
                        , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);
                }
                catch { }
            }
        }
    }
}

