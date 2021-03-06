#region edit
/*
 * edit     phuongphan
 * date     04/04/2011
 * content  edit GUI
 * ---
 */
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using Ecm.WebReferences.Classes;
using GoobizFrame.Windows.MdiUtils;

namespace Ecm.Rex.Forms
{
    public partial class Frmrex_Hopdong_Laodong : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Collection = new DataSet();
        DataSet ds_Nhansu = new DataSet();
        DataSet ds_Nghiviec = new DataSet();
        DataSet ds_Tamhoan = new DataSet();
        DataSet ds_Loai_HDLD = new DataSet();
        object Id_Bophan;
        DevExpress.XtraTreeList.Nodes.TreeListNode focusedNode;

        Frmrex_Hopdong_Laodong_InfoBP frmrex_Hopdong_Laodong_InfoBP;

        public Frmrex_Hopdong_Laodong()
        {
            InitializeComponent();

            dtNgay_Batdau.Properties.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Ketthuc.Properties.MinValue = new DateTime(2000, 01, 01);
            gridDate_Ngay_Batdau.Properties.MinValue = new DateTime(2000, 01, 01);
            gridDate_Ngaybatdau_Tamhoan.Properties.MinValue = new DateTime(2000, 01, 01);
            gridDate_Ngayketthuc_Tamhoan.Properties.MinValue = new DateTime(2000, 01, 01);
            gridDate_Ngay_Hopdong.Properties.MinValue = new DateTime(2000, 01, 01);
            gridDate_Ngay_Nghiviec.Properties.MinValue = new DateTime(2000, 01, 01);
            //datetime mask
            dtNgay_Batdau.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Batdau.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            dtNgay_Ketthuc.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Ketthuc.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            gridDate_Ngay_Batdau.Mask.UseMaskAsDisplayFormat = true;
            gridDate_Ngay_Batdau.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            gridDate_Ngaybatdau_Tamhoan.Mask.UseMaskAsDisplayFormat = true;
            gridDate_Ngaybatdau_Tamhoan.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            gridDate_Ngayketthuc_Tamhoan.Mask.UseMaskAsDisplayFormat = true;
            gridDate_Ngayketthuc_Tamhoan.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            gridDate_Ngay_Hopdong.Mask.UseMaskAsDisplayFormat = true;
            gridDate_Ngay_Hopdong.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();

            gridDate_Ngay_Nghiviec.Mask.UseMaskAsDisplayFormat = true;
            gridDate_Ngay_Nghiviec.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            this.DisplayInfo();
            GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);
            btnCapnhat_Nhanvien.Enabled = EnableEdit;
            btnCapnhat_Phuluc.Enabled = EnableEdit;
        }

        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                //Get data master table REX
                ds_Loai_HDLD = objMasterService.Get_All_Rex_Dm_Loai_Hopdong_Collection().ToDataSet();
                lookUp_Loai_Hopdong.Properties.DataSource = ds_Loai_HDLD.Tables[0];
                gridLookUp_Loai_Hopdong.DataSource = ds_Loai_HDLD.Tables[0];
                gridLookUpEdit_Loai_Hopdong_2.DataSource = ds_Loai_HDLD.Tables[0];
                //deonguyen
                DataSet ds_Quyetdinh = objMasterService.Get_All_Rex_Dm_Quyetdinh_Collection().ToDataSet();
                gridLookUp_Quyetdinh_Nghiviec.DataSource = ds_Quyetdinh.Tables[0];
                gridLookUp_Quyetdinh_Tanhoan.DataSource = ds_Quyetdinh.Tables[0];

                gridLookUp_Nhansu.DataSource = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet().Tables[0];
                //TreeList
                DataSet ds_Bophan = objMasterService.Get_All_Rex_Dm_Bophan_Collection().ToDataSet();
                treeListColumn1.TreeList.DataSource = ds_Bophan.Tables[0];
                this.ChangeStatus(true);
                this.gvrex_Hopdong_Laodong.OptionsBehavior.Editable = false;
                this.panelControl3.Enabled = true;
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
            this.txtMa_Hopdong_Laodong.DataBindings.Clear();
            this.lookUp_Loai_Hopdong.DataBindings.Clear();
            this.txtHoten_Nhansu.DataBindings.Clear();
            this.lookUp_Nhansu.DataBindings.Clear();
            this.dtNgay_Batdau.DataBindings.Clear();
            this.dtNgay_Ketthuc.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                txtMa_Hopdong_Laodong.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Hopdong_Laodong");
                dtNgay_Batdau.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ngay_Batdau");
                dtNgay_Ketthuc.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ngay_Ketthuc");
                txtHoten_Nhansu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Hoten");
                lookUp_Nhansu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Nhansu_Nld");
                lookUp_Loai_Hopdong.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Loai_Hopdong");
                txtGhichu.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ghichu");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public override void ChangeStatus(bool editable)
        {
            this.treeList_Bophan.Enabled = editable;
            this.txtHoten_Nhansu.Properties.ReadOnly = true;
            txtMa_Hopdong_Laodong.Properties.ReadOnly = true;
            dtNgay_Batdau.Properties.ReadOnly = editable;
            dtNgay_Ketthuc.Properties.ReadOnly = editable;
            lookUp_Loai_Hopdong.Properties.ReadOnly = editable;
            lookUp_Nhansu.Properties.ReadOnly = editable;
            txtGhichu.Properties.ReadOnly = editable;
            dgrex_Hopdong_Laodong.Enabled = editable;

            gridView_Tamhoan.OptionsBehavior.Editable = !editable;
            gridView_Nghiviec.OptionsBehavior.Editable = !editable;
            //if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
            //{
            //    dgNghiviec.Enabled = false;
            //    dgTamhoan_Hopdong.Enabled = false;
            //}
            //else
            //{
            //    dgNghiviec.Enabled = true;
            //    dgTamhoan_Hopdong.Enabled = true;
            //}
        }

        public override void ResetText()
        {
            this.txtMa_Hopdong_Laodong.Text = "";
            this.dtNgay_Batdau.EditValue = null;
            this.dtNgay_Ketthuc.EditValue = null;
            this.lookUp_Loai_Hopdong.EditValue = null;
            this.lookUp_Nhansu.EditValue = null;
            this.txtGhichu.Text = "";
            this.txtHoten_Nhansu.Text = "";
            this.dgTamhoan_Hopdong.DataSource = null;
            this.dgNghiviec.DataSource = null;
        }

        public object InsertObject()
        {
            Ecm.WebReferences.RexService.Rex_Hopdong_Laodong objRex_Hopdong_Laodong = new Ecm.WebReferences.RexService.Rex_Hopdong_Laodong();
            objRex_Hopdong_Laodong.Id_Hopdong_Laodong = -1;
            objRex_Hopdong_Laodong.Ma_Hopdong_Laodong = this.txtMa_Hopdong_Laodong.Text;

            if ("" + this.dtNgay_Batdau.EditValue != "")
                objRex_Hopdong_Laodong.Ngay_Batdau = this.dtNgay_Batdau.EditValue;

            if ("" + this.dtNgay_Ketthuc.EditValue != "")
                objRex_Hopdong_Laodong.Ngay_Ketthuc = this.dtNgay_Ketthuc.EditValue;

            if ("" + this.lookUp_Loai_Hopdong.EditValue != "")
                objRex_Hopdong_Laodong.Id_Loai_Hopdong = this.lookUp_Loai_Hopdong.EditValue;

            if ("" + this.lookUp_Nhansu.EditValue != "")
                objRex_Hopdong_Laodong.Id_Nhansu_Nld = this.lookUp_Nhansu.EditValue;
            objRex_Hopdong_Laodong.Ghichu = (txtGhichu.Text == "") ? null : txtGhichu.EditValue;
            objRex_Hopdong_Laodong.Trangthai_Hopdong_Laodong = objRexService.GetETrangthaiHopdongLaodong(Ecm.WebReferences.RexService.ETrangthaiHopdongLaodong.DangHopdong);
            return objRexService.Insert_Rex_Hopdong_Laodong(objRex_Hopdong_Laodong);
        }

        public object UpdateObject()
        {
            Ecm.WebReferences.RexService.Rex_Hopdong_Laodong objRex_Hopdong_Laodong = new Ecm.WebReferences.RexService.Rex_Hopdong_Laodong();
            objRex_Hopdong_Laodong.Id_Hopdong_Laodong = gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Hopdong_Laodong");
            objRex_Hopdong_Laodong.Ma_Hopdong_Laodong = this.txtMa_Hopdong_Laodong.Text;

            if ("" + this.dtNgay_Batdau.EditValue != "")
                objRex_Hopdong_Laodong.Ngay_Batdau = this.dtNgay_Batdau.EditValue;

            if ("" + this.dtNgay_Ketthuc.EditValue != "")
                objRex_Hopdong_Laodong.Ngay_Ketthuc = this.dtNgay_Ketthuc.EditValue;

            if ("" + this.lookUp_Loai_Hopdong.EditValue != "")
                objRex_Hopdong_Laodong.Id_Loai_Hopdong = this.lookUp_Loai_Hopdong.EditValue;

            if ("" + this.lookUp_Nhansu.EditValue != "")
                objRex_Hopdong_Laodong.Id_Nhansu_Nld = this.lookUp_Nhansu.EditValue;

            objRex_Hopdong_Laodong.Ghichu = (txtGhichu.Text == "") ? null : txtGhichu.EditValue;

            if (gridView_Nghiviec.RowCount > 0)
                objRex_Hopdong_Laodong.Trangthai_Hopdong_Laodong = objRexService.GetETrangthaiHopdongLaodong(Ecm.WebReferences.RexService.ETrangthaiHopdongLaodong.KetthucHopdong);
            else if (gridView_Tamhoan.RowCount > 0)
            {
                DateTime dtNgay_Ketthuc = Convert.ToDateTime(gridView_Tamhoan.GetRowCellValue(gridView_Tamhoan.RowCount - 1, gridView_Tamhoan.Columns["Ngay_Ketthuc"]));
                if (dtNgay_Ketthuc.CompareTo(DateTime.Today) >= 0)
                    objRex_Hopdong_Laodong.Trangthai_Hopdong_Laodong = objRexService.GetETrangthaiHopdongLaodong(Ecm.WebReferences.RexService.ETrangthaiHopdongLaodong.TamhoanHopdong);
            }
            else
                objRex_Hopdong_Laodong.Trangthai_Hopdong_Laodong = objRexService.GetETrangthaiHopdongLaodong(Ecm.WebReferences.RexService.ETrangthaiHopdongLaodong.DangHopdong);
            return objRexService.Update_Rex_Hopdong_Laodong(objRex_Hopdong_Laodong);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.RexService.Rex_Hopdong_Laodong objRex_Hopdong_Laodong = new Ecm.WebReferences.RexService.Rex_Hopdong_Laodong();
            objRex_Hopdong_Laodong.Id_Hopdong_Laodong = gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Hopdong_Laodong");
            return objRexService.Delete_Rex_Hopdong_Laodong(objRex_Hopdong_Laodong);
        }

        public override bool PerformAdd()
        {
            if ("" + Id_Bophan != "0")
            {
                ClearDataBindings();
                this.ChangeStatus(false);
                this.ResetText();
                this.txtMa_Hopdong_Laodong.EditValue = objRexService.Get_Rex_Hopdong_Laodong_SoHD();
                this.xtraTabControl1.SelectedTabPage = xtraTabPage1;
                this.changeStatus_button_Capnhat(false);
                return true;
            }
            return false;
        }

        public override bool PerformEdit()
        {
            if ("" + Id_Bophan != "0" && gvrex_Hopdong_Laodong.RowCount > 0)
            {
                if (gridView_Nghiviec.RowCount >= 1)
                    panelControl3.Enabled = false;
                else
                    panelControl3.Enabled = true;

                this.ChangeStatus(false);
                this.changeStatus_button_Capnhat(false);
                return true;
            }
            return false;
        }

        public override bool PerformCancel()
        {
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                dgTamhoan_Hopdong.EmbeddedNavigator.Buttons.DoClick(dgTamhoan_Hopdong.EmbeddedNavigator.Buttons.EndEdit);
                dgNghiviec.EmbeddedNavigator.Buttons.DoClick(dgNghiviec.EmbeddedNavigator.Buttons.EndEdit);

                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(lookUp_Nhansu, lblMa_Nhansu.Text);
                hashtableControls.Add(lookUp_Loai_Hopdong, lblLoai_Hopdong.Text);
                hashtableControls.Add(dtNgay_Batdau, lblNgay_Batdau.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau, dtNgay_Ketthuc))
                    return false;

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvrex_Hopdong_Laodong))
                    return false;

                object ngaybatdauTH = null;
                DataSet dsphuluc = objRexService.Get_Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Nhansu_Nld(this.lookUp_Nhansu.EditValue).ToDataSet();
                object giahan_Denngay = null;
                if (dsphuluc.Tables[0].Rows.Count > 0)
                {
                    giahan_Denngay = dsphuluc.Tables[0].Rows[0]["Thoigian_Thuchien_Den"];
                }
                if (gridView_Tamhoan.RowCount > 0)  // tạm hoãn
                {
                    GoobizFrame.Windows.Public.OrderHashtable hashtableControls_Tamhoan = new GoobizFrame.Windows.Public.OrderHashtable();
                    hashtableControls_Tamhoan.Add(gridView_Tamhoan.Columns["Id_Quyetdinh"], "");
                    hashtableControls_Tamhoan.Add(gridView_Tamhoan.Columns["Ngay_Batdau"], "");
                    hashtableControls_Tamhoan.Add(gridView_Tamhoan.Columns["Ngay_Ketthuc"], "");
                    hashtableControls_Tamhoan.Add(gridView_Tamhoan.Columns["Lydo"], "");
                    ngaybatdauTH = gridView_Tamhoan.GetDataRow(0)["Ngay_Batdau"].ToString();
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls_Tamhoan, gridView_Tamhoan))
                        return false;

                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDateGrid(gridView_Tamhoan.Columns["Ngay_Batdau"], gridView_Tamhoan.Columns["Ngay_Ketthuc"], gridView_Tamhoan))
                        return false;
                }
                object ngaynghiviec = null;
                if (gridView_Nghiviec.RowCount > 0)    // nghỉ việc
                {
                    GoobizFrame.Windows.Public.OrderHashtable hashtableControls_Nghiviec = new GoobizFrame.Windows.Public.OrderHashtable();
                    hashtableControls_Nghiviec.Add(gridView_Nghiviec.Columns["Id_Quyetdinh"], "");
                    hashtableControls_Nghiviec.Add(gridView_Nghiviec.Columns["Ngay_Hopdong"], "");
                    hashtableControls_Nghiviec.Add(gridView_Nghiviec.Columns["Ngay_Nghiviec"], "");
                    hashtableControls_Nghiviec.Add(gridView_Nghiviec.Columns["Lydo"], "");
                    ngaynghiviec = gridView_Nghiviec.GetDataRow(0)["Ngay_Nghiviec"].ToString();

                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls_Nghiviec, gridView_Nghiviec))
                        return false;

                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDateGrid(gridView_Nghiviec.Columns["Ngay_Hopdong"], gridView_Nghiviec.Columns["Ngay_Nghiviec"], gridView_Nghiviec))
                        return false;
                }
                Ecm.WebReferences.RexService.Rex_Nhansu objNhansu = new Ecm.WebReferences.RexService.Rex_Nhansu();
                objNhansu = objRexService.Get_Rex_Nhansu_ById(this.lookUp_Nhansu.EditValue);
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = Convert.ToBoolean(this.InsertObject());
                    //deonguyen
                    this.Update_Nghiviec_Collection();
                    this.Update_Tamhoan_Collection();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = Convert.ToBoolean(this.UpdateObject());
                    //deonguyen
                    this.Update_Nghiviec_Collection();
                    this.Update_Tamhoan_Collection();
                }
                if (success)
                {
                    this.FormState = GoobizFrame.Windows.Forms.FormState.View;
                    treeListColumn1.TreeList.FocusedNode = focusedNode;
                    this.DisplayInfo2();
                    this.ChangeStatus(true);
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
            if ("" + Id_Bophan != "0" && gvrex_Hopdong_Laodong.RowCount > 0)
            {
                if (GoobizFrame.Windows.Forms.UserMessage.Show("SYS_CONFIRM_BFDELETE", new string[]  {
                GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Hopdong_Laodong"),
                GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Hopdong_Laodong")   }) == DialogResult.Yes)
                {
                    try
                    {
                        this.DeleteObject();
                    }
                    catch (Exception ex)
                    {
                        //GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                        GoobizFrame.Windows.Forms.UserMessage.Show("SYS_DATA_INUSE", new string[] { this.Text.ToLower() });
                    }
                    this.DisplayInfo();
                }
                return base.PerformDelete();
            }
            return false;
        }

        public override bool PerformPrintPreview()
        {
            DataSet dsHDLD = objRexService.Get_Hopdong_Nhansu_Info_In_Hoso(gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Hopdong_Laodong")).ToDataSet();
            DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet();
            Reports.rptRex_Hopdong_Nhansu XtraReport = new Ecm.Rex.Reports.rptRex_Hopdong_Nhansu();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();

            XtraReport.xrTen_Donvi.Text = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyName"))[0]["Heso"].ToString();
            XtraReport.xrTen_Congty.Text = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyName"))[0]["Heso"].ToString();
            XtraReport.xrDiachi_Congty.Text = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyAddress"))[0]["Heso"].ToString();
            XtraReport.xrDienthoai_Congty.Text = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyTel"))[0]["Heso"].ToString();

            XtraReport.xrPic_Kyten_Nld.DataBindings.Add(
                       new DevExpress.XtraReports.UI.XRBinding("Image", dsHDLD, dsHDLD.Tables[0].TableName + ".Kyten_Nld"));
            XtraReport.xrPic_Kyten_Nsd.DataBindings.Add(
                       new DevExpress.XtraReports.UI.XRBinding("Image", dsHDLD, dsHDLD.Tables[0].TableName + ".Kyten_Nsd"));

            frmPrintPreview.Report = XtraReport;
            XtraReport.DataSource = dsHDLD;

            DataSet dsPhucap = objRexService.Get_Rex_Phucap_For_Hopdong_Laodong_Collection(
                gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Nhansu_Nld"),
                gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Ngay_Batdau")).ToDataSet();
            Reports.rptRex_Phucap rptPhucap = new Ecm.Rex.Reports.rptRex_Phucap();
            XtraReport.xrPhucap.ReportSource = rptPhucap;
            rptPhucap.DataSource = dsPhucap;
            rptPhucap.CreateDocument();

            XtraReport.CreateDocument();

            frmPrintPreview.printControl1.PrintingSystem = XtraReport.PrintingSystem;
            frmPrintPreview.MdiParent = this.MdiParent;
            frmPrintPreview.Text = this.Text + " - In hợp đồng lao động";
            frmPrintPreview.Show();
            frmPrintPreview.Activate();
            return true;
        }
        #endregion

        #region Event Handling

        private void treeList_Bophan_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            try
            {
                focusedNode = e.Node;
                Id_Bophan = Convert.ToInt64("" + e.Node.GetValue("Id_Bophan"));
                DisplayInfo2();
                binding_Tamhoan_Nghiviec();

                if (gvrex_Hopdong_Laodong.RowCount == 0)
                {
                    this.item_Edit.Enabled = false;
                    this.item_Delete.Enabled = false;
                }
                GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);
            }
            catch (Exception ex)
            {

            }
        }

        private void lookUpEdit_Nhansu_EditValueChanged(object sender, EventArgs e)
        {
            if (this.FormState != GoobizFrame.Windows.Forms.FormState.View && lookUp_Nhansu.EditValue != null)
            {
                DataRow[] dtr_Nhansu_Visible = ds_Collection.Tables[0].Select("Id_Nhansu_Nld = " + lookUp_Nhansu.EditValue);
                if (dtr_Nhansu_Visible.Length > 0)
                {
                    for (int i = 0; i < dtr_Nhansu_Visible.Length; i++)
                    {
                        DataSet ds_Nghiphep_ByHopdong = objRexService.Get_All_Rex_Nghiviec_ByHopdong(dtr_Nhansu_Visible[i]["Id_Hopdong_Laodong"]).ToDataSet();
                        //DataSet ds_Nghiphep_ByNhansu = objRexService.Get_All_Rex_Nghiviec_ByNhansu(lookUp_Nhansu.EditValue);
                        if (ds_Nghiphep_ByHopdong.Tables[0].Rows.Count == 0)
                        {
                            if ("" + dtr_Nhansu_Visible[i]["Ngay_Ketthuc"] == "")
                            {
                                GoobizFrame.Windows.Forms.MessageDialog.Show("Nhân viên này đã có hợp đồng, vui lòng kiểm tra lại");
                                lookUp_Nhansu.EditValue = null;
                                txtHoten_Nhansu.EditValue = null;
                                return;

                            }
                            else if ("" + dtr_Nhansu_Visible[i]["Ngay_Ketthuc"] != "")
                            {
                                if (Convert.ToDateTime(dtr_Nhansu_Visible[i]["Ngay_Ketthuc"]) > DateTime.Today)
                                {
                                    GoobizFrame.Windows.Forms.MessageDialog.Show("Nhân viên này đã có hợp đồng, vui lòng kiểm tra lại");
                                    lookUp_Nhansu.EditValue = null;
                                    txtHoten_Nhansu.EditValue = null;
                                    return;
                                }
                                else if ("" + dtr_Nhansu_Visible[i]["Giahan_Denngay"] != "")
                                {
                                    if (Convert.ToDateTime(dtr_Nhansu_Visible[i]["Giahan_Denngay"]) > DateTime.Today)
                                    {
                                        GoobizFrame.Windows.Forms.MessageDialog.Show("Nhân viên này đã có hợp đồng, vui lòng kiểm tra lại");
                                        lookUp_Nhansu.EditValue = null;
                                        txtHoten_Nhansu.EditValue = null;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
                DataRow[] dtr = ds_Nhansu.Tables[0].Select("Id_Nhansu = " + lookUp_Nhansu.EditValue);
                if (dtr.Length > 0)
                    txtHoten_Nhansu.EditValue = dtr[0]["Hoten_Nhansu"];
            }
        }

        private void btnCapnhat_Nhanvien_Click(object sender, EventArgs e)
        {
            if (gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Hopdong_Laodong") != null)
            {
                Frmrex_Hopdong_Laodong_Info frmHopdong_Laodong_Info = new Frmrex_Hopdong_Laodong_Info(gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Hopdong_Laodong"));
                frmHopdong_Laodong_Info.passData = new Frmrex_Hopdong_Laodong_Info.PassData(isUpdateValue);
                frmHopdong_Laodong_Info.Text = "Cập nhật Hợp đồng Lao động";
                frmHopdong_Laodong_Info.ShowDialog();
            }
        }

        private void dgrex_Hopdong_Laodong_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo gridHit = gvrex_Hopdong_Laodong.CalcHitInfo(e.X, e.Y);
            if (gridHit.InRowCell && EnableEdit)
            {
                Frmrex_Hopdong_Laodong_Info frmHopdong_Laodong_Info = new Frmrex_Hopdong_Laodong_Info(gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Hopdong_Laodong"));
                frmHopdong_Laodong_Info.passData = new Frmrex_Hopdong_Laodong_Info.PassData(isUpdateValue);
                frmHopdong_Laodong_Info.Text = "Cập nhật Hợp đồng Lao động";
                frmHopdong_Laodong_Info.ShowDialog();
            }
        }

        private void btnCapnhat_Phuluc_Click(object sender, EventArgs e)
        {
            Frmrex_Hopdong_Laodong_Phuluc frmrex_Hopdong_Laodong_Giahan = new Frmrex_Hopdong_Laodong_Phuluc();
            frmrex_Hopdong_Laodong_Giahan.Text = "Cập nhật Hợp đồng Lao động";
            frmrex_Hopdong_Laodong_Giahan.Set_Info(gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Nhansu_Nld"), gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Hopdong_Laodong"));
            frmrex_Hopdong_Laodong_Giahan.ShowDialog();
            DisplayInfo2();
            binding_Tamhoan_Nghiviec();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            binding_Tamhoan_Nghiviec();

            if ("" + gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Nhansu_Nld") != "")
            {
                object id_nhansu = gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Nhansu_Nld");
                DataSet dsHopdong_Laodong_By_Nhansu = objRexService.Get_All_Rex_Hopdong_Laodong_By_Nhansu(id_nhansu).ToDataSet();

                dgrex_Hopdong_Laodong_All.DataSource = dsHopdong_Laodong_By_Nhansu;
                dgrex_Hopdong_Laodong_All.DataMember = dsHopdong_Laodong_By_Nhansu.Tables[0].TableName;
            }
        }

        private void gridView3_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (gridView_Nghiviec.RowCount > 1)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Nhân viên này đã nghỉ việc nên không thể thêm mới thông tin Nghỉ việc");
                gridView_Nghiviec.CancelUpdateCurrentRow();
                return;
            }
            else
            {
                gridView_Nghiviec.SetFocusedRowCellValue("Id_Hopdong_Laodong", gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Hopdong_Laodong"));
                gridView_Nghiviec.SetFocusedRowCellValue("Id_Nhansu", gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Nhansu_Nld"));
                gridView_Nghiviec.SetFocusedRowCellValue("Ngay_Hopdong", gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Ngay_Batdau"));
            }
        }

        private void gridView2_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (gridView_Nghiviec.RowCount > 1)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Nhân viên này đã nghỉ việc nên không thể thêm mới thông tin Tạm hoãn");
                gridView_Tamhoan.CancelUpdateCurrentRow();
                return;
            }
            else
            {
                gridView_Tamhoan.SetFocusedRowCellValue("Id_Hopdong_Laodong", gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Hopdong_Laodong"));
                gridView_Tamhoan.SetFocusedRowCellValue("Id_Nhansu", gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Nhansu_Nld"));
            }
        }

        private void gridView3_RowCountChanged(object sender, EventArgs e)
        {
            if (FormState == GoobizFrame.Windows.Forms.FormState.Add || FormState == GoobizFrame.Windows.Forms.FormState.Edit)
            {
                if (gridView_Nghiviec.RowCount > 0)
                {
                    gridView_Tamhoan.OptionsBehavior.Editable = false;
                }
                else
                {
                    gridView_Tamhoan.OptionsBehavior.Editable = true;
                }
            }
        }

        // nhanvuong -- check thời gian tạm hoãn (ko đc nằm trong khoảng thời gian tạm hoãn đã có)
        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Ngay_Batdau")
            {
                DataSet ds_Tamhoan_ByHopdong = objRexService.Get_All_Rex_Tamhoan_ByHopdong(gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Hopdong_Laodong")).ToDataSet();
                if (ds_Tamhoan_ByHopdong.Tables[0].Rows.Count > 0)
                    for (int i = 0; i < ds_Tamhoan_ByHopdong.Tables[0].Rows.Count; i++)
                    {
                        DateTime Ngay_Batdau_New;
                        if (gridView_Tamhoan.GetFocusedRowCellValue(gridView_Tamhoan.Columns["Ngay_Batdau"]).ToString() != "")
                        {
                            Ngay_Batdau_New = Convert.ToDateTime(gridView_Tamhoan.GetFocusedRowCellValue(gridView_Tamhoan.Columns["Ngay_Batdau"]));
                            if (Ngay_Batdau_New < Convert.ToDateTime(ds_Tamhoan_ByHopdong.Tables[0].Rows[i]["Ngay_Ketthuc"]))
                            {
                                GoobizFrame.Windows.Forms.MessageDialog.Show("Thời gian tạm hoãn nhập không chính xác, vui lòng nhập lại");
                                gridView_Tamhoan.SetFocusedRowCellValue(gridView_Tamhoan.Columns["Ngay_Batdau"], null);
                                return;
                            }
                        }
                    }
            }
        }

        #endregion

        #region Custom method

        void changeStatus_button_Capnhat(bool editable)
        {
            btnCapnhat_Nhanvien.Enabled = editable && EnableEdit;
            btnCapnhat_Phuluc.Enabled = editable && EnableEdit;
        }

        public void DisplayInfo2()
        {
            //if(isLoaded)
            lock (this)
            {
                try
                {
                    ds_Nhansu = objRexService.Get_Rex_Nhansu_ByBoPhan_Collection(Id_Bophan).ToDataSet();
                    //ds_Nhansu = objRexService.Get_Rex_Nhansu_Collection();
                    lookUp_Nhansu.Properties.DataSource = ds_Nhansu.Tables[0];
                    ds_Collection = objRexService.Get_All_Rex_Hopdong_Laodong_By_Bophan(Id_Bophan).ToDataSet();
                    ds_Collection.Tables[0].Columns.Add("Giahan_Denngay");
                    foreach (DataRow dt in ds_Collection.Tables[0].Rows)
                    {
                        DataSet dsphuluc = objRexService.Get_Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Nhansu_Nld(dt["Id_Nhansu_Nld"]).ToDataSet();

                        if (dsphuluc.Tables[0].Rows.Count > 0)
                        {
                            dt["Giahan_Denngay"] = dsphuluc.Tables[0].Rows[0]["Thoigian_Thuchien_Den"];
                        }
                    }

                    dgrex_Hopdong_Laodong.DataSource = ds_Collection;
                    dgrex_Hopdong_Laodong.DataMember = ds_Collection.Tables[0].TableName;
                    DataBindingControl();
                    if (gvrex_Hopdong_Laodong.RowCount == 0)
                    {
                        ResetText();
                        this.changeStatus_button_Capnhat(false);
                    }
                    else
                    {
                        this.changeStatus_button_Capnhat(true);
                    }
                    this.gvrex_Hopdong_Laodong.BestFitColumns();

                    this.DisplayTamhoan(Convert.ToInt64(gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Hopdong_Laodong")));
                    this.DisplayNghiviec(Convert.ToInt64(gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Hopdong_Laodong")));
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.ToString());
#endif
                }
            }
        }

        public void isUpdateValue(string value)
        {
            if (value == "Updated")
                this.DisplayInfo();
        }

        private void DisplayNghiviec(object Id_Hopdong_Laodong)
        {
            ds_Nghiviec = objRexService.Get_All_Rex_Nghiviec_ByHopdong(Id_Hopdong_Laodong).ToDataSet();

            dgNghiviec.DataSource = ds_Nghiviec;
            dgNghiviec.DataMember = ds_Nghiviec.Tables[0].TableName;
        }

        private void DisplayTamhoan(object Id_Hopdong_Laodong)
        {
            ds_Tamhoan = objRexService.Get_All_Rex_Tamhoan_ByHopdong(Id_Hopdong_Laodong).ToDataSet();

            dgTamhoan_Hopdong.DataSource = ds_Tamhoan;
            dgTamhoan_Hopdong.DataMember = ds_Tamhoan.Tables[0].TableName;
        }

        //nhanvuong
        void binding_Tamhoan_Nghiviec()
        {
            object objId_Hopdong_Laodong = gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Hopdong_Laodong");
            if (objId_Hopdong_Laodong != null)
            {
                this.DisplayNghiviec(objId_Hopdong_Laodong);
                this.DisplayTamhoan(objId_Hopdong_Laodong);
            }
        }

        private bool CheckDateTamhoan(DateTime ngaybatdauHD, DateTime ngayketthucHD, DateTime ngayketthucTH, DateTime ngaybatdauTH, object ngaygiahan)
        {
            if (ngaybatdauTH < ngaybatdauHD)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Ngày bắt đầu hợp đồng nhỏ hơn ngày bắt đầu tạm hoãn, vui lòng nhập lại");
                return false;
            }
            if (ngaybatdauTH > ngayketthucHD)
            {
                if (ngaygiahan != null)
                {
                    if (Convert.ToDateTime(ngaygiahan) < ngaybatdauTH)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Ngày bắt đầu tạm hoãn lớn hơn thời gian trong hợp đồng gia hạn, vui lòng nhập lại");
                        return false;
                    }
                }
                else
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Ngày bắt đầu tạm hoãn lớn hơn thời gian trong hợp đồng, vui lòng nhập lại");
                    return false;
                }
            }
            return true;
        }

        private bool checkDate(DateTime ngayvaolam, DateTime ngaybatdauHD, DateTime ngayketthucHD, object ngaynghiviec, object ngayketthucgiahan)
        {
            // ngay  vao lam nho hon ngay bat dau hop dong
            if (ngayvaolam > ngaybatdauHD)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Ngày bắt đầu hợp đồng trước ngày vào làm, vui lòng nhập lại");
                return false;
            }
            // Ngay nghi viec truoc ngay hop dong
            if (ngaynghiviec != null)
            {
                if (ngaybatdauHD >= Convert.ToDateTime(ngaynghiviec.ToString()))
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Ngày nghỉ không được nhỏ hơn ngày vào làm, vui lòng nhập lại");
                    return false;
                }
            }
            return true;
        }

        private void Update_Nghiviec_Collection()
        {
            //dgNghiviec.EmbeddedNavigator.Buttons.DoClick(dgNghiviec.EmbeddedNavigator.Buttons.EndEdit);
            objRexService.Update_Rex_Nghiviec_Collection(ds_Nghiviec);
        }

        private void Update_Tamhoan_Collection()
        {
            //dgTamhoan_Hopdong.EmbeddedNavigator.Buttons.DoClick(dgTamhoan_Hopdong.EmbeddedNavigator.Buttons.EndEdit);
            objRexService.Update_Rex_Tamhoan_Collection(ds_Tamhoan);
        }
        #endregion

        private void dtNgay_Batdau_EditValueChanged(object sender, EventArgs e)
        {
            Cal_Thoigian_Hopdong();
        }

        private void Cal_Thoigian_Hopdong()
        {
            if ("" + lookUp_Loai_Hopdong.EditValue != "" && "" + dtNgay_Batdau.EditValue != "")
            {
                DataRow[] dr_loai_hdld = ds_Loai_HDLD.Tables[0].Select("Id_Loai_Hopdong = " + lookUp_Loai_Hopdong.EditValue);

                int thoihan = Convert.ToInt32(dr_loai_hdld[0]["Thoihan"]);
                DateTime dt_ngay_bd = Convert.ToDateTime(dtNgay_Batdau.EditValue);

                int date = dt_ngay_bd.Day;
                int month = 0;
                int year = 0;

                if (thoihan < 999 && thoihan > 0)
                {
                    if (dt_ngay_bd.Month + thoihan > 12)
                    {
                        year = dt_ngay_bd.Year + (dt_ngay_bd.Month + thoihan) / 12;
                        month = (dt_ngay_bd.Month + thoihan) % 12;
                    }
                    else
                    {
                        month = dt_ngay_bd.Month + thoihan;
                        year = dt_ngay_bd.Year;
                    }

                    dtNgay_Ketthuc.EditValue = dtNgay_Batdau.DateTime.AddMonths(thoihan); 
                }
                else dtNgay_Ketthuc.EditValue = null;
            }
        }

        private void lookUp_Loai_Hopdong_EditValueChanged(object sender, EventArgs e)
        {
            Cal_Thoigian_Hopdong();
        }

        /// <summary>
        /// chon loai hdld tu dialog Frmrex_Dm_Loai_Hopdong_Add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lookUp_Loai_Hopdong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                System.Windows.Forms.Form dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData("Ecm.MasterService.dll",
                    "Ecm.MasterService.Forms.Rex.Frmrex_Dm_Loai_Hopdong_Add", this);
                if (dialog == null)
                    return;
                var SelectedObject = dialog.GetType().GetProperty("SelectedDataRow").GetValue(dialog, null)
                   as DataRow;

                if (SelectedObject != null)
                {
                    ds_Loai_HDLD = objMasterService.Get_All_Rex_Dm_Loai_Hopdong_Collection().ToDataSet();
                    lookUp_Loai_Hopdong.Properties.DataSource = ds_Loai_HDLD.Tables[0];
                    gridLookUp_Loai_Hopdong.DataSource = ds_Loai_HDLD.Tables[0];

                    lookUp_Loai_Hopdong.EditValue = SelectedObject["Id_Loai_Hopdong"];
                }
            }
        }

        private void navBarControl1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            switch (e.Link.Item.Name)
            {
                case "navEdit_Hdld_ByBP":
                    if (frmrex_Hopdong_Laodong_InfoBP == null || frmrex_Hopdong_Laodong_InfoBP.IsDisposed)
                        frmrex_Hopdong_Laodong_InfoBP = new Frmrex_Hopdong_Laodong_InfoBP();
                    frmrex_Hopdong_Laodong_InfoBP.Id_Bophan = Id_Bophan;
                    frmrex_Hopdong_Laodong_InfoBP.MdiParent = this.MdiParent;
                    frmrex_Hopdong_Laodong_InfoBP.Show();
                    frmrex_Hopdong_Laodong_InfoBP.Activate();
                    break;
            }
        }

    }
}