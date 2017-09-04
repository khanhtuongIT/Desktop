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
    public partial class Frmware_Kiemke_Hanghoa_Ban : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Kk_Hh_Ban = new DataSet();
        DataSet ds_Kk_Hh_Ban_Chitiet = new DataSet();
        DataSet dsDm_Hanghoa_Ban;
        DataSet dsNhansu;
        DataSet dsDonvitinh;
        object identity;
        object id_Nhansu_current;

        public Frmware_Kiemke_Hanghoa_Ban()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            lookUpEdit_Cuahang_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Nhansu_Kk.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            this.item_Verify.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Test.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            id_Nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            this.DisplayInfo();
        }

        void LoadMasterData()
        {

            dsDm_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            dsDonvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
            //gridLookUpEdit_Hanghoa_Ban
            gridLookUpEdit_Hanghoa_Ban.DataSource = dsDm_Hanghoa_Ban.Tables[0];
            gridLookUpEditMa_Hanghoa_Ban.DataSource = dsDm_Hanghoa_Ban.Tables[0];
            //lookUpEdit_Nhansu_Kk
            lookUpEdit_Nhansu_Kk.Properties.DataSource = dsNhansu.Tables[0];
            gridLookUpEdit_Nhansu_Kk.DataSource = dsNhansu.Tables[0];
            gridLookUpEdit_Donvitinh.DataSource = dsDonvitinh.Tables[0];

            DataSet dsCuahang_Ban = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet();
            //lookUpEdit_Cuahang_Ban.Properties.DataSource = dsCuahang_Ban.Tables[0];
            gridookUpEdit_Cuahang_Ban.DataSource = dsCuahang_Ban.Tables[0];

            DataSet ds_collection = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
            if (ds_collection.Tables[0].Rows.Count > 0 &&
                "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
            {
                DataSet temp = dsCuahang_Ban.Copy();
                DataRow row = temp.Tables[0].NewRow();
                row["Id_Cuahang_Ban"] = -1;
                row["Ma_Cuahang_Ban"] = "All";
                row["Ten_Cuahang_Ban"] = "Tất cả";
                temp.Tables[0].Rows.Add(row);
                lookupEdit_Kho_View.Properties.DataSource = temp.Tables[0];
                lookUpEdit_Cuahang_Ban.Properties.DataSource = temp.Tables[0];
                lookupEdit_Kho_View.EditValue = -1;
            }
            else
            {
                DataSet dsCuahang = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_Nhansu_current, true).ToDataSet();
                lookupEdit_Kho_View.Properties.DataSource = dsCuahang.Tables[0];
                lookUpEdit_Cuahang_Ban.Properties.DataSource = dsCuahang_Ban.Tables[0];
            }
        }

        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                ResetText();
                LoadMasterData();
                this.dtThang_Nam.EditValue = DateTime.Now;
                Reload_Chungtu();
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
            this.dtNgay_Kk.DataBindings.Clear();
            this.lookUpEdit_Cuahang_Ban.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Kk.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Kk_Hh_Ban, ds_Kk_Hh_Ban.Tables[0].TableName + ".Sochungtu");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Kk_Hh_Ban, ds_Kk_Hh_Ban.Tables[0].TableName + ".Ghichu");
                this.dtNgay_Kk.DataBindings.Add("EditValue", ds_Kk_Hh_Ban, ds_Kk_Hh_Ban.Tables[0].TableName + ".Ngay_Kk");
                this.lookUpEdit_Cuahang_Ban.DataBindings.Add("EditValue", ds_Kk_Hh_Ban, ds_Kk_Hh_Ban.Tables[0].TableName + ".Id_Cuahang_Ban");
                this.lookUpEdit_Nhansu_Kk.DataBindings.Add("EditValue", ds_Kk_Hh_Ban, ds_Kk_Hh_Ban.Tables[0].TableName + ".Id_Nhansu_Kk");
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
            this.dgware_Kk_Hh_Ban.Enabled = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Cuahang_Ban.Properties.ReadOnly = (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit) ? true : !editTable;
            this.dgware_Kk_Hh_Ban_Chitiet.EmbeddedNavigator.Enabled = editTable;
            this.gvware_Kk_Hh_Ban_Chitiet.OptionsBehavior.Editable = editTable;
            //this.chkPrint_Save.Visible = editTable;
            this.chkPrint_Save.Enabled = editTable;
            dockPanel2.Enabled = !editTable;
        }

        public override void ResetText()
        {
            txtGhichu.EditValue = null;
            lookUpEdit_Cuahang_Ban.EditValue = null;
            lookUpEdit_Nhansu_Kk.EditValue = null;
            dtNgay_Kk.EditValue = null;
            chkPrint_Save.Checked = false;
            txtSochungtu.EditValue = null;
            this.ds_Kk_Hh_Ban_Chitiet = objWareService.Get_All_Ware_Kk_Hh_Ban_Chitiet_By_Kk_Hh_Ban(-1).ToDataSet();
            this.dgware_Kk_Hh_Ban_Chitiet.DataSource = ds_Kk_Hh_Ban_Chitiet.Tables[0];
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Kk_Hh_Ban objWare_Kk_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Kk_Hh_Ban();
                objWare_Kk_Hh_Ban.Id_Kk_Hh_Ban = -1;
                txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("Ware_Kk_Hh_Ban", "sochungtu", lookUpEdit_Cuahang_Ban.GetColumnValue("Ma_Cuahang_Ban"));
                objWare_Kk_Hh_Ban.Sochungtu = txtSochungtu.EditValue;
                objWare_Kk_Hh_Ban.Ghichu = "" + txtGhichu.EditValue;
                objWare_Kk_Hh_Ban.Ngay_Kk = dtNgay_Kk.EditValue;

                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Kk_Hh_Ban.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
                if ("" + lookUpEdit_Nhansu_Kk.EditValue != "")
                    objWare_Kk_Hh_Ban.Id_Nhansu_Kk = lookUpEdit_Nhansu_Kk.EditValue;

                identity = objWareService.Insert_Ware_Kk_Hh_Ban(objWare_Kk_Hh_Ban);
                if (identity != null)
                {
                    this.DoClickEndEdit(dgware_Kk_Hh_Ban_Chitiet);
                    foreach (DataRow dr in ds_Kk_Hh_Ban_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Kk_Hh_Ban"] = identity;
                    }
                    objWareService.Update_Ware_Kk_Hh_Ban_Chitiet_Collection(ds_Kk_Hh_Ban_Chitiet);
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
                Ecm.WebReferences.WareService.Ware_Kk_Hh_Ban objWare_Kk_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Kk_Hh_Ban();
                objWare_Kk_Hh_Ban.Id_Kk_Hh_Ban = gridView1.GetFocusedRowCellValue("Id_Kk_Hh_Ban");
                objWare_Kk_Hh_Ban.Sochungtu = txtSochungtu.EditValue;
                objWare_Kk_Hh_Ban.Ghichu = ""+ txtGhichu.EditValue;
                objWare_Kk_Hh_Ban.Ngay_Kk = dtNgay_Kk.EditValue;

                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Kk_Hh_Ban.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
                if ("" + lookUpEdit_Nhansu_Kk.EditValue != "")
                    objWare_Kk_Hh_Ban.Id_Nhansu_Kk = lookUpEdit_Nhansu_Kk.EditValue;
                //update donmuahang
                objWareService.Update_Ware_Kk_Hh_Ban(objWare_Kk_Hh_Ban);

                //update donmuahang_chitiet
                this.DoClickEndEdit(dgware_Kk_Hh_Ban_Chitiet);
                foreach (DataRow dr in ds_Kk_Hh_Ban_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Kk_Hh_Ban"] = gridView1.GetFocusedRowCellValue("Id_Kk_Hh_Ban");
                }
                objWareService.Update_Ware_Kk_Hh_Ban_Chitiet_Collection(ds_Kk_Hh_Ban_Chitiet);
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
            Ecm.WebReferences.WareService.Ware_Kk_Hh_Ban objWare_Kk_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Kk_Hh_Ban();
            objWare_Kk_Hh_Ban.Id_Kk_Hh_Ban = gridView1.GetFocusedRowCellValue("Id_Kk_Hh_Ban");
            return objWareService.Delete_Ware_Kk_Hh_Ban(objWare_Kk_Hh_Ban);
        }

        public override bool PerformAdd()
        {
            this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Add);
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            this.gridColumn18.Visible = false;
            dtNgay_Kk.EditValue = objWareService.GetServerDateTime();
            lookUpEdit_Nhansu_Kk.EditValue = Convert.ToInt64(id_Nhansu_current);
            //DataSet ds_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Kk.EditValue).ToDataSet();
            //this.lookUpEdit_Cuahang_Ban.Properties.DataSource = ds_Cuahang_Ban.Tables[0];
            //if (ds_Cuahang_Ban.Tables[0].Rows.Count > 0)
            //    lookUpEdit_Cuahang_Ban.EditValue = ds_Cuahang_Ban.Tables[0].Rows[0]["Id_Cuahang_Ban"];
            //else
            //{
            //     GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
            //    lookUpEdit_Nhansu_Kk.EditValue = null;
            //    return false;
            //}
            //txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("Ware_Kk_Hh_Ban", "sochungtu", lookUpEdit_Cuahang_Ban.GetColumnValue("Ma_Cuahang_Ban"));
            //this.xtraHNavigator1.Enabled = false;
            return true;
        }

        public override bool PerformEdit()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Kk_Hh_Ban") == null)
                    return false;
                //if (!id_Nhansu_current.Equals("" + lookUpEdit_Nhansu_Kk.EditValue))
                //{
                //    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                //    return false;
                //}
                //else
                //{
                //    Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                //    DocumentProcessStatus.Tablename = "Ware_Kk_Hh_Ban";
                //    DocumentProcessStatus.PK_Name = "Id_Kk_Hh_Ban";
                //    DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Kk_Hh_Ban");
                //    DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                //    if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                //    {
                //        GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                //        return false;
                //    }
                //}
                //DataSet ds_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Kk.EditValue).ToDataSet();
                //this.lookUpEdit_Cuahang_Ban.Properties.DataSource = ds_Cuahang_Ban.Tables[0];
                //if (ds_Cuahang_Ban.Tables[0].Rows.Count == 0)
                //{
                //    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                //    lookUpEdit_Nhansu_Kk.EditValue = null;
                //    return false;
                //}
                this.ChangeStatus(true);
                lookUpEdit_Cuahang_Ban.Properties.ReadOnly = true;
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
            this.FormState = GoobizFrame.Windows.Forms.FormState.Cancel;
            this.DisplayInfo();
            this.gridColumn18.Visible = true;
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtSochungtu, lblSochungtu.Text);
                hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblId_Cuahang_Ban.Text);
                hashtableControls.Add(lookUpEdit_Nhansu_Kk, lblId_Nhansu_Kk.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                this.DoClickEndEdit(dgware_Kk_Hh_Ban_Chitiet);
                if (gvware_Kk_Hh_Ban_Chitiet.RowCount == 0)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa nhập hàng hóa, nhập lại");
                    return false;
                }
                else
                {
                    hashtableControls.Clear();
                    hashtableControls.Add(gvware_Kk_Hh_Ban_Chitiet.Columns["Id_Hanghoa_Ban"], "");
                    hashtableControls.Add(gvware_Kk_Hh_Ban_Chitiet.Columns["Soluong"], "");
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvware_Kk_Hh_Ban_Chitiet))
                        return false;
                }
                Constraint constraint = null;
                try
                {
                    ds_Kk_Hh_Ban_Chitiet.Tables[0].Constraints.Clear();
                    constraint = new UniqueConstraint("constraint1",
                             new DataColumn[] {ds_Kk_Hh_Ban_Chitiet.Tables[0].Columns["Id_Hanghoa_Ban"],
                            ds_Kk_Hh_Ban_Chitiet.Tables[0].Columns["Id_Donvitinh"] }, false);
                    ds_Kk_Hh_Ban_Chitiet.Tables[0].Constraints.Add(constraint);
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
                    FormState = GoobizFrame.Windows.Forms.FormState.View;
                    if (chkPrint_Save.Checked)
                        this.PerformPrintPreview();
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
                if (gridView1.GetFocusedRowCellValue("Id_Kk_Hh_Ban") == null)
                    return false;
                //Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                //DocumentProcessStatus.Tablename = "Ware_Kk_Hh_Ban";
                //DocumentProcessStatus.PK_Name = "Id_Kk_Hh_Ban";
                //DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Kk_Hh_Ban");
                //DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                //if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                //{
                //    GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                //    return false;
                //}
                ////if ( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
                //if (!id_Nhansu_current.Equals("" + lookUpEdit_Nhansu_Kk.EditValue))
                //{
                //    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                //    return false;
                //}
                DataSet ds_Role_User = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
                if (ds_Role_User.Tables[0].Rows.Count > 0 &&
                   "" + ds_Role_User.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
                {
                    if (MessageBox.Show("Xóa phiếu tồn kho này?", "Confirm Dialog", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                }
                else
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                    return true;
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
            Ecm.WebReferences.WareService.Ware_Kk_Hh_Ban ware_Kk_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Kk_Hh_Ban();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Kk_Hh_Ban.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Kk_Hh_Ban.Id_Kk_Hh_Ban = dr["Id_Kk_Hh_Ban"];
                    ware_Kk_Hh_Ban.Sochungtu = dr["Sochungtu"];
                    ware_Kk_Hh_Ban.Ngay_Kk = dr["Ngay_Kk"];
                    ware_Kk_Hh_Ban.Id_Cuahang_Ban = dr["Id_Cuahang_Ban"];
                    ware_Kk_Hh_Ban.Id_Nhansu_Kk = dr["Id_Nhansu_Kk"];
                    ware_Kk_Hh_Ban.Ghichu = dr["Ghichu"];
                }
                this.Dispose();
                this.Close();
                return ware_Kk_Hh_Ban;
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
            if (gridView1.GetFocusedRowCellValue("Id_Kk_Hh_Ban") == null)
                return false;
            DataSets.dsKk_Hh_Mua dsWare_Kk_Hh_Mua = new Ecm.Ware.DataSets.dsKk_Hh_Mua();
            Reports.rptWare_Kk_Hh_Mua rptWare_Kk_Hh_Mua = new Ecm.Ware.Reports.rptWare_Kk_Hh_Mua();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptWare_Kk_Hh_Mua;

            rptWare_Kk_Hh_Mua.xrTableCell7.Text = "Cửa hàng";
            rptWare_Kk_Hh_Mua.xrTable_Ghichu.Text = this.txtGhichu.EditValue.ToString();
            rptWare_Kk_Hh_Mua.xrTable_khohang.Text = this.lookUpEdit_Cuahang_Ban.GetColumnValue("Ten_Cuahang_Ban").ToString();
            rptWare_Kk_Hh_Mua.xrTable_ngaykiemke.Text = this.dtNgay_Kk.EditValue.ToString();
            rptWare_Kk_Hh_Mua.xrTable_sochungtu.Text = this.txtSochungtu.EditValue.ToString();

            gvware_Kk_Hh_Ban_Chitiet.ExpandAllGroups();
            for (int i = 0; i < gvware_Kk_Hh_Ban_Chitiet.RowCount; i++)
            {
                try
                {
                    DataRow rWare_Kk_Hh_Mua_Chitiet = dsWare_Kk_Hh_Mua.Tables["ware_kk_hh_mua_chitiet"].NewRow();
                    if (gvware_Kk_Hh_Ban_Chitiet.GetRowCellDisplayText(i, gridColumn16).ToString() != "")
                    {
                        rWare_Kk_Hh_Mua_Chitiet["ma_hanghoa_mua"] = gvware_Kk_Hh_Ban_Chitiet.GetRowCellDisplayText(i, gridColumn16);
                        rWare_Kk_Hh_Mua_Chitiet["ten_hanghoa_mua"] = gvware_Kk_Hh_Ban_Chitiet.GetRowCellDisplayText(i, gridColumn4);
                        rWare_Kk_Hh_Mua_Chitiet["ten_donvitinh"] = gvware_Kk_Hh_Ban_Chitiet.GetRowCellDisplayText(i, "Id_Donvitinh");
                        rWare_Kk_Hh_Mua_Chitiet["soluong"] = gvware_Kk_Hh_Ban_Chitiet.GetRowCellValue(i, "Soluong");
                        rWare_Kk_Hh_Mua_Chitiet["soluong_doichieu"] = gvware_Kk_Hh_Ban_Chitiet.GetRowCellValue(i, "Soluong_Doichieu");
                        rWare_Kk_Hh_Mua_Chitiet["ghichu"] = gvware_Kk_Hh_Ban_Chitiet.GetRowCellValue(i, "Ghichu");
                        rWare_Kk_Hh_Mua_Chitiet["id_loai_hanghoa_ban"] = gvware_Kk_Hh_Ban_Chitiet.GetRowCellValue(i, "Id_Loai_Hanghoa_Ban");
                        rWare_Kk_Hh_Mua_Chitiet["ten_loai_hanghoa_ban"] = gvware_Kk_Hh_Ban_Chitiet.GetRowCellValue(i, "Ten_Loai_Hanghoa_Ban");
                        dsWare_Kk_Hh_Mua.Tables["ware_kk_hh_mua_chitiet"].Rows.Add(rWare_Kk_Hh_Mua_Chitiet);
                    }
                }
                catch (Exception ex)
                { }
            }
            dsWare_Kk_Hh_Mua.AcceptChanges();
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
                    ,imageData});
                rptWare_Kk_Hh_Mua.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptWare_Kk_Hh_Mua.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                //rptWare_Kk_Hh_Mua.xrPic_Logo.DataBindings.Add(
                //    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }
            #endregion
            rptWare_Kk_Hh_Mua.DataSource = dsWare_Kk_Hh_Mua;
            rptWare_Kk_Hh_Mua.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptWare_Kk_Hh_Mua);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                frmPrintPreview.Text = "Kiểm kê hàng hóa";
                frmPrintPreview.printControl1.PrintingSystem = rptWare_Kk_Hh_Mua.PrintingSystem;
                frmPrintPreview.MdiParent = this.MdiParent;
                frmPrintPreview.Show();
                frmPrintPreview.Activate();
            }
            else
            {
                var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptWare_Kk_Hh_Mua);
                reportPrintTool.Print();
            }
            return base.PerformPrintPreview();
        }
        
        #endregion

        #region Even

        private void gridLookUpEdit_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog frmware_Dm_Hanghoa_Ban_Dialog = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog();
                frmware_Dm_Hanghoa_Ban_Dialog.Text = "Hàng hóa";
                //frmware_Dm_Hanghoa_Ban_Dialog.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
                GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Ban_Dialog);
                frmware_Dm_Hanghoa_Ban_Dialog.ShowDialog();

                if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows != null
                    && frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 0)
                {
                    gvware_Kk_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Kk_Hh_Ban_Chitiet.Columns["Id_Hanghoa_Ban"]
                       , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Hanghoa_Ban"]);
                    gvware_Kk_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Kk_Hh_Ban_Chitiet.Columns["Id_Donvitinh"]
                        , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Donvitinh"]);
                    if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 1)
                    {
                        for (int i = 1; i < frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length; i++)
                        {
                            DataRow nrow = ds_Kk_Hh_Ban_Chitiet.Tables[0].NewRow();
                            nrow["Id_Hanghoa_Ban"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Hanghoa_Ban"];
                            nrow["Id_Donvitinh"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Donvitinh"];
                            ds_Kk_Hh_Ban_Chitiet.Tables[0].Rows.Add(nrow);
                        }
                    }
                }
            }
        }

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                try
                {
                    gvware_Kk_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Kk_Hh_Ban_Chitiet.Columns["Id_Donvitinh"]
                        , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);
                }
                catch { }
            }
        }

        private void lookUpEdit_Cuahang_Ban_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add
                    && lookUpEdit_Cuahang_Ban.EditValue != null)
                {
                    txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("Ware_Kk_Hh_Ban", "sochungtu", lookUpEdit_Cuahang_Ban.GetColumnValue("Ma_Cuahang_Ban"));
                    this.Load_Hanghoa(lookUpEdit_Cuahang_Ban.EditValue);
                    gvware_Kk_Hh_Ban_Chitiet.ExpandAllGroups();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void gridLookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add frm_Donvitinh = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add();
                if (gvware_Kk_Hh_Ban_Chitiet.GetFocusedRowCellValue(gvware_Kk_Hh_Ban_Chitiet.Columns["Id_Hanghoa_Ban"]).ToString() == "")
                    return;
                frm_Donvitinh.setId_Hanghoa_Ban(gvware_Kk_Hh_Ban_Chitiet.GetFocusedRowCellValue(gvware_Kk_Hh_Ban_Chitiet.Columns["Id_Hanghoa_Ban"]));
                frm_Donvitinh.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                frm_Donvitinh.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                frm_Donvitinh.ShowDialog();
                if (frm_Donvitinh.SelecteWare_Dm_Donvitinh != null)
                    gvware_Kk_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Kk_Hh_Ban_Chitiet.Columns["Id_Donvitinh"], frm_Donvitinh.SelecteWare_Dm_Donvitinh.Id_Donvitinh);
                gvware_Kk_Hh_Ban_Chitiet.BestFitColumns();
            }
        }

        //private void btnImport_FrRpt_Click(object sender, EventArgs e)
        //{
        //    if (lookUpEdit_Cuahang_Ban.EditValue == null)
        //    {
        //        GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn kho, vui lòng chọn lại");
        //        lookUpEdit_Cuahang_Ban.Focus();
        //        return;

        //    }
        //    if (FormState == GoobizFrame.Windows.Forms.FormState.Add)
        //    {
        //        DateTime ngay_chungtu = dtNgay_Kk2.DateTime;
        //        int day = 0;
        //        day = (ngay_chungtu.Day == 1) ? 1 : ngay_chungtu.Day - 1; // nếu ngay_chungtu.Day = 1 -> 1-1= 0 --> error
        //        DataSet dsNxt_Hanghoa_Ban = objWareService.Rptware_Nxt_Hhban(new DateTime(ngay_chungtu.Year, ngay_chungtu.Month, day, 0, 0, 0)
        //        , new DateTime(ngay_chungtu.Year, ngay_chungtu.Month, ngay_chungtu.Day, ngay_chungtu.Hour, ngay_chungtu.Minute, ngay_chungtu.Second)
        //        , lookUpEdit_Cuahang_Ban.EditValue, null, null).ToDataSet();
        //        ds_Kk_Hh_Ban_Chitiet.Tables[0].Clear();
        //        foreach (DataRow dr in dsNxt_Hanghoa_Ban.Tables[0].Rows)
        //        {
        //            DataRow ndr = ds_Kk_Hh_Ban_Chitiet.Tables[0].NewRow();
        //            ndr["Id_Hanghoa_Ban"] = dr["Id_Hanghoa_Ban"];
        //            ndr["Id_Donvitinh"] = dr["Id_Donvitinh"];
        //            ndr["Soluong"] = dr["Soluong_Ton"];
        //            ndr["Id_Loai_Hanghoa_Ban"] = dr["Id_Loai_Hanghoa_Ban"];
        //            ndr["Ten_Loai_Hanghoa_Ban"] = dr["Ten_Loai_Hanghoa_Ban"];
        //            ds_Kk_Hh_Ban_Chitiet.Tables[0].Rows.Add(ndr);
        //        }
        //        this.xtraHNavigator1.Enabled = true;
        //        gvware_Kk_Hh_Ban_Chitiet.BestFitColumns();
        //    }
        //}

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
                DisplayInfo_Details();
        }
        #endregion

        void DisplayInfo_Details()
        {
            try
            {
                identity = gridView1.GetFocusedRowCellValue("Id_Kk_Hh_Ban");
                this.ds_Kk_Hh_Ban_Chitiet = objWareService.Get_All_Ware_Kk_Hh_Ban_Chitiet_By_Kk_Hh_Ban(identity != null ? identity : 0).ToDataSet();
                this.dgware_Kk_Hh_Ban_Chitiet.DataSource = ds_Kk_Hh_Ban_Chitiet;
                this.dgware_Kk_Hh_Ban_Chitiet.DataMember = ds_Kk_Hh_Ban_Chitiet.Tables[0].TableName;
                gvware_Kk_Hh_Ban_Chitiet.BestFitColumns();
            }
            catch { }
        }

        public void Load_Hanghoa(object id_cuahang_ban)
        {
            this.ds_Kk_Hh_Ban_Chitiet = objWareService.Get_All_Ware_Kk_Hh_Ban_Chitiet_By_Kk_Hh_Ban(-1).ToDataSet();
            DataSet ds_hanghoa_nhap = objWareService.Rptware_Nxt_Hhban(new DateTime(dtNgay_Kk.DateTime.Year, dtNgay_Kk.DateTime.Month, dtNgay_Kk.DateTime.Day, 0, 0, 0)
                                                        , new DateTime(dtNgay_Kk.DateTime.Year, dtNgay_Kk.DateTime.Month, dtNgay_Kk.DateTime.Day, 23, 59, 59), id_cuahang_ban, null, null).ToDataSet();
            for (int i = 0; i < ds_hanghoa_nhap.Tables[0].Rows.Count; i++)
            {
                DataRow dtr = ds_Kk_Hh_Ban_Chitiet.Tables[0].NewRow();
                dtr["Id_Hanghoa_Ban"] = ds_hanghoa_nhap.Tables[0].Rows[i]["Id_Hanghoa_Ban"];
                dtr["Id_Donvitinh"] = ds_hanghoa_nhap.Tables[0].Rows[i]["Id_Donvitinh"];
                dtr["Soluong"] = ds_hanghoa_nhap.Tables[0].Rows[i]["Soluong_Ton"];
                dtr["Id_Loai_Hanghoa_Ban"] = ds_hanghoa_nhap.Tables[0].Rows[i]["Id_Loai_Hanghoa_Ban"];
                dtr["Ten_Loai_Hanghoa_Ban"] = ds_hanghoa_nhap.Tables[0].Rows[i]["Ten_Loai_Hanghoa_Ban"];
                ds_Kk_Hh_Ban_Chitiet.Tables[0].Rows.Add(dtr);
            }
            dgware_Kk_Hh_Ban_Chitiet.DataSource = ds_Kk_Hh_Ban_Chitiet;
            dgware_Kk_Hh_Ban_Chitiet.DataMember = ds_Kk_Hh_Ban_Chitiet.Tables[0].TableName;
        }

        void Reload_Chungtu()
        {
            //var id_kho = (Convert.ToInt64(lookupEdit_Kho_View.EditValue) == -1) ? null : lookupEdit_Kho_View.EditValue;
            ds_Kk_Hh_Ban = objWareService.Get_All_Ware_Kk_Hh_Ban(dtThang_Nam.DateTime, lookupEdit_Kho_View.EditValue).ToDataSet();
            dgware_Kk_Hh_Ban.DataSource = ds_Kk_Hh_Ban;
            dgware_Kk_Hh_Ban.DataMember = ds_Kk_Hh_Ban.Tables[0].TableName;
            this.DataBindingControl();
            this.ChangeStatus(false);
            DisplayInfo_Details();
        }

        private void gridLookUpEditMa_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            //{
            //    try
            //    {
            //        var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
            //            "Ecm.MasterTables.dll",
            //            "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_FullEdit", this);

            //        if (dialog == null)
            //            return;

            //        dsDm_Hanghoa_Ban = dialog.GetType().GetProperty("DsDm_Hanghoa_Ban").GetValue(dialog, null) as DataSet;
            //        gridLookUpEdit_Hanghoa_Ban.DataSource = dsDm_Hanghoa_Ban.Tables[0];
            //        gridLookUpEditMa_Hanghoa_Ban.DataSource = dsDm_Hanghoa_Ban.Tables[0];

            //        var SelectedObject = dialog.GetType().GetProperty("Selected_Ware_Dm_Hanghoa_Ban").GetValue(dialog, null)
            //            as Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban;

            //        if (SelectedObject != null)
            //            gvware_Kk_Hh_Ban_Chitiet.SetFocusedRowCellValue("Id_Hanghoa_Ban", SelectedObject.Id_Hanghoa_Ban);
            //    }
            //    catch (Exception ex)
            //    {
            //        GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            //    }
            //}
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Reload_Chungtu();
        }

        private void gvware_Kk_Hh_Ban_Chitiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (gvware_Kk_Hh_Ban_Chitiet.FocusedColumn.VisibleIndex == gvware_Kk_Hh_Ban_Chitiet.VisibleColumns.Count - 1
    && "" + gvware_Kk_Hh_Ban_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban") != "")
                gvware_Kk_Hh_Ban_Chitiet.AddNewRow();
        }

    }
}

