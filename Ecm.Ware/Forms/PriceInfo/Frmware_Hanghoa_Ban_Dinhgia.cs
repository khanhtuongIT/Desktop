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
    public partial class Frmware_Hanghoa_Ban_Dinhgia : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet ds_Collection = new DataSet();
        DataSet ds_Hanghoa_Ban = new DataSet();
        DataSet ds_Hanghoa_Dinhgia = new DataSet();
        //DataSet dsSys_Lognotify = null;
        DataSet ds_Donvitinh_quydoi = new DataSet();
        DataSet dsNhom_Hanghoa_Ban = new DataSet();
        DataSet ds_Collection_Log = new DataSet();
        DataSet dsWare_Hanghoa_Dinhgia_Khuvuc_Chitiet = new DataSet();
        DataSet dsWare_Hanghoa_Dinhgia_Cap_Chitiet = new DataSet();
        DataSet ds_Heso_Chuongtrinh = new DataSet();


        int Heso_Cap;
        int Khuvuc;

        object Id_Loai_Hanghoa = null;
        object Id_Hanghoa_Dinhgia = null;
        object identity;

        #region local data

        //string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        //string xml_WARE_DM_NHOM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Nhom_Hanghoa_Ban.xml";
        //string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";
        //DateTime dtlc_ware_dm_hanghoa_ban;
        //DateTime dtlc_ware_dm_donvitinh;
        //DateTime dtlc_ware_dm_nhom_hanghoa_ban;
        #endregion

        #region  Initialize

        public Frmware_Hanghoa_Ban_Dinhgia()
        {
            InitializeComponent();

            GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(this);

            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");

            this.repositoryItemDateEdit_Ngay_Batdau.MinValue = new DateTime(2000, 01, 01);
            this.repositoryItemDateEdit_Ngay_Ketthuc.MinValue = new DateTime(2000, 01, 01);
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            //this.lookUpEdit_Loai_Hanghoa_Ban.Properties.ReadOnly = true;
            ds_Heso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso("Cach_Tinh_Gia").ToDataSet();

            Heso_Cap = Convert.ToInt32(ds_Heso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='Cap'", "Tinh giá theo cấp"))[0]["Heso"]);

            if (Heso_Cap == 1)
            {

                TabKhuVuc.PageVisible = false;

                gridColumn_Dongia.Visible = false;
            }
            else
            {
                TabCap.PageVisible = false;
                gridColumn_Dongia.Visible = true;
            }
            this.DisplayInfo();
        }

        void LoadMasterData()
        {
            ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            dsNhom_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet();
            DataSet dsDonvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
            gridLookUpEdit_Donvitinh.DataSource = dsDonvitinh.Tables[0];
            gridLookUpEdit_Nhom_Hanghoa_Ban.DataSource = dsNhom_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];

            gridLookUpEdit_Cap.DataSource = objMasterService.Ware_Dm_Cap_SelectAll().ToDataSet().Tables[0];
            gridLookUpEdit_Khuvuc.DataSource = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet().Tables[0];
        }

        #endregion


        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                LoadMasterData();
                ds_Donvitinh_quydoi = objMasterService.Get_All_Ware_Dm_Donvitinh_Quydoi().ToDataSet();
                DataSet dsWare_Dm_Loai_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet();
                //lookUpEdit_Loai_Hanghoa_Ban.Properties.DataSource = dsWare_Dm_Loai_Hanghoa_Ban.Tables[0];
                gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = dsWare_Dm_Loai_Hanghoa_Ban.Tables[0];
                dgware_Dm_Loai_Hanghoa_Ban.DataSource = dsWare_Dm_Loai_Hanghoa_Ban.Tables[0];
                this.DisplayInfo_Hanghoa_Dinhgia(gridView2.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban"));
                this.ChangeStatus(false);
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
            dgware_Dm_Loai_Hanghoa_Ban.Enabled = !editTable;
            this.gvware_Hanghoa_Ban_Dinhgia.OptionsBehavior.Editable = editTable;
            this.gridView2.OptionsBehavior.Editable = editTable;
            this.dgware_Hanghoa_Ban_Dinhgia.EmbeddedNavigator.Buttons.Append.Enabled = editTable;
            this.dgware_Hanghoa_Ban_Dinhgia.EmbeddedNavigator.Buttons.Remove.Enabled = editTable;
            this.dgware_Hanghoa_Ban_Dinhgia.EmbeddedNavigator.Enabled = editTable;

            if (Heso_Cap != 1)
            {
                btnThem_GiaKV.Enabled = !editTable;
            }
            else
            {
                btn_Them_Cap.Enabled = !editTable;
            }
            //btnNhap_Excel.Enabled = editTable;
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Hanghoa_Dinhgia objWare_Hanghoa_Dinhgia = new Ecm.WebReferences.WareService.Ware_Hanghoa_Dinhgia();
            objWare_Hanghoa_Dinhgia.Id_Hanghoa_Dinhgia = Id_Hanghoa_Dinhgia;
            return objWareService.Delete_Ware_Hanghoa_Dinhgia(objWare_Hanghoa_Dinhgia);
        }

        public override bool PerformAdd()
        {
            dgware_Hanghoa_Ban_Dinhgia.EmbeddedNavigator.Buttons.Append.Visible = true;
            this.ChangeStatus(true);
            this.ResetText();
            Id_Loai_Hanghoa = gridView2.GetFocusedRowCellValue(gridView2.Columns["Id_Loai_Hanghoa_Ban"]);
            ClearDataBindings();
            return true;
        }

        private DataSet GetDataSet_Dm_Hanghoa_Ban(object Id_Loai_Hanghoa_Ban, object Ma_Hanghoa_Ban, object Ten_Hanghoa_Ban, object Barcode_Txt)
        {
            var strDm_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Loai_Hh_Ban_None_Dinhgia(
                Id_Loai_Hanghoa_Ban, Ma_Hanghoa_Ban, Ten_Hanghoa_Ban, Barcode_Txt);
            return strDm_Hanghoa_Ban.ToDataSet();
        }

        public override bool PerformEdit()
        {
            if (gridView2.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban") == null)
                return false;
            Id_Hanghoa_Dinhgia = gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Hanghoa_Dinhgia"]);
            this.ChangeStatus(true);
            this.ResetText();
            ClearDataBindings();
            if (gridView2.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban") != null)
                ds_Hanghoa_Ban = this.GetDataSet_Dm_Hanghoa_Ban(gridView2.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban"), null, null, null);
            else
                ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            return true;
        }

        public override bool PerformCancel()
        {

            ResetText();
            this.DisplayInfo();
            this.DisplayInfo_Hanghoa_Dinhgia(0);
            return true;
        }

        public override bool PerformSave()
        {
            return this.PerformSaveChanges();
        }

        public override bool PerformSaveChanges()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Hanghoa_Ban"], "");
            hashtableControls.Add(gvware_Hanghoa_Ban_Dinhgia.Columns["Dongia_Ban"], "");
            //hashtableControls.Add(gvware_Hanghoa_Ban_Dinhgia.Columns["Ngay_Batdau"], "");
            //hashtableControls.Add(gvware_Hanghoa_Ban_Dinhgia.Columns["Barcode_Txt"], "");

            this.DoClickEndEdit(dgware_Hanghoa_Ban_Dinhgia);
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvware_Hanghoa_Ban_Dinhgia))
                return false;
            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDateGrid(gvware_Hanghoa_Ban_Dinhgia.Columns["Ngay_Batdau"], gvware_Hanghoa_Ban_Dinhgia.Columns["Ngay_Ketthuc"], gvware_Hanghoa_Ban_Dinhgia))
                return false;
            try
            {
                Constraint constraint = new UniqueConstraint("constraint1",
                        new DataColumn[] {ds_Collection.Tables[0].Columns["Id_Hanghoa_Ban"],
                ds_Collection.Tables[0].Columns["Id_Donvitinh"],ds_Collection.Tables[0].Columns["Ngay_Batdau"] }, false);
                ds_Collection.Tables[0].Constraints.Clear();
                ds_Collection.Tables[0].Constraints.Add(constraint);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("These columns don't currently have unique values") != -1)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa đã được định giá");
                    return false;
                }
                MessageBox.Show(ex.ToString());
            }
            for (int i = 0; i < gvware_Hanghoa_Ban_Dinhgia.RowCount; i++)
            {
                if (Convert.ToDecimal("0" + gvware_Hanghoa_Ban_Dinhgia.GetRowCellValue(i, gvware_Hanghoa_Ban_Dinhgia.Columns["Dongia"])) >
                    Convert.ToDecimal("0" + gvware_Hanghoa_Ban_Dinhgia.GetRowCellValue(i, gvware_Hanghoa_Ban_Dinhgia.Columns["Dongia_Ban"])))
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Đơn giá bán không được nhỏ hơn đơn giá mua");
                    gvware_Hanghoa_Ban_Dinhgia.FocusedRowHandle = i;
                    return false;
                }

                if (Convert.ToDecimal("0" + gvware_Hanghoa_Ban_Dinhgia.GetRowCellValue(i, gvware_Hanghoa_Ban_Dinhgia.Columns["Dongia_Bansi"])) >
                    Convert.ToDecimal("0" + gvware_Hanghoa_Ban_Dinhgia.GetRowCellValue(i, gvware_Hanghoa_Ban_Dinhgia.Columns["Dongia_Ban"])))
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Đơn giá bán lẻ không được nhỏ hơn đơn giá sỉ");
                    gvware_Hanghoa_Ban_Dinhgia.FocusedRowHandle = i;
                    return false;
                }
            }
            try
            {
                this.DoClickEndEdit(dgware_Hanghoa_Ban_Dinhgia);
                objWareService.Update_Ware_Hanghoa_Dinhgia_Collection(this.ds_Collection);
                dgware_Dm_Loai_Hanghoa_Ban.Enabled = true;
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
            LoadMasterData();
            this.DisplayInfo_Hanghoa_Dinhgia(Id_Loai_Hanghoa);
            this.ChangeStatus(false);
            return true;
        }

        public override bool PerformDelete()
        {
            if (Id_Hanghoa_Dinhgia == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn chưa chọn hàng hóa để xóa, chọn lại");
                return false;
            }
            if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Hanghoa_Dinhgia"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Hanghoa_Dinhgia")   }) == DialogResult.Yes)
            {
                try
                {
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo_Hanghoa_Dinhgia(Id_Loai_Hanghoa);
            }
            return true;
        }
        public override bool PerformPrintPreview()
        {
            printReport_Hanghoa_Dinhgia();
            return base.PerformPrintPreview();
        }

        #endregion

        #region Even

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                gvware_Hanghoa_Ban_Dinhgia.SetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Loai_Hanghoa_Ban"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Id_Loai_Hanghoa_Ban"]);
                gvware_Hanghoa_Ban_Dinhgia.SetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Ten_Hanghoa_Ban"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Ten_Hanghoa_Ban"]);
                gvware_Hanghoa_Ban_Dinhgia.SetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Size"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Size"]);
                gvware_Hanghoa_Ban_Dinhgia.SetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Quycach"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Quycach"]);
                gvware_Hanghoa_Ban_Dinhgia.SetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Dongia"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Dongia_Mua"]);
                gvware_Hanghoa_Ban_Dinhgia.SetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Donvitinh"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);
            }
            if (e.Column.FieldName == "Id_Donvitinh")
            {
                if (gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Donvitinh"]).ToString() == "")
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa chưa có Đơn vị tính, vui lòng kiểm tra lại");
                    gvware_Hanghoa_Ban_Dinhgia.CancelUpdateCurrentRow();
                    return;
                }
                DataRow[] dtr_DVT = ds_Donvitinh_quydoi.Tables[0].Select("Id_Hanghoa_Ban = " + gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Hanghoa_Ban"]));
                DataRow[] dtr = ds_Hanghoa_Ban.Tables[0].Select("Id_Hanghoa_Ban = " + gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Hanghoa_Ban"])
                                                + " and Id_Donvitinh = " + gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Donvitinh"]));
                if (dtr.Length > 0)
                    gvware_Hanghoa_Ban_Dinhgia.SetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Barcode_Txt"], dtr[0]["Barcode_Txt"]);
                else
                {
                    DataRow[] dtr_Hanghoa_Ban = ds_Hanghoa_Ban.Tables[0].Select("Id_Hanghoa_Ban  = " + gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Hanghoa_Ban"]));
                    gvware_Hanghoa_Ban_Dinhgia.SetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Barcode_Txt"], dtr_Hanghoa_Ban[0]["Barcode_Txt"] +
                                                        "" + gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Donvitinh"]).ToString());
                }
                if (dtr_DVT.Length > 0)
                {
                    for (int i = 0; i < dtr_DVT.Length; i++)
                    {
                        dtr = null;
                        dtr = ds_Hanghoa_Ban.Tables[0].Select("Id_Hanghoa_Ban = " + gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Hanghoa_Ban"]));
                        if (dtr[0]["Dongia_Mua"].ToString() != "")
                        {
                            if (gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Donvitinh"]).Equals(dtr_DVT[i]["Id_Donvitinh2"]))
                            {
                                decimal value = Convert.ToDecimal(dtr[0]["Dongia_Mua"])
                                            / (Convert.ToDecimal(dtr_DVT[i]["Soluong2"]) / Convert.ToDecimal(dtr_DVT[i]["Soluong1"]));
                                gvware_Hanghoa_Ban_Dinhgia.SetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Dongia"], value);
                                break;
                            }
                            else
                                gvware_Hanghoa_Ban_Dinhgia.SetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Dongia"], dtr[0]["Dongia_Mua"]);
                        }
                    }
                }
            }
        }

        private void gridLookUpEdit_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                        gvware_Hanghoa_Ban_Dinhgia.SetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Hanghoa_Ban"], SelectedObject.Id_Hanghoa_Ban);
                    }
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Id_Loai_Hanghoa = gridView2.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban");
            if (Id_Loai_Hanghoa != null)
            {
                this.DisplayInfo_Hanghoa_Dinhgia(gridView2.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban"));
                this.item_Edit.Enabled = true;
                //this.lookUpEdit_Loai_Hanghoa_Ban.EditValue = gridView2.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban");
                this.DataBindingControl();
                Id_Loai_Hanghoa = gridView2.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban");
            }
            else
            {
                this.item_Edit.Enabled = false;
                dgware_Hanghoa_Ban_Dinhgia.DataSource = null;
            }
        }

        public void DisplayInfo_Hanghoa_Dinhgia(object Id_Loai_Hanghoa)
        {
            ds_Hanghoa_Ban = GetDataSet_Dm_Hanghoa_Ban(Id_Loai_Hanghoa, null, null, null);
            if (Id_Loai_Hanghoa != null)
                ds_Collection = objWareService.Get_All_Ware_Hanghoa_Dinhgia_By_Id_Loai_hh(Id_Loai_Hanghoa).ToDataSet();
            //ds_Collection.Tables[0].Columns.Add("Soluong_In", typeof(int));
            dgware_Hanghoa_Ban_Dinhgia.DataSource = ds_Collection;
            dgware_Hanghoa_Ban_Dinhgia.DataMember = ds_Collection.Tables[0].TableName;
            gvware_Hanghoa_Ban_Dinhgia.BestFitColumns();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (FormState == GoobizFrame.Windows.Forms.FormState.View)
            {
                Id_Hanghoa_Dinhgia = gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue("Id_Hanghoa_Dinhgia");
                Id_Loai_Hanghoa = gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban");
                //DataBindingControl();
                //Display Giá theo KV của mặt hàng
                if (Id_Hanghoa_Dinhgia != null)
                {
                    if (Heso_Cap != 1)
                    {
                        dsWare_Hanghoa_Dinhgia_Khuvuc_Chitiet = objWareService.Get_All_Ware_Hanghoa_Dinhgia_Khuvuc(Id_Hanghoa_Dinhgia).ToDataSet();
                        dgWare_Hanghoa_Dinhgia_Khuvuc.DataSource = dsWare_Hanghoa_Dinhgia_Khuvuc_Chitiet.Tables[0];
                        lblTenhang1.Text = gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue("Ten_Hanghoa_Ban").ToString();
                    }
                    else
                    {

                        dsWare_Hanghoa_Dinhgia_Cap_Chitiet = objWareService.Ware_Dongia_Cap_Selectall(Id_Hanghoa_Dinhgia).ToDataSet();
                        dgWare_Hanghoa_Dinhgia_Cap.DataSource = dsWare_Hanghoa_Dinhgia_Cap_Chitiet.Tables[0];
                        lblTenhang2.Text = gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue("Ten_Hanghoa_Ban").ToString();
                    }
                }
                else
                    {
                    lblTenhang1.Text = "";
                    lblTenhang2.Text = "";
                    }
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.gvware_Hanghoa_Ban_Dinhgia.OptionsBehavior.Editable = true;
            this.item_Save.Enabled = true;
            this.item_Cancel.Enabled = true;
            this.item_Close.Enabled = false;
            this.item_Edit.Enabled = false;
            this.item_Refresh.Enabled = false;
            FormState = GoobizFrame.Windows.Forms.FormState.Add;
            ClearDataBindings();
            if (gridView2.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban") == null)
                return;
        }


        private void btnIn_Banggia_Click(object sender, EventArgs e)
        {
            printReport_Hanghoa_Dinhgia();
        }

        private void gridLookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            //{

            //    Ecm.Ware.Forms.Frmware_Hdbanhang_Donvitinh_Dialog frm_Donvitinh = new Frmware_Hdbanhang_Donvitinh_Dialog();
            //    frm_Donvitinh.setId_Hanghoa_Ban(gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Hanghoa_Ban"]));
            //    frm_Donvitinh.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    frm_Donvitinh.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    frm_Donvitinh.ShowDialog();
            //    if (frm_Donvitinh.Id_Donvitinh != null)
            //    {
            //        gvware_Hanghoa_Ban_Dinhgia.SetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Donvitinh"], frm_Donvitinh.Id_Donvitinh);
            //    }
            //    gvware_Hanghoa_Ban_Dinhgia.BestFitColumns();
            //}
        }

        private void lookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //if (lookUpEdit_Hanghoa_Ban.EditValue == null)
            //    return;
            //if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            //{
            //    Ecm.Ware.Forms.Frmware_Hdbanhang_Donvitinh_Dialog frm_Donvitinh = new Frmware_Hdbanhang_Donvitinh_Dialog();
            //    frm_Donvitinh.setId_Hanghoa_Ban(lookUpEdit_Hanghoa_Ban.EditValue);
            //    frm_Donvitinh.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //    frm_Donvitinh.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    frm_Donvitinh.ShowDialog();
            //    if (frm_Donvitinh.Id_Donvitinh != null)
            //    {
            //        lookUpEdit_Donvitinh.EditValue = frm_Donvitinh.Id_Donvitinh;
            //    }
            //    frm_Donvitinh.Dispose();
            //}
        }
        #endregion

        #region Custom Method

        void setDatasourceForGridview1()
        {
            dgware_Hanghoa_Ban_Dinhgia.DataSource = ds_Collection;
            dgware_Hanghoa_Ban_Dinhgia.DataMember = ds_Collection.Tables[0].TableName;
            //this.lookUpEdit_Loai_Hanghoa_Ban.EditValue = Id_Loai_Hanghoa;
            this.Data = ds_Collection;
            this.GridControl = dgware_Hanghoa_Ban_Dinhgia;
            this.DataBindingControl();
            this.gvware_Hanghoa_Ban_Dinhgia.BestFitColumns();
        }

        void printReport_Hanghoa_Dinhgia()
        {
            //DataSets.dsDinhgia_Hanghoa ds_Dinhgia = new Ecm.Ware.DataSets.dsDinhgia_Hanghoa();
            //ds_Collection = objWareService.Get_All_Ware_Hanghoa_Dinhgia().ToDataSet();
            //Reports.rptThumau rpt_Dinhgia = new Reports.rptThumau();

            //GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            //frmPrintPreview.Report = rpt_Dinhgia;
            //rpt_Dinhgia.DataSource = ds_Dinhgia;
            //bool check;

            //for (int i = 0; i < ds_Collection.Tables[0].Rows.Count; i++)
            //{
            //    check = false;
            //    if ("" + ds_Collection.Tables[0].Rows[i]["Ngay_Ketthuc"] == "")
            //        check = true;
            //    else
            //        if (Convert.ToDateTime(ds_Collection.Tables[0].Rows[i]["Ngay_Ketthuc"]) > objWareService.GetServerDateTime())
            //            check = true;

            //    if (check)
            //    {
            //        DataRow dtr_Dinhgia = ds_Dinhgia.Tables[0].NewRow();
            //        dtr_Dinhgia["ten_hanghoa_ban"] = ds_Collection.Tables[0].Rows[i]["Ten_Hanghoa_Ban"];
            //        dtr_Dinhgia["dongia"] = ds_Collection.Tables[0].Rows[i]["Dongia"];
            //        dtr_Dinhgia["dongia_ban"] = ds_Collection.Tables[0].Rows[i]["Dongia_Ban"];
            //        dtr_Dinhgia["dongia_bansi"] = ds_Collection.Tables[0].Rows[i]["Dongia_Bansi"];
            //        dtr_Dinhgia["ghichu"] = ds_Collection.Tables[0].Rows[i]["Ghichu"];
            //        dtr_Dinhgia["ngay_ketthuc"] = ds_Collection.Tables[0].Rows[i]["Ngay_Ketthuc"];
            //        dtr_Dinhgia["ngay_batdau"] = ds_Collection.Tables[0].Rows[i]["Ngay_Batdau"];
            //        dtr_Dinhgia["ten_loai_hanghoa_ban"] = ds_Collection.Tables[0].Rows[i]["Ten_Loai_Hanghoa_Ban"];
            //        dtr_Dinhgia["ten_donvitinh"] = ds_Collection.Tables[0].Rows[i]["Ten_Donvitinh"];
            //        dtr_Dinhgia["ma_hanghoa_ban"] = ds_Collection.Tables[0].Rows[i]["Ma_Hanghoa_Ban"];
            //        ds_Dinhgia.Tables[0].Rows.Add(dtr_Dinhgia);
            //    }
            //}
            //ds_Dinhgia.AcceptChanges();
            //#region Set he so ctrinh - logo, ten cty

            //using (DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_Collection3().ToDataSet())
            //{
            //    DataSet dsCompany_Paras = new DataSet();
            //    dsCompany_Paras.Tables.Add("Company_Paras");
            //    dsCompany_Paras.Tables[0].Columns.Add("CompanyName", typeof(string));
            //    dsCompany_Paras.Tables[0].Columns.Add("CompanyAddress", typeof(string));
            //    dsCompany_Paras.Tables[0].Columns.Add("CompanyLogo", typeof(byte[]));

            //    byte[] imageData = Convert.FromBase64String("" + dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyLogo"))[0]["Heso"]);

            //    dsCompany_Paras.Tables[0].Rows.Add(new object[]  {    
            //        dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyName"))[0]["Heso"]
            //        ,dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'","CompanyAddress"))[0]["Heso"]
            //        ,imageData});

            //    rpt_Dinhgia.xrc_CompanyName.DataBindings.Add(
            //        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
            //    rpt_Dinhgia.xrc_CompanyAddress.DataBindings.Add(
            //        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            //}
            //#endregion
            //rpt_Dinhgia.txtNguoiLapPhieu.Text = "" + GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserEntry("User_Fullname"); //dtr_nhansu[0]["User_Fullname"].ToString();
            //rpt_Dinhgia.CreateDocument();

            //GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rpt_Dinhgia);
            //if (Convert.ToBoolean(oReportOptions.PrintPreview))
            //{
            //    frmPrintPreview.Text = "" + oReportOptions.Caption;
            //    frmPrintPreview.printControl1.PrintingSystem = rpt_Dinhgia.PrintingSystem;
            //    frmPrintPreview.MdiParent = this.MdiParent;
            //    frmPrintPreview.Show();
            //    frmPrintPreview.Text = "Bảng định giá Hàng hóa";
            //    frmPrintPreview.Activate();
            //}
            //else
            //{
            //    var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rpt_Dinhgia);
            //    reportPrintTool.Print();
            //}
        }

        #endregion

        private void gridText_Dongia_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if ("" + e.NewValue == "")
                {
                    gvware_Hanghoa_Ban_Dinhgia.SetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.FocusedColumn, null);
                    e.Cancel = true;
                }
                else if (e.NewValue.ToString().Length > 10)
                {
                    //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.                                        
                    e.Cancel = true;
                }
                //else if (Convert.ToDecimal(e.NewValue) <= 0)
                //{
                //    //    GoobizFrame.Windows.Forms.MessageDialog.Show("Đơn giá phải lớn hơn 0, vui lòng nhập lại.");
                //    e.Cancel = true;
                //}
            }
            catch (Exception ex)
            {
                ex.ToString();
                //Nếu đơn giá vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị đơn giá không hợp lệ, vui lòng nhập lại.");
                gvware_Hanghoa_Ban_Dinhgia.SetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Dongia"], null);
                e.Cancel = true;
            }
        }

        private void gridText_SoluongNhan_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.NewValue.ToString() == "" || e.NewValue.ToString() == "0")
                    e.Cancel = true;

                if (e.NewValue.ToString().Length > 7)
                    e.Cancel = true;
            }
        }

        private void btnCancel_KV_Click(object sender, EventArgs e)
        {
            ChangeStatus_KV(false);
        }

        private void btnThem_GiaKV_Click_1(object sender, EventArgs e)
        {
            if (gvware_Hanghoa_Ban_Dinhgia.RowCount == 0)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa có thông tin hàng hóa");
                return;
            }
            if (dsWare_Hanghoa_Dinhgia_Khuvuc_Chitiet.Tables.Count == 0)
            {
                dsWare_Hanghoa_Dinhgia_Khuvuc_Chitiet = objWareService.Get_All_Ware_Hanghoa_Dinhgia_Khuvuc(-1).ToDataSet();
                dgWare_Hanghoa_Dinhgia_Khuvuc.DataSource = dsWare_Hanghoa_Dinhgia_Khuvuc_Chitiet.Tables[0];
            }
            ChangeStatus_KV(true);
        }

        private void btn_Save_KV_Click(object sender, EventArgs e)
        {
            //if (gvWare_Hanghoa_Dinhgia_Khuvuc.RowCount == 0)
            //{
            //    GoobizFrame.Windows.Forms.MessageDialog.Show("Vui lòng nhập đầy đủ thông tin");
            //    return;
            //}
            foreach (DataRow dtr in dsWare_Hanghoa_Dinhgia_Khuvuc_Chitiet.Tables[0].Rows)
                if (dtr.RowState != DataRowState.Deleted)
                    dtr["Id_Hanghoa_Dinhgia"] = gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue(gvware_Hanghoa_Ban_Dinhgia.Columns["Id_Hanghoa_Dinhgia"]); ;
            objWareService.Update_Ware_Hanghoa_Dinhgia_Khuvuc_Collection(dsWare_Hanghoa_Dinhgia_Khuvuc_Chitiet);
            ChangeStatus_KV(false);
        }

        void ChangeStatus_KV(bool editable)
        {
            btn_Save_KV.Enabled = editable;
            btnCancel_KV.Enabled = editable;
            gvWare_Hanghoa_Dinhgia_Khuvuc.OptionsBehavior.ReadOnly = !editable;
            xtraHNavigator1.Enabled = editable;
            btnThem_GiaKV.Enabled = !editable;
            this.ChangeStatus(editable);
            dgware_Hanghoa_Ban_Dinhgia.Enabled = !editable;
            barSystem.Visible = !editable;
        }

        private void gvware_Hanghoa_Ban_Dinhgia_DataSourceChanged(object sender, EventArgs e)
        {
            if (FormState == GoobizFrame.Windows.Forms.FormState.View)
            {
                Id_Hanghoa_Dinhgia = gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue("Id_Hanghoa_Dinhgia");
                if (Id_Hanghoa_Dinhgia != null)
                {
                    if (Heso_Cap != 1)
                    {
                        dsWare_Hanghoa_Dinhgia_Khuvuc_Chitiet = objWareService.Get_All_Ware_Hanghoa_Dinhgia_Khuvuc(Id_Hanghoa_Dinhgia).ToDataSet();
                        dgWare_Hanghoa_Dinhgia_Khuvuc.DataSource = dsWare_Hanghoa_Dinhgia_Khuvuc_Chitiet.Tables[0];
                        lblTenhang1.Text = gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue("Ten_Hanghoa_Ban").ToString(); ;
                    }
                    else
                    {
                        dsWare_Hanghoa_Dinhgia_Cap_Chitiet = objWareService.Ware_Dongia_Cap_Selectall(Id_Hanghoa_Dinhgia).ToDataSet();
                        dgWare_Hanghoa_Dinhgia_Cap.DataSource = dsWare_Hanghoa_Dinhgia_Cap_Chitiet.Tables[0];
                        lblTenhang2.Text = gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue("Ten_Hanghoa_Ban").ToString(); ;
                    }
                }
                else
                {
                    if (Heso_Cap != 1)
                    {
                        dsWare_Hanghoa_Dinhgia_Khuvuc_Chitiet = objWareService.Get_All_Ware_Hanghoa_Dinhgia_Khuvuc(-1).ToDataSet();
                        dgWare_Hanghoa_Dinhgia_Khuvuc.DataSource = dsWare_Hanghoa_Dinhgia_Khuvuc_Chitiet.Tables[0];
                        lblTenhang1.Text = "";
                    }
                    else
                    {
                        dsWare_Hanghoa_Dinhgia_Cap_Chitiet = objWareService.Ware_Dongia_Cap_Selectall(-1).ToDataSet();
                        dgWare_Hanghoa_Dinhgia_Cap.DataSource = dsWare_Hanghoa_Dinhgia_Cap_Chitiet.Tables[0];
                        lblTenhang2.Text = "";
                    }
                }
            }
        }

        private void dgware_Dm_Donvitinh_Quydoi_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {

        }

        private void btn_Them_Cap_Click(object sender, EventArgs e)
        {
            if (gvware_Hanghoa_Ban_Dinhgia.RowCount == 0)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa có thông tin hàng hóa");
                return;
            }

            if (dsWare_Hanghoa_Dinhgia_Cap_Chitiet.Tables.Count == 0)
            {

                dsWare_Hanghoa_Dinhgia_Cap_Chitiet = objWareService.Ware_Dongia_Cap_Selectall(-1).ToDataSet();
                dgWare_Hanghoa_Dinhgia_Cap.DataSource = dsWare_Hanghoa_Dinhgia_Cap_Chitiet.Tables[0];
            }
            ChangeStatus_Cap(true);

        }
        void ChangeStatus_Cap(bool editable)
        {
            btn_Luu_Cap.Enabled = editable;
            btn_Huy.Enabled = editable;
            gvWare_Hanghoa_Dinhgia_Cap.OptionsBehavior.ReadOnly = !editable;
            xtraNar.Enabled = editable;
            btn_Them_Cap.Enabled = !editable;
            this.ChangeStatus(editable);
            dgware_Hanghoa_Ban_Dinhgia.Enabled = !editable;
            barSystem.Visible = !editable;
        }
        private void btn_Luu_Cap_Click(object sender, EventArgs e)
        {
            foreach (DataRow dtr in dsWare_Hanghoa_Dinhgia_Cap_Chitiet.Tables[0].Rows)
                if (dtr.RowState != DataRowState.Deleted)
                    try
                    {
                        dtr["Id_Hanghoa_Dinhgia"] = gvware_Hanghoa_Ban_Dinhgia.GetFocusedRowCellValue("Id_Hanghoa_Dinhgia"); ;
                        objWareService.Update_Ware_Dongia_Cap_Collection(dsWare_Hanghoa_Dinhgia_Cap_Chitiet);
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
            ChangeStatus_Cap(false);
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            ChangeStatus_Cap(false);
        }

    }
}

