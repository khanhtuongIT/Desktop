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
    public partial class Frmware_Kehoach_Banhang : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();

        DataSet ds_Kehoach_Banhang = new DataSet();
        DataSet ds_Kehoach_Banhang_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Ban = new DataSet();
        DataSet ds_Khachhang;
        DataSet ds_Nhansu;        
        object identity;
        object id_nhansu_current;
        //public DataRow[] _selectedRows;

        #region Initialize

        public Frmware_Kehoach_Banhang()
        {
            InitializeComponent();
            xtraTabControl_Main.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            dtNgay_Chungtu_View.EditValue = objWareService.GetServerDateTime();
        }

        void LoadMasterData()
        {
            ds_Nhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            DataRow row = ds_Nhansu.Tables[0].NewRow();
            row["Id_Nhansu"] = -1;
            row["Ma_Nhansu"] = "All";
            row["Hoten_Nhansu"] = "Tất cả";
            ds_Nhansu.Tables[0].Rows.Add(row);
            lookUpEdit_Nhansu_Banhang.Properties.DataSource = ds_Nhansu.Tables[0];
            lookUpEdit_Nhansu_View.Properties.DataSource = ds_Nhansu.Tables[0];
            lookUpEdit_Nhansu_View.EditValue = Convert.ToInt64(-1);
            DataSet ds_collection = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
            if (ds_collection.Tables[0].Rows.Count > 0 &&
                "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] != "Administrators")
            {
                lookUpEdit_Nhansu_View.EditValue = Convert.ToInt64(id_nhansu_current);
                lookUpEdit_Nhansu_View.Enabled = false;
            }

            ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa().ToDataSet();
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];

            ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            gridLookupEdit_Khachhang.DataSource = ds_Khachhang.Tables[0];
            gridLookupEdit_MaKH.DataSource = ds_Khachhang.Tables[0];
            gridLookupEdit_DVT.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet().Tables[0];       
            //gridLookupEdit_Khachhang_View.DataSource = ds_Khachhang.Tables[0];
        }

        void Load_Gridview()
        {
            object id_nhansu = (Convert.ToInt64(lookUpEdit_Nhansu_View.EditValue) == -1) ? null : lookUpEdit_Nhansu_View.EditValue;
            ds_Kehoach_Banhang = objWareService.Ware_Kehoach_Banhang_SelectAll(id_nhansu, dtNgay_Chungtu_View.EditValue).ToDataSet();
            dgware_Kehoach.DataSource = ds_Kehoach_Banhang;
            dgware_Kehoach.DataMember = ds_Kehoach_Banhang.Tables[0].TableName;
        }

        #endregion

        #region Event Override
        /// <summary>
        /// load master data
        /// </summary>
        public override void DisplayInfo()
        {
            //Set lại trạng thái form là view
            FormState = GoobizFrame.Windows.Forms.FormState.View;
            try
            {
                ResetText();
                LoadMasterData();
                Load_Gridview();
                this.ChangeStatus(false);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        public override void ClearDataBindings()
        {
            this.txtId_Hdbanhang.DataBindings.Clear();
            this.dtNgay_Chungtu.DataBindings.Clear();
            lookUpEdit_Nhansu_Banhang.DataBindings.Clear();
            txtGhichu.DataBindings.Clear();
            txtLydo.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                //ClearDataBindings();
                this.dtNgay_Chungtu.DataBindings.Add("EditValue", ds_Kehoach_Banhang, ds_Kehoach_Banhang.Tables[0].TableName + ".Ngay_Chungtu");
                lookUpEdit_Nhansu_Banhang.DataBindings.Add("EditValue", ds_Kehoach_Banhang, ds_Kehoach_Banhang.Tables[0].TableName + ".Id_Nhansu");
                txtLydo.DataBindings.Add("EditValue", ds_Kehoach_Banhang, ds_Kehoach_Banhang.Tables[0].TableName + ".Lydo");
                txtGhichu.DataBindings.Add("EditValue", ds_Kehoach_Banhang, ds_Kehoach_Banhang.Tables[0].TableName + ".Ghichu");
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
            this.dgware_Kehoach.Enabled = !editTable;
            gvKehoac_Chitiet.OptionsBehavior.Editable = editTable;
            txtGhichu.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtId_Hdbanhang.EditValue = null;
            lookUpEdit_Nhansu_Banhang.EditValue = null;
            dtNgay_Chungtu.EditValue = null;
            txtLydo.EditValue = null;
            txtGhichu.EditValue = null;
            this.ds_Kehoach_Banhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(-1).ToDataSet();
            this.dgware_Kehoach_Chitiet.DataSource = ds_Kehoach_Banhang_Chitiet.Tables[0];
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Kehoach_Banhang objWare_kehoach = new Ecm.WebReferences.WareService.Ware_Kehoach_Banhang();
                objWare_kehoach.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_kehoach.Id_Nhansu = lookUpEdit_Nhansu_Banhang.EditValue;
                objWare_kehoach.Ghichu = "" + txtGhichu.EditValue;
                identity = objWareService.Ware_Kehoach_Banhang_Insert(objWare_kehoach);

                if (identity != null)
                {
                    DoClickEndEdit(dgware_Kehoach_Chitiet);
                    foreach (DataRow dr in ds_Kehoach_Banhang_Chitiet.Tables[0].Rows)
                    {
                        if (dr.RowState != DataRowState.Deleted)
                            dr["Id_Kehoach_Banhang"] = identity;
                    }
                    objWareService.Update_Ware_Kehoach_Banhang_Chitiet_Collection(ds_Kehoach_Banhang_Chitiet);
                }
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Kehoach_Banhang objWare_kehoach = new Ecm.WebReferences.WareService.Ware_Kehoach_Banhang();
                objWare_kehoach.Id_Kehoach_Banhang = identity;
                objWare_kehoach.Ngay_Chungtu = dtNgay_Chungtu.EditValue;
                objWare_kehoach.Id_Nhansu = lookUpEdit_Nhansu_Banhang.EditValue;
                objWare_kehoach.Ghichu = "" + txtGhichu.EditValue;
                objWare_kehoach.Lydo = "" + txtLydo.EditValue;
                objWareService.Ware_Kehoach_Banhang_Update(objWare_kehoach);

                this.DoClickEndEdit(dgware_Kehoach_Chitiet);
                foreach (DataRow dr in ds_Kehoach_Banhang_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Kehoach_Banhang"] = identity;
                }
                objWareService.Update_Ware_Kehoach_Banhang_Chitiet_Collection(ds_Kehoach_Banhang_Chitiet);
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
            return objWareService.Ware_Kehoach_Banhang_Delete(identity);
        }

        public override bool PerformAdd()
        {
            this.ResetText();
            lookUpEdit_Nhansu_Banhang.EditValue = Convert.ToInt64(id_nhansu_current);
            this.ChangeStatus(true);
            dtNgay_Chungtu.EditValue = objWareService.GetServerDateTime();
            this.ds_Kehoach_Banhang_Chitiet = objWareService.Ware_Kehoach_Banhang_Chitiet_SelectById_Kehoach(-1).ToDataSet();
            this.dgware_Kehoach_Chitiet.DataSource = ds_Kehoach_Banhang_Chitiet.Tables[0];
            return true;
        }

        public override bool PerformEdit()
        {
            if (!gvKehoach.IsDataRow(gvKehoach.FocusedRowHandle))
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn kế hoạch, vui lòng chọn lại");
                return false;
            }
            //if (!id_nhansu_current.Equals("" + lookUpEdit_Nhansu_Banhang.EditValue))
            //{
            //    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
            //    return false;
            //}
            if (Convert.ToInt64("0" + gvKehoach.GetFocusedRowCellValue("Doc_Process_Status")) == 2)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Kế hoạch bán hàng đã được duyệt, không thể chỉnh sửa");
                return false;
            }
            this.ChangeStatus(true);
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
                System.Collections.Hashtable htbControl1 = new System.Collections.Hashtable();
                //htbControl1.Add(txtSotien_Vat, lblSotien_Vat.Text);
                //htbControl1.Add(lookUpEdit_Cuahang_Ban, lblCuahang_Ban.Text);
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
                    return false;
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                    success = (bool)this.UpdateObject();
                if (success)
                {
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
            if (!gvKehoach.IsDataRow(gvKehoach.FocusedRowHandle))
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn kế hoạch, vui lòng chọn lại");
                return false;
            }
            if (!id_nhansu_current.Equals("" + lookUpEdit_Nhansu_Banhang.EditValue))
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                return false;
            }
            if (Convert.ToInt64("0" + gvKehoach.GetFocusedRowCellValue("Doc_Process_Status")) == 2)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Kế hoạch bán hàng đã được duyệt, không thể chỉnh sửa");
                return false;
            }
            //if (GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
            //    if (!id_nhansu_current.Equals("" + lookUpEdit_Nhansu_Banhang.EditValue))
            //    {
            //        GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
            //        return false;
            //    }
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Hdbanhang"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Hdbanhang")   }) == DialogResult.Yes)
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

        public override bool PerformPrintPreview()
        {
            if (!gvKehoach.IsDataRow(gvKehoach.FocusedRowHandle))
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn kế hoạch, vui lòng chọn lại");
                return false;
            }

            Reports.rptKehoach_Banhang _rptKehoach_Banhang = new Reports.rptKehoach_Banhang();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmReport = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmReport.Report = _rptKehoach_Banhang;            

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
                _rptKehoach_Banhang.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                _rptKehoach_Banhang.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }
            #endregion
            //show form with printcontrol
            //rptLsx_Tbb.DataSource = ds_Kehoach_Banhang_Chitiet;
            //rptLsx_Tbb.CreateHeader(ds_Kehoach_Banhang_Chitiet.Tables[0]);
            //rptLsx_Tbb.CreateXRTable(ds_Kehoach_Banhang_Chitiet.Tables[0]);

            //rptLsx_Tbb.FillDataSource();

            DataSets.DsKehoach_Banhang dsKehoach_Banhang = new DataSets.DsKehoach_Banhang();
            foreach (DataRow dtr in ds_Kehoach_Banhang_Chitiet.Tables[0].Rows)
            {
                DataRow row = dsKehoach_Banhang.Tables[0].NewRow();
                row["Stt"] = dtr["Stt"];
                row["Ten_Khachhang"] = dtr["Ten_Khachhang"];
                row["Soluong"] = dtr["Soluong"];
                row["Ten_Hanghoa_Ban"] = dtr["Ten_Hanghoa_Ban"];
                row["Ten_Cuahang_Ban"] = dtr["Ten_Cuahang_Ban"];
                dsKehoach_Banhang.Tables[0].Rows.Add(row);
            }
            _rptKehoach_Banhang.xrTableCell_Nhanvien_Bh.Text = lookUpEdit_Nhansu_Banhang.Text;
            _rptKehoach_Banhang.xrcell_Ngay_Chungtu.Text = dtNgay_Chungtu.Text;
            _rptKehoach_Banhang.DataSource = dsKehoach_Banhang;
            _rptKehoach_Banhang.CreateDocument();
            frmReport.printControl1.PrintingSystem = _rptKehoach_Banhang.PrintingSystem;
            frmReport.MdiParent = this.MdiParent;
            frmReport.WindowState = FormWindowState.Maximized;
            frmReport.Show();
            frmReport.Activate();
            return base.PerformPrintPreview();
        }

        #endregion

        #region Event

        private void gridView4_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //Kiem tra so luong ton
            this.DoClickEndEdit(dgware_Kehoach_Chitiet);
            if (e.Column.FieldName == "Sanluong_Tuan1" || e.Column.FieldName == "Sanluong_Tuan2"
                || e.Column.FieldName == "Sanluong_Tuan3" || e.Column.FieldName == "Sanluong_Tuan4")
            {
                gvKehoac_Chitiet.SetFocusedRowCellValue("Sanluong_Tong_Thang", Convert.ToDecimal("0" + gvKehoac_Chitiet.GetFocusedRowCellValue("Sanluong_Tuan1"))
                                                                            + Convert.ToDecimal("0" + gvKehoac_Chitiet.GetFocusedRowCellValue("Sanluong_Tuan2"))
                                                                            + Convert.ToDecimal("0" + gvKehoac_Chitiet.GetFocusedRowCellValue("Sanluong_Tuan3"))
                                                                            + Convert.ToDecimal("0" + gvKehoac_Chitiet.GetFocusedRowCellValue("Sanluong_Tuan4")));
            }
            gvKehoac_Chitiet.BestFitColumns();
        }

        private void gridView4_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if ("" + gvKehoac_Chitiet.GetFocusedRowCellValue("Id_Hdbanhang_Chitiet") == "")
                return;
            dgware_Kehoach_Chitiet.DataSource = ds_Kehoach_Banhang_Chitiet.Tables[0];
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.DisplayInfo_Details();
        }

        #endregion

        void DisplayInfo_Details()
        {
            identity = gvKehoach.GetFocusedRowCellValue("Id_Kehoach_Banhang");
            this.ds_Kehoach_Banhang_Chitiet = objWareService.Ware_Kehoach_Banhang_Chitiet_SelectById_Kehoach(identity).ToDataSet();
            this.dgware_Kehoach_Chitiet.DataSource = ds_Kehoach_Banhang_Chitiet.Tables[0];
            gvKehoac_Chitiet.BestFitColumns();
            gvKehoac_Chitiet.ExpandAllGroups();
            DataBindingControl();
        }

        private void gvHoadon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ClearDataBindings();
            ResetText();
            if (e.FocusedRowHandle >= 0)
                DisplayInfo_Details();
        }

        private void Frmware_Hdbanhang_noVAT_Hhban_Load(object sender, EventArgs e)
        {
            DisplayInfo();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Load_Gridview();
        }

    }
}