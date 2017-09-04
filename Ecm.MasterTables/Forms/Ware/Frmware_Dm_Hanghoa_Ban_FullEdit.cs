using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Hanghoa_Ban_FullEdit : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public enum EditActivities
        {
            Loai,
            Hanghoa,
            None
        }
        Ecm.WebReferences.Classes.MasterService objMasterService = new WebReferences.Classes.MasterService();
        DataSet dsDm_Hanghoa_Ban_All;
        DataSet dsDm_Hanghoa_Ban;
        DataSet dsDm_Loai_Hanghoa_Ban;
        DataSet dsDm_Donvitinh;

        //bool addNewRow = false;

        private Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban _Selected_Ware_Dm_Hanghoa_Ban = new WebReferences.MasterService.Ware_Dm_Hanghoa_Ban();
        public Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban Selected_Ware_Dm_Hanghoa_Ban
        {
            get { return _Selected_Ware_Dm_Hanghoa_Ban; }
            set { _Selected_Ware_Dm_Hanghoa_Ban = value; }
        }

        public DataSet DsDm_Hanghoa_Ban
        {
            get { return dsDm_Hanghoa_Ban.Copy(); }
        }

        object Current_Id_Loai_Hanghoa_Ban;
        private EditActivities action;
        private bool _IsDialog = false;
        public bool IsDialog
        {
            get { return _IsDialog; }
            set { _IsDialog = value; }
        }

        public Frmware_Dm_Hanghoa_Ban_FullEdit()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");

            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            DisplayInfo();
            this.AfterCheckUserRightAction += new EventHandler(Frmware_Dm_Hanghoa_Ban_FullEdit_AfterCheckUserRightAction);
        }

        void Frmware_Dm_Hanghoa_Ban_FullEdit_AfterCheckUserRightAction(object sender, EventArgs e)
        {
            this.btnEdit_Loai.Enabled = this.EnableEdit;
        }

        void LoadMasterData()
        {
            try
            {
                dsDm_Loai_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet();
                dsDm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                dsDm_Hanghoa_Ban_All = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        void ChangeStatus(EditActivities act, bool editable)
        {
            switch (act)
            {
                case EditActivities.Loai:
                    gvware_Dm_Loai_Hanghoa_Ban.OptionsBehavior.Editable = editable;
                    //change main view
                    btnEdit_Loai.Enabled = !editable;
                    dpHanghoa_Ban.Enabled = !editable;
                    dpSearch_Hanghoa_Ban.Enabled = !editable;
                    break;
            }
        }

        #region override

        public override void DisplayInfo()
        {
            action = EditActivities.None;
            //addNewRow = false;
            LoadMasterData();
            gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = dsDm_Loai_Hanghoa_Ban.Tables[0];
            lookUp_Donvitinh.Properties.DataSource = dsDm_Donvitinh.Tables[0];
            gridLookUp_Donvitinh.DataSource = dsDm_Donvitinh.Tables[0];

            //Loai_Hanghoa_Ban
            dgware_Dm_Loai_Hanghoa_Ban.DataSource = dsDm_Loai_Hanghoa_Ban.Tables[0];
            gvware_Dm_Loai_Hanghoa_Ban.BestFitColumns();
            gvware_Dm_Loai_Hanghoa_Ban.OptionsBehavior.Editable = false;
            btnEdit_Loai.Enabled = this.EnableEdit;
            ChangeStatus(false);
            base.DisplayInfo();
        }

        public override void ClearDataBindings()
        {
            this.txtMa_Hanghoa_Ban.DataBindings.Clear();
            this.txtTen_Hanghoa_Ban.DataBindings.Clear();
            this.txtBarcode_Txt.DataBindings.Clear();
            this.lookUp_Donvitinh.DataBindings.Clear();
            base.ClearDataBindings();
        }

        public override void DataBindingControl()
        {
            this.ClearDataBindings();
            //add
            this.txtMa_Hanghoa_Ban.DataBindings.Add("EditValue", dsDm_Hanghoa_Ban, dsDm_Hanghoa_Ban.Tables[0].TableName + ".Ma_Hanghoa_Ban");
            this.txtTen_Hanghoa_Ban.DataBindings.Add("EditValue", dsDm_Hanghoa_Ban, dsDm_Hanghoa_Ban.Tables[0].TableName + ".Ten_Hanghoa_Ban");
            this.txtBarcode_Txt.DataBindings.Add("EditValue", dsDm_Hanghoa_Ban, dsDm_Hanghoa_Ban.Tables[0].TableName + ".Barcode_Txt");
            this.lookUp_Donvitinh.DataBindings.Add("EditValue", dsDm_Hanghoa_Ban, dsDm_Hanghoa_Ban.Tables[0].TableName + ".Id_Donvitinh");
            base.DataBindingControl();
        }

        public override void ChangeStatus(bool editTable)
        {
            this.dpLoai_Hanghoa_Ban.Enabled = !editTable;
            this.dpSearch_Hanghoa_Ban.Enabled = !editTable;
            gvware_Dm_Hanghoa_Ban.OptionsBehavior.Editable = editTable;
            this.txtMa_Hanghoa_Ban.Properties.ReadOnly = !editTable;
            this.txtTen_Hanghoa_Ban.Properties.ReadOnly = !editTable;
            this.txtBarcode_Txt.Properties.ReadOnly = !editTable;
            this.lookUp_Donvitinh.Properties.ReadOnly = !editTable;
            base.ChangeStatus(editTable);
        }

        public override void ResetText()
        {
            txtMa_Hanghoa_Ban.EditValue = null;
            txtTen_Hanghoa_Ban.EditValue = null;
            txtBarcode_Txt.EditValue = null;
            lookUp_Donvitinh.EditValue = null;
            base.ResetText();
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            return base.PerformAdd();
        }

        public override bool PerformEdit()
        {
            switch (action)
            {
                case EditActivities.None:
                    action = EditActivities.Hanghoa;
                    this.ChangeStatus(true);
                    break;
                case EditActivities.Loai:
                    ChangeStatus(EditActivities.Loai, true);
                    break;
            }
            return base.PerformEdit();
        }

        public override bool PerformCancel()
        {
            switch (action)
            {
                case EditActivities.Hanghoa:
                    ChangeStatus(false);
                    break;
                case EditActivities.Loai:
                    dsDm_Loai_Hanghoa_Ban.RejectChanges();
                    ChangeStatus(EditActivities.Loai, false);
                    break;
            }
            DisplayInfo();
            return base.PerformCancel();
        }

        public override bool PerformSaveChanges()
        {
            bool success = true;
            switch (action)
            {
                case EditActivities.Hanghoa:
                    success = SaveChangeHanghoaBan();
                    break;
                case EditActivities.Loai:
                    success = SaveChangeLoaiHanghoaBan();
                    break;
            }
            if (success) action = EditActivities.None;
            return success;
        }

        public override bool PerformSave()
        {
            return PerformSaveChanges();
        }

        public override object PerformSelectOneObject()
        {
            this.Dispose();
            this.Close();
            return base.PerformSelectOneObject();
        }
        #endregion

        private bool SaveChangeHanghoaBan()
        {
            DataSet ds_All_Hanghoa_Ban = new DataSet();
            ds_All_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            this.DoClickEndEdit(dgware_Dm_Hanghoa_Ban);
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gvware_Dm_Hanghoa_Ban.Columns["Ma_Hanghoa_Ban"], "");
            hashtableControls.Add(gvware_Dm_Hanghoa_Ban.Columns["Ten_Hanghoa_Ban"], "");
            hashtableControls.Add(gvware_Dm_Hanghoa_Ban.Columns["Id_Donvitinh"], "");
            //hashtableControls.Add(gvware_Dm_Hanghoa_Ban.Columns["Barcode_Txt"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvware_Dm_Hanghoa_Ban))
                return false;

            int focus = gvware_Dm_Hanghoa_Ban.FocusedRowHandle;
            if (FormState == GoobizFrame.Windows.Forms.FormState.Add)
            {
                System.Collections.Hashtable htbBarCode = new System.Collections.Hashtable();
                htbBarCode.Add(gvware_Dm_Hanghoa_Ban.Columns["Barcode_Txt"], "");
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(htbBarCode, gvware_Dm_Hanghoa_Ban))
                    return false;
            }
            hashtableControls.Remove(gvware_Dm_Hanghoa_Ban.Columns["Id_Donvitinh"]);
            hashtableControls.Remove(gvware_Dm_Hanghoa_Ban.Columns["Ten_Hanghoa_Ban"]);

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gvware_Dm_Hanghoa_Ban))
            {
                gvware_Dm_Hanghoa_Ban.FocusedRowHandle = focus;
                return false;
            }
            DataRow[] dtr = null;
            DataRow[] dtr_Id = null;
            for (int i = 0; i < gvware_Dm_Hanghoa_Ban.RowCount; i++)
            {
                if (gvware_Dm_Hanghoa_Ban.GetDataRow(i).RowState == DataRowState.Modified)
                {
                    dtr_Id = ds_All_Hanghoa_Ban.Tables[0].Select("Id_Hanghoa_Ban = '" + gvware_Dm_Hanghoa_Ban.GetRowCellValue(i, gvware_Dm_Hanghoa_Ban.Columns["Id_Hanghoa_Ban"]) + "'");
                    if (!dtr_Id[0]["Ma_Hanghoa_Ban"].Equals(gvware_Dm_Hanghoa_Ban.GetRowCellValue(i, gvware_Dm_Hanghoa_Ban.Columns["Ma_Hanghoa_Ban"])))
                    {
                        dtr = ds_All_Hanghoa_Ban.Tables[0].Select("Ma_Hanghoa_Ban = '" + gvware_Dm_Hanghoa_Ban.GetRowCellValue(i, gvware_Dm_Hanghoa_Ban.Columns["Ma_Hanghoa_Ban"]) + "'");
                        if (dtr.Length >= 1)
                        {
                            GoobizFrame.Windows.Forms.MessageDialog.Show("Mã hàng " + gvware_Dm_Hanghoa_Ban.GetRowCellValue(i, gvware_Dm_Hanghoa_Ban.Columns["Ma_Hanghoa_Ban"]) + " đã tồn tại, nhập lại Mã hàng hóa");
                            return false;
                        }
                    }
                }
                if (gvware_Dm_Hanghoa_Ban.GetDataRow(i).RowState == DataRowState.Added)
                {
                    dtr = ds_All_Hanghoa_Ban.Tables[0].Select("Ma_Hanghoa_Ban = '" + gvware_Dm_Hanghoa_Ban.GetRowCellValue(i, gvware_Dm_Hanghoa_Ban.Columns["Ma_Hanghoa_Ban"]) + "'");
                    if (dtr.Length >= 1)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Mã hàng " + gvware_Dm_Hanghoa_Ban.GetRowCellValue(i, gvware_Dm_Hanghoa_Ban.Columns["Ma_Hanghoa_Ban"]) + " đã tồn tại, nhập lại Mã hàng hóa");
                        return false;
                    }
                }
            }
            try
            {
                //dgware_Dm_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                //dsWare_Hanghoa_Ban_Dinhgia.Tables[0].Columns["Ma_Hanghoa_Ban"].Unique = true;
                //dsWare_Hanghoa_Ban_Dinhgia.Tables[0].Columns["Ten_Hanghoa_Ban"].Unique = true;
                objMasterService.Update_Ware_Dm_Hanghoa_Ban_Collection(this.dsDm_Hanghoa_Ban);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    if (ex.ToString().IndexOf("Ma_Hanghoa_Ban") != -1)
                        GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblMa_Hanghoa_Ban.Text, lblMa_Hanghoa_Ban.Text.ToLower() });
                    //else if (ex.ToString().IndexOf("Ten_Hanghoa_Ban") != -1)
                    //     GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblTen_Hanghoa_Ban.Text, lblTen_Hanghoa_Ban.Text.ToLower() });
                    return false;
                }
                //MessageBox.Show(ex.ToString());
            }
            DisplayInfo();
            ChangeStatus(false);
            return true;
        }

        private DataSet GetDataSet_Dm_Hanghoa_Ban(object Id_Loai_Hanghoa_Ban, object Ma_Hanghoa_Ban, object Ten_Hanghoa_Ban, object Barcode_Txt)
        {
            var strDm_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Loai_Hh_Ban_None_Dinhgia(
                Id_Loai_Hanghoa_Ban, Ma_Hanghoa_Ban, Ten_Hanghoa_Ban, Barcode_Txt);
            return strDm_Hanghoa_Ban.ToDataSet();
        }

        private void DisplayDmHanghoaBanInfo()
        {
            //LoadMasterData();
            gridLookUp_Donvitinh.DataSource = dsDm_Donvitinh.Tables[0];
            dsDm_Hanghoa_Ban = this.GetDataSet_Dm_Hanghoa_Ban(Current_Id_Loai_Hanghoa_Ban, null, null, null);
            dgware_Dm_Hanghoa_Ban.DataSource = dsDm_Hanghoa_Ban;
            dgware_Dm_Hanghoa_Ban.DataMember = dsDm_Hanghoa_Ban.Tables[0].TableName;
            DataBindingControl();
            this.Data = dsDm_Hanghoa_Ban;
            this.GridControl = dgware_Dm_Hanghoa_Ban;
            gvware_Dm_Hanghoa_Ban.BestFitColumns();
            cvware_Dm_Hanghoa_Ban.OptionsBehavior.ReadOnly = true;
            //ChangeStatus(false);
        }

        private void gvware_Dm_Loai_Hanghoa_Ban_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvware_Dm_Loai_Hanghoa_Ban.IsDataRow(gvware_Dm_Loai_Hanghoa_Ban.FocusedRowHandle))
            {
                Current_Id_Loai_Hanghoa_Ban = gvware_Dm_Loai_Hanghoa_Ban.GetFocusedRowCellValue("Id_Loai_Hanghoa_Ban");
                DisplayDmHanghoaBanInfo();
            }
        }

        private void lookUp_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
            {
                try
                {
                    var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                        "Ecm.MasterTables.dll",
                        "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add", this);

                    if (dialog == null)
                        return;
                    var SelectedObject = dialog.GetType().GetProperty("SelecteWware_Dm_Donvitinh").GetValue(dialog, null)
                        as Ecm.WebReferences.MasterService.Ware_Dm_Donvitinh;
                    var dsWare_Dm_Donvitinh = dialog.GetType().GetProperty("DsWare_Dm_Donvitinh").GetValue(dialog, null) as DataSet;

                    if (SelectedObject != null)
                        this.lookUp_Donvitinh.Properties.DataSource = objMasterService.Get_All_Ware_Dm_Donvitinh();
                    if (dsWare_Dm_Donvitinh != null)
                        this.dsDm_Donvitinh = dsWare_Dm_Donvitinh;
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }
            }
        }

        private void gvware_Dm_Hanghoa_Ban_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvware_Dm_Hanghoa_Ban.SetFocusedRowCellValue("Id_Loai_Hanghoa_Ban", Current_Id_Loai_Hanghoa_Ban);
            gvware_Dm_Hanghoa_Ban.SetFocusedRowCellValue("Id_Hanghoa_Ban", long.MaxValue - gvware_Dm_Hanghoa_Ban.FocusedRowHandle);
        }

        private void gvware_Dm_Hanghoa_Ban_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "Ma_Hanghoa_Ban")
                    gvware_Dm_Hanghoa_Ban.SetFocusedRowCellValue("Barcode_Txt", gvware_Dm_Hanghoa_Ban.GetFocusedRowCellValue("Ma_Hanghoa_Ban"));
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        #region Edit Loai

        private void btnLoai_Edit_Click(object sender, EventArgs e)
        {
            action = EditActivities.Loai;
            item_Edit.PerformClick();
        }

        private bool SaveChangeLoaiHanghoaBan()
        {
            dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Loai_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
            var valid = true;

            //validate
            foreach (DataRow dr in dsDm_Loai_Hanghoa_Ban.Tables[0].Rows)
            {
                if (dr.RowState == DataRowState.Deleted) continue;

                if ("" + dr["Ma_Loai_Hanghoa_Ban"] == "")
                {
                    valid = false;
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Mã loại không thể rỗng!");
                    return false;
                }

                if ("" + dr["Ten_Loai_Hanghoa_Ban"] == "")
                {
                    valid = false;
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Tên loại không thể rỗng!");
                    return false;
                }
            }

            if (valid)
            {
                objMasterService.Update_Ware_Dm_Loai_Hanghoa_Ban_Collection(dsDm_Loai_Hanghoa_Ban);
                dsDm_Loai_Hanghoa_Ban.AcceptChanges();
                ChangeStatus(EditActivities.Loai, false);
                DisplayInfo();
            }
            return valid;
        }

        private void gvware_Dm_Loai_Hanghoa_Ban_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvware_Dm_Loai_Hanghoa_Ban.SetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban", 3);
            gvware_Dm_Loai_Hanghoa_Ban.SetFocusedRowCellValue("Id_Loai_Hanghoa_Ban", long.MaxValue - gvware_Dm_Loai_Hanghoa_Ban.FocusedRowHandle);
        }

        private void cvware_Dm_Loai_Hanghoa_Ban_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvware_Dm_Loai_Hanghoa_Ban.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvware_Dm_Loai_Hanghoa_Ban.FocusedRowHandle = cardHit.RowHandle;
                Current_Id_Loai_Hanghoa_Ban = cvware_Dm_Loai_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Id_Loai_Hanghoa_Ban");
                GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvware_Dm_Loai_Hanghoa_Ban, "Id_Loai_Hanghoa_Ban", this.Current_Id_Loai_Hanghoa_Ban);

                DisplayDmHanghoaBanInfo();
            }
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //search dm hang hoa
            dsDm_Hanghoa_Ban = this.GetDataSet_Dm_Hanghoa_Ban(null,
                ("" + txtSearch_Ma_Hanghoa.EditValue != "") ? txtSearch_Ma_Hanghoa.EditValue : null,
                ("" + txtSearch_Ten_Hanghoa.EditValue != "") ? txtSearch_Ten_Hanghoa.EditValue : null,
                ("" + txtSearch_Barcode_Txt.EditValue != "") ? txtSearch_Barcode_Txt.EditValue : null);

            dgware_Dm_Hanghoa_Ban.DataSource = dsDm_Hanghoa_Ban;
            dgware_Dm_Hanghoa_Ban.DataMember = dsDm_Hanghoa_Ban.Tables[0].TableName;

            DataBindingControl();

            //search dinh gia
            var ware_Dm_Hanghoa_Ban = new WebReferences.MasterService.Ware_Dm_Hanghoa_Ban()
            {
                Ma_Hanghoa_Ban = ("" + txtSearch_Ma_Hanghoa.EditValue != "") ? txtSearch_Ma_Hanghoa.EditValue : null,
                Ten_Hanghoa_Ban = ("" + txtSearch_Ten_Hanghoa.EditValue != "") ? txtSearch_Ten_Hanghoa.EditValue : null,
                Barcode_Txt = ("" + txtSearch_Barcode_Txt.EditValue != "") ? txtSearch_Barcode_Txt.EditValue : null
            };
        }

        private void cvware_Dm_Hanghoa_Ban_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_IsDialog) return;

            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvware_Dm_Hanghoa_Ban.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvware_Dm_Hanghoa_Ban.FocusedRowHandle = cardHit.RowHandle;
                //Current_Id_Loai_Hanghoa_Ban = cvware_Dm_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Id_Hanghoa_Ban");
                _Selected_Ware_Dm_Hanghoa_Ban = new WebReferences.MasterService.Ware_Dm_Hanghoa_Ban()
                {
                    Id_Hanghoa_Ban = cvware_Dm_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Id_Hanghoa_Ban"),
                    Id_Loai_Hanghoa_Ban = cvware_Dm_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Id_Loai_Hanghoa_Ban"),
                    Ma_Hanghoa_Ban = cvware_Dm_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Ma_Hanghoa_Ban"),
                    Ten_Hanghoa_Ban = cvware_Dm_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Ten_Hanghoa_Ban"),
                    Barcode_Txt = cvware_Dm_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Barcode_Txt"),
                    Size = cvware_Dm_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Size"),
                    Quycach = cvware_Dm_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Quycach"),
                    Hamluong = cvware_Dm_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Hamluong"),
                };

                GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvware_Dm_Hanghoa_Ban, "Id_Hanghoa_Ban",
                     cvware_Dm_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Id_Hanghoa_Ban"));

                //this.Dispose();
                this.Close();
            }
        }

        private void Frmware_Dm_Hanghoa_Ban_FullEdit_Shown(object sender, EventArgs e)
        {
            if (this.MdiParent == null)
                _IsDialog = true;
        }

        private void gridLookUp_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                try
                {
                    var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                        "Ecm.MasterTables.dll",
                        "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add", this);

                    if (dialog == null)
                        return;
                    var SelectedObject = dialog.GetType().GetProperty("SelecteWare_Dm_Donvitinh").GetValue(dialog, null)
                        as Ecm.WebReferences.MasterService.Ware_Dm_Donvitinh;

                    if (SelectedObject != null)
                        gvware_Dm_Hanghoa_Ban.SetFocusedRowCellValue("Id_Donvitinh", Convert.ToInt64(SelectedObject.Id_Donvitinh));

                    LoadMasterData();
                    gridLookUp_Donvitinh.DataSource = dsDm_Donvitinh.Tables[0];
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }
            }
        }

    }
}