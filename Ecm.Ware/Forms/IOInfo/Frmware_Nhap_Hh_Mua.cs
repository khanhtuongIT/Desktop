using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SunLine.Ware.Forms
{
    public partial class Frmware_Nhap_Hh_Mua : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public WareService.WareService objWareService = new SunLine.Ware.WareService.WareService();
        public RexService.RexService objRexService = new SunLine.Ware.RexService.RexService();
        public MasterService.MasterService objMasterService = new SunLine.Ware.MasterService.MasterService();

        DataSet ds_Nhap_Hh_Mua = new DataSet();
        DataSet ds_Nhap_Hh_Mua_Chitiet = new DataSet();
        DataSet dsHanghoa_Mua;
        object identity;

        public Frmware_Nhap_Hh_Mua()
        {
            InitializeComponent();
            //date mask
            dtNgay_Nhap_Hh_Mua.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Nhap_Hh_Mua.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            repositoryItemDateEdit_Ngay_Nhap_Hh_Mua.Properties.Mask.UseMaskAsDisplayFormat = true;
            repositoryItemDateEdit_Ngay_Nhap_Hh_Mua.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            //reset lookup edit as delete value
            lookUpEdit_Kho_Hanghoa_Mua.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Nhansu_Nhanhang.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);

            this.DisplayInfo();
        }

        public override void DisplayInfo()
        {
            try
            {
                //Get data Ware_Dm_Kho_Hanghoa_Mua
                lookUpEdit_Kho_Hanghoa_Mua.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_Mua().Tables[0];

                //Get data Rex_Nhansu
                lookUpEdit_Nhansu_Nhanhang.Properties.DataSource = objRexService.Get_All_Rex_Nhansu_Collection().Tables[0];

                //Get data Ware_Dm_Hanghoa_Mua
                dsHanghoa_Mua = objMasterService.Get_All_Ware_Dm_Hanghoa_Mua();
                gridLookUpEdit_Hanghoa_Mua.DataSource = dsHanghoa_Mua.Tables[0];
                gridLookUpEditMa_Hanghoa_Mua.DataSource = dsHanghoa_Mua.Tables[0];

                //Get data Ware_Dm_Donvitinh
                gridLookUpEdit_Donvitinh.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().Tables[0];

                //Get data Ware_Kho_Hanghoa_Mua
                gridLookUpEdit_Kho_Hanghoa_Mua.DataSource = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_Mua().Tables[0];

                //Get data Ware_Nguoi_Nhan_Hanghoa_Mua
                gridLookUpEdit_Nguoi_Nhan_Hanghoa_Mua.DataSource = objRexService.Get_All_Rex_Nhansu_Collection().Tables[0];

                //Get data Ware_Nhap_Hh_Ban
                ds_Nhap_Hh_Mua = objWareService.Get_All_Ware_Nhap_Hh_Mua();
                dgware_Nhap_Hh_Mua.DataSource = ds_Nhap_Hh_Mua;
                dgware_Nhap_Hh_Mua.DataMember = ds_Nhap_Hh_Mua.Tables[0].TableName;

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
            this.txtId_Nhap_Hh_Mua.DataBindings.Clear();
            this.txtSochungtu.DataBindings.Clear();
            this.txtNguoi_Giao_Hanghoa_Mua.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.dtNgay_Nhap_Hh_Mua.DataBindings.Clear();

            this.lookUpEdit_Kho_Hanghoa_Mua.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Nhanhang.DataBindings.Clear();
        }

        public void DataBindingControl()
        {
            try
            {
                ClearDataBindings();

                this.txtId_Nhap_Hh_Mua.DataBindings.Add("EditValue", ds_Nhap_Hh_Mua, ds_Nhap_Hh_Mua.Tables[0].TableName + ".Id_Nhap_Hh_Mua");
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Nhap_Hh_Mua, ds_Nhap_Hh_Mua.Tables[0].TableName + ".Sochungtu");
                this.txtNguoi_Giao_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Nhap_Hh_Mua, ds_Nhap_Hh_Mua.Tables[0].TableName + ".Nguoi_Giaohang");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Nhap_Hh_Mua, ds_Nhap_Hh_Mua.Tables[0].TableName + ".Ghichu");
                this.dtNgay_Nhap_Hh_Mua.DataBindings.Add("EditValue", ds_Nhap_Hh_Mua, ds_Nhap_Hh_Mua.Tables[0].TableName + ".Ngay_Nhanhang");

                this.lookUpEdit_Kho_Hanghoa_Mua.DataBindings.Add("EditValue", ds_Nhap_Hh_Mua, ds_Nhap_Hh_Mua.Tables[0].TableName + ".Id_Kho_Hanghoa_Mua");
                this.lookUpEdit_Nhansu_Nhanhang.DataBindings.Add("EditValue", ds_Nhap_Hh_Mua, ds_Nhap_Hh_Mua.Tables[0].TableName + ".Id_Nhansu_Nhanhang");
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
            this.dgware_Nhap_Hh_Mua.Enabled = !editTable;
            this.txtSochungtu.Properties.ReadOnly = !editTable;
            this.txtNguoi_Giao_Hanghoa_Mua.Properties.ReadOnly = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.dtNgay_Nhap_Hh_Mua.Properties.ReadOnly = !editTable;

            this.lookUpEdit_Nhansu_Nhanhang.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Kho_Hanghoa_Mua.Properties.ReadOnly = !editTable;

            this.dgware_Nhap_Hh_Mua_Chitiet.EmbeddedNavigator.Enabled = editTable;   
            this.gridView5.OptionsBehavior.Editable = editTable;

            btnImport_Hanghoa_Mua.Enabled = editTable;
            this.chkPrint_Save.Enabled = editTable;
        }

        public void ResetText()
        {
            this.txtId_Nhap_Hh_Mua.EditValue = "";
            this.txtSochungtu.EditValue = "";
            this.txtNguoi_Giao_Hanghoa_Mua.EditValue = "";
            this.txtGhichu.EditValue = "";
            this.chkPrint_Save.Checked = false;
            //this.lookUpEdit_Kho_Hanghoa_Mua.EditValue = null;
            //this.lookUpEdit_Nguoi_Nhan_Hanghoa_Ban.EditValue = null;

            this.ds_Nhap_Hh_Mua_Chitiet = objWareService.Get_All_Ware_Nhap_Hh_Mua_Chitiet_By_Nhap_Hh_Mua(0);
            this.dgware_Nhap_Hh_Mua_Chitiet.DataSource = ds_Nhap_Hh_Mua_Chitiet.Tables[0];
        }

        #region Event Override
        public object InsertObject()
        {
            try
            {
                WareService.Ware_Nhap_Hh_Mua objWare_Nhap_Hh_Mua = new SunLine.Ware.WareService.Ware_Nhap_Hh_Mua();
                objWare_Nhap_Hh_Mua.Id_Nhap_Hh_Mua = -1;
                objWare_Nhap_Hh_Mua.Sochungtu = txtSochungtu.EditValue;
                objWare_Nhap_Hh_Mua.Nguoi_Giaohang = txtNguoi_Giao_Hanghoa_Mua.EditValue;
                objWare_Nhap_Hh_Mua.Ghichu = txtGhichu.EditValue;
                objWare_Nhap_Hh_Mua.Ngay_Nhanhang = dtNgay_Nhap_Hh_Mua.EditValue;

                if ("" + lookUpEdit_Kho_Hanghoa_Mua.EditValue != "")
                    objWare_Nhap_Hh_Mua.Id_Kho_Hanghoa_Mua = lookUpEdit_Kho_Hanghoa_Mua.EditValue;
                if ("" + lookUpEdit_Nhansu_Nhanhang.EditValue != "")
                    objWare_Nhap_Hh_Mua.Id_Nhansu_Nhanhang = lookUpEdit_Nhansu_Nhanhang.EditValue;

                identity = objWareService.Insert_Ware_Nhap_Hh_Mua(objWare_Nhap_Hh_Mua);

                if (identity != null)
                {
                    dgware_Nhap_Hh_Mua_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    foreach (DataRow dr in ds_Nhap_Hh_Mua_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Nhap_Hh_Mua"] = identity;
                    }
                    //update nhap_hh_mua_chitiet
                    objWareService.Update_Ware_Nhap_Hh_Mua_Chitiet_Collection(ds_Nhap_Hh_Mua_Chitiet);
                }

                //update don gia cho nhap kho
                objWareService.Ware_Nhap_Hh_Mua_Chitiet_UpdateDongia_FrHdmuahang(-1, identity);

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
                WareService.Ware_Nhap_Hh_Mua objWare_Nhap_Hh_Mua = new SunLine.Ware.WareService.Ware_Nhap_Hh_Mua();
                objWare_Nhap_Hh_Mua.Id_Nhap_Hh_Mua = identity;
                objWare_Nhap_Hh_Mua.Sochungtu = txtSochungtu.EditValue;
                objWare_Nhap_Hh_Mua.Nguoi_Giaohang = "" + txtNguoi_Giao_Hanghoa_Mua.EditValue;
                objWare_Nhap_Hh_Mua.Ghichu = "" + txtGhichu.EditValue;
                objWare_Nhap_Hh_Mua.Ngay_Nhanhang = dtNgay_Nhap_Hh_Mua.EditValue;

                if ("" + lookUpEdit_Kho_Hanghoa_Mua.EditValue != "")
                    objWare_Nhap_Hh_Mua.Id_Kho_Hanghoa_Mua = lookUpEdit_Kho_Hanghoa_Mua.EditValue;
                if ("" + lookUpEdit_Nhansu_Nhanhang.EditValue != "")
                    objWare_Nhap_Hh_Mua.Id_Nhansu_Nhanhang = lookUpEdit_Nhansu_Nhanhang.EditValue;
                //update nhap_hh_mua
                objWareService.Update_Ware_Nhap_Hh_Mua(objWare_Nhap_Hh_Mua);

                //update nhap_hh_mua_chitiet
                dgware_Nhap_Hh_Mua_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                foreach (DataRow dr in ds_Nhap_Hh_Mua_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Nhap_Hh_Mua"] = txtId_Nhap_Hh_Mua.EditValue;
                }
                //ds_Donmuahang_Chitiet.RejectChanges();
                objWareService.Update_Ware_Nhap_Hh_Mua_Chitiet_Collection(ds_Nhap_Hh_Mua_Chitiet);

                //update don gia cho nhap kho
                objWareService.Ware_Nhap_Hh_Mua_Chitiet_UpdateDongia_FrHdmuahang(-1, txtId_Nhap_Hh_Mua.EditValue);

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
            WareService.Ware_Nhap_Hh_Mua objWare_Nhap_Hh_Mua = new SunLine.Ware.WareService.Ware_Nhap_Hh_Mua();
            objWare_Nhap_Hh_Mua.Id_Nhap_Hh_Mua = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Mua");

            return objWareService.Delete_Ware_Nhap_Hh_Mua(objWare_Nhap_Hh_Mua);
        }

        public override bool PerformAdd()
        {
            dtNgay_Nhap_Hh_Mua.EditValue = DateTime.Now;
            lookUpEdit_Nhansu_Nhanhang.EditValue = Convert.ToInt64(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu());
            DataSet dsKho_Hanghoa_Mua = objMasterService.Get_All_Ware_Dm_Kho_Hanghoa_MuaBy_Id_Nhansu(lookUpEdit_Nhansu_Nhanhang.EditValue);
            if (dsKho_Hanghoa_Mua.Tables[0].Rows.Count > 0)
                lookUpEdit_Kho_Hanghoa_Mua.EditValue = dsKho_Hanghoa_Mua.Tables[0].Rows[0]["Id_Kho_Hanghoa_Mua"];
            else
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                lookUpEdit_Nhansu_Nhanhang.EditValue = null;
                return false;
            }
            
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();

            txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_nhap_hh_mua", "sochungtu", lookUpEdit_Kho_Hanghoa_Mua.GetColumnValue("Ma_Kho_Hanghoa_Mua"));
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
                hashtableControls.Add(txtSochungtu, lblSochungtu.Text);
                hashtableControls.Add(lookUpEdit_Kho_Hanghoa_Mua, lblKho.Text);
                hashtableControls.Add(lookUpEdit_Nhansu_Nhanhang, lblNguoi_Nhan_Hanghoa_Mua.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                //kiem tra trung hang hoa khi nhap lieu
                System.Collections.Hashtable hashtableUnique = new System.Collections.Hashtable();
                hashtableUnique.Add(gridView5.Columns["Id_Hanghoa_Mua"], gridView5.Columns["Id_Hanghoa_Mua"].Caption);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableUnique, gridView5))
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
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Nhap_Hh_Mua"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Nhap_Hh_Mua")   }) == DialogResult.Yes)
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
            WareService.Ware_Nhap_Hh_Mua ware_Nhap_Hh_Mua = new SunLine.Ware.WareService.Ware_Nhap_Hh_Mua();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Nhap_Hh_Mua.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Nhap_Hh_Mua.Id_Nhap_Hh_Mua = dr["Id_Nhap_Hh_Mua"];
                    ware_Nhap_Hh_Mua.Sochungtu = dr["Sochungtu"];
                    ware_Nhap_Hh_Mua.Nguoi_Giaohang = dr["Nguoi_Giaohang"];
                    ware_Nhap_Hh_Mua.Ngay_Nhanhang = dr["Ngay_Nhanhang"];
                    ware_Nhap_Hh_Mua.Id_Kho_Hanghoa_Mua = dr["Id_Kho_Hanghoa_Mua"];
                    ware_Nhap_Hh_Mua.Id_Nhansu_Nhanhang = dr["Id_Nhansu_Nhanhang"];
                    ware_Nhap_Hh_Mua.Ghichu = dr["Ghichu"];
                }
                this.Dispose();
                this.Close();
                return ware_Nhap_Hh_Mua;
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
            DataSets.DsNhap_Vattu dsWare_Nhap_Vattu = new SunLine.Ware.DataSets.DsNhap_Vattu();
            Reports.rptNhap_Vattu rptNhap_Vattu = new Reports.rptNhap_Vattu();
            GoobizFrame.Windows.Forms.FormReportWithHeader objFormReport = new GoobizFrame.Windows.Forms.FormReportWithHeader();
            objFormReport.Report = rptNhap_Vattu;
            rptNhap_Vattu.DataSource = dsWare_Nhap_Vattu;

            //Ware_Nhap_Vattu
            DataRow rWare_Nhap_Vattu = dsWare_Nhap_Vattu.Tables["ware_nhap_hh_mua"].NewRow();
            rWare_Nhap_Vattu["sochungtu"] = txtSochungtu.Text;
            rWare_Nhap_Vattu["ngay_nhanhang"] = dtNgay_Nhap_Hh_Mua.EditValue;
            rWare_Nhap_Vattu["nguoi_giaohang"] = txtNguoi_Giao_Hanghoa_Mua.Text;
            rWare_Nhap_Vattu["hoten_nhansu_nhanhang"] = lookUpEdit_Nhansu_Nhanhang.Text;
            rWare_Nhap_Vattu["ten_kho_hanghoa"] = lookUpEdit_Kho_Hanghoa_Mua.Text;
            dsWare_Nhap_Vattu.Tables["ware_nhap_hh_mua"].Rows.Add(rWare_Nhap_Vattu);
            //Ware_Nhap_Vattu_Chitiet
            for (int i = 0; i < gridView5.RowCount; i++)
            {
                DataRow rWare_Nhap_Vattu_Chitiet = dsWare_Nhap_Vattu.Tables["ware_nhap_hh_mua_chitiet"].NewRow();
                rWare_Nhap_Vattu_Chitiet["id_nhap_hh_mua_chitiet"] = i + 1;
                rWare_Nhap_Vattu_Chitiet["id_nhap_hh_mua"] = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Mua");
                rWare_Nhap_Vattu_Chitiet["ma_hanghoa"] = gridView5.GetRowCellDisplayText(i, gridColumn20);
                rWare_Nhap_Vattu_Chitiet["ten_hanghoa"] = gridView5.GetRowCellDisplayText(i, gridColumn14);
                rWare_Nhap_Vattu_Chitiet["ten_donvitinh"] = gridView5.GetRowCellDisplayText(i, "Id_Donvitinh");
                rWare_Nhap_Vattu_Chitiet["soluong"] = gridView5.GetRowCellDisplayText(i, "Soluong");
                dsWare_Nhap_Vattu.Tables["ware_nhap_hh_mua_chitiet"].Rows.Add(rWare_Nhap_Vattu_Chitiet);
            }
            dsWare_Nhap_Vattu.AcceptChanges();

            //rptNhap_Vattu.xrPictureBox1.Image = ERPMkg.Windows.MdiUtils.ThemeSettings.GetCompanyLogo();
            
            rptNhap_Vattu.CreateDocument();

            objFormReport.Text = this.Text + " [In]";
            objFormReport.printControl1.PrintingSystem = rptNhap_Vattu.PrintingSystem;
            objFormReport.MdiParent = this.MdiParent;
            objFormReport.Show();
            objFormReport.Activate();
            return true;
        }

        #endregion


        private void btnImport_Hanghoa_Mua_Click(object sender, EventArgs e)
        {
            Forms.Frmware_Donmuahang_Dialog frmware_Donmuahang_Dialog = new Frmware_Donmuahang_Dialog();
            frmware_Donmuahang_Dialog.StartPosition = FormStartPosition.CenterScreen;
            frmware_Donmuahang_Dialog.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            frmware_Donmuahang_Dialog.ShowDialog();
            if (frmware_Donmuahang_Dialog.dsSelected != null)
            {
                if (frmware_Donmuahang_Dialog.dsSelected.Tables.Count > 0)
                foreach (DataRow dr in frmware_Donmuahang_Dialog.dsSelected.Tables[0].Rows)
                {
                    DataRow newrow = ds_Nhap_Hh_Mua_Chitiet.Tables[0].NewRow();
                    foreach (DataColumn col in ds_Nhap_Hh_Mua_Chitiet.Tables[0].Columns)
                        try
                        {
                            newrow[col.ColumnName] = dr[col.ColumnName];
                        }
                        catch(Exception ex) { continue; }
                    ds_Nhap_Hh_Mua_Chitiet.Tables[0].Rows.Add(newrow);
                }
                dgware_Nhap_Hh_Mua_Chitiet.DataSource = ds_Nhap_Hh_Mua_Chitiet.Tables[0];
                //txtSotien.EditValue = gridView4.Columns["Thanhtien"].SummaryItem.SummaryValue;
            }
        }

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Soluong" || e.Column.FieldName == "Dongia")
                {
                    if ("" + gridView5.GetFocusedRowCellValue("Soluong") != ""
                        && "" + gridView5.GetFocusedRowCellValue("Dongia") != "")
                        gridView5.SetFocusedRowCellValue(gridView5.Columns["Thanhtien"], Convert.ToDecimal(gridView5.GetFocusedRowCellValue("Soluong"))
                                                                     * Convert.ToDecimal(gridView5.GetFocusedRowCellValue("Dongia"))
                                                        );
                }
                else if (e.Column.FieldName == "Id_Hanghoa_Mua")
                {
                    gridView5.SetFocusedRowCellValue(gridView5.Columns["Id_Donvitinh"]
                        , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Mua.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);
                    gridView5.SetFocusedRowCellValue(gridView5.Columns["Barcode_Txt"]
                       , DateTime.Now.Ticks);
                }
            }
            catch { }
        }

        void DisplayInfo2()
        {
            try
            {
                identity = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Mua");
                this.ds_Nhap_Hh_Mua_Chitiet = objWareService.Get_All_Ware_Nhap_Hh_Mua_Chitiet_By_Nhap_Hh_Mua(identity);
                this.dgware_Nhap_Hh_Mua_Chitiet.DataSource = ds_Nhap_Hh_Mua_Chitiet;
                this.dgware_Nhap_Hh_Mua_Chitiet.DataMember = ds_Nhap_Hh_Mua_Chitiet.Tables[0].TableName;

                gridView5.BestFitColumns();
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

        private void lookUpEdit_Kho_Hanghoa_Mua_EditValueChanged(object sender, EventArgs e)
        {
            try {
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add) 
                    txtSochungtu.EditValue = objWareService.GetNew_Sochungtu(
                        "ware_nhap_hh_mua"
                        , "sochungtu"
                        , lookUpEdit_Kho_Hanghoa_Mua.GetColumnValue("Ma_Kho_Hanghoa_Mua"));
                dsHanghoa_Mua = objMasterService.Get_All_Ware_Dm_Hanghoa_MuaBy_Id_Kho_Hh_Mua(lookUpEdit_Kho_Hanghoa_Mua.EditValue, dtNgay_Nhap_Hh_Mua.EditValue);
            }
            catch { }
        }

        //private void gridLookUpEdit_Hanghoa_Mua_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
        //    {
        //        SunLine.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Mua_Dialog frmware_Dm_Hanghoa_Mua_Dialog = new SunLine.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Mua_Dialog();
        //        frmware_Dm_Hanghoa_Mua_Dialog.Text = "Hàng hóa";
        //        GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Mua_Dialog);
        //        frmware_Dm_Hanghoa_Mua_Dialog.Id_Kho_Hanghoa_Mua = lookUpEdit_Kho_Hanghoa_Mua.EditValue;
        //        frmware_Dm_Hanghoa_Mua_Dialog.ShowDialog();

        //        if (frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows != null
        //            && frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows.Length > 0)
        //        {
        //            //gridLookUpEdit_Hanghoa_Mua.DataSource = frmware_Dm_Hanghoa_Mua_Dialog.Data.Tables[0];

        //            gridView5.SetFocusedRowCellValue(gridView5.Columns["Id_Hanghoa_Mua"]
        //                , frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[0]["Id_Hanghoa_Mua"]);
        //            gridView5.SetFocusedRowCellValue(gridView5.Columns["Id_Donvitinh"]
        //                , frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[0]["Id_Donvitinh"]);
        //            gridView5.SetFocusedRowCellValue(gridView5.Columns["Barcode_Txt"]
        //                , DateTime.Now.Ticks);

        //            //object Id_Cuahang_Mua = gridView1.GetFocusedRowCellValue("Id_Cuahang_Mua");
        //            if (frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows.Length > 1)
        //            {
        //                for (int i = 1; i < frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows.Length; i++)
        //                {
        //                    DataRow nrow = ds_Nhap_Hh_Mua_Chitiet.Tables[0].NewRow();
        //                    //nrow["Id_Cuahang_Mua"] = Id_Cuahang_Mua;
        //                    nrow["Id_Hanghoa_Mua"]  = frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[i]["Id_Hanghoa_Mua"];
        //                    nrow["Id_Donvitinh"]    = frmware_Dm_Hanghoa_Mua_Dialog.SelectedRows[i]["Id_Donvitinh"];
        //                    nrow["Barcode_Txt"]     = DateTime.Now.Ticks;
        //                    ds_Nhap_Hh_Mua_Chitiet.Tables[0].Rows.Add(nrow);
        //                }
        //            }
        //        }
        //    }
        //}

    }
}

