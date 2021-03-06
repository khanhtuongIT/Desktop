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
    public partial class Frmware_Xuat_Chuyen_Noibo : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet ds_Ware_Xuat_Hh_Ban = new DataSet();
        DataSet ds_Ware_Xuat_Hh_Ban_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Ban;
        DataSet ds_Hanghoa_Dinhgia = new DataSet();
        DataSet dsDonvitinh = new DataSet();
        DataSet dsNhansu;
        DataSet ds_Xuat_Hhban;
        object identity;
        public bool _Dialog = false;
        object id_nhansu_current;
        DataSet ds_Role_User;
        public object id_xuat_hh_ban;
        public object id_kho_nhap;

        public Frmware_Xuat_Chuyen_Noibo()
        {
            InitializeComponent();
            //date mask
            this.gridDate_Ngay_Sx.MinValue = new DateTime(2000, 01, 01);
            dtNgay_Chungtu_Xuat.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Chungtu_Xuat.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            //reset lookup edit as delete value
            lookUpEdit_Cuahang_Ban_Nhap.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Cuahang_Ban_Xuat.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Nhansu_Xuat.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Nhansu_Nhap.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            ds_Role_User = objMasterService.GetRole_System_Name_ById_User(id_nhansu_current).ToDataSet();
            this.DisplayInfo();
            this.item_Query.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Test.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Verify.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        void LoadMasterData()
        {
            ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            ds_Hanghoa_Dinhgia = objWareService.Get_All_Ware_Hanghoa_Ban_Dinhgia().ToDataSet();
            dsDonvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();

            //gridLookUpEdit_Hanghoa_Mua
            gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            gridLookUpEdit_Hanghoa_Ban.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            gridLookUpEdit_Ma_Hanghoa_Ban.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            //lookUpEdit_Nhansu_Kk
            lookUpEdit_Nhansu_Nhap.Properties.DataSource = dsNhansu.Tables[0];
            lookUpEdit_Nhansu_Xuat.Properties.DataSource = dsNhansu.Tables[0];
            gridLookUpEdit_Nhansu_Xuat.DataSource = dsNhansu.Tables[0];
            gridLookUpEdit_Donvitinh.DataSource = dsDonvitinh.Tables[0];

            DataSet dsCuahang_Ban = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet();
            lookUpEdit_Cuahang_Ban_Nhap.Properties.DataSource = dsCuahang_Ban.Tables[0];
            lookUpEdit_Cuahang_Ban_Xuat.Properties.DataSource = dsCuahang_Ban.Tables[0];
            gridLookUpEdit_Cuahang_Ban_Xuat.DataSource = dsCuahang_Ban.Tables[0];

            DataSet temp = dsCuahang_Ban.Copy();
            DataRow row = temp.Tables[0].NewRow();
            row["Id_Cuahang_Ban"] = -1;
            row["Ma_Cuahang_Ban"] = "All";
            row["Ten_Cuahang_Ban"] = "Tất cả";
            temp.Tables[0].Rows.Add(row);
            lookupEdit_Kho_View.Properties.DataSource = temp.Tables[0];
            lookupEdit_Kho_View.EditValue = -1;
            //DataSet ds_collection = objMasterService.GetRole_System_Name_ById_User(id_nhansu_current).ToDataSet();
            //if (ds_collection.Tables[0].Rows.Count > 0 &&
            //    "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
            //{
            //    DataSet temp = dsCuahang_Ban.Copy();
            //    DataRow row = temp.Tables[0].NewRow();
            //    row["Id_Cuahang_Ban"] = -1;
            //    row["Ma_Cuahang_Ban"] = "All";
            //    row["Ten_Cuahang_Ban"] = "Tất cả";
            //    temp.Tables[0].Rows.Add(row);
            //    lookupEdit_Kho_View.Properties.DataSource = temp.Tables[0];
            //    lookupEdit_Kho_View.EditValue = -1;
            //}
            //else
            //{
            //    DataSet dsCuahang = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current, true).ToDataSet();
            //    lookupEdit_Kho_View.Properties.DataSource = dsCuahang.Tables[0];
            //}
        }

        void Reload_Chungtu()
        {
            if (id_kho_nhap == null)
            {
                ds_Ware_Xuat_Hh_Ban = objWareService.Get_All_Ware_Xuat_Hh_Ban(dtThang_Nam.DateTime, lookupEdit_Kho_View.EditValue).ToDataSet();
                item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                ds_Ware_Xuat_Hh_Ban = objWareService.Ware_Xuat_Hh_Ban_SelectAll_ById_Kho_Nhap(dtThang_Nam.DateTime, id_kho_nhap).ToDataSet();
                item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            dgware_Xuat_Hanghoa_Ban.DataSource = ds_Ware_Xuat_Hh_Ban;
            dgware_Xuat_Hanghoa_Ban.DataMember = ds_Ware_Xuat_Hh_Ban.Tables[0].TableName;
            this.DataBindingControl();
            this.ChangeStatus(false);
            DisplayInfo_Details();
        }

        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                ResetText();
                LoadMasterData();
                dtThang_Nam.EditValue = DateTime.Now;
                Reload_Chungtu();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public override void ClearDataBindings()
        {
            this.txtId_Xuat_Hh_Ban.DataBindings.Clear();
            this.txtSochungtu.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.dtNgay_Chungtu_Xuat.DataBindings.Clear();
            this.lookUpEdit_Cuahang_Ban_Nhap.DataBindings.Clear();
            this.lookUpEdit_Cuahang_Ban_Xuat.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Nhap.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Xuat.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtId_Xuat_Hh_Ban.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Id_Xuat_Hh_Ban");
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Sochungtu");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Ghichu");
                this.dtNgay_Chungtu_Xuat.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Ngay_Chungtu_Xuat");
                this.lookUpEdit_Cuahang_Ban_Nhap.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Id_Cuahang_Ban_Nhap");
                this.lookUpEdit_Cuahang_Ban_Xuat.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Id_Cuahang_Ban_Xuat");
                this.lookUpEdit_Nhansu_Nhap.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Id_Nhansu_Nhap");
                this.lookUpEdit_Nhansu_Xuat.DataBindings.Add("EditValue", ds_Ware_Xuat_Hh_Ban, ds_Ware_Xuat_Hh_Ban.Tables[0].TableName + ".Id_Nhansu_Xuat");
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
            dockPanel1.Enabled = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Nhansu_Nhap.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Cuahang_Ban_Nhap.Properties.ReadOnly = !editTable;
            this.lookUpEdit_Cuahang_Ban_Xuat.Properties.ReadOnly = !editTable;
            this.dgware_Xuat_Hanghoa_Ban_Chitiet.EmbeddedNavigator.Enabled = editTable;
            this.gvware_Xuat_Hanghoa_Ban_Chitiet.OptionsBehavior.Editable = editTable;
            this.chkPrint_Save.Enabled = editTable;
            this.chkPrint_Save.Checked = !editTable;
            gridColumn_Delete.Visible = editTable;
        }

        public override void ResetText()
        {
            this.txtId_Xuat_Hh_Ban.EditValue = null;
            this.txtGhichu.EditValue = null;
            this.lookUpEdit_Cuahang_Ban_Nhap.EditValue = null;
            this.lookUpEdit_Cuahang_Ban_Xuat.EditValue = null;
            this.lookUpEdit_Nhansu_Nhap.EditValue = null;
            lookUpEdit_Nhansu_Xuat.EditValue = null;
            txtSochungtu.EditValue = null;
            dtNgay_Chungtu_Xuat.EditValue = null;
            this.ds_Ware_Xuat_Hh_Ban_Chitiet = objWareService.Get_All_Ware_Xuat_Hh_Ban_Chitiet_By_Xuat_Hh_Ban(-1).ToDataSet();
            this.dgware_Xuat_Hanghoa_Ban_Chitiet.DataSource = ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0];
        }

        void DisplayInfo_Details()
        {
            try
            {
                DataBindingControl();
                identity = gridView1.GetFocusedRowCellValue("Id_Xuat_Hh_Ban");
                ds_Ware_Xuat_Hh_Ban_Chitiet = objWareService.Get_All_Ware_Xuat_Hh_Ban_Chitiet_By_Xuat_Hh_Ban(identity != null ? identity : 0).ToDataSet();
                ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0].Columns.Add("Chon", typeof(bool));
                this.dgware_Xuat_Hanghoa_Ban_Chitiet.DataSource = ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0];
                gvware_Xuat_Hanghoa_Ban_Chitiet.BestFitColumns();
            }
            catch { }
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Xuat_Hh_Ban objWare_Xuat_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Xuat_Hh_Ban();
                objWare_Xuat_Hh_Ban.Id_Xuat_Hh_Ban = -1;
                txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_xuat_hh_ban", "Sochungtu", lookUpEdit_Cuahang_Ban_Xuat.GetColumnValue("Ma_Cuahang_Ban"));
                objWare_Xuat_Hh_Ban.Sochungtu = txtSochungtu.EditValue;
                objWare_Xuat_Hh_Ban.Ghichu = "" + txtGhichu.EditValue;
                objWare_Xuat_Hh_Ban.Ngay_Chungtu_Xuat = dtNgay_Chungtu_Xuat.EditValue;
                if ("" + lookUpEdit_Cuahang_Ban_Nhap.EditValue != "")
                    objWare_Xuat_Hh_Ban.Id_Cuahang_Ban_Nhap = lookUpEdit_Cuahang_Ban_Nhap.EditValue;
                if ("" + lookUpEdit_Cuahang_Ban_Xuat.EditValue != "")
                    objWare_Xuat_Hh_Ban.Id_Cuahang_Ban_Xuat = lookUpEdit_Cuahang_Ban_Xuat.EditValue;
                if ("" + lookUpEdit_Nhansu_Nhap.EditValue != "")
                    objWare_Xuat_Hh_Ban.Id_Nhansu_Nhap = lookUpEdit_Nhansu_Nhap.EditValue;
                if ("" + lookUpEdit_Nhansu_Xuat.EditValue != "")
                    objWare_Xuat_Hh_Ban.Id_Nhansu_Xuat = lookUpEdit_Nhansu_Xuat.EditValue;

                identity = objWareService.Insert_Ware_Xuat_Hh_Ban(objWare_Xuat_Hh_Ban);
                if (identity != null)
                {
                    this.DoClickEndEdit(dgware_Xuat_Hanghoa_Ban); //dgware_Xuat_Hanghoa_Ban.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    foreach (DataRow dr in ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Xuat_Hh_Ban"] = identity;
                    }
                    //update nhap_hh_mua_chitiet
                    objWareService.Update_Ware_Xuat_Hh_Ban_Chitiet_Collection(ds_Ware_Xuat_Hh_Ban_Chitiet);

                    #region insert auto phiếu nhập kho

                    Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban objWare_Nhap_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban();
                    objWare_Nhap_Hh_Ban.Id_Nhap_Hh_Ban = -1;
                    objWare_Nhap_Hh_Ban.Sochungtu = objWareService.GetNew_Sochungtu("ware_nhap_hh_ban", "sochungtu", lookUpEdit_Cuahang_Ban_Nhap.GetColumnValue("Ma_Cuahang_Ban"));
                    objWare_Nhap_Hh_Ban.Nguoi_Giaohang = "";
                    objWare_Nhap_Hh_Ban.Ghichu = "Phiếu nhập tự động từ phiếu xuất chuyển nội bộ  " + txtSochungtu.Text;
                    objWare_Nhap_Hh_Ban.Ngay_Nhanhang = dtNgay_Chungtu_Xuat.EditValue;
                    objWare_Nhap_Hh_Ban.Id_Xuat_Hh_Ban = identity;
                    objWare_Nhap_Hh_Ban.Id_Ncc = null;
                    objWare_Nhap_Hh_Ban.Id_Nhansu_Nhan = ("" + lookUpEdit_Nhansu_Nhap.EditValue == "") ? null : lookUpEdit_Nhansu_Nhap.EditValue;
                    if ("" + lookUpEdit_Cuahang_Ban_Nhap.EditValue != "")
                        objWare_Nhap_Hh_Ban.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban_Nhap.EditValue;
                    objWare_Nhap_Hh_Ban.Id_Nhansu_Nhanhang = lookUpEdit_Nhansu_Nhap.EditValue;
                    objWare_Nhap_Hh_Ban.Is_Vat = false;
                    objWareService.Insert_Ware_Nhap_Hh_Ban_FromXuatchuyen(objWare_Nhap_Hh_Ban);

                    //if (identity != null)
                    //{
                    //    this.DoClickEndEdit(dgware_Nhap_Hh_Ban_Chitiet); //dgware_Nhap_Hh_Ban_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    //    foreach (DataRow dr in ds_Nhap_Hh_Ban_Chitiet.Tables[0].Rows)
                    //    {
                    //        dr["Id_Nhap_Hh_Ban"] = identity;
                    //    }
                    //    //update donmuahang_chitiet
                    //    objWareService.Update_Ware_Nhap_Hh_Ban_Chitiet_Collection(ds_Nhap_Hh_Ban_Chitiet);
                    //}

                    #endregion
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Xuat_Hh_Ban objWare_Xuat_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Xuat_Hh_Ban();
                objWare_Xuat_Hh_Ban.Id_Xuat_Hh_Ban = identity;
                objWare_Xuat_Hh_Ban.Sochungtu = txtSochungtu.EditValue;
                objWare_Xuat_Hh_Ban.Ghichu = "" + txtGhichu.EditValue;
                objWare_Xuat_Hh_Ban.Ngay_Chungtu_Xuat = dtNgay_Chungtu_Xuat.EditValue;

                if ("" + lookUpEdit_Cuahang_Ban_Nhap.EditValue != "")
                    objWare_Xuat_Hh_Ban.Id_Cuahang_Ban_Nhap = lookUpEdit_Cuahang_Ban_Nhap.EditValue;
                if ("" + lookUpEdit_Cuahang_Ban_Xuat.EditValue != "")
                    objWare_Xuat_Hh_Ban.Id_Cuahang_Ban_Xuat = lookUpEdit_Cuahang_Ban_Xuat.EditValue;

                if ("" + lookUpEdit_Nhansu_Nhap.EditValue != "")
                    objWare_Xuat_Hh_Ban.Id_Nhansu_Nhap = lookUpEdit_Nhansu_Nhap.EditValue;
                if ("" + lookUpEdit_Nhansu_Xuat.EditValue != "")
                    objWare_Xuat_Hh_Ban.Id_Nhansu_Xuat = lookUpEdit_Nhansu_Xuat.EditValue;
                objWare_Xuat_Hh_Ban.Doc_Process_Status = 2;
                objWareService.Update_Ware_Xuat_Hh_Ban(objWare_Xuat_Hh_Ban);
                this.DoClickEndEdit(dgware_Xuat_Hanghoa_Ban_Chitiet); //dgware_Xuat_Hanghoa_Ban_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                foreach (DataRow dr in ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Xuat_Hh_Ban"] = gridView1.GetFocusedRowCellValue("Id_Xuat_Hh_Ban");
                }
                objWareService.Update_Ware_Xuat_Hh_Ban_Chitiet_Collection(ds_Ware_Xuat_Hh_Ban_Chitiet);
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
            Ecm.WebReferences.WareService.Ware_Xuat_Hh_Ban objWare_Xuat_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Xuat_Hh_Ban();
            objWare_Xuat_Hh_Ban.Id_Xuat_Hh_Ban = gridView1.GetFocusedRowCellValue("Id_Xuat_Hh_Ban");
            return objWareService.Delete_Ware_Xuat_Hh_Ban(objWare_Xuat_Hh_Ban);
        }

        public override bool PerformAdd()
        {
            if (Convert.ToInt64(lookupEdit_Kho_View.EditValue) == -1
                || lookupEdit_Kho_View.EditValue == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn kho, vui lòng chọn lại");
                lookupEdit_Kho_View.Focus();
                return false;
            }
            FormState = GoobizFrame.Windows.Forms.FormState.Add;
            this.ChangeStatus(true);
            ClearDataBindings();
            this.ResetText();
            dtNgay_Chungtu_Xuat.EditValue = objWareService.GetServerDateTime();
            lookUpEdit_Nhansu_Xuat.EditValue = Convert.ToInt64(id_nhansu_current);
            //DataSet ds_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Xuat.EditValue).ToDataSet();
            //this.lookUpEdit_Cuahang_Ban_Xuat.Properties.DataSource = ds_Cuahang_Ban.Tables[0];
            //if (ds_Cuahang_Ban.Tables[0].Rows.Count > 0)
            //    lookUpEdit_Cuahang_Ban_Xuat.EditValue = ds_Cuahang_Ban.Tables[0].Rows[0]["Id_Cuahang_Ban"];
            //else
            //{
            //    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
            //    lookUpEdit_Nhansu_Xuat.EditValue = null;
            //    return false;
            //}
            //ds_Xuat_Hhban = objWareService.Get_All_Ware_Nxt_HhBan(new DateTime(dtNgay_Chungtu_Xuat.DateTime.Year, dtNgay_Chungtu_Xuat.DateTime.Month, dtNgay_Chungtu_Xuat.DateTime.Day, 0, 0, 0)
            //    , new DateTime(dtNgay_Chungtu_Xuat.DateTime.Year, dtNgay_Chungtu_Xuat.DateTime.Month, dtNgay_Chungtu_Xuat.DateTime.Day, 23, 0, 0)
            //    , lookUpEdit_Cuahang_Ban_Xuat.EditValue).ToDataSet();
            lookUpEdit_Cuahang_Ban_Xuat.EditValue = lookupEdit_Kho_View.EditValue;
            return true;
        }

        public override bool PerformEdit()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Xuat_Hh_Ban") == null)
                    return false;
                //Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                //DocumentProcessStatus.Tablename = "ware_xuat_hh_ban";
                //DocumentProcessStatus.PK_Name = "id_xuat_hh_ban";
                //DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Xuat_Hh_Ban");
                //DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                //if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                //{
                //    GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                //    return false;
                //}
                //if (!id_nhansu_current.Equals("" + lookUpEdit_Nhansu_Xuat.EditValue))
                //{
                //    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                //    return false;
                //}
                //ds_Xuat_Hhban = objWareService.Get_All_Ware_Xuat_Hh_Ban();
                //DateTime ngay_chungtu = dtNgay_Chungtu_Xuat.DateTime;
                //ds_Xuat_Hhban = objWareService.Get_All_Ware_Nxt_HhBan(new DateTime(ngay_chungtu.Year, ngay_chungtu.Month, ngay_chungtu.Day, 0, 0, 0)
                //    , new DateTime(ngay_chungtu.Year, ngay_chungtu.Month, ngay_chungtu.Day, 23, 0, 0)
                //    , lookUpEdit_Cuahang_Ban_Xuat.EditValue).ToDataSet();
                //DataSet ds_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Nhap.EditValue);
                //this.lookUpEdit_Cuahang_Ban_Xuat.Properties.DataSource = ds_Cuahang_Ban.Tables[0];
                //if (ds_Cuahang_Ban.Tables[0].Rows.Count == 0)
                //{
                //     GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                //    lookUpEdit_Nhansu_Nhap.EditValue = null;
                //    return false;
                //}
                //if (ds_Role_User.Tables[0].Rows.Count > 0 && "" + ds_Role_User.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
                //{
                this.ChangeStatus(true);
                lookUpEdit_Cuahang_Ban_Xuat.Properties.ReadOnly = true;
                //  }
                // else
                // {
                //GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                // return false;
                // }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return true;
        }

        public override bool PerformCancel()
        {
            this.FormState = GoobizFrame.Windows.Forms.FormState.View;
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            try
            {
                bool success = false;
                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                hashtableControls.Add(txtSochungtu, lblSochungtu.Text);
                hashtableControls.Add(lookUpEdit_Cuahang_Ban_Xuat, lblId_Cuahang_Ban_Xuat.Text);
                hashtableControls.Add(lookUpEdit_Nhansu_Xuat, lblId_Nhansu_Xuat.Text);
                hashtableControls.Add(lookUpEdit_Cuahang_Ban_Nhap, lblId_Cuahang_Ban_Nhap.Text);
                this.DoClickEndEdit(dgware_Xuat_Hanghoa_Ban_Chitiet); //this.dgware_Xuat_Hanghoa_Ban_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (lookUpEdit_Cuahang_Ban_Nhap.EditValue.Equals(lookUpEdit_Cuahang_Ban_Xuat.EditValue))
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Cửa hàng nhập và xuất không được giống nhau, chọn lại cửa hàng nhập vào");
                    return false;
                }
                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                if (gvware_Xuat_Hanghoa_Ban_Chitiet.RowCount == 0)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa nhập hàng hóa, nhập lại");
                    return false;
                }
                else
                {
                    hashtableControls.Clear();
                    hashtableControls.Add(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Id_Hanghoa_Ban"], "");
                    hashtableControls.Add(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Soluong"], "");
                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(hashtableControls, gvware_Xuat_Hanghoa_Ban_Chitiet))
                        return false;
                }
                //try
                //{
                //    Constraint constraint = new UniqueConstraint("constraint1",
                //            new DataColumn[] {ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0].Columns["Id_Hanghoa_Ban"],
                //            ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0].Columns["Id_Donvitinh"] }, false);
                //    ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0].Constraints.Add(constraint);
                //}
                //catch (Exception ex)
                //{
                //    if (ex.ToString().IndexOf("These columns don't currently have unique values") != -1)
                //    {
                //        GoobizFrame.Windows.Forms.MessageDialog.Show("Tên hàng hóa và đơn vị tính đã tồn tại, vui lòng nhập lại ");
                //        return false;
                //    }
                //    MessageBox.Show(ex.ToString());
                //}
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Chungtu_Xuat, dtNgay_Chungtu_Nhap))
                    //    return false;
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    //if (! GoobizFrame.Windows.MdiUtils.Validator.CheckDate(dtNgay_Chungtu_Xuat, dtNgay_Chungtu_Nhap))
                    //    return false;
                    success = (bool)this.UpdateObject();
                }
                if (success)
                {
                    if (chkPrint_Save.Checked)
                        PerformPrintPreview();
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
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Xuat_Hh_Ban") == null)
                    return false;
                //Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                //DocumentProcessStatus.Tablename = "ware_xuat_hh_ban";
                //DocumentProcessStatus.PK_Name = "id_xuat_hh_ban";
                //DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Xuat_Hh_Ban");
                //DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);

                if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
                 GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Xuat_Hh_Ban"),
                 GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Xuat_Hh_Ban")   }) == DialogResult.Yes)
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
                //if (ds_Role_User.Tables[0].Rows.Count > 0 && ds_Role_User.Tables[0].Select("Role_System_Name = 'Administrators' ", "").Length > 0) 
                //{
                //    if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
                // GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Xuat_Hh_Ban"),
                // GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Xuat_Hh_Ban")   }) == DialogResult.Yes)
                //    {
                //        try
                //        {
                //            this.DeleteObject();
                //        }
                //        catch (Exception ex)
                //        {
                //            GoobizFrame.Windows.MdiUtils.Validator.CheckReferencedRecord(ex.Message, "");
                //        }
                //        this.DisplayInfo();
                //    }
                //}
                //else
                //{
                //    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                //    return false;
                //}
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
                return false;
#endif
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            try
            {
                if (gridView1.FocusedRowHandle < 0)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu xuất, vui lòng chọn lại");
                    return false;
                }
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Ware_Xuat_Hh_Ban.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    id_xuat_hh_ban = dr["Id_Xuat_Hh_Ban"];
                }
                this.Dispose();
                this.Close();
                return id_xuat_hh_ban;
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
            if (gridView1.GetFocusedRowCellValue("Id_Xuat_Hh_Ban") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu xuất, vui lòng chọn lại");
                return false;
            }
            try
            {
                DataSets.DsHdbanhang_Xuatkho dsWare_Xuat_Vattu = new Ecm.Ware.DataSets.DsHdbanhang_Xuatkho();
                Reports.rptXuat_ChuyenNB rptXuat_Vattu = new Reports.rptXuat_ChuyenNB();
                GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
                frmPrintPreview.Report = rptXuat_Vattu;
                rptXuat_Vattu.DataSource = dsWare_Xuat_Vattu;
                //Ware_Xuat_Vattu
                rptXuat_Vattu.xrTableCell_Sochungtu_Xuat.Text = gridView1.GetFocusedRowCellValue("Sochungtu").ToString();
                rptXuat_Vattu.xrTableCell_Ngayxuat.Text = dtNgay_Chungtu_Xuat.Text;
                rptXuat_Vattu.xrTableCell_Ngay.Text = DateTime.Now.Day.ToString();
                rptXuat_Vattu.xrTableCell_Thang.Text = DateTime.Now.Month.ToString();
                rptXuat_Vattu.xrTableCell_Nam.Text = DateTime.Now.Year.ToString();

                rptXuat_Vattu.xrTableCell_Kho_xuat.Text = lookUpEdit_Cuahang_Ban_Xuat.Text;
                rptXuat_Vattu.xrTableCell_Nguoi_Xuat.Text = lookUpEdit_Nhansu_Xuat.Text;
                rptXuat_Vattu.xrTableCell_Kho_Nhan.Text = lookUpEdit_Cuahang_Ban_Nhap.Text;
                rptXuat_Vattu.xrTableCell_Nguoi_Nhan.Text = lookUpEdit_Nhansu_Nhap.Text;
                rptXuat_Vattu.xrTableCell_Lydo.Text = txtGhichu.Text;

                //Ware_Xuat_Vattu_Chitiet
                for (int i = 0; i < gvware_Xuat_Hanghoa_Ban_Chitiet.RowCount; i++)
                {
                    DataRow rWare_Xuat_Vattu_Chitiet = dsWare_Xuat_Vattu.Tables[0].NewRow();
                    rWare_Xuat_Vattu_Chitiet["stt"] = i + 1;
                    rWare_Xuat_Vattu_Chitiet["Ma_Hanghoa_Ban"] = gvware_Xuat_Hanghoa_Ban_Chitiet.GetRowCellDisplayText(i, gridColumn7);
                    rWare_Xuat_Vattu_Chitiet["Ten_Hanghoa_Ban"] = gvware_Xuat_Hanghoa_Ban_Chitiet.GetRowCellDisplayText(i, gridColumn14);
                    rWare_Xuat_Vattu_Chitiet["Ten_Donvitinh"] = gvware_Xuat_Hanghoa_Ban_Chitiet.GetRowCellDisplayText(i, "Id_Donvitinh");
                    rWare_Xuat_Vattu_Chitiet["Soluong"] = Convert.ToDecimal("0" + gvware_Xuat_Hanghoa_Ban_Chitiet.GetRowCellDisplayText(i, "Soluong"));
                    rWare_Xuat_Vattu_Chitiet["Dongia_Ban"] = Convert.ToDecimal("0" + gvware_Xuat_Hanghoa_Ban_Chitiet.GetRowCellDisplayText(i, "Dongia"));
                    rWare_Xuat_Vattu_Chitiet["Thanhtien"] = Convert.ToDecimal("0" + gvware_Xuat_Hanghoa_Ban_Chitiet.GetRowCellDisplayText(i, "Thanhtien"));
                    rWare_Xuat_Vattu_Chitiet["DVT_Quydoi"] = gvware_Xuat_Hanghoa_Ban_Chitiet.GetRowCellDisplayText(i, "DVT_Quydoi");
                    dsWare_Xuat_Vattu.Tables[0].Rows.Add(rWare_Xuat_Vattu_Chitiet);
                }
                dsWare_Xuat_Vattu.AcceptChanges();
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
                    ,imageData
                });

                    rptXuat_Vattu.xrc_CompanyName.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                    rptXuat_Vattu.xrc_CompanyAddress.DataBindings.Add(
                        new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                    //rptXuat_Vattu.xrPic_Logo.DataBindings.Add(
                    //    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
                }
                #endregion

                double thanhtien = Convert.ToDouble("0" + gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Thanhtien"].SummaryText);
                string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(thanhtien, " đồng.");
                str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
                // rptXuat_Vattu.xrTableCell_Sotien_Chu.Text = str;
                rptXuat_Vattu.CreateDocument();
                GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptXuat_Vattu);
                if (Convert.ToBoolean(oReportOptions.PrintPreview))
                {
                    frmPrintPreview.Text = "In Phiếu xuất chuyển";//oReportOptions.Caption;
                    frmPrintPreview.printControl1.PrintingSystem = rptXuat_Vattu.PrintingSystem;
                    frmPrintPreview.MdiParent = this.MdiParent;
                    frmPrintPreview.Show();
                    frmPrintPreview.Activate();
                }
                else
                {
                    var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptXuat_Vattu);
                    reportPrintTool.Print();
                }
                DisplayInfo();
            }
            catch (Exception ex)
            { ex.ToString(); }
            return true;
        }

        #endregion

        #region Even

        private void lookUpEdit_Cuahang_Ban_Xuat_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.FormState != GoobizFrame.Windows.Forms.FormState.View)
                {
                    object Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban_Xuat.EditValue;
                    if ("" + Id_Cuahang_Ban != "")
                    {
                        if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                            txtSochungtu.EditValue = objWareService.GetNew_Sochungtu(
                                "ware_xuat_hh_ban"
                                , "Sochungtu"
                                , lookUpEdit_Cuahang_Ban_Xuat.GetColumnValue("Ma_Cuahang_Ban"));
                        if (FormState == GoobizFrame.Windows.Forms.FormState.View)
                            return;

                        //DataSet dsHanghoa_ByCuahang = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban(Id_Cuahang_Ban, dtNgay_Chungtu_Xuat.EditValue).ToDataSet();
                        //gridLookUpEdit_Hanghoa_Ban.DataSource = dsHanghoa_ByCuahang.Tables[0];
                        //gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = dsHanghoa_ByCuahang.Tables[0];
                    }
                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void gridLookUpEdit_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
                {
                    Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog frmware_Dm_Hanghoa_Ban_Dialog = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog();
                    frmware_Dm_Hanghoa_Ban_Dialog.Text = "Hàng hóa";
                    GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Ban_Dialog);
                    frmware_Dm_Hanghoa_Ban_Dialog.ShowDialog();

                    if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows != null
                        && frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 0)
                    {
                        gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Id_Hanghoa_Ban"]
                            , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Hanghoa_Ban"]);
                        gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Id_Donvitinh"]
                            , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Donvitinh"]);
                        gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Dongia_Ban"]
                            , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Dongia_Ban"]);
                        //object Id_Cuahang_Ban = gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban");
                        if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 1)
                        {
                            for (int i = 1; i < frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length; i++)
                            {
                                DataRow nrow = ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0].NewRow();
                                //nrow["Id_Cuahang_Ban"] = Id_Cuahang_Ban;
                                nrow["Id_Hanghoa_Ban"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Hanghoa_Ban"];
                                nrow["Id_Donvitinh"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Donvitinh"];
                                nrow["Dongia"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Dongia_Ban"];
                                ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0].Rows.Add(nrow);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public decimal Get_Soluong_Ton_Quydoi(object Id_Hanghoa_Ban, object Id_Donvitinh, object Id_Xuat_Hh_Ban_Chitiet)
        {
            try
            {
                var _Id_Donvitinh = ds_Hanghoa_Ban.Tables[0].Select(string.Format("Id_Hanghoa_Ban={0}", Id_Hanghoa_Ban))[0]["Id_Donvitinh"];
                DataSet ds_hh_nxt = Get_Soluong_Ton_Quydoi(lookUpEdit_Cuahang_Ban_Xuat.EditValue, Id_Hanghoa_Ban, Id_Donvitinh, ("" + Id_Xuat_Hh_Ban_Chitiet == "") ? null : Id_Xuat_Hh_Ban_Chitiet);
                decimal soluong_ton_quydoi = 0;
                soluong_ton_quydoi = ("" + Id_Donvitinh == "" + _Id_Donvitinh)
                ? Convert.ToDecimal("0" + ds_hh_nxt.Tables[0].Compute("sum(Soluong_Ton_Qdoi)",
                        string.Format("Id_Hanghoa_Ban={0}", Id_Hanghoa_Ban)))
                : Convert.ToDecimal("0" + ds_hh_nxt.Tables[0].Compute("sum(Soluong_Ton)",
                        string.Format("Id_Hanghoa_Ban={0} and Id_Donvitinh={1}", Id_Hanghoa_Ban, Id_Donvitinh)));
                return soluong_ton_quydoi;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return 0;
            }
        }

        public DataSet Get_Soluong_Ton_Quydoi(object Id_Cuahang_Ban, object Id_Hanghoa_Ban, object Id_Donvitinh, object Id_Xuat_Hh_Ban_Chitiet)
        {
            try
            {
                DateTime current_date = objWareService.GetServerDateTime();
                int today = 1;
                if (current_date.Day == 1)
                    today = 1;
                else
                    today = current_date.Day - 1;

                return objWareService.Rptware_Nxt_Hhban_Qdoi_Id_Xuat_Chuyen_Chitiet(new DateTime(current_date.Year, current_date.Month, today, 0, 0, 0),
                                                                current_date, Id_Cuahang_Ban, Id_Hanghoa_Ban, Id_Donvitinh, ("" + Id_Xuat_Hh_Ban_Chitiet == "") ? null : Id_Xuat_Hh_Ban_Chitiet).ToDataSet();
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                return null;
            }
        }

        private void gridLookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
                {
                    Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add frm_Donvitinh = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add();
                    if (gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Id_Hanghoa_Ban"]).ToString() == "")
                        return;
                    frm_Donvitinh.setId_Hanghoa_Ban(gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Id_Hanghoa_Ban"]));
                    frm_Donvitinh.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    frm_Donvitinh.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    frm_Donvitinh.ShowDialog();
                    if (frm_Donvitinh.SelecteWare_Dm_Donvitinh != null)
                        gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Id_Donvitinh"], frm_Donvitinh.SelecteWare_Dm_Donvitinh.Id_Donvitinh);

                    int soluong = Convert.ToInt32(gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Soluong"]));
                    if (Get_Soluong_Ton_Quydoi(gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Id_Hanghoa_Ban"]),
                                                gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Id_Donvitinh"]),
                                                gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Id_Xuat_Hh_Ban_Chitiet"])) < soluong)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Không đủ số lượng để xuất theo yêu cầu");
                        gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Soluong"], soluong);
                        return;
                    }
                    gvware_Xuat_Hanghoa_Ban_Chitiet.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedDataRow() == null
                    || lookUpEdit_Cuahang_Ban_Xuat.EditValue == null)
                    return;

                switch (e.Column.FieldName)
                {
                    case "Id_Hanghoa_Ban":
                        var _Id_Hanghoa_Ban = ds_Hanghoa_Ban.Tables[0].Select(string.Format("Id_Hanghoa_Ban={0}",
                               gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban")))[0]["Id_Hanghoa_Ban"];
                        var _Id_Donvitinh = ds_Hanghoa_Ban.Tables[0].Select(string.Format("Id_Hanghoa_Ban={0}",
                                gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban")))[0]["Id_Donvitinh"];
                        gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue("Id_Donvitinh", _Id_Donvitinh);
                        DataSet dsNhap_Chitiet = objWareService.Get_All_Ware_Nhap_Hh_Ban_Chitiet_By_Nhap_Hh_Ban(_Id_Hanghoa_Ban).ToDataSet();

                        //DateTime date_current = objWareService.GetServerDateTime();
                        //DataSet ds_hanghoa_nhap = objWareService.Rptware_Nxt_Hhban(new DateTime(date_current.Year, date_current.Month, date_current.Day, 0, 0, 0)
                        //                                , new DateTime(date_current.Year, date_current.Month, date_current.Day, 23, 59, 59), lookUpEdit_Cuahang_Ban_Xuat.EditValue, null, null).ToDataSet();
                        //DataRow[] row = ds_hanghoa_nhap.Tables[0].Select("Id_Hanghoa_Ban = " + _Id_Hanghoa_Ban + " and Id_Donvitinh = " + _Id_Donvitinh);

                        break;
                    //case "Id_Donvitinh":
                    //    var soluong_ton = this.Get_Soluong_Ton_Quydoi(
                    //            gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban"),
                    //            gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Id_Donvitinh"),
                    //            gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Id_Xuat_Hh_Ban_Chitiet"));
                    //    gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue("Soluong", soluong_ton);

                    //    DataRow[] dtr = ds_Hanghoa_Dinhgia.Tables[0].Select("Id_Hanghoa_Ban = " + gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban")
                    //                          + "and Id_Donvitinh = " + gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Id_Donvitinh"));
                    //    if (dtr.Length != 0 && dtr[0]["Dongia_Ban"].ToString() != "")
                    //        gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Dongia"], dtr[0]["Dongia_Ban"]);
                    //    else
                    //        gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Dongia"], null);
                    //    break;
                    case "Soluong":
                    case "Dongia":
                        decimal soluong = 0;
                        decimal dongia = 0;
                        decimal thanhtien = 0;
                        //soluong_ton = this.Get_Soluong_Ton_Quydoi(
                        //       gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban"),
                        //       gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Id_Donvitinh"),
                        //       gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Id_Xuat_Hh_Ban_Chitiet"));
                        //soluong = Convert.ToDecimal("0" + gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Soluong"));
                        //dongia = Convert.ToDecimal("0" + gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Dongia"));
                        //if (soluong_ton < soluong)
                        //{
                        //    GoobizFrame.Windows.Forms.MessageDialog.Show("Không đủ số lượng để xuất theo yêu cầu");
                        //    gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Soluong"], soluong_ton);
                        //    return;
                        //}
                        if ((thanhtien * dongia).ToString().Length > 16)
                        {
                            GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị thành tiền vượt quá khả năng lưu trữ.");
                            gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Dongia"], null);
                            gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue(gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Soluong"], null);
                            return;
                        }
                        gvware_Xuat_Hanghoa_Ban_Chitiet.SetFocusedRowCellValue("Thanhtien", soluong * dongia);
                        break;
                    case "Thanhtien":
                        gvware_Xuat_Hanghoa_Ban_Chitiet.UpdateTotalSummary();
                        //txtSotien.Text = gvware_Xuat_Hanghoa_Ban_Chitiet.Columns["Thanhtien"].SummaryText;
                        break;
                }

                gvware_Xuat_Hanghoa_Ban_Chitiet.BestFitColumns();
            }
            catch (Exception ex)
            {
#if (DEBUG)
                MessageBox.Show(ex.Message);
#endif
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ClearDataBindings();
            if (gridView1.FocusedRowHandle >= 0)
                DisplayInfo_Details();
            else
                ResetText();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Reload_Chungtu();
        }

        private void Frmware_Xuat_Chuyen_Noibo_Load(object sender, EventArgs e)
        {
            if (_Dialog)
            {
                //gridColumn_Chon.Visible = true;
                //chkCheckAll.Visible = true;
                panelControl2.Enabled = false;
                item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            Reload_Chungtu();
        }

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow row in ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0].Rows)
                row["Chon"] = chkCheckAll.EditValue;
        }

        #endregion

        private void gvware_Xuat_Hanghoa_Ban_Chitiet_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvware_Xuat_Hanghoa_Ban_Chitiet.CancelUpdateCurrentRow();
            if (lookUpEdit_Cuahang_Ban_Xuat.EditValue == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn Kho xuất, vui lòng chọn lại");
                lookUpEdit_Cuahang_Ban_Xuat.Focus();
                return;
            }
            if (ds_Ware_Xuat_Hh_Ban_Chitiet == null)
                ds_Ware_Xuat_Hh_Ban_Chitiet = objWareService.Get_All_Ware_Xuat_Hh_Ban_Chitiet_By_Xuat_Hh_Ban(-1).ToDataSet();
            Frmware_Nhap_Hh_Ban_Xuatchuyen frmNhap_Xuatchuyen = new Frmware_Nhap_Hh_Ban_Xuatchuyen(lookUpEdit_Cuahang_Ban_Xuat.EditValue);
            frmNhap_Xuatchuyen.ShowDialog();
            try
            {
                DataSet dsDinhgia_ById_Hanghoa;
                foreach (DataRow dtr in frmNhap_Xuatchuyen._selectedRows)
                {
                    // Add nhap vattu chi tiet 
                    DataRow row_xuatchuyen_chitiet = ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0].NewRow();
                    row_xuatchuyen_chitiet["Id_Hanghoa_Ban"] = dtr["Id_Hanghoa_Ban"];
                    //DataSet dsNhap_Chitiet = objWareService.Ware_Nhap_Hh_Ban_Chitiet_SelectById_Nhap_Chitiet(dtr["Id_Nhap_Hh_Ban_Chitiet"]).ToDataSet();
                    //if (dsNhap_Chitiet.Tables.Count > 0)
                    //{
                    //    row_xuatchuyen_chitiet["Ngay_Sx"] = dsNhap_Chitiet.Tables[0].Rows[0]["Ngay_Sx"];
                    //    row_xuatchuyen_chitiet["Lo_Sx"] = dsNhap_Chitiet.Tables[0].Rows[0]["Lo_Sx"];
                    //    row_xuatchuyen_chitiet["Han_Sd"] = dsNhap_Chitiet.Tables[0].Rows[0]["Han_Sd"];
                    //}
                    row_xuatchuyen_chitiet["Id_Donvitinh"] = dtr["Id_Donvitinh"];
                    //rNha_Chitiet["Barcode_Txt"] = dtr["Barcode_Txt"];
                    row_xuatchuyen_chitiet["Soluong"] = dtr["Soluong_Ton"];
                    //rNha_Chitiet["Ten_Mathang"] = dtr["Ten_Mathang"];
                    //row_xuatchuyen_chitiet["Id_Nhap_Hh_Ban_Chitiet"] = dtr["Id_Nhap_Hh_Ban_Chitiet"];
                    //row_xuatchuyen_chitiet["Dongia"] = dtr["Dongia_Nhap"];    
                    //row_xuatchuyen_chitiet["Thanhtien"] = dtr["Thanhtien"];

                    dsDinhgia_ById_Hanghoa = objWareService.Get_All_Ware_Hanghoa_Dinhgia_By_Id_HhBan(dtr["Id_Hanghoa_Ban"]).ToDataSet();
                    DataRow[] row = dsDinhgia_ById_Hanghoa.Tables[0].Select();
                    row_xuatchuyen_chitiet["Dongia"] = row[0]["Dongia_Banle"];
                    row_xuatchuyen_chitiet["Thanhtien"] = Convert.ToDecimal("0" + dtr["Soluong_Ton"]) * Convert.ToDecimal("0" + row[0]["Dongia_Banle"]);
                    ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0].Rows.Add(row_xuatchuyen_chitiet);
                }
            }
            catch (Exception ex)
            { ex.ToString(); }
        }

        private void gvware_Xuat_Hanghoa_Ban_Chitiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (gvware_Xuat_Hanghoa_Ban_Chitiet.FocusedColumn.VisibleIndex == gvware_Xuat_Hanghoa_Ban_Chitiet.VisibleColumns.Count - 1
      && "" + gvware_Xuat_Hanghoa_Ban_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban") != "")
                gvware_Xuat_Hanghoa_Ban_Chitiet.AddNewRow();
        }

        private void gridButtonEdit_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                gvware_Xuat_Hanghoa_Ban_Chitiet.DeleteRow(gvware_Xuat_Hanghoa_Ban_Chitiet.FocusedRowHandle);
        }

    }
}