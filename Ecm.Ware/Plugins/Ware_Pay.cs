using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.Ware.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Ware_Pay : IPlugin
    {

        bool DataLoaded = false;
        #region Forms
        Forms.Frmware_So_Quytm frmware_So_Quytm;
        Forms.Frmware_Phieu_Thu         frmware_Phieu_Thu;
        Forms.Frmware_Phieu_Thu_Congno  frmware_Phieu_Thu_Congno;
        Forms.Frmware_Phieu_Chi         frmware_Phieu_Chi;
        Forms.Frmware_Phieu_Chi_Congno  frmware_Phieu_Chi_Congno;
        //Forms.Frmware_Quytm_Dauky       frmware_Quytm_Dauky;
        Forms.Frmware_Congnotra_Dauky   frmware_Congnotra_Dauky;
        Forms.Frmware_Congnothu_Dauky   frmware_Congnothu_Dauky;

        #endregion

        public Ware_Pay()
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

                case "Frmware_Phieu_Thu":
                    frmware_Phieu_Thu = (Forms.Frmware_Phieu_Thu) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Phieu_Thu");

                    if (frmware_Phieu_Thu == null || frmware_Phieu_Thu.IsDisposed)
                        frmware_Phieu_Thu = new Forms.Frmware_Phieu_Thu();
                    frmware_Phieu_Thu.Text = formText;
                    frmware_Phieu_Thu.MdiParent = mdiParent;
                    frmware_Phieu_Thu.Show();
                    frmware_Phieu_Thu.Activate();
                    break;

                case "Frmware_Phieu_Thu_Congno":
                    frmware_Phieu_Thu_Congno = (Forms.Frmware_Phieu_Thu_Congno) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Phieu_Thu_Congno");

                    if (frmware_Phieu_Thu_Congno == null || frmware_Phieu_Thu_Congno.IsDisposed)
                        frmware_Phieu_Thu_Congno = new Forms.Frmware_Phieu_Thu_Congno();
                    frmware_Phieu_Thu_Congno.Text = formText;
                    frmware_Phieu_Thu_Congno.MdiParent = mdiParent;
                    frmware_Phieu_Thu_Congno.Show();
                    frmware_Phieu_Thu_Congno.Activate();
                    break;
                
                case "Frmware_Phieu_Chi":
                    frmware_Phieu_Chi = (Forms.Frmware_Phieu_Chi) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Phieu_Chi");

                    if (frmware_Phieu_Chi == null || frmware_Phieu_Chi.IsDisposed)
                        frmware_Phieu_Chi = new Forms.Frmware_Phieu_Chi();
                    frmware_Phieu_Chi.Text = formText;
                    frmware_Phieu_Chi.MdiParent = mdiParent;
                    frmware_Phieu_Chi.Show();
                    frmware_Phieu_Chi.Activate();
                    break;


                case "Frmware_Phieu_Chi_Congno":
                    frmware_Phieu_Chi_Congno = (Forms.Frmware_Phieu_Chi_Congno) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Phieu_Chi_Congno");

                    if (frmware_Phieu_Chi_Congno == null || frmware_Phieu_Chi_Congno.IsDisposed)
                        frmware_Phieu_Chi_Congno = new Forms.Frmware_Phieu_Chi_Congno();
                    frmware_Phieu_Chi_Congno.Text = formText;
                    frmware_Phieu_Chi_Congno.MdiParent = mdiParent;
                    frmware_Phieu_Chi_Congno.Show();
                    frmware_Phieu_Chi_Congno.Activate();
                    break;

                //case "Frmware_Quytm_Dauky":
                //    frmware_Quytm_Dauky = (Forms.Frmware_Quytm_Dauky) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Quytm_Dauky");

                //    if (frmware_Quytm_Dauky == null || frmware_Quytm_Dauky.IsDisposed)
                //        frmware_Quytm_Dauky = new Forms.Frmware_Quytm_Dauky();
                //    frmware_Quytm_Dauky.Text = formText;
                //    frmware_Quytm_Dauky.MdiParent = mdiParent;
                //    frmware_Quytm_Dauky.Show();
                //    frmware_Quytm_Dauky.Activate();
                //    break;

                case "Frmware_Congnotra_Dauky":
                    frmware_Congnotra_Dauky = (Forms.Frmware_Congnotra_Dauky) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Congnotra_Dauky");

                    if (frmware_Congnotra_Dauky == null || frmware_Congnotra_Dauky.IsDisposed)
                        frmware_Congnotra_Dauky = new Forms.Frmware_Congnotra_Dauky();
                    frmware_Congnotra_Dauky.Text = formText;
                    frmware_Congnotra_Dauky.MdiParent = mdiParent;
                    frmware_Congnotra_Dauky.Show();
                    frmware_Congnotra_Dauky.Activate();
                    break;

                case "Frmware_Congnothu_Dauky":
                    frmware_Congnothu_Dauky = (Forms.Frmware_Congnothu_Dauky) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Congnothu_Dauky");

                    if (frmware_Congnothu_Dauky == null || frmware_Congnothu_Dauky.IsDisposed)
                        frmware_Congnothu_Dauky = new Forms.Frmware_Congnothu_Dauky();
                    frmware_Congnothu_Dauky.Text = formText;
                    frmware_Congnothu_Dauky.MdiParent = mdiParent;
                    frmware_Congnothu_Dauky.Show();
                    frmware_Congnothu_Dauky.Activate();
                    break;


                case "FrmRptWare_SoQTM_2":
                    GoobizFrame.Windows.MdiUtils.ThemeSettings.ShowExternalForm("Ecm.Reports.dll", "Ecm.Reports.Forms.FrmRptWare_SoQTM_2", this.MdiParent);
                    break;

                case "Frmware_Hdbanhang_noVAT_Hhban":
                    Forms.Frmware_Hdbanhang_noVAT_Hhban _Frmware_Hdbanhang_noVAT_Hhban = (Forms.Frmware_Hdbanhang_noVAT_Hhban)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hdbanhang_noVAT_Hhban");

                    if (_Frmware_Hdbanhang_noVAT_Hhban == null || _Frmware_Hdbanhang_noVAT_Hhban.IsDisposed)
                        _Frmware_Hdbanhang_noVAT_Hhban = new Forms.Frmware_Hdbanhang_noVAT_Hhban();
                    _Frmware_Hdbanhang_noVAT_Hhban.Text = formText;
                    _Frmware_Hdbanhang_noVAT_Hhban.MdiParent = mdiParent;
                    _Frmware_Hdbanhang_noVAT_Hhban.Show();
                    _Frmware_Hdbanhang_noVAT_Hhban.Activate();
                    break;

                case "Frmware_Hdbanhang_VAT":
                    Forms.Frmware_Hdbanhang_VAT _Frmware_Hdbanhang_VAT = (Forms.Frmware_Hdbanhang_VAT)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Hdbanhang_VAT");

                    if (_Frmware_Hdbanhang_VAT == null || _Frmware_Hdbanhang_VAT.IsDisposed)
                        _Frmware_Hdbanhang_VAT = new Forms.Frmware_Hdbanhang_VAT();
                    _Frmware_Hdbanhang_VAT.Text = formText;
                    _Frmware_Hdbanhang_VAT.MdiParent = mdiParent;
                    _Frmware_Hdbanhang_VAT.Show();
                    _Frmware_Hdbanhang_VAT.Activate();
                    break;

                default:
                    System.Windows.Forms.MessageBox.Show("Please wait... " + formName + "'ll be created at next year!!!!!");
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
