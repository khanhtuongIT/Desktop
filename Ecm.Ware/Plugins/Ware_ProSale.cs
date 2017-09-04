using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.Ware.Plugins
{
    /// <summary>
    /// Ecm.Ware.Ware_DirectSale
    /// </summary>
    public class Ware_ProSale : IPlugin
    {   

        bool DataLoaded = false;
        #region Forms
        //pro sale
        //Forms.Frmware_Hdbanhang_Hhban frmware_Hdbanhang;
        Forms.Frmware_Hdbanhang_noVAT_Hhban frmware_Hdbanhang_noVAT;
        Forms.Frmware_Xuat_Hh_Ban frmware_Hdbanhang_Xuatkho;
        Forms.Frmware_Kehoach_Dathang _Frmware_Kehoach_Dathang;
        Forms.Frmware_Baocao_Chitiet_Banhang _Frmware_Baocao_Chitiet_Banhang;
        Forms.Frmware_Congno_Phaithu _Frmware_Congno_Phaithu;
        Forms.Frmware_Dondathang _Frmware_Dondathang;
        Forms.Frmware_Hh_Ban_Kh_Tra _Frmware_Hh_Ban_Kh_Tra;
       
        //Forms.Frmware_Hdbanhang_Xuatkho_MngrEdit frmware_Hdbanhang_Xuatkho_MngrEdit;
        //Forms.Frmware_Hdbanhang_Xuatkho_Kh_Tra frmware_Hdbanhang_Xuatkho_Kh_Tra;        

        #endregion

        public Ware_ProSale()
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

                case "Frmware_Dm_Dinhluong_Add":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Ecm.MasterTables.Forms.Ware.Frmware_Dm_Dinhluong_Add>(mdiParent, formText);
                    break;

                case "FrmRptware_Baocao_Congno_Sale":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Ecm.Ware.Forms.FrmRptware_Baocao_Congno_Sale>(mdiParent, formText);
                    break;

                case "Frmware_Kehoach_Dathang":
                    _Frmware_Kehoach_Dathang = (Forms.Frmware_Kehoach_Dathang)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Kehoach_Dathang");

                    if (_Frmware_Kehoach_Dathang == null || _Frmware_Kehoach_Dathang.IsDisposed)
                        _Frmware_Kehoach_Dathang = new Forms.Frmware_Kehoach_Dathang();
                    _Frmware_Kehoach_Dathang.Text = formText;
                    _Frmware_Kehoach_Dathang.MdiParent = mdiParent;
                    _Frmware_Kehoach_Dathang.Show();
                    _Frmware_Kehoach_Dathang.Activate();
                    break;

                case "Frmware_Baocao_Chitiet_Banhang":
                    _Frmware_Baocao_Chitiet_Banhang = (Forms.Frmware_Baocao_Chitiet_Banhang)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Baocao_Chitiet_Banhang");

                    if (_Frmware_Baocao_Chitiet_Banhang == null || _Frmware_Baocao_Chitiet_Banhang.IsDisposed)
                        _Frmware_Baocao_Chitiet_Banhang = new Forms.Frmware_Baocao_Chitiet_Banhang();
                    _Frmware_Baocao_Chitiet_Banhang.Text = formText;
                    _Frmware_Baocao_Chitiet_Banhang.MdiParent = mdiParent;
                    _Frmware_Baocao_Chitiet_Banhang.Show();
                    _Frmware_Baocao_Chitiet_Banhang.Activate();
                    break;

                case "Frmware_Congno_Phaithu":
                    _Frmware_Congno_Phaithu = (Forms.Frmware_Congno_Phaithu)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Congno_Phaithu");

                    if (_Frmware_Congno_Phaithu == null || _Frmware_Congno_Phaithu.IsDisposed)
                        _Frmware_Congno_Phaithu = new Forms.Frmware_Congno_Phaithu();
                    _Frmware_Congno_Phaithu.Text = formText;
                    _Frmware_Congno_Phaithu.MdiParent = mdiParent;
                    _Frmware_Congno_Phaithu.Show();
                    _Frmware_Congno_Phaithu.Activate();
                    break;

                case "Frmware_Dondathang":
                    _Frmware_Dondathang = (Forms.Frmware_Dondathang)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Dondathang");

                    if (_Frmware_Dondathang == null || _Frmware_Dondathang.IsDisposed)
                        _Frmware_Dondathang = new Forms.Frmware_Dondathang();
                    _Frmware_Dondathang.Text = formText;
                    _Frmware_Dondathang.MdiParent = mdiParent;
                    _Frmware_Dondathang.Show();
                    _Frmware_Dondathang.Activate();
                    break;

                case "Frmware_Hh_Ban_Kh_Tra":
                    _Frmware_Hh_Ban_Kh_Tra = (Forms.Frmware_Hh_Ban_Kh_Tra)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hh_Ban_Kh_Tra");

                    if (_Frmware_Hh_Ban_Kh_Tra == null || _Frmware_Hh_Ban_Kh_Tra.IsDisposed)
                        _Frmware_Hh_Ban_Kh_Tra = new Forms.Frmware_Hh_Ban_Kh_Tra();
                    _Frmware_Hh_Ban_Kh_Tra.Text = formText;
                    _Frmware_Hh_Ban_Kh_Tra.MdiParent = mdiParent;
                    _Frmware_Hh_Ban_Kh_Tra.Show();
                    _Frmware_Hh_Ban_Kh_Tra.Activate();
                    break;

                //case "Frmware_Hanghoa_Tra":
                //    _Rrmware_Hanghoa_Tra = (Forms.SaleInfo.Frmware_Hanghoa_Tra)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hanghoa_Tra");

                //    if (_Rrmware_Hanghoa_Tra == null || _Rrmware_Hanghoa_Tra.IsDisposed)
                //        _Rrmware_Hanghoa_Tra = new Forms.SaleInfo.Frmware_Hanghoa_Tra();
                //    _Rrmware_Hanghoa_Tra.Text = formText;
                //    _Rrmware_Hanghoa_Tra.MdiParent = mdiParent;
                //    _Rrmware_Hanghoa_Tra.Show();
                //    _Rrmware_Hanghoa_Tra.Activate();
                //    break;

               

                //case "Frmware_Hdbanhang_Hhban":
                //    frmware_Hdbanhang = (Forms.Frmware_Hdbanhang_Hhban) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hdbanhang_Hhban");

                //    if (frmware_Hdbanhang == null || frmware_Hdbanhang.IsDisposed)
                //        frmware_Hdbanhang = new Forms.Frmware_Hdbanhang_Hhban();
                //    frmware_Hdbanhang.Text = formText;
                //    frmware_Hdbanhang.MdiParent = mdiParent;
                //    frmware_Hdbanhang.Show();
                //    frmware_Hdbanhang.Activate();
                //    break;

                case "Frmware_Hdbanhang_noVAT_Hhban":
                    frmware_Hdbanhang_noVAT = (Forms.Frmware_Hdbanhang_noVAT_Hhban) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hdbanhang_noVAT_Hhban");

                    if (frmware_Hdbanhang_noVAT == null || frmware_Hdbanhang_noVAT.IsDisposed)
                        frmware_Hdbanhang_noVAT = new Forms.Frmware_Hdbanhang_noVAT_Hhban();
                    frmware_Hdbanhang_noVAT.Text = formText;
                    frmware_Hdbanhang_noVAT.MdiParent = mdiParent;
                    frmware_Hdbanhang_noVAT.Show();
                    frmware_Hdbanhang_noVAT.Activate();
                    break;

                    // dùng form xuất nội bộ thay xuất kho bán hàng 
                case "Frmware_Hdbanhang_Xuatkho":
                    frmware_Hdbanhang_Xuatkho = (Forms.Frmware_Xuat_Hh_Ban)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Xuat_Hh_Ban");

                    if (frmware_Hdbanhang_Xuatkho == null || frmware_Hdbanhang_Xuatkho.IsDisposed)
                        frmware_Hdbanhang_Xuatkho = new Forms.Frmware_Xuat_Hh_Ban();
                    frmware_Hdbanhang_Xuatkho.Text = formText;
                    frmware_Hdbanhang_Xuatkho.MdiParent = mdiParent;
                    frmware_Hdbanhang_Xuatkho.Show();
                    frmware_Hdbanhang_Xuatkho.Activate();
                    break;

                //case "Frmware_Hdbanhang_Xuatkho":
                //    frmware_Hdbanhang_Xuatkho = (Forms.Frmware_Hdbanhang_Xuatkho)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hdbanhang_Xuatkho");

                //    if (frmware_Hdbanhang_Xuatkho == null || frmware_Hdbanhang_Xuatkho.IsDisposed)
                //        frmware_Hdbanhang_Xuatkho = new Forms.Frmware_Hdbanhang_Xuatkho();
                //    frmware_Hdbanhang_Xuatkho.Text = formText;
                //    frmware_Hdbanhang_Xuatkho.MdiParent = mdiParent;
                //    frmware_Hdbanhang_Xuatkho.Show();
                //    frmware_Hdbanhang_Xuatkho.Activate();
                //    break;

                //case "Frmware_Hdbanhang_Xuatkho_MngrEdit":
                //    frmware_Hdbanhang_Xuatkho_MngrEdit = (Forms.Frmware_Hdbanhang_Xuatkho_MngrEdit) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hdbanhang_Xuatkho_MngrEdit");

                //    if (frmware_Hdbanhang_Xuatkho_MngrEdit == null || frmware_Hdbanhang_Xuatkho_MngrEdit.IsDisposed)
                //        frmware_Hdbanhang_Xuatkho_MngrEdit = new Forms.Frmware_Hdbanhang_Xuatkho_MngrEdit();
                //    frmware_Hdbanhang_Xuatkho_MngrEdit.Text = formText;
                //    frmware_Hdbanhang_Xuatkho_MngrEdit.MdiParent = mdiParent;
                //    frmware_Hdbanhang_Xuatkho_MngrEdit.Show();
                //    frmware_Hdbanhang_Xuatkho_MngrEdit.Activate();
                //    break;

                //case "Frmware_Hdbanhang_Xuatkho_Kh_Tra":
                //    frmware_Hdbanhang_Xuatkho_Kh_Tra = (Forms.Frmware_Hdbanhang_Xuatkho_Kh_Tra) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hdbanhang_Xuatkho_Kh_Tra");

                //    if (frmware_Hdbanhang_Xuatkho_Kh_Tra == null || frmware_Hdbanhang_Xuatkho_Kh_Tra.IsDisposed)
                //        frmware_Hdbanhang_Xuatkho_Kh_Tra = new Forms.Frmware_Hdbanhang_Xuatkho_Kh_Tra();
                //    frmware_Hdbanhang_Xuatkho_Kh_Tra.Text = formText;
                //    frmware_Hdbanhang_Xuatkho_Kh_Tra.MdiParent = mdiParent;
                //    frmware_Hdbanhang_Xuatkho_Kh_Tra.Show();
                //    frmware_Hdbanhang_Xuatkho_Kh_Tra.Activate();
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
