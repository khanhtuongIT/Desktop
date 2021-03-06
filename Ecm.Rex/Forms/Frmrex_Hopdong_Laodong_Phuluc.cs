#region edit
/*
 * edit     phuuongphan
 * date     06/04/2011
 * content  edit GUI
 */
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraTab;
using Ecm.Rex.Forms;


namespace Ecm.Rex.Forms
{
    public partial class Frmrex_Hopdong_Laodong_Phuluc : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        Ecm.WebReferences.Classes.SystemService objSystemService = new Ecm.WebReferences.Classes.SystemService();
        Ecm.WebReferences.RexService.Rex_Hopdong_Laodong objHopdong_Laodong = new Ecm.WebReferences.RexService.Rex_Hopdong_Laodong();

        DataSet ds_Collection = new DataSet();
        DataSet ds_Nhansu = new DataSet();
        DataSet dsDm_Heso_Chuongtrinh ;
        public object Id_Hopdong_Laodong;
        public object Id_Nhansu_Nld = null;
        object Id_Hopdong_Laodong_Phuluc;

        public Frmrex_Hopdong_Laodong_Phuluc()
        {
            InitializeComponent();
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            #region format datetime

            dtNgay_Batdau_Hieuluc.Properties.MinValue = new DateTime(1950, 01, 01);
            dtNgay_Ketthuc_Hieuluc.Properties.MinValue = new DateTime(1950, 01, 01);
            dtNgaycap_Nhansu_B.Properties.MinValue = new DateTime(1950, 01, 01);
            dtNgaycap_Solaodong_Nhansu_B.Properties.MinValue = new DateTime(1950, 01, 01);
            dtNgayky_Phuluc.Properties.MinValue = new DateTime(1950, 01, 01);
            gridDate_Ngay_Ky.Properties.MinValue = new DateTime(1950, 01, 01);


            dtNgay_Batdau_Hieuluc.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Batdau_Hieuluc.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            dtNgay_Ketthuc_Hieuluc.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Ketthuc_Hieuluc.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            dtNgaycap_Nhansu_B.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgaycap_Nhansu_B.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            dtNgaycap_Solaodong_Nhansu_B.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgaycap_Solaodong_Nhansu_B.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            dtNgayky_Phuluc.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgayky_Phuluc.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            gridDate_Ngay_Ky.Mask.UseMaskAsDisplayFormat = true;
            gridDate_Ngay_Ky.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            #endregion

        }

        #region methods override

        public override void DisplayInfo()
        {
            ds_Collection = objRexService.Get_Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Nhansu_Nld(Id_Nhansu_Nld).ToDataSet();
            dgrex_Hopdong_Laodong.DataSource = ds_Collection;
            dgrex_Hopdong_Laodong.DataMember = ds_Collection.Tables[0].TableName;

            this.Data = ds_Collection;
            this.GridControl = dgrex_Hopdong_Laodong;
            DataBindingControl();

            ds_Nhansu = objRexService.Get_All_Rex_Nhansu_None_Bophan().ToDataSet();
            txtTen_Nhansu_A.Properties.DataSource = ds_Nhansu.Tables[0];
            txtTen_Nhansu_B.Properties.DataSource = ds_Nhansu.Tables[0];

            //if (ds_Collection.Tables[0].Rows[0]["Id_Nhansu_Nsd"] != null)
            //    txtTen_Nhansu_A.EditValue = ds_Collection.Tables[0].Rows[0]["Id_Nhansu_Nsd"];

            DataSet ds_Quocgia = objMasterService.Get_All_Rex_Dm_Quocgia_Collection().ToDataSet();
            lookUpEdit_Quoctich_Nhansu_A.Properties.DataSource = ds_Quocgia.Tables[0];
            lookUpEdit_Quoctich_Nhansu_B.Properties.DataSource = ds_Quocgia.Tables[0];

            DataSet ds_Chucvu = objMasterService.Get_All_Rex_Dm_Chucvu_Collection().ToDataSet();
            lookUp_Chucvu_Nhansu_A.Properties.DataSource = ds_Chucvu.Tables[0];

            DataSet ds_Chuyenmon = objMasterService.Get_All_Rex_Dm_Chuyenmon_Collection().ToDataSet();
            lookUp_Chuyenmon_Nhansu_B.Properties.DataSource = ds_Chuyenmon.Tables[0];

            ChangeStatus(true);
            if (gridView1.RowCount == 0)
                this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            else
                this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            base.DisplayInfo();
        }

