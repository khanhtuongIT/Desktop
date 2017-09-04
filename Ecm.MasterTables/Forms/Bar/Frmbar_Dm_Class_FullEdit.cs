using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Bar
{
    public partial class Frmbar_Dm_Class_FullEdit : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public enum EditActivities
        {
            None,
            Class,
            RentCost,
            TableList
        }

        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        //public Ecm.WebReferences.Classes.BarService objBarService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.BarService>();

        DataSet dsWare_Dm_Cuahang_Ban;
        DataSet dsBar_Dm_Class;
        DataSet dsBar_Dm_Table_All;
        DataSet dsBar_Dm_Table;
        DataSet dsBar_Rentcost;

        private EditActivities CurrentEditActivity = EditActivities.None;
        object Current_Id_Cuahang_Ban = null;
        object Current_Id_Class = null;
        object Current_Id_Table = null;

        public Frmbar_Dm_Class_FullEdit()
        {
            InitializeComponent();
            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.AfterCheckUserRightAction += new EventHandler(Frmbar_Dm_Class_FullEdit_AfterCheckUserRightAction);
            //set MainView
            this.dgWare_Dm_Cuahang_Ban.MainView = cvWare_Dm_Cuahang_Ban;
            this.dgBar_Dm_Class.MainView = cvBar_Dm_Class;
            this.dgbar_Dm_Table_All.MainView = cvbar_Dm_Table_All;
            this.dgbar_Dm_Table.MainView = cvbar_Dm_Table;
            //current date
            dtNgay_Bc.DateTime = DateTime.Now;
            DisplayInfo();
        }

        void Frmbar_Dm_Class_FullEdit_AfterCheckUserRightAction(object sender, EventArgs e)
        {
            this.btnRentcost_Edit.Enabled = this.EnableEdit;
        }

        public override void DisplayInfo()
        {
            var dsBar_Dm_Facility = objMasterService.Get_All_Bar_Dm_Facility().ToDataSet();
            lookUpEdit_Facility.DataSource = dsBar_Dm_Facility.Tables[0];

            var dsBar_Dm_Rentlevel = objMasterService.Get_All_Bar_Dm_Rentlevel_Collection().ToDataSet();
            LookUpEdit_Rentlevel.DataSource = dsBar_Dm_Rentlevel.Tables[0];
            DisplayInfo_Cuahang();
            DisplayInfo_Class();
            ChangeStatus(false);
            base.DisplayInfo();
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

        public void DisplayInfo_Table()
        {
            try
            {
                Current_Id_Table = null;
                dsBar_Dm_Table_All = objMasterService.Get_All_Bar_Dm_Table_WithClass(Current_Id_Cuahang_Ban, null, null, true).ToDataSet();
                dgbar_Dm_Table_All.DataSource = dsBar_Dm_Table_All.Tables[0];

                dsBar_Dm_Table = objMasterService.Get_All_Bar_Dm_Table_WithClass(Current_Id_Cuahang_Ban, null, Current_Id_Class, true).ToDataSet();
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

        void DisplayInfo_Class()
        {
            try
            {
                dsBar_Dm_Class = objMasterService.Get_All_Bar_Dm_Class().ToDataSet();
                dgBar_Dm_Class.DataSource = dsBar_Dm_Class.Tables[0];
                if (cvBar_Dm_Class.RowCount > 0)
                {
                    cvBar_Dm_Class.FocusedRowHandle = 0;
                    Current_Id_Class = cvBar_Dm_Class.GetFocusedRowCellValue("Id_Class");
                }
                //dgBar_Dm_Class
                if (dsBar_Dm_Class.Tables[0].Rows.Count > 0)
                {
                    int i = Convert.ToInt32("0" + dsBar_Dm_Class.Tables[0].Rows[0]["Id_Class"]);
                    foreach (DataRow drClass in dsBar_Dm_Class.Tables[0].Rows)
                    {
                        DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
                        styleFormatCondition.Appearance.BackColor = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetColor(Convert.ToInt32(drClass["Id_Class"]));
                        styleFormatCondition.Appearance.Options.UseBackColor = true;
                        styleFormatCondition.ApplyToRow = true;
                        styleFormatCondition.Column = this.cvBar_Dm_Class.Columns.ColumnByFieldName("Id_Class");
                        styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
                        styleFormatCondition.Value1 = Convert.ToInt32(drClass["Id_Class"]);
                        this.cvBar_Dm_Class.FormatConditions.Add(styleFormatCondition);
                    }
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private void DisplayInfo_Table_Facility()
        {
            if ("" + Current_Id_Table != "")
            {
                var dsBar_Dm_Table_Facility = objMasterService.Get_All_Bar_Dm_Table_Facility_Collection(Current_Id_Table).ToDataSet();
                dgDm_Table_Facility.DataSource = dsBar_Dm_Table_Facility.Tables[0];
                gvDm_Table_Facility.BestFitColumns();
            }
        }

        private void DisplayInfo_Table_Facility(object Id_Table)
        {
            if ("" + Id_Table != "")
            {
                var dsBar_Dm_Table_Facility = objMasterService.Get_All_Bar_Dm_Table_Facility_Collection(Id_Table).ToDataSet();
                dgDm_Table_Facility.DataSource = dsBar_Dm_Table_Facility.Tables[0];
                gvDm_Table_Facility.BestFitColumns();
            }
            //gvDm_Table_Facility.OptionsBehavior.Editable = (Current_Id_Table != null) && this.EnableEdit;
        }

        private void DisplayInfo_Rentcost()
        {
            dgbar_Rentcost.DataSource = null;
            if ("" + Current_Id_Class != "" || "" + Current_Id_Cuahang_Ban != "")
            {
                //dsBar_Rentcost = objBarService.Get_All_Bar_Rentcost_Collection(Current_Id_Cuahang_Ban, Current_Id_Class, dtNgay_Bc.DateTime).ToDataSet();
                //dgbar_Rentcost.DataSource = dsBar_Rentcost.Tables[0];
                gvbar_Rentcost.BestFitColumns();
            }
        }

        public override bool PerformEdit()
        {
            if (Current_Id_Cuahang_Ban == null) return false;
            if (CurrentEditActivity == EditActivities.None)
                this.CurrentEditActivity = EditActivities.Class;
            ChangeStatus(true);
            this.ChangeFormState(GoobizFrame.Windows.Forms.FormState.Edit);
            return base.PerformEdit();
        }

        public override void ChangeStatus(bool editTable)
        {
            switch (CurrentEditActivity)
            {
                case EditActivities.Class:
                    dgWare_Dm_Cuahang_Ban.Enabled = !editTable;
                    dgbar_Dm_Table.Enabled = !editTable;
                    dgDm_Table_Facility.Enabled = !editTable;
                    dgbar_Rentcost.Enabled = !editTable;
                    gvBar_Dm_Class.OptionsBehavior.Editable = editTable;
                    gvbar_Rentcost.OptionsBehavior.Editable = !editTable;
                    if (editTable)
                    {
                        dgBar_Dm_Class.MainView = gvBar_Dm_Class;
                    }
                    else
                    {
                        dgBar_Dm_Class.MainView = cvBar_Dm_Class;
                    }
                    break;

                case EditActivities.RentCost:
                    dgWare_Dm_Cuahang_Ban.Enabled = !editTable;
                    dgbar_Dm_Table_All.Enabled = !editTable;
                    dgbar_Dm_Table.Enabled = !editTable;
                    dgDm_Table_Facility.Enabled = !editTable;
                    dgBar_Dm_Class.Enabled = !editTable;
                    btnRentcost_Edit.Enabled = !editTable;
                    btnDgAll.Enabled = !editTable;
                    btnDgNgay.Enabled = !editTable;
                    btnDm_Table_Edit.Enabled = !editTable;
                    gvbar_Rentcost.OptionsBehavior.Editable = editTable;
                    break;

                case EditActivities.TableList:
                    btnRentcost_Edit.Enabled = !editTable;
                    btnDgAll.Enabled = !editTable;
                    btnDgNgay.Enabled = !editTable;
                    dgBar_Dm_Class.Enabled = !editTable;
                    dgbar_Rentcost.Enabled = !editTable;

                    btnTable_Add.Enabled = editTable;
                    btnTable_Remove.Enabled = editTable;
                    btnDm_Table_Edit.Enabled = !editTable;
                    break;

                case EditActivities.None:
                    gvBar_Dm_Class.OptionsBehavior.Editable = false;
                    gvbar_Rentcost.OptionsBehavior.Editable = false;
                    btnTable_Add.Enabled = false;
                    btnTable_Remove.Enabled = false;
                    break;
            }
            base.ChangeStatus(editTable);
        }

        public override bool PerformSave()
        {
            return this.PerformSaveChanges();
            //return base.PerformSave();
        }

        public override bool PerformSaveChanges()
        {
            bool valid = true;
            switch (CurrentEditActivity)
            {
                case EditActivities.Class:
                    GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                    hashtableControls.Add(gvBar_Dm_Class.Columns["Ma_Class"], "");
                    hashtableControls.Add(gvBar_Dm_Class.Columns["Ten_Class"], "");

                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvBar_Dm_Class))
                        valid = false;

                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(hashtableControls, gvBar_Dm_Class))
                        valid = false;

                    if (valid)
                    {
                        try
                        {
                            this.DoClickEndEdit(this.dgBar_Dm_Class);
                            this.dsWare_Dm_Cuahang_Ban.Tables[0].Columns["Ma_Cuahang_Ban"].Unique = true;
                            objMasterService.Update_Bar_Dm_Class_Collection(this.dsBar_Dm_Class);
                        }
                        catch (Exception ex)
                        {
                            GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), ex.GetType().FullName);
                            valid = false;
                        }
                    }
                    break;

                case EditActivities.TableList:
                    try
                    {
                        if (dsBar_Dm_Table_All.HasChanges())
                            objMasterService.Update_Bar_Dm_Table_Collection(dsBar_Dm_Table_All);
                        valid = true;
                    }
                    catch (Exception ex)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), ex.GetType().FullName);
                        valid = false;
                    }
                    break;

                case EditActivities.RentCost:
                    try
                    {
                        this.DoClickEndEdit(dgbar_Rentcost);
                        GoobizFrame.Windows.Public.OrderHashtable htb = new GoobizFrame.Windows.Public.OrderHashtable();
                        htb.Add(gvbar_Rentcost.Columns["Id_Rentlevel"], "");
                        htb.Add(gvbar_Rentcost.Columns["Dongia"], "");
                        htb.Add(gvbar_Rentcost.Columns["Ngay_Batdau"], "");
                        htb.Add(gvbar_Rentcost.Columns["Ngay_Ketthuc"], "");

                        if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(htb, gvbar_Rentcost))
                            return false;

                        if (!GoobizFrame.Windows.MdiUtils.Validator.CheckDateGrid(gvbar_Rentcost.Columns["Ngay_Batdau"], gvbar_Rentcost.Columns["Ngay_Ketthuc"], gvbar_Rentcost))
                            return false;

                        //if (dsBar_Rentcost.HasErrors)
                        //    valid = false;
                        if (dsBar_Rentcost.HasChanges())
                        {
                            //objBarService.Update_Bar_Rentcost_Collection(dsBar_Rentcost);
                            //valid = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), ex.GetType().FullName);
                        valid = false;
                    }
                    break;
            }

            if (valid)
            {
                ChangeStatus(false);
                DisplayInfo();
                this.CurrentEditActivity = EditActivities.None;
            }
            return valid;
        }

        public override bool PerformCancel()
        {
            ChangeStatus(false);
            this.CurrentEditActivity = EditActivities.None;
            return base.PerformCancel();
        }

        private void btnRentcost_Edit_Click(object sender, EventArgs e)
        {
            this.CurrentEditActivity = EditActivities.RentCost;
            this.PerformEdit();
            dsBar_Rentcost = objBarService.Get_All_Bar_Rentcost_Collection(Current_Id_Cuahang_Ban, Current_Id_Class, null).ToDataSet();
            DataSet dsBar_Dm_Rentlevel = objMasterService.Get_All_Bar_Dm_Rentlevel_Collection().ToDataSet();
            if (dsBar_Rentcost.Tables[0].Rows.Count != dsBar_Dm_Rentlevel.Tables[0].Rows.Count)
                foreach (DataRow dtr in dsBar_Dm_Rentlevel.Tables[0].Rows)
                {
                    var new_row = dsBar_Rentcost.Tables[0].NewRow();
                    new_row["Id_Rentlevel"] = dtr["Id_Rentlevel"];
                    new_row["Id_Class"] = Current_Id_Class;
                    new_row["Id_Cuahang_Ban"] = Current_Id_Cuahang_Ban;
                    new_row["Ngay_Batdau"] = dtNgay_Bc.DateTime;
                    dsBar_Rentcost.Tables[0].Rows.Add(new_row);
                }
            dgbar_Rentcost.DataSource = dsBar_Rentcost.Tables[0];
        }

        private void cvbar_Dm_Table_All_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvbar_Dm_Table_All.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvbar_Dm_Table_All.FocusedRowHandle = cardHit.RowHandle;
                Current_Id_Table = cvbar_Dm_Table_All.GetRowCellValue(cardHit.RowHandle, "Id_Table");
                DisplayInfo_Table_Facility();
                GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvbar_Dm_Table_All, "Id_Table", Current_Id_Table);
            }
        }

        private void cvWare_Dm_Cuahang_Ban_MouseDown(object sender, MouseEventArgs e)
        {
            dgDm_Table_Facility.DataSource = null;
            dgbar_Rentcost.DataSource = null;

            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvWare_Dm_Cuahang_Ban.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvWare_Dm_Cuahang_Ban.FocusedRowHandle = cardHit.RowHandle;
                Current_Id_Cuahang_Ban = cvWare_Dm_Cuahang_Ban.GetRowCellValue(cardHit.RowHandle, "Id_Cuahang_Ban");
                DisplayInfo_Table();
                GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvWare_Dm_Cuahang_Ban, "Id_Cuahang_Ban", Current_Id_Cuahang_Ban);
            }
        }

        private void cvBar_Dm_Class_MouseDown(object sender, MouseEventArgs e)
        {
            dgDm_Table_Facility.DataSource = null;
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvBar_Dm_Class.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvBar_Dm_Class.FocusedRowHandle = cardHit.RowHandle;
                Current_Id_Class = cvBar_Dm_Class.GetRowCellValue(cardHit.RowHandle, "Id_Class");
                DisplayInfo_Table();
                DisplayInfo_Rentcost();
                //GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvBar_Dm_Class, "Id_Class", Current_Id_Class);
                //dgBar_Dm_Class
                cvbar_Dm_Table.FormatConditions.Clear();
                if ("" + Current_Id_Class != "")
                {
                    DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition = new DevExpress.XtraGrid.StyleFormatCondition();
                    styleFormatCondition.Appearance.BackColor = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetColor(Convert.ToInt32(Current_Id_Class));
                    styleFormatCondition.Appearance.Options.UseBackColor = true;
                    styleFormatCondition.ApplyToRow = true;
                    styleFormatCondition.Column = this.cvbar_Dm_Table.Columns.ColumnByFieldName("Id_Class");
                    styleFormatCondition.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
                    styleFormatCondition.Value1 = Convert.ToInt32(Current_Id_Class);
                    this.cvbar_Dm_Table.FormatConditions.Add(styleFormatCondition);
                }
            }
        }

        private void btnDm_Table_Edit_Click(object sender, EventArgs e)
        {
            this.CurrentEditActivity = EditActivities.TableList;
            this.PerformEdit();
        }

        private void btnTable_Add_Click(object sender, EventArgs e)
        {
            if (Current_Id_Class == null || Current_Id_Table == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phòng, vui lòng chọn phòng");
                return;
            }

            var sdr = dsBar_Dm_Table.Tables[0].Select(string.Format("Id_Table={0}", Current_Id_Table));
            if (sdr.Length > 0)
                return;

            var sdr_All = dsBar_Dm_Table_All.Tables[0].Select(string.Format("Id_Table={0}", Current_Id_Table))[0];
            sdr_All["Id_Class"] = Current_Id_Class;

            var ndr = dsBar_Dm_Table.Tables[0].NewRow();
            foreach (DataColumn dc in dsBar_Dm_Table.Tables[0].Columns)
                ndr[dc.ColumnName] = sdr_All[dc.ColumnName];

            dsBar_Dm_Table.Tables[0].Rows.Add(ndr);
            dgbar_Dm_Table.RefreshDataSource();
        }

        private void btnTable_Remove_Click(object sender, EventArgs e)
        {
            var id_table = cvbar_Dm_Table.GetFocusedRowCellValue("Id_Table");
            if ("" + id_table == "")
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phòng, vui lòng chọn phòng");
                return;
            }

            var sdr_All = dsBar_Dm_Table_All.Tables[0].Select(string.Format("Id_Table={0}", id_table))[0];
            sdr_All["Id_Class"] = DBNull.Value;

            var sdr = dsBar_Dm_Table.Tables[0].Select(string.Format("Id_Table={0}", id_table))[0];
            dsBar_Dm_Table.Tables[0].Rows.Remove(sdr);
            dgbar_Dm_Table.RefreshDataSource();
        }


        private void cvbar_Dm_Table_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvbar_Dm_Table.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvbar_Dm_Table.FocusedRowHandle = cardHit.RowHandle;
                var Current_Id_Table_Class = cvbar_Dm_Table.GetRowCellValue(cardHit.RowHandle, "Id_Table");

                DisplayInfo_Table_Facility(Current_Id_Table_Class);
                //GoobizFrame.Windows.MdiUtils.ThemeSettings.MakeConditionForSelectedCard(cvbar_Dm_Table, "Id_Table", Current_Id_Table_Class);
            }
        }

        private void LookUpEdit_Rentlevel_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowExternalDialog("Ecm.MasterTables.dll",
                    "Ecm.MasterTables.Forms.Bar.Frmbar_Dm_Rentlevel",
                    this,
                    null,
                    null,
                    false);

                var dsBar_Dm_Rentlevel = objMasterService.Get_All_Bar_Dm_Rentlevel_Collection().ToDataSet();
                LookUpEdit_Rentlevel.DataSource = dsBar_Dm_Rentlevel.Tables[0];
            }
        }

        private void dtNgay_Bc_EditValueChanged(object sender, EventArgs e)
        {
            DisplayInfo_Rentcost();
        }

        private void repositoryItemDateEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                gvbar_Rentcost.SetFocusedRowCellValue(gvbar_Rentcost.FocusedColumn.FieldName, null);
            }
        }

        private void gvbar_Rentcost_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvbar_Rentcost.SetFocusedRowCellValue("Id_Rentcost", DateTime.Now.Ticks);
            gvbar_Rentcost.SetFocusedRowCellValue("Id_Class", Current_Id_Class);
            gvbar_Rentcost.SetFocusedRowCellValue("Id_Cuahang_Ban", Current_Id_Cuahang_Ban);
            gvbar_Rentcost.SetFocusedRowCellValue("Ngay_Batdau", dtNgay_Bc.DateTime);
        }

        private void btnDgNgay_Click(object sender, EventArgs e)
        {
            DisplayInfo_Rentcost();
            this.btnRentcost_Edit.Enabled = true;
        }

        private void btnDgAll_Click(object sender, EventArgs e)
        {
            dgbar_Rentcost.DataSource = null;
            if ("" + Current_Id_Class != "" || "" + Current_Id_Cuahang_Ban != "")
            {
                dsBar_Rentcost = objBarService.Get_All_Bar_Rentcost_Collection(Current_Id_Cuahang_Ban, Current_Id_Class, null).ToDataSet();
                dgbar_Rentcost.DataSource = dsBar_Rentcost.Tables[0];
                gvbar_Rentcost.BestFitColumns();
            }
            this.btnRentcost_Edit.Enabled = false;
        }

        private void gvbar_Rentcost_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                //var dr = gvbar_Rentcost.GetFocusedDataRow();
                //if ("" + dr["Id_Rentlevel"] != "" && "" + dr["Ngay_Batdau"] != "")
                //{
                //    var q = from r in dsBar_Rentcost.Tables[0].AsEnumerable()
                //            where r.Field<long>("Id_Rentcost") != long.Parse("" + dr["Id_Rentcost"])
                //                && r.Field<long>("Id_Class") == long.Parse("" + dr["Id_Class"])
                //                && r.Field<long>("Id_Rentlevel") == long.Parse("" + dr["Id_Rentlevel"])
                //                && DateTime.Parse("" + dr["Ngay_Batdau"]) >= r.Field<DateTime>("Ngay_Batdau")
                //                && DateTime.Parse("" + dr["Ngay_Batdau"]) <= (("" + r.Field<object>("Ngay_Ketthuc") != "") ? r.Field<DateTime>("Ngay_Ketthuc") : new DateTime(9999, 9, 9))
                //            select r;

                //    var valid = (q.Count<DataRow>() == 0);
                //    valid = valid && objBarService.Bar_Rentcost_CheckDate(new Ecm.WebReferences.BarService.Bar_Rentcost()
                //        {
                //            Id_Cuahang_Ban = Current_Id_Cuahang_Ban,
                //            Id_Class = Current_Id_Class,
                //            Id_Rentlevel = dr["Id_Rentlevel"],
                //            Ngay_Batdau = dr["Ngay_Batdau"],
                //            Ngay_Ketthuc = ("" + dr["Ngay_Ketthuc"] != "") ? dr["Ngay_Ketthuc"] : new DateTime(9999, 9, 9),
                //        });

                //    dr.RowError = (!valid)
                //    ? "thời gian từ Ngày bắt đầu đến ngày kết thúc không hợp lệ"
                //    : "";
                //}
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

    }
}
