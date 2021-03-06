using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using Wref = Ecm.WebReferences.Classes;

namespace Ecm.MasterTables.Forms.Bar
{
    public partial class Frmbar_Dm_Menu_Hanghoa_Ban_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Menu_Hanghoa_Ban = new DataSet();
        DataSet dsBar_Dm_Menu = new DataSet();
        //Ecm.MasterTables.Forms.Bar.Frmbar_Dm_Menu_Add frmbar_Dm_Menu_Add = new Frmbar_Dm_Menu_Add();
        Ecm.MasterTables.Forms.Ware.Frmware_Dm_Nhom_Hanghoa_Ban_Add frmware_Dm_Nhom_Hanghoa_Ban_Add = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Nhom_Hanghoa_Ban_Add();
        object identity;
        object id_menu;
        DataSet ds_Hanghoa_Ban = new DataSet();
        DataSet ds_Donvitinh = new DataSet();
        DataSet ds_Hanghoa_Dinhgia = new DataSet();
        DataSet ds_Hanghoa_In_Menu = new DataSet();
        DataSet dsNhom_Hanghoa_Ban;

        #region local data
        DataSet dsSys_Lognotify = null;

        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_WARE_DM_NHOM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Nhom_Hanghoa_Ban.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";
        string xml_BAR_DM_MENU = @"Resources\localdata\BAR_DM_MENU.xml";
        string xml_WARE_HANGHOA_DINHGIA = @"Resources\localdata\WARE_HANGHOA_DINHGIA.xml"; //WARE_HANGHOA_DINHGIA

        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_ware_hanghoa_dinhgia;
        DateTime dtlc_bar_dm_menu;
        DateTime dtlc_bar_dm_menu_hanghoa_ban;
        DateTime dtlc_ware_dm_donvitinh;
        DateTime dtlc_ware_dm_nhom_hanghoa_ban;
        #endregion

        public Frmbar_Dm_Menu_Hanghoa_Ban_Add()
        {
            InitializeComponent();

            //if (System.IO.Directory.Exists(@"Resources\localdata"))
            //    System.IO.Directory.Delete(@"Resources\localdata", true);
            this.DisplayInfo();
        }

