using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;
using System.Reflection;
using System.Windows.Forms;

namespace Ecm.Reports.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class XRpt_Ware : IPlugin
    {

        bool DataLoaded = false;
        #region Forms
        Forms.FrmRptware_Baocao_Khohang frmRptware_Baocao_Khohang;
        Forms.FrmRptware_Baocao_Muahang frmRptware_Baocao_Muahang;
        Forms.FrmRptware_Baocao_Banhang frmRptware_Baocao_Banhang;
        Forms.FrmRptware_Baocao_Congno frmRptware_Baocao_Congno;
        Forms.FrmRptware_Baocao_Tonghop frmRptware_Baocao_Tonghop;
        Forms.FrmRptware_Baocao_Congno_Ncc _FrmRptware_Baocao_Congno_Ncc;
        //in use
        Forms.FrmRptWare_Hdbanhang FrmRptWare_Hdbanhang;
        Forms.Frmware_Dinhmuc _Frmware_Dinhmuc;
        Forms.FrmRptWare_Hdbanhang_ByKhohanghoa FrmRptWare_Hdbanhang_ByKhohanghoa;
        //Forms.FrmRptware_Nxt_Hhban FrmRptware_Nxt_Hhban;

        #endregion

        public XRpt_Ware()
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
                case "Frmware_Dinhmuc":
                    _Frmware_Dinhmuc = (Forms.Frmware_Dinhmuc)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Dinhmuc");

                    if (_Frmware_Dinhmuc == null || _Frmware_Dinhmuc.IsDisposed)
                        _Frmware_Dinhmuc = new Forms.Frmware_Dinhmuc();
                    _Frmware_Dinhmuc.Text = formText;
                    _Frmware_Dinhmuc.MdiParent = mdiParent;
                    _Frmware_Dinhmuc.Show();
                    _Frmware_Dinhmuc.Activate();
                    break;

                case "FrmRptware_Baocao_Khohang":
                    frmRptware_Baocao_Khohang = (Forms.FrmRptware_Baocao_Khohang) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptware_Baocao_Khohang");

                    if (frmRptware_Baocao_Khohang == null || frmRptware_Baocao_Khohang.IsDisposed)
                        frmRptware_Baocao_Khohang = new Forms.FrmRptware_Baocao_Khohang();
                    frmRptware_Baocao_Khohang.Text = formText;
                    frmRptware_Baocao_Khohang.MdiParent = mdiParent;
                    frmRptware_Baocao_Khohang.Show();
                    frmRptware_Baocao_Khohang.Activate();
                    break;              

                case "FrmRptware_Baocao_Muahang":
                    frmRptware_Baocao_Muahang = (Forms.FrmRptware_Baocao_Muahang) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptware_Baocao_Muahang");

                    if (frmRptware_Baocao_Muahang == null || frmRptware_Baocao_Muahang.IsDisposed)
                        frmRptware_Baocao_Muahang = new Forms.FrmRptware_Baocao_Muahang();
                    frmRptware_Baocao_Muahang.Text = formText;
                    frmRptware_Baocao_Muahang.MdiParent = mdiParent;
                    frmRptware_Baocao_Muahang.Show();
                    frmRptware_Baocao_Muahang.Activate();
                    break;

                case "FrmRptware_Baocao_Banhang":
                    frmRptware_Baocao_Banhang = (Forms.FrmRptware_Baocao_Banhang) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptware_Baocao_Banhang");

                    if (frmRptware_Baocao_Banhang == null || frmRptware_Baocao_Banhang.IsDisposed)
                        frmRptware_Baocao_Banhang = new Forms.FrmRptware_Baocao_Banhang();
                    frmRptware_Baocao_Banhang.Text = formText;
                    frmRptware_Baocao_Banhang.MdiParent = mdiParent;
                    frmRptware_Baocao_Banhang.Show();
                    frmRptware_Baocao_Banhang.Activate();
                    break;

                case "FrmRptware_Baocao_Congno":
                    frmRptware_Baocao_Congno = (Forms.FrmRptware_Baocao_Congno)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptware_Baocao_Congno");

                    if (frmRptware_Baocao_Congno == null || frmRptware_Baocao_Congno.IsDisposed)
                        frmRptware_Baocao_Congno = new Forms.FrmRptware_Baocao_Congno();
                    frmRptware_Baocao_Congno.Text = formText;
                    frmRptware_Baocao_Congno.MdiParent = mdiParent;
                    frmRptware_Baocao_Congno.Show();
                    frmRptware_Baocao_Congno.Activate();
                    break;

                case "FrmRptware_Baocao_Tonghop":
                    frmRptware_Baocao_Tonghop = (Forms.FrmRptware_Baocao_Tonghop) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptware_Baocao_Tonghop");

                    if (frmRptware_Baocao_Tonghop == null || frmRptware_Baocao_Tonghop.IsDisposed)
                        frmRptware_Baocao_Tonghop = new Forms.FrmRptware_Baocao_Tonghop();
                    frmRptware_Baocao_Tonghop.Text = formText;
                    frmRptware_Baocao_Tonghop.MdiParent = mdiParent;
                    frmRptware_Baocao_Tonghop.Show();
                    frmRptware_Baocao_Tonghop.Activate();
                    break;

                case "FrmRptware_Baocao_Congno_Ncc":
                    _FrmRptware_Baocao_Congno_Ncc = (Forms.FrmRptware_Baocao_Congno_Ncc)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmRptware_Baocao_Congno_Ncc");

                    if (_FrmRptware_Baocao_Congno_Ncc == null || frmRptware_Baocao_Tonghop.IsDisposed)
                        _FrmRptware_Baocao_Congno_Ncc = new Forms.FrmRptware_Baocao_Congno_Ncc();
                    _FrmRptware_Baocao_Congno_Ncc.Text = formText;
                    _FrmRptware_Baocao_Congno_Ncc.MdiParent = mdiParent;
                    _FrmRptware_Baocao_Congno_Ncc.Show();
                    _FrmRptware_Baocao_Congno_Ncc.Activate();
                    break;

                case "Frmware_Nhap_Hh_Ban_Date":
                    Assembly assRun;
                    Type typeRun;
                    System.Windows.Forms.Form objStartupForm = null;
                    assRun = Assembly.LoadFile(Application.StartupPath + @"\Ecm.Ware.dll");
                    typeRun = assRun.GetType("Ecm.Ware.Forms.Frmware_Nhap_Hh_Ban_Date");

                    if (typeRun == null)
                    {
                        return;
                    }
                    objStartupForm = GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, typeRun.Name);
                    if (objStartupForm == null)
                        objStartupForm = (System.Windows.Forms.Form)Activator.CreateInstance(typeRun);
                    objStartupForm.Text = formText;
                    objStartupForm.MdiParent = mdiParent;
                    objStartupForm.Show();
                    objStartupForm.Activate();
                    break;

                #region in use
                //case "FrmRptware_Nxt_Hhban":
                //    if (FrmRptware_Nxt_Hhban == null || FrmRptware_Nxt_Hhban.IsDisposed)
                //        FrmRptware_Nxt_Hhban = new Ecm.Reports.Forms.FrmRptware_Nxt_Hhban();
                //    FrmRptware_Nxt_Hhban.Text = formText;
                //    FrmRptware_Nxt_Hhban.MdiParent = this.MdiParent;
                //    FrmRptware_Nxt_Hhban.Show();
                //    FrmRptware_Nxt_Hhban.Activate();
                //    break;
                case "FrmRptWare_Hdbanhang":
                    if (FrmRptWare_Hdbanhang == null || FrmRptWare_Hdbanhang.IsDisposed)
                        FrmRptWare_Hdbanhang = new Ecm.Reports.Forms.FrmRptWare_Hdbanhang();
                    FrmRptWare_Hdbanhang.Text = formText;
                    FrmRptWare_Hdbanhang.MdiParent = this.MdiParent;
                    FrmRptWare_Hdbanhang.Show();
                    FrmRptWare_Hdbanhang.Activate();
                    break;
                case "FrmRptWare_Hdbanhang_ByKhohanghoa":
                    if (FrmRptWare_Hdbanhang_ByKhohanghoa == null || FrmRptWare_Hdbanhang_ByKhohanghoa.IsDisposed)
                        FrmRptWare_Hdbanhang_ByKhohanghoa = new Ecm.Reports.Forms.FrmRptWare_Hdbanhang_ByKhohanghoa();
                    FrmRptWare_Hdbanhang_ByKhohanghoa.Text = formText;
                    FrmRptWare_Hdbanhang_ByKhohanghoa.MdiParent = this.MdiParent;
                    FrmRptWare_Hdbanhang_ByKhohanghoa.Show();
                    FrmRptWare_Hdbanhang_ByKhohanghoa.Activate();
                    break;
                #endregion
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
