using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Ware.Forms
{
    public partial class Frmware_Hanghoa_Mua_Dinhgia : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public SunLine.WebReferences.Classes.WareService objWareService = new SunLine.WebReferences.Classes.WareService();
        public SunLine.WebReferences.Classes.MasterService objMasterService = new SunLine.WebReferences.Classes.MasterService();
        DataSet ds_Collection = new DataSet();
        object identity;
        DataSet ds_Hanghoa_Mua = new DataSet();
        #region local data
        bool Exists_Sys_Lognotify_Path = false;
        DataSet dsSys_Lognotify = null;

        string log_WARE_DM_HANGHOA_MUA = "init";
        string log_WARE_HANGHOA_DINHGIA = "init";

        string Sys_Lognotify_Path = @"Resources\localdata\SYS_LOGNOTIFY.xml";
        string xml_WARE_DM_HANGHOA_MUA = @"Resources\localdata\WARE_DM_HANGHOA_MUA.xml";
        string xml_WARE_DG_HANGHOA_MUA = @"Resources\localdata\WARE_DG_HANGHOA_MUA.xml";

        #endregion
        public Frmware_Hanghoa_Mua_Dinhgia()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            
            //date mask
            dtNgay_Batdau.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Batdau.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetLongDateTimeFormat();
            
            dtNgay_Ketthuc.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Ketthuc.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetLongDateTimeFormat();

            repositoryItemDateEdit_Ngay_Batdau.Properties.Mask.UseMaskAsDisplayFormat = true;
            repositoryItemDateEdit_Ngay_Batdau.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetLongDateTimeFormat();
            
            repositoryItemDateEdit_Ngay_Ketthuc.Properties.Mask.UseMaskAsDisplayFormat = true;
            repositoryItemDateEdit_Ngay_Ketthuc.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetLongDateTimeFormat();
            //reset lookup edit as delete value
            lookUpEdit_Donvitinh.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Hanghoa_Mua.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            
            gridLookUpEdit_Donvitinh.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            gridLookUpEdit_Hanghoa_Mua.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);

            this.DisplayInfo();
            GetAllLog();
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

                    vlog_WARE_DM_HANGHOA_MUA = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_MUA'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_MUA'")[0]["Last_Change"] : "";
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

            //LookUpEdit_Hanghoa_Mua
            lookUpEdit_Hanghoa_Mua.Properties.DataSource = ds_Hanghoa_Mua.Tables[0];
            gridLookUpEdit_Hanghoa_Mua.DataSource = ds_Hanghoa_Mua.Tables[0];
        }

        public override void DisplayInfo()
        {
            try
            {
                LoadMasterData();

                ////Get data Ware_Dm_Loai_Hanghoa_Mua
                DataSet dsWare_Dm_Loai_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Mua();
                lookUpEdit_Loai_Hanghoa_Mua.Properties.DataSource = dsWare_Dm_Loai_Hanghoa_Mua.Tables[0];
                gridLookUpEdit_Loai_Hanghoa_Mua.DataSource = dsWare_Dm_Loai_Hanghoa_Mua.Tables[0];
                dgware_Dm_Loai_Hanghoa_Mua.DataSource = dsWare_Dm_Loai_Hanghoa_Mua.Tables[0];

                //gridLookUpEdit_Nhom_Hanghoa_Mua
                gridLookUpEdit_Nhom_Hanghoa_Mua.DataSource = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Mua().Tables[0];
                gridLookUpEdit_Nhom_Hanghoa_Mua2.DataSource = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Mua().Tables[0];
               
                //LookUpEdit_Donvitinh
                lookUpEdit_Donvitinh.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().Tables[0];
                gridLookUpEdit_Donvitinh.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().Tables[0];

                //Get data Ware_Dm_Hanghoa_Mua
                if (chkShowCurrent.Checked)
                    ds_Collection = objWareService.Get_All_Ware_Hanghoa_Mua_Dinhgia_ByDate(objWareService.GetServerDateTime());
                else
                    ds_Collection = objWareService.Get_All_Ware_Hanghoa_Mua_Dinhgia();
                dgware_Hanghoa_Mua_Dinhgia.DataSource = ds_Collection;
                dgware_Hanghoa_Mua_Dinhgia.DataMember = ds_Collection.Tables[0].TableName;
                ds_Collection.Tables[0].Columns.Add("Soluong_In", typeof(int));

                this.Data = ds_Collection;
                this.GridControl = dgware_Hanghoa_Mua_Dinhgia;

                this.DataBindingControl();

                this.ChangeStatus(false);

                this.gridView1.BestFitColumns();
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
            this.txtId_Hanghoa_Dinhgia.DataBindings.Clear();
            this.txtDongia_Ban.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.dtNgay_Batdau.DataBindings.Clear();
            this.dtNgay_Ketthuc.DataBindings.Clear();

            this.lookUpEdit_Donvitinh.DataBindings.Clear();
            this.lookUpEdit_Hanghoa_Mua.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Hanghoa_Dinhgia.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Hanghoa_Dinhgia"); 
                this.txtDongia_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Dongia_Ban"); 
                this.txtGhichu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ghichu"); 
                this.dtNgay_Batdau.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ngay_Batdau"); 
                this.dtNgay_Ketthuc.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ngay_Ketthuc");

                this.lookUpEdit_Donvitinh.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Donvitinh");
                this.lookUpEdit_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Hanghoa_Mua");
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
            this.dgware_Hanghoa_Mua_Dinhgia.Enabled = !editTable;
            this.txtDongia_Ban.Properties.ReadOnly = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.dtNgay_Batdau.Properties.ReadOnly = !editTable;
            this.dtNgay_Ketthuc.Properties.ReadOnly = !editTable;

            this.lookUpEdit_Donvitinh.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Hanghoa_Mua.Properties.ReadOnly = !editTable;

            //this.dgware_Hanghoa_Mua_Dinhgia.EmbeddedNavigator.Enabled = editTable;
            //this.gridView5.OptionsBehavior.Editable = editTable;

        }

        public void ResetText()
        {
            this.txtId_Hanghoa_Dinhgia.EditValue = "";
            this.txtTen_Hanghoa_Mua.EditValue = "";
            this.txtTen_Nhasanxuat.EditValue = "";
            this.txtSize.EditValue = "";
            this.txtQuycach.EditValue = "";
            this.txtGhichu.EditValue = "";
            this.dtNgay_Batdau.EditValue = null;
            this.dtNgay_Ketthuc.EditValue = null;
            
            this.txtDongia_Ban.EditValue = null;

            this.lookUpEdit_Donvitinh.EditValue = null;
            this.lookUpEdit_Loai_Hanghoa_Mua.EditValue = null;
            this.lookUpEdit_Hanghoa_Mua.EditValue = null;


            //this.ds_Collection = objWareService.Get_All_Ware_Nhap_Hh_Mua_Chitiet_By_Nhap_Hh_Mua(0);
            //this.dgware_Nhap_Hh_Mua_Chitiet.DataSource = ds_Nhap_Hh_Mua_Chitiet.Tables[0];
        }

        #region Log
        DataSet ds_Collection_Log = new DataSet();
        void GetAllLog()
        {
            ds_Collection_Log = objWareService.Get_All_Ware_Hanghoa_Dinhgia_Log();
        }
        /// <summary>
        /// 
        /// </summary>
        void UpdateLog()
        {
            //neu sua row
            //save row trong Ware_Hdbanhang_Chitiet_Log
            if (ds_Collection.HasChanges(DataRowState.Modified))
            {
                DataTable dt_Modified = ds_Collection.Tables[0].GetChanges(DataRowState.Modified).Copy();
                dt_Modified.RejectChanges();
                foreach (DataRow dr_Modified in dt_Modified.Rows)
                {
                        DataRow ndr_Log = ds_Collection_Log.Tables[0].NewRow();
                        foreach (DataColumn col in ndr_Log.Table.Columns)
                            try
                            {
                                ndr_Log[col.ColumnName] = dr_Modified[col.ColumnName];
                            }
                            catch(Exception ex) { continue; }
                        ndr_Log["RowState"] = DataRowState.Modified.ToString();
                        ndr_Log["Id_Nhansu"] = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu(); //nhan su sua row
                        ndr_Log["Ngay_Hieuchinh"] = objWareService.GetServerDateTime();

                        ds_Collection_Log.Tables[0].Rows.Add(ndr_Log);
                }
            }
            objWareService.Update_Ware_Hanghoa_Dinhgia_Log_Collection(ds_Collection_Log);
        }

        /// <summary>
        /// 
        /// </summary>
        void AddLogDeletedRow()
        {
            DataRow ndr_Log = ds_Collection_Log.Tables[0].NewRow();
            DataRow fdr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            foreach (DataColumn col in ndr_Log.Table.Columns)
                try
                {
                    ndr_Log[col.ColumnName] = fdr[col.ColumnName];
                }
                catch (Exception ex) { continue; }
            ndr_Log["RowState"] = DataRowState.Deleted.ToString();
            ndr_Log["Id_Nhansu"] = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu(); //nhan su xoa row
            ndr_Log["Ngay_Hieuchinh"] = objWareService.GetServerDateTime();

            ds_Collection_Log.Tables[0].Rows.Add(ndr_Log);
        }

        private void dgware_Hanghoa_Ban_Dinhgia_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            //neu xoa row
            //save row vao Ware_Hdbanhang_Chitiet_Log
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
                if( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00021", new string[] { "" }) == DialogResult.Yes)
                {
                    AddLogDeletedRow();
                }
                else
                    e.Handled = true;
        }
        #endregion

        #region Event Override
        public object InsertObject()
        {
            try
            {
                SunLine.WebReferences.WareService.Ware_Hanghoa_Dinhgia objWare_Hanghoa_Dinhgia = new SunLine.WebReferences.WareService.Ware_Hanghoa_Dinhgia();
                objWare_Hanghoa_Dinhgia.Id_Hanghoa_Dinhgia = -1;
                objWare_Hanghoa_Dinhgia.Ghichu = txtGhichu.EditValue;
                objWare_Hanghoa_Dinhgia.Ngay_Batdau = dtNgay_Batdau.EditValue;
                objWare_Hanghoa_Dinhgia.Ngay_Ketthuc = dtNgay_Ketthuc.EditValue;
                
                if("" + txtDongia_Ban.EditValue != "")
                    objWare_Hanghoa_Dinhgia.Dongia_Ban = txtDongia_Ban.EditValue;
                if ("" + lookUpEdit_Donvitinh.EditValue != "")
                    objWare_Hanghoa_Dinhgia.Id_Donvitinh = lookUpEdit_Donvitinh.EditValue;
                    
                identity = objWareService.Insert_Ware_Hanghoa_Dinhgia(objWare_Hanghoa_Dinhgia);

                if (identity != null)
                {
                    this.DoClickEndEdit(dgware_Hanghoa_Mua_Dinhgia); //dgware_Hanghoa_Mua_Dinhgia.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    foreach (DataRow dr in ds_Collection.Tables[0].Rows)
                    {
                        dr["Id_Hanghoa_Dinhgia"] = identity;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                SunLine.WebReferences.WareService.Ware_Hanghoa_Dinhgia objWare_Hanghoa_Dinhgia = new SunLine.WebReferences.WareService.Ware_Hanghoa_Dinhgia();
                objWare_Hanghoa_Dinhgia.Id_Hanghoa_Dinhgia = gridView1.GetFocusedRowCellValue("Id_Hanghoa_Dinhgia");
                objWare_Hanghoa_Dinhgia.Ghichu = txtGhichu.EditValue;
                
                if ("" + dtNgay_Batdau.EditValue != "")
                    objWare_Hanghoa_Dinhgia.Ngay_Batdau = dtNgay_Batdau.EditValue;
                if ("" + dtNgay_Ketthuc.EditValue != "")
                    objWare_Hanghoa_Dinhgia.Ngay_Ketthuc = dtNgay_Ketthuc.EditValue;
                if ("" + txtDongia_Ban.EditValue != "")
                    objWare_Hanghoa_Dinhgia.Dongia_Ban = txtDongia_Ban.EditValue;
                if ("" + lookUpEdit_Donvitinh.EditValue != "")
                    objWare_Hanghoa_Dinhgia.Id_Donvitinh = lookUpEdit_Donvitinh.EditValue;

                //update nhap_hh_mua
                objWareService.Update_Ware_Hanghoa_Dinhgia(objWare_Hanghoa_Dinhgia);

              

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
            SunLine.WebReferences.WareService.Ware_Hanghoa_Dinhgia objWare_Hanghoa_Dinhgia = new SunLine.WebReferences.WareService.Ware_Hanghoa_Dinhgia();
            objWare_Hanghoa_Dinhgia.Id_Hanghoa_Dinhgia = gridView1.GetFocusedRowCellValue("Id_Hanghoa_Dinhgia");

            return objWareService.Delete_Ware_Hanghoa_Dinhgia(objWare_Hanghoa_Dinhgia);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            return true;
        }

        public override bool PerformEdit()
        {
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

                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(lookUpEdit_Hanghoa_Mua, lblMa_Hanghoa_Mua.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                        return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                        return false;
                    UpdateLog();
                    success = (bool)this.UpdateObject();
                }

                if (success)
                {
                    this.DisplayInfo();

                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00014", new string[] { lblMa_Hanghoa_Mua.Text, lblMa_Hanghoa_Mua.Text.ToLower() });
                    return false;
                }
                
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public override bool PerformSaveChanges()
        {

            this.DoClickEndEdit(dgware_Hanghoa_Mua_Dinhgia); //dgware_Hanghoa_Mua_Dinhgia.EmbeddedNavigator.Buttons.EndEdit.DoClick();
           
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Id_Hanghoa_Mua"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDateGrid(gridView1.Columns["Ngay_Batdau"], gridView1.Columns["Ngay_Ketthuc"], gridView1))
                return false;
            try
            {
                //ds_Collection.Tables[0].Columns["Id_Hanghoa_Mua"].Unique = true;
                this.DoClickEndEdit(dgware_Hanghoa_Mua_Dinhgia); //dgware_Hanghoa_Mua_Dinhgia.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                UpdateLog();
                objWareService.Update_Ware_Hanghoa_Dinhgia_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.ToString());
#endif
                //Error here
                GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                return false;
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Hanghoa_Dinhgia"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Hanghoa_Dinhgia")   }) == DialogResult.Yes)
            {
                try
                {
                    AddLogDeletedRow();
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

        public override bool PerformPrintPreview()
        {
            dgware_Hanghoa_Mua_Dinhgia.ShowPrintPreview();
            return base.PerformPrintPreview();
        }

        
        #endregion
        void PrintBarcode_ByBlock3()
        {
            Frmware_Hanghoa_Ban_Dinhgia_BarcodeInfo Frmware_Hanghoa_Ban_Dinhgia_BarcodeInfo = new Frmware_Hanghoa_Ban_Dinhgia_BarcodeInfo();
            System.Data.DataRowView drv = (System.Data.DataRowView)lookUpEdit_Hanghoa_Mua.Properties.GetDataSourceRowByKeyValue(lookUpEdit_Hanghoa_Mua.EditValue);
            Frmware_Hanghoa_Ban_Dinhgia_BarcodeInfo.txtTen_Hanghoa_Ban.EditValue = drv["Ten_Hanghoa_Mua"];
            Frmware_Hanghoa_Ban_Dinhgia_BarcodeInfo.txtSize.EditValue = drv["Size"];
            Frmware_Hanghoa_Ban_Dinhgia_BarcodeInfo.txtQuycach.EditValue = drv["Quycach"];
            Frmware_Hanghoa_Ban_Dinhgia_BarcodeInfo.txtBarcode_Txt.EditValue = drv["Barcode_Txt"];

            Frmware_Hanghoa_Ban_Dinhgia_BarcodeInfo.ShowDialog();
            if ("" + Frmware_Hanghoa_Ban_Dinhgia_BarcodeInfo.txtNoBlock.EditValue != "")
            {
                //show form print preview
                Reports.rptBarcode rptBarcode = new SunLine.Ware.Reports.rptBarcode();
                //objFormReport.FileName = txtXtra_Rpt_Name.Text;

                //reset data
                DataSets.DsBarcode dsBarcode = new SunLine.Ware.DataSets.DsBarcode();
                GoobizFrame.Windows.Forms.FormReportWithHeader objFormReport = new GoobizFrame.Windows.Forms.FormReportWithHeader();
                objFormReport.Report = rptBarcode;
                rptBarcode.DataSource = dsBarcode;

                int noBlock = 0;
                noBlock = Convert.ToInt32(Frmware_Hanghoa_Ban_Dinhgia_BarcodeInfo.txtNoBlock.EditValue);
                for (int blok = 0; blok < noBlock; blok++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        DataRow nrow = dsBarcode.Tables[0].NewRow();
                        nrow["Ten_Hanghoa"] = drv["Ten_Hanghoa_Mua"];
                        nrow["Barcode_Txt"] = drv["Barcode_Txt"];
                        nrow["Dongia_Ban"] = gridView1.GetFocusedRowCellValue("Dongia_Ban");

                        dsBarcode.Tables[0].Rows.Add(nrow);
                    }
                    dsBarcode.AcceptChanges();

                }

                rptBarcode.CreateDocument();

                if (GoobizFrame.Windows.Forms.UserMessage.Show("SHOW_PRINTPREVIEW", new string[] { }) == DialogResult.No)
                    rptBarcode.Print();
                else
                {
                    objFormReport.printControl1.PrintingSystem = rptBarcode.PrintingSystem;
                    objFormReport.MdiParent = this.MdiParent;
                    objFormReport.Text = this.Text + "(Xem trang in)";
                    objFormReport.Show();
                    objFormReport.Activate();
                }

            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Id_Hanghoa_Mua")
            {
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Loai_Hanghoa_Mua"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Id_Loai_Hanghoa_Mua"]);
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Ten_Nhasanxuat"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Ten_Nhasanxuat"]);
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Ten_Hanghoa_Mua"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Ten_Hanghoa_Mua"]);
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Size"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Size"]);
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Quycach"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Quycach"]);
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Donvitinh"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);
            }

            this.DoClickEndEdit(dgware_Hanghoa_Mua_Dinhgia); //dgware_Hanghoa_Mua_Dinhgia.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        }

        private void lookUpEdit_Hanghoa_Mua_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)lookUpEdit_Hanghoa_Mua.Properties.GetDataSourceRowByKeyValue(lookUpEdit_Hanghoa_Mua.EditValue);
                lookUpEdit_Loai_Hanghoa_Mua.EditValue = drv["Id_Loai_Hanghoa_Mua"];
                txtTen_Hanghoa_Mua.EditValue = drv["Ten_Hanghoa_Mua"];
                txtTen_Nhasanxuat.EditValue = drv["Ten_Nhasanxuat"];
                txtSize.EditValue = drv["Size"];
                txtQuycach.EditValue = drv["Quycach"];
                lookUpEdit_Donvitinh.EditValue = drv["Id_Donvitinh"];
            }
            catch { }
        }

        private void dgware_Hanghoa_Mua_Dinhgia_Click(object sender, EventArgs e)
        {

        }

        private void rgChon_Hanghoa_EditValueChanged(object sender, EventArgs e)
        {
            gridView1.Columns["Soluong_In"].VisibleIndex = 12;
            gridView1.Columns["Soluong_In"].Visible = Convert.ToBoolean( rgChon_Hanghoa.EditValue );
            gridView1.OptionsView.ShowFooter = Convert.ToBoolean( rgChon_Hanghoa.EditValue );
        }

        private void btnInBarcode_Click(object sender, EventArgs e)
        {
            //reset data
            DataSets.DsBarcode dsBarcode = new SunLine.Ware.DataSets.DsBarcode();
            //objFormReport.FileName = txtXtra_Rpt_Name.Text;
            DevExpress.XtraReports.UI.XtraReport xtraReport = null;
            //show form print preview
            if (Convert.ToBoolean(rgChon_KieuIn.EditValue))
                xtraReport = new SunLine.Ware.Reports.rptBarcode5x1();
            else
                xtraReport = new SunLine.Ware.Reports.rptBarcode();
            GoobizFrame.Windows.Forms.FormReportWithHeader objFormReport = new GoobizFrame.Windows.Forms.FormReportWithHeader();
            objFormReport.Report = xtraReport;
            xtraReport.DataSource = dsBarcode;
            
            if (Convert.ToBoolean(rgChon_Hanghoa.EditValue))
            {
                //in nhieu san pham
                DataRow[] sdr = ds_Collection.Tables[0].Select("Soluong_In > 0");
                if (sdr != null && sdr.Length > 0)
                {
                    foreach (DataRow dr in sdr)
                    {
                        for (int i = 0; i < Convert.ToInt32(dr["Soluong_In"]); i++)
                        {
                            DataRow nrow = dsBarcode.Tables[0].NewRow();
                            nrow["Ten_Hanghoa"] = dr["Ten_Hanghoa_Mua"];
                            nrow["Barcode_Txt"] = dr["Barcode_Txt"];
                            nrow["Dongia_Ban"] = dr["Dongia_Ban"];

                            dsBarcode.Tables[0].Rows.Add(nrow);
                        }
                        dsBarcode.AcceptChanges();
                    }
                }
            }
            else if (gridView1.FocusedRowHandle >= 0)
            {
                DataRow drv = ds_Collection.Tables[0].Rows[ gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle) ];
                int Soluong_In = (Convert.ToBoolean( rgChon_KieuIn.EditValue)) ? 5 : 3;

                for (int i = 0; i < Soluong_In; i++)
                {
                    DataRow nrow = dsBarcode.Tables[0].NewRow();
                    nrow["Ten_Hanghoa"] = drv["Ten_Hanghoa_Mua"];
                    nrow["Barcode_Txt"] = drv["Barcode_Txt"];
                    nrow["Dongia_Ban"] = drv["Dongia_Ban"];

                    dsBarcode.Tables[0].Rows.Add(nrow);
                }
                dsBarcode.AcceptChanges();

            }

           
            
            xtraReport.CreateDocument();

            if (GoobizFrame.Windows.Forms.UserMessage.Show("SHOW_PRINTPREVIEW", new string[] { }) == DialogResult.No)
                xtraReport.Print();
            else
            {
                objFormReport.printControl1.PrintingSystem = xtraReport.PrintingSystem;
                objFormReport.MdiParent = this.MdiParent;
                objFormReport.Text = this.Text + "(Xem trang in)";
                objFormReport.Show();
                objFormReport.Activate();
            }
        }

        //private void gridLookUpEdit_Hanghoa_Mua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
        //    {
        //        SunLine.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Mua_Add objFrmware_Dm_Hanghoa_Mua_Add = new SunLine.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Mua_Add();
        //        objFrmware_Dm_Hanghoa_Mua_Add.Text = lblTen_Hanghoa_Mua.Text;
        //        GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(objFrmware_Dm_Hanghoa_Mua_Add);
        //        objFrmware_Dm_Hanghoa_Mua_Add.ShowDialog();

        //        if (objFrmware_Dm_Hanghoa_Mua_Add.SelectedWare_Dm_Hanghoa_Mua != null)
        //        {
        //            DataSet dsWare_Dm_Hanghoa_Mua = objFrmware_Dm_Hanghoa_Mua_Add.Data;
        //            lookUpEdit_Hanghoa_Mua.Properties.DataSource = dsWare_Dm_Hanghoa_Mua.Tables[0];
        //            gridLookUpEdit_Hanghoa_Mua.DataSource = dsWare_Dm_Hanghoa_Mua.Tables[0];

        //            gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Hanghoa_Mua"], objFrmware_Dm_Hanghoa_Mua_Add.SelectedWare_Dm_Hanghoa_Mua.Id_Hanghoa_Mua);
        //        }
        //    }
        //}

        private void chkShowCurrent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowCurrent.Checked)
                ds_Collection = objWareService.Get_All_Ware_Hanghoa_Mua_Dinhgia_ByDate(objWareService.GetServerDateTime());
            else
                ds_Collection = objWareService.Get_All_Ware_Hanghoa_Mua_Dinhgia();

            dgware_Hanghoa_Mua_Dinhgia.DataSource = ds_Collection;
            dgware_Hanghoa_Mua_Dinhgia.DataMember = ds_Collection.Tables[0].TableName;
            ds_Collection.Tables[0].Columns.Add("Soluong_In", typeof(int));
        }

        private void dgware_Dm_Loai_Hanghoa_Mua_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            gridView1.Columns["Id_Loai_Hanghoa_Mua"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                gridView1.Columns["Id_Loai_Hanghoa_Mua"],
                gridView2.GetFocusedRowCellValue("Id_Loai_Hanghoa_Mua"));
        }

        
      
    }
}

