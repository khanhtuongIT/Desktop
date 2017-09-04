using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.MasterTables.Forms.Bar
{
    public partial class Frmbar_Dm_Menu_FullEdit : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public enum EditActivities
        {
            Menu,
            Hanghoa,
            None
        }

        Ecm.WebReferences.Classes.MasterService objMasterService = new WebReferences.Classes.MasterService();

        DataSet dsDm_Nhom_Hanghoa_Ban;
        DataSet dsDm_Donvitinh;
        DataSet dsDm_Hanghoa_Ban;
        DataSet ds_Hanghoa_Dinhgia;
        DataSet dsBar_Dm_Menu;
        DataSet dsMenu_Hanghoa_Ban;

        object Current_Id_Nhom_Hanghoa_Ban;
        object Current_Id_Menu;

        EditActivities action = EditActivities.None;

        public Frmbar_Dm_Menu_FullEdit()
        {
            InitializeComponent();

            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            DisplayInfo();

            this.AfterCheckUserRightAction += new EventHandler(Frmbar_Dm_Menu_FullEdit_AfterCheckUserRightAction);
        }

        void Frmbar_Dm_Menu_FullEdit_AfterCheckUserRightAction(object sender, EventArgs e)
        {
            this.btnInit_Menu.Enabled = this.EnableEdit;
        }   

        #region local data
     
        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_NHOM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Nhom_Hanghoa_Ban.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_WARE_HANGHOA_DINHGIA = @"Resources\localdata\WARE_HANGHOA_DINHGIA.xml"; //WARE_HANGHOA_DINHGIA

        DateTime dtlc_bar_dm_menu;
        DateTime dtlc_ware_dm_donvitinh;
        DateTime dtlc_ware_dm_nhom_hanghoa_ban;
        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_ware_hanghoa_dinhgia;
        DateTime dtlc_bar_dm_menu_hanghoa_ban;

        #endregion

        #region LoadMasterData
       
        private DateTime GetLastChange_FrmLognotify(string table_name)
        {
            try
            {
                return Convert.ToDateTime(dsSys_Lognotify.Tables[0].Select(string.Format("Table_Name='{0}'", table_name))[0]["Last_Change"]);
            }
            catch (Exception ex)
            {
                return new DateTime(2010, 01, 01);
            }
        }
       
        void LoadMasterData()
        {
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables(
                    "[Ware_Dm_Nhom_Hanghoa_Ban], [Ware_Dm_Loai_Hanghoa_Ban], " +
                    "[Ware_Dm_Donvitinh], [Ware_Dm_Khachhang], [ware_dm_hanghoa_ban]").ToDataSet();

            //date time last change
            dtlc_ware_dm_nhom_hanghoa_ban = GetLastChange_FrmLognotify("Ware_Dm_Nhom_Hanghoa_Ban");
            dtlc_ware_dm_donvitinh = GetLastChange_FrmLognotify("Ware_Dm_Donvitinh");
            dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("ware_dm_hanghoa_ban");
            dtlc_ware_hanghoa_dinhgia = GetLastChange_FrmLognotify("WARE_HANGHOA_DINHGIA");
            dtlc_bar_dm_menu = GetLastChange_FrmLognotify("BAR_DM_MENU");

            //load data from local xml when last change at local differ from database
            if (!System.IO.File.Exists(xml_WARE_DM_NHOM_HANGHOA_BAN)
                || DateTime.Compare(dtlc_ware_dm_nhom_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_NHOM_HANGHOA_BAN)) > 0)
            {
                dsDm_Nhom_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet();
                dsDm_Nhom_Hanghoa_Ban.WriteXml(xml_WARE_DM_NHOM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (dsDm_Nhom_Hanghoa_Ban == null || dsDm_Nhom_Hanghoa_Ban.Tables.Count == 0)
            {
                dsDm_Nhom_Hanghoa_Ban = new DataSet();
                dsDm_Nhom_Hanghoa_Ban.ReadXml(xml_WARE_DM_NHOM_HANGHOA_BAN);
            }
            
            //xml_WARE_DM_DONVITINH
            if (!System.IO.File.Exists(xml_WARE_DM_DONVITINH)
                || DateTime.Compare(dtlc_ware_dm_donvitinh, System.IO.File.GetLastWriteTime(xml_WARE_DM_DONVITINH)) > 0)
            {
                dsDm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                dsDm_Donvitinh.WriteXml(xml_WARE_DM_DONVITINH, XmlWriteMode.WriteSchema);
            }
            else if (dsDm_Donvitinh == null || dsDm_Donvitinh.Tables.Count == 0)
            {
                dsDm_Donvitinh = new DataSet();
                dsDm_Donvitinh.ReadXml(xml_WARE_DM_DONVITINH);
            }
           
            if (!System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN)
              || DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN)) > 0)
            {
                dsDm_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                dsDm_Hanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else
            {
                dsDm_Hanghoa_Ban = new DataSet();
                dsDm_Hanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN);
            }

            if (!System.IO.File.Exists(xml_WARE_HANGHOA_DINHGIA)
                || DateTime.Compare(dtlc_ware_hanghoa_dinhgia, System.IO.File.GetLastWriteTime(xml_WARE_HANGHOA_DINHGIA)) > 0)
            {
                ds_Hanghoa_Dinhgia = objMasterService.Get_All_Ware_Hanghoa_Dinhgia().ToDataSet();
                ds_Hanghoa_Dinhgia.WriteXml(xml_WARE_HANGHOA_DINHGIA, XmlWriteMode.WriteSchema);
            }
            else //if (ds_Hanghoa_Dinhgia == null || ds_Hanghoa_Dinhgia.Tables.Count == 0)
            {
                ds_Hanghoa_Dinhgia = new DataSet();
                ds_Hanghoa_Dinhgia.ReadXml(xml_WARE_HANGHOA_DINHGIA);
            }

            dsDm_Nhom_Hanghoa_Ban.AcceptChanges();
            //dsDm_Loai_Hanghoa_Ban.AcceptChanges();
            dsDm_Donvitinh.AcceptChanges();
            dsDm_Hanghoa_Ban.AcceptChanges();
        }
      
        void ReloadDmHanghoa()
        {
            try
            {
                dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables(
                    "[Ware_Dm_Nhom_Hanghoa_Ban], [Ware_Dm_Loai_Hanghoa_Ban], " +
                    "[Ware_Dm_Donvitinh], [Ware_Dm_Khachhang], [ware_dm_hanghoa_ban]").ToDataSet();
                dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("ware_dm_hanghoa_ban");
                if (!System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN)
              || DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN)) > 0)
                {
                    dsDm_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                    dsDm_Hanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
                }
                else
                {
                    dsDm_Hanghoa_Ban = new DataSet();
                    dsDm_Hanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN);
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }
        #endregion

        private void btnNhom_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                    "Ecm.MasterTables.dll",
                    "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_FullEdit", this);

                if (dialog == null)
                    return;

                DisplayInfo();
                
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }
     
        #region override

        public override void DisplayInfo()
        {
            ChangeStatus(false);
            action = EditActivities.None;
            Current_Id_Nhom_Hanghoa_Ban = null;
            Current_Id_Menu = null;

            try
            {
                LoadMasterData();
                this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //Get data Bar_Dm_Menu   
                //gridView2.RefreshData();
                dsBar_Dm_Menu = objMasterService.Get_All_Bar_Dm_Menu().ToDataSet();
                gridLookUpEdit_Menu.DataSource = dsBar_Dm_Menu.Tables[0];
                dgbar_Dm_Menu.DataSource = dsBar_Dm_Menu;
                dgbar_Dm_Menu.DataMember = dsBar_Dm_Menu.Tables[0].TableName;

                gridLookUp_Donvitinh.DataSource = dsDm_Donvitinh.Tables[0];
                gridLookUp_Hanghoa_Ban.DataSource = dsDm_Hanghoa_Ban.Tables[0];
                gridLookUp_Nhom_Hanghoa_Ban.DataSource = dsDm_Nhom_Hanghoa_Ban.Tables[0];
                DisplayInfo_NhomHanghoa();
                cvbar_Dm_Menu_Hanghoa_Ban.ClearColumnsFilter();
                base.DisplayInfo();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            switch (action)
            {
                case EditActivities.None:
                case EditActivities.Hanghoa:
                    dpNhom_Hanghoa.Enabled = !editTable;
                    dpMenu.Enabled = !editTable;
                    if (editTable)
                    {
                        dgbar_Dm_Menu_Hanghoa_Ban.MainView = gvbar_Dm_Menu_Hanghoa_Ban;
                        gvbar_Dm_Menu_Hanghoa_Ban.OptionsBehavior.Editable = editTable;
                    }
                    else
                        dgbar_Dm_Menu_Hanghoa_Ban.MainView = cvbar_Dm_Menu_Hanghoa_Ban;
                    break;
                case EditActivities.Menu:
                    dpNhom_Hanghoa.Enabled = !editTable;
                    dpMenu_Hanghoa.Enabled = !editTable;
                    btnEdit_Menu.Enabled = !editTable;
                    if (editTable)
                    {
                        dgbar_Dm_Menu.MainView = gvbar_Dm_Menu;
                        gvbar_Dm_Menu.OptionsBehavior.Editable = editTable;
                    }
                    else
                        dgbar_Dm_Menu.MainView = cvbar_Dm_Menu;
                    break;
            }
            base.ChangeStatus(editTable);
        }

        public override bool PerformEdit()
        {
            if (action == EditActivities.None)
            {
                if (Current_Id_Menu == null)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_EMPTY_COLLECTION", new string[]{dpMenu.Text});
                    return false;
                }
                action = EditActivities.Hanghoa;
            }
            ChangeStatus(true);
            return base.PerformEdit();
        }

        public override bool PerformSave()
        {
            return PerformSaveChanges();
        }

        public override bool PerformSaveChanges()
        {
            bool success = false;
            switch (action)
            {
                case EditActivities.Hanghoa:
                    success = PerformSave_Menu_Hanghoa();
                    break;
                case EditActivities.Menu:
                    success = PerformSave_Menu();
                    break;
            }
            return success;
        }

        public override bool PerformCancel()
        {
            ChangeStatus(false);
            DisplayInfo();
            return base.PerformCancel();
        }

        #endregion

        #region Utils

        private void DisplayInfo_NhomHanghoa()
        {
            try
            {
                dgware_Dm_Nhom_Hanghoa_Ban.DataSource = dsDm_Nhom_Hanghoa_Ban.Tables[0];
                dgware_Dm_Nhom_Hanghoa_Ban.RefreshDataSource();
                dgware_Dm_Nhom_Hanghoa_Ban.MainView = cvDm_Nhom_Hanghoa_Ban;
                if (cvDm_Nhom_Hanghoa_Ban.RowCount > 0)
                {
                    cvDm_Nhom_Hanghoa_Ban.FocusedRowHandle = 0;
                    Current_Id_Nhom_Hanghoa_Ban = cvDm_Nhom_Hanghoa_Ban.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban");

                    DisplayInfo_Menu();
                }

            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private void DisplayInfo_Menu()
        {
            try
            {
                dgbar_Dm_Menu.DataSource = dsBar_Dm_Menu.Tables[0];
                dgbar_Dm_Menu.MainView = cvbar_Dm_Menu;

                if (Current_Id_Nhom_Hanghoa_Ban != null)
                {
                    cvbar_Dm_Menu.Columns["Id_Nhom_Hanghoa_Ban"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(cvbar_Dm_Menu.Columns["Id_Nhom_Hanghoa_Ban"], Current_Id_Nhom_Hanghoa_Ban);
                    cvbar_Dm_Menu.ApplyColumnsFilter();
                }

                if (cvbar_Dm_Menu.RowCount > 0)
                {
                    cvbar_Dm_Menu.FocusedRowHandle = 0;
                    Current_Id_Menu = cvbar_Dm_Menu.GetFocusedRowCellValue("Id_Menu");
                }
                else
                    Current_Id_Menu = null;

                DisplayInfo_Menu_Hanghoa();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private void DisplayInfo_Menu_Hanghoa()
        {
            try
            {
                dsMenu_Hanghoa_Ban = objMasterService.Get_All_Bar_Dm_Menu_Hanghoa_Ban_By_Id_Menu((Current_Id_Menu != null) ? Current_Id_Menu : -1 ,null).ToDataSet();
                dgbar_Dm_Menu_Hanghoa_Ban.DataSource = dsMenu_Hanghoa_Ban.Tables[0];
                dgbar_Dm_Menu_Hanghoa_Ban.MainView = cvbar_Dm_Menu_Hanghoa_Ban;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private bool PerformSave_Menu_Hanghoa()
        {
            try
            {
                bool success = false;
               
                dgbar_Dm_Menu_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgbar_Dm_Menu_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);

                if (gvbar_Dm_Menu_Hanghoa_Ban.RowCount == 0)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Danh sách hàng hóa không thể rỗng");
                    return false;
                }

                try
                {
                    Constraint constraint = new UniqueConstraint("UniqueConstraint1",
                            new DataColumn[] {dsMenu_Hanghoa_Ban.Tables[0].Columns["Id_Hanghoa_Ban"],
                                  dsMenu_Hanghoa_Ban.Tables[0].Columns["Id_Donvitinh"] }, false);
                    dsMenu_Hanghoa_Ban.Tables[0].Constraints.Clear();
                    dsMenu_Hanghoa_Ban.Tables[0].Constraints.Add(constraint);

                    objMasterService.Update_Bar_Dm_Menu_Hanghoa_Ban_Collection(dsMenu_Hanghoa_Ban);
                    dsMenu_Hanghoa_Ban.AcceptChanges();
                    success = true;
                }
                catch (Exception ex)
                {
                    if (ex.ToString().IndexOf("These columns don't currently have unique values") != -1)
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa đã được thêm vào menu, vui lòng kiểm tra lại");

                    return false;

                }
                
                if (success)
                {
                    this.DisplayInfo();
                }

                return success;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return false;
            }
        }

        private bool PerformSave_Menu()
        {
            GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
            hashtableControls.Add(gvbar_Dm_Menu.Columns["Ma_Menu"], "");
            hashtableControls.Add(gvbar_Dm_Menu.Columns["Ten_Menu"], "");

            if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvbar_Dm_Menu))
                return false;

            try
            {
                dgbar_Dm_Menu.EmbeddedNavigator.Buttons.DoClick(dgbar_Dm_Menu.EmbeddedNavigator.Buttons.EndEdit);
                dsBar_Dm_Menu.Tables[0].Columns["Ma_Menu"].Unique = true;

                objMasterService.Update_Bar_Dm_Menu_Collection(this.dsBar_Dm_Menu);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Unique") != -1)
                {
                    GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { gvbar_Dm_Menu.Columns["Ma_Menu"].Caption });
                    return false;
                }

            }
            this.DisplayInfo();
            return true;
        }

        private void cvDm_Nhom_Hanghoa_Ban_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvDm_Nhom_Hanghoa_Ban.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvDm_Nhom_Hanghoa_Ban.FocusedRowHandle = cardHit.RowHandle;
                Current_Id_Nhom_Hanghoa_Ban = cvDm_Nhom_Hanghoa_Ban.GetRowCellValue(cardHit.RowHandle, "Id_Nhom_Hanghoa_Ban");
                DisplayInfo_Menu();
            }
        }

        private void cvbar_Dm_Menu_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Card.ViewInfo.CardHitInfo cardHit = cvbar_Dm_Menu.CalcHitInfo(e.X, e.Y);
            if (cardHit.InCard)
            {
                cvbar_Dm_Menu.FocusedRowHandle = cardHit.RowHandle;
                Current_Id_Menu = cvbar_Dm_Menu.GetRowCellValue(cardHit.RowHandle, "Id_Menu");
                DisplayInfo_Menu_Hanghoa();
            }
        }

        private void gvbar_Dm_Menu_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (Current_Id_Nhom_Hanghoa_Ban != null)
                gvbar_Dm_Menu.SetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban", Current_Id_Nhom_Hanghoa_Ban);
        }

        private void gvbar_Dm_Menu_Hanghoa_Ban_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (Current_Id_Menu != null)
                gvbar_Dm_Menu_Hanghoa_Ban.SetFocusedRowCellValue("Id_Menu", Current_Id_Menu);
        }

        private void gridLookUp_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                    "Ecm.MasterTables.dll",
                    "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_FullEdit", this);

                if (dialog == null)
                    return;

                var SelectedObject = dialog.GetType().GetProperty("Selected_Ware_Dm_Hanghoa_Ban").GetValue(dialog, null)
                       as Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban;

                ReloadDmHanghoa();
                gridLookUp_Hanghoa_Ban.DataSource = dsDm_Hanghoa_Ban.Tables[0];

                if (SelectedObject != null)
                {

                    gvbar_Dm_Menu_Hanghoa_Ban.SetFocusedRowCellValue(gvbar_Dm_Menu_Hanghoa_Ban.Columns["Id_Hanghoa_Ban"], SelectedObject.Id_Hanghoa_Ban);

                }
            }
        }

        private void btnEdit_Menu_Click(object sender, EventArgs e)
        {
            this.action = EditActivities.Menu;
            this.item_Edit.PerformClick();
        }

        #endregion

        private void gvbar_Dm_Menu_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvbar_Dm_Menu.GetFocusedDataRow() != null)
            {
                Current_Id_Menu = gvbar_Dm_Menu.GetFocusedDataRow()["Id_Menu"];
                if (dgbar_Dm_Menu_Hanghoa_Ban.MainView == gvbar_Dm_Menu_Hanghoa_Ban)
                {
                    gvbar_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        gvbar_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"], Current_Id_Menu);
                    gvbar_Dm_Menu_Hanghoa_Ban.ApplyColumnsFilter();
                }
                else
                {
                    cvbar_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
                        cvbar_Dm_Menu_Hanghoa_Ban.Columns["Id_Menu"], Current_Id_Menu);
                    cvbar_Dm_Menu_Hanghoa_Ban.ApplyColumnsFilter();
                }
            }
        }

        private void btnInit_Menu_Click(object sender, EventArgs e)
        {
            if (GoobizFrame.Windows.Forms.UserMessage.Show("SYS_CONFIRM_BFRESET", new string[] { }) == System.Windows.Forms.DialogResult.Yes)
            {
                if (Current_Id_Nhom_Hanghoa_Ban == null) return;
                objMasterService.Init_Bar_Dm_Menu_WithNhom_Hanghoa_Ban(new WebReferences.MasterService.Bar_Dm_Menu()
                {
                    Id_Nhom_Hanghoa_Ban = Current_Id_Nhom_Hanghoa_Ban
                });
                DisplayInfo();
            }
        }
   
    }
}