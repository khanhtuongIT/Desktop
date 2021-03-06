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
    public partial class Frmware_Xuat_Hh_Ban_Dialog : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        public Ecm.WebReferences.Classes.WareService objWareService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.WareService>();
        public Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        public Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        DataSet ds_Xkbanhang = new DataSet();
        DataSet ds_Xkbanhang_Chitiet = new DataSet();
        DataSet ds_Hanghoa_Dinhgia = new DataSet();
        DataSet dsDonvitinh = new DataSet();
        object identity;
        object id_nhansu_current;
        object id_hdban_hang;
        private bool ok;
        public bool Ok
        {
            get { return ok ; }
            set { ok = value; }
        }

        public Frmware_Xuat_Hh_Ban_Dialog(object Id_Hdbanhang)
        {
            InitializeComponent();
            id_hdban_hang = Id_Hdbanhang;
            //date mask
            //LocationId_Cuahang_Ban = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetLocation("Id_Cuahang_Ban");
            id_nhansu_current = GoobizFrame.Windows.MdiUtils.ThemeSettings.GetCurrentId_Nhansu();
            this.item_Query.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Verify.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Test.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Cancel.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Edit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Save.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_PrintPreview.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            item_Refresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barSystem.Visible = false;
            //ds_Role_User = objMasterService.GetRole_System_Name_ById_User(id_nhansu_current).ToDataSet();
            this.DisplayInfo();
        }

        void LoadMasterData()
        {
            //ds_Hanghoa_Ban = objMasterService.Get_All_Ware_Dm_Hanghoa_Ban().ToDataSet();
            //dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            //ds_Hanghoa_Dinhgia = objWareService.Get_All_Ware_Hanghoa_Ban_Dinhgia().ToDataSet();
            //dsDonvitinh = objMasterService.Get_All_Ware_Dm_Donvitinh().ToDataSet();

            ////gridLookUpEdit_Hanghoa_Mua
            //gridLookUpEdit_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            //gridLookUpEdit_Ma_Hanghoa_Ban.DataSource = ds_Hanghoa_Ban.Tables[0];
            ////lookUpEdit_Nhansu_Kk
            //lookUpEdit_Nhansu_Banhang.Properties.DataSource = dsNhansu.Tables[0];
            //gridLookUpEdit_Nhansu_Xuat.DataSource = dsNhansu.Tables[0];
            //gridLookUpEdit_Donvitinh.DataSource = dsDonvitinh.Tables[0];
            //DataSet ds_Khachhang = objMasterService.Get_All_Ware_Dm_Khachhang().ToDataSet();
            //lookupEditKhachhang.Properties.DataSource = ds_Khachhang.Tables[0];

            DataSet dsCuahang_Ban = objMasterService.Ware_Dm_Cuahang_Ban_Select_Kho().ToDataSet();
            //gridLookUpEdit_Cuahang_Ban_Xuat.DataSource = dsCuahang_Ban.Tables[0];

            DataSet ds_collection = objMasterService.GetRole_System_Name_ById_User(id_nhansu_current).ToDataSet();
            if (ds_collection.Tables[0].Rows.Count > 0 &&
                "" + ds_collection.Tables[0].Rows[0]["Role_System_Name"] == "Administrators")
            {
                DataTable temp = dsCuahang_Ban.Tables[0].Copy();
                DataRow row = temp.NewRow();
                row["Id_Cuahang_Ban"] = -1;
                row["Ma_Cuahang_Ban"] = "All";
                row["Ten_Cuahang_Ban"] = "Tất cả";
                temp.Rows.Add(row);
                lookUpEdit_Kho_View.Properties.DataSource = temp;
                lookUpEdit_Kho_View.EditValue = -1;
            }
            else
            {
                DataSet dsCuahang = objWareService.Get_Ware_Ql_Cuahang_Ban_By_Id_Nhansu(id_nhansu_current, true).ToDataSet();
                lookUpEdit_Kho_View.Properties.DataSource = dsCuahang.Tables[0];
            }
        }

        public override void DisplayInfo()
        {
            try
            {
                lookUpEdit_Kho_View.EditValue = null;
                LoadMasterData();
                //Reload_Chungtu();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message);
#endif
            }
        }

        public object InsertObject()
        {
            try
            {
                DataSet dsHoadon_Banhang = objWareService.Get_All_Ware_Hdbanhang_ById_Hdbanhang(id_hdban_hang).ToDataSet();
                DataSet ds_Hoadon_Banhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(id_hdban_hang).ToDataSet();

                Ecm.WebReferences.WareService.Ware_Xuatkho_Banhang objWare_Xuatkho_Banhang = new Ecm.WebReferences.WareService.Ware_Xuatkho_Banhang();
                objWare_Xuatkho_Banhang.Id_Xuatkho_Banhang = -1;
                //objWare_Xuatkho_Banhang.Sochungtu = objWareService.Getnew_Sohoadon_XuatkhoBh(
                //    ((DataRowView)lookUpEdit_Kho_View.Properties.GetDataSourceRowByKeyValue(lookUpEdit_Kho_View.EditValue))["Ma_Cuahang_Ban"]);
                objWare_Xuatkho_Banhang.Sochungtu = dsHoadon_Banhang.Tables[0].Rows[0]["Sochungtu"];
                objWare_Xuatkho_Banhang.Sotien = ds_Hoadon_Banhang_Chitiet.Tables[0].Compute("Sum(Thanhtien)", "");
                objWare_Xuatkho_Banhang.Ngay_Chungtu = objWareService.GetServerDateTime();
                objWare_Xuatkho_Banhang.Ngay_Thanhtoan = dsHoadon_Banhang.Tables[0].Rows[0]["Ngay_Thutien"];  // dùng ngày thanh toán -> ngày thu tiền
                objWare_Xuatkho_Banhang.Nguoinhan = null; // (txtNguoinhan.Text == "") ? null : txtNguoinhan.EditValue;
                objWare_Xuatkho_Banhang.Per_Chietkhau = 0;
                objWare_Xuatkho_Banhang.Thanhtien_Chietkhau = 0;
                objWare_Xuatkho_Banhang.Sotien_Vat = "0";// + txtSotien_Vat.EditValue;
                objWare_Xuatkho_Banhang.Id_Cuahang_Ban = lookUpEdit_Kho_View.EditValue;
                objWare_Xuatkho_Banhang.Id_Nhansu_Bh = dsHoadon_Banhang.Tables[0].Rows[0]["Id_Nhansu_Bh"];
                objWare_Xuatkho_Banhang.Id_Khachhang = dsHoadon_Banhang.Tables[0].Rows[0]["Id_Khachhang"];
                objWare_Xuatkho_Banhang.Id_Hdbanhang = dsHoadon_Banhang.Tables[0].Rows[0]["Id_Hdbanhang"];
                objWare_Xuatkho_Banhang.Ghichu_Edit = "" + dsHoadon_Banhang.Tables[0].Rows[0]["Ghichu_Edit"];
                identity = objWareService.Insert_ware_xuatkho_banhang(objWare_Xuatkho_Banhang);

                ds_Xkbanhang_Chitiet = objWareService.Get_All_Ware_Xuatkho_Banhang_Chitiet_By_Id_Xuatkho_Banhang(-1).ToDataSet();
                if (identity != null)
                {
                    foreach (DataRow dr in ds_Hoadon_Banhang_Chitiet.Tables[0].Rows)
                    {
                        DataRow row = ds_Xkbanhang_Chitiet.Tables[0].NewRow();
                        row["Id_Xuatkho_Banhang"] = identity;
                        row["Id_Hanghoa_Ban"] = dr["Id_Hanghoa_Ban"];
                        row["Id_Donvitinh"] = dr["Id_Donvitinh"];
                        row["Soluong"] = dr["Soluong"];
                        row["Dongia_Ban"] = dr["Dongia_Ban"];
                        row["Thanhtien"] = dr["Thanhtien"];
                        row["Per_VAT"] = dr["Per_Dongia"];
                        ds_Xkbanhang_Chitiet.Tables[0].Rows.Add(row);
                    }
                    objWareService.Update_Ware_Xuatkho_Banhang_Chitiet_Collection(ds_Xkbanhang_Chitiet);
                    ds_Xkbanhang_Chitiet = objWareService.Get_All_Ware_Xuatkho_Banhang_Chitiet_By_Id_Xuatkho_Banhang(identity).ToDataSet();
                    foreach (DataRow row in ds_Xkbanhang_Chitiet.Tables[0].Rows)
                    {
                        objWareService.Insert_Ware_Nhap_Xuat_Chitiet(row["Id_Xuatkho_Banhang_Chitiet"], null, row["Id_Hanghoa_Ban"]);
                    }
                    ok = true;
                }
                return true;
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
                return false;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (lookUpEdit_Kho_View.EditValue == null || Convert.ToInt64(lookUpEdit_Kho_View.EditValue) == -1)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show("Chưa chọn kho, vui lòng chọn lại");
                lookUpEdit_Kho_View.Focus();
                return;
            }
            try
            {
                DataSet ds_Hdbanhang_Chitiet = objWareService.Get_All_Ware_Hdbanhang_Chitiet_By_Hdbanhang(id_hdban_hang).ToDataSet();
                DataSet dsTonkho;
                DateTime current_date = objWareService.GetServerDateTime();
                int today = 1;
                if (current_date.Day == 1)
                    today = 1;
                else
                    today = current_date.Day - 1;
                bool check = false;
                decimal sl_ton = 0;
                DateTime a = new  DateTime(current_date.Year, current_date.Month, today, 0, 0, 0);
                foreach (DataRow row in ds_Hdbanhang_Chitiet.Tables[0].Rows)
                {
                    if ("" + row["Id_Hanghoa_Ban"] == "" || "" + row["Id_Donvitinh"] == "") continue;
                    dsTonkho = objWareService.Rptware_Nxt_Hhban_Qdoi(new DateTime(current_date.Year, current_date.Month, today, 0, 0, 0),
                                                                            current_date, lookUpEdit_Kho_View.EditValue, row["Id_Hanghoa_Ban"], row["Id_Donvitinh"]).ToDataSet();
                    if (dsTonkho.Tables[0].Rows.Count > 0)
                    {
                        if (Convert.ToDecimal(dsTonkho.Tables[0].Rows[0]["Soluong_Ton"]) >= Convert.ToDecimal("0" + row["Soluong"]))
                            check = true;
                        else
                        {
                            sl_ton = Convert.ToDecimal(dsTonkho.Tables[0].Rows[0]["Soluong_Ton"]);
                            check = false;
                        }
                    }
                    else
                        check = false;
                    if (!check)
                    {
                        GoobizFrame.Windows.Forms.MessageDialog.Show(row["Ten_Hanghoa_Ban"].ToString() + " không đủ số lượng xuất\nSố lượng tồn kho là: " + sl_ton.ToString() + "\nVui lòng kiểm tra lại");
                        Ecm.WebReferences.WareService.Ware_Hdbanhang objWare_Hdbanhang = new Ecm.WebReferences.WareService.Ware_Hdbanhang();
                        objWare_Hdbanhang.Id_Hdbanhang = id_hdban_hang;
                        objWare_Hdbanhang.Doc_Process_Status = 1;
                        objWareService.Ware_Hdbanhang_Update_Doc(objWare_Hdbanhang);
                        return;
                    }
                }
                InsertObject();
                this.Dispose();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Ecm.WebReferences.WareService.Ware_Hdbanhang objWare_Hdbanhang = new Ecm.WebReferences.WareService.Ware_Hdbanhang();
            objWare_Hdbanhang.Id_Hdbanhang = id_hdban_hang;
            objWare_Hdbanhang.Doc_Process_Status = 1;
            objWareService.Ware_Hdbanhang_Update_Doc(objWare_Hdbanhang);
            ok = false;
            Dispose();
        }

    }
}