using System;
using System.Collections.Generic;
using System.Text;
using GoobizFrame.Windows.PlugIn;

namespace Ecm.Rex.Plugins
{
    public class Rex_Time : IPlugin
    {
        public static bool DataLoaded = false;
        #region Forms
        Forms.Frmrex_Nghiphep frmrex_Nghiphep;
        Forms.Frmrex_Xepca_Thang frmrex_Xepca_Thang;
        Forms.Frmrex_Chamcong_Thang frmrex_Chamcong_Thang;
        Forms.Frmrex_Chamcong_Tangca frmrex_Chamcong_Tangca;
        Forms.Frmrex_Chon_Thang frmrex_Chon_Thang;
        #endregion

       

        public Rex_Time()
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
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm("Vui lòng chờ trong vài giây...", "Đang thực hiện");

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
                case "Frmrex_Xepca_Thang":
                    frmrex_Xepca_Thang = (Forms.Frmrex_Xepca_Thang)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Xepca_Thang");

                    if (frmrex_Xepca_Thang == null || frmrex_Xepca_Thang.IsDisposed)
                        frmrex_Xepca_Thang = new Forms.Frmrex_Xepca_Thang();
                    frmrex_Xepca_Thang.Text = formText;
                    frmrex_Xepca_Thang.MdiParent = mdiParent;
                    frmrex_Xepca_Thang.Show();
                    frmrex_Xepca_Thang.Activate();
                    break;

                case "Frmrex_Nghiphep":
                    frmrex_Nghiphep = (Forms.Frmrex_Nghiphep)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Nghiphep");

                    if (frmrex_Nghiphep == null || frmrex_Nghiphep.IsDisposed)
                        frmrex_Nghiphep = new Forms.Frmrex_Nghiphep();
                    frmrex_Nghiphep.Text = formText;
                    frmrex_Nghiphep.MdiParent = mdiParent;
                    frmrex_Nghiphep.Show();
                    frmrex_Nghiphep.Activate();
                    break;



                case "Frmrex_Chamcong_Thang":
                    frmrex_Chamcong_Thang = (Forms.Frmrex_Chamcong_Thang)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Chamcong_Thang");

                    if (frmrex_Chamcong_Thang == null || frmrex_Chamcong_Thang.IsDisposed)
                        frmrex_Chamcong_Thang = new Forms.Frmrex_Chamcong_Thang();
                    frmrex_Chamcong_Thang.Text = formText;
                    frmrex_Chamcong_Thang.MdiParent = mdiParent;
                    frmrex_Chamcong_Thang.Show();
                    frmrex_Chamcong_Thang.Activate();
                    break;

                case "Frmrex_Chamcong_Tangca":
                    frmrex_Chamcong_Tangca = (Forms.Frmrex_Chamcong_Tangca)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Chamcong_Tangca");

                    if (frmrex_Chamcong_Tangca == null || frmrex_Chamcong_Tangca.IsDisposed)
                        frmrex_Chamcong_Tangca = new Forms.Frmrex_Chamcong_Tangca();
                    frmrex_Chamcong_Tangca.Text = formText;
                    frmrex_Chamcong_Tangca.MdiParent = mdiParent;
                    frmrex_Chamcong_Tangca.Show();
                    frmrex_Chamcong_Tangca.Activate();
                    break;

                case "Frmrex_Chon_Thang":
                    frmrex_Chon_Thang = (Forms.Frmrex_Chon_Thang)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Chon_Thang");

                    if (frmrex_Chon_Thang == null || frmrex_Chon_Thang.IsDisposed)
                        frmrex_Chon_Thang = new Forms.Frmrex_Chon_Thang();
                    frmrex_Chon_Thang.Text = formText;
                    frmrex_Chon_Thang.MdiParent = mdiParent;
                    frmrex_Chon_Thang.Show();
                    frmrex_Chon_Thang.Activate();
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

                DataLoaded = true;
            }
        }
        #endregion
    }
}
