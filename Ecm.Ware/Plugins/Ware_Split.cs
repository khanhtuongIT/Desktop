using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.Ware.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Ware_Split : IPlugin
    {       
        //Forms.Frmware_Congtac frmware_Congtac;
        //Forms.Frmware_Congtac_Ketqua frmware_congtac_ketqua;
        //Forms.Frmware_Thumau frmWare_Thumau;
        //Forms.Frmware_Kehoach_Banhang frm_kehoach;
        //Forms.Frmware_Phantich_Thitruong frm_thitruong;


        bool DataLoaded = false;
        #region Forms

         GoobizFrame.Windows.Forms.FormReportWithHeader objFormReport;

        #endregion

        public Ware_Split()
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
            else if (e.GetType() == typeof(DevExpress.XtraBars.ItemClickEventArgs))
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
                case "FormReportWithHeader":
                    break;              

                case "FrmRptSplit_Sum_Hhban":
                    GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowExternalForm("Ecm.Reports.dll", "Ecm.Reports.Forms.FrmRptSplit_Sum_Hhban", this.MdiParent);
                    break;

                //case "Frmware_Congtac":
                //    frmware_Congtac = (Forms.Frmware_Congtac)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Congtac");

                //    if (frmware_Congtac == null || frmware_Congtac.IsDisposed)
                //        frmware_Congtac = new Forms.Frmware_Congtac();
                //    frmware_Congtac.Text = formText;
                //    frmware_Congtac.MdiParent = mdiParent;
                //    frmware_Congtac.Show();
                //    frmware_Congtac.Activate();
                //    break;

                //case "Frmware_Congtac_Ketqua":
                //    frmware_congtac_ketqua = (Forms.Frmware_Congtac_Ketqua)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Congtac_Ketqua");

                //    if (frmware_congtac_ketqua == null || frmware_congtac_ketqua.IsDisposed)
                //        frmware_congtac_ketqua = new Forms.Frmware_Congtac_Ketqua();
                //    frmware_congtac_ketqua.Text = formText;
                //    frmware_congtac_ketqua.MdiParent = mdiParent;
                //    frmware_congtac_ketqua.Show();
                //    frmware_congtac_ketqua.Activate();
                //    break;

                //case "Frmware_Thumau":
                //    frmWare_Thumau = (Forms.Frmware_Thumau)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Thumau");

                //    if (frmWare_Thumau == null || frmWare_Thumau.IsDisposed)
                //        frmWare_Thumau = new Forms.Frmware_Thumau();
                //    frmWare_Thumau.Text = formText;
                //    frmWare_Thumau.MdiParent = mdiParent;
                //    frmWare_Thumau.Show();
                //    frmWare_Thumau.Activate();
                //    break;

                //case "Frmware_Kehoach_Banhang":
                //    frm_kehoach = (Forms.Frmware_Kehoach_Banhang)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Kehoach_Banhang");

                //    if (frm_kehoach == null || frm_kehoach.IsDisposed)
                //        frm_kehoach = new Forms.Frmware_Kehoach_Banhang();
                //    frm_kehoach.Text = formText;
                //    frm_kehoach.MdiParent = mdiParent;
                //    frm_kehoach.Show();
                //    frm_kehoach.Activate();
                //    break;

                //case "Frmware_Phantich_Thitruong":
                //    frm_thitruong = (Forms.Frmware_Phantich_Thitruong)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Phantich_Thitruong");

                //    if (frm_thitruong == null || frm_thitruong.IsDisposed)
                //        frm_thitruong = new Forms.Frmware_Phantich_Thitruong();
                //    frm_thitruong.Text = formText;
                //    frm_thitruong.MdiParent = mdiParent;
                //    frm_thitruong.Show();
                //    frm_thitruong.Activate();
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
