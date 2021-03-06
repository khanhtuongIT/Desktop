using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using System.IO;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Hh_Mua_Tra_Ncc :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Hh_Mua_Tra_Ncc = new DataSet();
        DataSet ds_Hh_Mua_Tra_Ncc_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Ban = new DataSet();
        DataSet dsDonvitinh = new DataSet();
        DataSet dsNhansu;
        object identity;

        #region local data
        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_REX_NHANSU = @"Resources\localdata\Rex_Nhansu.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";
        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_ware_dm_donvitinh;
        DateTime dtlc_rex_nhansu;
        #endregion

        #region  Initialize

        public Frmware_Hh_Mua_Tra_Ncc()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            //date mask
            this.gridDate_Ngay_Sx.MinValue = new DateTime(2000, 01, 01);
            this.gridDate_Han_Sd.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Chungtu.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Chungtu.Properties.Mask.EditMask =  GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            repositoryItemDateEdit_Ngay_Nhap_Hh_Mua.Properties.Mask.UseMaskAsDisplayFormat = true;
            repositoryItemDateEdit_Ngay_Nhap_Hh_Mua.Properties.Mask.EditMask =  GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            //reset lookup edit as delete value
            lookUpEdit_Cuahang_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Nhansu_Lap.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler( GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            this.DisplayInfo();
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

        void LoadMasterData()
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
            else
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
            if (DateTime.Compare(dtlc_ware_dm_donvitinh, System.IO.File.GetLastWriteTime(xml_WARE_DM_DONVITINH)) > 0
            || !System.IO.File.Exists(xml_WARE_DM_DONVITINH))
            {
                dsDonvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                dsDonvitinh.WriteXml(xml_WARE_DM_DONVITINH, XmlWriteMode.WriteSchema);
            }
            else
            {
                if (dsDonvitinh == null || dsDonvitinh.Tables.Count == 0)
                {
                    dsDonvitinh = new DataSet();
                    dsDonvitinh.ReadXml(xml_WARE_DM_DONVITINH);
                }
            }
            lookUpEdit_Nhansu_Lap.Properties.DataSource = dsNhansu.Tables[0];
            gridLookUpEdit_Nguoi_Nhan_Hanghoa_Mua.DataSource = dsNhansu.Tables[0];
            gridLookUpEdit_Hanghoa.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUp_Ma_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Donvitinh.DataSource = dsDonvitinh.Tables[0];
        }
        #endregion

        #region Event Override
        public override void DisplayInfo()
        {
            try
            {
                LoadMasterData();
                //Get data Get_All_Rex_Nhansu_Collection
                DataSet dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
                lookUpEdit_Nhansu_Lap.Properties.DataSource = dsNhansu.Tables[0];

                //Get data Ware_Dm_Kho_Hanghoa_Mua
                DataSet dsCuahang_Ban = new DataSet();
                dsCuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet();
                lookUpEdit_Cuahang_Ban.Properties.DataSource = dsCuahang_Ban.Tables[0];
                gridLookUpEdit_Cuahang_Ban.DataSource = dsCuahang_Ban.Tables[0];

                //Get data Ware_Dm_Khachang (Nha cung cap)
                DataSet dsKhachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                lookUpEdit_Nhacungcap.Properties.DataSource = dsKhachhang.Tables[0];

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

        public override void ClearDataBindings()
        {
            this.txtSochungtu.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.dtNgay_Chungtu.DataBindings.Clear();
            this.lookUpEdit_Cuahang_Ban.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Lap.DataBindings.Clear();
            this.lookUpEdit_Nhacungcap.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Hh_Mua_Tra_Ncc, ds_Hh_Mua_Tra_Ncc.Tables[0].TableName + ".Sochungtu");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Hh_Mua_Tra_Ncc, ds_Hh_Mua_Tra_Ncc.Tables[0].TableName + ".Ghichu");
                this.dtNgay_Chungtu.DataBindings.Add("EditValue", ds_Hh_Mua_Tra_Ncc, ds_Hh_Mua_Tra_Ncc.Tables[0].TableName + ".Ngay_Chungtu");
                this.lookUpEdit_Cuahang_Ban.DataBindings.Add("EditValue", ds_Hh_Mua_Tra_Ncc, ds_Hh_Mua_Tra_Ncc.Tables[0].TableName + ".Id_Cuahang_Ban");
                this.lookUpEdit_Nhansu_Lap.DataBindings.Add("EditValue", ds_Hh_Mua_Tra_Ncc, ds_Hh_Mua_Tra_Ncc.Tables[0].TableName + ".Id_Nhansu_Lap");
                this.lookUpEdit_Nhacungcap.DataBindings.Add("EditValue", ds_Hh_Mua_Tra_Ncc, ds_Hh_Mua_Tra_Ncc.Tables[0].TableName + ".Id_Khachhang");
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
            this.dgware_Hh_Mua_Tra_Ncc.Enabled = !editTable;
            this.txtSochungtu.Properties.ReadOnly = true;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.dtNgay_Chungtu.Properties.ReadOnly = true;
            this.lookUpEdit_Nhansu_Lap.Properties.ReadOnly = true;
            this.lookUpEdit_Cuahang_Ban.Properties.ReadOnly = (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit) ? true : !editTable;
            this.lookUpEdit_Nhacungcap.Properties.ReadOnly = (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit) ? true : !editTable;
            this.dgware_Hh_Mua_Tra_Ncc_Chitiet.EmbeddedNavigator.Enabled = editTable;
            this.gvware_Hh_Mua_Tra_Ncc_Chitiet.OptionsBehavior.Editable = editTable;
            this.btnImport_From_DonHanghoa_Mua.Enabled = editTable;
            this.btnImport_From_Kho_Hhmua.Enabled = editTable;
            //this.chkPrint_Save.Visible = editTable;
            this.chkPrint_Save.Enabled = editTable;
        }

        public override void ResetText()
        {
            this.txtGhichu.EditValue = "";
            this.ds_Hh_Mua_Tra_Ncc_Chitiet = objWareService.Get_All_Ware_Hh_Mua_Tra_Ncc_Chitiet_By_Hh_Mua_Tra_Ncc(0).ToDataSet();
            this.dgware_Hh_Mua_Tra_Ncc_Chitiet.DataSource = ds_Hh_Mua_Tra_Ncc_Chitiet.Tables[0];
            this.lookUpEdit_Nhacungcap.EditValue = null;
            this.txtSotien.Text = "";
            this.lookUpEdit_Nhansu_Lap.EditValue = Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Hh_Mua_Tra_Ncc objWare_Hh_Mua_Tra_Ncc = new Ecm.WebReferences.WareService.Ware_Hh_Mua_Tra_Ncc();
                objWare_Hh_Mua_Tra_Ncc.Id_Hh_Mua_Tra_Ncc = -1;
                txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_hh_mua_tra_ncc", "Sochungtu", lookUpEdit_Cuahang_Ban.GetColumnValue("Ma_Cuahang_Ban"));
                objWare_Hh_Mua_Tra_Ncc.Sochungtu = txtSochungtu.EditValue;
                objWare_Hh_Mua_Tra_Ncc.Ghichu = txtGhichu.EditValue;
                objWare_Hh_Mua_Tra_Ncc.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_Hh_Mua_Tra_Ncc.Id_Khachhang = lookUpEdit_Nhacungcap.EditValue;
                objWare_Hh_Mua_Tra_Ncc.Sotien = Convert.ToDecimal("0" + txtSotien.Text);

                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Hh_Mua_Tra_Ncc.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
                if ("" + lookUpEdit_Nhansu_Lap.EditValue != "")
                    objWare_Hh_Mua_Tra_Ncc.Id_Nhansu_Lap = lookUpEdit_Nhansu_Lap.EditValue;
                identity = objWareService.Insert_Ware_Hh_Mua_Tra_Ncc(objWare_Hh_Mua_Tra_Ncc);
                if (identity != null)
                {
                    this.DoClickEndEdit(dgware_Hh_Mua_Tra_Ncc_Chitiet);
                    foreach (DataRow dr in ds_Hh_Mua_Tra_Ncc_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Hh_Mua_Tra_Ncc"] = identity;
                    }
                    //update nhap_hh_mua_chitiet
                    objWareService.Update_Ware_Hh_Mua_Tra_Ncc_Chitiet_Collection(ds_Hh_Mua_Tra_Ncc_Chitiet);
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
                Ecm.WebReferences.WareService.Ware_Hh_Mua_Tra_Ncc objWare_Hh_Mua_Tra_Ncc = new Ecm.WebReferences.WareService.Ware_Hh_Mua_Tra_Ncc();
                objWare_Hh_Mua_Tra_Ncc.Id_Hh_Mua_Tra_Ncc = gridView1.GetFocusedRowCellValue("Id_Hh_Mua_Tra_Ncc");
                identity = objWare_Hh_Mua_Tra_Ncc.Id_Hh_Mua_Tra_Ncc;
                objWare_Hh_Mua_Tra_Ncc.Sochungtu = txtSochungtu.EditValue;
                objWare_Hh_Mua_Tra_Ncc.Ghichu = txtGhichu.EditValue;
                objWare_Hh_Mua_Tra_Ncc.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Hh_Mua_Tra_Ncc.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
                if ("" + lookUpEdit_Nhansu_Lap.EditValue != "")
                    objWare_Hh_Mua_Tra_Ncc.Id_Nhansu_Lap = lookUpEdit_Nhansu_Lap.EditValue;
                if ("" + lookUpEdit_Nhacungcap.EditValue != "")
                    objWare_Hh_Mua_Tra_Ncc.Id_Khachhang = lookUpEdit_Nhacungcap.EditValue;

                objWare_Hh_Mua_Tra_Ncc.Sotien = Convert.ToDecimal(txtSotien.Text);

                //update nhap_hh_mua
                objWareService.Update_Ware_Hh_Mua_Tra_Ncc(objWare_Hh_Mua_Tra_Ncc);
                //update nhap_hh_mua_chitiet
                this.DoClickEndEdit(dgware_Hh_Mua_Tra_Ncc_Chitiet);
                foreach (DataRow dr in ds_Hh_Mua_Tra_Ncc_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Hh_Mua_Tra_Ncc"] = gridView1.GetFocusedRowCellValue("Id_Hh_Mua_Tra_Ncc");
                }
                objWareService.Update_Ware_Hh_Mua_Tra_Ncc_Chitiet_Collection(ds_Hh_Mua_Tra_Ncc_Chitiet);
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
            Ecm.WebReferences.WareService.Ware_Hh_Mua_Tra_Ncc objWare_Hh_Mua_Tra_Ncc = new Ecm.WebReferences.WareService.Ware_Hh_Mua_Tra_Ncc();
            objWare_Hh_Mua_Tra_Ncc.Id_Hh_Mua_Tra_Ncc = gridView1.GetFocusedRowCellValue("Id_Hh_Mua_Tra_Ncc");
            return objWareService.Delete_Ware_Hh_Mua_Tra_Ncc(objWare_Hh_Mua_Tra_Ncc);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            dtNgay_Chungtu.EditValue = objWareService.GetServerDateTime();
            DataSet ds_Kho_Hanghoa = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Lap.EditValue).ToDataSet();
            this.lookUpEdit_Cuahang_Ban.Properties.DataSource = ds_Kho_Hanghoa.Tables[0];
            if (ds_Kho_Hanghoa.Tables[0].Rows.Count > 0)
                lookUpEdit_Cuahang_Ban.EditValue = ds_Kho_Hanghoa.Tables[0].Rows[0]["Id_Cuahang_Ban"];
            else
            {
                 GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                lookUpEdit_Nhansu_Lap.EditValue = null;
                return false;
            }
            lookUpEdit_Nhansu_Lap.EditValue = Convert.ToInt64( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_hh_mua_tra_ncc", "Sochungtu", lookUpEdit_Cuahang_Ban.GetColumnValue("Ma_Cuahang_Ban"));
            return true;
        }

        public override bool PerformEdit()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Hh_Mua_Tra_Ncc") == null)
                    return false;
                if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Lap.EditValue))
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }
                else
                {
                    Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                    DocumentProcessStatus.Tablename = "ware_hh_mua_tra_ncc";
                    DocumentProcessStatus.PK_Name = "Id_hh_mua_tra_ncc";
                    DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Hh_Mua_Tra_Ncc");
                    DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                    if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                        return false;
                    }
                }
                DataSet ds_Kho_Hanghoa = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Lap.EditValue).ToDataSet();
                this.lookUpEdit_Cuahang_Ban.Properties.DataSource = ds_Kho_Hanghoa.Tables[0];
                if (ds_Kho_Hanghoa.Tables[0].Rows.Count == 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    lookUpEdit_Nhansu_Lap.EditValue = null;
                    return false;
                }
                this.ChangeFormState( GoobizFrame.Windows.Forms.FormState.Edit);
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
                hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblKho.Text);
                hashtableControls.Add(lookUpEdit_Nhansu_Lap, lblNhansu_Lap.Text);
                hashtableControls.Add(lookUpEdit_Nhacungcap, lblNha_Cungcap.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                this.DoClickEndEdit(dgware_Hh_Mua_Tra_Ncc_Chitiet);
                if (gvware_Hh_Mua_Tra_Ncc_Chitiet.RowCount == 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa nhập hàng hóa, nhập lại");
                    return false;
                }
                else
                {
                    hashtableControls.Clear();
                    hashtableControls.Add(gvware_Hh_Mua_Tra_Ncc_Chitiet.Columns["Id_Hanghoa_Ban"], "");
                    hashtableControls.Add(gvware_Hh_Mua_Tra_Ncc_Chitiet.Columns["Soluong"], "");

                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvware_Hh_Mua_Tra_Ncc_Chitiet))
                        return false;
                }
                try
                {
                    ds_Hh_Mua_Tra_Ncc_Chitiet.Tables[0].Constraints.Clear();
                    Constraint constraint = new UniqueConstraint("constraint1",
                            new DataColumn[] {ds_Hh_Mua_Tra_Ncc_Chitiet.Tables[0].Columns["Id_Hanghoa_Ban"],
                            ds_Hh_Mua_Tra_Ncc_Chitiet.Tables[0].Columns["Id_Donvitinh"] }, false);
                    ds_Hh_Mua_Tra_Ncc_Chitiet.Tables[0].Constraints.Add(constraint);
                }
                catch (Exception ex)
                {
                    if (ex.ToString().IndexOf("These columns don't currently have unique values") != -1)
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa và đơn vị tính đã tồn tại, vui lòng nhập lại");
                        return false;
                    }
                    MessageBox.Show(ex.ToString());
                }
                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                    success = (bool)this.InsertObject();

                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                    success = (bool)this.UpdateObject();
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
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Hh_Mua_Tra_Ncc") == null)
                    return false;
                Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                DocumentProcessStatus.Tablename = "ware_hh_mua_tra_ncc";
                DocumentProcessStatus.PK_Name = "Id_hh_mua_tra_ncc";
                DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Hh_Mua_Tra_Ncc");
                DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                    return false;
                }
                //if ( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
                if (! GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu().Equals("" + lookUpEdit_Nhansu_Lap.EditValue))
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return false;
                }
                if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
                 GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Hh_Mua_Tra_Ncc"),
                 GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Hh_Mua_Tra_Ncc")   }) == DialogResult.Yes)
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
            Ecm.WebReferences.WareService.Ware_Hh_Mua_Tra_Ncc ware_Hh_Mua_Tra_Ncc = new Ecm.WebReferences.WareService.Ware_Hh_Mua_Tra_Ncc();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Hh_Mua_Tra_Ncc.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Hh_Mua_Tra_Ncc.Id_Hh_Mua_Tra_Ncc = dr["Id_Hh_Mua_Tra_Ncc"];
                    ware_Hh_Mua_Tra_Ncc.Sochungtu = dr["Sochungtu"];
                    ware_Hh_Mua_Tra_Ncc.Ngay_Chungtu = dr["Ngay_Chungtu"];
                    ware_Hh_Mua_Tra_Ncc.Id_Cuahang_Ban = dr["Id_Cuahang_Ban"];
                    ware_Hh_Mua_Tra_Ncc.Id_Khachhang = dr["Id_Khachhang"];
                    ware_Hh_Mua_Tra_Ncc.Id_Nhansu_Lap = dr["Id_Nhansu_Lap"];
                    ware_Hh_Mua_Tra_Ncc.Ghichu = dr["Ghichu"];
                }
                this.Dispose();
                this.Close();
                return ware_Hh_Mua_Tra_Ncc;
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
                if (gridView1.GetFocusedRowCellValue("Id_Hh_Mua_Tra_Ncc") == null)
                    return false;
                //show form ShowFormDocProgress
                 GoobizFrame.Windows.MdiUtils.MdiChecker.ShowFormDocProgress(
                    "ware_hh_mua_tra_ncc" //Table name
                    , "Id_hh_mua_tra_ncc" //PK name
                    , gridView1.GetFocusedRowCellValue("Id_Hh_Mua_Tra_Ncc") //value
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
                if (gridView1.GetFocusedRowCellValue("Id_Hh_Mua_Tra_Ncc") == null)
                    return false;
                //show form ShowFormDocProgress
                 GoobizFrame.Windows.MdiUtils.MdiChecker.ShowFormDocProgress(
                    "ware_hh_mua_tra_ncc" //Table name
                    , "Id_hh_mua_tra_ncc" //PK name
                    , gridView1.GetFocusedRowCellValue("Id_Hh_Mua_Tra_Ncc") //value
                    ,  GoobizFrame.Windows.Forms.DocProgress.Enumerators.EDocumentProcessStatus.VerifyDoc //New enum DocStatus
                    , false);
                Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                DocumentProcessStatus.Tablename = "ware_hh_mua_tra_ncc";
                DocumentProcessStatus.PK_Name = "Id_hh_mua_tra_ncc";
                DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Hh_Mua_Tra_Ncc");
                DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                    objMasterService.Update_Ware_Dm_Loai_Hanghoa_By_Id_Cuahang(lookUpEdit_Cuahang_Ban.EditValue);
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
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Hh_Mua_Tra_Ncc") == null)
                    return false;
                 GoobizFrame.Windows.Forms.FrmPrintPreview objFormReport = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
                Reports.rptWare_Hh_Mua_Tra_Ncc rptWare_Hh_Mua_Tra_Ncc = new Ecm.Ware.Reports.rptWare_Hh_Mua_Tra_Ncc();
                DataSets.dsHh_Mua_Tra_Ncc dsWare_Hh_Mua_Tra_Ncc = new Ecm.Ware.DataSets.dsHh_Mua_Tra_Ncc();
                // GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
                if (objFormReport == null)
                    objFormReport = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
                objFormReport.Report = rptWare_Hh_Mua_Tra_Ncc;
                //Ware_Hh_Mua_Tra_Ncc
                DataRow rWare_Hh_Mua_Tra_Ncc = dsWare_Hh_Mua_Tra_Ncc.Tables["ware_hh_mua_tra_ncc"].NewRow();
                rWare_Hh_Mua_Tra_Ncc["sochungtu"] = this.txtSochungtu.EditValue;
                rWare_Hh_Mua_Tra_Ncc["ngay_chungtu"] = this.dtNgay_Chungtu.EditValue;
                rWare_Hh_Mua_Tra_Ncc["ten_kho_hanghoa"] = this.lookUpEdit_Cuahang_Ban.GetColumnValue("Ten_Cuahang_Ban");
                rWare_Hh_Mua_Tra_Ncc["ten_nhansu_lap"] = this.lookUpEdit_Nhansu_Lap.GetColumnValue("Hoten_Nhansu");
                dsWare_Hh_Mua_Tra_Ncc.Tables["ware_hh_mua_tra_ncc"].Rows.Add(rWare_Hh_Mua_Tra_Ncc);
                this.ds_Hh_Mua_Tra_Ncc_Chitiet = objWareService.Get_All_Ware_Hh_Mua_Tra_Ncc_Chitiet_By_Hh_Mua_Tra_Ncc(identity != null ? identity : 0).ToDataSet();
                foreach (DataRow dr in ds_Hh_Mua_Tra_Ncc_Chitiet.Tables[0].Rows)
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
                rptWare_Hh_Mua_Tra_Ncc.lbTitile.Text = "HÀNG HÓA TRẢ NHÀ CUNG CẤP";
                rptWare_Hh_Mua_Tra_Ncc.xrTable_RuiroCB_Header.Visible = false;
                rptWare_Hh_Mua_Tra_Ncc.xrTableCell_RuiRoCB.Visible = false;
                rptWare_Hh_Mua_Tra_Ncc.xrTable2.Width = 850;
                rptWare_Hh_Mua_Tra_Ncc.xrTable3.Width = 850;
                #region logo, company name
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
                        ,imageData});

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
                     //objFormReport.Text = "" + oReportOptions.Caption;
                     objFormReport.Text = this.Text + " [In]";
                     objFormReport.printControl1.PrintingSystem = rptWare_Hh_Mua_Tra_Ncc.PrintingSystem;
                     objFormReport.MdiParent = this.MdiParent;
                     objFormReport.Show();
                     objFormReport.Activate();
                 }
                 else
                 {
                     var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptWare_Hh_Mua_Tra_Ncc);
                     reportPrintTool.Print();
                 }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return base.PerformPrintPreview();
        }
        #endregion

        #region Even

        private void btnImport_Hanghoa_Mua_Click(object sender, EventArgs e)
        {
            Forms.Frmware_Hdmuahang frmware_Hdmuahang_Dialog = new Frmware_Hdmuahang();
            frmware_Hdmuahang_Dialog.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            frmware_Hdmuahang_Dialog.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            frmware_Hdmuahang_Dialog.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            frmware_Hdmuahang_Dialog.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            frmware_Hdmuahang_Dialog.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            frmware_Hdmuahang_Dialog.gridColumn_Chon.Visible = true;
            frmware_Hdmuahang_Dialog.gvware_Hdmuahang_Chitiet.OptionsBehavior.Editable = true;
             GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Hdmuahang_Dialog);
            frmware_Hdmuahang_Dialog.Text = "Nhập Hàng hóa từ đơn mua hàng";
            frmware_Hdmuahang_Dialog.ShowDialog();
            if (frmware_Hdmuahang_Dialog.ds_Selected != null)
            {
                if (frmware_Hdmuahang_Dialog.ds_Selected.Tables.Count > 0)
                    foreach (DataRow dr in frmware_Hdmuahang_Dialog.ds_Selected.Tables[0].Rows)
                    {
                        DataRow newrow = ds_Hh_Mua_Tra_Ncc_Chitiet.Tables[0].NewRow();
                        foreach (DataColumn col in ds_Hh_Mua_Tra_Ncc_Chitiet.Tables[0].Columns)
                            try
                            {
                                newrow[col.ColumnName] = dr[col.ColumnName];
                            }
                            catch (Exception ex) { continue; }

                        newrow["soluong"] = dr["soluong"];
                        ds_Hh_Mua_Tra_Ncc_Chitiet.Tables[0].Rows.Add(newrow);
                    }
                dgware_Hh_Mua_Tra_Ncc_Chitiet.DataSource = ds_Hh_Mua_Tra_Ncc_Chitiet.Tables[0];

            }

        }

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (gvware_Hh_Mua_Tra_Ncc_Chitiet.GetFocusedDataRow() == null) return;

                switch (e.Column.FieldName)
                {
                    case "Id_Hanghoa_Ban":
                        var _Id_Hanghoa_Ban = ds_Hanghoa_Ban.Tables[0].Select(string.Format("Id_Hanghoa_Ban={0}",
                               gvware_Hh_Mua_Tra_Ncc_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban")))[0]["Id_Hanghoa_Ban"];
                        var _Id_Donvitinh = ds_Hanghoa_Ban.Tables[0].Select(string.Format("Id_Hanghoa_Ban={0}",
                                gvware_Hh_Mua_Tra_Ncc_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban")))[0]["Id_Donvitinh"];
                        gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue("Id_Donvitinh", _Id_Donvitinh);
                        break;
                    case "Id_Donvitinh":                      
                        var soluong_ton = this.Get_Soluong_Ton_Quydoi(
                                gvware_Hh_Mua_Tra_Ncc_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban"), 
                                gvware_Hh_Mua_Tra_Ncc_Chitiet.GetFocusedRowCellValue("Id_Donvitinh") );
                        gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue("Soluong", soluong_ton);                        
                    break;
                    case "Soluong":
                    case "Dongia":
                        decimal soluong = 0;
                        decimal dongia = 0;
                        decimal thanhtien = 0;
                        soluong_ton = this.Get_Soluong_Ton_Quydoi(
                               gvware_Hh_Mua_Tra_Ncc_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban"),
                               gvware_Hh_Mua_Tra_Ncc_Chitiet.GetFocusedRowCellValue("Id_Donvitinh"));
                        soluong = Convert.ToDecimal("0"+gvware_Hh_Mua_Tra_Ncc_Chitiet.GetFocusedRowCellValue("Soluong"));
                        dongia = Convert.ToDecimal("0" + gvware_Hh_Mua_Tra_Ncc_Chitiet.GetFocusedRowCellValue("Dongia"));
                        if (soluong_ton < soluong)
                        {
                            GoobizFrame.Windows.Forms.MessageDialog.Show("Không đủ số lượng để xuất theo yêu cầu");
                            gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.Columns["Soluong"], soluong_ton);
                            return;
                        }
                        if ((thanhtien*dongia).ToString().Length > 16)
                        {
                            GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị thành tiền vượt quá khả năng lưu trữ.");
                            gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.Columns["Dongia"], null);
                            gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.Columns["Soluong"], null);
                            return;
                        }
                        gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue("Thanhtien", soluong * dongia);
                    break;
                    case "Thanhtien":
                        gvware_Hh_Mua_Tra_Ncc_Chitiet.UpdateTotalSummary();
                        txtSotien.Text = gvware_Hh_Mua_Tra_Ncc_Chitiet.Columns["Thanhtien"].SummaryText;
                    break;

                }
                
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
                DisplayInfo2();
        }

        private void gridLookUpEdit_Hanghoa_Mua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                        gridLookUpEdit_Hanghoa.DataSource = DsDm_Hanghoa_Ban.Tables[0];
                        gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.Columns["Id_Hanghoa_Ban"], SelectedObject.Id_Hanghoa_Ban);
                    }
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }

            }
        }

        private void lookUpEditKho_Hanghoa_Mua_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                    txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_hh_mua_tra_ncc", "Sochungtu", lookUpEdit_Cuahang_Ban.GetColumnValue("Ma_Cuahang_Ban"));
            }
            catch { }
        }

        private void chkShowPreview_CheckedChanged(object sender, EventArgs e)
        {
            this.gridView1.OptionsView.ShowPreview = chkShowPreview.Checked;
        }

        private void gridLookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
                {
                    Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add frm_Donvitinh = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add();
                    if (gvware_Hh_Mua_Tra_Ncc_Chitiet.GetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.Columns["Id_Hanghoa_Ban"]).ToString() == "")
                        return;
                    frm_Donvitinh.setId_Hanghoa_Ban(gvware_Hh_Mua_Tra_Ncc_Chitiet.GetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.Columns["Id_Hanghoa_Ban"]));
                    frm_Donvitinh.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    frm_Donvitinh.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    frm_Donvitinh.ShowDialog();
                    if (frm_Donvitinh.SelecteWare_Dm_Donvitinh != null)
                        gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.Columns["Id_Donvitinh"], frm_Donvitinh.SelecteWare_Dm_Donvitinh.Id_Donvitinh);
                    gvware_Hh_Mua_Tra_Ncc_Chitiet.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }
        #endregion

        #region Custom Method

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

        void DisplayInfo2()
        {
            try
            {
                identity = gridView1.GetFocusedRowCellValue("Id_Hh_Mua_Tra_Ncc");
                this.ds_Hh_Mua_Tra_Ncc_Chitiet = objWareService.Get_All_Ware_Hh_Mua_Tra_Ncc_Chitiet_By_Hh_Mua_Tra_Ncc(identity != null ? identity : 0).ToDataSet();
                this.dgware_Hh_Mua_Tra_Ncc_Chitiet.DataSource = ds_Hh_Mua_Tra_Ncc_Chitiet;
                this.dgware_Hh_Mua_Tra_Ncc_Chitiet.DataMember = ds_Hh_Mua_Tra_Ncc_Chitiet.Tables[0].TableName;
                gvware_Hh_Mua_Tra_Ncc_Chitiet.BestFitColumns();
            }
            catch { }
        }
        #endregion

        private void gridText_Soluong_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if ("" + e.NewValue == "")
                {
                    gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (Convert.ToInt32(e.NewValue) <= 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng phải lớn hơn 0, vui lòng nhập lại.");
                    gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (Convert.ToInt32(e.NewValue) >= int.MaxValue)
                {
                    //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị số lượng không hợp lệ, vui lòng nhập lại.");
                    gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.FocusedColumn, null);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị số lượng không hợp lệ, vui lòng nhập lại.");
                gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.FocusedColumn, null);
                e.Cancel = true;
            }
        }

        private void gridText_Dongia_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if ("" + e.NewValue == "")
                {
                    gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (Convert.ToDecimal(e.NewValue) <= 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Đơn giá phải lớn hơn 0, vui lòng nhập lại.");
                    gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (e.NewValue.ToString().Length > 16)
                {
                    //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị đơn giá không hợp lệ, vui lòng nhập lại.");
                    gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.FocusedColumn, null);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị đơn giá không hợp lệ, vui lòng nhập lại.");
                gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue(gvware_Hh_Mua_Tra_Ncc_Chitiet.FocusedColumn, null);
                e.Cancel = true;
            }
        }

        private void dtThang_Nam_EditValueChanged(object sender, EventArgs e)
        {
            if (dtThang_Nam.Text != "")
                Reload_Chungtu(dtThang_Nam.DateTime);
            else
                Reload_Chungtu(null);
        }

        void Reload_Chungtu(object Ngay_Chungtu)
        {
            ds_Hh_Mua_Tra_Ncc = objWareService.Get_All_Ware_Hh_Mua_Tra_Ncc(Ngay_Chungtu).ToDataSet();
            dgware_Hh_Mua_Tra_Ncc.DataSource = ds_Hh_Mua_Tra_Ncc;
            dgware_Hh_Mua_Tra_Ncc.DataMember = ds_Hh_Mua_Tra_Ncc.Tables[0].TableName;
            this.DataBindingControl();
            this.ChangeStatus(false);
            DisplayInfo2();
        }

        private void lookUpEdit_Nhacungcap_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                try
                {
                    var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                        "Ecm.MasterTables.dll",
                        "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add", this);

                    if (dialog == null)
                        return;
                    var SelectedObject = dialog.GetType().GetProperty("SelectedWare_Dm_Khachhang").GetValue(dialog, null)
                        as Ecm.WebReferences.MasterService.Ware_Dm_Khachhang;

                    if (SelectedObject != null)
                        lookUpEdit_Nhacungcap.EditValue = Convert.ToInt64(SelectedObject.Id_Khachhang);
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }
            }
        }

        private void gridLookUp_Ma_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                    var SelectedObject = dialog.GetType().GetProperty("Selected_Ware_Dm_Hanghoa_Ban").GetValue(dialog, null)
                        as Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban;

                    if (SelectedObject != null)
                    {
                        gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue("Id_Hanghoa_Ban", Convert.ToInt64(SelectedObject.Id_Hanghoa_Ban));
                        gvware_Hh_Mua_Tra_Ncc_Chitiet.SetFocusedRowCellValue("Id_Donvitinh", Convert.ToInt64(SelectedObject.Id_Donvitinh));
                        gvware_Hh_Mua_Tra_Ncc_Chitiet.EndUpdate();
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

