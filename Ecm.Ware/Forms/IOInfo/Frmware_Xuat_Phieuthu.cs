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
    public partial class Frmware_Xuat_Phieuthu : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet ds_Xkbanhang = new DataSet();
        DataSet dsPhieuthu_Chitiet = new DataSet();
        //DataSet ds_Hanghoa_Ban;
        //DataSet ds_Hanghoa_Dinhgia = new DataSet();
        //DataSet dsDonvitinh = new DataSet();
        DataSet dsNhansu;
        String chungtu_goc;
        object id_nhansu_current;
        DataSet ds_Role_User;

        public Frmware_Xuat_Phieuthu()
        {
            InitializeComponent();
            //date mask
            dtNgay_Chungtu.Properties.Mask.UseMaskAsDisplayFormat = true;
            dtNgay_Chungtu.Properties.Mask.EditMask = GoobizFrame.Windows.MdiUtils.DateTimeMask.GetDateTimeFormat();
            //reset lookup edit as delete value
            //lookUpEdit_Kho_View.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            lookUpEdit_Nhansu_Lap.Properties.ProcessNewValue += new DevExpress.XtraEditors.Controls.ProcessNewValueEventHandler(GoobizFrame.Windows.MdiUtils.Validator.LookUpEdit_Properties_ProcessNewValue);
            //LocationId_Cuahang_Ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            this.item_Query.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Verify.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Test.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            ds_Role_User = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();
            this.DisplayInfo();
        }

        void LoadMasterData()
        {
            //ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            //ds_Hanghoa_Dinhgia = objWareService.Get_All_Ware_Hanghoa_Ban_Dinhgia().ToDataSet();
            //dsDonvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();

            lookUpEdit_Nhansu_Lap.Properties.DataSource = dsNhansu.Tables[0];
            gridLookUpEdit_Nhansu_Xuat.DataSource = dsNhansu.Tables[0];
            lookupEdit_Nhansu_Bh.Properties.DataSource = dsNhansu.Tables[0];
            lookUpEdit_Nhansu_Lapphieu.Properties.DataSource = dsNhansu.Tables[0];
            //gridLookUpEdit_Donvitinh.DataSource = dsDonvitinh.Tables[0];

            DataSet ds_collection = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            lookupEditKhachhang.Properties.DataSource = ds_collection.Tables[0];
            ds_collection = objMasterService.GetRole_System_Name_ById_User(GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUserId()).ToDataSet();

            DataSet dsCuahang_Ban = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet();
            gridLookUpEdit_Cuahang_Ban_Xuat.DataSource = dsCuahang_Ban.Tables[0];

            //if (ds_collection.Tables[0].Rows.Count > 0 &&
            //    "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
            //{
            //    DataTable temp = dsCuahang_Ban.Tables[0].Copy();
            //    DataRow row = temp.NewRow();
            //    row["Id_Cuahang_Ban"] = -1;
            //    row["Ma_Cuahang_Ban"] = "All";
            //    row["Ten_Cuahang_Ban"] = "Tất cả";
            //    temp.Rows.Add(row);
            //    lookUpEdit_Kho_View.Properties.DataSource = temp;
            //    lookUpEdit_Kho_View.EditValue = -1;
            //}
            //else
            //{
            //    DataSet dsCuahang = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current, true).ToDataSet();
            //    lookUpEdit_Kho_View.Properties.DataSource = dsCuahang.Tables[0];
            //}
            lookUpEdit_Soquy.Properties.DataSource = objMasterService.GetAll_Ware_Dm_Soquy(null).ToDataSet().Tables[0];
            ds_collection = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet();
            lookUpEditKhuvuc.Properties.DataSource = ds_collection.Tables[0];
            //lookUpEditKhuvuc_View.Properties.DataSource = ds_collection.Tables[0];
        }

        void Reload_Chungtu()
        {
            //var id_kho = (Convert.ToInt64() == -1) ? null : lookUpEdit_Kho_View.EditValue;
            ds_Xkbanhang = objWareService.Get_All_Ware_Xuatkho_Banhang_ByCuahang_ByKhachhang(lookUpEdit_Khachang_View.EditValue, dtNgay_Xuatkho.DateTime, lookUpEdit_Kho_View.EditValue).ToDataSet();
            dgware_Hdbanhang.DataSource = ds_Xkbanhang;
            dgware_Hdbanhang.DataMember = ds_Xkbanhang.Tables[0].TableName;
            this.DataBindingControl();
            this.ChangeStatus(false);
            gridView1.SetRowExpanded(-1, true);
            //DisplayInfo_Details();
        }

        #region Event Override

        public override void DisplayInfo()
        {
            try
            {
                DataSet dsCuahang_Ban = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet();
                if (ds_Role_User.Tables[0].Rows.Count > 0 &&
                   "" + ds_Role_User.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
                {
                    item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                    item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                    DataTable temp = dsCuahang_Ban.Tables[0].Copy();
                    DataRow row = temp.NewRow();
                    row["Id_Cuahang_Ban"] = -1;
                    row["Ma_Cuahang_Ban"] = "All";
                    row["Ten_Cuahang_Ban"] = "Tất cả";
                    temp.Rows.Add(row);
                    lookUpEdit_Kho_View.Properties.DataSource = temp;
                    //lookUpEdit_Kho_View.EditValue = -1;

                    temp = objMasterService.Ware_Dm_Cuahang_Ban_Select_Sale().ToDataSet().Tables[0];
                    row = temp.NewRow();
                    row["Id_Cuahang_Ban"] = -1;
                    row["Ma_Cuahang_Ban"] = "All";
                    row["Ten_Cuahang_Ban"] = "Tất cả";
                    temp.Rows.Add(row);
                    lookUpEditKhuvuc_View.Properties.DataSource = temp;
                    //lookUpEditKhuvuc_View.EditValue = Convert.ToInt64(-1);
                }
                else
                {
                    item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                    dsCuahang_Ban = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current, true).ToDataSet();
                    lookUpEdit_Kho_View.Properties.DataSource = dsCuahang_Ban.Tables[0];

                    DataSet dsKhuvuc = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current, false).ToDataSet();
                    lookUpEditKhuvuc_View.Properties.DataSource = dsKhuvuc.Tables[0];
                }
                ResetText();
                LoadMasterData();
                this.ChangeStatus(false);
                this.dtNgay_Xuatkho.EditValue = DateTime.Now;
                if (ds_Xkbanhang.Tables.Count == 0) return;
                //Reload_Chungtu();
                DisplayInfo_Details();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        void DisplayInfo_Details()
        {
            try
            {
                DataBindingControl();
                chungtu_goc = gridView1.GetFocusedRowCellValue("Sochungtu").ToString();
                this.dsPhieuthu_Chitiet = objWareService.Ware_Phieu_Thu_SelectBy_PhieuXuat(chungtu_goc).ToDataSet();
                this.dgware_Hdbanhang_Chitiet.DataSource = dsPhieuthu_Chitiet;
                this.dgware_Hdbanhang_Chitiet.DataMember = dsPhieuthu_Chitiet.Tables[0].TableName;
                gvPhieuthu_Chitiet_FocusedRowChanged(null, null);
                gvPhieuthu_Chitiet.BestFitColumns();
                decimal sotien_dathu = Convert.ToDecimal("0" + gvPhieuthu_Chitiet.Columns["Sotien_Quydoi"].SummaryText);
                txtSotien_Conlai.EditValue = Convert.ToDecimal("0" + txtTongtien_Hang.EditValue) - sotien_dathu;
            }
            catch { }
        }

        public override void ClearDataBindings()
        {
            this.txtSochungtu.DataBindings.Clear();
            //this.txtSotien.DataBindings.Clear();
            //this.txtSotien_Vat.DataBindings.Clear();
            this.txtTongtien_Hang.DataBindings.Clear();
            //this.txtNguoinhan.DataBindings.Clear();
            this.dtNgay_Chungtu.DataBindings.Clear();
            //this.lookUpEdit_Kho_View.DataBindings.Clear();
            this.lookUpEdit_Nhansu_Lap.DataBindings.Clear();
            this.lookupEditKhachhang.DataBindings.Clear();
            lookupEdit_Nhansu_Bh.DataBindings.Clear();
            this.txtGhichu.DataBindings.Clear();
            dtNgaygiao.DataBindings.Clear();
            lookUpEdit_Soquy.DataBindings.Clear();
            lookUpEditKhuvuc.DataBindings.Clear();
        }

        public override void DataBindingControl()
        {
            try
            {                
                this.ClearDataBindings();
                this.txtSochungtu.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Sochungtu");
                //this.txtSotien.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Sotien");
                //this.txtSotien_Vat.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Sotien_Vat");
                this.txtTongtien_Hang.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Thanhtien_NotVAT");
                //this.txtNguoinhan.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Nguoinhan");
                this.dtNgay_Chungtu.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Ngay_Chungtu");
                //this.lookUpEdit_Kho_View.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Cuahang_Ban");
                this.lookUpEdit_Nhansu_Lap.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Nhansu_Edit");
                this.lookupEdit_Nhansu_Bh.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Nhansu_Bh");
                this.lookupEditKhachhang.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Khachhang");
                this.txtGhichu.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Ghichu_Edit");
                dtNgaygiao.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Ngay_Thanhtoan");
                lookUpEditKhuvuc.DataBindings.Add("EditValue", ds_Xkbanhang, ds_Xkbanhang.Tables[0].TableName + ".Id_Khuvuc");
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
            txtNguoi_Nop.Properties.ReadOnly = !editTable;
            txtSotien_Quydoi.Properties.ReadOnly = !editTable;
            txtLydo.Properties.ReadOnly = !editTable;
            dockPanel1_Container.Enabled = !editTable;
            lookUpEdit_Soquy.Properties.ReadOnly = !editTable;
        }

        public override void ResetText()
        {
            this.txtSophieuthu.EditValue = null;
            dtNgaylap_PT.EditValue = null;
            lookUpEdit_Nhansu_Lapphieu.EditValue = null;
            txtNguoi_Nop.EditValue = null;
            txtSotien_Quydoi.EditValue = null;
            txtLydo.EditValue = null;
            txtSotien_Chu.EditValue = null;
        }

        public object InsertObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Phieu_Thu objWare_Phieu_Thu = new Ecm.WebReferences.WareService.Ware_Phieu_Thu();
                objWare_Phieu_Thu.Id_Phieu_Thu = -1;
                objWare_Phieu_Thu.Sochungtu = txtSophieuthu.EditValue;
                objWare_Phieu_Thu.Ngay_Chungtu = dtNgaylap_PT.EditValue;
                objWare_Phieu_Thu.Id_Cuahang_Ban = lookUpEdit_Soquy.EditValue; // id_Soquy
                objWare_Phieu_Thu.Ma_Doituong = null;
                objWare_Phieu_Thu.Ten_Doituong = null;
                objWare_Phieu_Thu.Nguoi_Nop = txtNguoi_Nop.Text;
                objWare_Phieu_Thu.Chungtu_Goc = chungtu_goc;
                objWare_Phieu_Thu.Lydo = "" + txtLydo.EditValue;
                objWare_Phieu_Thu.Id_Tiente = null;
                objWare_Phieu_Thu.Id_Khachhang = lookupEditKhachhang.EditValue;
                if ("" + lookUpEdit_Nhansu_Lapphieu.EditValue != "")
                    objWare_Phieu_Thu.Id_Nhansu_Lapphieu = lookUpEdit_Nhansu_Lapphieu.EditValue;

                objWare_Phieu_Thu.Id_Kho_Hanghoa_Mua = null;
                objWare_Phieu_Thu.Sotien_Quydoi = txtSotien_Quydoi.EditValue;
                objWareService.Insert_Ware_Phieu_Thu(objWare_Phieu_Thu);
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        public object UpdateObject()
        {
            try
            {
                Ecm.WebReferences.WareService.Ware_Phieu_Thu objWare_Phieu_Thu = new Ecm.WebReferences.WareService.Ware_Phieu_Thu();
                objWare_Phieu_Thu.Id_Phieu_Thu = gvPhieuthu_Chitiet.GetFocusedRowCellValue("Id_Phieuthu");
                objWare_Phieu_Thu.Sochungtu = txtSophieuthu.EditValue;
                objWare_Phieu_Thu.Ngay_Chungtu = dtNgaylap_PT.EditValue;
                objWare_Phieu_Thu.Id_Cuahang_Ban = lookUpEdit_Soquy.EditValue; // id_Soquy
                objWare_Phieu_Thu.Ma_Doituong = null;
                objWare_Phieu_Thu.Ten_Doituong = null;
                objWare_Phieu_Thu.Nguoi_Nop = txtNguoi_Nop.Text;
                objWare_Phieu_Thu.Chungtu_Goc = chungtu_goc;
                objWare_Phieu_Thu.Lydo = "" + txtLydo.EditValue;
                objWare_Phieu_Thu.Id_Tiente = null;
                objWare_Phieu_Thu.Id_Khachhang = lookupEditKhachhang.EditValue;
                if ("" + lookUpEdit_Nhansu_Lapphieu.EditValue != "")
                    objWare_Phieu_Thu.Id_Nhansu_Lapphieu = lookUpEdit_Nhansu_Lapphieu.EditValue;
                objWare_Phieu_Thu.Id_Kho_Hanghoa_Mua = null;
                objWare_Phieu_Thu.Sotien_Quydoi = txtSotien_Quydoi.EditValue;
                objWareService.Update_Ware_Phieu_Thu(objWare_Phieu_Thu);
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        public object DeleteObject()
        {
            Ecm.WebReferences.WareService.Ware_Phieu_Thu objWare_Phieu_Thu = new Ecm.WebReferences.WareService.Ware_Phieu_Thu();
            objWare_Phieu_Thu.Id_Phieu_Thu = gvPhieuthu_Chitiet.GetFocusedRowCellValue("Id_Phieuthu");
            return objWareService.Delete_Ware_Phieu_Thu(objWare_Phieu_Thu);
        }

        public override bool PerformAdd()
        {
            if (gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu xuất, vui lòng chọn lại");
                return false;
            }
            try
            {
                lookUpEdit_Soquy.Properties.DataSource = objMasterService.GetAll_Ware_Dm_Soquy_By_Id_Nhansu(id_nhansu_current).ToDataSet().Tables[0];
                this.ResetText();
                //Kiểm tra nếu nhân viên login không tồn tại trong kho hàng hóa mua thì access denied.
                //DataSet ds_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Banhang.EditValue).ToDataSet();
                //this.lookUpEdit_Cuahang_Ban.Properties.DataSource = ds_Cuahang_Ban.Tables[0];
                //if (ds_Cuahang_Ban.Tables[0].Rows.Count > 0)
                //    lookUpEdit_Cuahang_Ban.EditValue = ds_Cuahang_Ban.Tables[0].Rows[0]["Id_Cuahang_Ban"];
                //else
                //{
                //    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                //    lookUpEdit_Nhansu_Banhang.EditValue = null;
                //    return false;
                //}
                ClearDataBindings_Phieuthu();
                this.ChangeStatus(true);

                lookUpEdit_Nhansu_Lapphieu.EditValue = Convert.ToInt64(id_nhansu_current);
                dtNgaylap_PT.EditValue = objWareService.GetServerDateTime();
                txtSophieuthu.EditValue = objWareService.GetNew_Sochungtu("ware_phieu_thu", "sochungtu", "THU");
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        public override bool PerformEdit()
        {
            try
            {
                if (gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang") == null)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu xuất, vui lòng chọn lại");
                    return false;
                }
                if ("" + gvPhieuthu_Chitiet.GetFocusedRowCellValue("Id_Phieuthu") == "")
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu thu, vui lòng chọn lại");
                    return false;
                }
                //Ecm.WebReferences.WareService.DocumentProcessStatus DocumentProcessStatus = new Ecm.WebReferences.WareService.DocumentProcessStatus();
                //DocumentProcessStatus.Tablename = "ware_xuat_hh_ban";
                //DocumentProcessStatus.PK_Name = "id_xuat_hh_ban";
                //DocumentProcessStatus.Identity = gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang");
                //DocumentProcessStatus = objWareService.Get_DocumentProcessStatus(DocumentProcessStatus);
                //if (objWareService.GetEDocumentProcessStatus((int)DocumentProcessStatus.Doc_Process_Status) != Ecm.WebReferences.WareService.EDocumentProcessStatus.NewDoc)
                //{
                //    GoobizFrame.Windows.Forms.UserMessage.Show("TASK_VERIFIED", new string[] { });
                //    return false;
                //}5
                //ds_Xuat_Hhban = objWareService.Get_All_Ware_Xuat_Hh_Ban();
                if (Convert.ToInt64(gridView1.GetFocusedRowCellValue("Doc_Process_Status")) == 0)
                {
                    lookUpEdit_Nhansu_Lap.EditValue = Convert.ToInt64(id_nhansu_current);
                    this.ChangeStatus(true);
                }
                else
                    if (ds_Role_User.Tables[0].Rows.Count > 0 &&
                    "" + ds_Role_User.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
                    {
                        //DateTime ngay_chungtu = dtNgay_Chungtu.DateTime;
                        //ds_Xuat_Hhban = objWareService.Get_All_Ware_Nxt_HhBan(new DateTime(ngay_chungtu.Year, ngay_chungtu.Month, ngay_chungtu.Day, 0, 0, 0)
                        //    , new DateTime(ngay_chungtu.Year, ngay_chungtu.Month, ngay_chungtu.Day, 23, 0, 0)
                        //    , lookUpEdit_Kho_View.EditValue).ToDataSet();
                        //DataSet ds_Cuahang_Ban = objMasterService.Get_All_Ware_Dm_Cuahang_Ban_By_Id_Nhansu(lookUpEdit_Nhansu_Nhap.EditValue);
                        //this.lookUpEdit_Cuahang_Ban_Xuat.Properties.DataSource = ds_Cuahang_Ban.Tables[0];
                        //if (ds_Cuahang_Ban.Tables[0].Rows.Count == 0)
                        //{
                        //     GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                        //    lookUpEdit_Nhansu_Nhap.EditValue = null;
                        //    return false;
                        //}
                        lookUpEdit_Nhansu_Lap.EditValue = Convert.ToInt64(id_nhansu_current);
                        this.ChangeStatus(true);
                    }
                    else
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show("Phiếu xuất kho đã xuất, nên không thể thao tác.\nVui lòng liên hệ admin");
                        return false;
                    }


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
                GoobizFrame.Windows.Public.OrderHashtable htbControl1 = new GoobizFrame.Windows.Public.OrderHashtable();
                htbControl1.Add(txtNguoi_Nop, lblNguoi_Nop.Text);
                htbControl1.Add(txtLydo, lblLydo.Text);
                htbControl1.Add(txtSotien_Quydoi, lblSotien_Quydoi.Text);

                if (!GoobizFrame.Windows.MdiUtils.Validator.CheckNullFields(htbControl1))
                    return false;

                //try
                //{
                //    ds_Xkbanhang_Chitiet.Tables[0].Constraints.Clear();
                //    Constraint constraint = new UniqueConstraint("constraint1",
                //            new DataColumn[] {ds_Xkbanhang_Chitiet.Tables[0].Columns["Id_Hanghoa_Ban"],
                //            ds_Xkbanhang_Chitiet.Tables[0].Columns["Id_Donvitinh"] }, false);
                //    ds_Xkbanhang_Chitiet.Tables[0].Constraints.Add(constraint);
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
                if (gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang") == null)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu xuất, vui lòng chọn lại");
                    return false;
                }
                if ("" + gvPhieuthu_Chitiet.GetFocusedRowCellValue("Id_Phieuthu") == "")
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu thu, vui lòng chọn lại");
                    return false;
                }
                //if ( GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentUser().ToUpper() != "ADMIN")
                //if (!id_nhansu_current.Equals("" + lookUpEdit_Nhansu_Lap.EditValue))
                //{
                //    GoobizFrame.Windows.Forms.UserMessage.Show("ACCESS_DENIED", new string[] { });
                //    return false;
                //}
                if (ds_Role_User.Tables[0].Rows.Count > 0 &&
                                            "" + ds_Role_User.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")

                    if (GoobizFrame.Windows.Forms.UserMessage.Show("Msg00004", new string[]  {
                     GoobizFrame.Windows.Forms.UserMessage.GetTableDescription("Ware_Phieu_Thu"),
                     GoobizFrame.Windows.Forms.UserMessage.GetTableRelations("Ware_Phieu_Thu")   }) == DialogResult.Yes)
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
                return true;
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
            //            Ecm.WebReferences.WareService.Ware_Xuatkho_Banhang ware_xuatkho_banhang = new Ecm.WebReferences.WareService.Ware_Xuatkho_Banhang();
            //            try
            //            {
            //                int focusedRow = gridView1.GetDataSourceRowIndex(gridView1.FocusedRowHandle);
            //                DataRow dr = ds_Xkbanhang.Tables[0].Rows[focusedRow];
            //                if (dr != null)
            //                {
            //                    ware_xuatkho_banhang.Id_Xuatkho_Banhang = dr["Id_Xuatkho_Banhang"];
            //                    ware_xuatkho_banhang.Sochungtu = dr["Sochungtu"];
            //                    ware_xuatkho_banhang.Ngay_Chungtu_Xuat = dr["Ngay_Chungtu_Xuat"];
            //                    ware_xuatkho_banhang.Id_Cuahang_Ban_Xuat = dr["Id_Cuahang_Ban_Xuat"];
            //                    ware_xuatkho_banhang.Id_Nhansu_Xuat = dr["Id_Nhansu_Xuat"];
            //                    ware_xuatkho_banhang.Ghichu = dr["Ghichu"];
            //                }
            //                this.Dispose();
            //                this.Close();
            //                return ware_xuatkho_banhang;
            //            }
            //            catch (Exception ex)
            //            {
            //#if DEBUG
            //                MessageBox.Show(ex.Message);
            //#endif
            return null;
            //            }
        }

        public override bool PerformPrintPreview()
        {
            if (gridView1.GetFocusedRowCellValue("Id_Xuatkho_Banhang") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu xuất, vui lòng chọn lại");
                return false;
            }

            if (gvPhieuthu_Chitiet.GetFocusedRowCellValue("Id_Phieu_Thu") == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn phiếu thu, vui lòng chọn lại");
                return false;
            }
            //_id_phieuthu = gvPhieuthu_Chitiet.GetFocusedRowCellValue("Id_Phieu_Thu");
            //if ("" + _id_phieuthu != "")
            //{
            Reports.rptPhieu_Thu rptPhieu_Thu = new Ecm.Ware.Reports.rptPhieu_Thu();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();
            frmPrintPreview.Report = rptPhieu_Thu;

            //add parameter values
            rptPhieu_Thu.tbcDiachi.Text = txtDiachi.Text;
            rptPhieu_Thu.tbcLydo.Text = txtLydo.Text;
            rptPhieu_Thu.tbcNam.Text = "" + dtNgay_Chungtu.DateTime.Year;
            rptPhieu_Thu.tbcThang.Text = "" + dtNgay_Chungtu.DateTime.Month;
            rptPhieu_Thu.tbcNgay.Text = "" + dtNgay_Chungtu.DateTime.Day;
            rptPhieu_Thu.tbcNguoi_Noptien.Text = txtNguoi_Nop.Text;
            rptPhieu_Thu.tbcNguoi_Noptien_Kyten.Text = "" + txtNguoi_Nop.Text;
            rptPhieu_Thu.tbcNhansu_Lapphieu.Text = "" + lookUpEdit_Nhansu_Lapphieu.Text;
            rptPhieu_Thu.tbcGhichu.Text = "" + txtSochungtu.Text;
            rptPhieu_Thu.tbcSochungtu.Text = txtSophieuthu.Text;
            rptPhieu_Thu.tbcSotien.Text = string.Format("{0:#,#}", txtSotien_Quydoi.EditValue);
            double sotien = Convert.ToDouble(txtSotien_Quydoi.EditValue);
            string str = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(sotien, " đồng.");
            str = str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
            rptPhieu_Thu.tbcSotien_Bangchu.Text = str;
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

                rptPhieu_Thu.xrc_CompanyName.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyName"));
                rptPhieu_Thu.xrc_CompanyAddress.DataBindings.Add(
                    new DevExpress.XtraReports.UI.XRBinding("Text", dsCompany_Paras, dsCompany_Paras.Tables[0].TableName + ".CompanyAddress"));
            }

            #endregion

            rptPhieu_Thu.CreateDocument();
            GoobizFrame.Windows.Forms.ReportOptions oReportOptions = GoobizFrame.Windows.Forms.ReportOptions.GetReportOptions(rptPhieu_Thu);
            if (Convert.ToBoolean(oReportOptions.PrintPreview))
            {
                frmPrintPreview.Text = "" + oReportOptions.Caption;
                frmPrintPreview.printControl1.PrintingSystem = rptPhieu_Thu.PrintingSystem;
                frmPrintPreview.MdiParent = this.MdiParent;
                frmPrintPreview.Show();
                frmPrintPreview.Activate();
            }
            else
            {
                var reportPrintTool = new DevExpress.XtraReports.UI.ReportPrintTool(rptPhieu_Thu);
                reportPrintTool.Print();
            }

            return base.PerformPrintPreview();
            //}
        }

        #endregion

        #region Even

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
                        gvPhieuthu_Chitiet.SetFocusedRowCellValue(gvPhieuthu_Chitiet.Columns["Id_Hanghoa_Ban"]
                            , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Hanghoa_Ban"]);
                        gvPhieuthu_Chitiet.SetFocusedRowCellValue(gvPhieuthu_Chitiet.Columns["Id_Donvitinh"]
                            , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Id_Donvitinh"]);
                        gvPhieuthu_Chitiet.SetFocusedRowCellValue(gvPhieuthu_Chitiet.Columns["Dongia_Ban"]
                            , frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[0]["Dongia_Ban"]);
                        //object Id_Cuahang_Ban = gridView1.GetFocusedRowCellValue("Id_Cuahang_Ban");
                        if (frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length > 1)
                        {
                            for (int i = 1; i < frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows.Length; i++)
                            {
                                DataRow nrow = dsPhieuthu_Chitiet.Tables[0].NewRow();
                                //nrow["Id_Cuahang_Ban"] = Id_Cuahang_Ban;
                                nrow["Id_Hanghoa_Ban"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Hanghoa_Ban"];
                                nrow["Id_Donvitinh"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Id_Donvitinh"];
                                nrow["Dongia"] = frmware_Dm_Hanghoa_Ban_Dialog.SelectedRows[i]["Dongia_Ban"];
                                dsPhieuthu_Chitiet.Tables[0].Rows.Add(nrow);
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

        private void gridView5_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (gvPhieuthu_Chitiet.GetFocusedDataRow() == null) return;

                switch (e.Column.FieldName)
                {

                }

                gvPhieuthu_Chitiet.BestFitColumns();
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
            if (gridView1.FocusedRowHandle >= 0 && "" + gridView1.GetFocusedRowCellValue("Sochungtu") != "")
            {
                chungtu_goc = gridView1.GetFocusedRowCellValue("Sochungtu").ToString();
                DisplayInfo_Details();
            }
            else
                ResetText();
        }

        private void lookupEditKhachhang_EditValueChanged(object sender, EventArgs e)
        {
            if (lookupEditKhachhang.EditValue != null)
                this.txtDiachi.EditValue = lookupEditKhachhang.GetColumnValue("Diachi_Khachhang");
            else
                this.txtDiachi.EditValue = null;
        }

        private void btnDonhang_Click(object sender, EventArgs e)
        {
            if (lookupEditKhachhang.EditValue == null)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn Khách hàng, vui lòng chọn lại");
                return;
            }
            Frmware_Hdbanhang_noVAT_Hhban frmDonhang = new Frmware_Hdbanhang_noVAT_Hhban(lookupEditKhachhang.EditValue);
            frmDonhang.item_Select.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            frmDonhang.gridColumnChon.Visible = true;
            frmDonhang.gridColumnChon.VisibleIndex = 0;
            frmDonhang.ShowDialog();
            if (frmDonhang._selectedRows != null && frmDonhang._selectedRows.Length > 0)
            {
                Fill_Dondathang(frmDonhang._selectedRows);
                //txtTongtien_Hang.EditValue = gvPhieuthu_Chitiet.Columns["Sotien_Quydoi"].SummaryText;
            }
        }

        private void Fill_Dondathang(DataRow[] sdrware_DonDatHang_Chitiet)
        {
            try
            {
                foreach (DataRow dtr in sdrware_DonDatHang_Chitiet)
                {
                    // Add nhap vattu chi tiet 
                    DataRow rNha_Chitiet = dsPhieuthu_Chitiet.Tables[0].NewRow();
                    rNha_Chitiet["Id_Hanghoa_Ban"] = dtr["Id_Hanghoa_Ban"];
                    rNha_Chitiet["Id_Donvitinh"] = dtr["Id_Donvitinh"];
                    rNha_Chitiet["Barcode_Txt"] = dtr["Barcode_Txt"];
                    rNha_Chitiet["Soluong"] = dtr["Soluong"];
                    //rNha_Chitiet["Ten_Mathang"] = dtr["Ten_Mathang"];
                    //rNha_Chitiet["Ten_Donvitinh"] = dtr["Ten_Donvitinh"];
                    rNha_Chitiet["Dongia_Ban"] = dtr["Dongia_Ban"];
                    rNha_Chitiet["Thanhtien"] = dtr["Thanhtien"];
                    dsPhieuthu_Chitiet.Tables[0].Rows.Add(rNha_Chitiet);
                }
            }
            catch (Exception ex)
            { ex.ToString(); }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Reload_Chungtu();
        }

        #endregion

        private void gvPhieuthu_Chitiet_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataBindingControl_Phieuthu();
        }

        public void DataBindingControl_Phieuthu()
        {
            try
            {
                this.ClearDataBindings_Phieuthu();
                this.txtSophieuthu.DataBindings.Add("EditValue", dsPhieuthu_Chitiet, dsPhieuthu_Chitiet.Tables[0].TableName + ".Sochungtu");
                dtNgaylap_PT.DataBindings.Add("EditValue", dsPhieuthu_Chitiet, dsPhieuthu_Chitiet.Tables[0].TableName + ".Ngay_Chungtu");
                lookUpEdit_Nhansu_Lapphieu.DataBindings.Add("EditValue", dsPhieuthu_Chitiet, dsPhieuthu_Chitiet.Tables[0].TableName + ".Id_Nhansu_Lapphieu");
                txtNguoi_Nop.DataBindings.Add("EditValue", dsPhieuthu_Chitiet, dsPhieuthu_Chitiet.Tables[0].TableName + ".Nguoi_Nop");
                txtSotien_Quydoi.DataBindings.Add("EditValue", dsPhieuthu_Chitiet, dsPhieuthu_Chitiet.Tables[0].TableName + ".Sotien_Quydoi");
                txtLydo.DataBindings.Add("EditValue", dsPhieuthu_Chitiet, dsPhieuthu_Chitiet.Tables[0].TableName + ".Lydo");
                lookUpEdit_Soquy.DataBindings.Add("EditValue", dsPhieuthu_Chitiet, dsPhieuthu_Chitiet.Tables[0].TableName + ".Id_Cuahang_Ban"); // id_Soquy
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ClearDataBindings_Phieuthu()
        {
            this.txtSophieuthu.DataBindings.Clear();
            dtNgaylap_PT.DataBindings.Clear();
            lookUpEdit_Nhansu_Lapphieu.DataBindings.Clear();
            txtNguoi_Nop.DataBindings.Clear();
            txtSotien_Quydoi.DataBindings.Clear();
            txtLydo.DataBindings.Clear();
            lookUpEdit_Soquy.DataBindings.Clear();
        }

        private void txtSotien_Quydoi_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if ("" + txtSotien_Quydoi.EditValue != "")
                {
                    decimal sotien1 = Convert.ToDecimal(txtSotien_Quydoi.EditValue);
                    if (txtSotien_Quydoi.Text != "")
                    {
                        double sotien = Convert.ToDouble(txtSotien_Quydoi.EditValue);
                        txtSotien_Chu.Text = GoobizFrame.Windows.HelperClasses.ReadNumber.ChangeNum2VNStr(sotien, " đồng.");
                    }
                    else
                        txtSotien_Chu.Text = "";
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Số tiền không hợp lý, vui lòng nhập lại!");
                txtSotien_Quydoi.Text = @"0";
            }
        }

        private void lookUpEditKhuvuc_View_EditValueChanged(object sender, EventArgs e)
        {
            lookUpEdit_Khachang_View.Properties.DataSource = objMasterService.Ware_Dm_Khachhang_SelectBy_Khuvuc(lookUpEditKhuvuc_View.EditValue).ToDataSet().Tables[0];
        }

        private void lookUpEdit_Khachang_View_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lookUpEdit_Khachang_View.EditValue = null;
        }

    }
}