        public override void ResetText()
        {
            this.txtNoiky_Phuluc.EditValue = null;
            this.dtNgayky_Phuluc.EditValue = null;
            this.memoNoidung_Thaydoi.EditValue = null;
            this.dtNgay_Batdau_Hieuluc.EditValue = null;
            this.dtNgay_Ketthuc_Hieuluc.EditValue = null;
            base.ResetText();
        }

        public override void ChangeStatus(bool editTable)
        {
            this.txtNoiky_Phuluc.Properties.ReadOnly = editTable;
            this.dtNgayky_Phuluc.Properties.ReadOnly = editTable;
            this.txtTen_Nhansu_A.Properties.ReadOnly = editTable;
            this.dgrex_Hopdong_Laodong.Enabled = editTable;
            this.memoNoidung_Thaydoi.Properties.ReadOnly = editTable;
            this.dtNgay_Batdau_Hieuluc.Properties.ReadOnly = editTable;
            this.dtNgay_Ketthuc_Hieuluc.Properties.ReadOnly = editTable;
            base.ChangeStatus(editTable);
        }

        public override void ClearDataBindings()
        {
            this.txtNoiky_Phuluc.DataBindings.Clear();
            this.dtNgayky_Phuluc.DataBindings.Clear();
            this.txtSophuluc_Hopdong.DataBindings.Clear();
            this.memoNoidung_Thaydoi.DataBindings.Clear();
            this.dtNgay_Batdau_Hieuluc.DataBindings.Clear();
            this.dtNgay_Ketthuc_Hieuluc.DataBindings.Clear();
            this.txtTen_Nhansu_A.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            ClearDataBindings();

            this.txtNoiky_Phuluc.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Noiky");
            this.dtNgayky_Phuluc.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ngayky");
            this.txtSophuluc_Hopdong.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Ma_Hopdong_Laodong_Phuluc");
            this.memoNoidung_Thaydoi.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Noidung_Thaydoi");
            this.dtNgay_Batdau_Hieuluc.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Thoigian_Thuchien_Tu");
            this.dtNgay_Ketthuc_Hieuluc.DataBindings.Add("EditValue", ds_Collection, ds_Collection.Tables[0].TableName + ".Thoigian_Thuchien_Den");
            this.txtTen_Nhansu_A.DataBindings.Add("Editvalue", ds_Collection, ds_Collection.Tables[0].TableName + ".Id_Nhansu_Nsd");
        }

        #endregion

        #region event override
        public override bool PerformAdd()
        {
            ChangeStatus(false);
            ResetText();
            this.txtNoiky_Phuluc.Focus();
            this.ClearDataBindings();
            this.txtSophuluc_Hopdong.EditValue = objRexService.Get_Rex_Hopdong_Laodong_Phuluc_SoHD();
            this.txtNoiky_Phuluc.Text = "" + dsDm_Heso_Chuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='Company_Tinh'")[0]["Heso"];
            this.txtTen_Nhansu_A.EditValue = Convert.ToInt64(
                dsDm_Heso_Chuongtrinh.Tables[0].Select("Ma_Heso_Chuongtrinh='CompanyRepresented'")[0]["Heso"].ToString().Split(new char[]{'|'})[0]
                );
            return base.PerformAdd();
        }

        public override bool PerformCancel()
        {
            DisplayInfo();
            this.txtNoiky_Phuluc.Focus();
            return base.PerformCancel();
        }

        public override bool PerformEdit()
        {
            ChangeStatus(false);
            Id_Hopdong_Laodong_Phuluc = gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Hopdong_Laodong_Phuluc"]);
            return base.PerformEdit();
        }

