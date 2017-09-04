using System;
using System.Collections.Generic;
using System.Text;
using GoobizFrame.Windows.PlugIn;

namespace Ecm.Rex.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Rex_Input : IPlugin
    {

        //bool DataLoaded = false;
        #region Forms
        Forms.Frmrex_Nhansu frmrex_Nhansu;
        //Forms.Frmrex_Hopdong_Laodong frmrex_Hopdong_Laodong;
        //Forms.Frmrex_Botri_Nhansu_Stt frmrex_Botri_Nhansu_Stt;
        #endregion

        public Rex_Input()
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
                case "Frmrex_Nhansu":
                    frmrex_Nhansu = (Forms.Frmrex_Nhansu)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Nhansu");

                    if (frmrex_Nhansu == null || frmrex_Nhansu.IsDisposed)
                        frmrex_Nhansu = new Forms.Frmrex_Nhansu();
                    frmrex_Nhansu.Text = formText;
                    frmrex_Nhansu.MdiParent = mdiParent;
                    frmrex_Nhansu.Show();
                    frmrex_Nhansu.Activate();
                    break;

                //case "Frmrex_Botri_Nhansu":
                //    frmrex_Botri_Nhansu_Stt = (Forms.Frmrex_Botri_Nhansu_Stt)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Botri_Nhansu");

                //    if (frmrex_Botri_Nhansu_Stt == null || frmrex_Botri_Nhansu_Stt.IsDisposed)
                //        frmrex_Botri_Nhansu_Stt = new Forms.Frmrex_Botri_Nhansu_Stt();
                //    frmrex_Botri_Nhansu_Stt.Text = formText;
                //    frmrex_Botri_Nhansu_Stt.MdiParent = mdiParent;
                //    frmrex_Botri_Nhansu_Stt.Show();
                //    frmrex_Botri_Nhansu_Stt.Activate();
                //    break;

                //case "Frmrex_Hopdong_Laodong":
                //    frmrex_Hopdong_Laodong = (Forms.Frmrex_Hopdong_Laodong)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Hopdong_Laodong");

                //    if (frmrex_Hopdong_Laodong == null || frmrex_Hopdong_Laodong.IsDisposed)
                //        frmrex_Hopdong_Laodong = new Forms.Frmrex_Hopdong_Laodong();
                //    frmrex_Hopdong_Laodong.Text = formText;
                //    frmrex_Hopdong_Laodong.MdiParent = mdiParent;
                //    frmrex_Hopdong_Laodong.Show();
                //    frmrex_Hopdong_Laodong.Activate();
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
               

                

                //DataLoaded = true;
            }
        }
        #endregion
    }
}