        /// <summary>
        /// Truy xuat DateTime thay doi du lieu cuoi cung
        /// </summary>
        /// <param name="table_name"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        void LoadMasterData()
        {
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables(
                    "[ware_dm_hanghoa_ban], [ware_hanghoa_dinhgia], " +
                    "[bar_dm_menu], [ware_dm_donvitinh], [ware_dm_nhom_hanghoa_ban]").ToDataSet();

            dtlc_ware_dm_nhom_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_NHOM_HANGHOA_BAN");
            dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");
            dtlc_ware_dm_donvitinh = GetLastChange_FrmLognotify("WARE_DM_DONVITINH");
            dtlc_ware_hanghoa_dinhgia = GetLastChange_FrmLognotify("WARE_HANGHOA_DINHGIA");
            dtlc_bar_dm_menu = GetLastChange_FrmLognotify("BAR_DM_MENU");

            //load data from local xml when last change at local differ from database
            if (!System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN)
                || DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN)) > 0)
            {
                ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                ds_Hanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (ds_Hanghoa_Ban == null || ds_Hanghoa_Ban.Tables.Count == 0)
            {
                ds_Hanghoa_Ban = new DataSet();
                ds_Hanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN);
            }
            //ds_Donvitinh
            if (!System.IO.File.Exists(xml_WARE_DM_DONVITINH)
                || DateTime.Compare(dtlc_ware_dm_donvitinh, System.IO.File.GetLastWriteTime(xml_WARE_DM_DONVITINH)) > 0)
            {
                ds_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                ds_Donvitinh.WriteXml(xml_WARE_DM_DONVITINH, XmlWriteMode.WriteSchema);
            }
            else if (ds_Donvitinh == null || ds_Donvitinh.Tables.Count == 0)
            {
                ds_Donvitinh = new DataSet();
                ds_Donvitinh.ReadXml(xml_WARE_DM_DONVITINH);
            }
            //dsBar_Dm_Menu
            //if (!System.IO.File.Exists(xml_BAR_DM_MENU)
            //   || DateTime.Compare(dtlc_bar_dm_menu, System.IO.File.GetLastWriteTime(xml_BAR_DM_MENU)) > 0)
            //{
            //    dsBar_Dm_Menu = objMasterService.Get_All_Bar_Dm_Menu();
            //    dsBar_Dm_Menu.WriteXml(xml_BAR_DM_MENU, XmlWriteMode.WriteSchema);
            //}
            //else if (dsBar_Dm_Menu == null || dsBar_Dm_Menu.Tables.Count == 0)
            //{
            //    dsBar_Dm_Menu = new DataSet();
            //    dsBar_Dm_Menu.ReadXml(xml_BAR_DM_MENU);
            //}
            //Ware_Dm_Nhom_Hanghoa_Ban
            if (!System.IO.File.Exists(xml_WARE_DM_NHOM_HANGHOA_BAN)
               || DateTime.Compare(dtlc_ware_dm_nhom_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_NHOM_HANGHOA_BAN)) > 0)
            {
                dsNhom_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Nhom_Hanghoa_Ban().ToDataSet();
                dsNhom_Hanghoa_Ban.WriteXml(xml_WARE_DM_NHOM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (dsNhom_Hanghoa_Ban == null || dsNhom_Hanghoa_Ban.Tables.Count == 0)
            {
                dsNhom_Hanghoa_Ban = new DataSet();
                dsNhom_Hanghoa_Ban.ReadXml(xml_WARE_DM_NHOM_HANGHOA_BAN);
            }
            //Get data Ware_Dm_Hanghoa_Ban
            //lookUpEdit_Hanghoa_Ban.Properties.DataSource = ds_Hanghoa_Ban.Tables[0];            
            gridLookUp_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUp_Donvitinh.DataSource = ds_Donvitinh.Tables[0];            
        }

        void Load_Ds_Hanghoa_Dinhgia()
        {
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
        }

        public override void DisplayInfo()
        {
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

                //gridLookUpEditNhom_Hanghoa_Ban
                //lookUp_Nhom_Hanghoa_Ban.Properties.DataSource = dsNhom_Hanghoa_Ban.Tables[0];
                gridLookUp_Nhom_Hanghoa_Ban.DataSource = dsNhom_Hanghoa_Ban.Tables[0];

                this.ChangeStatus(false);
                if (gridView2.RowCount > 0)
                    DisplayInfo2();
                this.gridView2.BestFitColumns();
                //this.DataBindingControl();                
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                ////Ecm.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void  ClearDataBindings()
        {
            //this.txtId_Menu.DataBindings.Clear();
            //this.txtMa_Menu.DataBindings.Clear();
            //this.txtTen_Menu.DataBindings.Clear();
            //this.lookUp_Nhom_Hanghoa_Ban.DataBindings.Clear();
            //this.txtGhichu.DataBindings.Clear();
            //this.chkVisible.DataBindings.Clear();
        }
        public override void  DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                //this.txtId_Menu.DataBindings.Add("EditValue", dsBar_Dm_Menu, dsBar_Dm_Menu.Tables[0].TableName + ".Id_Menu");
                //this.txtMa_Menu.DataBindings.Add("EditValue", dsBar_Dm_Menu, dsBar_Dm_Menu.Tables[0].TableName + ".Ma_Menu");
                //this.txtTen_Menu.DataBindings.Add("EditValue", dsBar_Dm_Menu, dsBar_Dm_Menu.Tables[0].TableName + ".Ten_Menu");
                //this.lookUp_Nhom_Hanghoa_Ban.DataBindings.Add("EditValue", dsBar_Dm_Menu, dsBar_Dm_Menu.Tables[0].TableName + ".Id_Nhom_Hanghoa_Ban");
                //this.txtGhichu.DataBindings.Add("EditValue", dsBar_Dm_Menu, dsBar_Dm_Menu.Tables[0].TableName + ".Ghichu");
                //this.chkVisible.DataBindings.Add("EditValue", dsBar_Dm_Menu, dsBar_Dm_Menu.Tables[0].TableName + ".Visible");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                ////Ecm.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void  ChangeStatus(bool editTable)
        {
            //this.dgbar_Dm_Menu.Enabled = !editTable;
            this.gridView1.OptionsBehavior.Editable = editTable;
            this.gridView2.OptionsBehavior.Editable = editTable;
            this.btnMenu.Enabled = !editTable;
            //this.lookUp_Nhom_Hanghoa_Ban.Properties.ReadOnly = !editTable;
            //this.txtMa_Menu.Properties.ReadOnly = !editTable;
            //this.txtTen_Menu.Properties.ReadOnly = !editTable;
            //this.txtGhichu.Properties.ReadOnly = !editTable;
            //this.chkVisible.Properties.ReadOnly = !editTable;
        }

        void changeStatusButtonMenu(bool editTable)
        {
            this.item_Add.Enabled = !editTable;
            this.item_Close.Enabled = !editTable;
            this.item_Delete.Enabled = !editTable;
            this.item_Edit.Enabled = !editTable;
            this.item_Refresh.Enabled = !editTable;
            this.item_Save.Enabled = editTable;
            this.item_Cancel.Enabled = editTable;
        }


        public override void ResetText()
        {
            ds_Menu_Hanghoa_Ban = objMasterService.Get_All_Bar_Dm_Menu_Hanghoa_Ban().ToDataSet();
            dgbar_Dm_Menu_Hanghoa_Ban.DataSource = ds_Menu_Hanghoa_Ban;
            dgbar_Dm_Menu_Hanghoa_Ban.DataMember = ds_Menu_Hanghoa_Ban.Tables[0].TableName;
        }

        #region Event Override
        public object InsertObject()
        {            
            Ecm.WebReferences.MasterService.Bar_Dm_Menu objBar_Dm_Menu = new Ecm.WebReferences.MasterService.Bar_Dm_Menu();
            // objBar_Dm_Menu.Id_Menu = -1;
            //objBar_Dm_Menu.Ma_Menu = txtMa_Menu.EditValue;
            //objBar_Dm_Menu.Ten_Menu = txtTen_Menu.EditValue;
            //objBar_Dm_Menu.Ghichu = txtGhichu.EditValue;
            //objBar_Dm_Menu.Id_Nhom_Hanghoa_Ban = lookUp_Nhom_Hanghoa_Ban.EditValue;
            //if (chkVisible.EditValue == null)
            //    chkVisible.EditValue = false;
            //objBar_Dm_Menu.Visible = chkVisible.EditValue;
            identity = objMasterService.Insert_Bar_Dm_Menu(objBar_Dm_Menu);
            dgbar_Dm_Menu_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgbar_Dm_Menu_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
            if (identity != null)
                foreach (DataRow dr in ds_Menu_Hanghoa_Ban.Tables[0].Rows)
                    dr["Id_Menu"] = identity;
            //Ecm.WebReferences.MasterService.Bar_Dm_Menu_Hanghoa_Ban objBar_Dm_Menu_Hanghoa_Ban = new Ecm.WebReferences.MasterService.Bar_Dm_Menu_Hanghoa_Ban();
            // objBar_Dm_Menu_Hanghoa_Ban.Id_Menu_Hanghoa_Ban           = -1;
            //objBar_Dm_Menu_Hanghoa_Ban.Dongia           = txtDongia.EditValue;
            //objBar_Dm_Menu_Hanghoa_Ban.Ghichu           = txtGhichu.EditValue;

            //if("" + lookUpEdit_Menu.EditValue != "")
            //    objBar_Dm_Menu_Hanghoa_Ban.Id_Menu          = lookUpEdit_Menu.EditValue;
            //if ("" + lookUpEdit_Hanghoa_Ban.EditValue != "")
            //    objBar_Dm_Menu_Hanghoa_Ban.Id_Hanghoa_Ban   = lookUpEdit_Hanghoa_Ban.EditValue;
            return objMasterService.Update_Bar_Dm_Menu_Hanghoa_Ban_Collection(ds_Menu_Hanghoa_Ban);
        }

        public object UpdateObject()
        {
            //bool saved = false;
            //Ecm.WebReferences.MasterService.Bar_Dm_Menu objBar_Dm_Menu = new Ecm.WebReferences.MasterService.Bar_Dm_Menu();
            //objBar_Dm_Menu.Id_Menu = gridView2.GetFocusedRowCellValue("Id_Menu");
            //objBar_Dm_Menu.Ma_Menu = txtMa_Menu.EditValue;
            //objBar_Dm_Menu.Ten_Menu = txtTen_Menu.EditValue;

            //if ("" + txtGhichu.EditValue != "")
            //    objBar_Dm_Menu.Ghichu = txtGhichu.EditValue;
            //else
            //    objBar_Dm_Menu.Ghichu = null;

            //objBar_Dm_Menu.Id_Nhom_Hanghoa_Ban = lookUp_Nhom_Hanghoa_Ban.EditValue;
            //if (chkVisible.EditValue == null)
            //    chkVisible.EditValue = false;
            //objBar_Dm_Menu.Visible = chkVisible.EditValue;
            //objMasterService.Update_Bar_Dm_Menu(objBar_Dm_Menu);

            dgbar_Dm_Menu_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgbar_Dm_Menu_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
            dgbar_Dm_Menu.EmbeddedNavigator.Buttons.DoClick(dgbar_Dm_Menu.EmbeddedNavigator.Buttons.EndEdit);
            DataRow row = null;
            if (ds_Menu_Hanghoa_Ban.HasChanges())
            {
                for (int i = ds_Menu_Hanghoa_Ban.Tables[0].Rows.Count - 1; i >= 0; i--)
                {
                    row = ds_Menu_Hanghoa_Ban.Tables[0].Rows[i];
                    if (row.RowState == DataRowState.Added)
                        row["Id_Menu"] = gridView2.GetFocusedRowCellValue("Id_Menu");
                    if (row.RowState == DataRowState.Deleted)
                        ds_Menu_Hanghoa_Ban.Tables[0].Rows[i].Delete();
                }
                //foreach (DataRow dr in ds_Menu_Hanghoa_Ban.Tables[0].Rows)
                //{
                //    try
                //    {
                //        if (dr.RowState == DataRowState.Added)
                //            dr["Id_Menu"] = gridView2.GetFocusedRowCellValue("Id_Menu");
                //        if (dr.RowState == DataRowState.Deleted)
                //            ds_Menu_Hanghoa_Ban.Tables[0].Rows.Remove(dr);
                //    }
                //    catch (Exception ex) {
                //        continue;
                //    }
                //}
                //ds_Menu_Hanghoa_Ban.Tables[0].AcceptChanges();

                objMasterService.Update_Bar_Dm_Menu_Hanghoa_Ban_Collection(ds_Menu_Hanghoa_Ban);
                ds_Menu_Hanghoa_Ban.AcceptChanges();
                //saved = true;
            }
            objMasterService.Update_Bar_Dm_Menu_Collection(dsBar_Dm_Menu);
            dsBar_Dm_Menu.AcceptChanges();

            //Ecm.WebReferences.MasterService.Bar_Dm_Menu_Hanghoa_Ban objBar_Dm_Menu_Hanghoa_Ban = new Ecm.WebReferences.MasterService.Bar_Dm_Menu_Hanghoa_Ban();
            //objBar_Dm_Menu_Hanghoa_Ban.Id_Menu_Hanghoa_Ban = gridView1.GetFocusedRowCellValue("Id_Menu_Hanghoa_Ban");
            //objBar_Dm_Menu_Hanghoa_Ban.Dongia               = txtDongia.EditValue;
            //objBar_Dm_Menu_Hanghoa_Ban.Ghichu               = txtGhichu.EditValue;
            //if ("" + lookUpEdit_Menu.EditValue != "")
            //    objBar_Dm_Menu_Hanghoa_Ban.Id_Menu          = lookUpEdit_Menu.EditValue;
            //if ("" + lookUpEdit_Hanghoa_Ban.EditValue != "")
            //    objBar_Dm_Menu_Hanghoa_Ban.Id_Hanghoa_Ban   = lookUpEdit_Hanghoa_Ban.EditValue;

            //if (System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN))
            //{
            //    try
            //    {
            //        System.IO.File.Delete(xml_WARE_DM_HANGHOA_BAN);
            //    }
            //    catch (Exception ex)
            //    {
            //         GoobizFrame.Windows.Forms.MessageDialog.Show(ex.ToString());
            //    }
            //}

            //if (System.IO.File.Exists(xml_BAR_DM_MENU))
            //{
            //    try
            //    {
            //        System.IO.File.Delete(xml_BAR_DM_MENU);
            //    }
            //    catch (Exception ex)
            //    {
            //         GoobizFrame.Windows.Forms.MessageDialog.Show(ex.ToString());
            //    }
            //}
            return true;
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Bar_Dm_Menu objBar_Dm_Menu = new Ecm.WebReferences.MasterService.Bar_Dm_Menu();
            //objBar_Dm_Menu_Hanghoa_Ban.Id_Menu_Hanghoa_Ban = gridView1.GetFocusedRowCellValue("Id_Menu_Hanghoa_Ban");
            objBar_Dm_Menu.Id_Menu = gridView2.GetFocusedRowCellValue("Id_Menu");
            return objMasterService.Delete_Bar_Dm_Menu(objBar_Dm_Menu);
        }

        public override bool PerformAdd()
        {
            identity = null;
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            Load_Ds_Hanghoa_Dinhgia();
            return true;
        }

        public override bool PerformEdit()
        {
            if("" + id_menu != "")
            {
                this.ChangeStatus(true);
                Load_Ds_Hanghoa_Dinhgia();
                
                return true;
            }
            return false;
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
                // GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                //hashtableControls.Add(lookUp_Nhom_Hanghoa_Ban, lookUp_Nhom_Hanghoa_Ban.Text);
                //hashtableControls.Add(txtMa_Menu, lblMa_Menu.Text);
                //hashtableControls.Add(txtTen_Menu, lblTen_Menu.Text);

                //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                //    return false;

                //System.Collections.Hashtable htbMa_Menu = new System.Collections.Hashtable();
                //htbMa_Menu.Add(txtMa_Menu, lblMa_Menu.Text);

                //System.Collections.Hashtable htbTen_Menu = new System.Collections.Hashtable();
                //htbTen_Menu.Add(txtTen_Menu, lblTen_Menu.Text);
                dgbar_Dm_Menu_Hanghoa_Ban.EmbeddedNavigator.Buttons.DoClick(dgbar_Dm_Menu_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit);
                if (FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                    if (gridView1.RowCount == 0)
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Danh sách hàng hóa không thể rỗng");
                        return false;
                    }
                try
                {
                    Constraint constraint = new UniqueConstraint("constraint1",
                            new DataColumn[] {ds_Menu_Hanghoa_Ban.Tables[0].Columns["Id_Hanghoa_Ban"],
                                  ds_Menu_Hanghoa_Ban.Tables[0].Columns["Id_Donvitinh"] }, false);
                    ds_Menu_Hanghoa_Ban.Tables[0].Constraints.Clear();
                    ds_Menu_Hanghoa_Ban.Tables[0].Constraints.Add(constraint);
                }
                catch (Exception ex)
                {
                    if (ex.ToString().IndexOf("These columns don't currently have unique values") != -1)
                    {
                         GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa đã được thêm vào menu, vui lòng kiểm tra lại");
                        return false;
                    }
                     
                }
                //for (int i = 0; i < gridView1.RowCount; i++)
                //{
                //    if ("" + gridView1.GetRowCellValue(i, gridView1.Columns["Id_Donvitinh"]) != "")
                //    {
                //        dtr = ds_Hanghoa_In_Menu.Tables[0].Select("Id_Hanghoa_Ban = " + gridView1.GetRowCellValue(i, gridView1.Columns["Id_Hanghoa_Ban"])
                //                                                   + "and Id_Donvitinh = " + gridView1.GetRowCellValue(i, gridView1.Columns["Id_Donvitinh"]));
                //        if (gridView1.GetDataRow(i).RowState == DataRowState.Added)
                //            if (dtr.Length >= 1)
                //            {
                //                 GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa đã được thêm vào menu");
                //                gridView1.FocusedRowHandle = i;
                //                return false;
                //            }
                //        if (gridView1.GetDataRow(i).RowState == DataRowState.Modified)
                //        {
                //            if (dtr.Length > 0 && !gridView1.GetRowCellValue(i, gridView1.Columns["Id_Menu_Hanghoa_Ban"]).Equals(dtr[0]["Id_Menu_Hanghoa_Ban"]))
                //                if (dtr.Length >= 1)
                //                {
                //                     GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa đã được thêm vào menu");
                //                    gridView1.FocusedRowHandle = i;
                //                    return false;
                //                }
                //        }
                //    }
                //    else
                //    {
                //         GoobizFrame.Windows.Forms.MessageDialog.Show("Đơn vị tính không được rỗng, nhập lại đơn vị tính");
                //        gridView1.FocusedRowHandle = i;
                //        return false;
                //    }
                //}

                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbMa_Menu, dsBar_Dm_Menu, "Ma_Menu"))
                    //    return false;
                    //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbTen_Menu, dsBar_Dm_Menu, "Ten_Menu"))
                    //    return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    //dsBar_Dm_Menu =  GoobizFrame.Windows.MdiUtils.Validator.datasetFillter(dsBar_Dm_Menu, "id_menu = " + gridView2.GetFocusedRowCellValue("Id_Menu"));
                    //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbMa_Menu, dsBar_Dm_Menu, "Ma_Menu"))
                    //    return false;
                    success = (bool)this.UpdateObject();
                }

                if (success)
                {
                    this.DisplayInfo();
                }
                return success;
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("exists") != -1)
                {
                    // GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblId_Hanghoa_Ban.Text, lblId_Hanghoa_Ban.Text });
                }
                //MessageBox.Show(ex.ToString());
                return false;
            }
        }
        public override bool PerformSaveChanges()
        {
            this.PerformSave();
            return base.PerformSaveChanges();
        }

        #region code not use
        //public override bool PerformSaveChanges()
        //{
        // GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
        ////hashtableControls.Add(gridView1.Columns["Dongia"], "");
        //hashtableControls.Add(gridView1.Columns["Id_Menu"], "");
        //hashtableControls.Add(gridView1.Columns["Id_Hanghoa_Ban"], "");

        //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
        //    return false;

        //try
        //{
        //    dgbar_Dm_Menu_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        //    //ds_Menu_Hanghoa_Ban.Tables[0].Columns["Id_Menu"].Unique = true;
        //    //ds_Menu_Hanghoa_Ban.Tables[0].Columns["Id_Hanghoa_Ban"].Unique = true;
        //    objMasterService.Update_Bar_Dm_Menu_Hanghoa_Ban_Collection(this.ds_Menu_Hanghoa_Ban);
        //}
        //catch (Exception ex)
        //{

        //    if (ex.ToString().IndexOf("Unique") != -1 && ex.ToString().IndexOf("Id_Menu") != -1)
        //    {
        //        // GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblId_Menu.Text, lblId_Menu.Text });
        //        return false;
        //    }
        //    else if (ex.ToString().IndexOf("Unique") != -1 && ex.ToString().IndexOf("Id_Hanghoa_Ban") != -1)
        //    {
        //        // GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblId_Hanghoa_Ban.Text, lblId_Hanghoa_Ban.Text });
        //        return false;
        //    }
        //    MessageBox.Show(ex.ToString());
        //}
        //this.DisplayInfo();
        //    return true;
        //}


        //private void gridLookUpEdit_Menu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{
        //    if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
        //    {
        //        Frmbar_Dm_Menu_Add objFrmbar_Dm_Menu_Add = new Frmbar_Dm_Menu_Add();
        //        objFrmbar_Dm_Menu_Add.Text = "Menu";
        //         GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(objFrmbar_Dm_Menu_Add);
        //        objFrmbar_Dm_Menu_Add.ShowDialog();
        //        objFrmbar_Dm_Menu_Add.Text = gridView1.Columns["Id_Menu"].Caption;
        //        if (objFrmbar_Dm_Menu_Add.SelectedBar_Dm_Menu != null
        //            && "" + objFrmbar_Dm_Menu_Add.SelectedBar_Dm_Menu.Id_Menu != "")
        //        {
        //            gridLookUpEdit_Menu.DataSource = objFrmbar_Dm_Menu_Add.Data.Tables[0];
        //            //lookUpEdit_Menu.Properties.DataSource = objFrmbar_Dm_Menu_Add.Data.Tables[0];
        //            gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Menu"], objFrmbar_Dm_Menu_Add.SelectedBar_Dm_Menu.Id_Menu);
        //        }
        //    }
        //}

        //private void btnMenu_Click(object sender, EventArgs e)
        //{

        //    if (frmbar_Dm_Menu_Add.IsDisposed || frmbar_Dm_Menu_Add == null)
        //        frmbar_Dm_Menu_Add = new Frmbar_Dm_Menu_Add();
        //     GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmbar_Dm_Menu_Add);
        //     GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(frmbar_Dm_Menu_Add);


        //    frmbar_Dm_Menu_Add.Show();
        //}

        #endregion

        private void dgbar_Dm_Menu_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            {
                if (gridView1.GetFocusedRowCellValue("Id_Menu_Hanghoa_Ban").ToString() != "")
                    if (Convert.ToInt32(objMasterService.GetExistReferences("Bar_Dm_Menu_Hanghoa_Ban", "Id_Menu_Hanghoa_Ban", this.gridView1.GetFocusedRowCellValue("Id_Menu_Hanghoa_Ban"))) > 0)
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                        e.Handled = true;
                    }
                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.View)
                    this.FormState =  GoobizFrame.Windows.Forms.FormState.Edit;
                changeStatusButtonMenu(true);
            }
            if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Append)
            {
                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.View)
                    this.FormState =  GoobizFrame.Windows.Forms.FormState.Edit;
                gridView1.OptionsBehavior.Editable = true;
                changeStatusButtonMenu(true);
            }
        }


        public override bool PerformDelete()
        {
            if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Bar_Dm_Menu_Hanghoa_Ban"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Bar_Dm_Menu_Hanghoa_Ban")   }) == DialogResult.Yes)
            {
                try
                {
                    //if (Convert.ToInt32(objMasterService.GetExistReferences("Bar_Dm_Menu_Hanghoa_Ban", "Id_Menu_Hanghoa_Ban", this.gridView1.GetFocusedRowCellValue("Id_Menu_Hanghoa_Ban"))) > 0)
                    //{
                    //     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    //    return true;
                    //}
                    this.DeleteObject();
                }
                catch (Exception ex)
                {
                     GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    // GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                }
                this.DisplayInfo();
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Bar_Dm_Menu_Hanghoa_Ban bar_Dm_Menu_Hanghoa_Ban = new Ecm.WebReferences.MasterService.Bar_Dm_Menu_Hanghoa_Ban();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Menu_Hanghoa_Ban.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    bar_Dm_Menu_Hanghoa_Ban.Id_Menu_Hanghoa_Ban = dr["Id_Table"];
                    bar_Dm_Menu_Hanghoa_Ban.Dongia = dr["Dongia"];
                    bar_Dm_Menu_Hanghoa_Ban.Ghichu = dr["Ghichu"];
                    bar_Dm_Menu_Hanghoa_Ban.Id_Menu = dr["Id_Menu"];
                    bar_Dm_Menu_Hanghoa_Ban.Id_Hanghoa_Ban = dr["Id_Hanghoa_Ban"];
                }
                this.Dispose();
                this.Close();
                return bar_Dm_Menu_Hanghoa_Ban;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }
        #endregion

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DataRow[] dtr = null;
            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                object id_hanghoa_ban = ((System.Data.DataRowView)gridLookUp_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Id_Hanghoa_Ban"];
                dtr = ds_Hanghoa_Dinhgia.Tables[0].Select("Id_Hanghoa_Ban = " + id_hanghoa_ban);
                if (dtr.Length > 0)
                {
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Ma_Hanghoa_Ban"], dtr[0]["Ma_Hanghoa_Ban"]);
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Dongia"], dtr[0]["Dongia_Ban"]);
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Donvitinh"], dtr[0]["Id_Donvitinh"]);
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Hanghoa_Dinhgia"], dtr[0]["Id_Hanghoa_Dinhgia"]);
                }
                else
                {
                    DataRow[] dtr2 = ds_Hanghoa_Ban.Tables[0].Select("Id_Hanghoa_Ban = " + id_hanghoa_ban);
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Ma_Hanghoa_Ban"], dtr2[0]["Ma_Hanghoa_Ban"]);
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Dongia"], null);
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Donvitinh"], dtr2[0]["Id_Donvitinh"]);
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Hanghoa_Dinhgia"], null);
                }
            }

            if (e.Column.FieldName == "Id_Donvitinh")
            {
                if ("" + gridView1.GetFocusedRowCellValue("Id_Donvitinh") != "")
                {
                    dtr = ds_Hanghoa_Dinhgia.Tables[0].Select("Id_Hanghoa_Ban = " + gridView1.GetFocusedRowCellValue("Id_Hanghoa_Ban")
                                                                + "and Id_Donvitinh = " + gridView1.GetFocusedRowCellValue("Id_Donvitinh"));
                    if (dtr.Length > 0)
                    {
                        gridView1.SetFocusedRowCellValue(gridView1.Columns["Dongia"], dtr[0]["Dongia_Ban"]);
                        //gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Donvitinh"], dtr[0]["Id_Donvitinh"]);
                        gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Hanghoa_Dinhgia"], dtr[0]["Id_Hanghoa_Dinhgia"]);
                    }
                    else
                        gridView1.SetFocusedRowCellValue(gridView1.Columns["Dongia"], null);
                }
            }
            //this.dgbar_Dm_Menu_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit.DoClick();
            gridView1.BestFitColumns();
        }

        private void gridLookUpEdit_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog frmware_Dm_Hanghoa_Ban_Dialog = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog();
                frmware_Dm_Hanghoa_Ban_Dialog.Text = "Hàng hóa";
                if (gridView2.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban") != null)
                    frmware_Dm_Hanghoa_Ban_Dialog.Id_Loai_Hanghoa = gridView2.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban");

                 GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Ban_Dialog);
                frmware_Dm_Hanghoa_Ban_Dialog.DisplayInfo();
                frmware_Dm_Hanghoa_Ban_Dialog.ShowDialog();

                if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows != null
                    && frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 0)
                {
                    //gridLookUpEdit_Hanghoa_Ban.DataSource = frmware_Dm_Hanghoa_Ban_Dialog.Data.Tables[0];
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Hanghoa_Ban"]
                        , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Hanghoa_Ban"]);
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Menu"]
                        , gridView2.GetFocusedRowCellValue("Id_Menu"));
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Donvitinh"]
                        , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Donvitinh"]);
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Ma_Hanghoa_Ban"]
                        , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Ma_Hanghoa_Ban"]);
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Dongia"]
                        , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Dongia_Ban"]);

                    //object Id_Cuahang_Ban = gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban");
                    if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 1)
                    {
                        DataRow[] dtr = null;
                        for (int i = 1; i < frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length; i++)
                        {
                            DataRow nrow = ds_Menu_Hanghoa_Ban.Tables[0].NewRow();
                            nrow["Id_Hanghoa_Ban"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Hanghoa_Ban"];
                            nrow["Id_Menu"] = gridView2.GetFocusedRowCellValue("Id_Menu");
                            nrow["Id_Donvitinh"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Donvitinh"];
                            nrow["Ma_Hanghoa_Ban"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Ma_Hanghoa_Ban"];
                            dtr = ds_Hanghoa_Dinhgia.Tables[0].Select("Id_Hanghoa_Ban = " + frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Hanghoa_Ban"]);
                            if (dtr.Length > 0)
                            {
                                nrow["Dongia"] = dtr[0]["Dongia_Ban"];
                                nrow["Id_Hanghoa_Dinhgia"] = dtr[0]["Id_Hanghoa_Dinhgia"];
                            }
                            else
                            {
                                nrow["Dongia"] = DBNull.Value;
                            }
                            ds_Menu_Hanghoa_Ban.Tables[0].Rows.Add(nrow);
                        }
                    }
                    gridView1.BestFitColumns();
                }
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DisplayInfo2();
            //gridView1.Columns["Id_Menu"].FilterInfo = new DevExpress.XtraGrid.Columns.ColumnFilterInfo(
            //    gridView2.GetFocusedRowCellValue("Id_Menu"));
        }

        public void DisplayInfo2()
        {
            id_menu = gridView2.GetFocusedRowCellValue("Id_Menu");
            ds_Menu_Hanghoa_Ban = objMasterService.Get_All_Bar_Dm_Menu_Hanghoa_Ban_By_Id_Menu(gridView2.GetFocusedRowCellValue("Id_Menu"),null).ToDataSet();
            dgbar_Dm_Menu_Hanghoa_Ban.DataSource = ds_Menu_Hanghoa_Ban;
            dgbar_Dm_Menu_Hanghoa_Ban.DataMember = ds_Menu_Hanghoa_Ban.Tables[0].TableName;
            this.gridView1.BestFitColumns();
            this.Data = ds_Menu_Hanghoa_Ban;
            this.GridControl = dgbar_Dm_Menu_Hanghoa_Ban;
            gridView2.RefreshData();
            //if (gridView2.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban") != null)
            //{
            //    DataTable dataTable = new DataTable();
            //    dataTable.Columns.Add("Id_Hanghoa_Ban");
            //    dataTable.Columns.Add("Ma_Hanghoa_Ban");
            //    dataTable.Columns.Add("Ten_Hanghoa_Ban");
            //    dataTable.Columns.Add("Dongia");
            //    dataTable.Columns.Add("Id_Dongvitinh");
            //    foreach(DataRow dr in ds_Hanghoa_Ban.Tables[0].Select("Id_Nhom_Hanghoa_Ban = " + gridView2.GetFocusedRowCellValue("Id_Nhom_Hanghoa_Ban")) )
            //    {
            //        dataTable.ImportRow(dr);
            //    }
            //    gridLookUp_Hanghoa_Ban.DataSource = dataTable;                
            //}
        }

        private void btnHanghoa_Ban_Click(object sender, EventArgs e)
        {
            if (frmware_Dm_Nhom_Hanghoa_Ban_Add.IsDisposed || frmware_Dm_Nhom_Hanghoa_Ban_Add == null)
                frmware_Dm_Nhom_Hanghoa_Ban_Add = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Nhom_Hanghoa_Ban_Add();
             GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Nhom_Hanghoa_Ban_Add);
             GoobizFrame.Windows.PlugIn.RightHelpers.CheckUserRightAction(frmware_Dm_Nhom_Hanghoa_Ban_Add);
            frmware_Dm_Nhom_Hanghoa_Ban_Add.Show();
        }

        private void gridLookUp_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add frm_Donvitinh = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add();
                if (gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Hanghoa_Ban"]).ToString() == "")
                    return;
                frm_Donvitinh.setId_Hanghoa_Ban(gridView1.GetFocusedRowCellValue(gridView1.Columns["Id_Hanghoa_Ban"]));
                frm_Donvitinh.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                frm_Donvitinh.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                frm_Donvitinh.ShowDialog();
                if (frm_Donvitinh.SelecteWare_Dm_Donvitinh != null)
                    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Donvitinh"], frm_Donvitinh.SelecteWare_Dm_Donvitinh.Id_Donvitinh);
                gridView1.BestFitColumns();
            }
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            Ecm.MasterTables.Forms.Bar.Frmbar_Dm_Menu_Add frm_Menu = new Frmbar_Dm_Menu_Add();
            frm_Menu.ShowDialog();
            this.DisplayInfo();
        }
    }
}