        public override bool PerformSave()
        {
            bool success = false;

            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(txtNoiky_Phuluc, "Nơi ký");
            hashtableControls.Add(dtNgayky_Phuluc, "Ngày ký");
            hashtableControls.Add(memoNoidung_Thaydoi, "Nội dung thay đổi");
            hashtableControls.Add(dtNgay_Batdau_Hieuluc, "Thời gian thực hiện");
            hashtableControls.Add(dtNgay_Ketthuc_Hieuluc, "Thời gian kết thúc");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                return false;

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Batdau_Hieuluc, dtNgay_Ketthuc_Hieuluc))
                return false;

            if (FormState == GoobizFrame.Windows.Forms.FormState.Add)
                success = (bool)this.InsertObject();
            if (FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                success = (bool)this.UpdateObject();

            if (success)
            {
                DisplayInfo();
                return true;
            }
            else
                return false;
        }

        public override bool PerformDelete()
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
            GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Rex_Hopdong_Laodong_Phuluc"),
            GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Rex_Hopdong_Laodong_Phuluc")   }) == DialogResult.Yes)
            {
                try
                {
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    return false;
                }
            }
            DisplayInfo();
            return true;
        }

        public override bool PerformPrintPreview()
        {
            try
            {
                //DataSet ds_Hopdong_Laodong = objRexService.Get_Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Hdld(Id_Hopdong_Laodong);
                DataSet ds_Hopdong_Laodong = objRexService.Rex_Hopdong_Laodong_Phuluc_Select_By_Id_Phuluc(gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Hopdong_Laodong_Phuluc"])).ToDataSet();
                Reports.rptRex_Hopdong_Nhansu_Phuluc rpt_Hopdong_Phuluc = new Ecm.Rex.Reports.rptRex_Hopdong_Nhansu_Phuluc();
                GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();

                frmPrintPreview.Report = rpt_Hopdong_Phuluc;
                rpt_Hopdong_Phuluc.DataSource = ds_Hopdong_Laodong;

                //Main info
                rpt_Hopdong_Phuluc.xrTen_Donvi.Text = dsDm_Heso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyName"))[0]["Heso"].ToString();
                rpt_Hopdong_Phuluc.xrTen_Congty.Text = dsDm_Heso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyName"))[0]["Heso"].ToString();
                rpt_Hopdong_Phuluc.xrDiachi_Congty.Text = dsDm_Heso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyAddress"))[0]["Heso"].ToString();
                rpt_Hopdong_Phuluc.xrDienthoai_Congty.Text = dsDm_Heso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyTel"))[0]["Heso"].ToString();

                // Phu luc HDLD info
                DataRow[] dtr_PhulucHd = ds_Collection.Tables[0].Select("Id_Hopdong_Laodong_Phuluc = " + gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Hopdong_Laodong_Phuluc"]));
                rpt_Hopdong_Phuluc.xrNoiky_Phuluc.Text = dtr_PhulucHd[0]["Noiky"].ToString();
                DateTime dtNgayky = (DateTime)dtr_PhulucHd[0]["Ngayky"];
                rpt_Hopdong_Phuluc.xrNgayky_Phuluc.Text = dtNgayky.Day.ToString();
                rpt_Hopdong_Phuluc.xrThangky_Phuluc.Text = dtNgayky.Month.ToString();
                rpt_Hopdong_Phuluc.xrNamky_Phuluc.Text = dtNgayky.Year.ToString();
                rpt_Hopdong_Phuluc.xrSo_Hopdong.Text = dtr_PhulucHd[0]["Ma_Hopdong_Laodong_Phuluc"].ToString();
                rpt_Hopdong_Phuluc.xrNoidung_Thaydoi.Text = dtr_PhulucHd[0]["Noidung_Thaydoi"].ToString();
                rpt_Hopdong_Phuluc.xrThoigian_Thuchien.Text = "Từ " + dtr_PhulucHd[0]["Thoigian_Thuchien_Tu"].ToString().Substring(0, 9) + " đến " + dtr_PhulucHd[0]["Thoigian_Thuchien_Den"].ToString().Substring(0, 9);

                rpt_Hopdong_Phuluc.CreateDocument();
                frmPrintPreview.printControl1.PrintingSystem = rpt_Hopdong_Phuluc.PrintingSystem;
                frmPrintPreview.MdiParent = this.MdiParent;
                frmPrintPreview.Text = "In phụ lục hợp đồng lao động";
                frmPrintPreview.ShowDialog();
                frmPrintPreview.Activate();
            }
            catch (Exception ex) { }

            return base.PerformPrintPreview();
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.RexService.Rex_Hopdong_Laodong_Phuluc objRex_Hopdong_Laodong_Phuluc = new Ecm.WebReferences.RexService.Rex_Hopdong_Laodong_Phuluc();
                objRex_Hopdong_Laodong_Phuluc.Id_Hopdong_Laodong = Id_Hopdong_Laodong;
                objRex_Hopdong_Laodong_Phuluc.Id_Nhansu_Nld = txtTen_Nhansu_B.EditValue;
                objRex_Hopdong_Laodong_Phuluc.Id_Nhansu_Nsd = txtTen_Nhansu_A.EditValue;
                objRex_Hopdong_Laodong_Phuluc.Ma_Hopdong_Laodong_Phuluc = txtSophuluc_Hopdong.EditValue;
                objRex_Hopdong_Laodong_Phuluc.Ngayky = dtNgayky_Phuluc.DateTime.Date;
                objRex_Hopdong_Laodong_Phuluc.Noidung_Thaydoi = (memoNoidung_Thaydoi.Text == "") ? null : memoNoidung_Thaydoi.EditValue;
                objRex_Hopdong_Laodong_Phuluc.Noiky = txtNoiky_Phuluc.EditValue;
                objRex_Hopdong_Laodong_Phuluc.Tendonvi = txtTendonvi.EditValue;
                objRex_Hopdong_Laodong_Phuluc.Thoigian_Thuchien_Tu = (dtNgay_Batdau_Hieuluc.Text == "") ? null : dtNgay_Batdau_Hieuluc.EditValue;
                objRex_Hopdong_Laodong_Phuluc.Thoigian_Thuchien_Den = (dtNgay_Ketthuc_Hieuluc.Text == "") ? null : dtNgay_Ketthuc_Hieuluc.EditValue;

                objRexService.Rex_Hopdong_Laodong_Phuluc_Insert(objRex_Hopdong_Laodong_Phuluc);
                return true;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Số phụ lục hợp đồng đã tồn tại. \n vui lòng nhập lại");
                }
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.RexService.Rex_Hopdong_Laodong_Phuluc objRex_Hopdong_Laodong_Phuluc = new Ecm.WebReferences.RexService.Rex_Hopdong_Laodong_Phuluc();
                objRex_Hopdong_Laodong_Phuluc.Id_Hopdong_Laodong_Phuluc = Id_Hopdong_Laodong_Phuluc;
                objRex_Hopdong_Laodong_Phuluc.Id_Hopdong_Laodong = Id_Hopdong_Laodong;
                objRex_Hopdong_Laodong_Phuluc.Id_Nhansu_Nld = txtTen_Nhansu_B.EditValue;
                objRex_Hopdong_Laodong_Phuluc.Id_Nhansu_Nsd = txtTen_Nhansu_A.EditValue;
                objRex_Hopdong_Laodong_Phuluc.Ma_Hopdong_Laodong_Phuluc = txtSophuluc_Hopdong.EditValue;
                objRex_Hopdong_Laodong_Phuluc.Ngayky = dtNgayky_Phuluc.DateTime.Date;
                objRex_Hopdong_Laodong_Phuluc.Noidung_Thaydoi = (memoNoidung_Thaydoi.Text == "") ? null : memoNoidung_Thaydoi.EditValue;
                objRex_Hopdong_Laodong_Phuluc.Noiky = txtNoiky_Phuluc.EditValue;
                objRex_Hopdong_Laodong_Phuluc.Tendonvi = txtTendonvi.EditValue;
                objRex_Hopdong_Laodong_Phuluc.Thoigian_Thuchien_Tu = (dtNgay_Batdau_Hieuluc.Text == "") ? null : dtNgay_Batdau_Hieuluc.EditValue;
                objRex_Hopdong_Laodong_Phuluc.Thoigian_Thuchien_Den = (dtNgay_Ketthuc_Hieuluc.Text == "") ? null : dtNgay_Ketthuc_Hieuluc.EditValue;

                objRexService.Rex_Hopdong_Laodong_Phuluc_Update(objRex_Hopdong_Laodong_Phuluc);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public object DeleteObject()
        {
            try
            {
                objRexService.Rex_Hopdong_Laodong_Phuluc_Delete(gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Hopdong_Laodong_Phuluc"]));
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn chưa chọn hợp đồng lao động phụ lục để xóa");
                return false;
            }
        }

        #endregion

        #region process control
        private void txtTen_Nhansu_A_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTen_Nhansu_A.EditValue != null)
            {
                try
                {
                    Ecm.WebReferences.RexService.Rex_Nhansu objNhansu_A = new Ecm.WebReferences.RexService.Rex_Nhansu();
                    objNhansu_A = objRexService.Get_Rex_Nhansu_ById(txtTen_Nhansu_A.EditValue);
                    lookUpEdit_Quoctich_Nhansu_A.EditValue = objNhansu_A.Id_Quocgia;
                    lookUp_Chucvu_Nhansu_A.EditValue = objNhansu_A.Id_Chucvu;
                    lblChuky_Nguoi_Sd_Laodong.Text = objNhansu_A.Ho_Nhansu + " " + objNhansu_A.Ten_Nhansu;
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(),"Exception");
                }
            }
        }

        private void txtTen_Nhansu_B_EditValueChanged(object sender, EventArgs e)
        {
            if (txtTen_Nhansu_B.EditValue != null)
            {
                try
                {
                    Ecm.WebReferences.RexService.Rex_Nhansu objNhansu_B = new Ecm.WebReferences.RexService.Rex_Nhansu();
                    objNhansu_B = objRexService.Get_Rex_Nhansu_ById(txtTen_Nhansu_B.EditValue);
                    lookUpEdit_Quoctich_Nhansu_B.EditValue = Convert.ToInt64("0" + objNhansu_B.Id_Quocgia);
                    lookUp_Chuyenmon_Nhansu_B.EditValue = Convert.ToInt64("0" + objNhansu_B.Id_Chuyenmon);
                    txtNgaysinh_Nhansu_B.EditValue = objNhansu_B.Namsinh;
                    txtDiachi_Thuongtru_Nhansu_B.EditValue = objNhansu_B.Diachi_Thuongtru;
                    txtCMND_Nhansu_B.EditValue = objNhansu_B.Cmnd;
                    dtNgaycap_Nhansu_B.EditValue = objNhansu_B.Ngaycap;
                    txtNoicap_Nhansu_B.EditValue = objNhansu_B.Noicap;
                    lblChuky_Nguoi_Laodong.Text = objNhansu_B.Ho_Nhansu + " " + objNhansu_B.Ten_Nhansu;
                }
                catch (Exception ex) { }
            }
        }
        #endregion

      

        #region buttons bottom
        private void btnAdd_Click(object sender, EventArgs e)
        {
            PerformAdd();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PerformEdit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PerformDelete();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            PerformSave();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PerformCancel();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PerformPrintPreview();
        }

        #endregion

        // set information from form Hopdonglaodong
        public void Set_Info(object id_nhansu_nld, object id_hopdong_laodong)
        {
            this.Id_Nhansu_Nld = id_nhansu_nld;
            this.Id_Hopdong_Laodong = id_hopdong_laodong;

            this.txtTen_Nhansu_B.EditValue = Id_Nhansu_Nld;
            UpdateInfo_By_Id_Hopdong(Id_Hopdong_Laodong);
            dsDm_Heso_Chuongtrinh = objSystemService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet();
            txtCongty_Daidien.EditValue = dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyName'")[0]["Heso"];
            txtTendonvi.EditValue = txtCongty_Daidien.EditValue;
            txtDienthoai_Congty.EditValue = dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyTel'")[0]["Heso"];
            txtDiachi_Congty.EditValue = dsDm_Heso_Chuongtrinh.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyAddress'")[0]["Heso"];

            this.DisplayInfo();
        }

        // cập nhật thông tin trên form by Id_Hopdong_Laodong
        void UpdateInfo_By_Id_Hopdong(object Id_Hopdong)
        {
            objHopdong_Laodong = objRexService.Get_Rex_Hopdong_Laodong_Info_ByID_Hopdong(Id_Hopdong_Laodong);
            txtSolaodong_Nhansu_B.EditValue = objHopdong_Laodong.So_Laodong;
            dtNgaycap_Solaodong_Nhansu_B.EditValue = objHopdong_Laodong.Ngaycap_Sld;
            txtNoicap_Solaodong_Nhansu_B.EditValue = objHopdong_Laodong.Noicap_Sld;
            txtSohopdong_Ketluan.EditValue = objHopdong_Laodong.Ma_Hopdong_Laodong;
            txtSohopdong.EditValue = objHopdong_Laodong.Ma_Hopdong_Laodong;
            if (objHopdong_Laodong.Ngayky != null)
            {
                DateTime ngayky = new DateTime();
                ngayky = DateTime.Parse(objHopdong_Laodong.Ngayky.ToString());
                cmbNgay.EditValue = ngayky.Day;
                cmbThang.EditValue = ngayky.Month;
                txtNam.EditValue = ngayky.Year;
            }
            else
            {
                cmbNgay.EditValue = null;
                cmbThang.EditValue = null;
                txtNam.EditValue = null;
            }
            if (objHopdong_Laodong.Id_Nhansu_Nsd != null)
                txtTen_Nhansu_A.EditValue = Convert.ToInt64(objHopdong_Laodong.Id_Nhansu_Nsd);
        }
    }
}

