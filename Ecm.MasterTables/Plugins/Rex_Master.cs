using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.MasterTables.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Rex_Master : IPlugin
    {

        //bool DataLoaded = false;
        #region Forms
        Forms.Rex.Frmrex_Dm_Bophan_Add frmrex_Dm_Bophan_Add;
        //Forms.Rex.Frmrex_Dm_Loai_Nhanvien_Add frmrex_Dm_Loai_Nhanvien_Add;
        Forms.Rex.Frmrex_Dm_Vanhoa_Add frmrex_Dm_Vanhoa_Add;
        Forms.Rex.Frmrex_Dm_Chuyenmon_Add frmrex_Dm_Chuyenmon_Add;
        Forms.Rex.Frmrex_Dm_Tinhoc_Add frmrex_Dm_Tinhoc_Add;
        //Forms.Rex.Frmrex_Dm_Ngoaingu_Add frmrex_Dm_Ngoaingu_Add;
        Forms.Rex.Frmrex_Dm_Tongiao_Add frmrex_Dm_Tongiao_Add;
        Forms.Rex.Frmrex_Dm_Dantoc_Add frmrex_Dm_Dantoc_Add;
        //Forms.Rex.Frmrex_Dm_Xa_Add frmrex_Dm_Xa_Add;
        //Forms.Rex.Frmrex_Dm_Huyen_Add frmrex_Dm_Huyen_Add;
        Forms.Rex.Frmrex_Dm_Tinh_Add frmrex_Dm_Tinh_Add;
        //Forms.Rex.Frmrex_Dm_Quocgia_Add frmrex_Dm_Quocgia_Add;
        //Forms.Rex.Frmrex_Dm_Honnhan_Add frmrex_Dm_Honnhan_Add;
        //Forms.Rex.Frmrex_Dm_Tpbanthan_Add frmrex_Dm_Tpbanthan_Add;
        //Forms.Rex.Frmrex_Dm_Tpgiadinh_Add frmrex_Dm_Tpgiadinh_Add;
        //Forms.Rex.Frmrex_Dm_Phucap_Add frmrex_Dm_Phucap_Add;
        //Forms.Rex.Frmrex_Dm_Chucvu_Add frmrex_Dm_Chucvu_Add;
        //Forms.Rex.Frmrex_Dm_Ngachluong_Add frmrex_Dm_Ngachluong_Add;
        //Forms.Rex.Frmrex_Dm_Bacluong_Add frmrex_Dm_Bacluong_Add;
        //Forms.Rex.Frmrex_Dm_Loai_Hopdong_Add frmrex_Dm_Loai_Hopdong_Add;
        //Forms.Rex.Frmrex_Dm_Ngaynghi_Add frmrex_Dm_Ngaynghi_Add;
        //Forms.Rex.Frmrex_Dm_Ca_Lamviec_Add frmrex_Dm_Ca_Lamviec_Add;
        Forms.Rex.Frmrex_Dm_Chungchi_Add frmrex_Dm_Chungchi_Add;
        //Forms.Rex.Frmrex_Dm_Khenthuong_Kyluat_Add frmrex_Dm_Khenthuong_Kyluat_Add;
        //Forms.Rex.Frmrex_Dm_Loai_Bophan_Add frmrex_Dm_Loai_Bophan_Add;
        //Forms.Rex.Frmrex_Dm_Loai_Ktkl_Add frmrex_Dm_Loai_Ktkl_Add;
        //Forms.Rex.Frmrex_Dm_Loai_Nghiphep_Add frmrex_Dm_Loai_Nghiphep_Add;
        //Forms.Rex.Frmrex_Dm_Phuongthuc_Huongluong_Add frmrex_Dm_Phuongthuc_Huongluong_Add;
        //Forms.Rex.Frmrex_Dm_Quanhe_Giadinh_Add frmrex_Dm_Quanhe_Giadinh_Add;
        //Forms.Rex.Frmrex_Dm_Quyetdinh_Add frmrex_Dm_Quyetdinh_Add;
        Forms.Rex.Frmrex_Dm_Tochuc_Add frmrex_Dm_Tochuc_Add;
        //Forms.Rex.Frmrex_Dm_Coquan_Add frmrex_Dm_Coquan_Add;
        //Forms.Rex.Frmrex_Dm_Xeploai_Add frmrex_Dm_Xeploai_Add;
        //Forms.Rex.Frmrex_Dm_Heso_Giotangca_Add frmrex_Dm_Heso_Giotangca_Add;
        Forms.Rex.Frmrex_Dm_Kynang_Chuyenmon_Add frmrex_Dm_Kynang_Chuyenmon_Add;
        //Forms.Rex.Frmrex_Dm_Ndung_Tgluong frmrex_Dm_Ndung_Tgluong;

        //ACC
        //Forms.Accounting.Frmacc_Dm_Thue_TNCN_Luytien frmacc_Dm_Thue_TNCN_Luytien;
       #endregion

        public Rex_Master()
        {
            m_strName = "Đang kiểm tra";
            m_PluginItemConfig = @"";
        }

        public void SetMdiParent(System.Windows.Forms.Form mdiParent)
        {
            this.mdiParent = mdiParent;
        }

        public void BarManager_ItemClick(object sender, EventArgs e)
        {
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm();

            string formName = "";
            string formText = "";

            if (e.GetType() == typeof(DevExpress.XtraNavBar.NavBarLinkEventArgs))
            {
                formName = ((DevExpress.XtraNavBar.NavBarItem)sender).Name;
                formText = ((DevExpress.XtraNavBar.NavBarItem)sender).Caption;
            }
            else if (e.GetType() == typeof(DevExpress.XtraBars.ItemClickEventArgs))
            {
                formName = ((DevExpress.XtraBars.ItemClickEventArgs)e).Item.Name;
                formText = ((DevExpress.XtraBars.ItemClickEventArgs)e).Item.Caption;
            }

            switch (formName)
            {
                case "Frmrex_Dm_Bophan_Add":
                    frmrex_Dm_Bophan_Add = (MasterTables.Forms.Rex.Frmrex_Dm_Bophan_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Bophan_Add");

                    if (frmrex_Dm_Bophan_Add == null || frmrex_Dm_Bophan_Add.IsDisposed)
                        frmrex_Dm_Bophan_Add = new MasterTables.Forms.Rex.Frmrex_Dm_Bophan_Add();
                    frmrex_Dm_Bophan_Add.Text = formText;
                    frmrex_Dm_Bophan_Add.MdiParent = mdiParent;
                    frmrex_Dm_Bophan_Add.Show();
                    frmrex_Dm_Bophan_Add.Activate();
                    break;

                //case "Frmrex_Dm_Loai_Nhanvien_Add":
                //    frmrex_Dm_Loai_Nhanvien_Add = (MasterTables.Forms.Rex.Frmrex_Dm_Loai_Nhanvien_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Loai_Nhanvien_Add");

                //    if (frmrex_Dm_Loai_Nhanvien_Add == null || frmrex_Dm_Loai_Nhanvien_Add.IsDisposed)
                //        frmrex_Dm_Loai_Nhanvien_Add = new MasterTables.Forms.Rex.Frmrex_Dm_Loai_Nhanvien_Add();
                //    frmrex_Dm_Loai_Nhanvien_Add.Text = formText;
                //    frmrex_Dm_Loai_Nhanvien_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Loai_Nhanvien_Add.Show();
                //    frmrex_Dm_Loai_Nhanvien_Add.Activate();
                //    break;
                case "Frmrex_Dm_Vanhoa_Add":
                    frmrex_Dm_Vanhoa_Add = (Forms.Rex.Frmrex_Dm_Vanhoa_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Vanhoa_Add");

                    if (frmrex_Dm_Vanhoa_Add == null || frmrex_Dm_Vanhoa_Add.IsDisposed)
                        frmrex_Dm_Vanhoa_Add = new Forms.Rex.Frmrex_Dm_Vanhoa_Add();
                    frmrex_Dm_Vanhoa_Add.Text = formText;
                    frmrex_Dm_Vanhoa_Add.MdiParent = mdiParent;
                    frmrex_Dm_Vanhoa_Add.Show();
                    frmrex_Dm_Vanhoa_Add.Activate();
                    break;

                case "Frmrex_Dm_Chuyenmon_Add":
                    frmrex_Dm_Chuyenmon_Add = (Forms.Rex.Frmrex_Dm_Chuyenmon_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Chuyenmon_Add");

                    if (frmrex_Dm_Chuyenmon_Add == null || frmrex_Dm_Chuyenmon_Add.IsDisposed)
                        frmrex_Dm_Chuyenmon_Add = new Forms.Rex.Frmrex_Dm_Chuyenmon_Add();
                    frmrex_Dm_Chuyenmon_Add.Text = formText;
                    frmrex_Dm_Chuyenmon_Add.MdiParent = mdiParent;
                    frmrex_Dm_Chuyenmon_Add.Show();
                    frmrex_Dm_Chuyenmon_Add.Activate();
                    break;

                case "Frmrex_Dm_Tinhoc_Add":
                    frmrex_Dm_Tinhoc_Add = (Forms.Rex.Frmrex_Dm_Tinhoc_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Tinhoc_Add");

                    if (frmrex_Dm_Tinhoc_Add == null || frmrex_Dm_Tinhoc_Add.IsDisposed)
                        frmrex_Dm_Tinhoc_Add = new Forms.Rex.Frmrex_Dm_Tinhoc_Add();
                    frmrex_Dm_Tinhoc_Add.Text = formText;
                    frmrex_Dm_Tinhoc_Add.MdiParent = mdiParent;
                    frmrex_Dm_Tinhoc_Add.Show();
                    frmrex_Dm_Tinhoc_Add.Activate();
                    break;

                //case "Frmrex_Dm_Ngoaingu_Add":
                //    frmrex_Dm_Ngoaingu_Add = (Forms.Rex.Frmrex_Dm_Ngoaingu_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Ngoaingu_Add");

                //    if (frmrex_Dm_Ngoaingu_Add == null || frmrex_Dm_Ngoaingu_Add.IsDisposed)
                //        frmrex_Dm_Ngoaingu_Add = new Forms.Rex.Frmrex_Dm_Ngoaingu_Add();
                //    frmrex_Dm_Ngoaingu_Add.Text = formText;
                //    frmrex_Dm_Ngoaingu_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Ngoaingu_Add.Show();
                //    frmrex_Dm_Ngoaingu_Add.Activate();
                //    break;

                case "Frmrex_Dm_Dantoc_Add":
                    frmrex_Dm_Dantoc_Add = (Forms.Rex.Frmrex_Dm_Dantoc_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Dantoc_Add");

                    if (frmrex_Dm_Dantoc_Add == null || frmrex_Dm_Dantoc_Add.IsDisposed)
                        frmrex_Dm_Dantoc_Add = new Forms.Rex.Frmrex_Dm_Dantoc_Add();
                    frmrex_Dm_Dantoc_Add.Text = formText;
                    frmrex_Dm_Dantoc_Add.MdiParent = mdiParent;
                    frmrex_Dm_Dantoc_Add.Show();
                    frmrex_Dm_Dantoc_Add.Activate();
                    break;

                case "Frmrex_Dm_Tongiao_Add":
                    frmrex_Dm_Tongiao_Add = (Forms.Rex.Frmrex_Dm_Tongiao_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Tongiao_Add");

                    if (frmrex_Dm_Tongiao_Add == null || frmrex_Dm_Tongiao_Add.IsDisposed)
                        frmrex_Dm_Tongiao_Add = new Forms.Rex.Frmrex_Dm_Tongiao_Add();
                    frmrex_Dm_Tongiao_Add.Text = formText;
                    frmrex_Dm_Tongiao_Add.MdiParent = mdiParent;
                    frmrex_Dm_Tongiao_Add.Show();
                    frmrex_Dm_Tongiao_Add.Activate();
                    break;

                //case "Frmrex_Dm_Xa_Add":
                //    frmrex_Dm_Xa_Add = (Forms.Rex.Frmrex_Dm_Xa_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Xa_Add");

                //    if (frmrex_Dm_Xa_Add == null || frmrex_Dm_Xa_Add.IsDisposed)
                //        frmrex_Dm_Xa_Add = new Forms.Rex.Frmrex_Dm_Xa_Add();
                //    frmrex_Dm_Xa_Add.Text = formText;
                //    frmrex_Dm_Xa_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Xa_Add.Show();
                //    frmrex_Dm_Xa_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Huyen_Add":
                //    frmrex_Dm_Huyen_Add = (Forms.Rex.Frmrex_Dm_Huyen_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Huyen_Add");

                //    if (frmrex_Dm_Huyen_Add == null || frmrex_Dm_Huyen_Add.IsDisposed)
                //        frmrex_Dm_Huyen_Add = new Forms.Rex.Frmrex_Dm_Huyen_Add();
                //    frmrex_Dm_Huyen_Add.Text = formText;
                //    frmrex_Dm_Huyen_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Huyen_Add.Show();
                //    frmrex_Dm_Huyen_Add.Activate();
                //    break;

                case "Frmrex_Dm_Tinh_Add":
                    frmrex_Dm_Tinh_Add = (Forms.Rex.Frmrex_Dm_Tinh_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Tinh_Add");

                    if (frmrex_Dm_Tinh_Add == null || frmrex_Dm_Tinh_Add.IsDisposed)
                        frmrex_Dm_Tinh_Add = new Forms.Rex.Frmrex_Dm_Tinh_Add();
                    frmrex_Dm_Tinh_Add.Text = formText;
                    frmrex_Dm_Tinh_Add.MdiParent = mdiParent;
                    frmrex_Dm_Tinh_Add.Show();
                    frmrex_Dm_Tinh_Add.Activate();
                    break;

                //case "Frmrex_Dm_Quocgia_Add":
                //    frmrex_Dm_Quocgia_Add = (Forms.Rex.Frmrex_Dm_Quocgia_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Quocgia_Add");

                //    if (frmrex_Dm_Quocgia_Add == null || frmrex_Dm_Quocgia_Add.IsDisposed)
                //        frmrex_Dm_Quocgia_Add = new Forms.Rex.Frmrex_Dm_Quocgia_Add();
                //    frmrex_Dm_Quocgia_Add.Text = formText;
                //    frmrex_Dm_Quocgia_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Quocgia_Add.Show();
                //    frmrex_Dm_Quocgia_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Honnhan_Add":
                //    frmrex_Dm_Honnhan_Add = (Forms.Rex.Frmrex_Dm_Honnhan_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Honnhan_Add");

                //    if (frmrex_Dm_Honnhan_Add == null || frmrex_Dm_Honnhan_Add.IsDisposed)
                //        frmrex_Dm_Honnhan_Add = new Forms.Rex.Frmrex_Dm_Honnhan_Add();
                //    frmrex_Dm_Honnhan_Add.Text = formText;
                //    frmrex_Dm_Honnhan_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Honnhan_Add.Show();
                //    frmrex_Dm_Honnhan_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Tpbanthan_Add":
                //    frmrex_Dm_Tpbanthan_Add = (Forms.Rex.Frmrex_Dm_Tpbanthan_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Tpbanthan_Add");

                //    if (frmrex_Dm_Tpbanthan_Add == null || frmrex_Dm_Tpbanthan_Add.IsDisposed)
                //        frmrex_Dm_Tpbanthan_Add = new Forms.Rex.Frmrex_Dm_Tpbanthan_Add();
                //    frmrex_Dm_Tpbanthan_Add.Text = formText;
                //    frmrex_Dm_Tpbanthan_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Tpbanthan_Add.Show();
                //    frmrex_Dm_Tpbanthan_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Tpgiadinh_Add":
                //    frmrex_Dm_Tpgiadinh_Add = (Forms.Rex.Frmrex_Dm_Tpgiadinh_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Tpgiadinh_Add");

                //    if (frmrex_Dm_Tpgiadinh_Add == null || frmrex_Dm_Tpgiadinh_Add.IsDisposed)
                //        frmrex_Dm_Tpgiadinh_Add = new Forms.Rex.Frmrex_Dm_Tpgiadinh_Add();
                //    frmrex_Dm_Tpgiadinh_Add.Text = formText;
                //    frmrex_Dm_Tpgiadinh_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Tpgiadinh_Add.Show();
                //    frmrex_Dm_Tpgiadinh_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Phucap_Add":
                //    frmrex_Dm_Phucap_Add = (Forms.Rex.Frmrex_Dm_Phucap_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Phucap_Add");

                //    if (frmrex_Dm_Phucap_Add == null || frmrex_Dm_Phucap_Add.IsDisposed)
                //        frmrex_Dm_Phucap_Add = new Forms.Rex.Frmrex_Dm_Phucap_Add();
                //    frmrex_Dm_Phucap_Add.Text = formText;
                //    frmrex_Dm_Phucap_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Phucap_Add.Show();
                //    frmrex_Dm_Phucap_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Chucvu_Add":
                //    frmrex_Dm_Chucvu_Add = (Forms.Rex.Frmrex_Dm_Chucvu_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Chucvu_Add");

                //    if (frmrex_Dm_Chucvu_Add == null || frmrex_Dm_Chucvu_Add.IsDisposed)
                //        frmrex_Dm_Chucvu_Add = new Forms.Rex.Frmrex_Dm_Chucvu_Add();
                //    frmrex_Dm_Chucvu_Add.Text = formText;
                //    frmrex_Dm_Chucvu_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Chucvu_Add.Show();
                //    frmrex_Dm_Chucvu_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Ngachluong_Add":
                //    frmrex_Dm_Ngachluong_Add = (Forms.Rex.Frmrex_Dm_Ngachluong_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Ngachluong_Add");

                //    if (frmrex_Dm_Ngachluong_Add == null || frmrex_Dm_Ngachluong_Add.IsDisposed)
                //        frmrex_Dm_Ngachluong_Add = new Forms.Rex.Frmrex_Dm_Ngachluong_Add();
                //    frmrex_Dm_Ngachluong_Add.Text = formText;
                //    frmrex_Dm_Ngachluong_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Ngachluong_Add.Show();
                //    frmrex_Dm_Ngachluong_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Bacluong_Add":
                //    frmrex_Dm_Bacluong_Add = (Forms.Rex.Frmrex_Dm_Bacluong_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Bacluong_Add");

                //    if (frmrex_Dm_Bacluong_Add == null || frmrex_Dm_Bacluong_Add.IsDisposed)
                //        frmrex_Dm_Bacluong_Add = new Forms.Rex.Frmrex_Dm_Bacluong_Add();
                //    frmrex_Dm_Bacluong_Add.Text = formText;
                //    frmrex_Dm_Bacluong_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Bacluong_Add.Show();
                //    frmrex_Dm_Bacluong_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Loai_Hopdong_Add":
                //    frmrex_Dm_Loai_Hopdong_Add = (Forms.Rex.Frmrex_Dm_Loai_Hopdong_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Loai_Hopdong_Add");

                //    if (frmrex_Dm_Loai_Hopdong_Add == null || frmrex_Dm_Loai_Hopdong_Add.IsDisposed)
                //        frmrex_Dm_Loai_Hopdong_Add = new Forms.Rex.Frmrex_Dm_Loai_Hopdong_Add();
                //    frmrex_Dm_Loai_Hopdong_Add.Text = formText;
                //    frmrex_Dm_Loai_Hopdong_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Loai_Hopdong_Add.Show();
                //    frmrex_Dm_Loai_Hopdong_Add.Activate();
                    //break;

                //case "Frmrex_Dm_Ngaynghi_Add":
                //    frmrex_Dm_Ngaynghi_Add = (Forms.Rex.Frmrex_Dm_Ngaynghi_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Ngaynghi_Add");

                //    if (frmrex_Dm_Ngaynghi_Add == null || frmrex_Dm_Ngaynghi_Add.IsDisposed)
                //        frmrex_Dm_Ngaynghi_Add = new Forms.Rex.Frmrex_Dm_Ngaynghi_Add();
                //    frmrex_Dm_Ngaynghi_Add.Text = formText;
                //    frmrex_Dm_Ngaynghi_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Ngaynghi_Add.Show();
                //    frmrex_Dm_Ngaynghi_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Ca_Lamviec_Add":
                //    frmrex_Dm_Ca_Lamviec_Add = (Forms.Rex.Frmrex_Dm_Ca_Lamviec_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Ca_Lamviec_Add");

                //    if (frmrex_Dm_Ca_Lamviec_Add == null || frmrex_Dm_Ca_Lamviec_Add.IsDisposed)
                //        frmrex_Dm_Ca_Lamviec_Add = new Forms.Rex.Frmrex_Dm_Ca_Lamviec_Add();
                //    frmrex_Dm_Ca_Lamviec_Add.Text = formText;
                //    frmrex_Dm_Ca_Lamviec_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Ca_Lamviec_Add.Show();
                //    frmrex_Dm_Ca_Lamviec_Add.Activate();
                //    break;


                case "Frmrex_Dm_Chungchi_Add":
                    frmrex_Dm_Chungchi_Add = (Forms.Rex.Frmrex_Dm_Chungchi_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Chungchi_Add");

                    if (frmrex_Dm_Chungchi_Add == null || frmrex_Dm_Chungchi_Add.IsDisposed)
                        frmrex_Dm_Chungchi_Add = new Forms.Rex.Frmrex_Dm_Chungchi_Add();
                    frmrex_Dm_Chungchi_Add.Text = formText;
                    frmrex_Dm_Chungchi_Add.MdiParent = mdiParent;
                    frmrex_Dm_Chungchi_Add.Show();
                    frmrex_Dm_Chungchi_Add.Activate();
                    break;

                //case "Frmrex_Dm_Khenthuong_Kyluat_Add":
                //    frmrex_Dm_Khenthuong_Kyluat_Add = (Forms.Rex.Frmrex_Dm_Khenthuong_Kyluat_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Khenthuong_Kyluat_Add");

                //    if (frmrex_Dm_Khenthuong_Kyluat_Add == null || frmrex_Dm_Khenthuong_Kyluat_Add.IsDisposed)
                //        frmrex_Dm_Khenthuong_Kyluat_Add = new Forms.Rex.Frmrex_Dm_Khenthuong_Kyluat_Add();
                //    frmrex_Dm_Khenthuong_Kyluat_Add.Text = formText;
                //    frmrex_Dm_Khenthuong_Kyluat_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Khenthuong_Kyluat_Add.Show();
                //    frmrex_Dm_Khenthuong_Kyluat_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Loai_Bophan_Add":
                //    frmrex_Dm_Loai_Bophan_Add = (Forms.Rex.Frmrex_Dm_Loai_Bophan_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Loai_Bophan_Add");

                //    if (frmrex_Dm_Loai_Bophan_Add == null || frmrex_Dm_Loai_Bophan_Add.IsDisposed)
                //        frmrex_Dm_Loai_Bophan_Add = new Forms.Rex.Frmrex_Dm_Loai_Bophan_Add();
                //    frmrex_Dm_Loai_Bophan_Add.Text = formText;
                //    frmrex_Dm_Loai_Bophan_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Loai_Bophan_Add.Show();
                //    frmrex_Dm_Loai_Bophan_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Loai_Ktkl_Add":
                //    frmrex_Dm_Loai_Ktkl_Add = (Forms.Rex.Frmrex_Dm_Loai_Ktkl_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Loai_Ktkl_Add");

                //    if (frmrex_Dm_Loai_Ktkl_Add == null || frmrex_Dm_Loai_Ktkl_Add.IsDisposed)
                //        frmrex_Dm_Loai_Ktkl_Add = new Forms.Rex.Frmrex_Dm_Loai_Ktkl_Add();
                //    frmrex_Dm_Loai_Ktkl_Add.Text = formText;
                //    frmrex_Dm_Loai_Ktkl_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Loai_Ktkl_Add.Show();
                //    frmrex_Dm_Loai_Ktkl_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Loai_Nghiphep_Add":
                //    frmrex_Dm_Loai_Nghiphep_Add = (Forms.Rex.Frmrex_Dm_Loai_Nghiphep_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Loai_Nghiphep_Add");

                //    if (frmrex_Dm_Loai_Nghiphep_Add == null || frmrex_Dm_Loai_Nghiphep_Add.IsDisposed)
                //        frmrex_Dm_Loai_Nghiphep_Add = new Forms.Rex.Frmrex_Dm_Loai_Nghiphep_Add();
                //    frmrex_Dm_Loai_Nghiphep_Add.Text = formText;
                //    frmrex_Dm_Loai_Nghiphep_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Loai_Nghiphep_Add.Show();
                //    frmrex_Dm_Loai_Nghiphep_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Phuongthuc_Huongluong_Add":
                //    frmrex_Dm_Phuongthuc_Huongluong_Add = (Forms.Rex.Frmrex_Dm_Phuongthuc_Huongluong_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Phuongthuc_Huongluong_Add");

                //    if (frmrex_Dm_Phuongthuc_Huongluong_Add == null || frmrex_Dm_Phuongthuc_Huongluong_Add.IsDisposed)
                //        frmrex_Dm_Phuongthuc_Huongluong_Add = new Forms.Rex.Frmrex_Dm_Phuongthuc_Huongluong_Add();
                //    frmrex_Dm_Phuongthuc_Huongluong_Add.Text = formText;
                //    frmrex_Dm_Phuongthuc_Huongluong_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Phuongthuc_Huongluong_Add.Show();
                //    frmrex_Dm_Phuongthuc_Huongluong_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Quanhe_Giadinh_Add":
                //    frmrex_Dm_Quanhe_Giadinh_Add = (Forms.Rex.Frmrex_Dm_Quanhe_Giadinh_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Quanhe_Giadinh_Add");

                //    if (frmrex_Dm_Quanhe_Giadinh_Add == null || frmrex_Dm_Quanhe_Giadinh_Add.IsDisposed)
                //        frmrex_Dm_Quanhe_Giadinh_Add = new Forms.Rex.Frmrex_Dm_Quanhe_Giadinh_Add();
                //    frmrex_Dm_Quanhe_Giadinh_Add.Text = formText;
                //    frmrex_Dm_Quanhe_Giadinh_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Quanhe_Giadinh_Add.Show();
                //    frmrex_Dm_Quanhe_Giadinh_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Quyetdinh_Add":
                //    frmrex_Dm_Quyetdinh_Add = (Forms.Rex.Frmrex_Dm_Quyetdinh_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Quyetdinh_Add");

                //    if (frmrex_Dm_Quyetdinh_Add == null || frmrex_Dm_Quyetdinh_Add.IsDisposed)
                //        frmrex_Dm_Quyetdinh_Add = new Forms.Rex.Frmrex_Dm_Quyetdinh_Add();
                //    frmrex_Dm_Quyetdinh_Add.Text = formText;
                //    frmrex_Dm_Quyetdinh_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Quyetdinh_Add.Show();
                //    frmrex_Dm_Quyetdinh_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Coquan_Add":
                //    frmrex_Dm_Coquan_Add = (Forms.Rex.Frmrex_Dm_Coquan_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Coquan_Add");

                //    if (frmrex_Dm_Coquan_Add == null || frmrex_Dm_Coquan_Add.IsDisposed)
                //        frmrex_Dm_Coquan_Add = new Forms.Rex.Frmrex_Dm_Coquan_Add();
                //    frmrex_Dm_Coquan_Add.Text = formText;
                //    frmrex_Dm_Coquan_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Coquan_Add.Show();
                //    frmrex_Dm_Coquan_Add.Activate();
                //    break;

                case "Frmrex_Dm_Tochuc_Add":
                    frmrex_Dm_Tochuc_Add = (Forms.Rex.Frmrex_Dm_Tochuc_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Tochuc_Add");

                    if (frmrex_Dm_Tochuc_Add == null || frmrex_Dm_Tochuc_Add.IsDisposed)
                        frmrex_Dm_Tochuc_Add = new Forms.Rex.Frmrex_Dm_Tochuc_Add();
                    frmrex_Dm_Tochuc_Add.Text = formText;
                    frmrex_Dm_Tochuc_Add.MdiParent = mdiParent;
                    frmrex_Dm_Tochuc_Add.Show();
                    frmrex_Dm_Tochuc_Add.Activate();
                    break;

                //case "Frmrex_Dm_Xeploai_Add":
                //    frmrex_Dm_Xeploai_Add = (Forms.Rex.Frmrex_Dm_Xeploai_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Xeploai_Add");

                //    if (frmrex_Dm_Xeploai_Add == null || frmrex_Dm_Xeploai_Add.IsDisposed)
                //        frmrex_Dm_Xeploai_Add = new Forms.Rex.Frmrex_Dm_Xeploai_Add();
                //    frmrex_Dm_Xeploai_Add.Text = formText;
                //    frmrex_Dm_Xeploai_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Xeploai_Add.Show();
                //    frmrex_Dm_Xeploai_Add.Activate();
                //    break;

                //case "Frmrex_Dm_Heso_Giotangca_Add":
                //    frmrex_Dm_Heso_Giotangca_Add = (Forms.Rex.Frmrex_Dm_Heso_Giotangca_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Heso_Giotangca_Add");

                //    if (frmrex_Dm_Heso_Giotangca_Add == null || frmrex_Dm_Heso_Giotangca_Add.IsDisposed)
                //        frmrex_Dm_Heso_Giotangca_Add = new Forms.Rex.Frmrex_Dm_Heso_Giotangca_Add();
                //    frmrex_Dm_Heso_Giotangca_Add.Text = formText;
                //    frmrex_Dm_Heso_Giotangca_Add.MdiParent = mdiParent;
                //    frmrex_Dm_Heso_Giotangca_Add.Show();
                //    frmrex_Dm_Heso_Giotangca_Add.Activate();
                //    break;
                case "Frmrex_Dm_Kynang_Chuyenmon_Add":
                    frmrex_Dm_Kynang_Chuyenmon_Add = (MasterTables.Forms.Rex.Frmrex_Dm_Kynang_Chuyenmon_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Kynang_Chuyenmon_Add");

                    if (frmrex_Dm_Kynang_Chuyenmon_Add == null || frmrex_Dm_Kynang_Chuyenmon_Add.IsDisposed)
                        frmrex_Dm_Kynang_Chuyenmon_Add = new MasterTables.Forms.Rex.Frmrex_Dm_Kynang_Chuyenmon_Add();
                    frmrex_Dm_Kynang_Chuyenmon_Add.Text = formText;
                    frmrex_Dm_Kynang_Chuyenmon_Add.MdiParent = mdiParent;
                    frmrex_Dm_Kynang_Chuyenmon_Add.Show();
                    frmrex_Dm_Kynang_Chuyenmon_Add.Activate();
                    break;
              
                //case "Frmrex_Dm_Ndung_Tgluong":
                //    frmrex_Dm_Ndung_Tgluong = (MasterTables.Forms.Rex.Frmrex_Dm_Ndung_Tgluong) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Dm_Ndung_Tgluong");

                //    if (frmrex_Dm_Ndung_Tgluong == null || frmrex_Dm_Ndung_Tgluong.IsDisposed)
                //        frmrex_Dm_Ndung_Tgluong = new MasterTables.Forms.Rex.Frmrex_Dm_Ndung_Tgluong();
                //    frmrex_Dm_Ndung_Tgluong.Text = formText;
                //    frmrex_Dm_Ndung_Tgluong.MdiParent = mdiParent;
                //    frmrex_Dm_Ndung_Tgluong.Show();
                //    frmrex_Dm_Ndung_Tgluong.Activate();
                //    break;

                    //acc
                //case "Frmacc_Dm_Thue_TNCN_Luytien":
                //    frmacc_Dm_Thue_TNCN_Luytien = (MasterTables.Forms.Accounting.Frmacc_Dm_Thue_TNCN_Luytien)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmacc_Dm_Thue_TNCN_Luytien");

                //    if (frmacc_Dm_Thue_TNCN_Luytien == null || frmacc_Dm_Thue_TNCN_Luytien.IsDisposed)
                //        frmacc_Dm_Thue_TNCN_Luytien = new MasterTables.Forms.Accounting.Frmacc_Dm_Thue_TNCN_Luytien();
                //    frmacc_Dm_Thue_TNCN_Luytien.Text = formText;
                //    frmacc_Dm_Thue_TNCN_Luytien.MdiParent = mdiParent;
                //    frmacc_Dm_Thue_TNCN_Luytien.Show();
                //    frmacc_Dm_Thue_TNCN_Luytien.Activate();
                //    break;

                case "Frmacc_Dm_Nganhang_Add":
                    Forms.Accounting.Frmacc_Dm_Nganhang_Add _Frmacc_Dm_Nganhang_Add;
                    _Frmacc_Dm_Nganhang_Add = (MasterTables.Forms.Accounting.Frmacc_Dm_Nganhang_Add)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmacc_Dm_Nganhang_Add");

                    if (_Frmacc_Dm_Nganhang_Add == null || _Frmacc_Dm_Nganhang_Add.IsDisposed)
                        _Frmacc_Dm_Nganhang_Add = new MasterTables.Forms.Accounting.Frmacc_Dm_Nganhang_Add();
                    _Frmacc_Dm_Nganhang_Add.Text = formText;
                    _Frmacc_Dm_Nganhang_Add.MdiParent = mdiParent;
                    _Frmacc_Dm_Nganhang_Add.Show();
                    _Frmacc_Dm_Nganhang_Add.Activate();
                    break;

            }
            WaitDialogForm.Close();
        }

        #region Implements Interface
        private string m_strName;
        private string m_PluginItemConfig;
        private IPluginHost m_Host;

        private System.Windows.Forms.Form mdiParent;
        public System.Windows.Forms.Form MdiParent
        {
            get { return mdiParent; }
            set { mdiParent = value; }
        }
        public string Name
        { get { return m_strName; } set { m_strName = value; } }

        public string PluginItemConfig
        { get { return m_PluginItemConfig; } set { m_PluginItemConfig = value; } }

        //public void Show(System.Windows.Forms.Form mdiParent)
        //{ 
        //    Main1 mn = new Main1();
        //    mn.ShowDialog();
        //}

        public IPluginHost Host
        {
            get { return m_Host; }
            set
            {
                m_Host = value;
                m_Host.Register(this);
            }
        }

        public void PreLoadData()
        {
            new System.Threading.Thread(new System.Threading.ThreadStart(this.PreLoadThread)).Start();
        }

        void PreLoadThread()
        {
            lock (this)
            {
                //frmrex_Dm_Dantoc_Add = new Ecm.MasterTables.Forms.Frmrex_Dm_Dantoc_Add();
                //frmrex_Dm_Dantoc_Add.Dispose();

                

                //DataLoaded = true;
            }
        }
        #endregion
    }
}
