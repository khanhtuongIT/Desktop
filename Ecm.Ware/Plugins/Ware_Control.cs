using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.Ware.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Ware_Control : IPlugin
    {

        bool DataLoaded = false;
        #region Forms
        //Forms.FrmRptWare_DataLog frmRptWare_DataLog;
        Forms.Frmware_Kh_Hh_Ban frmware_Kh_Hh_Ban;
        //Forms.FrmRptware_NL_Hhsx frmRptware_NL_Hhsx;
        Forms.FrmRptware_Nxt_Hhban_Notify frmRptware_Nxt_Hhban_Notify;
       #endregion

        public Ware_Control()
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
               
                //case "FrmRptWare_DataLog":
                //    frmRptWare_DataLog = (Forms.FrmRptWare_DataLog) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptWare_DataLog");

                //    if (frmRptWare_DataLog == null || frmRptWare_DataLog.IsDisposed)
                //        frmRptWare_DataLog = new Forms.FrmRptWare_DataLog();
                //    frmRptWare_DataLog.Text = formText;
                //    frmRptWare_DataLog.MdiParent = mdiParent;
                //    frmRptWare_DataLog.Show();
                //    frmRptWare_DataLog.Activate();
                //    break;

                case "Frmware_Kh_Hh_Ban":
                    frmware_Kh_Hh_Ban = (Forms.Frmware_Kh_Hh_Ban)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Kh_Hh_Ban");

                    if (frmware_Kh_Hh_Ban == null || frmware_Kh_Hh_Ban.IsDisposed)
                        frmware_Kh_Hh_Ban = new Forms.Frmware_Kh_Hh_Ban();
                    frmware_Kh_Hh_Ban.Text = formText;
                    frmware_Kh_Hh_Ban.MdiParent = mdiParent;
                    frmware_Kh_Hh_Ban.Show();
                    frmware_Kh_Hh_Ban.Activate();
                    break;
                //case "FrmRptware_NL_Hhsx":
                //    frmRptware_NL_Hhsx = (Forms.FrmRptware_NL_Hhsx)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptware_NL_Hhsx");

                //    if (frmRptware_NL_Hhsx == null || frmRptware_NL_Hhsx.IsDisposed)
                //        frmRptware_NL_Hhsx = new Forms.FrmRptware_NL_Hhsx();
                //    frmRptware_NL_Hhsx.Text = formText;
                //    frmRptware_NL_Hhsx.MdiParent = mdiParent;
                //    frmRptware_NL_Hhsx.Show();
                //    frmRptware_NL_Hhsx.Activate();
                //    break;
                case "FrmRptware_Nxt_Hhban_Notify":
                    frmRptware_Nxt_Hhban_Notify = (Forms.FrmRptware_Nxt_Hhban_Notify)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptware_Nxt_Hhban_Notify");

                    if (frmRptware_Nxt_Hhban_Notify == null || frmRptware_Nxt_Hhban_Notify.IsDisposed)
                        frmRptware_Nxt_Hhban_Notify = new Forms.FrmRptware_Nxt_Hhban_Notify();
                    frmRptware_Nxt_Hhban_Notify.Text = formText;
                    frmRptware_Nxt_Hhban_Notify.MdiParent = mdiParent;
                    frmRptware_Nxt_Hhban_Notify.Show();
                    frmRptware_Nxt_Hhban_Notify.Activate();
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
                //frmware_Dm_Cuahang_Ban_Add = new Ecm.Ware.Forms.Frmware_Dm_Cuahang_Ban_Add();
                //frmware_Dm_Cuahang_Ban_Add.Dispose();

                

                DataLoaded = true;
            }
        }
        #endregion
    }
}
