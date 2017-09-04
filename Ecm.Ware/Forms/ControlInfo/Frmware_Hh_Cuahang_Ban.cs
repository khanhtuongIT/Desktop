using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Ware.Forms
{
    public partial class Frmware_Hh_Cuahang_Ban : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public WareService.WareService objWareService = new SunLine.Ware.WareService.WareService();
        public MasterService.MasterService objMasterService = new SunLine.Ware.MasterService.MasterService();

        DataSet ds_Collection = new DataSet();
        DataSet ds_Hanghoa_Ban = null;

        #region local data
        bool Exists_Sys_Lognotify_Path = false;
        DataSet dsSys_Lognotify = null;
        string log_WARE_DM_HANGHOA_BAN = "init";
        string log_WARE_HANGHOA_DINHGIA = "init";
        string log_REX_NHANSU = "init";

        string Sys_Lognotify_Path = @"Resources\localdata\SYS_LOGNOTIFY.xml";
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\WARE_DM_HANGHOA_BAN.xml";
        string xml_REX_NHANSU = @"Resources\localdata\REX_NHANSU.xml";

        #endregion

        public Frmware_Hh_Cuahang_Ban()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            this.DisplayInfo();
        }
        void LoadMasterTable()
        {
            string vlog_WARE_DM_HANGHOA_BAN = log_WARE_DM_HANGHOA_BAN;
            string vlog_WARE_HANGHOA_DINHGIA = log_WARE_HANGHOA_DINHGIA;
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
                DataRow[] sdr = dsSys_Lognotify_db.Tables[0].Select("Table_Name = 'Ware_Hh_Cuahang_Ban'");
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
                    log_WARE_HANGHOA_DINHGIA = (dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_HANGHOA_DINHGIA'").Length > 0)
                        ? "" + dsSys_Lognotify.Tables[0].Select("Table_Name='WARE_HANGHOA_DINHGIA'")[0]["Last_Change"] : "";

                    vlog_WARE_DM_HANGHOA_BAN = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_DM_HANGHOA_BAN'")[0]["Last_Change"] : "";
                    vlog_WARE_HANGHOA_DINHGIA = (dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_HANGHOA_DINHGIA'").Length > 0)
                        ? "" + dsSys_Lognotify_db.Tables[0].Select("Table_Name='WARE_HANGHOA_DINHGIA'")[0]["Last_Change"] : "";

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
            if (vlog_WARE_DM_HANGHOA_BAN + vlog_WARE_HANGHOA_DINHGIA != log_WARE_DM_HANGHOA_BAN + log_WARE_HANGHOA_DINHGIA
                || !System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN))
            {
                ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban();
                ds_Hanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (ds_Hanghoa_Ban == null || ds_Hanghoa_Ban.Tables.Count == 0)
            {
                ds_Hanghoa_Ban = new DataSet();
                ds_Hanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN);
            }



            //Get data Ware_Hanghoa_Ban
            lookUpEdit_Hanghoa_Ban.Properties.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
        }

        public override void DisplayInfo()
        {
            try
            {
                LoadMasterTable();


                //Get data Ware_Cuahang_Ban
                DataSet dsWare_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban();
                lookUpEdit_Cuahang_Ban.Properties.DataSource = dsWare_Cuahang_Ban.Tables[0];
                gridLookUpEdit_Cuahang_Ban.DataSource = dsWare_Cuahang_Ban.Tables[0];
                dgware_Dm_Cuahang_Ban.DataSource = dsWare_Cuahang_Ban.Tables[0];
              
                //gridLookUpEdit_Loai_Hanghoa_Ban
                DataSet dsLoai_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban();
                gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = dsLoai_Hanghoa_Ban.Tables[0];

                //Get data dgware_Hh_Cuahang_Ban
                ds_Collection = objWareService.Get_All_Ware_Hh_Cuahang_Ban();
                dgware_Hh_Cuahang_Ban.DataSource = ds_Collection;
                dgware_Hh_Cuahang_Ban.DataMember = ds_Collection.Tables[0].TableName;
                
                //allow edit on gridview
                this.Data = ds_Collection;
                this.GridControl = dgware_Hh_Cuahang_Ban;

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
            this.txtId_Hh_Cuahang_Ban.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();

            this.lookUpEdit_Cuahang_Ban.DataBindings.Clear();
            this.lookUpEdit_Hanghoa_Ban.DataBindings.Clear();

        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
   
                this.txtId_Hh_Cuahang_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Hh_Cuahang_Ban");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ghichu");

                this.lookUpEdit_Cuahang_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Cuahang_Ban");
                this.lookUpEdit_Hanghoa_Ban.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Hanghoa_Ban");
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
            this.dgware_Hh_Cuahang_Ban.Enabled = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Cuahang_Ban.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Hanghoa_Ban.Properties.ReadOnly = !editTable;
        }

        public void ResetText()
        {
            this.txtId_Hh_Cuahang_Ban.EditValue = "";
            this.txtGhichu.EditValue = "";

            this.lookUpEdit_Cuahang_Ban.EditValue = null;
            this.lookUpEdit_Hanghoa_Ban.EditValue = null;
        }

        #region Event Override
        public object InsertObject()
        {
            WareService.Ware_Hh_Cuahang_Ban objWare_Hh_Cuahang_Ban = new SunLine.Ware.WareService.Ware_Hh_Cuahang_Ban();
            objWare_Hh_Cuahang_Ban.Id_Hh_Cuahang_Ban = -1;
            objWare_Hh_Cuahang_Ban.Ghichu = txtGhichu.EditValue;

            if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                objWare_Hh_Cuahang_Ban.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
            if ("" + lookUpEdit_Hanghoa_Ban.EditValue != "")
                objWare_Hh_Cuahang_Ban.Id_Hanghoa_Ban = lookUpEdit_Hanghoa_Ban.EditValue;

            return objWareService.Insert_Ware_Hh_Cuahang_Ban(objWare_Hh_Cuahang_Ban);
        }

        public object UpdateObject()
        {
            WareService.Ware_Hh_Cuahang_Ban objWare_Hh_Cuahang_Ban = new SunLine.Ware.WareService.Ware_Hh_Cuahang_Ban();
            objWare_Hh_Cuahang_Ban.Id_Hh_Cuahang_Ban = gridView1.GetFocusedRowCellValue("Id_Hh_Cuahang_Ban");
            objWare_Hh_Cuahang_Ban.Ghichu = txtGhichu.EditValue;

            if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                objWare_Hh_Cuahang_Ban.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
            if ("" + lookUpEdit_Hanghoa_Ban.EditValue != "")
                objWare_Hh_Cuahang_Ban.Id_Hanghoa_Ban = lookUpEdit_Hanghoa_Ban.EditValue;

            return objWareService.Update_Ware_Hh_Cuahang_Ban(objWare_Hh_Cuahang_Ban);
        }

        public object DeleteObject()
        {
            WareService.Ware_Hh_Cuahang_Ban objWare_Hh_Cuahang_Ban = new SunLine.Ware.WareService.Ware_Hh_Cuahang_Ban();
            objWare_Hh_Cuahang_Ban.Id_Hh_Cuahang_Ban = gridView1.GetFocusedRowCellValue("Id_Hh_Cuahang_Ban");

            return objWareService.Delete_Ware_Hh_Cuahang_Ban(objWare_Hh_Cuahang_Ban);
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

                System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
                hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblId_Cuahang_Ban.Text);
                hashtableControls.Add(lookUpEdit_Hanghoa_Ban, lblId_Hanghoa_Ban.Text);

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
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {

                if (ex.ToString().IndexOf("exists") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00014", new string[] { lblId_Hanghoa_Ban.Text, lblId_Hanghoa_Ban.Text.ToLower() });
                }            
                return false;

            }
        }

        public override bool PerformSaveChanges()
        {
            System.Collections.Hashtable hashtableControls = new System.Collections.Hashtable();
            hashtableControls.Add(gridView1.Columns["Id_Hanghoa_Ban"], "");
            hashtableControls.Add(gridView1.Columns["Id_Cuahang_Ban"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGridOnComplex(new string[] { "Id_Cuahang_Ban", "Id_Hanghoa_Ban" }, gridView1))
                return false;

            try
            {
                dgware_Hh_Cuahang_Ban.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                objWareService.Update_Ware_Hh_Cuahang_Ban_Collection(this.ds_Collection);
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
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Hh_Cuahang_Ban"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Hh_Cuahang_Ban")   }) == DialogResult.Yes)
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
            WareService.Ware_Hh_Cuahang_Ban ware_Hh_Cuahang_Ban = new SunLine.Ware.WareService.Ware_Hh_Cuahang_Ban();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Hh_Cuahang_Ban.Id_Hh_Cuahang_Ban = dr["Id_Hh_Cuahang_Ban"];
                    ware_Hh_Cuahang_Ban.Id_Cuahang_Ban = dr["Id_Cuahang_Ban"];
                    ware_Hh_Cuahang_Ban.Id_Hanghoa_Ban = dr["Id_Hanghoa_Ban"];
                    ware_Hh_Cuahang_Ban.Ghichu = dr["Ghichu"];
                }
                this.Dispose();
                this.Close();
                return ware_Hh_Cuahang_Ban;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }
        #endregion

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Loai_Hanghoa_Ban"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Id_Loai_Hanghoa_Ban"]);
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Ten_Hanghoa_Ban"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Ten_Hanghoa_Ban"]);
            }
            this.dgware_Hh_Cuahang_Ban.EmbeddedNavigator.Buttons.EndEdit.DoClick();

        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gridView1.FocusedColumn = gridView1.Columns["Id_Hh_Cuahang_Ban"];
            gridView1.SetRowCellValue(e.RowHandle, "Id_Cuahang_Ban", gridView2.GetFocusedRowCellValue("Id_Cuahang_Ban"));
            this.addnewrow_clicked = true;
        }

        private void gridLookUpEdit_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                SunLine.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog frmware_Dm_Hanghoa_Ban_Dialog = new SunLine.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog();
                frmware_Dm_Hanghoa_Ban_Dialog.Text = "Hàng hóa";
                GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Ban_Dialog);
                frmware_Dm_Hanghoa_Ban_Dialog.ShowDialog();

                if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows != null
                    && frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 0)
                {
                    //gridLookUpEdit_Hanghoa_Ban.DataSource = frmware_Dm_Hanghoa_Ban_Dialog.Data.Tables[0];

                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Hanghoa_Ban"]
                        , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Hanghoa_Ban"]);

                    object Id_Cuahang_Ban = gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban");
                    if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 1)
                    {
                        for (int i = 1; i < frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length; i++)
                        {
                            DataRow nrow = ds_Collection.Tables[0].NewRow();
                            nrow["Id_Cuahang_Ban"] = Id_Cuahang_Ban;
                            nrow["Id_Hanghoa_Ban"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Hanghoa_Ban"];
                            ds_Collection.Tables[0].Rows.Add(nrow);
                        }
                    }
                }
            }
        }

        private void dgware_Dm_Cuahang_Ban_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView2.FocusedRowHandle >= 0)
                gridView1.Columns["Id_Cuahang_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                    gridView1.Columns["Id_Cuahang_Ban"], gridView2.GetFocusedRowCellValue("Id_Cuahang_Ban"));
        }

    }
}

