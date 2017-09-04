using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.MasterTables.Forms.Bar
{
    public partial class Frmbar_Dm_Table_FullEdit : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();

        DataSet dsBar_Dm_Table;
        DataSet dsBar_Dm_Khuvuc;
        DataSet dsWare_Dm_Cuahang_Ban;
        DataSet dsBar_Dm_Table_Facility;
        object Current_Id_Cuahang_Ban;
        object Current_Id_Khuvuc;
        object Current_Id_Table;

        public DataSet DsBar_Dm_Table
        {
            get { return dsBar_Dm_Table; }
        }

        public enum EditActivities
        {
            Cuahang,
            Khuvuc,
            Table,
            None
        }

        private EditActivities action = EditActivities.None;

        public Frmbar_Dm_Table_FullEdit()
        {
            InitializeComponent();
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.AfterCheckUserRightAction += new EventHandler(Frmbar_Dm_Table_FullEdit_AfterCheckUserRightAction);
            this.dgWare_Dm_Cuahang_Ban.MainView = cvWare_Dm_Cuahang_Ban;
            this.dgbar_dm_khuvuc.MainView = cvbar_dm_khuvuc;
            this.dgbar_Dm_Table.MainView = cvbar_Dm_Table;
            DisplayInfo();
        }

        void Frmbar_Dm_Table_FullEdit_AfterCheckUserRightAction(object sender, EventArgs e)
        {
            this.btnEdit_Dm_Cuahang_Ban.Enabled = this.EnableEdit;
            this.btnEdit_Dm_Khuvuc.Enabled = this.EnableEdit;
        }

        void DisplayInfo_Cuahang()
        {
            try
            {
                dsWare_Dm_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban().ToDataSet();
                dgWare_Dm_Cuahang_Ban.DataSource = dsWare_Dm_Cuahang_Ban.Tables[0];
                if (cvWare_Dm_Cuahang_Ban.RowCount > 0)
                {
                    cvWare_Dm_Cuahang_Ban.FocusedRowHandle = 0;
                    Current_Id_Cuahang_Ban = cvWare_Dm_Cuahang_Ban.GetFocusedRowCellValue("Id_Cuahang_Ban");
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        void DisplayInfo_Khuvuc()
        {
            try
            {

                if (dgbar_dm_khuvuc.MainView == cvbar_dm_khuvuc)
                {
                    cvbar_dm_khuvuc.Columns["Id_Cuahang_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                       cvbar_dm_khuvuc.Columns["Id_Cuahang_Ban"], Current_Id_Cuahang_Ban);
                    cvbar_dm_khuvuc.ApplyColumnsFilter();

                    if (cvbar_dm_khuvuc.RowCount > 0)
                    {
                        cvbar_dm_khuvuc.FocusedRowHandle = 0;
                        Current_Id_Khuvuc = cvbar_dm_khuvuc.GetFocusedRowCellValue("Id_Khuvuc");
                    }
                    else
                        Current_Id_Khuvuc = null;
                }
                else
                {
                    gvbar_dm_khuvuc.Columns["Id_Cuahang_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        gvbar_dm_khuvuc.Columns["Id_Cuahang_Ban"], Current_Id_Cuahang_Ban);
                    gvbar_dm_khuvuc.ApplyColumnsFilter();

                    if (gvbar_dm_khuvuc.RowCount > 0)
                    {
                        gvbar_dm_khuvuc.FocusedRowHandle = 0;
                        Current_Id_Khuvuc = gvbar_dm_khuvuc.GetFocusedRowCellValue("Id_Khuvuc");
                    }
                    else
                        Current_Id_Khuvuc = null;
                }
                DisplayInfo_Table();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        public void DisplayInfo_Table()
        {
            try
            {
                dsBar_Dm_Table = objMasterService.Get_All_Bar_Dm_Table_ByKhuvuc(
                    new WebReferences.MasterService.Bar_Dm_Table() { Id_Khuvuc = (Current_Id_Khuvuc != null) ? Current_Id_Khuvuc : -1, }).ToDataSet();

                dgbar_Dm_Table.DataSource = dsBar_Dm_Table;
                dgbar_Dm_Table.DataMember = dsBar_Dm_Table.Tables[0].TableName;

                this.Data = dsBar_Dm_Table;
                this.GridControl = dgbar_Dm_Table;

                DataBindingControl();
                if (dsBar_Dm_Table.Tables[0].Rows.Count > 0)
                {
                    cvbar_Dm_Table.FocusedRowHandle = 0;
                    cvbar_Dm_Table.Focus();
                    Current_Id_Table = cvbar_Dm_Table.GetFocusedRowCellValue("Id_Table");
                    DisplayInfo_Table_Facility();
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        #region  event override

        public override void DisplayInfo()
        {
            dsBar_Dm_Khuvuc = objMasterService.Get_All_Bar_Dm_Khuvuc().ToDataSet();
            dgbar_dm_khuvuc.DataSource = dsBar_Dm_Khuvuc.Tables[0];
            lookUp_Khuvuc.Properties.DataSource = dsBar_Dm_Khuvuc.Tables[0];
            var dsBar_Dm_Facility = objMasterService.Get_All_Bar_Dm_Facility().ToDataSet();
            lookUpEdit_Facility.DataSource = dsBar_Dm_Facility.Tables[0];
            DisplayInfo_Cuahang();
            DisplayInfo_Khuvuc();
            this.action = EditActivities.None;
            ChangeStatus(false);
            ChangeStatus_Cuahang(false);
            ChangeStatus_Khuvuc(false);
            base.DisplayInfo();
        }

        public override void ClearDataBindings()
        {
            this.txtMa_Table.DataBindings.Clear();
            this.txtTen_Table.DataBindings.Clear();
            this.txtVitri.DataBindings.Clear();
            this.txtSoluong.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.lookUp_Khuvuc.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtMa_Table.DataBindings.Add("EditValue", dsBar_Dm_Table, dsBar_Dm_Table.Tables[0].TableName + ".Ma_Table");
                this.txtTen_Table.DataBindings.Add("EditValue", dsBar_Dm_Table, dsBar_Dm_Table.Tables[0].TableName + ".Ten_Table");
                this.txtVitri.DataBindings.Add("EditValue", dsBar_Dm_Table, dsBar_Dm_Table.Tables[0].TableName + ".Vitri");
                this.txtSoluong.DataBindings.Add("EditValue", dsBar_Dm_Table, dsBar_Dm_Table.Tables[0].TableName + ".Soluong");
                this.txtGhichu.DataBindings.Add("EditValue", dsBar_Dm_Table, dsBar_Dm_Table.Tables[0].TableName + ".Ghichu");
                this.lookUp_Khuvuc.DataBindings.Add("EditValue", dsBar_Dm_Table, dsBar_Dm_Table.Tables[0].TableName + ".Id_Khuvuc");
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
            base.DataBindingControl();
        }

        public override bool PerformEdit()
        {
            txtMa_Table_Prefix.EditValue = null;
            spinEdit_Start.EditValue = null;
            spinEdit_End.EditValue = null;
            switch (action)
            {
                case EditActivities.None:
                    if (Current_Id_Khuvuc == null) return false;
                    ChangeStatus(true);
                    this.action = EditActivities.Table;
                    break;
                case EditActivities.Cuahang:
                    ChangeStatus_Cuahang(true);
                    break;
                case EditActivities.Khuvuc:
                    ChangeStatus_Khuvuc(true);
                    break;
            }
            return base.PerformEdit();
        }

        public override bool PerformSave()
        {
            return PerformSaveChanges();
        }

        public override bool PerformSaveChanges()
        {
            bool save = false;
            switch (action)
            {
                case EditActivities.Cuahang:
                    save = PerformSaveChanges_Cuahang();
                    break;
                case EditActivities.Khuvuc:
                    save = PerformSaveChanges_Khuvuc();
                    break;
                case EditActivities.Table:
                    save =  PerformSaveChanges_Table();
                    break;
            }
            if (save)
            {
                objMasterService.Update_Bar_Dm_Table_Collection(dsBar_Dm_Table);
                dsBar_Dm_Table.AcceptChanges();
                ChangeStatus(false);
                DisplayInfo();
            }
            else
                return false;
            return base.PerformSaveChanges();
        }

        public override bool PerformCancel()
        {
            DisplayInfo();
            ChangeStatus(false);
            ChangeStatus_Cuahang(false);
            ChangeStatus_Khuvuc(false);
            return base.PerformCancel();
        }

        public override void ChangeStatus(bool editTable)
        {
            this.txtMa_Table.Properties.ReadOnly = !editTable;
            this.txtTen_Table.Properties.ReadOnly = !editTable;
            this.txtVitri.Properties.ReadOnly = !editTable;
            this.txtSoluong.Properties.ReadOnly = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.lookUp_Khuvuc.Properties.ReadOnly = !editTable;

            this.txtMa_Table_Prefix.Properties.ReadOnly = !editTable;
            this.spinEdit_Start.Properties.ReadOnly = !editTable;
            this.spinEdit_End.Properties.ReadOnly = !editTable;
            this.btnAddRanges.Enabled = editTable;

            dpCuahang.Enabled = !editTable;
            dpKhuvuc.Enabled = !editTable;
            gvbar_Dm_Table.OptionsBehavior.Editable = editTable;
            gvDm_Table_Facility.OptionsBehavior.Editable = editTable;
            if (editTable)
            {
                dgbar_Dm_Table.MainView = gvbar_Dm_Table;
            }
            else
            {
                dgbar_Dm_Table.MainView = cvbar_Dm_Table;
            }
        }

        #endregion

        public void ChangeStatus_Cuahang(bool editTable)
        {
            dpKhuvuc.Enabled = !editTable;
            dpTable.Enabled = !editTable;
            btnEdit_Dm_Cuahang_Ban.Enabled = !editTable;
            gvWare_Dm_Cuahang_Ban.OptionsBehavior.Editable = editTable;

            if (editTable)
            {
                dgWare_Dm_Cuahang_Ban.MainView = gvWare_Dm_Cuahang_Ban;
            }
            else
            {
                dgWare_Dm_Cuahang_Ban.MainView = cvWare_Dm_Cuahang_Ban;
            }
        }

        public void ChangeStatus_Khuvuc(bool editTable)
        {
            dpCuahang.Enabled = !editTable;
            dpTable.Enabled = !editTable;
            btnEdit_Dm_Khuvuc.Enabled = !editTable;
            gvbar_dm_khuvuc.OptionsBehavior.Editable = editTable;

            if (editTable)
            {
                dgbar_dm_khuvuc.MainView = gvbar_dm_khuvuc;
            }
            else
            {
                dgbar_dm_khuvuc.MainView = cvbar_dm_khuvuc;
            }
        }

        public bool PerformSaveChanges_Cuahang()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gvWare_Dm_Cuahang_Ban.Columns["Ma_Cuahang_Ban"], "");
            hashtableControls.Add(gvWare_Dm_Cuahang_Ban.Columns["Ten_Cuahang_Ban"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvWare_Dm_Cuahang_Ban))
                return false;

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gvWare_Dm_Cuahang_Ban))
                return false;

            try
            {
                dgWare_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.DoClick(dgWare_Dm_Cuahang_Ban.EmbeddedNavigator.Buttons.EndEdit);
                this.dsWare_Dm_Cuahang_Ban.Tables[0].Columns["Ma_Cuahang_Ban"].Unique = true;
                objMasterService.Update_Ware_Dm_Cuahang_Ban_Collection(this.dsWare_Dm_Cuahang_Ban);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { gvWare_Dm_Cuahang_Ban.Columns["Ma_Cuahang_Ban"].Caption });
                    return false;
                }
            }
            //this.DisplayInfo();
            //this.ChangeStatus_Cuahang(false);
            return true;
        }

        private bool PerformSaveChanges_Khuvuc()
        {
            dgbar_dm_khuvuc.EmbeddedNavigator.Buttons.DoClick(dgbar_dm_khuvuc.EmbeddedNavigator.Buttons.EndEdit);
            var valid = true;

            //validate
            foreach (DataRow dr in dsBar_Dm_Khuvuc.Tables[0].Rows)
            {
                if (dr.RowState == DataRowState.Deleted) continue;
                if ("" + dr["Ma_Khuvuc"] == "")
                {
                    valid = false;
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Mã khu vực không thể rỗng!");
                    return false;
                }

                if ("" + dr["Ten_Khuvuc"] == "")
                {
                    valid = false;
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Tên khu vực không thể rỗng!");
                    return false;
                }

                var sdr = dsBar_Dm_Khuvuc.Tables[0].Select(string.Format("Ma_Khuvuc = '{0}' and Id_Khuvuc <> {1} and Id_Cuahang_Ban = {2}",
                    new object[] { dr["Ma_Khuvuc"], dr["Id_Khuvuc"], dr["Id_Cuahang_Ban"] }));
                if (sdr.Length > 0)
                {
                    valid = false;
                    GoobizFrame.Windows.Forms.MessageDialog.Show(
                        string.Format("Cửa hàng \"{0}\", Mã KV \"{1}\" đã tồn tại trong cửa hàng \"{2}\"!",
                        new object[]{
                            dsWare_Dm_Cuahang_Ban.Tables[0].Select(string.Format("Id_Cuahang_Ban={0}", dr["Id_Cuahang_Ban"]))[0]["Ten_Cuahang_Ban"],
                            dr["Ma_Khuvuc"],
                            dsWare_Dm_Cuahang_Ban.Tables[0].Select(string.Format("Id_Cuahang_Ban={0}", sdr[0]["Id_Cuahang_Ban"]))[0]["Ten_Cuahang_Ban"],
                        }
                        ));
                    return false;
                }
            }

            if (valid)
            {
                objMasterService.Update_Bar_Dm_Khuvuc_Collection(dsBar_Dm_Khuvuc);
                dsBar_Dm_Khuvuc.AcceptChanges();
                ChangeStatus_Khuvuc(false);
                DisplayInfo();
            }
            return valid;
        }

        private bool PerformSaveChanges_Table()
        {
            try
            {
                //save ds tien nghi
                if (dsBar_Dm_Table_Facility.HasChanges())
                {
                    GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                    hashtableControls.Add(gvDm_Table_Facility.Columns["Id_Facility"], "");
                    
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gvDm_Table_Facility))
                        return false;
                    hashtableControls.Add(gvDm_Table_Facility.Columns["Soluong"], "");
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvDm_Table_Facility))
                        return false;

                    if (dsBar_Dm_Table_Facility != null && dsBar_Dm_Table_Facility.HasChanges())
                        objMasterService.Update_Bar_Dm_Table_Facility_Collection(dsBar_Dm_Table_Facility);

                }
                dgbar_Dm_Table.EmbeddedNavigator.Buttons.DoClick(dgbar_Dm_Table.EmbeddedNavigator.Buttons.EndEdit);
                var valid = true;

                //validate
                foreach (DataRow dr in dsBar_Dm_Table.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Deleted) continue;

                    if ("" + dr["Ma_Table"] == "")
                    {
                        valid = false;
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Mã table không thể rỗng!");
                        return false;
                    }

                    if ("" + dr["Ten_Table"] == "")
                    {
                        valid = false;
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Tên Table không thể rỗng!");
                        return false;
                    }
                    DataRow[] sdr;
                    if ("" + dr["Id_Table"] != "")
                        sdr = dsBar_Dm_Table.Tables[0].Select(string.Format("Ma_Table = '{0}' and Id_Table <> {1} and Id_Khuvuc = {2}",
                            new object[] { dr["Ma_Table"], ("" + dr["Id_Table"] == "") ? null : dr["Id_Table"], dr["Id_Khuvuc"] }));
                    else
                        sdr = dsBar_Dm_Table.Tables[0].Select(string.Format("Ma_Table = '{0}' and Id_Table = null and Id_Khuvuc = {1}",
                        new object[] { dr["Ma_Table"], dr["Id_Khuvuc"] }));
                    if (sdr.Length > 0)
                    {
                        valid = false;
                        GoobizFrame.Windows.Forms.MessageDialog.Show(
                            string.Format("KV \"{0}\", Mã Table \"{1}\" đã tồn tại trong KV \"{2}\"!",
                            new object[]{
                            dsBar_Dm_Khuvuc.Tables[0].Select(string.Format("Id_Khuvuc={0}", dr["Id_Khuvuc"]))[0]["Ten_Khuvuc"],
                            dr["Ma_Table"],
                            dsBar_Dm_Khuvuc.Tables[0].Select(string.Format("Id_Khuvuc={0}", sdr[0]["Id_Khuvuc"]))[0]["Ten_Khuvuc"],
                        }
                            ));
                        return false;
                    }
                }
                return valid;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.ToString());
                return false;
            }
        }

        private void btnEdit_Dm_Cuahang_Ban_Click(object sender, EventArgs e)
        {
            this.action = EditActivities.Cuahang;
            this.item_Edit.PerformClick();
        }

        private void btnEdit_Dm_Khuvuc_Click(object sender, EventArgs e)
        {
            if (Current_Id_Cuahang_Ban == null) return;
            this.action = EditActivities.Khuvuc;
            this.item_Edit.PerformClick();
        }

        private void cvWare_Dm_Cuahang_Ban_MouseDown(object sender, MouseEventArgs e)
        {
            SaveChanges_Bar_Dm_Table_Facility();
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvWare_Dm_Cuahang_Ban.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvWare_Dm_Cuahang_Ban.FocusedRowHandle = cardHit.RowHandle;
                this.Current_Id_Cuahang_Ban = cvWare_Dm_Cuahang_Ban.GetRowCellValue(cardHit.RowHandle, "Id_Cuahang_Ban");
                DisplayInfo_Khuvuc();
            }
        }

        private void cvbar_dm_khuvuc_MouseDown(object sender, MouseEventArgs e)
        {
            SaveChanges_Bar_Dm_Table_Facility();
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvbar_dm_khuvuc.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvbar_dm_khuvuc.FocusedRowHandle = cardHit.RowHandle;
                this.Current_Id_Khuvuc = cvbar_dm_khuvuc.GetRowCellValue(cardHit.RowHandle, "Id_Khuvuc");
                DisplayInfo_Table();
                GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvbar_dm_khuvuc, "Id_Khuvuc", Current_Id_Khuvuc);
            }
        }

        private void gvbar_dm_khuvuc_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (Current_Id_Cuahang_Ban != null)
            {
                gvbar_dm_khuvuc.SetFocusedRowCellValue("Id_Cuahang_Ban", Current_Id_Cuahang_Ban);
                gvbar_dm_khuvuc.SetFocusedRowCellValue("Id_Khuvuc", long.MaxValue - gvbar_dm_khuvuc.FocusedRowHandle);
            }
        }

        private void gvbar_Dm_Table_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (Current_Id_Khuvuc != null)
            {
                gvbar_Dm_Table.SetFocusedRowCellValue("Id_Khuvuc", Current_Id_Khuvuc);
                gvbar_dm_khuvuc.SetFocusedRowCellValue("Id_Table", long.MaxValue - gvbar_dm_khuvuc.FocusedRowHandle);
            }
        }

        private void btnAddRanges_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(spinEdit_End.EditValue) > Convert.ToInt32(spinEdit_Start.EditValue)
                && !string.IsNullOrWhiteSpace("" + txtMa_Table_Prefix.EditValue))
            {
                for (int i = Convert.ToInt32(spinEdit_Start.EditValue); i <= Convert.ToInt32(spinEdit_End.EditValue); i++)
                {
                    var ndr = dsBar_Dm_Table.Tables[0].NewRow();
                    ndr["Id_Table"] = long.MaxValue - i;
                    ndr["Ma_Table"] = "" + txtMa_Table_Prefix.EditValue + i.ToString().PadLeft(2, '0');
                    ndr["Ten_Table"] = "" + txtMa_Table_Prefix.EditValue + i.ToString().PadLeft(2, '0');
                    ndr["Id_Khuvuc"] = Current_Id_Khuvuc;
                    ndr["Vitri"] = cvbar_dm_khuvuc.GetFocusedDataRow()["Ten_Khuvuc"];
                    dsBar_Dm_Table.Tables[0].Rows.Add(ndr);
                }
            }
        }

        private void lookUpEdit_Facility_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowExternalDialog("Ecm.MasterTables.dll",
                    "Ecm.MasterTables.Forms.Bar.Frmbar_Dm_Facility",
                    this,
                    null,
                    null,
                    false);

                var dsBar_Dm_Facility = objMasterService.Get_All_Bar_Dm_Facility().ToDataSet();
                lookUpEdit_Facility.DataSource = dsBar_Dm_Facility.Tables[0];
            }
        }

        private void cvbar_Dm_Table_MouseDown(object sender, MouseEventArgs e)
        {
            SaveChanges_Bar_Dm_Table_Facility();
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvbar_Dm_Table.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvbar_Dm_Table.FocusedRowHandle = cardHit.RowHandle;
                Current_Id_Table = cvbar_Dm_Table.GetRowCellValue(cardHit.RowHandle, "Id_Table");
                DisplayInfo_Table_Facility();
            }
        }

        private void gvbar_Dm_Table_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            SaveChanges_Bar_Dm_Table_Facility();
            Current_Id_Table = gvbar_Dm_Table.GetFocusedRowCellValue("Id_Table");
            DisplayInfo_Table_Facility();
        }

        private void gvDm_Table_Facility_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvDm_Table_Facility.SetFocusedRowCellValue("Id_Table", Current_Id_Table);
        }

        private void DisplayInfo_Table_Facility()
        {
            if ("" + Current_Id_Table != "")
            {
                dsBar_Dm_Table_Facility = objMasterService.Get_All_Bar_Dm_Table_Facility_Collection(Current_Id_Table).ToDataSet();
                dgDm_Table_Facility.DataSource = dsBar_Dm_Table_Facility.Tables[0];
                gvDm_Table_Facility.BestFitColumns();
            }
            //gvDm_Table_Facility.OptionsBehavior.Editable = (Current_Id_Table != null) && this.EnableEdit;
        }

        private void SaveChanges_Bar_Dm_Table_Facility()
        {
            if (dsBar_Dm_Table_Facility != null && dsBar_Dm_Table_Facility.HasChanges())
            {
                dsBar_Dm_Table_Facility.AcceptChanges();
                objMasterService.Update_Bar_Dm_Table_Facility_Collection(dsBar_Dm_Table_Facility);
            }
            dsBar_Dm_Table_Facility = new DataSet();
            dgDm_Table_Facility.DataSource = null;
        }

    }
}