using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;using GoobizFrame.Windows.Forms;
using DevExpress.XtraEditors;

namespace Ecm.Rex.Forms
{
    public partial class Frmrex_Hopdong_Laodong_InfoBP : GoobizFrame.Windows.Forms.FormUpdateWithToolbar
    {
        Ecm.WebReferences.Classes.RexService objRexService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.RexService>();
        Ecm.WebReferences.Classes.MasterService objMasterService = Ecm.WebReferences.Instance.GetService<Ecm.WebReferences.Classes.MasterService>();
        DataSet ds_Hopdong_Laodong = new DataSet();
        DataSet ds_Loai_HDLD;
        DataSet dsDm_Heso_Chuongtrinh_Company;
        DataSet dsHsct_Hopdonglaodonginfo;

        public object Id_Nhansu_Sd
        {
            get
            {
                var sdrHeso = dsDm_Heso_Chuongtrinh_Company.Tables[0].Select("Ma_Heso_Chuongtrinh='CompanyRepresented'");
                string str_CompanyRepresented = sdrHeso[0]["Heso"].ToString().Split(new char[] { '|' })[0];
                long CompanyRepresented = Convert.ToInt64("0" + str_CompanyRepresented);
                return CompanyRepresented;
            }
        }


        private object id_bophan;
        public object Id_Bophan
        {
            get { return id_bophan; }
            set { id_bophan = value; this.DisplayInfo(); }
        }


        public Frmrex_Hopdong_Laodong_InfoBP()
        {
            InitializeComponent();

            this.item_Add.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.item_Delete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            dsDm_Heso_Chuongtrinh_Company = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso("Company").ToDataSet();

            dsHsct_Hopdonglaodonginfo = objMasterService.Get_Rex_Dm_Heso_Chuongtrinh_By_Nhomheso("Hopdonglaodonginfo").ToDataSet();
            dgHeso_Chuongtrinh.DataSource = dsHsct_Hopdonglaodonginfo.Tables[0];

        }

        private void dg_Phucap_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {

        }

        private void DisplayInfo_Nhansu_Nsd()
        {
            foreach (DataRow drHopdong in ds_Hopdong_Laodong.Tables[0].Rows)
                drHopdong["Id_Nhansu_Nsd"] = (""+drHopdong["Id_Nhansu_Nsd"]=="") ? Id_Nhansu_Sd : drHopdong["Id_Nhansu_Nsd"];
        }

        #region override

        public override void DisplayInfo()
        {
            DataSet dsNhansu = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet();
            DataSet dsQuocgia = objMasterService.Get_All_Rex_Dm_Quocgia_Collection().ToDataSet();
            DataSet dsChucvu = objMasterService.Get_All_Rex_Dm_Chucvu_Collection().ToDataSet();
            txtTen_Nhansu_B.Properties.DataSource = dsNhansu.Tables[0];
            lookUpEdit_Quoctich_Nhansu_A.Properties.DataSource = dsQuocgia.Tables[0];
            lookUp_Chucvu_Nhansu_A.Properties.DataSource = dsChucvu.Tables[0];
            lookUpEdit_Quoctich_Nhansu_B.Properties.DataSource = dsQuocgia.Tables[0];
            lookUp_Chuyenmon_Nhansu_B.Properties.DataSource = objMasterService.Get_All_Rex_Dm_Chuyenmon_Collection().ToDataSet().Tables[0];
            lookUp_Loai_Hopdong.Properties.DataSource = objMasterService.Get_All_Rex_Dm_Loai_Hopdong_Collection().ToDataSet().Tables[0];
            lookUp_Chucvu_Nhansu_B.Properties.DataSource = dsChucvu.Tables[0];
            lookUp_Bacluong.Properties.DataSource = objMasterService.Get_All_Rex_Dm_Bacluong_Collection().ToDataSet().Tables[0];
            lookUp_Phuongthuc_Huongluong.Properties.DataSource = objMasterService.Get_All_Rex_Dm_Phuongthuc_Huongluong_Collection().ToDataSet().Tables[0];
            ds_Loai_HDLD = objMasterService.Get_All_Rex_Dm_Loai_Hopdong_Collection().ToDataSet();
            lookUp_Loai_Hopdong.Properties.DataSource = ds_Loai_HDLD.Tables[0];
            gridLookUp_Loai_Hopdong.DataSource = ds_Loai_HDLD.Tables[0];


            gridLookUp_Nhansu.DataSource = objRexService.Get_All_Rex_Nhansu_Collection().ToDataSet().Tables[0];

            ds_Hopdong_Laodong = objRexService.GetAll_Rex_Hopdong_Laodong_ByBophan(id_bophan, DateTime.Now).ToDataSet();
            dgrex_Hopdong_Laodong.DataSource = ds_Hopdong_Laodong;
            dgrex_Hopdong_Laodong.DataMember = ds_Hopdong_Laodong.Tables[0].TableName;

            txtCongty.EditValue = dsDm_Heso_Chuongtrinh_Company.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyName'")[0]["Heso"];
            txtCongty_Daidien.EditValue = dsDm_Heso_Chuongtrinh_Company.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyName'")[0]["Heso"];
            txtDienthoai_Congty.EditValue = dsDm_Heso_Chuongtrinh_Company.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyTel'")[0]["Heso"];
            txtDiachi_Congty.EditValue = dsDm_Heso_Chuongtrinh_Company.Tables[0].Select("Nhom_Heso_Chuongtrinh = 'Company' and Ma_Heso_Chuongtrinh = 'CompanyAddress'")[0]["Heso"];


            //CompanyRepresented
            var sdrHeso = dsDm_Heso_Chuongtrinh_Company.Tables[0].Select("Ma_Heso_Chuongtrinh='CompanyRepresented'");
            DataTable tblNhansu_Nsdld = new DataTable();
            tblNhansu_Nsdld.Columns.AddRange(new DataColumn[] { 
                new DataColumn("Id_Nhansu", typeof(long)),
                new DataColumn("Ma_Nhansu", typeof(string)),
                new DataColumn("Hoten_Nhansu", typeof(string))
            });
            tblNhansu_Nsdld.Rows.Add(sdrHeso[0]["Heso"].ToString().Split(new char[] { '|' }));
            lookupEditTen_Nhansu_A.Properties.DataSource = tblNhansu_Nsdld;

            ChangeStatus(false);

            ClearDataBindings();
            DataBindingControl();
            base.DisplayInfo();
        }

        

