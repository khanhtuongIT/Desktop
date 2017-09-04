using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GoobizFrame.Windows.Forms;

namespace Ecm.MasterTables.Forms.Ware
{
    public partial class Frmware_Dm_Congthuc_Phache_Chitiet_Add :  GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Congthuc_Phache_Chitiet = new DataSet();
        object Id_Congthuc_Phache;
        DataSet dsWare_Dm_Donvitinh;
        DataSet dsNhom_Hanghoa_Ban;
        DataSet dsLoai_Hanghoa_Ban;
        DataSet ds_Congthuc_Phache;
        DataSet dsHanghoa_Ban;

        #region local data
        DataSet dsSys_Lognotify = null;
        string xml_WARE_DM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Hanghoa_Ban.xml";
        string xml_WARE_DM_LOAI_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Loai_Hanghoa_Ban.xml";
        string xml_WARE_DM_DONVITINH = @"Resources\localdata\Ware_Dm_Donvitinh.xml";
        string xml_WARE_DM_NHOM_HANGHOA_BAN = @"Resources\localdata\Ware_Dm_Nhom_Hanghoa_Ban.xml";

        DateTime dtlc_ware_dm_hanghoa_ban;
        DateTime dtlc_ware_dm_loai_hanghoa;
        DateTime dtlc_ware_dm_nhom_hanghoa_ban; 
        DateTime dtlc_ware_dm_donvitinh; 
        #endregion

        #region Initialize

