using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;

namespace Ecm.Ware.Forms
{
    public partial class Frmware_Khachhang_Quota :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();        
        DataSet ds_Collection = new DataSet();

        public Frmware_Khachhang_Quota()
        {
            InitializeComponent();
            this.DisplayInfo();
            repositoryItemDateEdit1.MinValue = new DateTime(2000, 01, 01);
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            gridLookUpEdit_Vip_Member.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(
                 GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);

            bool isAdmin = ( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() == "ADMIN");
            gridView1.Columns["Id_Vip_Member"].OptionsColumn.ReadOnly = !isAdmin;
            gridView1.Columns["Ngay_Batdau_Vip"].OptionsColumn.ReadOnly = !isAdmin;
            gridView1.Columns["Ngay_Ketthuc_Vip"].OptionsColumn.ReadOnly = !isAdmin;
            gridView1.Columns["Fix_Rate"].OptionsColumn.ReadOnly = !isAdmin;
        }

        public override void DisplayInfo()
        {
            try
            {
                DataSet dsKhachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
                gridLookUpEdit_Khachhang.DataSource = dsKhachhang.Tables[0];
                gridLookUpEdit_Vip_Member.DataSource = objWareService.Get_All_Ware_Vip_Member().ToDataSet().Tables[0];

                ds_Collection = objWareService.Get_All_Ware_Khachhang_Quota().ToDataSet();

                if (!ds_Collection.Tables[0].Columns.Contains("Chon"))
                    ds_Collection.Tables[0].Columns.Add("Chon", typeof(bool));
                dgware_Khachhang_Quota.DataSource = ds_Collection;
                dgware_Khachhang_Quota.DataMember = ds_Collection.Tables[0].TableName;

                if (!chkPrint_Card.Checked)
                {
                    this.Data = ds_Collection;
                    this.GridControl = dgware_Khachhang_Quota;
                }
                this.gridView1.BestFitColumns();                
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        #region Event Override

        public override bool PerformCancel()
        {
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSaveChanges()
        {
            this.DoClickEndEdit(dgware_Khachhang_Quota);
             GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gridView1.Columns["Id_Khachhang"], "");
            hashtableControls.Add(gridView1.Columns["Ngay_Batdau"], "");
            hashtableControls.Add(gridView1.Columns["Ngay_Ketthuc"], "");

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
                return false;

            if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDateGrid(gridView1.Columns["Ngay_Batdau"], gridView1.Columns["Ngay_Ketthuc"], gridView1))
                return false;

            foreach (DataRow dtr in ds_Collection.Tables[0].Rows)
            {
                if (dtr.RowState != DataRowState.Deleted)
                    if (dtr["Id_Vip_Member"].ToString() != "")
                        if (dtr["Max_Quota"].ToString() != "")
                        {
                             GoobizFrame.Windows.Forms.MessageDialog.Show("Khách hàng có mã số " + dtr["Ma_Khachhang"] + " không thể vừa là khách hàng VIP vừa là khách hàng quota \nVui lòng xóa thông tin quota");
                            return false;
                        }
            }
            try
            {
                ds_Collection.Tables[0].Columns["Id_Khachhang"].Unique = true;
                objWareService.Update_Ware_Khachhang_Quota_Collection(this.ds_Collection);
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Khách hàng đã tồn tại, vui lòng chọn lại");
                return false;
            }
            this.DisplayInfo();
            return true;
        }

        public override bool PerformEdit()
        {
            gridView1.OptionsBehavior.Editable = true;
            return base.PerformEdit();
        }

        public override bool PerformAdd()
        {
            gridView1.OptionsBehavior.Editable = true;
            this.addnewrow_clicked = true;
            return base.PerformAdd();
        }

        public override bool PerformPrintPreview()
        {
            this.DoClickEndEdit(dgware_Khachhang_Quota);
            if (chkPrint_Card.Checked)
                PrintCard();
            else
            {
                //IN DANH SACH KHACH HANG
                dgware_Khachhang_Quota.ShowPrintPreview();
            }
            return base.PerformPrintPreview();
        }

        #endregion

        #region Even

        private void dgware_Dm_Khachhang_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (Convert.ToInt32(objWareService.GetExistReferences("Ware_Dm_Khachhang", "Id_Khachhang", this.gridView1.GetFocusedRowCellValue("Id_Khachhang"))) > 0)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    e.Handled = true;
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Id_Khachhang")
            {
                if (gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Khachhang"]).ToString() != "")
                {
                    DataRow[] dtr = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet().Tables[0].Select("Id_Khachhang = " + gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Khachhang"]));
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Ma_Khachhang"], dtr[0]["Ma_Khachhang"]);
                }
            }
        }

        private void gridButtonEdit_Chitiet_Khucvuc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Frmware_Khachhang_Vip frmware_Khachhang_Vip = new Frmware_Khachhang_Vip();
                frmware_Khachhang_Vip.Text = "Chi tiết giảm giá theo khuc vực";
                 GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Khachhang_Vip);
                frmware_Khachhang_Vip.Id_Khachhang = gridView1.GetFocusedRowCellValue("Id_Khachhang");
                frmware_Khachhang_Vip.ShowDialog();
            }
        }

        private void gridLookUpEdit_Khachhang_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add frmware_Dm_Khachhang_Add = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add();
                frmware_Dm_Khachhang_Add.Text = "Khách hàng";
                 GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Khachhang_Add);
                frmware_Dm_Khachhang_Add.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                frmware_Dm_Khachhang_Add.item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                frmware_Dm_Khachhang_Add.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                frmware_Dm_Khachhang_Add.item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                frmware_Dm_Khachhang_Add.item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                frmware_Dm_Khachhang_Add.ShowDialog();
                if (frmware_Dm_Khachhang_Add.Id_Khachhang != null)
                    if (frmware_Dm_Khachhang_Add.Id_Khachhang.Length > 0)
                    {
                        gridLookUpEdit_Khachhang.DataSource = frmware_Dm_Khachhang_Add.Data.Tables[0];
                        gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Khachhang"], frmware_Dm_Khachhang_Add.Id_Khachhang[0]);
                        if (frmware_Dm_Khachhang_Add.Id_Khachhang.Length > 1)
                        {
                            for (int i = 1; i < frmware_Dm_Khachhang_Add.Id_Khachhang.Length; i++)
                            {
                                DataRow drnew = ds_Collection.Tables[0].NewRow();
                                drnew["Id_Khachhang"] = frmware_Dm_Khachhang_Add.Id_Khachhang[i];
                                ds_Collection.Tables[0].Rows.Add(drnew);
                            }
                        }
                    }
            }
        }

        void PrintCard()
        {
            if (ds_Collection.Tables[0].Select("Chon=True").Length == 0)
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Xin vui lòng chọn khách hàng để in.");
            else
            {
                this.DoClickEndEdit(dgware_Khachhang_Quota);
                DataSet dsPrint = ds_Collection.Clone();
                foreach (DataRow row in ds_Collection.Tables[0].Select("Chon=True"))
                {
                    dsPrint.Tables[0].ImportRow(row);
                }               
                 GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new  GoobizFrame.Windows.Forms.FrmPrintPreview();
                Reports.rptWare_Khachhang_Barcode rptWare_Khachhang_Barcode = new Ecm.Ware.Reports.rptWare_Khachhang_Barcode();
                rptWare_Khachhang_Barcode.DataSource = dsPrint.Tables[0];
                rptWare_Khachhang_Barcode.CreateDocument();

                frmPrintPreview.printControl1.PrintingSystem = rptWare_Khachhang_Barcode.PrintingSystem;
                frmPrintPreview.MdiParent = this.MdiParent;
                frmPrintPreview.Text = this.Text + "(Xem trang in)";
                frmPrintPreview.Report = rptWare_Khachhang_Barcode;
                frmPrintPreview.Show();
                frmPrintPreview.Activate();
            }
        }

        private void btnUpdateQuota_Click(object sender, EventArgs e)
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();
            foreach (DataRow dr in ds_Collection.Tables[0].Rows)
                objWareService.Update_Ware_Khachhang_Min_Quota(dr["Id_Khachhang"], objWareService.GetServerDateTime());
            DisplayInfo();
            WaitDialogForm.Close();
        }

        private void btnCalcMark_Click(object sender, EventArgs e)
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();
            foreach (DataRow dr in ds_Collection.Tables[0].Rows)
                objWareService.Update_Ware_Khachhang_VipMemeber(dr["Id_Khachhang"], objWareService.GetServerDateTime());
            DisplayInfo();
            WaitDialogForm.Close();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue(gridView1.Columns["Ma_Khachhang"]).ToString() == "")
                return;
            string ma_khachhang = "" + gridView1.GetFocusedRowCellValue(gridView1.FocusedColumn);
            Frmware_Dm_Khachhang_Info objFrmware_Dm_Khachhang_Info = new Frmware_Dm_Khachhang_Info();
            objFrmware_Dm_Khachhang_Info.Ma_Khachhang = ma_khachhang;
            objFrmware_Dm_Khachhang_Info.Text = "Thông tin chi tiết Khách hàng";
            objFrmware_Dm_Khachhang_Info.ShowDialog();
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            this.addnewrow_clicked = true;
        }

        private void dgware_Khachhang_Quota_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00021", new string[] { "" }) == DialogResult.No)
                    e.Handled = true;
            }
        }

        private void chkPrint_Card_CheckedChanged(object sender, EventArgs e)
        {
            chkAll.Enabled = chkPrint_Card.Checked;
            gridBand6.Visible = chkPrint_Card.Checked;

            DisplayInfo();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow dr in ds_Collection.Tables[0].Rows)
                dr["Chon"] = chkAll.EditValue;
        }

        private void gridText_Quota_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if ("" + e.NewValue == "")
                {
                    gridView1.SetFocusedRowCellValue("Max_Quota", null);
                    e.Cancel = true;
                }

                if (e.NewValue.ToString().Length > 9)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                //Nếu số lượng vượt quá khả năng nhập liệu sẽ hiện thông báo lỗi.
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị Quota vượt quá khả năng lưu trữ.");
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Max_Quota"], null);
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if (view.FocusedColumn.FieldName == "Id_Vip_Member"
                || view.FocusedColumn.FieldName == "Ngay_Ketthuc_Vip")
            {
                GridColumn columnNgay_Ketthuc = view.Columns["Ngay_Ketthuc"];
                GridColumn columnNgay_Ketthuc_Vip = view.Columns["Ngay_Ketthuc_Vip"];
                GridColumn columnId_Vip_Member = view.Columns["Id_Vip_Member"];

                object id_vip_member = view.GetRowCellValue(e.RowHandle, columnId_Vip_Member);
                try
                {
                    if (id_vip_member.ToString() != "")
                    {
                        gridView1.SetRowCellValue(e.RowHandle, "Max_Quota", null);
                        gridView1.SetRowCellValue(e.RowHandle, "Songay_Quota", null);
                        gridView1.SetRowCellValue(e.RowHandle, "Min_Quota", null);
                        gridView1.SetRowCellValue(e.RowHandle, "Ngay_Batdau_Vip", DateTime.Now.Date);
                        if (view.GetRowCellValue(e.RowHandle, columnNgay_Ketthuc).ToString() != ""
                            && view.GetRowCellValue(e.RowHandle, columnNgay_Ketthuc_Vip).ToString() != "")
                        {
                            DateTime dtNgay_Ketthuc = (DateTime)view.GetRowCellValue(e.RowHandle, columnNgay_Ketthuc);
                            DateTime dtNgay_Ketthuc_Vip = (DateTime)view.GetRowCellValue(e.RowHandle, columnNgay_Ketthuc_Vip);
                            if (dtNgay_Ketthuc_Vip > dtNgay_Ketthuc)
                                gridView1.SetRowCellValue(e.RowHandle, "Ngay_Ketthuc", dtNgay_Ketthuc_Vip);
                        }
                    }
                }
                catch (Exception ex)
                {
                    gridView1.CancelUpdateCurrentRow();
                }
            }
        }

        private void gridLookUpEdit_Vip_Member_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                this.gridView1.SetFocusedRowCellValue("Id_Vip_Member", null);
        }

        private void gridText_Songay_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                int songay = 0;
                if (gridView1.GetFocusedRowCellValue("Ngay_Batdau").ToString() != ""
                   && gridView1.GetFocusedRowCellValue("Ngay_Ketthuc").ToString() != "")
                {
                    TimeSpan timespan = DateTime.Parse(gridView1.GetFocusedRowCellValue("Ngay_Ketthuc").ToString()).Subtract(DateTime.Parse(gridView1.GetFocusedRowCellValue("Ngay_Batdau").ToString()));
                    songay = timespan.Days;
                }
                else
                    songay = 365;
                if ("" + e.NewValue == "")
                {
                    gridView1.SetFocusedRowCellValue("Songay_Quota", null);
                    e.Cancel = true;
                }
                if ("" + e.NewValue != "" && Convert.ToInt32(e.NewValue) > songay)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                 GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị số ngày quota vượt quá khả năng lưu trữ.");
                gridView1.SetFocusedRowCellValue(gridView1.Columns["Songay_Quota"], null);
            }
        }
        #endregion

    }
}

