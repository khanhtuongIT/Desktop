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
    public partial class Frmware_Nhap_Hh_Ban : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Nhap_Hh_Ban = new DataSet();
        DataSet ds_Nhap_Hh_Ban_Chitiet = new DataSet();
        DataSet dsHanghoa_Ban;
        DataSet dsDonvitinh = new DataSet();
        DataSet dsNhansu = new DataSet();
        object identity;
        object id_nhansu_current;
        object id_xuat_hh_ban;  //id xuất chuyển
        DataSet ds_Role_User;
        object per_vat;
        public Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban ware_Nhap_Hh_Ban;

        public Frmware_Nhap_Hh_Ban()
        {
            InitializeComponent();
            if (!System.IO.Directory.Exists(@"Resources\localdata"))
                System.IO.Directory.CreateDirectory(@"Resources\localdata");

            this.gridDate_Ngay_Sanxuat.MinValue = new DateTime(2000, 01, 01);
            this.gridDate_Han_Sd.MinValue = new DateTime(2000, 01, 01);
            this.item_Query.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            ////date mask
            lookUpEdit_Cuahang_Ban.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Nhansu_Lap.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            ds_Role_User = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
            this.DisplayInfo();
        }

        void LoadMasterData()
        {
            dsHanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            dsDonvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();

            lookUpEdit_Nhansu_Nhan.Properties.DataSource = dsNhansu.Tables[0];
            lookUpEdit_Nhansu_Lap.Properties.DataSource = dsNhansu.Tables[0];
            gridLookUpEdit_Nguoi_Nhan_Hanghoa_Ban.DataSource = dsNhansu.Tables[0];

            gridLookUpEdit_Hanghoa_Ban.DataSource = dsHanghoa_Ban.Tables[0];
            gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = dsHanghoa_Ban.Tables[0];
            gridLookUpEdit_Donvitinh.DataSource = dsDonvitinh.Tables[0];

            DataTable dtb = objMasterService.Get_All_Ware_Dm_Nhacungcap().ToDataSet().Tables[0];
            lookUpEdit_MaNCC.Properties.DataSource = dtb;
            lookUpEdit_NCC.Properties.DataSource = dtb;

            dtb = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet().Tables[0];
            lookUpEdit_Cuahang_Ban.Properties.DataSource = dtb;
            gridLookUpEdit_Kho_Hanghoa_Ban.DataSource = dtb;

            DataTable temp = dtb.Copy();
            DataRow row = temp.NewRow();
            row["Id_Cuahang_Ban"] = -1;
            row["Ma_Cuahang_Ban"] = "All";
            row["Ten_Cuahang_Ban"] = "Tất cả";
            temp.Rows.Add(row);
            lookupEdit_Kho_View.Properties.DataSource = temp;

            //DataSet ds_collection = objMasterService.GetRole_System_Name_ById_User(id_nhansu_current).ToDataSet();
            //if (ds_collection.Tables[0].Rows.Count > 0 &&
            //    "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
            //{
            //    DataTable temp = dtb.Copy();
            //    DataRow row = temp.NewRow();
            //    row["Id_Cuahang_Ban"] = -1;
            //    row["Ma_Cuahang_Ban"] = "All";
            //    row["Ten_Cuahang_Ban"] = "Tất cả";
            //    temp.Rows.Add(row);
            //    lookupEdit_Kho_View.Properties.DataSource = temp;
            //    lookupEdit_Kho_View.EditValue = -1;
            //}
            //else
            //{
            //    DataSet dsCuahang = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current, true).ToDataSet();
            //    lookupEdit_Kho_View.Properties.DataSource = dsCuahang.Tables[0];
            //}
        }

        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                DataSet dsHeso_Chuongtrinh = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso("Thue_GTGT").ToDataSet();
                per_vat = dsHeso_Chuongtrinh.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='Thue_GTGT'"))[0]["Heso"];
                LoadMasterData();
                dtThang_Nam.EditValue = DateTime.Now;
                Reload_Chungtu();
                if (!Convert.ToBoolean(objWareService.Ware_Nhap_Hh_Ban_CheckXuat_Chuyen()))
                    this.btnPhieuXuat.Appearance.ForeColor = System.Drawing.Color.Red;
                else
                    this.btnPhieuXuat.Appearance.ForeColor = System.Drawing.Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void DisplayInfo_Details()
        {
            try
            {
                identity = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban");
                this.ds_Nhap_Hh_Ban_Chitiet = objWareService.Get_All_Ware_Nhap_Hh_Ban_Chitiet_By_Nhap_Hh_Ban(identity != null ? identity : 0).ToDataSet();
                this.dgware_Nhap_Hh_Ban_Chitiet.DataSource = ds_Nhap_Hh_Ban_Chitiet;
                this.dgware_Nhap_Hh_Ban_Chitiet.DataMember = ds_Nhap_Hh_Ban_Chitiet.Tables[0].TableName;
                gvware_Nhap_Hh_Ban_Chitiet.BestFitColumns();
                DataBindingControl();
            }
            catch { }
        }

        public override void ClearDataBindings()
        {
            this.txtSochungtu.DataBindings.Clear();
            this.txtNguoi_Giao_Hanghoa_Ban.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            this.dtNgay_Nhap_Hh_Ban.DataBindings.Clear();
            this.lookUpEdit_Cuahang_Ban.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Lap.DataBindings.Clear();
            lookUpEdit_MaNCC.DataBindings.Clear();
            lookUpEdit_Nhansu_Nhan.DataBindings.Clear();
            this.chkGTGT.DataBindings.Clear();
            chkNguyenlieu.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {
                ClearDataBindings();
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban, ds_Nhap_Hh_Ban.Tables[0].TableName + ".Sochungtu");
                this.txtNguoi_Giao_Hanghoa_Ban.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban, ds_Nhap_Hh_Ban.Tables[0].TableName + ".Nguoi_Giaohang");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban, ds_Nhap_Hh_Ban.Tables[0].TableName + ".Ghichu");
                this.dtNgay_Nhap_Hh_Ban.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban, ds_Nhap_Hh_Ban.Tables[0].TableName + ".Ngay_Nhanhang");
                this.lookUpEdit_Cuahang_Ban.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban, ds_Nhap_Hh_Ban.Tables[0].TableName + ".Id_Cuahang_Ban");
                this.lookUpEdit_MaNCC.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban, ds_Nhap_Hh_Ban.Tables[0].TableName + ".Id_Ncc");
                this.lookUpEdit_Nhansu_Lap.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban, ds_Nhap_Hh_Ban.Tables[0].TableName + ".Id_Nhansu_Nhanhang"); //  người lập
                this.lookUpEdit_Nhansu_Nhan.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban, ds_Nhap_Hh_Ban.Tables[0].TableName + ".Id_Nhansu_Nhan"); // người nhận
                this.chkGTGT.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban, ds_Nhap_Hh_Ban.Tables[0].TableName + ".Is_Vat");
                this.chkNguyenlieu.DataBindings.Add("EditValue", ds_Nhap_Hh_Ban, ds_Nhap_Hh_Ban.Tables[0].TableName + ".Nguyenlieu");
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
            this.txtNguoi_Giao_Hanghoa_Ban.Properties.ReadOnly = !editTable;
            this.txtGhichu.Properties.ReadOnly = !editTable;
            lookUpEdit_MaNCC.Properties.ReadOnly = !editTable;
            lookUpEdit_Nhansu_Nhan.Properties.ReadOnly = !editTable;
            //this.lookUpEdit_Cuahang_Ban.Properties.ReadOnly = (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit) ? true : !editTable;
            this.dgware_Nhap_Hh_Ban_Chitiet.EmbeddedNavigator.Enabled = editTable;
            this.gvware_Nhap_Hh_Ban_Chitiet.OptionsBehavior.Editable = editTable;
            //this.chkPrint_Save.Visible = editTable;
            dockPanel1.Enabled = !editTable;
            btnPhieuXuat.Enabled = false;
            if (editTable)
            {
                if (!Convert.ToBoolean(objWareService.Ware_Nhap_Hh_Ban_CheckXuat_Chuyen()))
                {
                    this.btnPhieuXuat.Appearance.ForeColor = System.Drawing.Color.Red;
                    btnPhieuXuat.Enabled = editTable;
                }
            }
            this.chkGTGT.Enabled = editTable;
            chkNguyenlieu.Enabled = editTable;
            gridColumnDelete.Visible = editTable;
        }

        public override void ResetText()
        {
            this.txtNguoi_Giao_Hanghoa_Ban.EditValue = null;
            this.txtGhichu.EditValue = null;
            lookUpEdit_MaNCC.EditValue = null;
            this.lookUpEdit_Cuahang_Ban.EditValue = null;
            lookUpEdit_Nhansu_Lap.EditValue = null;
            dtNgay_Nhap_Hh_Ban.EditValue = null;
            txtSochungtu.EditValue = null;
            lookUpEdit_Nhansu_Nhan.EditValue = null;
            this.ds_Nhap_Hh_Ban_Chitiet = objWareService.Get_All_Ware_Nhap_Hh_Ban_Chitiet_By_Nhap_Hh_Ban(0).ToDataSet();
            this.dgware_Nhap_Hh_Ban_Chitiet.DataSource = ds_Nhap_Hh_Ban_Chitiet.Tables[0];
            this.chkGTGT.Checked = false;
            chkNguyenlieu.Checked = false;
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban objWare_Nhap_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban();
                objWare_Nhap_Hh_Ban.Id_Nhap_Hh_Ban = -1;
                txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_nhap_hh_ban", "sochungtu", lookUpEdit_Cuahang_Ban.GetColumnValue("Ma_Cuahang_Ban"));
                objWare_Nhap_Hh_Ban.Sochungtu = txtSochungtu.EditValue;
                objWare_Nhap_Hh_Ban.Nguoi_Giaohang = txtNguoi_Giao_Hanghoa_Ban.EditValue;
                objWare_Nhap_Hh_Ban.Ghichu = txtGhichu.EditValue;
                objWare_Nhap_Hh_Ban.Ngay_Nhanhang = dtNgay_Nhap_Hh_Ban.EditValue;
                objWare_Nhap_Hh_Ban.Id_Xuat_Hh_Ban = ("" + id_xuat_hh_ban == "") ? null : id_xuat_hh_ban;
                objWare_Nhap_Hh_Ban.Id_Ncc = ("" + lookUpEdit_MaNCC.EditValue == "") ? null : lookUpEdit_MaNCC.EditValue;
                objWare_Nhap_Hh_Ban.Id_Nhansu_Nhan = ("" + lookUpEdit_Nhansu_Nhan.EditValue == "") ? null : lookUpEdit_Nhansu_Nhan.EditValue;
                objWare_Nhap_Hh_Ban.Is_Vat = chkGTGT.Checked;
                objWare_Nhap_Hh_Ban.Nguyenlieu = chkNguyenlieu.Checked;
                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Nhap_Hh_Ban.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
                if ("" + lookUpEdit_Nhansu_Lap.EditValue != "")
                    objWare_Nhap_Hh_Ban.Id_Nhansu_Nhanhang = lookUpEdit_Nhansu_Lap.EditValue;
                identity = objWareService.Insert_Ware_Nhap_Hh_Ban(objWare_Nhap_Hh_Ban);
                if (identity != null)
                {
                    this.DoClickEndEdit(dgware_Nhap_Hh_Ban_Chitiet); //dgware_Nhap_Hh_Ban_Chitiet.EmbeddedNavigator.Buttons.EndEdit.DoClick();
                    foreach (DataRow dr in ds_Nhap_Hh_Ban_Chitiet.Tables[0].Rows)
                    {
                        dr["Id_Nhap_Hh_Ban"] = identity;
                    }
                    //update donmuahang_chitiet
                    objWareService.Update_Ware_Nhap_Hh_Ban_Chitiet_Collection(ds_Nhap_Hh_Ban_Chitiet);
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
                Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban objWare_Nhap_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban();
                objWare_Nhap_Hh_Ban.Id_Nhap_Hh_Ban = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban");
                objWare_Nhap_Hh_Ban.Sochungtu = txtSochungtu.EditValue;
                objWare_Nhap_Hh_Ban.Nguoi_Giaohang = "" + txtNguoi_Giao_Hanghoa_Ban.EditValue;
                objWare_Nhap_Hh_Ban.Ghichu = "" + txtGhichu.EditValue;
                objWare_Nhap_Hh_Ban.Ngay_Nhanhang = dtNgay_Nhap_Hh_Ban.EditValue;
                objWare_Nhap_Hh_Ban.Id_Ncc = ("" + lookUpEdit_MaNCC.EditValue == "") ? null : lookUpEdit_MaNCC.EditValue;
                objWare_Nhap_Hh_Ban.Id_Nhansu_Nhan = ("" + lookUpEdit_Nhansu_Nhan.EditValue == "") ? null : lookUpEdit_Nhansu_Nhan.EditValue;
                objWare_Nhap_Hh_Ban.Is_Vat = chkGTGT.Checked;
                objWare_Nhap_Hh_Ban.Nguyenlieu = chkNguyenlieu.Checked;
                if ("" + lookUpEdit_Cuahang_Ban.EditValue != "")
                    objWare_Nhap_Hh_Ban.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
                if ("" + lookUpEdit_Nhansu_Lap.EditValue != "")
                    objWare_Nhap_Hh_Ban.Id_Nhansu_Nhanhang = lookUpEdit_Nhansu_Lap.EditValue;
                //update donmuahang
                objWareService.Update_Ware_Nhap_Hh_Ban(objWare_Nhap_Hh_Ban);
                //update donmuahang_chitiet
                this.DoClickEndEdit(dgware_Nhap_Hh_Ban_Chitiet);
                foreach (DataRow dr in ds_Nhap_Hh_Ban_Chitiet.Tables[0].Rows)
                {
                    if (dr.RowState == DataRowState.Added)
                        dr["Id_Nhap_Hh_Ban"] = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban");
                }
                objWareService.Update_Ware_Nhap_Hh_Ban_Chitiet_Collection(ds_Nhap_Hh_Ban_Chitiet);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban objWare_Nhap_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban();
            objWare_Nhap_Hh_Ban.Id_Nhap_Hh_Ban = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban");
            return objWareService.Delete_Ware_Nhap_Hh_Ban(objWare_Nhap_Hh_Ban);
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
            ClearDataBindings();
            this.ChangeStatus(true);
            this.ResetText();
            dtNgay_Nhap_Hh_Ban.EditValue = objWareService.GetServerDateTime();
            lookUpEdit_Nhansu_Lap.EditValue = Convert.ToInt64(id_nhansu_current);
            lookUpEdit_Cuahang_Ban.EditValue = lookupEdit_Kho_View.EditValue;
            gvware_Nhap_Hh_Ban_Chitiet.AddNewRow();
            if (chkGTGT.Checked)
                gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue("Per_Vat", per_vat);
            //DataSet ds_Kho_Hanghoa = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Nhanhang.EditValue).ToDataSet();
            //this.lookUpEdit_Cuahang_Ban.Properties.DataSource = ds_Kho_Hanghoa.Tables[0];
            //if (ds_Kho_Hanghoa.Tables[0].Rows.Count > 0)
            //    lookUpEdit_Cuahang_Ban.EditValue = ds_Kho_Hanghoa.Tables[0].Rows[0]["Id_Cuahang_Ban"];
            //else
            //{
            //    GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn không có quyền thao tác trên cửa hàng " + lookUpEdit_Cuahang_Ban.Text + "\n vui lòng hủy thao tác");
            //    lookUpEdit_Nhansu_Nhanhang.EditValue = null;
            //    return false;
            //}
            return true;
        }

        public override bool PerformEdit()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban") == null)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu nhập, vui lòng chọn lại");
                    return false;
                }
                //Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                //DocumentProcessStatus.Tablename = "Ware_Nhap_Hh_Ban";
                //DocumentProcessStatus.PK_Name = "Id_Nhap_Hh_Ban";
                //DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban");
                //DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                //if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                //{
                //     GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                //    return false;
                //}
                //DataSet ds_Kho_Hanghoa = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Nhanhang.EditValue).ToDataSet();
                //this.lookUpEdit_Cuahang_Ban.Properties.DataSource = ds_Kho_Hanghoa.Tables[0];
                //if (ds_Kho_Hanghoa.Tables[0].Rows.Count == 0)
                //{
                //    GoobizFrame.Windows.Forms.MessageDialog.Show("Bạn không có quyền thao tác trên cửa hàng " + lookUpEdit_Cuahang_Ban.Text + "\n vui lòng hủy thao tác");
                //    lookUpEdit_Nhansu_Nhanhang.EditValue = null;
                //    return false;
                //}

                //if (ds_Role_User.Tables[0].Rows.Count > 0 && "" + ds_Role_User.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
                //{
                //    this.ChangeStatus(true);
                //}
                //else
                //{
                //    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                //    return false;
                //}
                this.ChangeStatus(true);
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
            this.DisplayInfo();
            return true;
        }

        public override bool PerformSave()
        {
            bool success = false;
            try
            {
                GoobizFrame.Windows.Public.OrderHashtable hashtableControls = new GoobizFrame.Windows.Public.OrderHashtable();
                //hashtableControls.Add(txtSochungtu, lblSochungtu.Text);
                hashtableControls.Add(lookUpEdit_Cuahang_Ban, lblKho.Text);
                hashtableControls.Add(lookUpEdit_Nhansu_Lap, lblNguoi_Nhan_Hanghoa_Ban.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(hashtableControls))
                    return false;

                this.DoClickEndEdit(dgware_Nhap_Hh_Ban_Chitiet);

                if (gvware_Nhap_Hh_Ban_Chitiet.RowCount > 0)
                {
                    System.Collections.Hashtable htbControl2 = new System.Collections.Hashtable();
                    htbControl2.Add(gvware_Nhap_Hh_Ban_Chitiet.Columns["Id_Hanghoa_Ban"], "");
                    //htbControl2.Add(gvware_Nhap_Hh_Ban_Chitiet.Columns["Soluong"], "");

                    if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullGrid(htbControl2, gvware_Nhap_Hh_Ban_Chitiet))
                        return false;
                }
                else
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa có hàng hóa, nhập hàng hóa");
                    return false;
                }
                try
                {
                    if (ds_Nhap_Hh_Ban_Chitiet.Tables[0].Constraints.Count == 0)
                    {
                        Constraint constraint = new UniqueConstraint("constraint1",
                                new DataColumn[] {ds_Nhap_Hh_Ban_Chitiet.Tables[0].Columns["Id_Hanghoa_Ban"],
                            ds_Nhap_Hh_Ban_Chitiet.Tables[0].Columns["Id_Donvitinh"] }, false);
                        ds_Nhap_Hh_Ban_Chitiet.Tables[0].Constraints.Add(constraint);
                    }
                }
                catch (Exception ex)
                {
                    if (ex.ToString().IndexOf("These columns don't currently have unique values") != -1)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Hàng hóa và đơn vị tính đã tồn tại, vui lòng nhập lại");
                        return false;
                    }
                    MessageBox.Show(ex.ToString());
                }
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                {
                    success = (bool)this.InsertObject();
                }
                else if (this.FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    success = (bool)this.UpdateObject();
                }
                if (success)
                {
                    this.DisplayInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            return success;
        }

        public override bool PerformDelete()
        {
            if (gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu nhập, vui lòng chọn lại");
                return false;
            }
            //Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
            //DocumentProcessStatus.Tablename = "Ware_Nhap_Hh_Ban";
            //DocumentProcessStatus.PK_Name = "Id_Nhap_Hh_Ban";
            //DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban");
            //DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
            //if ( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
            //if (ds_Role_User.Tables[0].Rows.Count > 0 && "" + ds_Role_User.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
            if (ds_Role_User.Tables[0].Rows.Count > 0 && ds_Role_User.Tables[0].Select("Role_System_Name = 'Administrators' ", "").Length > 0)
            {
                if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
             GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Nhap_Hh_Ban"),
             GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Nhap_Hh_Ban")   }) == DialogResult.Yes)
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
            }
            else
            {
                GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                return false;
            }
            return base.PerformDelete();
        }

        public override object PerformSelectOneObject()
        {
            ware_Nhap_Hh_Ban = new Ecm.WebReferences.WareService.Ware_Nhap_Hh_Ban();
            try
            {
                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
                DataRow dr = ds_Nhap_Hh_Ban.Tables[0].Rows[focusedRow];
                if (dr != null)
                {
                    ware_Nhap_Hh_Ban.Id_Nhap_Hh_Ban = dr["Id_Nhap_Hh_Ban"];
                    ware_Nhap_Hh_Ban.Sochungtu = dr["Sochungtu"];
                    ware_Nhap_Hh_Ban.Nguoi_Giaohang = dr["Nguoi_Giaohang"];
                    ware_Nhap_Hh_Ban.Ngay_Nhanhang = dr["Ngay_Nhanhang"];
                    ware_Nhap_Hh_Ban.Id_Cuahang_Ban = dr["Id_Cuahang_Ban"];
                    ware_Nhap_Hh_Ban.Id_Nhansu_Nhanhang = dr["Id_Nhansu_Nhanhang"];
                    ware_Nhap_Hh_Ban.Ghichu = dr["Ghichu"];
                }
                this.Dispose();
                this.Close();
                return ware_Nhap_Hh_Ban;
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
            if (gridView1.GetFocusedRowCellValue("Id_Nhap_Hh_Ban") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu nhập, vui lòng chọn lại");
                return false;
            }
            DataSets.DsNhap_Vattu dsWare_Nhap_Vattu = new Ecm.Ware.DataSets.DsNhap_Vattu();
            Reports.rptNhap_Vattu rptNhap_Vattu = new Reports.rptNhap_Vattu();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptNhap_Vattu;
            rptNhap_Vattu.DataSource = dsWare_Nhap_Vattu;
            //Ware_Nhap_Vattu
            DataRow rWare_Nhap_Vattu = dsWare_Nhap_Vattu.Tables["ware_nhap_hh_mua"].NewRow();
            rWare_Nhap_Vattu["sochungtu"] = txtSochungtu.Text;
            rWare_Nhap_Vattu["ngay_nhanhang"] = dtNgay_Nhap_Hh_Ban.EditValue;
            rWare_Nhap_Vattu["nguoi_giaohang"] = txtNguoi_Giao_Hanghoa_Ban.Text;
            rWare_Nhap_Vattu["hoten_nhansu_nhanhang"] = lookUpEdit_Nhansu_Lap.Text;
            rWare_Nhap_Vattu["ten_kho_hanghoa"] = lookUpEdit_Cuahang_Ban.Text;
            dsWare_Nhap_Vattu.Tables["ware_nhap_hh_mua"].Rows.Add(rWare_Nhap_Vattu);
            //Ware_Nhap_Vattu_Chitiet
            for (int i = 0; i < gvware_Nhap_Hh_Ban_Chitiet.RowCount; i++)
            {
                DataRow rWare_Nhap_Vattu_Chitiet = dsWare_Nhap_Vattu.Tables["ware_nhap_hh_mua_chitiet"].NewRow();
                rWare_Nhap_Vattu_Chitiet["id_nhap_hh_mua_chitiet"] = i + 1;
                rWare_Nhap_Vattu_Chitiet["ma_hanghoa"] = gvware_Nhap_Hh_Ban_Chitiet.GetRowCellDisplayText(i, gridColumn20);
                rWare_Nhap_Vattu_Chitiet["ten_hanghoa"] = gvware_Nhap_Hh_Ban_Chitiet.GetRowCellDisplayText(i, gridColumn14);
                rWare_Nhap_Vattu_Chitiet["ten_donvitinh"] = gvware_Nhap_Hh_Ban_Chitiet.GetRowCellDisplayText(i, "Id_Donvitinh");
                rWare_Nhap_Vattu_Chitiet["soluong"] = gvware_Nhap_Hh_Ban_Chitiet.GetRowCellDisplayText(i, "Soluong");
                rWare_Nhap_Vattu_Chitiet["dongia"] = gvware_Nhap_Hh_Ban_Chitiet.GetRowCellDisplayText(i, "Dongia");
                rWare_Nhap_Vattu_Chitiet["thanhtien"] = gvware_Nhap_Hh_Ban_Chitiet.GetRowCellDisplayText(i, "Thanhtien");
                dsWare_Nhap_Vattu.Tables["ware_nhap_hh_mua_chitiet"].Rows.Add(rWare_Nhap_Vattu_Chitiet);
            }
            dsWare_Nhap_Vattu.AcceptChanges();

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
                rptNhap_Vattu.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptNhap_Vattu.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
                rptNhap_Vattu.xrPic_Logo.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Image", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyLogo"));
            }

            #endregion
            rptNhap_Vattu.xrTableCell_Nguoigiao.Text = txtNguoi_Giao_Hanghoa_Ban.Text;

            double thanhtien = Convert.ToDouble("0" + gvware_Nhap_Hh_Ban_Chitiet.Columns["Thanhtien"].SummaryText);
            string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(thanhtien, " đồng.");
            str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            rptNhap_Vattu.xrTableCell_Sotien_Chu.Text = str;
            rptNhap_Vattu.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptNhap_Vattu);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                frmPrintPreview.Text = "In Phiếu Nhập kho";  // "" + oReportOptions.Caption;
                frmPrintPreview.printControl1.PrintingSystem = rptNhap_Vattu.PrintingSystem;
                frmPrintPreview.MdiParent = this.MdiParent;
                frmPrintPreview.Show();
                frmPrintPreview.Activate();
            }
            else
            {
                var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptNhap_Vattu);
                reportPrintTool.Print();
            }
            return true;
        }
        #endregion

        #region Even

        private void btnImport_Hanghoa_Ban_Click(object sender, EventArgs e)
        {
            //Forms.Frmware_Donmuahang_Dialog frmware_Donmuahang = new Frmware_Donmuahang_Dialog();
            //frmware_Donmuahang.StartPosition = FormStartPosition.CenterScreen;
            //frmware_Donmuahang.ShowDialog();
        }

        private void gridView5_CellValueChanged_1(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Value + "" == "") return;
            if (e.Column.FieldName == "Id_Hanghoa_Ban")
            {
                gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Id_Donvitinh"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);
                gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Id_Donvitinh"]
                    , ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Id_Donvitinh"]);
                gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Barcode_Txt"]
                    , txtSochungtu.EditValue + " " +
                    ((System.Data.DataRowView)gridLookUpEdit_Hanghoa_Ban.GetDataSourceRowByKeyValue(e.Value))["Ma_Hanghoa_Ban"]);
            }
            if (e.Column.FieldName == "Soluong" || e.Column.FieldName == "Soluong_Nguyenlieu" || e.Column.FieldName == "Dongia")
            {
                decimal soluong = Convert.ToDecimal("0" + gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue("Soluong")) + (Convert.ToDecimal("0" + gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue("Soluong_Nguyenlieu")));
                decimal thanhtien_vat = (soluong
                                            * Convert.ToDecimal("0" + gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue("Dongia"))
                                            * Convert.ToDecimal("0" + gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue("Per_Vat"))
                                         ) / 100;
                gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Thanhtien"]
                    , (soluong * Convert.ToDecimal("0" + gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue("Dongia"))) + thanhtien_vat);
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

        private void lookUpEdit_Cuahang_Ban_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.FormState == GoobizFrame.Windows.Forms.FormState.Add)
                    txtSochungtu.EditValue = objWareService.GetNew_Sochungtu("ware_nhap_hh_ban", "sochungtu", lookUpEdit_Cuahang_Ban.GetColumnValue("Ma_Cuahang_Ban"));
                //dsHanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban_By_Id_Cuahang_Ban(lookUpEdit_Cuahang_Ban.EditValue, dtNgay_Nhap_Hh_Ban.EditValue).ToDataSet();
            }
            catch { }
        }

        private void chkShowPreview_CheckedChanged(object sender, EventArgs e)
        {
            //gridView1.OptionsView.ShowPreview = chkShowPreview.Checked;
        }

        private void gridLookUpEdit_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog frmware_Dm_Hanghoa_Ban_Dialog = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Dialog();
                frmware_Dm_Hanghoa_Ban_Dialog.Text = "Hàng hóa";
                GoobizFrame.Windows.MdiUtils.ThemeSettings.SetDialogShow(frmware_Dm_Hanghoa_Ban_Dialog);
                frmware_Dm_Hanghoa_Ban_Dialog.Id_Cuahang_Ban = lookUpEdit_Cuahang_Ban.EditValue;
                frmware_Dm_Hanghoa_Ban_Dialog.ShowDialog();

                if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows != null
                    && frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 0)
                {
                    gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Id_Hanghoa_Ban"]
                        , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Hanghoa_Ban"]);
                    gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Id_Donvitinh"]
                        , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Donvitinh"]);

                    if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 1)
                    {
                        for (int i = 1; i < frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length; i++)
                        {
                            DataRow nrow = ds_Nhap_Hh_Ban_Chitiet.Tables[0].NewRow();
                            nrow["Id_Hanghoa_Ban"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Hanghoa_Ban"];
                            nrow["Id_Donvitinh"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Donvitinh"];
                            ds_Nhap_Hh_Ban_Chitiet.Tables[0].Rows.Add(nrow);
                        }
                    }
                }
            }
        }

        private void gridLookUpEdit_Donvitinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add frm_Donvitinh = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Donvitinh_Add();
                if (gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Id_Hanghoa_Ban"]).ToString() == "")
                    return;
                frm_Donvitinh.setId_Hanghoa_Ban(gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Id_Hanghoa_Ban"]));
                frm_Donvitinh.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                frm_Donvitinh.item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                frm_Donvitinh.ShowDialog();
                if (frm_Donvitinh.SelecteWare_Dm_Donvitinh != null)
                {
                    gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Id_Donvitinh"], frm_Donvitinh.SelecteWare_Dm_Donvitinh.Id_Donvitinh);
                }
                gvware_Nhap_Hh_Ban_Chitiet.BestFitColumns();
            }
        }
        #endregion

        private void gridText_Soluong_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if ("" + e.NewValue == "")
                {
                    gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Soluong"], null);
                    e.Cancel = true;
                }
                else if (Convert.ToInt32(e.NewValue) > int.MaxValue)
                {
                    // GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị số lượng không hợp lệ, vui lòng nhập lại.");
                    //gridView5.SetFocusedRowCellValue(gridView5.Columns["Soluong"], null);
                    e.Cancel = true;
                }
                else if (Convert.ToInt32(e.NewValue) <= 0)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Số lượng phải lớn hơn 0, vui lòng nhập lại.");
                    gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue(gvware_Nhap_Hh_Ban_Chitiet.Columns["Soluong"], null);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                // GoobizFrame.Windows.Forms.MessageDialog.Show("Giá trị số lượng không hợp lệ, vui lòng nhập lại.");
                //gridView5.SetFocusedRowCellValue(gridView5.Columns["Soluong"], null);
                e.Cancel = true;
            }
        }

        void Reload_Chungtu()
        {
            ResetText();
            //var id_kho = (Convert.ToInt64(lookupEdit_Kho_View.EditValue) == -1) ? null : lookupEdit_Kho_View.EditValue;
            ds_Nhap_Hh_Ban = objWareService.Get_All_Ware_Nhap_Hh_Ban(dtThang_Nam.EditValue, lookupEdit_Kho_View.EditValue).ToDataSet();
            dgware_Nhap_Hh_Ban.DataSource = ds_Nhap_Hh_Ban;
            dgware_Nhap_Hh_Ban.DataMember = ds_Nhap_Hh_Ban.Tables[0].TableName;
            this.DataBindingControl();
            this.ChangeStatus(false);
            DisplayInfo_Details();
        }

        private void gridLookUpEdit_Ma_Hanghoa_Ban_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                try
                {
                    var dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData(
                        "Ecm.MasterTables.dll",
                        "Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_FullEdit", this);

                    if (dialog == null)
                        return;

                    //dsHanghoa_Ban = dialog.GetType().GetProperty("DsDm_Hanghoa_Ban").GetValue(dialog, null) as DataSet;
                    //gridLookUpEdit_Hanghoa_Ban.DataSource = dsHanghoa_Ban.Tables[0];
                    //gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = dsHanghoa_Ban.Tables[0];

                    var SelectedObject = dialog.GetType().GetProperty("Selected_Ware_Dm_Hanghoa_Ban").GetValue(dialog, null)
                        as Ecm.WebReferences.MasterService.Ware_Dm_Hanghoa_Ban;

                    if (SelectedObject != null)
                        gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue("Id_Hanghoa_Ban", SelectedObject.Id_Hanghoa_Ban);
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Reload_Chungtu();
        }

        private void btnPhieuXuat_Click(object sender, EventArgs e)
        {
            Frmware_Xuat_Chuyen_Noibo frmXuat = new Frmware_Xuat_Chuyen_Noibo();
            frmXuat.Text = "Chọn hàng hóa nhập từ phiếu xuất chuyển nội bộ";
            frmXuat._Dialog = true;
            frmXuat.id_kho_nhap = lookUpEdit_Cuahang_Ban.EditValue;
            frmXuat.ShowDialog();
            id_xuat_hh_ban = frmXuat.id_xuat_hh_ban;
            DataSet ds_Ware_Xuat_Hh_Ban_Chitiet = objWareService.Get_All_Ware_Xuat_Hh_Ban_Chitiet_By_Xuat_Hh_Ban(id_xuat_hh_ban != null ? id_xuat_hh_ban : 0).ToDataSet();
            foreach (DataRow dtr in ds_Ware_Xuat_Hh_Ban_Chitiet.Tables[0].Rows)
            {
                DataRow row = ds_Nhap_Hh_Ban_Chitiet.Tables[0].NewRow();
                row["Id_Hanghoa_Ban"] = dtr["Id_Hanghoa_Ban"];
                row["Id_Donvitinh"] = dtr["Id_Donvitinh"];
                row["Soluong"] = dtr["Soluong"];
                row["Dongia"] = dtr["Dongia"];
                row["Thanhtien"] = dtr["Thanhtien"];
                row["Barcode_Txt"] = dtr["Barcode_Txt"];
                row["Ngay_Sx"] = dtr["Ngay_Sx"];
                row["Han_Sd"] = dtr["Han_Sd"];
                row["Lo_Sx"] = dtr["Lo_Sx"];
                ds_Nhap_Hh_Ban_Chitiet.Tables[0].Rows.Add(row);
            }
        }

        private void lookUpEdit_MaNCC_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_MaNCC.EditValue = null;
        }

        private void lookUpEdit_MaNCC_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_NCC.EditValue = lookUpEdit_MaNCC.EditValue;
        }

        private void lookUpEdit_Nhansu_Nhan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_Nhansu_Nhan.EditValue = null;
        }

        private void gvware_Nhap_Hh_Ban_Chitiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (gvware_Nhap_Hh_Ban_Chitiet.FocusedColumn.VisibleIndex == gvware_Nhap_Hh_Ban_Chitiet.VisibleColumns.Count - 1
                && e.KeyCode == Keys.Enter && "" + gvware_Nhap_Hh_Ban_Chitiet.GetFocusedRowCellValue("Id_Hanghoa_Ban") != "")
                gvware_Nhap_Hh_Ban_Chitiet.AddNewRow();
        }

        private void gvware_Nhap_Hh_Ban_Chitiet_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvware_Nhap_Hh_Ban_Chitiet.FocusedColumn = gvware_Nhap_Hh_Ban_Chitiet.VisibleColumns[0];
            if (chkGTGT.Checked)
                gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue("Per_Vat", per_vat);
        }

        private void gridButtonEdit_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)
                gvware_Nhap_Hh_Ban_Chitiet.DeleteRow(gvware_Nhap_Hh_Ban_Chitiet.FocusedRowHandle);
        }

        private void chkGTGT_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataRow row in ds_Nhap_Hh_Ban_Chitiet.Tables[0].Rows)
            {
                if (chkGTGT.Checked)
                    gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue("Per_Vat", per_vat);
                else
                    gvware_Nhap_Hh_Ban_Chitiet.SetFocusedRowCellValue("Per_Vat", 0);
            }
        }

        private void chkNguyenlieu_CheckedChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(chkNguyenlieu.Checked))
            {
                gridColumn_SL.Visible = false;
                gridColumn_SLNL.Visible = true;
                gridColumn_SLNL.VisibleIndex = 3;
            }
            else
            {
                gridColumn_SLNL.Visible = false;
                gridColumn_SL.Visible = true;
                gridColumn_SL.VisibleIndex = 3;
            }
        }

    }
}

