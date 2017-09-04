using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.Ware.Plugins
{
    /// <summary>
    /// Ecm.Ware.Ware_DirectSale
    /// </summary>
    public class Ware_PriceSale : IPlugin
    {   

        bool DataLoaded = false;
        #region Forms
        //direct sale
        Forms.Frmware_Hanghoa_Ban_Dinhgia frmware_Hanghoa_Ban_Dinhgia;
       

        //Forms.Frmware_Donmuahang_Kh_Hhban frmware_Donmuahang_Kh_Hhban;

        #endregion

        public Ware_PriceSale()
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
                formName = ((DevExpress.XtraNavBar.NavBarLinkEventArgs)e).Link.ItemName;
                formText = ((DevExpress.XtraNavBar.NavBarLinkEventArgs)e).Link.Caption;
            }
            else 
            if (e.GetType() == typeof(DevExpress.XtraBars.ItemClickEventArgs))
            {
                formName = ((DevExpress.XtraBars.ItemClickEventArgs)e).Item.Name;
                formText = ((DevExpress.XtraBars.ItemClickEventArgs)e).Item.Caption;
            }
            else
            {
                formName = ((System.Windows.Forms.Control)sender).Name;
                formText = ((System.Windows.Forms.Control)sender).Text;
            }
            switch (formName)
            {


                #region Ware_ProSale - Bán hàng hóa đã qua chế biến (thành phẩm)

                case "Frmware_Nhap_Hh_Ban":
                    Forms.Frmware_Nhap_Hh_Ban frmware_Nhap_Hh_Ban = (Forms.Frmware_Nhap_Hh_Ban)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Nhap_Hh_Ban");

                    if (frmware_Nhap_Hh_Ban == null || frmware_Nhap_Hh_Ban.IsDisposed)
                        frmware_Nhap_Hh_Ban = new Forms.Frmware_Nhap_Hh_Ban();
                    frmware_Nhap_Hh_Ban.Text = formText;
                    frmware_Nhap_Hh_Ban.MdiParent = mdiParent;
                    frmware_Nhap_Hh_Ban.Show();
                    frmware_Nhap_Hh_Ban.Activate();
                    break;

                case "Frmware_Congnothu_Dauky":
                    Forms.Frmware_Congnothu_Dauky _Frmware_Congnothu_Dauky = (Forms.Frmware_Congnothu_Dauky)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Congnothu_Dauky");

                    if (_Frmware_Congnothu_Dauky == null || _Frmware_Congnothu_Dauky.IsDisposed)
                        _Frmware_Congnothu_Dauky = new Forms.Frmware_Congnothu_Dauky();
                    _Frmware_Congnothu_Dauky.Text = formText;
                    _Frmware_Congnothu_Dauky.MdiParent = mdiParent;
                    _Frmware_Congnothu_Dauky.Show();
                    _Frmware_Congnothu_Dauky.Activate();
                    break;

                case "Frmware_Hanghoa_Ban_Dauky":
                    Forms.Frmware_Hanghoa_Ban_Dauky _Frmware_Hanghoa_Ban_Dauky = (Forms.Frmware_Hanghoa_Ban_Dauky)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hanghoa_Ban_Dauky");

                    if (_Frmware_Hanghoa_Ban_Dauky == null || _Frmware_Hanghoa_Ban_Dauky.IsDisposed)
                        _Frmware_Hanghoa_Ban_Dauky = new Forms.Frmware_Hanghoa_Ban_Dauky();
                    _Frmware_Hanghoa_Ban_Dauky.Text = formText;
                    _Frmware_Hanghoa_Ban_Dauky.MdiParent = mdiParent;
                    _Frmware_Hanghoa_Ban_Dauky.Show();
                    _Frmware_Hanghoa_Ban_Dauky.Activate();
                    break;

                case "Frmware_Xuat_Hh_Ban":
                    Forms.Frmware_Xuat_Hh_Ban _Frmware_Xuat_Hh_Ban = (Forms.Frmware_Xuat_Hh_Ban)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Xuat_Hh_Ban");

                    if (_Frmware_Xuat_Hh_Ban == null || _Frmware_Xuat_Hh_Ban.IsDisposed)
                        _Frmware_Xuat_Hh_Ban = new Forms.Frmware_Xuat_Hh_Ban();
                    _Frmware_Xuat_Hh_Ban.Text = formText;
                    _Frmware_Xuat_Hh_Ban.MdiParent = mdiParent;
                    _Frmware_Xuat_Hh_Ban.Show();
                    _Frmware_Xuat_Hh_Ban.Activate();
                    break;

                //case "Frmware_Xuat_Nguyenlieu":
                //    Forms.Frmware_Xuat_Nguyenlieu _Frmware_Xuat_Nguyenlieu = (Forms.Frmware_Xuat_Nguyenlieu)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Xuat_Nguyenlieu");

                //    if (_Frmware_Xuat_Nguyenlieu == null || _Frmware_Xuat_Nguyenlieu.IsDisposed)
                //        _Frmware_Xuat_Nguyenlieu = new Forms.Frmware_Xuat_Nguyenlieu();
                //    _Frmware_Xuat_Nguyenlieu.Text = formText;
                //    _Frmware_Xuat_Nguyenlieu.MdiParent = mdiParent;
                //    _Frmware_Xuat_Nguyenlieu.Show();
                //    _Frmware_Xuat_Nguyenlieu.Activate();
                //    break;

                case "Frmware_Dieuxe":
                    Forms.Frmware_Dieuxe _Frmware_Dieuxe = (Forms.Frmware_Dieuxe)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Dieuxe");

                    if (_Frmware_Dieuxe == null || _Frmware_Dieuxe.IsDisposed)
                        _Frmware_Dieuxe = new Forms.Frmware_Dieuxe();
                    _Frmware_Dieuxe.Text = formText;
                    _Frmware_Dieuxe.MdiParent = mdiParent;
                    _Frmware_Dieuxe.Show();
                    _Frmware_Dieuxe.Activate();
                    break;

                //case "Frmware_Dm_Hanghoa_Ban_Import":
                //    frmware_Dm_Hanghoa_Ban_Import = (Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Import) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Dm_Hanghoa_Ban_Import");

                //    if (frmware_Dm_Hanghoa_Ban_Import == null || frmware_Dm_Hanghoa_Ban_Import.IsDisposed)
                //        frmware_Dm_Hanghoa_Ban_Import = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Hanghoa_Ban_Import();
                //    frmware_Dm_Hanghoa_Ban_Import.Text = formText;
                //    frmware_Dm_Hanghoa_Ban_Import.MdiParent = mdiParent;
                //    frmware_Dm_Hanghoa_Ban_Import.Show();
                //    frmware_Dm_Hanghoa_Ban_Import.Activate();
                //    break;

                case "Frmware_Kiemke_Hanghoa_Ban":
                    Forms.Frmware_Kiemke_Hanghoa_Ban frmware_Kiemke_Hanghoa_Ban = (Forms.Frmware_Kiemke_Hanghoa_Ban)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Kiemke_Hanghoa_Ban");

                    if (frmware_Kiemke_Hanghoa_Ban == null || frmware_Kiemke_Hanghoa_Ban.IsDisposed)
                        frmware_Kiemke_Hanghoa_Ban = new Forms.Frmware_Kiemke_Hanghoa_Ban();
                    frmware_Kiemke_Hanghoa_Ban.Text = formText;
                    frmware_Kiemke_Hanghoa_Ban.MdiParent = mdiParent;
                    frmware_Kiemke_Hanghoa_Ban.Show();
                    frmware_Kiemke_Hanghoa_Ban.Activate();
                    break;

                case "Frmware_Xuat_Chuyen_Noibo":
                    Forms.Frmware_Xuat_Chuyen_Noibo _Frmware_Xuat_Chuyen_Noibo = (Forms.Frmware_Xuat_Chuyen_Noibo)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Xuat_Chuyen_Noibo");

                    if (_Frmware_Xuat_Chuyen_Noibo == null || _Frmware_Xuat_Chuyen_Noibo.IsDisposed)
                        _Frmware_Xuat_Chuyen_Noibo = new Forms.Frmware_Xuat_Chuyen_Noibo();
                    _Frmware_Xuat_Chuyen_Noibo.Text = formText;
                    _Frmware_Xuat_Chuyen_Noibo.MdiParent = mdiParent;
                    _Frmware_Xuat_Chuyen_Noibo.Show();
                    _Frmware_Xuat_Chuyen_Noibo.Activate();
                    break;

                case "Frmware_Hanghoa_Ban_Dinhgia":
                    frmware_Hanghoa_Ban_Dinhgia = (Forms.Frmware_Hanghoa_Ban_Dinhgia) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hanghoa_Ban_Dinhgia");

                    if (frmware_Hanghoa_Ban_Dinhgia == null || frmware_Hanghoa_Ban_Dinhgia.IsDisposed)
                        frmware_Hanghoa_Ban_Dinhgia = new Forms.Frmware_Hanghoa_Ban_Dinhgia();
                    frmware_Hanghoa_Ban_Dinhgia.Text = formText;
                    frmware_Hanghoa_Ban_Dinhgia.MdiParent = mdiParent;
                    frmware_Hanghoa_Ban_Dinhgia.Show();
                    frmware_Hanghoa_Ban_Dinhgia.Activate();
                    break;
               

                //case "Frmware_Donmuahang_Kh_Hhban":
                //    frmware_Donmuahang_Kh_Hhban = (Forms.Frmware_Donmuahang_Kh_Hhban) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Donmuahang_Kh_Hhban");

                //    if (frmware_Donmuahang_Kh_Hhban == null || frmware_Donmuahang_Kh_Hhban.IsDisposed)
                //        frmware_Donmuahang_Kh_Hhban = new Forms.Frmware_Donmuahang_Kh_Hhban();
                //    frmware_Donmuahang_Kh_Hhban.Text = formText;
                //    frmware_Donmuahang_Kh_Hhban.MdiParent = mdiParent;
                //    frmware_Donmuahang_Kh_Hhban.Show();
                //    frmware_Donmuahang_Kh_Hhban.Activate();
                //    break;
               
                #endregion

                //default:
                //     GoobizFrame.Windows.Forms.MessageDialog.Show("Chức năng " + formText + " đang được xây dựng");
                //    break;
               
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
                //frmware_Dm_Cuahang_Ban_Add = new Ecm.Ware.Forms.Frmware_Dm_Cuahang_Ban_Add();
                //frmware_Dm_Cuahang_Ban_Add.Dispose();

                

                DataLoaded = true;
            }
        }
        #endregion
    }
}
