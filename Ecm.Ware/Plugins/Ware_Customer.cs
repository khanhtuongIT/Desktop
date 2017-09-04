using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.Ware.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Ware_Customer : IPlugin
    {

        bool DataLoaded = false;
        #region Forms
        Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add frmware_Dm_Khachhang_Add;
        Ecm.Ware.Forms.Frmware_Dm_Khachhang_Info frmware_Dm_Khachhang_Info;

        //Forms.Frmware_Vip_Member            frmware_Vip_Member;
        //Forms.Frmware_Khachhang_Vip         frmware_Khachhang_Vip;
        //Forms.Frmware_Khachhang_Quota       frmware_Khachhang_Quota;

        //Forms.Frmware_Ctrinh_Kmai frmware_Ctrinh_Kmai;
        //Forms.Frmware_Ctrinh_Kmai_Rent frmware_Ctrinh_Kmai_rent;

       #endregion

        public Ware_Customer()
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
                case "Frmware_Dm_Khachhang_Add":
                    frmware_Dm_Khachhang_Add = (Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Dm_Khachhang_Add");

                    if (frmware_Dm_Khachhang_Add == null || frmware_Dm_Khachhang_Add.IsDisposed)
                        frmware_Dm_Khachhang_Add = new Ecm.MasterTables.Forms.Ware.Frmware_Dm_Khachhang_Add();
                    frmware_Dm_Khachhang_Add.Text = formText;
                    frmware_Dm_Khachhang_Add.MdiParent = mdiParent;
                    frmware_Dm_Khachhang_Add.Show();
                    frmware_Dm_Khachhang_Add.Activate();
                    break;

                case "Frmware_Dm_Khachhang_Info":
                    frmware_Dm_Khachhang_Info = (Ecm.Ware.Forms.Frmware_Dm_Khachhang_Info) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Dm_Khachhang_Info");

                    if (frmware_Dm_Khachhang_Info == null || frmware_Dm_Khachhang_Info.IsDisposed)
                        frmware_Dm_Khachhang_Info = new Ecm.Ware.Forms.Frmware_Dm_Khachhang_Info();
                    frmware_Dm_Khachhang_Info.Text = formText;
                    frmware_Dm_Khachhang_Info.MdiParent = mdiParent;
                    frmware_Dm_Khachhang_Info.Show();
                    frmware_Dm_Khachhang_Info.Activate();
                    break;

                //case "Frmware_Vip_Member":
                //    frmware_Vip_Member = (Forms.Frmware_Vip_Member) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Vip_Member");

                //    if (frmware_Vip_Member == null || frmware_Vip_Member.IsDisposed)
                //        frmware_Vip_Member = new Forms.Frmware_Vip_Member();
                //    frmware_Vip_Member.Text = formText;
                //    frmware_Vip_Member.MdiParent = mdiParent;
                //    frmware_Vip_Member.Show();
                //    frmware_Vip_Member.Activate();
                //    break;

                //case "Frmware_Khachhang_Vip":
                //    frmware_Khachhang_Vip = (Forms.Frmware_Khachhang_Vip) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Khachhang_Vip");

                //    if (frmware_Khachhang_Vip == null || frmware_Khachhang_Vip.IsDisposed)
                //        frmware_Khachhang_Vip = new Forms.Frmware_Khachhang_Vip();
                //    frmware_Khachhang_Vip.Text = formText;
                //    frmware_Khachhang_Vip.MdiParent = mdiParent;
                //    frmware_Khachhang_Vip.Show();
                //    frmware_Khachhang_Vip.Activate();
                //    break;

                //case "Frmware_Khachhang_Quota":
                //    frmware_Khachhang_Quota = (Forms.Frmware_Khachhang_Quota) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Khachhang_Quota");

                //    if (frmware_Khachhang_Quota == null || frmware_Khachhang_Quota.IsDisposed)
                //        frmware_Khachhang_Quota = new Forms.Frmware_Khachhang_Quota();
                //    frmware_Khachhang_Quota.Text = formText;
                //    frmware_Khachhang_Quota.MdiParent = mdiParent;
                //    frmware_Khachhang_Quota.Show();
                //    frmware_Khachhang_Quota.Activate();
                //    break;

                //case "Frmware_Ctrinh_Kmai":
                //    frmware_Ctrinh_Kmai = (Forms.Frmware_Ctrinh_Kmai) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Ctrinh_Kmai");
                //    if (frmware_Ctrinh_Kmai == null || frmware_Ctrinh_Kmai.IsDisposed)
                //        frmware_Ctrinh_Kmai = new Forms.Frmware_Ctrinh_Kmai();
                //    frmware_Ctrinh_Kmai.Text = formText;
                //    frmware_Ctrinh_Kmai.MdiParent = mdiParent;
                //    frmware_Ctrinh_Kmai.Show();
                //    frmware_Ctrinh_Kmai.Activate();
                //    break;

                //case "Frmware_Ctrinh_Kmai_Rent":
                //    frmware_Ctrinh_Kmai_rent = (Forms.Frmware_Ctrinh_Kmai_Rent)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Ctrinh_Kmai_Rent");
                //    if (frmware_Ctrinh_Kmai_rent == null || frmware_Ctrinh_Kmai_rent.IsDisposed)
                //        frmware_Ctrinh_Kmai_rent = new Forms.Frmware_Ctrinh_Kmai_Rent();
                //    frmware_Ctrinh_Kmai_rent.Text = formText;
                //    frmware_Ctrinh_Kmai_rent.MdiParent = mdiParent;
                //    frmware_Ctrinh_Kmai_rent.Show();
                //    frmware_Ctrinh_Kmai_rent.Activate();
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