        public override void DataBindingControl()
        {
            try
            {
                txtSohopdong.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Ma_Hopdong_Laodong"));
                lookupEditTen_Nhansu_A.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Id_Nhansu_Nsd"));
                lookUpEdit_Quoctich_Nhansu_A.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Id_Quocgia_Nsd"));
                lookUp_Chucvu_Nhansu_A.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Id_Chucvu_Nsd"));
                txtTen_Nhansu_B.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Id_Nhansu_Nld"));
                lookUpEdit_Quoctich_Nhansu_B.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Id_Quocgia_Nld"));
                txtNgaysinh_Nhansu_B.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Ngaysinh_Nld"));
                lookUp_Chuyenmon_Nhansu_B.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Id_chuyenmon_Nld"));
                txtDiachi_Thuongtru_Nhansu_B.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Diachi_Thuongtru_Nld"));
                txtCMND_Nhansu_B.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Cmnd_Nld"));
                dtNgaycap_Nhansu_B.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Ngaycap_Nld"));
                txtNoicap_Nhansu_B.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Noicap_Nld"));
                txtSolaodong_Nhansu_B.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".So_Laodong"));
                dtNgaycap_Solaodong_Nhansu_B.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Ngaycap_Sld"));
                txtNoicap_Solaodong_Nhansu_B.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Noicap_Sld"));
                lookUp_Loai_Hopdong.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Id_Loai_Hopdong"));
                dtNgay_Batdau.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Ngay_Batdau"));
                dtNgay_Ketthuc.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Ngay_Ketthuc"));
                txtDiadiem_Lamviec.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Diachi_Lamviec"));
                lookUp_Chucvu_Nhansu_B.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Id_Chucvu_Nld"));
                txtCongviec.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Congviec_Phailam"));
                txtThoigian_Lamviec.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Thoigio_Lamviec"));
                txtDungcu_Lamviec.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Dungcu_Lamviec"));
                txtPhuongtien_Dichuyen.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Phuongtien_Dilai"));
                lookUp_Bacluong.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Id_Bacluong"));
                txtLuong_Thoathuan.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Luong_Thoathuan"));
                lookUp_Phuongthuc_Huongluong.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Id_Phuongthuc_Huongluong"));
                txtTraluong.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Ngay_Tra_Luong"));
                txtTienthuong.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Tienthuong"));
                txtChedo_Nangluong.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Chedo_Nangluong"));
                txtBaoho_Laodong.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Baoho_Laodong_Gom"));
                txtChedo_Nghingoi.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Chedo_Nghingoi"));
                txtBaohiem.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Baohiem"));
                txtChedo_Daotao.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Chedo_Daotao"));
                txtThoathuan_Khac.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Thoathuan_Khac"));
                txtBoithuong_Vatchat.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Boithuong_Vipham"));
                dtLap_Hopdong.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Ngay_Lap_Hopdong"));
                txtNoiky.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Noiky"));
                dtNgayky.DataBindings.Add(new Binding("EditValue", ds_Hopdong_Laodong, ds_Hopdong_Laodong.Tables[0].TableName + ".Ngayky"));
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message,ex.ToString(),"Exception");
            }
            base.DataBindingControl();
        }

        public override void ClearDataBindings()
        {
            txtSohopdong.DataBindings.Clear();
            lookupEditTen_Nhansu_A.DataBindings.Clear();
            lookUpEdit_Quoctich_Nhansu_A.DataBindings.Clear();
            lookUp_Chucvu_Nhansu_A.DataBindings.Clear();
            txtTen_Nhansu_B.DataBindings.Clear();
            lookUpEdit_Quoctich_Nhansu_B.DataBindings.Clear();
            txtNgaysinh_Nhansu_B.DataBindings.Clear();
            lookUp_Chuyenmon_Nhansu_B.DataBindings.Clear();
            txtDiachi_Thuongtru_Nhansu_B.DataBindings.Clear();
            txtCMND_Nhansu_B.DataBindings.Clear();
            dtNgaycap_Nhansu_B.DataBindings.Clear();
            txtNoicap_Nhansu_B.DataBindings.Clear();
            txtSolaodong_Nhansu_B.DataBindings.Clear();
            dtNgaycap_Solaodong_Nhansu_B.DataBindings.Clear();
            txtNoicap_Solaodong_Nhansu_B.DataBindings.Clear();
            lookUp_Loai_Hopdong.DataBindings.Clear();
            dtNgay_Batdau.DataBindings.Clear();
            dtNgay_Ketthuc.DataBindings.Clear();
            txtDiadiem_Lamviec.DataBindings.Clear();
            lookUp_Chucvu_Nhansu_B.DataBindings.Clear();
            txtCongviec.DataBindings.Clear();
            txtThoigian_Lamviec.DataBindings.Clear();
            txtDungcu_Lamviec.DataBindings.Clear();
            txtPhuongtien_Dichuyen.DataBindings.Clear();
            lookUp_Bacluong.DataBindings.Clear();
            txtLuong_Thoathuan.DataBindings.Clear();
            lookUp_Phuongthuc_Huongluong.DataBindings.Clear();
            txtTraluong.DataBindings.Clear();
            txtTienthuong.DataBindings.Clear();
            txtChedo_Nangluong.DataBindings.Clear();
            txtBaoho_Laodong.DataBindings.Clear();
            txtChedo_Nghingoi.DataBindings.Clear();
            txtBaohiem.DataBindings.Clear();
            txtChedo_Daotao.DataBindings.Clear();
            txtThoathuan_Khac.DataBindings.Clear();
            txtBoithuong_Vatchat.DataBindings.Clear();
            dtLap_Hopdong.DataBindings.Clear();
            txtNoiky.DataBindings.Clear();
            dtNgayky.DataBindings.Clear();
            base.ClearDataBindings();
        }

        public override void ChangeStatus(bool editable)
        {
            gvrex_Hopdong_Laodong.OptionsBehavior.Editable = false;

            lookupEditTen_Nhansu_A.Properties.ReadOnly = !editable;
            txtTen_Nhansu_B.Properties.ReadOnly = true;

            txtSolaodong_Nhansu_B.Properties.ReadOnly = !editable;
            dtNgaycap_Solaodong_Nhansu_B.Properties.ReadOnly = !editable;
            txtNoicap_Solaodong_Nhansu_B.Properties.ReadOnly = !editable;
            lookUp_Loai_Hopdong.Properties.ReadOnly = !editable;
            dtNgay_Batdau.Properties.ReadOnly = !editable;
            dtNgay_Ketthuc.Properties.ReadOnly = !editable;
            txtDiadiem_Lamviec.Properties.ReadOnly = !editable;
            lookUp_Chucvu_Nhansu_B.Properties.ReadOnly = !editable;
            txtCongviec.Properties.ReadOnly = !editable;
            txtThoigian_Lamviec.Properties.ReadOnly = !editable;
            txtDungcu_Lamviec.Properties.ReadOnly = !editable;
            txtPhuongtien_Dichuyen.Properties.ReadOnly = !editable;
            lookUp_Bacluong.Properties.ReadOnly = !editable;
            lookUp_Phuongthuc_Huongluong.Properties.ReadOnly = !editable;
            //txtPhucap.Properties.ReadOnly = editable;
            txtTraluong.Properties.ReadOnly = !editable;
            txtTienthuong.Properties.ReadOnly = !editable;
            txtChedo_Nangluong.Properties.ReadOnly = !editable;
            txtBaoho_Laodong.Properties.ReadOnly = !editable;
            txtChedo_Nghingoi.Properties.ReadOnly = !editable;
            txtBaohiem.Properties.ReadOnly = !editable;
            txtChedo_Daotao.Properties.ReadOnly = !editable;
            txtThoathuan_Khac.Properties.ReadOnly = !editable;
            txtBoithuong_Vatchat.Properties.ReadOnly = !editable;
            dtLap_Hopdong.Properties.ReadOnly = !editable;
            txtNoiky.Properties.ReadOnly = !editable;
            dtNgayky.Properties.ReadOnly = !editable;           
            gvPhucap.OptionsBehavior.Editable = false;
            xSignPane1.Enabled = editable;
            xSignPane2.Enabled = editable;

        }

        public override bool PerformEdit()
        {
            DevExpress.Utils.WaitDialogForm wdf = new DevExpress.Utils.WaitDialogForm("Vui lòng chờ trong vài giây...", "Đang tập hợp dữ liệu mẫu...");
            var sdrHopdong_New = ds_Hopdong_Laodong.Tables[0].Select(string.Format("Pb_New ={0}",true));
            foreach (DataRow drHopdong_New in sdrHopdong_New)
            {
                drHopdong_New["Id_Nhansu_Nsd"] = Id_Nhansu_Sd;
                var Id_Nhansu = drHopdong_New["Id_Nhansu_Nld"];
                drHopdong_New["Ma_Hopdong_Laodong"] = drHopdong_New["New_Identity"];
                drHopdong_New["Ngay_Batdau"] = DateTime.Now;

                var dsBotri_Nhansu = objRexService.Get_Rex_Botri_Nhansu_For_Hopdong_Laodong_Collection(Id_Nhansu, drHopdong_New["Ngay_Batdau"]).ToDataSet();
                drHopdong_New["Diachi_Lamviec"] = dsBotri_Nhansu.Tables[0].Rows[0]["Ten_Bophan"];
                drHopdong_New["Id_Chucvu_Nld"] = dsBotri_Nhansu.Tables[0].Rows[0]["Id_Chucvu"];
                drHopdong_New["Id_Phuongthuc_Huongluong"] = dsBotri_Nhansu.Tables[0].Rows[0]["Id_Phuongthuc_Huongluong"];

                try
                {
                    var dsDienbien_Luong = objRexService.Get_Rex_Dienbien_Luong_For_Hopdong_Laodong_Collection(Id_Nhansu, drHopdong_New["Ngay_Batdau"]).ToDataSet();
                   drHopdong_New["Id_Dienbien_Luong"] = dsDienbien_Luong.Tables[0].Rows[0]["Id_Dienbien_Luong"];
                    drHopdong_New["Id_Bacluong"] = dsDienbien_Luong.Tables[0].Rows[0]["Id_Bacluong"];
                    drHopdong_New["Luong_Thoathuan"] = dsDienbien_Luong.Tables[0].Rows[0]["Luong_Thoathuan"];
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                }

                string[] defaultvalues = new string[] { 
                "Congviec_Phailam", "Thoigio_Lamviec", "Dungcu_Lamviec",
                "Phuongtien_Dilai","Ngay_Tra_Luong","Tienthuong",
                "Chedo_Nangluong","Baoho_Laodong_Gom","Chedo_Nghingoi",
                "Baohiem","Chedo_Daotao","Thoathuan_Khac","Boithuong_Vipham"
                };
                foreach (string field in defaultvalues)
                {
                    try
                    {
                        drHopdong_New[field] = dsHsct_Hopdonglaodonginfo.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'",field))[0]["Heso"];
                    }
                    catch (Exception ex)
                    {
                        GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
                        continue;
                    }
                }
            }
            ChangeStatus(true);

            wdf.Close();
            return base.PerformEdit();
        }

        public override bool PerformCancel()
        {
            DisplayInfo();
            ChangeStatus(false);
            return base.PerformCancel();
        }

        public override bool PerformSave()
        {
            this.DoClickEndEdit(dgrex_Hopdong_Laodong);
            foreach (DataRow drHongdong in ds_Hopdong_Laodong.Tables[0].Rows)
            {
                try
                {
                    var objHopdong_Laodong = new Ecm.WebReferences.RexService.Rex_Hopdong_Laodong();
                    //  Gan gia tri vao doi tuong
                    objHopdong_Laodong.Id_Hopdong_Laodong = ("" + drHongdong["Id_Hopdong_Laodong"] != "") ? drHongdong["Id_Hopdong_Laodong"] : null;
                    objHopdong_Laodong.Ma_Hopdong_Laodong = ("" + drHongdong["Ma_Hopdong_Laodong"] != "") ? drHongdong["Ma_Hopdong_Laodong"] : null;
                    objHopdong_Laodong.Id_Loai_Hopdong = ("" + drHongdong["Id_Loai_Hopdong"] != "") ? drHongdong["Id_Loai_Hopdong"] : null;
                    objHopdong_Laodong.Id_Nhansu_Nld = ("" + drHongdong["Id_Nhansu_Nld"] != "") ? drHongdong["Id_Nhansu_Nld"] : null;
                    objHopdong_Laodong.Ngay_Batdau = ("" + drHongdong["Ngay_Batdau"] != "") ? drHongdong["Ngay_Batdau"] : null;
                    objHopdong_Laodong.Ngay_Ketthuc = ("" + drHongdong["Ngay_Ketthuc"] != "") ? drHongdong["Ngay_Ketthuc"] : null;
                    objHopdong_Laodong.Id_Nhansu_Nsd = ("" + drHongdong["Id_Nhansu_Nsd"] != "") ? drHongdong["Id_Nhansu_Nsd"] : null;
                    objHopdong_Laodong.So_Laodong = ("" + drHongdong["So_Laodong"] != "") ? drHongdong["So_Laodong"] : null;
                    objHopdong_Laodong.Ngaycap_Sld = ("" + drHongdong["Ngaycap_Sld"] != "") ? drHongdong["Ngaycap_Sld"] : null;
                    objHopdong_Laodong.Noicap_Sld = ("" + drHongdong["Noicap_Sld"] != "") ? drHongdong["Noicap_Sld"] : null;
                    //objHopdong_Laodong.Ngay_Batdau_Thuviec = dtNgay_Batdau_Thuviec.DateTime.Date;
                    //objHopdong_Laodong.Ngay_Ketthuc_Thuviec = dtNgay_Ketthuc_Thuviec.DateTime.Date;
                    objHopdong_Laodong.Diachi_Lamviec = ("" + drHongdong["Diachi_Lamviec"] != "") ? drHongdong["Diachi_Lamviec"] : null;
                    objHopdong_Laodong.Id_Chucvu_Nld = ("" + drHongdong["Id_Chucvu_Nld"] != "") ? drHongdong["Id_Chucvu_Nld"] : null;
                    objHopdong_Laodong.Congviec_Phailam = ("" + drHongdong["Congviec_Phailam"] != "") ? drHongdong["Congviec_Phailam"] : null;
                    objHopdong_Laodong.Thoigio_Lamviec = ("" + drHongdong["Thoigio_Lamviec"] != "") ? drHongdong["Thoigio_Lamviec"] : null;
                    objHopdong_Laodong.Dungcu_Lamviec = ("" + drHongdong["Dungcu_Lamviec"] != "") ? drHongdong["Dungcu_Lamviec"] : null;
                    objHopdong_Laodong.Phuongtien_Dilai = ("" + drHongdong["Phuongtien_Dilai"] != "") ? drHongdong["Phuongtien_Dilai"] : null;
                    objHopdong_Laodong.Diachi_Lamviec = ("" + drHongdong["Diachi_Lamviec"] != "") ? drHongdong["Diachi_Lamviec"] : null;
                    objHopdong_Laodong.Id_Dienbien_Luong = ("" + drHongdong["Id_Dienbien_Luong"] != "") ? drHongdong["Id_Dienbien_Luong"] : null;
                    objHopdong_Laodong.Id_Phuongthuc_Huongluong = ("" + drHongdong["Id_Phuongthuc_Huongluong"] != "") ? drHongdong["Id_Phuongthuc_Huongluong"] : null;
                    //objHopdong_Laodong.Phucap_Gom = txtPhucap.Text.ToString();
                    objHopdong_Laodong.Ngay_Tra_Luong = ("" + drHongdong["Ngay_Tra_Luong"] != "") ? drHongdong["Ngay_Tra_Luong"] : null;
                    objHopdong_Laodong.Tienthuong = ("" + drHongdong["Tienthuong"] != "") ? drHongdong["Tienthuong"] : null;
                    objHopdong_Laodong.Chedo_Nangluong = ("" + drHongdong["Chedo_Nangluong"] != "") ? drHongdong["Chedo_Nangluong"] : null;
                    objHopdong_Laodong.Baoho_Laodong_Gom = ("" + drHongdong["Baoho_Laodong_Gom"] != "") ? drHongdong["Baoho_Laodong_Gom"] : null;
                    objHopdong_Laodong.Chedo_Nghingoi = ("" + drHongdong["Chedo_Nghingoi"] != "") ? drHongdong["Chedo_Nghingoi"] : null;
                    objHopdong_Laodong.Baohiem = ("" + drHongdong["Baohiem"] != "") ? drHongdong["Baohiem"] : null;
                    objHopdong_Laodong.Chedo_Daotao = ("" + drHongdong["Chedo_Daotao"] != "") ? drHongdong["Chedo_Daotao"] : null;
                    objHopdong_Laodong.Thoathuan_Khac = ("" + drHongdong["Thoathuan_Khac"] != "") ? drHongdong["Thoathuan_Khac"] : null;
                    objHopdong_Laodong.Boithuong_Vipham = ("" + drHongdong["Boithuong_Vipham"] != "") ? drHongdong["Boithuong_Vipham"] : null;
                    objHopdong_Laodong.Ngay_Lap_Hopdong = ("" + drHongdong["Ngay_Lap_Hopdong"] != "") ? drHongdong["Ngay_Lap_Hopdong"] : null;
                    objHopdong_Laodong.Noiky = ("" + drHongdong["Noiky"] != "") ? drHongdong["Noiky"] : null;
                    objHopdong_Laodong.Ngayky = ("" + drHongdong["Ngayky"] != "") ? drHongdong["Ngayky"] : null;

                    //MemoryStream ms1 = new MemoryStream();
                    //xSignPane1.Bitmap.Save(ms1, System.Drawing.Imaging.ImageFormat.Bmp);
                    //byte[] imgByteArray1 = ms1.ToArray();

                    objHopdong_Laodong.Kyten_Nld = null;

                    //MemoryStream ms2 = new MemoryStream();
                    //xSignPane2.Bitmap.Save(ms2, System.Drawing.Imaging.ImageFormat.Bmp);
                    //byte[] imgByteArray2 = ms2.ToArray();

                    objHopdong_Laodong.Kyten_Nsd = null;

                    objHopdong_Laodong.Luong_Thoathuan = ("" + drHongdong["Luong_Thoathuan"] != "") ? drHongdong["Luong_Thoathuan"] : null;

                    if (Convert.ToBoolean(drHongdong["Pb_New"]))
                        objRexService.Insert_Rex_Hopdong_Laodong_Info(objHopdong_Laodong);
                    else
                        objRexService.Update_Rex_Hopdong_Laodong_Info_ByID_Hopdong(objHopdong_Laodong);
                }
                catch (Exception ex)
                {
                    GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Lỗi khi lưu: HĐLĐ số " + drHongdong["Ma_Hopdong_Laodong"]);
                    continue;
                }
            }

            DisplayInfo();
            ChangeStatus(false);
            new System.Threading.Thread(new System.Threading.ThreadStart(this.Luongtonghop_Init)).Start();
            return base.PerformSave();
        }


        public override bool PerformPrintPreview()
        {
            DataSet dsHDLD = objRexService.Get_Hopdong_Nhansu_Info_In_Hoso(gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Hopdong_Laodong")).ToDataSet();
            Reports.rptRex_Hopdong_Nhansu XtraReport = new Ecm.Rex.Reports.rptRex_Hopdong_Nhansu();
            GoobizFrame.Windows.Forms.FrmPrintPreview frmPrintPreview = new GoobizFrame.Windows.Forms.FrmPrintPreview();

            XtraReport.xrTen_Donvi.Text = dsDm_Heso_Chuongtrinh_Company.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyName"))[0]["Heso"].ToString();
            XtraReport.xrTen_Congty.Text = dsDm_Heso_Chuongtrinh_Company.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyName"))[0]["Heso"].ToString();
            XtraReport.xrDiachi_Congty.Text = dsDm_Heso_Chuongtrinh_Company.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyAddress"))[0]["Heso"].ToString();
            XtraReport.xrDienthoai_Congty.Text = dsDm_Heso_Chuongtrinh_Company.Tables[0].Select(string.Format("Ma_Heso_Chuongtrinh='{0}'", "CompanyTel"))[0]["Heso"].ToString();

            XtraReport.xrPic_Kyten_Nld.DataBindings.Add(
                       new DevExpress.XtraReports.UI.XRBinding("Image", dsHDLD, dsHDLD.Tables[0].TableName + ".Kyten_Nld"));
            XtraReport.xrPic_Kyten_Nsd.DataBindings.Add(
                       new DevExpress.XtraReports.UI.XRBinding("Image", dsHDLD, dsHDLD.Tables[0].TableName + ".Kyten_Nsd"));

            frmPrintPreview.Report = XtraReport;
            XtraReport.DataSource = dsHDLD;

            Reports.rptRex_Phucap rptPhucap = new Ecm.Rex.Reports.rptRex_Phucap();
            XtraReport.xrPhucap.ReportSource = rptPhucap;
            var dsPhucap = objRexService.Get_Rex_Phucap_For_Hopdong_Laodong_Collection(gvrex_Hopdong_Laodong.GetFocusedDataRow()["Id_Nhansu_Nld"],
                    ("" + dtNgay_Batdau.EditValue != "") ? dtNgay_Batdau.EditValue : DateTime.Now
                );
            rptPhucap.DataSource = dsPhucap;
            rptPhucap.CreateDocument();

            XtraReport.CreateDocument();

            frmPrintPreview.printControl1.PrintingSystem = XtraReport.PrintingSystem;
            frmPrintPreview.Text = this.Text + " - In hợp đồng lao động";
            frmPrintPreview.ShowDialog();
            frmPrintPreview.Activate();

            return base.PerformPrintPreview();
        }
        #endregion

        void Luongtonghop_Init()
        {
            try
            {
                //tinh luong
                objRexService.Rex_Luong_Tonghop_Init_ByBophan(DateTime.Now.Year, DateTime.Now.Month, Id_Bophan);
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(), "Exception");
            }
        }

        private void gvrex_Hopdong_Laodong_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                var dsPhucap = objRexService.Get_Rex_Phucap_For_Hopdong_Laodong_Collection(gvrex_Hopdong_Laodong.GetFocusedDataRow()["Id_Nhansu_Nld"], 
                    (""+dtNgay_Batdau.EditValue!="") ? dtNgay_Batdau.EditValue : DateTime.Now
                ).ToDataSet();

                dg_Phucap.DataSource = dsPhucap.Tables[0];
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.Forms.MessageDialog.Show(ex.Message, ex.ToString(),"Exception");
            }
        }

        private void lookUp_Loai_Hopdong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                System.Windows.Forms.Form dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData("Ecm.MasterService.dll",
                    "Ecm.MasterService.Forms.Rex.Frmrex_Dm_Loai_Hopdong_Add", this);
                if (dialog == null)
                    return;
                var SelectedObject = dialog.GetType().GetProperty("SelectedDataRow").GetValue(dialog, null)
                   as DataRow;

                if (SelectedObject != null)
                {
                    ds_Loai_HDLD = objMasterService.Get_All_Rex_Dm_Loai_Hopdong_Collection().ToDataSet();
                    lookUp_Loai_Hopdong.Properties.DataSource = ds_Loai_HDLD.Tables[0];
                    gridLookUp_Loai_Hopdong.DataSource = ds_Loai_HDLD.Tables[0];

                    lookUp_Loai_Hopdong.EditValue = SelectedObject["Id_Loai_Hopdong"];
                }
            }
        }

        private void lookUp_Bacluong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
            {
                System.Windows.Forms.Form dialog = GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowDialogOfMetaData("Ecm.MasterService.dll",
                    "Ecm.MasterService.Forms.Rex.Frmrex_Dm_Bacluong_Add", this);
                if (dialog == null)
                    return;
                var SelectedObject = dialog.GetType().GetProperty("SelectedRex_Dm_Bacluong").GetValue(dialog, null)
                   as Ecm.WebReferences.MasterService.Rex_Dm_Bacluong;

                if (SelectedObject != null)
                {
                    var dsBacluong = objMasterService.Get_All_Rex_Dm_Bacluong_Collection();
                    lookUp_Bacluong.Properties.DataSource = ds_Loai_HDLD.Tables[0];

                    lookUp_Bacluong.EditValue = SelectedObject.Id_Bacluong;
                }
            }
        }

        private void btnSave_Heso_Chuongtrinh_Click(object sender, EventArgs e)
        {
            this.DoClickEndEdit(dgHeso_Chuongtrinh);
            if (dsHsct_Hopdonglaodonginfo.HasChanges())
            {
                objMasterService.Update_Rex_Dm_Heso_Chuongtrinh_Collection(dsHsct_Hopdonglaodonginfo);
                btnSave_Heso_Chuongtrinh.Enabled = false;
            }
        }

        private void gvHeso_Chuongtrinh_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            btnSave_Heso_Chuongtrinh.Enabled = true;
        }

        private void gvrex_Hopdong_Laodong_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "Ngay_Batdau":
                case "Id_Loai_Hopdong":
                    var sdrLoai_Hdld = ds_Loai_HDLD.Tables[0].Select(string.Format("Id_Loai_Hopdong={0}", gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Id_Loai_Hopdong")));
                    if (sdrLoai_Hdld.Length > 0)
                    {
                        int thoihan = Convert.ToInt32(sdrLoai_Hdld[0]["Thoihan"]);
                        if (thoihan < 1200) 
                        {
                            ///////////////thoi han toi da 100 nam !!!!!!!!!!!???????////////////////////////////////////////////////
                            DateTime dtNgay_Batdau = Convert.ToDateTime(gvrex_Hopdong_Laodong.GetFocusedRowCellValue("Ngay_Batdau"));
                            DateTime dtNgay_Ketthuc = dtNgay_Batdau.AddMonths(thoihan);
                            gvrex_Hopdong_Laodong.SetFocusedRowCellValue("Ngay_Ketthuc", dtNgay_Ketthuc);
                        }
                        else
                            gvrex_Hopdong_Laodong.SetFocusedRowCellValue("Ngay_Ketthuc", null);

                    }
                    break;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var drHopdong_New = gvrex_Hopdong_Laodong.GetFocusedDataRow();
                var Id_Nhansu = drHopdong_New["Id_Nhansu_Nld"];
                var dsBotri_Nhansu = objRexService.Get_Rex_Botri_Nhansu_For_Hopdong_Laodong_Collection(Id_Nhansu, drHopdong_New["Ngay_Batdau"]).ToDataSet();
                drHopdong_New["Diachi_Lamviec"] = dsBotri_Nhansu.Tables[0].Rows[0]["Ten_Bophan"];
                drHopdong_New["Id_Chucvu_Nld"] = dsBotri_Nhansu.Tables[0].Rows[0]["Id_Chucvu"];
                drHopdong_New["Id_Phuongthuc_Huongluong"] = dsBotri_Nhansu.Tables[0].Rows[0]["Id_Phuongthuc_Huongluong"];
            }
            catch { }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                var drHopdong_New = gvrex_Hopdong_Laodong.GetFocusedDataRow();
                var Id_Nhansu = drHopdong_New["Id_Nhansu_Nld"];
                var dsDienbien_Luong = objRexService.Get_Rex_Dienbien_Luong_For_Hopdong_Laodong_Collection(Id_Nhansu, drHopdong_New["Ngay_Batdau"]).ToDataSet();
                drHopdong_New["Id_Bacluong"] = dsDienbien_Luong.Tables[0].Rows[0]["Id_Bacluong"];
                drHopdong_New["Luong_Thoathuan"] = dsDienbien_Luong.Tables[0].Rows[0]["Luong_Thoathuan"];
                 drHopdong_New["Id_Dienbien_Luong"] = dsDienbien_Luong.Tables[0].Rows[0]["Id_Dienbien_Luong"];
           }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private void lookUp_Loai_Hopdong_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (FormState == GoobizFrame.Windows.Forms.FormState.Edit)
                {
                    int thoihan = Convert.ToInt32(lookUp_Loai_Hopdong.GetColumnValue("Thoihan"));
                    if (thoihan < 1200)
                    {
                        ///////////////thoi han toi da 100 nam !!!!!!!!!!!???????////////////////////////////////////////////////
                        DateTime Ngay_Batdau = dtNgay_Batdau.DateTime;
                        DateTime Ngay_Ketthuc = Ngay_Batdau.AddMonths(thoihan);
                        dtNgay_Ketthuc.DateTime = Ngay_Ketthuc;
                    }
                    else
                        dtNgay_Ketthuc.EditValue = null;

                    this.DoClickEndEdit(dgrex_Hopdong_Laodong);
                    gvrex_Hopdong_Laodong.RefreshData();
                }
            }
            catch (Exception ex)
            {
                GoobizFrame.Windows.TrayMessage.TrayMessage.Status = new GoobizFrame.Windows.TrayMessage.TrayMessageInfo(MessageBoxIcon.Asterisk, ex.Message, ex.ToString());
            }
        }

        private void dtNgay_Batdau_EditValueChanged(object sender, EventArgs e)
        {
            lookUp_Loai_Hopdong_EditValueChanged( sender,  e);
        }

       
    }
}