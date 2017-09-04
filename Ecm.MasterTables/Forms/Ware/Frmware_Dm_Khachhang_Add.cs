using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using System.Text.RegularExpressions;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Khachhang_Add : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        DataSet ds_Collection = new DataSet();
        private Ecm.WebReferences.MasterService.Ware_Dm_Khachhang ware_Dm_Khachhang = new Ecm.WebReferences.MasterService.Ware_Dm_Khachhang();
        private GoobizFrame.Windows.Public.OrderHashtable infoControls = new GoobizFrame.Windows.Public.OrderHashtable();
        public long[] Id_Khachhang;
        public bool filter = false;


        public Ecm.WebReferences.MasterService.Ware_Dm_Khachhang SelectedWare_Dm_Khachhang
        {
            get { return ware_Dm_Khachhang; }
            set { ware_Dm_Khachhang = value; }
        }

        public Frmware_Dm_Khachhang_Add()
        {
            InitializeComponent();
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            xtraTabControl1.TabPages[1].PageVisible = false;
            this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //this.DisplayInfo();
            //infoControls.Add(txtTen_Khachhang, "Tên Khách hàng yêu cầu nhập");
            //infoControls.Add(txtCmnd, "CMND  yêu cầu nhập");
            //infoControls.Add(txtDienthoai, "Điện thoại yêu cầu nhập");
        }

        public override void DisplayInfo()
        {
            try
            {
                var ds = objMasterService.Get_All_Ware_Dm_Nganhang().ToDataSet();
                lookupEdit_Nganhang.Properties.DataSource = ds.Tables[0];
                gridLookupEdit_Nganhang.DataSource = ds.Tables[0];

                ds = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet();
                lookupEditKhuvuc.Properties.DataSource = ds.Tables[0];
                lookupEdit_Search_Khuvuc.Properties.DataSource = ds.Tables[0];
                gridLookupEdit_Khuvuc.DataSource = ds.Tables[0];

                ds_Collection = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                if (!ds_Collection.Tables[0].Columns.Contains("Chon"))
                    ds_Collection.Tables[0].Columns.Add("Chon", typeof(bool));
                dgware_Dm_Khachhang.DataSource = ds_Collection;
                dgware_Dm_Khachhang.DataMember = ds_Collection.Tables[0].TableName;
                //format ngay sinh theo dd/MM/yyyy (varchar)
                //foreach (DataRow row_Khachhang in ds_Collection.Tables[0].Rows)
                //    row_Khachhang["Ngay_Sinh"] = GoobizFrame.Windows.MdiUtils.DateTimeMask.YMDToShortDatePattern("" + row_Khachhang["Ngay_Sinh"],
                //         GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat());
                ds_Collection.AcceptChanges();
                this.ChangeStatus(false);
                //this.Data = ds_Collection;
                //this.GridControl = dgware_Dm_Khachhang;
                this.DataBindingControl();
                this.gvDm_Khahhang.BestFitColumns();
                btnKetchuyen.Enabled = true;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                //// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ClearDataBindings()
        {
            this.txtMa_Khachhang.DataBindings.Clear();
            this.txtTen_Khachhang.DataBindings.Clear();
            this.txtDiachi_Khachhang.DataBindings.Clear();
            this.txtMasothue.DataBindings.Clear();
            this.txtDienthoai.DataBindings.Clear();
            this.txtNguoi_Daidien.DataBindings.Clear();
            //this.txtDinhmuc_No.DataBindings.Clear();            
            //this.chkTochuc.DataBindings.Clear();
            this.txtSotaikhoan.DataBindings.Clear();
            this.lookupEdit_Nganhang.DataBindings.Clear();
            this.lookupEditKhuvuc.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Khachhang.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Khachhang");
                this.txtTen_Khachhang.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ten_Khachhang");
                this.txtDiachi_Khachhang.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Diachi_Khachhang");
                this.txtMasothue.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Masothue");
                this.txtDienthoai.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Dienthoai");
                this.txtNguoi_Daidien.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Nguoi_Daidien");
                //this.txtDinhmuc_No.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Dinhmuc_No");               
                //this.chkTochuc.DataBindings.Add("Checked", ds_Collection, ds_Collection.Tables[0].TableName + ".Pb_Tochuc");
                this.txtSotaikhoan.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Sotaikhoan");
                this.lookupEdit_Nganhang.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Nganhang");
                this.lookupEditKhuvuc.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Khuvuc");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                //// GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgware_Dm_Khachhang.Enabled = !editTable;
            //this.panelControl_Import_Nhansu.Enabled = !editTable;
            //this.gvDm_Khahhang.OptionsBehavior.Editable = editTable;
            //this.gvDm_Khahhang.OptionsBehavior.ReadOnly = !editTable;
            this.txtMa_Khachhang.Properties.ReadOnly = !editTable;
            this.txtTen_Khachhang.Properties.ReadOnly = !editTable;
            this.txtDiachi_Khachhang.Properties.ReadOnly = !editTable;
            this.txtMasothue.Properties.ReadOnly = !editTable;
            this.txtDienthoai.Properties.ReadOnly = !editTable;
            this.txtNguoi_Daidien.Properties.ReadOnly = !editTable;
            this.txtSotaikhoan.Properties.ReadOnly = !editTable;
            this.lookupEdit_Nganhang.Properties.ReadOnly = !editTable;
            this.lookupEditKhuvuc.Properties.ReadOnly = !editTable;
            this.btnSearch.Enabled = !editTable;
            //this.chkTochuc.Enabled = editTable;
            this.btnAdd_n_InitInfo.Enabled = false;
            //gridColumn10.OptionsColumn.AllowEdit = !editTable;
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvDm_Khahhang.Columns)
            {
                if (col.Name == "gridColumn10")
                    col.OptionsColumn.AllowEdit = !editTable;
                else
                    col.OptionsColumn.AllowEdit = editTable;
            }
            xtraHNavigator1.Enabled = editTable;
        }

        public override void ResetText()
        {
            this.txtMa_Khachhang.EditValue = string.Empty;
            this.txtTen_Khachhang.EditValue = string.Empty;
            this.txtDiachi_Khachhang.EditValue = string.Empty;
            this.txtMasothue.EditValue = string.Empty;
            this.txtDienthoai.EditValue = string.Empty;
            this.txtNguoi_Daidien.EditValue = string.Empty;
            //this.chkTochuc.Checked = false;
            this.txtSotaikhoan.EditValue = string.Empty;
            this.lookupEdit_Nganhang.EditValue = null;
            this.lookupEditKhuvuc.EditValue = null;
        }

        #region Event Override Insert - Update - Delete, sự kiện trên button và form
        public object InsertObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Khachhang objWare_Dm_Khachhang = new Ecm.WebReferences.MasterService.Ware_Dm_Khachhang();
            objWare_Dm_Khachhang.Id_Khachhang = -1;
            objWare_Dm_Khachhang.Ma_Khachhang = txtMa_Khachhang.EditValue;
            objWare_Dm_Khachhang.Ten_Khachhang = txtTen_Khachhang.EditValue;
            objWare_Dm_Khachhang.Diachi_Khachhang = txtDiachi_Khachhang.EditValue;
            objWare_Dm_Khachhang.Masothue = txtMasothue.EditValue;
            objWare_Dm_Khachhang.Dienthoai = txtDienthoai.EditValue;
            objWare_Dm_Khachhang.Fax = txtNguoi_Daidien.EditValue;
            objWare_Dm_Khachhang.Sotaikhoan = txtSotaikhoan.EditValue + "";
            objWare_Dm_Khachhang.Id_Nganhang = (lookupEdit_Nganhang.EditValue + "" == "") ? null : lookupEdit_Nganhang.EditValue;
            objWare_Dm_Khachhang.Id_Khuvuc = (lookupEditKhuvuc.EditValue + "" == "") ? null : lookupEditKhuvuc.EditValue;
            //objWare_Dm_Khachhang.Congno_Thang = (lookupEditKhuvuc.EditValue + "" == "") ? null : lookupEditKhuvuc.EditValue;
            //objWare_Dm_Khachhang.Pb_Tochuc = chkTochuc.Checked;
            return objMasterService.Insert_Ware_Dm_Khachhang(objWare_Dm_Khachhang);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Khachhang objWare_Dm_Khachhang = new Ecm.WebReferences.MasterService.Ware_Dm_Khachhang();
            objWare_Dm_Khachhang.Id_Khachhang = gvDm_Khahhang.GetFocusedRowCellValue("Id_Khachhang");
            objWare_Dm_Khachhang.Ma_Khachhang = txtMa_Khachhang.EditValue;
            objWare_Dm_Khachhang.Ten_Khachhang = txtTen_Khachhang.EditValue;

            if ("" + txtDiachi_Khachhang.EditValue == "")
                objWare_Dm_Khachhang.Diachi_Khachhang = null;
            else
                objWare_Dm_Khachhang.Diachi_Khachhang = txtDiachi_Khachhang.EditValue;

            if ("" + txtMasothue.EditValue == "")
                objWare_Dm_Khachhang.Masothue = null;
            else
                objWare_Dm_Khachhang.Masothue = txtMasothue.EditValue;

            if ("" + txtDienthoai.EditValue == "")
                objWare_Dm_Khachhang.Dienthoai = null;
            else
                objWare_Dm_Khachhang.Dienthoai = txtDienthoai.EditValue;

            if ("" + txtNguoi_Daidien.EditValue == "")
                objWare_Dm_Khachhang.Fax = null;
            else
                objWare_Dm_Khachhang.Fax = txtNguoi_Daidien.EditValue;

            objWare_Dm_Khachhang.Sotaikhoan = txtSotaikhoan.EditValue + "";
            objWare_Dm_Khachhang.Id_Nganhang = (lookupEdit_Nganhang.EditValue + "" == "") ? null : lookupEdit_Nganhang.EditValue;
            objWare_Dm_Khachhang.Id_Khuvuc = (lookupEditKhuvuc.EditValue + "" == "") ? null : lookupEditKhuvuc.EditValue;
            //objWare_Dm_Khachhang.Pb_Tochuc = chkTochuc.Checked;
            return objMasterService.Update_Ware_Dm_Khachhang(objWare_Dm_Khachhang);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Khachhang objWare_Dm_Khachhang = new Ecm.WebReferences.MasterService.Ware_Dm_Khachhang();
            objWare_Dm_Khachhang.Id_Khachhang = gvDm_Khahhang.GetFocusedRowCellValue("Id_Khachhang");
            return objMasterService.Delete_Ware_Dm_Khachhang(objWare_Dm_Khachhang);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            //this.SetInformation(infoControls);
            txtMa_Khachhang.EditValue = objMasterService.GetNew_Sochungtu("Ware_Dm_Khachhang", "Ma_Khachhang", "");
            return true;
        }

        public override bool PerformEdit()
        {
            this.ChangeStatus(true);
            //this.SetInformation(infoControls);
            return true;
        }

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            return PerformSaveChanges();
            //try
            //{
            //    bool success = false;
            //    GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            //    hashtableControls.Add(txtMa_Khachhang, lblMa_Khachhang.Text);
            //    hashtableControls.Add(txtTen_Khachhang, lblTen_Khachhang.Text);

            //    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
            //        return false;

            //    if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
            //    {
            //        success = (bool)this.InsertObject();
            //    }
            //    else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
            //    {
            //        success = (bool)this.UpdateObject();
            //    }
            //    if (success)
            //        this.DisplayInfo();
            //    return success;
            //}
            //catch (Exception ex)
            //{
            //    if (ex.ToString().IndexOf("exists_Ma_Khachhang") != -1)
            //    {
            //        GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Khachhang.Text, lblMa_Khachhang.Text.ToLower() });
            //    }
            //    else if (ex.ToString().IndexOf("exists_Masothue") != -1)
            //    {
            //        GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMasothue.Text, lblMasothue.Text.ToLower() });
            //    }
            //    return false;
            //}
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gvDm_Khahhang.Columns["Ma_Khachhang"], "");
            hashtableControls.Add(gvDm_Khahhang.Columns["Ten_Khachhang"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvDm_Khahhang))
                return false;

            //format ngay sinh theo YYYMMDD (varchar)
            //foreach (DataRow row_Khachhang in ds_Collection.Tables[0].Rows)
            //    try
            //    {
            //        if (row_Khachhang.RowState == DataRowState.Added || row_Khachhang.RowState == DataRowState.Modified)
            //            row_Khachhang["Ngay_Sinh"] = GoobizFrame.Windows.MdiUtils.DateTimeMask.YMDFromShortDatePattern("" + row_Khachhang["Ngay_Sinh"],
            //                 GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat());
            //    }
            //    catch { continue; }
            try
            {
                dgware_Dm_Khachhang.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Khachhang.EmbeddedNavigator.Buttons.EndEdit);
                ds_Collection.Tables[0].Columns["Ma_Khachhang"].Unique = true;
                //ds_Collection.Tables[0].Columns["Masothue"].Unique = true;
                objMasterService.Update_Ware_Dm_Khachhang_Collection(this.ds_Collection.GetChanges());
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1 && ex.ToString().IndexOf("Ma_Khachhang") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Khachhang.Text, lblMa_Khachhang.Text.ToLower() });
                    return false;
                }
                else if (ex.ToString().IndexOf("Unique") != -1 && ex.ToString().IndexOf("Masothue") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMasothue.Text, lblMasothue.Text.ToLower() });
                    return false;
                }
                //MessageBox.Show(ex.ToString());
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformDelete()
        {
            object id_khachhang = this.gvDm_Khahhang.GetFocusedRowCellValue("Id_Khachhang");
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Dm_Khachhang"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Dm_Khachhang")   }) == DialogResult.Yes)
            {
                try
                {
                    objMasterService.Delete_Ware_Khachhang_Quota(id_khachhang);
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Khachhang", "Id_Khachhang", id_khachhang)) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        return true;
                    }
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    // GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            //Ecm.WebReferences.MasterService.Ware_Dm_Khachhang ware_Dm_Khachhang = new Ecm.WebReferences.MasterService.Ware_Dm_Khachhang();
            try
            {
                int focusedRow = gvDm_Khahhang.GetDataSourceRowIndex(gvDm_Khahhang.FocusedRowHandle);
                DataRow dr = ds_Collection.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Khachhang.Id_Khachhang = dr["Id_Khachhang"];
                    ware_Dm_Khachhang.Ma_Khachhang = dr["Ma_Khachhang"];
                    ware_Dm_Khachhang.Ten_Khachhang = dr["Ten_Khachhang"];
                    ware_Dm_Khachhang.Diachi_Khachhang = dr["Diachi_Khachhang"];
                    ware_Dm_Khachhang.Cmnd = dr["Cmnd"];
                    ware_Dm_Khachhang.Masothue = dr["Masothue"];
                    ware_Dm_Khachhang.Dienthoai = dr["Dienthoai"];
                    ware_Dm_Khachhang.Fax = dr["Fax"];
                    ware_Dm_Khachhang.Email = dr["Email"];
                    ware_Dm_Khachhang.Website = dr["Website"];
                }
                this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.View);
                int[] Id_Khachhang_Chon = gvDm_Khahhang.GetSelectedRows();
                Id_Khachhang = new long[Id_Khachhang_Chon.Length];
                for (int i = 0; i < Id_Khachhang.Length; i++)
                {
                    Id_Khachhang[i] = Convert.ToInt64(gvDm_Khahhang.GetRowCellValue(Id_Khachhang_Chon[i], "Id_Khachhang"));
                }
                this.Dispose();
                this.Close();
                return base.PerformSelectOneObject();
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
            try
            {
                DataSets.DsWare_Dm_Khachhang _DsWare_Dm_Khachhang = new DataSets.DsWare_Dm_Khachhang();
                Reports.rptWare_Dm_Khachhang _rptWare_Dm_Khachhang = new Reports.rptWare_Dm_Khachhang();
                GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                frmPrintPreview.Report = _rptWare_Dm_Khachhang;
                //frmPrintPreview.Name = this.Name;
                //frmPrintPreview.EnablePrintPreview = this.EnablePrintPreview;
                _rptWare_Dm_Khachhang.DataSource = _DsWare_Dm_Khachhang;
                foreach (DataRow dr in ds_Collection.Tables[0].Select("Chon = True", ""))
                {
                    DataRow drnew = _DsWare_Dm_Khachhang.Tables[0].NewRow();
                    foreach (DataColumn dc in ds_Collection.Tables[0].Columns)
                    {
                        try
                        {
                            drnew[dc.ColumnName] = dr[dc.ColumnName];
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    _DsWare_Dm_Khachhang.Tables[0].Rows.Add(drnew);
                }
                //add parameter values
                #region Set he so ctrinh - logo, ten cty
                using (DataSet dsCompany_Paras = new DataSet())
                {
                    dsCompany_Paras.Tables.Add("Company_Paras");
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
                    dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

                    DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet();
                    byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

                    dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
                    dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
                    ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
                    ,imageData});

                    _rptWare_Dm_Khachhang.xrc_CompanyName.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                    _rptWare_Dm_Khachhang.xrc_CompanyAddress.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                }
                #endregion

                _rptWare_Dm_Khachhang.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(_rptWare_Dm_Khachhang);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    frmPrintPreview.Text = "" + oReportOptions.Caption;
                    frmPrintPreview.printControl1.PrintingSystem = _rptWare_Dm_Khachhang.PrintingSystem;
                    frmPrintPreview.MdiParent = this.MdiParent;
                    frmPrintPreview.Text = this.Text + "(Xem trang in)";
                    frmPrintPreview.Show();
                    frmPrintPreview.Activate();
                }
                else
                {
                    var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(_rptWare_Dm_Khachhang);
                    reportPrintTool.Print();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
            return base.PerformPrintPreview();
        }
        #endregion

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvDm_Khahhang.SetFocusedRowCellValue(gvDm_Khahhang.Columns["Ma_Khachhang"], objMasterService.GetNew_Sochungtu("Ware_Dm_Khachhang", "Ma_Khachhang", ""));
            gvDm_Khahhang.SetFocusedRowCellValue("Congno_Thang", 0);
            gvDm_Khahhang.SetFocusedRowCellValue("Danhdau_Xoa", 0);
            this.addnewrow_clicked = true;
            //ClearDataBindings();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            this.dgware_Dm_Khachhang.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Khachhang.EmbeddedNavigator.Buttons.EndEdit);
        }

        private void dgware_Dm_Khachhang_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (this.gvDm_Khahhang.GetFocusedDataRow().RowState != DataRowState.Added)
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Khachhang", "Id_Khachhang", this.gvDm_Khahhang.GetFocusedRowCellValue("Id_Khachhang"))) > 0)
                    {
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
            }
        }

        //private void btnPrint_Card_Click(object sender, EventArgs e)
        //{
        //    PrintCard();
        //    //this.item_Cancel.PerformClick();
        //}

        void PrintCard()
        {
            //if (ds_Collection.Tables[0].Select("Chon=True").Length == 0)
            //    GoobizFrame.Windows.Forms.MessageDialog.Show("Xin vui lòng chọn khách hàng để in.");
            //else
            //{
            //    this.DoClickEndEdit(dgware_Dm_Khachhang);
            //    DataSet dsPrint = ds_Collection.Clone();
            //    foreach (DataRow row in ds_Collection.Tables[0].Select("Chon=True"))
            //    {
            //        dsPrint.Tables[0].ImportRow(row);
            //    }

            //    Reports.rptWare_Khachhang_Barcode rptWare_Khachhang_Barcode = new Ecm.MasterTables.Reports.rptWare_Khachhang_Barcode();
            //    rptWare_Khachhang_Barcode.DataSource = dsPrint.Tables[0];
            //    rptWare_Khachhang_Barcode.CreateDocument();

            //    if (frmPrintPreview == null || frmPrintPreview.IsDisposed) frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            //    frmPrintPreview.printControl1.PrintingSystem = rptWare_Khachhang_Barcode.PrintingSystem;
            //    frmPrintPreview.MdiParent = this.MdiParent;
            //    frmPrintPreview.Text = this.Text + @"(Xem trang in)";
            //    frmPrintPreview.Report = rptWare_Khachhang_Barcode;
            //    frmPrintPreview.Show();
            //    frmPrintPreview.Activate();
            //}
        }

        private void gridText_Dinhmuc_No_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.ToString() == "")
            {
                gvDm_Khahhang.SetFocusedRowCellValue("Dinhmuc_No", null);
                e.Cancel = true;
                return;
            }
            if (e.NewValue.ToString().Length > 9)
                e.Cancel = true;
        }

        private void xtraHNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (this.gvDm_Khahhang.GetFocusedDataRow().RowState != DataRowState.Added)
                {
                    try
                    {
                        objMasterService.CheckDelete_Ware_Dm_Khachhang(gvDm_Khahhang.GetFocusedRowCellValue("Id_Khachhang"));
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                        GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ds_Collection = objMasterService.Search_Ware_Dm_Khachhang(new WebReferences.MasterService.Ware_Dm_Khachhang()
                {
                    Ma_Khachhang = ("" + txtSearch_Ma_Khachhang.EditValue != "") ? txtSearch_Ma_Khachhang.EditValue : null,
                    Ten_Khachhang = ("" + txtSearch_Ten_Khachhang.EditValue != "") ? txtSearch_Ten_Khachhang.EditValue : null,
                    Diachi_Khachhang = ("" + txtSearch_Diachi_Khachhang.EditValue != "") ? txtSearch_Diachi_Khachhang.EditValue : null,
                    Dienthoai = ("" + txtSearch_Dienthoai.EditValue != "") ? txtSearch_Dienthoai.EditValue : null,
                    Masothue = ("" + txtSearch_Masothue.EditValue != "") ? txtSearch_Masothue.EditValue : null,
                    //Dinhmuc_No = ("" + txtSearch_Dinhmuc_No.EditValue != "") ? txtSearch_Dinhmuc_No.EditValue : null,
                    //Pb_Tochuc = (chk_Search_Tochuc.Checked) ? chk_Search_Tochuc.Checked : false,
                    Sotaikhoan = ("" + txtSearch_Sotaikhoan.EditValue != "") ? txtSearch_Sotaikhoan.EditValue : null,
                    Id_Nganhang = ("" + lookUpEdit_Search_Nganhang.EditValue != "") ? lookUpEdit_Search_Nganhang.EditValue : null,
                    Id_Khuvuc = ("" + lookupEdit_Search_Khuvuc.EditValue != "") ? lookupEdit_Search_Khuvuc.EditValue : null
                }).ToDataSet();
            dgware_Dm_Khachhang.DataSource = ds_Collection;
            dgware_Dm_Khachhang.DataMember = ds_Collection.Tables[0].TableName;
            //format ngay sinh theo dd/MM/yyyy (varchar)
            foreach (DataRow row_Khachhang in ds_Collection.Tables[0].Rows)
                row_Khachhang["Ngay_Sinh"] = GoobizFrame.Windows.MdiUtils.DateTimeMask.YMDToShortDatePattern("" + row_Khachhang["Ngay_Sinh"],
                     GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat());

            ds_Collection.AcceptChanges();
            this.ChangeStatus(false);
            btnAdd_n_InitInfo.Enabled = (ds_Collection.Tables.Count > 0) && (ds_Collection.Tables[0].Rows.Count == 0);
        }

        private void btnAdd_n_InitInfo_Click(object sender, EventArgs e)
        {
            this.item_Add.PerformClick();
            //txtMa_Khachhang.EditValue = txtSearch_Ma_Khachhang.EditValue;
            txtTen_Khachhang.EditValue = txtSearch_Ten_Khachhang.EditValue;
            txtDiachi_Khachhang.EditValue = txtSearch_Diachi_Khachhang.EditValue;
            txtDienthoai.EditValue = txtSearch_Dienthoai.EditValue;
            txtMasothue.EditValue = txtSearch_Masothue.EditValue;
            //txtDinhmuc_No.EditValue = txtSearch_Dinhmuc_No.EditValue;
            //chkTochuc.Checked = chk_Search_Tochuc.Checked;
            txtSearch_Sotaikhoan.EditValue = txtSotaikhoan.EditValue;
            lookupEdit_Nganhang.EditValue = lookUpEdit_Search_Nganhang.EditValue;
            lookupEditKhuvuc.EditValue = lookUpEdit_Search_Nganhang.EditValue;
            xtraTabControl1.SelectedTabPage = xtraTabPage_Info;
        }

        private void Frmware_Dm_Khachhang_Add_Load(object sender, EventArgs e)
        {
            DisplayInfo();
            if (filter)
            {
                gvDm_Khahhang.Columns["Pb_Tochuc"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(gvDm_Khahhang.Columns["Pb_Tochuc"], false);
                this.gvDm_Khahhang.OptionsBehavior.AutoExpandAllGroups = true;
            }
        }

        private void lookupEdit_Nganhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus
                && FormState != GoobizFrame.Windows.Forms.FormState.View)
            {
                MasterTables.Forms.Ware.Frmware_Dm_Nganhang_Add frmNganhang = new Frmware_Dm_Nganhang_Add();
                frmNganhang.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                frmNganhang.ShowDialog();
                if (frmNganhang.ware_Dm_Nganhang != null)
                {
                    var dsNganhang = objMasterService.Get_All_Ware_Dm_Nganhang().ToDataSet();
                    lookupEdit_Nganhang.Properties.DataSource = dsNganhang.Tables[0];
                    gridLookupEdit_Nganhang.DataSource = dsNganhang.Tables[0];
                    lookupEdit_Nganhang.EditValue = frmNganhang.ware_Dm_Nganhang.Id_Nganhang;
                }
            }
        }

        private void lookupEdit_Search_Khuvuc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookupEdit_Search_Khuvuc.EditValue = null;
        }

        private void btnKetchuyen_Click(object sender, EventArgs e)
        {
            DataSet dsKhachhang_New = objWareService.Ware_Congtac_SelectKhachhang_New().ToDataSet();
            DataRow dtr_new;
            foreach (DataRow row in dsKhachhang_New.Tables[0].Rows)
            {
                dtr_new = ds_Collection.Tables[0].NewRow();
                dtr_new["Ten_Khachhang"] = row["Ten_Khachhang"];
                dtr_new["Diachi_Khachhang"] = row["Diachi"];
                dtr_new["Dienthoai"] = row["Dienthoai"];
                dtr_new["Nguoi_Daidien"] = row["Nguoi_Daidien"];
                ds_Collection.Tables[0].Rows.Add(dtr_new);
            }
            dgware_Dm_Khachhang.DataSource = ds_Collection.Tables[0];
            btnKetchuyen.Enabled = false;
        }

        private void checkEdit_ChonAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow row in ds_Collection.Tables[0].Rows)
            {
                row["Chon"] = checkEdit_ChonAll.Checked;
            }
        }

    }
}

