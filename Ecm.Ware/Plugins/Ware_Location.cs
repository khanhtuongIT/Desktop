using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.Ware.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Ware_Location : IPlugin
    {

        bool DataLoaded = false;
        #region Forms
        Forms.Frmware_Ql_Cuahang_Ban        frmware_Ql_Cuahang_Ban;
        Forms.Frmware_So_Quytm frmware_So_Quytm;
        //Forms.Frmware_Ql_Kho_Hanghoa_Mua    frmware_Ql_Kho_Hanghoa_Mua;
        //Forms.Frmware_SetLocation frmware_SetLocation;
       #endregion

        public Ware_Location()
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
                case "Frmware_Phieu_Thu":
                    Forms.Frmware_Phieu_Thu _Frmware_Phieu_Thu = (Forms.Frmware_Phieu_Thu)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Phieu_Thu");

                    if (_Frmware_Phieu_Thu == null || _Frmware_Phieu_Thu.IsDisposed)
                        _Frmware_Phieu_Thu = new Forms.Frmware_Phieu_Thu();
                    _Frmware_Phieu_Thu.Text = formText;
                    _Frmware_Phieu_Thu.MdiParent = mdiParent;
                    _Frmware_Phieu_Thu.Show();
                    _Frmware_Phieu_Thu.Activate();
                    break;

                case "Frmware_Phieu_Thu_Ds":
                    Forms.Frmware_Phieu_Thu_Ds _Frmware_Phieu_Thu_Ds = (Forms.Frmware_Phieu_Thu_Ds)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Phieu_Thu_Ds");

                    if (_Frmware_Phieu_Thu_Ds == null || _Frmware_Phieu_Thu_Ds.IsDisposed)
                        _Frmware_Phieu_Thu_Ds = new Forms.Frmware_Phieu_Thu_Ds();
                    _Frmware_Phieu_Thu_Ds.Text = formText;
                    _Frmware_Phieu_Thu_Ds.MdiParent = mdiParent;
                    _Frmware_Phieu_Thu_Ds.Show();
                    _Frmware_Phieu_Thu_Ds.Activate();
                    break;

                case "Frmware_Xuat_Phieuthu":
                    Forms.Frmware_Xuat_Phieuthu _Frmware_Xuat_Phieuthu = (Forms.Frmware_Xuat_Phieuthu)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Xuat_Phieuthu");

                    if (_Frmware_Xuat_Phieuthu == null || _Frmware_Xuat_Phieuthu.IsDisposed)
                        _Frmware_Xuat_Phieuthu = new Forms.Frmware_Xuat_Phieuthu();
                    _Frmware_Xuat_Phieuthu.Text = formText;
                    _Frmware_Xuat_Phieuthu.MdiParent = mdiParent;
                    _Frmware_Xuat_Phieuthu.Show();
                    _Frmware_Xuat_Phieuthu.Activate();
                    break;

                case "Frmware_Phieu_Chi":
                    Forms.Frmware_Phieu_Chi _Frmware_Phieu_Chi = (Forms.Frmware_Phieu_Chi)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Phieu_Chi");

                    if (_Frmware_Phieu_Chi == null || _Frmware_Phieu_Chi.IsDisposed)
                        _Frmware_Phieu_Chi = new Forms.Frmware_Phieu_Chi();
                    _Frmware_Phieu_Chi.Text = formText;
                    _Frmware_Phieu_Chi.MdiParent = mdiParent;
                    _Frmware_Phieu_Chi.Show();
                    _Frmware_Phieu_Chi.Activate();
                    break;                

                case "Frmware_Ql_Cuahang_Ban":
                    frmware_Ql_Cuahang_Ban = (Forms.Frmware_Ql_Cuahang_Ban) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Ql_Cuahang_Ban");

                    if (frmware_Ql_Cuahang_Ban == null || frmware_Ql_Cuahang_Ban.IsDisposed)
                        frmware_Ql_Cuahang_Ban = new Forms.Frmware_Ql_Cuahang_Ban();
                    frmware_Ql_Cuahang_Ban.Text = formText;
                    frmware_Ql_Cuahang_Ban.MdiParent = mdiParent;
                    frmware_Ql_Cuahang_Ban.Show();
                    frmware_Ql_Cuahang_Ban.Activate();
                    break;

                case "Frmware_So_Quytm":
                    frmware_So_Quytm = (Forms.Frmware_So_Quytm)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_So_Quytm");

                    if (frmware_So_Quytm == null || frmware_So_Quytm.IsDisposed)
                        frmware_So_Quytm = new Forms.Frmware_So_Quytm();
                    frmware_So_Quytm.Text = formText;
                    frmware_So_Quytm.MdiParent = mdiParent;
                    frmware_So_Quytm.Show();
                    frmware_So_Quytm.Activate();
                    break;
                

                //case "Frmware_Ql_Kho_Hanghoa_Mua":
                //    frmware_Ql_Kho_Hanghoa_Mua = (Forms.Frmware_Ql_Kho_Hanghoa_Mua) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Ql_Kho_Hanghoa_Mua");

                //    if (frmware_Ql_Kho_Hanghoa_Mua == null || frmware_Ql_Kho_Hanghoa_Mua.IsDisposed)
                //        frmware_Ql_Kho_Hanghoa_Mua = new Forms.Frmware_Ql_Kho_Hanghoa_Mua();
                //    frmware_Ql_Kho_Hanghoa_Mua.Text = formText;
                //    frmware_Ql_Kho_Hanghoa_Mua.MdiParent = mdiParent;
                //    frmware_Ql_Kho_Hanghoa_Mua.Show();
                //    frmware_Ql_Kho_Hanghoa_Mua.Activate();
                //    break;
            

                //case "Frmware_SetLocation":
                //    frmware_SetLocation = (Forms.Frmware_SetLocation) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_SetLocation");

                //    if (frmware_SetLocation == null || frmware_SetLocation.IsDisposed)
                //        frmware_SetLocation = new Forms.Frmware_SetLocation();
                //    frmware_SetLocation.Text = formText;
                //    frmware_SetLocation.MdiParent = mdiParent;
                //    frmware_SetLocation.Show();
                //    frmware_SetLocation.Activate();
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
