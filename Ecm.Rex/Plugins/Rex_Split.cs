using System;
using System.Collections.Generic;
using System.Text;
using GoobizFrame.Windows.PlugIn;

namespace Ecm.Rex.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Rex_Split : IPlugin
    {

        bool DataLoaded = false;
        #region Forms
        //Forms.FrmRptRex_Thongke_Nhansu frmRptRex_Thongke_Nhansu;
        Forms.FrmRptRex_Thongke_Phepnam frmRptRex_Thongke_Phepnam;
        Forms.FrmRptRex_Thongke_Loai_Hopdong frmRptRex_Thongke_Loai_Hopdong;
        #endregion

        public Rex_Split()
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
                //case "FrmRptRex_Thongke_Nhansu":
                //    frmRptRex_Thongke_Nhansu = (Forms.FrmRptRex_Thongke_Nhansu)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Thongke_Nhansu");

                //    if (frmRptRex_Thongke_Nhansu == null || frmRptRex_Thongke_Nhansu.IsDisposed)
                //        frmRptRex_Thongke_Nhansu = new Forms.FrmRptRex_Thongke_Nhansu();
                //    frmRptRex_Thongke_Nhansu.Text = formText;
                //    frmRptRex_Thongke_Nhansu.MdiParent = mdiParent;
                //    frmRptRex_Thongke_Nhansu.Show();
                //    frmRptRex_Thongke_Nhansu.Activate();
                //    break;

                case "FrmRptRex_Thongke_Phepnam":
                    frmRptRex_Thongke_Phepnam = (Forms.FrmRptRex_Thongke_Phepnam)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Thongke_Phepnam");

                    if (frmRptRex_Thongke_Phepnam == null || frmRptRex_Thongke_Phepnam.IsDisposed)
                        frmRptRex_Thongke_Phepnam = new Forms.FrmRptRex_Thongke_Phepnam();
                    frmRptRex_Thongke_Phepnam.Text = formText;
                    frmRptRex_Thongke_Phepnam.MdiParent = mdiParent;
                    frmRptRex_Thongke_Phepnam.Show();
                    frmRptRex_Thongke_Phepnam.Activate();
                    break;

                case "FrmRptRex_Thongke_Loai_Hopdong":
                    frmRptRex_Thongke_Loai_Hopdong = (Forms.FrmRptRex_Thongke_Loai_Hopdong)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptRex_Thongke_Loai_Hopdong");

                    if (frmRptRex_Thongke_Loai_Hopdong == null || frmRptRex_Thongke_Loai_Hopdong.IsDisposed)
                        frmRptRex_Thongke_Loai_Hopdong = new Forms.FrmRptRex_Thongke_Loai_Hopdong();
                    frmRptRex_Thongke_Loai_Hopdong.Text = formText;
                    frmRptRex_Thongke_Loai_Hopdong.MdiParent = mdiParent;
                    frmRptRex_Thongke_Loai_Hopdong.Show();
                    frmRptRex_Thongke_Loai_Hopdong.Activate();
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
