using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.Ware.Plugins
{
    /// <summary>
    /// handle Ware_Input, Ware_Output
    /// </summary>
    public class Ware_Input : IPlugin
    {   

        bool DataLoaded = false;
        #region Forms
        //input
        //Forms.Frmware_Donmuahang            frmware_Donmuahang;
        Forms.Frmware_Hdmuahang             frmware_Hdmuahang;
        //Forms.Frmware_Nhap_Hh_Mua      frmware_Nhap_Hh_Mua;
        //Forms.Frmware_Hh_Mua_Tra_Ncc   frmware_Hh_Mua_Tra_Ncc;
        Forms.Frmware_Nhap_Hh_Ban      frmware_Nhap_Hh_Ban;
        Forms.FrmRptware_Hanghoa_Bangke_Doanhso frmRptware_Hanghoa_Bangke_Doanhso;


        #endregion

        public Ware_Input()
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
                #region Ware_Input  - Dự trù mua hàng, Nhập hàng hóa mua, nhập hàng hóa sản xuất

                //case "Frmware_Donmuahang":
                //    frmware_Donmuahang = (Forms.Frmware_Donmuahang) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Donmuahang");

                //    if (frmware_Donmuahang == null || frmware_Donmuahang.IsDisposed)
                //        frmware_Donmuahang = new Forms.Frmware_Donmuahang();
                //    frmware_Donmuahang.Text = formText;
                //    frmware_Donmuahang.MdiParent = mdiParent;
                //    frmware_Donmuahang.gvware_Donmuahang_Chitiet.Columns["Chon"].Visible = false;
                //    frmware_Donmuahang.Show();
                //    frmware_Donmuahang.Activate();
                //    break;

                case "Frmware_Hdmuahang":
                    frmware_Hdmuahang = (Forms.Frmware_Hdmuahang) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hdmuahang");

                    if (frmware_Hdmuahang == null || frmware_Hdmuahang.IsDisposed)
                        frmware_Hdmuahang = new Forms.Frmware_Hdmuahang();
                    frmware_Hdmuahang.Text = formText;
                    frmware_Hdmuahang.MdiParent = mdiParent;
                    frmware_Hdmuahang.Show();
                    frmware_Hdmuahang.Activate();
                    break;

                //case "Frmware_Nhap_Hh_Mua":
                //    frmware_Nhap_Hh_Mua = (Forms.Frmware_Nhap_Hh_Mua) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Nhap_Hh_Mua");

                //    if (frmware_Nhap_Hh_Mua == null || frmware_Nhap_Hh_Mua.IsDisposed)
                //        frmware_Nhap_Hh_Mua = new Forms.Frmware_Nhap_Hh_Mua();
                //    frmware_Nhap_Hh_Mua.Text = formText;
                //    frmware_Nhap_Hh_Mua.MdiParent = mdiParent;
                //    frmware_Nhap_Hh_Mua.Show();
                //    frmware_Nhap_Hh_Mua.Activate();
                //    break;

                //case "Frmware_Hh_Mua_Tra_Ncc":
                //    frmware_Hh_Mua_Tra_Ncc = (Forms.Frmware_Hh_Mua_Tra_Ncc) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hh_Mua_Tra_Ncc");

                //    if (frmware_Hh_Mua_Tra_Ncc == null || frmware_Hh_Mua_Tra_Ncc.IsDisposed)
                //        frmware_Hh_Mua_Tra_Ncc = new Forms.Frmware_Hh_Mua_Tra_Ncc();
                //    frmware_Hh_Mua_Tra_Ncc.Text = formText;
                //    frmware_Hh_Mua_Tra_Ncc.MdiParent = mdiParent;
                //    frmware_Hh_Mua_Tra_Ncc.Show();
                //    frmware_Hh_Mua_Tra_Ncc.Activate();
                //    break;

                case "Frmware_Nhap_Hh_Ban":
                    frmware_Nhap_Hh_Ban = (Forms.Frmware_Nhap_Hh_Ban) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Nhap_Hh_Ban");

                    if (frmware_Nhap_Hh_Ban == null || frmware_Nhap_Hh_Ban.IsDisposed)
                        frmware_Nhap_Hh_Ban = new Forms.Frmware_Nhap_Hh_Ban();
                    frmware_Nhap_Hh_Ban.Text = formText;
                    frmware_Nhap_Hh_Ban.MdiParent = mdiParent;
                    frmware_Nhap_Hh_Ban.Show();
                    frmware_Nhap_Hh_Ban.Activate();
                    break;

                case "FrmRptware_Hanghoa_Bangke_Doanhso":
                    frmRptware_Hanghoa_Bangke_Doanhso = (Forms.FrmRptware_Hanghoa_Bangke_Doanhso) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptware_Hanghoa_Bangke_Doanhso");

                    if (frmRptware_Hanghoa_Bangke_Doanhso == null || frmRptware_Hanghoa_Bangke_Doanhso.IsDisposed)
                        frmRptware_Hanghoa_Bangke_Doanhso = new Forms.FrmRptware_Hanghoa_Bangke_Doanhso();
                    frmRptware_Hanghoa_Bangke_Doanhso.Text = formText;
                    frmRptware_Hanghoa_Bangke_Doanhso.MdiParent = mdiParent;
                    frmRptware_Hanghoa_Bangke_Doanhso.Show();
                    frmRptware_Hanghoa_Bangke_Doanhso.Activate();
                    break;

                
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
