using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.Ware.Plugins
{
    /// <summary>
    /// Ecm.Ware.Ware_DirectSale
    /// </summary>
    public class Ware_DirectSale : IPlugin
    {   

        bool DataLoaded = false;
        #region Forms
        //direct sale
        //Forms.Frmware_Hdbanhang_Hhmua       frmware_Hdbanhang_Pro;
        //Forms.Frmware_Hh_Mua_Kh_Tra    frmware_Hh_Mua_Kh_Tra;
        //Forms.Frmware_Hdbanhang_noVAT_Hhmua frmware_Hdbanhang_noVAT_Hhmua;

        #endregion

        public Ware_DirectSale()
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

                #region Ware_DirectSale - Bán trực tiếp hàng hóa mua

               
                //case "Frmware_Hh_Mua_Kh_Tra":
                //    frmware_Hh_Mua_Kh_Tra = (Forms.Frmware_Hh_Mua_Kh_Tra) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hh_Mua_Kh_Tra");

                //    if (frmware_Hh_Mua_Kh_Tra == null || frmware_Hh_Mua_Kh_Tra.IsDisposed)
                //        frmware_Hh_Mua_Kh_Tra = new Forms.Frmware_Hh_Mua_Kh_Tra();
                //    frmware_Hh_Mua_Kh_Tra.Text = formText;
                //    frmware_Hh_Mua_Kh_Tra.MdiParent = mdiParent;
                //    frmware_Hh_Mua_Kh_Tra.Show();
                //    frmware_Hh_Mua_Kh_Tra.Activate();
                //    break;
                
                //case "Frmware_Hdbanhang_noVAT_Hhmua":
                //    frmware_Hdbanhang_noVAT_Hhmua = (Forms.Frmware_Hdbanhang_noVAT_Hhmua) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hdbanhang_noVAT_Hhmua");

                //    if (frmware_Hdbanhang_noVAT_Hhmua == null || frmware_Hdbanhang_noVAT_Hhmua.IsDisposed)
                //        frmware_Hdbanhang_noVAT_Hhmua = new Forms.Frmware_Hdbanhang_noVAT_Hhmua();
                //    frmware_Hdbanhang_noVAT_Hhmua.Text = formText;
                //    frmware_Hdbanhang_noVAT_Hhmua.MdiParent = mdiParent;
                //    frmware_Hdbanhang_noVAT_Hhmua.Show();
                //    frmware_Hdbanhang_noVAT_Hhmua.Activate();
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
