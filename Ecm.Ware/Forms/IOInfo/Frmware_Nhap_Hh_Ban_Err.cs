using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Nhap_Hh_Ban_Err :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Nhap_Hh_Ban_Err = new DataSet();
        DataSet ds_Nhap_Hh_Ban_Err_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Dinhgia = new DataSet();
        DataSet ds_Hanghoa_Ban = null;
        DataSet dsNhansu;
        DataSet dsDonvitinh = new DataSet();
        object identity;

        #region local data

        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_REX_NHANSU = @"Resources\localdata\Rex_Nhansu.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";
        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_ware_dm_donvitinh;
        DateTime dtlc_rex_nhansu;

        string xml_WARE_DG_HANGHOA_BAN = @"Resources\localdata\ware_Dm_Hanghoa_Dinhgia.xml";
        DateTime dtlc_ware_dm_hanghoa_dinhgia;

        #endregion

        #region Initialize
        public Frmware_Nhap_Hh_Ban_Err()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            lookUpEdit_Cuahang_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Nhansu_Nhap.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
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
                return new DateTime(2010, 01, 01);
            }
        }

        void LoadMasterTable()
        {
            //load data from local xml when last change at local differ from database
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables("[ware_dm_hanghoa_ban], "
                  + "[ware_dm_donvitinh], [rex_nhansu]").ToDataSet();
            dtlc_rex_nhansu = GetLastChange_FrmLognotify("REX_NHANSU");
            dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");
            dtlc_ware_dm_donvitinh = GetLastChange_FrmLognotify("WARE_DM_DONVITINH");
            if (DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN)) > 0
                || !System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN))
            {
                ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                ds_Hanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (ds_Hanghoa_Ban == null || ds_Hanghoa_Ban.Tables.Count == 0)
            {
                ds_Hanghoa_Ban = new DataSet();
                ds_Hanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN);
            }
            if (DateTime.Compare(dtlc_rex_nhansu, System.IO.File.GetLastWriteTime(xml_REX_NHANSU)) > 0
                || !System.IO.File.Exists(xml_REX_NHANSU))
            {
                dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                dsNhansu.WriteXml(xml_REX_NHANSU, XmlWriteMode.WriteSchema);
            }
            else if (dsNhansu == null || dsNhansu.Tables.Count == 0)
            {
                dsNhansu = new DataSet();
                dsNhansu.ReadXml(xml_REX_NHANSU);
            }
            if (DateTime.Compare(dtlc_ware_dm_hanghoa_dinhgia, System.IO.File.GetLastWriteTime(xml_WARE_DG_HANGHOA_BAN)) > 0
               || !System.IO.File.Exists(xml_WARE_DG_HANGHOA_BAN))
            {
                ds_Hanghoa_Dinhgia = objWareService.Get_All_Ware_Hanghoa_Ban_Dinhgia().ToDataSet();
                ds_Hanghoa_Dinhgia.WriteXml(xml_WARE_DG_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else
            {
                ds_Hanghoa_Dinhgia = new DataSet();
                ds_Hanghoa_Dinhgia.ReadXml(xml_WARE_DG_HANGHOA_BAN);
            }
            if (DateTime.Compare(dtlc_ware_dm_donvitinh, System.IO.File.GetLastWriteTime(xml_WARE_DM_DONVITINH)) > 0
            || !System.IO.File.Exists(xml_WARE_DM_DONVITINH))
            {
                dsDonvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                dsDonvitinh.WriteXml(xml_WARE_DM_DONVITINH, XmlWriteMode.WriteSchema);
            }
            else if (dsDonvitinh == null || dsDonvitinh.Tables.Count == 0)
            {
                dsDonvitinh = new DataSet();
                dsDonvitinh.ReadXml(xml_WARE_DM_DONVITINH);
            }
            //Get data Rex_Nhansu
            lookUpEdit_Nhansu_Nhap.Properties.DataSource = dsNhansu.Tables[0];
            gridLookUpEdit_Nguoi_Nhan_Hanghoa_Ban.DataSource = dsNhansu.Tables[0];
            //Get data Ware_Dm_Hanghoa_Ban
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Donvitinh.DataSource = dsDonvitinh.Tables[0];
        }
        #endregion

        #region Event Override
        public override void DisplayInfo()
        {
            try
            {
                LoadMasterTable();
                lookUpEdit_Cuahang_Ban.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
                //Get data Ware_Kho_Hanghoa_Ban
                gridLookUpEdit_Cuahang_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
                //Get data Ware_Nhap_Hh_Ban
                this.dtThang_Nam.EditValue = DateTime.Now;
                //Reload_Chungtu(dtThang_Nam.DateTime);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif

            }
        }

        public void DisplayInfo2()
        {
            try
            {
                identity = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban_Err");
                this.ds_Nhap_Hh_Ban_Err_Chitiet = objWareService.Get_All_Ware_Nhap_Hh_Ban_Err_Chitiet_By_Nhap_Hh_Ban_Err(identity != null ? identity : 0).ToDataSet();
                this.dgware_Nhap_Hh_Ban_Chitiet.DataSource = ds_Nhap_Hh_Ban_Err_Chitiet;
                this.dgware_Nhap_Hh_Ban_Chitiet.DataMember = ds_Nhap_Hh_Ban_Err_Chitiet.Tables[0].TableName;
                gvware_Nhap_Hh_Ban_Chitiet.BestFitColumns();
            }
            catch { }
        }

        public override void ClearDataBindings()
        {
            this.txtSochungtu.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.dtNgay_Nhap.DataBindings.Clear();
            this.lookUpEdit_Cuahang_Ban.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Nhap.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban_Err, ds_Nhap_Hh_Ban_Err.Tables[0].TableName + ".Sochungtu");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban_Err, ds_Nhap_Hh_Ban_Err.Tables[0].TableName + ".Ghichu");
                this.dtNgay_Nhap.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban_Err, ds_Nhap_Hh_Ban_Err.Tables[0].TableName + ".Ngay_Nhap");
                this.lookUpEdit_Cuahang_Ban.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban_Err, ds_Nhap_Hh_Ban_Err.Tables[0].TableName + ".Id_Cuahang_Ban");
                this.lookUpEdit_Nhansu_Nhap.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban_Err, ds_Nhap_Hh_Ban_Err.Tables[0].TableName + ".Id_Nhansu_Nhap");
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
            this.dgware_Nhap_Hh_Ban.Enabled = !editTable;
            this.txtSochungtu.Properties.ReadOnly = true;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.dtNgay_Nhap.Properties.ReadOnly = true;
            this.lookUpEdit_Cuahang_Ban.Properties.ReadOnly = (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit) ? true : !editTable;
            this.lookUpEdit_Nhansu_Nhap.Properties.ReadOnly = true;
            this.dgware_Nhap_Hh_Ban_Chitiet.EmbeddedNavigator.Enabled = editTable;
            this.gvware_Nhap_Hh_Ban_Chitiet.OptionsBehavior.Editable = editTable;
            this.chkPrint_Save.Enabled = editTable;

        }

        public override void ResetText()
        {
            this.txtGhichu.EditValue = "";
            this.lookUpEdit_Cuahang_Ban.EditValue = "";
            this.ds_Nhap_Hh_Ban_Err_Chitiet = objWareService.Get_All_Ware_Nhap_Hh_Ban_Err_Chitiet_By_Nhap_Hh_Ban_Err(0).ToDataSet();
            this.dgware_Nhap_Hh_Ban_Chitiet.DataSource = ds_Nhap_Hh_Ban_Err_Chitiet.Tables[0];
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban_Err objWare_Nhap_Hh_Ban_Err = new Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban_Err();
                objWare_Nhap_Hh_Ban_Err.Id_Nhap_Hh_Ban_Err = -1;
                txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_nhap_hh_ban_err", "sochungtu", lookUpEdit_Cuahang_Ban.GetColumnValue("Ma_Cuahang_Ban"));
                objWare_Nhap_Hh_Ban_Err.Sochungtu = txtSochungtu.EditValue;
                objWare_Nhap_Hh_Ban_Err.Ghichu = txtGhichu.EditValue;
                objWare_Nhap_Hh_Ban_Err.Ngay_Nhap = dtNgay_Nhap.EditValue;
                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Nhap_Hh_Ban_Err.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
                if ("" + lookUpEdit_Nhansu_Nhap.EditValue != "")
                    objWare_Nhap_Hh_Ban_Err.Id_Nhansu_Nhap = lookUpEdit_Nhansu_Nhap.EditValue;

                identity = objWareService.Insert_Ware_Nhap_Hh_Ban_Err(objWare_Nhap_Hh_Ban_Err);
                if (identity != null)
                {
                    this.DoClickEndEdit(dgware_Nhap_Hh_Ban_Chitiet); //dgware_Nhap_Hh_Ban_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    foreach (DataRow dr in ds_Nhap_Hh_Ban_Err_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Nhap_Hh_Ban_Err"] = identity;
                    }
                    //update donmuahang_chitiet
                    objWareService.Update_Ware_Nhap_Hh_Ban_Err_Chitiet_Collection(ds_Nhap_Hh_Ban_Err_Chitiet);
                }
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban_Err objWare_Nhap_Hh_Ban_Err = new Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban_Err();
                objWare_Nhap_Hh_Ban_Err.Id_Nhap_Hh_Ban_Err = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban_Err");
                objWare_Nhap_Hh_Ban_Err.Sochungtu = txtSochungtu.EditValue;
                objWare_Nhap_Hh_Ban_Err.Ghichu = txtGhichu.EditValue;
                objWare_Nhap_Hh_Ban_Err.Ngay_Nhap = dtNgay_Nhap.EditValue;
                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Nhap_Hh_Ban_Err.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
                if ("" + lookUpEdit_Nhansu_Nhap.EditValue != "")
                    objWare_Nhap_Hh_Ban_Err.Id_Nhansu_Nhap = lookUpEdit_Nhansu_Nhap.EditValue;
                //Update Ware_Nhap_Hh_Ban_Err
                objWareService.Update_Ware_Nhap_Hh_Ban_Err(objWare_Nhap_Hh_Ban_Err);
                //update donmuahang_err_chitiet
                this.DoClickEndEdit(dgware_Nhap_Hh_Ban_Chitiet);
                foreach (DataRow dr in ds_Nhap_Hh_Ban_Err_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Nhap_Hh_Ban_Err"] = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban_Err");
                }

                objWareService.Update_Ware_Nhap_Hh_Ban_Err_Chitiet_Collection(ds_Nhap_Hh_Ban_Err_Chitiet);
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban_Err objWare_Nhap_Hh_Ban_Err = new Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban_Err();
            objWare_Nhap_Hh_Ban_Err.Id_Nhap_Hh_Ban_Err = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban_Err");
            return objWareService.Delete_Ware_Nhap_Hh_Ban_Err(objWare_Nhap_Hh_Ban_Err);
        }

        public override bool PerformAdd()
        {
            //Kiểm tra nếu nhân viên login không tồn tại trong kho hàng hóa mua thì access denied.
            lookUpEdit_Nhansu_Nhap.EditValue = Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            DataSet ds_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Nhap.EditValue).ToDataSet();
            this.lookUpEdit_Cuahang_Ban.Properties.DataSource = ds_Cuahang_Ban.Tables[0];
            if (ds_Cuahang_Ban.Tables[0].Rows.Count > 0)
                lookUpEdit_Cuahang_Ban.EditValue = ds_Cuahang_Ban.Tables[0].Rows[0]["Id_Cuahang_Ban"];
            else
            {
                 GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                lookUpEdit_Nhansu_Nhap.EditValue = null;
                return false;
            }
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            dtNgay_Nhap.EditValue = objWareService.GetServerDateTime();
            txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_nhap_hh_ban_err", "sochungtu", lookUpEdit_Cuahang_Ban.GetColumnValue("Ma_Cuahang_Ban"));
            return true;
        }

        public override bool PerformEdit()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban_Err") == null)
                    return false;
                if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Nhap.EditValue))
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }
                else
                {
                    Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                    DocumentProcessStatus.Tablename = "Ware_Nhap_Hh_Ban_Err";
                    DocumentProcessStatus.PK_Name = "Id_Nhap_Hh_Ban_Err";
                    DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban_Err");
                    DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                    if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                        return false;
                    }
                }
                //gridLookUpEdit_Hanghoa_Ban.DataSource = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Nhap.EditValue).ToDataSet().Tables[0];
                DataSet ds_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Nhap.EditValue).ToDataSet();
                this.lookUpEdit_Cuahang_Ban.Properties.DataSource = ds_Cuahang_Ban.Tables[0];
                if (ds_Cuahang_Ban.Tables[0].Rows.Count == 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    lookUpEdit_Nhansu_Nhap.EditValue = null;
                    return false;
                }

                this.ChangeStatus(true);
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return true;

        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtSochungtu, lblSochungtu.Text);
                hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblCuahang.Text);
                hashtableControls.Add(lookUpEdit_Nhansu_Nhap, lblId_Nhansu_Nhap.Text);
                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;
                this.DoClickEndEdit(dgware_Nhap_Hh_Ban_Chitiet); //dgware_Nhap_Hh_Ban_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();

                if (gvware_Nhap_Hh_Ban_Chitiet.RowCount == 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa nhập hàng hóa, nhập lại");
                    return false;
                }
                else
                {
                    hashtableControls.Clear();
                    hashtableControls.Add(gvware_Nhap_Hh_Ban_Chitiet.Columns["Id_Hanghoa_Ban"], "");
                    hashtableControls.Add(gvware_Nhap_Hh_Ban_Chitiet.Columns["Soluong"], "");
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvware_Nhap_Hh_Ban_Chitiet))
                        return false;
                }
                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = (bool)this.UpdateObject();
                }
                if (success)
                {
                    if (chkPrint_Save.Checked)
                        this.PerformPrintPreview();
                    chkPrint_Save.Checked = false;
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return false;
            }
        }

        public override bool PerformDelete()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban_Err") == null)
                    return false;
                Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                DocumentProcessStatus.Tablename = "Ware_Nhap_Hh_Ban_Err";
                DocumentProcessStatus.PK_Name = "Id_Nhap_Hh_Ban_Err";
                DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban_Err");
                DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                    return false;
                }
                //if ( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
                if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Nhap.EditValue))
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }
                if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
                 GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Nhap_Hh_Ban_Err"),
                 GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Nhap_Hh_Ban_Err")   }) == DialogResult.Yes)
                {
                    this.DeleteObject();
                    this.DisplayInfo();
                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban_Err ware_Nhap_Hh_Ban_Err = new Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban_Err();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Nhap_Hh_Ban_Err.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Nhap_Hh_Ban_Err.Id_Nhap_Hh_Ban_Err = dr["Id_Nhap_Hh_Ban_Err"];
                    ware_Nhap_Hh_Ban_Err.Sochungtu = dr["Sochungtu"];
                    ware_Nhap_Hh_Ban_Err.Ngay_Nhap = dr["Ngay_Nhap"];
                    ware_Nhap_Hh_Ban_Err.Id_Cuahang_Ban = dr["Id_Cuahang_Ban"];
                    ware_Nhap_Hh_Ban_Err.Id_Nhansu_Nhap = dr["Id_Nhansu_Nhap"];
                    ware_Nhap_Hh_Ban_Err.Ghichu = dr["Ghichu"];
                }
                this.Dispose();
                this.Close();
                return ware_Nhap_Hh_Ban_Err;
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
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban_Err") == null)
                    return false;
                //show form ShowFormDocProgress
                 GoobizFrame.Windows.MdiUtils.MdiChecker.ShowFormDocProgress(
                    "Ware_Nhap_Hh_Ban_Err" //Table name
                    , "Id_Nhap_Hh_Ban_Err" //PK name
                    , gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban_Err") //value
                    ,  GoobizFrame.Windows.Forms.DocProgress.Enumerators.EDocumentProcessStatus.TestDoc //New enum DocStatus
                    , false);
                DisplayInfo();
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return base.PerformTest();
        }

        public override bool PerformVerify()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban_Err") == null)
                    return false;
                //show form ShowFormDocProgress
                 GoobizFrame.Windows.MdiUtils.MdiChecker.ShowFormDocProgress(
                    "Ware_Nhap_Hh_Ban_Err" //Table name
                    , "Id_Nhap_Hh_Ban_Err" //PK name
                    , gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban_Err") //value
                    ,  GoobizFrame.Windows.Forms.DocProgress.Enumerators.EDocumentProcessStatus.VerifyDoc //New enum DocStatus
                    , false);
                DisplayInfo();
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return base.PerformVerify();

        }

        public override bool PerformPrintPreview()
        {
            Reports.rptWare_Hh_Mua_Tra_Ncc rptWare_Hh_Mua_Tra_Ncc = new Ecm.Ware.Reports.rptWare_Hh_Mua_Tra_Ncc();
            DataSets.dsHh_Mua_Tra_Ncc dsWare_Hh_Mua_Tra_Ncc = new Ecm.Ware.DataSets.dsHh_Mua_Tra_Ncc();
             GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptWare_Hh_Mua_Tra_Ncc;
            //Ware_Hh_Mua_Tra_Ncc
            DataRow rWare_Hh_Mua_Tra_Ncc = dsWare_Hh_Mua_Tra_Ncc.Tables["ware_hh_mua_tra_ncc"].NewRow();
            rWare_Hh_Mua_Tra_Ncc["sochungtu"] = this.txtSochungtu.EditValue;
            rWare_Hh_Mua_Tra_Ncc["ngay_chungtu"] = this.dtNgay_Nhap.EditValue;
            rWare_Hh_Mua_Tra_Ncc["ten_kho_hanghoa"] = this.lookUpEdit_Cuahang_Ban.GetColumnValue("Ten_Cuahang_Ban");
            rWare_Hh_Mua_Tra_Ncc["ten_nhansu_lap"] = this.lookUpEdit_Nhansu_Nhap.GetColumnValue("Hoten_Nhansu");
            dsWare_Hh_Mua_Tra_Ncc.Tables["ware_hh_mua_tra_ncc"].Rows.Add(rWare_Hh_Mua_Tra_Ncc);

            foreach (DataRow dr in ds_Nhap_Hh_Ban_Err_Chitiet.Tables[0].Rows)
            {
                DataRow rWare_Hh_Mua_Tra_Ncc_Chitiet = dsWare_Hh_Mua_Tra_Ncc.Tables["ware_hh_mua_tra_ncc_chitiet"].NewRow();
                foreach (DataColumn col in rWare_Hh_Mua_Tra_Ncc_Chitiet.Table.Columns)
                {
                    try
                    {
                        rWare_Hh_Mua_Tra_Ncc_Chitiet[col.ColumnName] = dr[col.ColumnName];
                    }
                    catch { continue; }
                }
                dsWare_Hh_Mua_Tra_Ncc.Tables["ware_hh_mua_tra_ncc_chitiet"].Rows.Add(rWare_Hh_Mua_Tra_Ncc_Chitiet);
            }
            dsWare_Hh_Mua_Tra_Ncc.AcceptChanges();
            rptWare_Hh_Mua_Tra_Ncc.DataSource = dsWare_Hh_Mua_Tra_Ncc;
            #region Set he so ctrinh - logo, ten cty

            using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            {
                DataSet dsCompany_Paras = new DataSet();
                dsCompany_Paras.Tables.Add("Company_Paras");
                dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData
                });

                rptWare_Hh_Mua_Tra_Ncc.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptWare_Hh_Mua_Tra_Ncc.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                rptWare_Hh_Mua_Tra_Ncc.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }

            #endregion
            rptWare_Hh_Mua_Tra_Ncc.CreateDocument();
             GoobizFrame.Windows.Forms.ReportOptions oReportOptions =  GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptWare_Hh_Mua_Tra_Ncc);
             if (Convert.ToBoolean(oReportOptions.PrintPreview))
             {
                 frmPrintPreview.Text = "" + oReportOptions.Caption;
                 frmPrintPreview.printControl1.PrintingSystem = rptWare_Hh_Mua_Tra_Ncc.PrintingSystem;
                 frmPrintPreview.MdiParent = this.MdiParent;
                 frmPrintPreview.Show();
                 frmPrintPreview.Activate();
             }
             else
             {
                 var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptWare_Hh_Mua_Tra_Ncc);
                 reportPrintTool.Print();
             }
            return base.PerformPrintPreview();
        }

        public override bool PerformSaveChanges()
        {
            return base.PerformSaveChanges();
        }
        #endregion

        #region Even

        private void chkShowPreview_CheckedChanged(object sender, EventArgs e)
        {
            gridView1.OptionsView.ShowPreview = chkShowPreview.Checked;
        }

        private void gridLookUpEdit_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
                {
                    try
                    {
                        var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                            "Ecm.MasterTables.dll",
                            "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_FullEdit", this);

                        if (dialog == null)
                            return;
                        var SelectedObject = dialog.GetType().GetProperty("Selected_Ware_Dm_Hanghoa_Ban").GetValue(dialog, null)
                            as Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban;
                        var DsDm_Hanghoa_Ban = dialog.GetType().GetProperty("DsDm_Hanghoa_Ban").GetValue(dialog, null) as DataSet;

                        if (SelectedObject != null)
                        {
                            gridLookUpEdit_Hanghoa_Ban.DataSource = DsDm_Hanghoa_Ban.Tables[0];

                            gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Id_Hanghoa_Ban"], SelectedObject.Id_Hanghoa_Ban);
                            gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Id_Donvitinh"], SelectedObject.Id_Donvitinh);
                        }
                    }
                    catch (Exception ex)
                    {
                        GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                    }

                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void lookUpEdit_Cuahang_Ban_EditValueChanged(object sender, EventArgs e)
        {
            if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_nhap_hh_ban_err", "sochungtu", lookUpEdit_Cuahang_Ban.GetColumnValue("Ma_Cuahang_Ban"));

        }

        private void gridLookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
                {
                    Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add frm_Donvitinh = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add();
                    if (gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Id_Hanghoa_Ban"]).ToString() == "")
                        return;
                    frm_Donvitinh.setId_Hanghoa_Ban(gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Id_Hanghoa_Ban"]));
                    frm_Donvitinh.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    frm_Donvitinh.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    frm_Donvitinh.ShowDialog();
                    if (frm_Donvitinh.SelecteWare_Dm_Donvitinh != null)
                    {
                        gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Id_Donvitinh"], frm_Donvitinh.SelecteWare_Dm_Donvitinh.Id_Donvitinh);
                    }
                    gvware_Nhap_Hh_Ban_Chitiet.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                DisplayInfo2();
            }
        }

        private void gridView5_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (gvware_Nhap_Hh_Ban_Chitiet.GetFocusedDataRow() == null) return;

                switch (e.Column.FieldName)
                {
                    case "Id_Hanghoa_Ban":
                        var _Id_Hanghoa_Ban = ds_Hanghoa_Ban.Tables[0].Select(string.Format("Id_Hanghoa_Ban={0}",
                               gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban")))[0]["Id_Hanghoa_Ban"];
                        var _Id_Donvitinh = ds_Hanghoa_Ban.Tables[0].Select(string.Format("Id_Hanghoa_Ban={0}",
                                gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban")))[0]["Id_Donvitinh"];
                        gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue("Id_Donvitinh", _Id_Donvitinh);
                        break;
                    case "Id_Donvitinh":
                        var soluong_ton = this.Get_Soluong_Ton_Quydoi(
                                gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban"),
                                gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue("Id_Donvitinh"));
                        gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue("Soluong", soluong_ton);
                        break;
                    case "Soluong":
                    case "Dongia":
                        decimal soluong = 0;
                        decimal dongia = 0;
                        decimal thanhtien = 0;
                        soluong_ton = this.Get_Soluong_Ton_Quydoi(
                               gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban"),
                               gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue("Id_Donvitinh"));
                        soluong = Convert.ToDecimal("0" + gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue("Soluong"));
                        dongia = Convert.ToDecimal("0" + gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue("Dongia"));
                        if (soluong_ton < soluong)
                        {
                            GoobizFrame.Windows.Forms.MessageDialog.Show("Không đủ số lượng để xuất theo yêu cầu");
                            gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Soluong"], soluong_ton);
                            return;
                        }
                        if ((thanhtien * dongia).ToString().Length > 16)
                        {
                            GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị thành tiền vượt quá khả năng lưu trữ.");
                            gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Dongia"], null);
                            gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Soluong"], null);
                            return;
                        }
                        gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue("Thanhtien", soluong * dongia);
                        break;
                    case "Thanhtien":
                        gvware_Nhap_Hh_Ban_Chitiet.UpdateTotalSummary();
                        //txtSotien.Text = gvware_Nhap_Hh_Ban_Chitiet.Columns["Thanhtien"].SummaryText;
                        break;

                }

                gvware_Nhap_Hh_Ban_Chitiet.BestFitColumns();
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }


        }

        public decimal Get_Soluong_Ton_Quydoi(object Id_Hanghoa_Ban, object Id_Donvitinh)
        {
            try
            {
                var _Id_Donvitinh = ds_Hanghoa_Ban.Tables[0].Select(string.Format("Id_Hanghoa_Ban={0}", Id_Hanghoa_Ban))[0]["Id_Donvitinh"];
                DataSet ds_hh_nxt = Get_Soluong_Ton_Quydoi(lookUpEdit_Cuahang_Ban.EditValue, Id_Hanghoa_Ban, Id_Donvitinh);
                decimal soluong_ton_quydoi = 0;
                soluong_ton_quydoi = (Id_Donvitinh == _Id_Donvitinh)
                ? Convert.ToDecimal("0" + ds_hh_nxt.Tables[0].Compute("sum(Soluong_Ton_Qdoi)",
                        string.Format("Id_Hanghoa_Ban={0}", Id_Hanghoa_Ban)))
                : Convert.ToDecimal("0" + ds_hh_nxt.Tables[0].Compute("sum(Soluong_Ton)",
                        string.Format("Id_Hanghoa_Ban={0} and Id_Donvitinh={1}", Id_Hanghoa_Ban, Id_Donvitinh)));
                return soluong_ton_quydoi;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return 0;
            }
        }

        public DataSet Get_Soluong_Ton_Quydoi(object Id_Cuahang_Ban, object Id_Hanghoa_Ban, object Id_Donvitinh)
        {
            try
            {
                DateTime current_date = objWareService.GetServerDateTime();
                int today = 1;
                if (current_date.Day == 1)
                    today = 1;
                else
                    today = current_date.Day - 1;

                return objWareService.Rptware_Nxt_Hhban_Qdoi(new DateTime(current_date.Year, current_date.Month, today, 0, 0, 0),
                                                                current_date, Id_Cuahang_Ban, Id_Hanghoa_Ban, Id_Donvitinh).ToDataSet();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return null;
            }
        }
        #endregion

        private void gridText_Soluong_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if ("" + e.NewValue == "")
                {
                    gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (Convert.ToInt32(e.NewValue) <= 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng phải lớn hơn 0, vui lòng nhập lại.");
                    gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (Convert.ToInt32(e.NewValue) >= int.MaxValue)
                {
                    //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                    // GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị số lượng không hợp lệ, vui lòng nhập lại.");
                    //gridView5.SetFocusedRowCellValue(gridView5.FocusedColumn, null);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                // GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị số lượng không hợp lệ, vui lòng nhập lại.");
                //gridView5.SetFocusedRowCellValue(gridView5.FocusedColumn, null);
                e.Cancel = true;
            }
        }

        void Reload_Chungtu(object Ngay_Chungtu)
        {
            ds_Nhap_Hh_Ban_Err = objWareService.Get_All_Ware_Nhap_Hh_Ban_Err(Ngay_Chungtu).ToDataSet();
            dgware_Nhap_Hh_Ban.DataSource = ds_Nhap_Hh_Ban_Err;
            dgware_Nhap_Hh_Ban.DataMember = ds_Nhap_Hh_Ban_Err.Tables[0].TableName;
            this.DataBindingControl();
            this.ChangeStatus(false);
            DisplayInfo2();
        }

        private void dtThang_Nam_EditValueChanged(object sender, EventArgs e)
        {
            if (dtThang_Nam.Text != "")
                Reload_Chungtu(dtThang_Nam.DateTime);
            else
                Reload_Chungtu(null);
        }

        private void gridLookUpEdit_Ma_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                try
                {
                    var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                        "Ecm.MasterTables.dll",
                        "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_FullEdit", this);

                    if (dialog == null)
                        return;

                    ds_Hanghoa_Ban = dialog.GetType().GetProperty("DsDm_Hanghoa_Ban").GetValue(dialog, null) as DataSet;
                    gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
                    gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];

                    var SelectedObject = dialog.GetType().GetProperty("Selected_Ware_Dm_Hanghoa_Ban").GetValue(dialog, null)
                        as Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban;                    

                    if (SelectedObject != null)
                    {
                        gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue("Id_Hanghoa_Ban", SelectedObject.Id_Hanghoa_Ban);
                    }
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }
            }
        }

    }
}