        public Frmware_Dm_Congthuc_Phache_Chitiet_Add()
        {
            InitializeComponent();
            this.item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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

        void LoadMasterData()
        {
            dsSys_Lognotify = objMasterService.Get_Sys_Lognotify_SelectLastChange_OfTables(
                    "[ware_dm_hanghoa_ban], [ware_dm_loai_hanghoa_ban] ," +
                    " [ware_dm_donvitinh], [ware_dm_nhom_hanghoa_ban]").ToDataSet();

            dtlc_ware_dm_nhom_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_NHOM_HANGHOA_BAN");
            dtlc_ware_dm_hanghoa_ban = GetLastChange_FrmLognotify("WARE_DM_HANGHOA_BAN");
            dtlc_ware_dm_donvitinh = GetLastChange_FrmLognotify("WARE_DM_DONVITINH");
            dtlc_ware_dm_loai_hanghoa = GetLastChange_FrmLognotify("ware_dm_loai_hanghoa_ban");

            //load data from local xml when last change at local differ from database
            if (!System.IO.File.Exists(xml_WARE_DM_HANGHOA_BAN)
                || DateTime.Compare(dtlc_ware_dm_hanghoa_ban, System.IO.File.GetLastWriteTime(xml_WARE_DM_HANGHOA_BAN)) > 0)
            {
                dsHanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
                dsHanghoa_Ban.WriteXml(xml_WARE_DM_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (dsHanghoa_Ban == null || dsHanghoa_Ban.Tables.Count == 0)
            {
                dsHanghoa_Ban = new DataSet();
                dsHanghoa_Ban.ReadXml(xml_WARE_DM_HANGHOA_BAN);
            }
            //ds_Donvitinh
            if (!System.IO.File.Exists(xml_WARE_DM_DONVITINH)
                || DateTime.Compare(dtlc_ware_dm_donvitinh, System.IO.File.GetLastWriteTime(xml_WARE_DM_DONVITINH)) > 0)
            {
                dsWare_Dm_Donvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();
                dsWare_Dm_Donvitinh.WriteXml(xml_WARE_DM_DONVITINH, XmlWriteMode.WriteSchema);
            }
            else if (dsWare_Dm_Donvitinh == null || dsWare_Dm_Donvitinh.Tables.Count == 0)
            {
                dsWare_Dm_Donvitinh = new DataSet();
                dsWare_Dm_Donvitinh.ReadXml(xml_WARE_DM_DONVITINH);
            }
            if (!System.IO.File.Exists(xml_WARE_DM_LOAI_HANGHOA_BAN)
               || DateTime.Compare(dtlc_ware_dm_loai_hanghoa, System.IO.File.GetLastWriteTime(xml_WARE_DM_LOAI_HANGHOA_BAN)) > 0)
            {
                dsLoai_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Loai_Hanghoa_Ban().ToDataSet();
                dsLoai_Hanghoa_Ban.WriteXml(xml_WARE_DM_LOAI_HANGHOA_BAN, XmlWriteMode.WriteSchema);
            }
            else if (dsLoai_Hanghoa_Ban == null || dsLoai_Hanghoa_Ban.Tables.Count == 0)
            {
                dsLoai_Hanghoa_Ban = new DataSet();
                dsLoai_Hanghoa_Ban.ReadXml(xml_WARE_DM_LOAI_HANGHOA_BAN);
            }
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
            lookUp_Donvitinh.Properties.DataSource = dsWare_Dm_Donvitinh.Tables[0];
            gridLookUp_Donvitinh.DataSource = dsWare_Dm_Donvitinh.Tables[0];
            gridLookUp_Donvitinh_Congthuc_Phache.DataSource = dsWare_Dm_Donvitinh.Tables[0];

            gridLookUpEdit_Nhom_Hanghoa_Ban.DataSource = dsNhom_Hanghoa_Ban.Tables[0];
            gridLookUp_Nhom_Hanghoa_Ban.DataSource = dsNhom_Hanghoa_Ban.Tables[0];

            gridLookUpEdit_Loai_Hanghoa_Ban.DataSource = dsLoai_Hanghoa_Ban.Tables[0];
            gridLookUp_Loai_Hanghoa_Ban.DataSource = dsLoai_Hanghoa_Ban.Tables[0];

            lookUp_Hanghoa_Ban.Properties.DataSource = dsHanghoa_Ban.Tables[0];
            lookUpMa_Hanghoa_Ban.Properties.DataSource = dsHanghoa_Ban.Tables[0];
            gridLookUp_Hanghoa_Ban.DataSource = dsHanghoa_Ban.Tables[0];
        }
        #endregion

        #region Event Override


        public override void DisplayInfo()
        {
            try
            {
                LoadMasterData();

                DataSet dsWare_Dm_Hanghoa = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Nguyenlieu_Chebien().ToDataSet();
                gridLookUp_Hanghoa_Mua.DataSource = dsWare_Dm_Hanghoa.Tables[0];
                gridLookUpEditMa_Hanghoa_Ban.DataSource = dsWare_Dm_Hanghoa.Tables[0];
                //Get data Ware_Dm_Congthuc_Phache
                ds_Congthuc_Phache = objMasterService.Get_All_Ware_Dm_Congthuc_Phache().ToDataSet();
                dgware_Dm_Congthuc_Phache.DataSource = ds_Congthuc_Phache;
                dgware_Dm_Congthuc_Phache.DataMember = ds_Congthuc_Phache.Tables[0].TableName;
                if (gridView2.RowCount > 0)
                {
                    gridView2.FocusedRowHandle = 0;
                    gridView2.Focus();
                    if (gridView2.IsDataRow(gridView2.FocusedRowHandle))
                        Id_Congthuc_Phache = gridView2.GetFocusedRowCellValue("Id_Congthuc_Phache");
                    else
                        Id_Congthuc_Phache = -1;

                    this.DisplayInfo2();
                }
                DataBindingControl();
                this.ChangeStatus(false);
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                // GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public void DisplayInfo2()
        {
            if ("" + Id_Congthuc_Phache == "") return;
            ds_Congthuc_Phache_Chitiet = objMasterService.Get_All_Ware_Dm_Congthuc_Phache_Chitiet_By_Id_CT_Phache(Id_Congthuc_Phache).ToDataSet();
            dgware_Dm_Congthuc_Phache_Chitiet.DataSource = null;
            dgware_Dm_Congthuc_Phache_Chitiet.DataSource = ds_Congthuc_Phache_Chitiet;
            dgware_Dm_Congthuc_Phache_Chitiet.DataMember = ds_Congthuc_Phache_Chitiet.Tables[0].TableName;
            this.gvware_Dm_Congthuc_Phache_Chitiet.BestFitColumns();
            //this.Data = ds_Congthuc_Phache_Chitiet;
            //this.GridControl = dgware_Dm_Congthuc_Phache_Chitiet;
        }

        public override void ClearDataBindings()
        {
            this.txtId_Congthuc_Phache.DataBindings.Clear();
            this.txtMa_Congthuc_Phache.DataBindings.Clear();
            this.txtTen_Congthuc_Phache.DataBindings.Clear();
            this.lookUp_Hanghoa_Ban.DataBindings.Clear();
            this.lookUpMa_Hanghoa_Ban.DataBindings.Clear();
            this.lookUp_Donvitinh.DataBindings.Clear();
            this.txtSoluong.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtId_Congthuc_Phache.DataBindings.Add("EditValue", ds_Congthuc_Phache, ds_Congthuc_Phache.Tables[0].TableName + ".Id_Congthuc_Phache");
                this.txtMa_Congthuc_Phache.DataBindings.Add("EditValue", ds_Congthuc_Phache, ds_Congthuc_Phache.Tables[0].TableName + ".Ma_Congthuc_Phache");
                this.txtTen_Congthuc_Phache.DataBindings.Add("EditValue", ds_Congthuc_Phache, ds_Congthuc_Phache.Tables[0].TableName + ".Ten_Congthuc_Phache");
                this.lookUp_Hanghoa_Ban.DataBindings.Add("EditValue", ds_Congthuc_Phache, ds_Congthuc_Phache.Tables[0].TableName + ".Id_Hanghoa_Ban");
                this.lookUpMa_Hanghoa_Ban.DataBindings.Add("EditValue", ds_Congthuc_Phache, ds_Congthuc_Phache.Tables[0].TableName + ".Id_Hanghoa_Ban");
                this.lookUp_Donvitinh.DataBindings.Add("EditValue", ds_Congthuc_Phache, ds_Congthuc_Phache.Tables[0].TableName + ".Id_Donvitinh");
                this.txtSoluong.DataBindings.Add("EditValue", ds_Congthuc_Phache, ds_Congthuc_Phache.Tables[0].TableName + ".Soluong");
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                // GoobizFrame.Windows.HelperClasses.ExceptionLogger.LogException1(ex);
            }
        }

        public override void ChangeStatus(bool editTable)
        {
            //this.dgware_Dm_Congthuc_Phache.Enabled = !editTable;
            gvware_Dm_Congthuc_Phache_Chitiet.OptionsBehavior.Editable = editTable;
            this.dgware_Dm_Congthuc_Phache_Chitiet.EmbeddedNavigator.Buttons.Append.Visible = editTable;
            this.dgware_Dm_Congthuc_Phache_Chitiet.EmbeddedNavigator.Buttons.Remove.Visible = editTable;
            this.dgware_Dm_Congthuc_Phache_Chitiet.EmbeddedNavigator.Buttons.Edit.Visible = editTable;
            this.dgware_Dm_Congthuc_Phache_Chitiet.EmbeddedNavigator.Buttons.EndEdit.Visible = editTable;
            this.dgware_Dm_Congthuc_Phache_Chitiet.EmbeddedNavigator.Buttons.CancelEdit.Visible = editTable;
            this.btCT_Dinhluong.Enabled = !editTable;
            this.btnCopy_Chitiet.Enabled = editTable;
            this.txtMa_Congthuc_Phache.Properties.ReadOnly = !editTable;
            this.txtTen_Congthuc_Phache.Properties.ReadOnly = !editTable;
            this.txtSoluong.Properties.ReadOnly = !editTable;
            this.lookUp_Hanghoa_Ban.Properties.ReadOnly = !editTable;
            this.lookUpMa_Hanghoa_Ban.Properties.ReadOnly = !editTable;
            this.lookUp_Donvitinh.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            Id_Congthuc_Phache = null;
            this.txtId_Congthuc_Phache.EditValue = null;
            this.txtMa_Congthuc_Phache.EditValue = null;
            this.txtTen_Congthuc_Phache.EditValue = null;
            this.lookUp_Hanghoa_Ban.EditValue = null;
            this.lookUpMa_Hanghoa_Ban.EditValue = null;
            this.lookUp_Donvitinh.EditValue = null;
            this.txtSoluong.EditValue = null;
            dgware_Dm_Congthuc_Phache_Chitiet.DataSource = null;
            ds_Congthuc_Phache_Chitiet = objMasterService.Get_All_Ware_Dm_Congthuc_Phache_Chitiet()
                .ToDataSet();
            dgware_Dm_Congthuc_Phache_Chitiet.DataSource = ds_Congthuc_Phache_Chitiet.Tables[0];
        }

        public object InsertObject()
        {
            bool saved = false;
            Ecm.WebReferences.MasterService.Ware_Dm_Congthuc_Phache objWare_Dm_Congthuc_Phache = new Ecm.WebReferences.MasterService.Ware_Dm_Congthuc_Phache();
            objWare_Dm_Congthuc_Phache.Ma_Congthuc_Phache = txtMa_Congthuc_Phache.EditValue;
            objWare_Dm_Congthuc_Phache.Ten_Congthuc_Phache = txtTen_Congthuc_Phache.EditValue;
            objWare_Dm_Congthuc_Phache.Id_Hanghoa_Ban = lookUp_Hanghoa_Ban.EditValue;
            objWare_Dm_Congthuc_Phache.Soluong = txtSoluong.EditValue;
            objWare_Dm_Congthuc_Phache.Id_Donvitinh = lookUp_Donvitinh.EditValue;

            Id_Congthuc_Phache = objMasterService.Insert_Ware_Dm_Congthuc_Phache(objWare_Dm_Congthuc_Phache);
            if (Id_Congthuc_Phache != null)
                foreach (DataRow dr in ds_Congthuc_Phache_Chitiet.Tables[0].Rows)
                    dr["Id_Congthuc_Phache"] = Id_Congthuc_Phache;
            objMasterService.Update_Ware_Dm_Congthuc_Phache_Chitiet_Collection(ds_Congthuc_Phache_Chitiet);
            saved = true;
            return saved;
        }

        public object UpdateObject()
        {
            try
            {
                bool saved = false;
                Ecm.WebReferences.MasterService.Ware_Dm_Congthuc_Phache objWare_Dm_Congthuc_Phache = new Ecm.WebReferences.MasterService.Ware_Dm_Congthuc_Phache();
                objWare_Dm_Congthuc_Phache.Id_Congthuc_Phache = Id_Congthuc_Phache;
                objWare_Dm_Congthuc_Phache.Ma_Congthuc_Phache = txtMa_Congthuc_Phache.EditValue;
                objWare_Dm_Congthuc_Phache.Ten_Congthuc_Phache = txtTen_Congthuc_Phache.EditValue;
                objWare_Dm_Congthuc_Phache.Id_Hanghoa_Ban = lookUp_Hanghoa_Ban.EditValue;
                objWare_Dm_Congthuc_Phache.Soluong = txtSoluong.EditValue;
                objWare_Dm_Congthuc_Phache.Id_Donvitinh = lookUp_Donvitinh.EditValue;
                objMasterService.Update_Ware_Dm_Congthuc_Phache(objWare_Dm_Congthuc_Phache);

                foreach (DataRow dr in ds_Congthuc_Phache_Chitiet.Tables[0].Rows)
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Congthuc_Phache"] = Id_Congthuc_Phache;
                objMasterService.Update_Ware_Dm_Congthuc_Phache_Chitiet_Collection(ds_Congthuc_Phache_Chitiet);
                saved = true;
                return saved;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //Ecm.WebReferences.MasterService.Ware_Dm_Congthuc_Phache_Chitiet ware_Dm_Congthuc_Phache_Chitiet = new Ecm.WebReferences.MasterService.Ware_Dm_Congthuc_Phache_Chitiet();
            //ware_Dm_Congthuc_Phache_Chitiet.Id_Congthuc_Phache_Chitiet = gridView1.GetFocusedRowCellValue("Id_Congthuc_Phache_Chitiet");
            ////ware_Dm_Congthuc_Phache_Chitiet.Id_Congthuc_Phache = lookUpEdit_Congthuc_Phache.EditValue;
            //ware_Dm_Congthuc_Phache_Chitiet.Ghichu = txtGhichu.EditValue;

            //if ("" + txtSoluong.EditValue != "")
            //    ware_Dm_Congthuc_Phache_Chitiet.Soluong = txtSoluong.EditValue;
            //if ("" + lookUpEdit_Donvitinh.EditValue != "")
            //    ware_Dm_Congthuc_Phache_Chitiet.Id_Donvitinh = lookUpEdit_Donvitinh.EditValue;
            //if ("" + lookUpEdit_Hanghoa_Mua.EditValue != "")
            //    ware_Dm_Congthuc_Phache_Chitiet.Id_Hanghoa_Mua = lookUpEdit_Hanghoa_Mua.EditValue;
            //return objMasterService.Update_Ware_Dm_Congthuc_Phache_Chitiet(ware_Dm_Congthuc_Phache_Chitiet);
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Congthuc_Phache ware_Dm_Congthuc_Phache = new Ecm.WebReferences.MasterService.Ware_Dm_Congthuc_Phache();
            ware_Dm_Congthuc_Phache.Id_Congthuc_Phache = gridView2.GetFocusedRowCellValue("Id_Congthuc_Phache");
            //ware_Dm_Congthuc_Phache_Chitiet.Id_Congthuc_Phache_Chitiet = gridView1.GetFocusedRowCellValue("Id_Congthuc_Phache_Chitiet");
            return objMasterService.Delete_Ware_Dm_Congthuc_Phache(ware_Dm_Congthuc_Phache);
        }

        public override bool PerformAdd()
        {
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            return true;
        }

        public override bool PerformEdit()
        {
            if ("" + Id_Congthuc_Phache != "")
            {
                this.ChangeStatus(true);
                return true;
            }
            else
            {
                return false;
            }

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
                dgware_Dm_Congthuc_Phache_Chitiet.EmbeddedNavigator.Buttons.DoClick(dgware_Dm_Congthuc_Phache_Chitiet.EmbeddedNavigator.Buttons.EndEdit);                
                bool success = false;
                 GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtMa_Congthuc_Phache, lblMa_Congthuc_Phache.Text);
                hashtableControls.Add(txtTen_Congthuc_Phache, lblTen_Congthuc_Phache.Text);
                hashtableControls.Add(lookUp_Hanghoa_Ban, lblId_Hanghoa_Ban.Text);
                hashtableControls.Add(txtSoluong, lblSoluong.Text);

                System.Collections.Hashtable htbMa_Congthuc_Phache = new System.Collections.Hashtable();
                htbMa_Congthuc_Phache.Add(txtMa_Congthuc_Phache, lblMa_Congthuc_Phache.Text);

                System.Collections.Hashtable htbTen_Congthuc_Phache = new System.Collections.Hashtable();
                htbTen_Congthuc_Phache.Add(txtTen_Congthuc_Phache, lblTen_Congthuc_Phache.Text);

                if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (gvware_Dm_Congthuc_Phache_Chitiet.RowCount == 0)
                {
                     GoobizFrame.Windows.Forms.MessageDialog.Show("Vui lòng nhập công thức pha chế chi tiết");
                    return false;
                }
                else
                {
                     GoobizFrame.Windows.Public.OrderHashtable hashtablegird = new  GoobizFrame.Windows.Public.OrderHashtable();
                    //hashtablegird.Add(gridView1.Columns["Id_Congthuc_Phache"], "");
                    hashtablegird.Add(gvware_Dm_Congthuc_Phache_Chitiet.Columns["Id_Donvitinh"], "");
                    hashtablegird.Add(gvware_Dm_Congthuc_Phache_Chitiet.Columns["Id_Hanghoa_Ban"], "");
                    hashtablegird.Add(gvware_Dm_Congthuc_Phache_Chitiet.Columns["Soluong"], "");
                    System.Collections.Hashtable htbId_Hanghoa_Mua = new System.Collections.Hashtable();
                    htbId_Hanghoa_Mua.Add(gvware_Dm_Congthuc_Phache_Chitiet.Columns["Id_Hanghoa_Ban"], "");

                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtablegird, gvware_Dm_Congthuc_Phache_Chitiet))
                        return false;
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(htbId_Hanghoa_Mua, gvware_Dm_Congthuc_Phache_Chitiet))
                        return false;
                }
                if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Add)
                {
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbMa_Congthuc_Phache, ds_Congthuc_Phache, "Ma_Congthuc_Phache"))
                        return false;
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbTen_Congthuc_Phache, ds_Congthuc_Phache, "Ten_Congthuc_Phache"))
                        return false;
                    success = (bool)this.InsertObject();                  
                }
                else if (this.FormState ==  GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    ds_Congthuc_Phache =  GoobizFrame.Windows.MdiUtils.Validator.datasetFillter(ds_Congthuc_Phache, "id_congthuc_phache = " + Id_Congthuc_Phache);
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbMa_Congthuc_Phache, ds_Congthuc_Phache, "Ma_Congthuc_Phache"))
                        return false;
                    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistValues(htbTen_Congthuc_Phache, ds_Congthuc_Phache, "Ten_Congthuc_Phache"))
                        return false;
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
                    // GoobizFrame.Windows.Forms.UserMessage.Show("SYS_ALREADY_EXIST", new string[] { lblId_Congthuc_Phache.Text, lblId_Congthuc_Phache.Text });
                }
                return false;
            }
        }

        //public override bool PerformSaveChanges()
        //{
        //     GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new  GoobizFrame.Windows.Public.OrderHashtable();
        //    hashtableControls.Add(gridView1.Columns["Id_Congthuc_Phache"], "");
        //    hashtableControls.Add(gridView1.Columns["Id_Donvitinh"], "");
        //    hashtableControls.Add(gridView1.Columns["Id_Hanghoa_Mua"], "");
        //    hashtableControls.Add(gridView1.Columns["Soluong"], "");
        //    System.Collections.Hashtable htbId_Hanghoa_Mua = new System.Collections.Hashtable();
        //    htbId_Hanghoa_Mua.Add(gridView1.Columns["Id_Hanghoa_Mua"], "");

        //    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gridView1))
        //        return false;
        //    if (! GoobizFrame.Windows.MdiUtils.Validator.CheckExistGrid(htbId_Hanghoa_Mua, gridView1))
        //        return false;
        //    try
        //    {
        //        dgware_Dm_Congthuc_Phache.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        //        ds_Congthuc_Phache.Tables[0].Columns["Ma_Congthuc_Phache"].Unique = true;
        //        objMasterService.Update_Ware_Dm_Congthuc_Phache_Collection(this.ds_Congthuc_Phache);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    try
        //    {
        //        dgware_Dm_Congthuc_Phache_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
        //        objMasterService.Update_Ware_Dm_Congthuc_Phache_Chitiet_Collection(this.ds_Congthuc_Phache_Chitiet);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    this.DisplayInfo();
        //    return true;
        //}

        public override bool PerformDelete()
        {
            if ("" + Id_Congthuc_Phache != "")
            {
                if ( GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
                 GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Dm_Congthuc_Phache_Chitiet"),
                 GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Dm_Congthuc_Phache_Chitiet")   }) == DialogResult.Yes)
                {
                    try
                    {
                        this.DeleteObject();
                    }
                    catch (Exception ex)
                    {
                         GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
                    }
                    this.DisplayInfo();
                }
                return true;
            }
            else
            {
                return false;
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            Ecm.WebReferences.MasterService.Ware_Dm_Congthuc_Phache_Chitiet ware_Dm_Congthuc_Phache_Chitiet = new Ecm.WebReferences.MasterService.Ware_Dm_Congthuc_Phache_Chitiet();
            try
            {
                int focusedRow = gvware_Dm_Congthuc_Phache_Chitiet.GetDataSourceRowIndex(gvware_Dm_Congthuc_Phache_Chitiet.FocusedRowHandle);
                DataRow dr = ds_Congthuc_Phache_Chitiet.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Dm_Congthuc_Phache_Chitiet.Id_Congthuc_Phache_Chitiet = dr["Id_Congthuc_Phache_Chitiet"];
                    ware_Dm_Congthuc_Phache_Chitiet.Id_Congthuc_Phache = dr["Id_Congthuc_Phache"];
                    ware_Dm_Congthuc_Phache_Chitiet.Ghichu = dr["Ghichu"];
                    ware_Dm_Congthuc_Phache_Chitiet.Soluong = dr["Soluong"];
                    ware_Dm_Congthuc_Phache_Chitiet.Id_Donvitinh = dr["Id_Donvitinh"];
                    ware_Dm_Congthuc_Phache_Chitiet.Id_Hanghoa_Mua = dr["Id_Hanghoa_Mua"];
                }
                this.Dispose();
                this.Close();
                return ware_Dm_Congthuc_Phache_Chitiet;
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
                return null;
            }
        }

        public override bool PerformPrintPreview()
        {
            dgware_Dm_Congthuc_Phache_Chitiet.ShowPrintPreview();
            return base.PerformPrintPreview();
        }
        #endregion

        #region Even

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                var _Id_Hanghoa_Ban = gvware_Dm_Congthuc_Phache_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban");
                var sdr = dsHanghoa_Ban.Tables[0].Select(string.Format("Id_Hanghoa_Ban={0}", _Id_Hanghoa_Ban));
                if (sdr.Length > 0)
                {
                    gvware_Dm_Congthuc_Phache_Chitiet.SetFocusedRowCellValue("Id_Donvitinh", sdr[0]["Id_Donvitinh"]);
                }
            }
        }

        private void dgware_Dm_Congthuc_Phache_Chitiet_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            //if (e.Button.ButtonType == DevExpress.XtraEditors.NavigatorButtonType.Remove)
            //{
            //    if (Convert.ToInt32(objMasterService.GetExistReferences("Ware_Dm_Congthuc_Phache_Chitiet", "Id_Congthuc_Phache_Chitiet", this.gridView1.GetFocusedRowCellValue("Id_Congthuc_Phache_Chitiet"))) > 0)
            //    {
            //         GoobizFrame.Windows.Forms.UserMessage.Show("Msg00015", new string[] { this.Text.ToLower() });
            //        e.Handled = true;
            //    }
            //}
        }

        private void lookUpEdit_Hanghoa_Mua_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    System.Data.DataRowView drv = (System.Data.DataRowView)lookUpEdit_Hanghoa_Mua.Properties.GetDataSourceRowByKeyValue(lookUpEdit_Hanghoa_Mua.EditValue);
            //    lookUpEdit_Donvitinh.EditValue = drv["Id_Donvitinh"];

            //}
            //catch { }
        }

        private void gridLookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Frmware_Dm_Donvitinh_Add frmware_Dm_Donvitinh_Add = new Frmware_Dm_Donvitinh_Add();
                frmware_Dm_Donvitinh_Add.Text = "Đơn vị tính";
                 GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Donvitinh_Add);
                frmware_Dm_Donvitinh_Add.ShowDialog();

                if (frmware_Dm_Donvitinh_Add.SelecteWare_Dm_Donvitinh != null)
                {
                    gridLookUp_Donvitinh.DataSource = frmware_Dm_Donvitinh_Add.Data.Tables[0];
                    gvware_Dm_Congthuc_Phache_Chitiet.SetFocusedRowCellValue(gvware_Dm_Congthuc_Phache_Chitiet.Columns["Id_Donvitinh"], frmware_Dm_Donvitinh_Add.SelecteWare_Dm_Donvitinh.Id_Donvitinh);
                }
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView2.FocusedRowHandle >= 0)
            {
                Id_Congthuc_Phache = gridView2.GetFocusedRowCellValue("Id_Congthuc_Phache");
                DisplayInfo2();
            }
            else
            {
                Id_Congthuc_Phache = "";
            }
        }

        private void btnCopy_Chitiet_Click(object sender, EventArgs e)
        {
            bool check = false;
            Frmware_Dm_Congthuc_Phache_Chitiet_Dialog frmware_Dm_Hanghoa_Ban_Dialog = new Frmware_Dm_Congthuc_Phache_Chitiet_Dialog();
            frmware_Dm_Hanghoa_Ban_Dialog.Text = btnCopy_Chitiet.Text;
            frmware_Dm_Hanghoa_Ban_Dialog.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
             GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Ban_Dialog);
            frmware_Dm_Hanghoa_Ban_Dialog.ShowDialog();

            //if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows != null
            //    && frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 0)
            //{
            //    //gridLookUpEdit_Hanghoa_Ban.DataSource = frmware_Dm_Hanghoa_Ban_Dialog.Data.Tables[0];
            //    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Congthuc_Phache"], gridView2.GetFocusedRowCellValue("Id_Congthuc_Phache"));
            //    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Hanghoa_Mua"]
            //        , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Hanghoa_Mua"]);
            //    gridView1.SetFocusedRowCellValue(gridView1.Columns["Soluong"]
            //        , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Soluong"]);
            //    gridView1.SetFocusedRowCellValue(gridView1.Columns["Id_Donvitinh"]
            //        , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Donvitinh"]);

            //object Id_Cuahang_Ban = gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban");
            if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows != null)
            {

                for (int i = 0; i < frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length; i++)
                {
                    check = false;
                    for (int j = 0; j < ds_Congthuc_Phache_Chitiet.Tables[0].Rows.Count; j++)
                        if (ds_Congthuc_Phache_Chitiet.Tables[0].Rows[j]["Id_Hanghoa_Ban"].Equals(frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Hanghoa_Ban"]))
                        {
                            check = true;
                            break;
                        }
                    if (!check)
                    {
                        DataRow nrow = ds_Congthuc_Phache_Chitiet.Tables[0].NewRow();
                        //nrow["Id_Cuahang_Ban"] = Id_Cuahang_Ban;
                        nrow["Id_Congthuc_Phache"] = gridView2.GetFocusedRowCellValue("Id_Congthuc_Phache");
                        nrow["Id_Hanghoa_Ban"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Hanghoa_Ban"];
                        nrow["Soluong"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Soluong"];
                        nrow["Id_Donvitinh"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Donvitinh"];
                        nrow["Ghichu"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Ghichu"];
                        ds_Congthuc_Phache_Chitiet.Tables[0].Rows.Add(nrow);
                    }
                }
                dgware_Dm_Congthuc_Phache_Chitiet.DataSource = ds_Congthuc_Phache_Chitiet.Tables[0];
            }
            //}
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();
            foreach (DataRow drHanghoa_Ban in dsHanghoa_Ban.Tables[0].Rows)
            {
                if (ds_Congthuc_Phache.Tables[0].Select("Id_Hanghoa_Ban=" + drHanghoa_Ban["Id_Hanghoa_Ban"]).Length == 0)
                {
                    DataRow ndrCongthuc_Phache = ds_Congthuc_Phache.Tables[0].NewRow();
                    ndrCongthuc_Phache["Id_Hanghoa_Ban"] = drHanghoa_Ban["Id_Hanghoa_Ban"];
                    ndrCongthuc_Phache["Ma_Congthuc_Phache"] = drHanghoa_Ban["Ma_Hanghoa_Ban"];
                    ndrCongthuc_Phache["Ten_Congthuc_Phache"] = drHanghoa_Ban["Ten_Hanghoa_Ban"];
                    ndrCongthuc_Phache["Id_Donvitinh"] = drHanghoa_Ban["Id_Donvitinh"];
                    ds_Congthuc_Phache.Tables[0].Rows.Add(ndrCongthuc_Phache);
                }
            }
            objMasterService.Update_Ware_Dm_Congthuc_Phache_Collection(ds_Congthuc_Phache);
            DisplayInfo();
            WaitDialogForm.Close();
        }

        private void lookUpEdit_Hanghoa_Ban_EditValueChanged(object sender, EventArgs e)
        {
            lookUp_Donvitinh.EditValue = lookUp_Hanghoa_Ban.GetColumnValue("Id_Donvitinh");
        }

        private void txtMa_Congthuc_Phache_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar).Equals(39))
                e.Handled = true;

        }
        #endregion

        private void gridText_Soluong_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //if (e.NewValue != null)
            //{
            //    if (e.NewValue.ToString() == "" || e.NewValue.ToString() == "0")
            //        e.Cancel = true;

            //    if (e.NewValue.ToString().Length > 9)
            //        e.Cancel = true;
            //}
        }

        private void txtSoluong_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue != null)
            {
                if (e.NewValue.ToString() == "" || e.NewValue.ToString() == "0")
                    e.Cancel = true;

                if (e.NewValue.ToString().Length > 9)
                    e.Cancel = true;
            }
        }

        private void lookUpMa_Hanghoa_Ban_EditValueChanged(object sender, EventArgs e)
        {
            lookUp_Hanghoa_Ban.EditValue = lookUpMa_Hanghoa_Ban.EditValue;
            //if (txtMa_Congthuc_Phache.Text == "")
            //    txtMa_Congthuc_Phache.Text = "" + lookUpMa_Hanghoa_Ban.GetColumnValue("Ma_Hanghoa_Ban");
            //if (txtTen_Congthuc_Phache.Text == "")
            //    txtTen_Congthuc_Phache.Text = "" + lookUpMa_Hanghoa_Ban.GetColumnValue("Ten_Hanghoa_Ban");
        }

    }
}

