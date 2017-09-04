using System;
using System.Collections.Generic;
using System.Text;
using GoobizFrame.Windows.PlugIn;

namespace Ecm.Rex.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Rex_Pay : IPlugin
    {

        bool DataLoaded = false;
        #region Forms
        Forms.Frmrex_Kyluong frmrex_Kyluong;
        #endregion

        public Rex_Pay()
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
              
                case "Frmrex_Kyluong":
                    frmrex_Kyluong = (Forms.Frmrex_Kyluong)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Kyluong");

                    if (frmrex_Kyluong == null || frmrex_Kyluong.IsDisposed)
                        frmrex_Kyluong = new Forms.Frmrex_Kyluong();
                    frmrex_Kyluong.Text = formText;
                    frmrex_Kyluong.MdiParent = mdiParent;
                    frmrex_Kyluong.Show();
                    frmrex_Kyluong.Activate();
                    break;

                case "FrmRex_Tamung_Ky1":
                    var frmRex_Tamung_Ky1 = (Forms.Tienluong.FrmRex_Tamung_Ky1)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRex_Tamung_Ky1");

                    if (frmRex_Tamung_Ky1 == null || frmRex_Tamung_Ky1.IsDisposed)
                        frmRex_Tamung_Ky1 = new Forms.Tienluong.FrmRex_Tamung_Ky1();
                    frmRex_Tamung_Ky1.Text = formText;
                    frmRex_Tamung_Ky1.MdiParent = mdiParent;
                    frmRex_Tamung_Ky1.Show();
                    frmRex_Tamung_Ky1.Activate();
                    break;

                case "Frmrex_Luong_Tonghop":
                    var frmrex_Luong_Tonghop = (Forms.Frmrex_Luong_Tonghop)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmrex_Luong_Tonghop");

                    if (frmrex_Luong_Tonghop == null || frmrex_Luong_Tonghop.IsDisposed)
                        frmrex_Luong_Tonghop = new  Forms.Frmrex_Luong_Tonghop();
                    frmrex_Luong_Tonghop.Text = formText;
                    frmrex_Luong_Tonghop.MdiParent = mdiParent;
                    frmrex_Luong_Tonghop.Show();
                    frmrex_Luong_Tonghop.Activate();
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
               

                

                DataLoaded = true;
            }
        }
        #endregion
    }
}
