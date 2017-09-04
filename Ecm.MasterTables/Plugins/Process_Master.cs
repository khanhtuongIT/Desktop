using System;
using System.Collections.Generic;
using System.Text;
using GoobizFrame.Windows.PlugIn;
using System.Reflection;
using System.Windows.Forms;

namespace Ecm.MasterTables.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Process_Master : IPlugin
    {

        //bool DataLoaded = false;
        #region Forms
        //Forms.Ware.Frmware_Dm_Congthuc_Phache_Add frmware_Dm_Congthuc_Phache_Add;
        Forms.Ware.Frmware_Dm_Khachhang_Add _Frmware_Dm_Khachhang_Add;
        Forms.Ware.Frmware_Dm_Nhacungcap_Add _Frmware_Dm_Nhacungcap_Add;  
        #endregion

        public Process_Master()
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
                formName = ((DevExpress.XtraNavBar.NavBarItem)sender).Name;
                formText = ((DevExpress.XtraNavBar.NavBarItem)sender).Caption;
            }
            else if (e.GetType() == typeof(DevExpress.XtraBars.ItemClickEventArgs))
            {
                formName = ((DevExpress.XtraBars.ItemClickEventArgs)e).Item.Name;
                formText = ((DevExpress.XtraBars.ItemClickEventArgs)e).Item.Caption;
            }

            switch (formName)
            {
                //case "Frmware_Dm_Congthuc_Phache_Add":
                //    frmware_Dm_Congthuc_Phache_Add = (Forms.Ware.Frmware_Dm_Congthuc_Phache_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Dm_Congthuc_Phache_Add");

                //    if (frmware_Dm_Congthuc_Phache_Add == null || frmware_Dm_Congthuc_Phache_Add.IsDisposed)
                //        frmware_Dm_Congthuc_Phache_Add = new Forms.Ware.Frmware_Dm_Congthuc_Phache_Add();
                //    frmware_Dm_Congthuc_Phache_Add.Text = formText;
                //    frmware_Dm_Congthuc_Phache_Add.MdiParent = mdiParent;
                //    frmware_Dm_Congthuc_Phache_Add.Show();
                //    frmware_Dm_Congthuc_Phache_Add.Activate();
                //    break;

                case "Frmware_Dm_Khachhang_Add":
                    _Frmware_Dm_Khachhang_Add = (Forms.Ware.Frmware_Dm_Khachhang_Add)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Dm_Khachhang_Add");

                    if (_Frmware_Dm_Khachhang_Add == null || _Frmware_Dm_Khachhang_Add.IsDisposed)
                        _Frmware_Dm_Khachhang_Add = new Forms.Ware.Frmware_Dm_Khachhang_Add();
                    _Frmware_Dm_Khachhang_Add.Text = formText;
                    _Frmware_Dm_Khachhang_Add.MdiParent = mdiParent;
                    _Frmware_Dm_Khachhang_Add.Show();
                    _Frmware_Dm_Khachhang_Add.Activate();
                    break;

                case "Frmware_Dm_Nhacungcap_Add":
                    _Frmware_Dm_Nhacungcap_Add = (Forms.Ware.Frmware_Dm_Nhacungcap_Add)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmware_Dm_Nhacungcap_Add");

                    if (_Frmware_Dm_Nhacungcap_Add == null || _Frmware_Dm_Nhacungcap_Add.IsDisposed)
                        _Frmware_Dm_Nhacungcap_Add = new Forms.Ware.Frmware_Dm_Nhacungcap_Add();
                    _Frmware_Dm_Nhacungcap_Add.Text = formText;
                    _Frmware_Dm_Nhacungcap_Add.MdiParent = mdiParent;
                    _Frmware_Dm_Nhacungcap_Add.Show();
                    _Frmware_Dm_Nhacungcap_Add.Activate();
                    break;

                case "Frmrex_Nhansu":
                    Assembly assRun;
                    Type typeRun;
                    System.Windows.Forms.Form objStartupForm = null;
                    assRun = Assembly.LoadFile(Application.StartupPath + @"\Ecm.Rex.dll");
                    typeRun = assRun.GetType("Ecm.Rex.Forms.Frmrex_Nhansu");

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

                case "Frmware_Ql_Cuahang_Ban":
                    Assembly assRun2;
                    Type typeRun2;
                    System.Windows.Forms.Form objStartupForm2 = null;
                    assRun2 = Assembly.LoadFile(Application.StartupPath + @"\Ecm.Ware.dll");
                    typeRun2 = assRun2.GetType("Ecm.Ware.Forms.Frmware_Ql_Cuahang_Ban");

                    if (typeRun2 == null)
                    {
                        return;
                    }
                    objStartupForm2 = GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, typeRun2.Name);
                    if (objStartupForm2 == null)
                        objStartupForm2 = (System.Windows.Forms.Form)Activator.CreateInstance(typeRun2);
                    objStartupForm2.Text = formText;
                    objStartupForm2.MdiParent = mdiParent;
                    objStartupForm2.Show();
                    objStartupForm2.Activate();
                    break;

                case "Frmware_Khachhang_Nhansu":
                    Assembly assRun3;
                    Type typeRun3;
                    System.Windows.Forms.Form objStartupForm3 = null;
                    assRun3 = Assembly.LoadFile(Application.StartupPath + @"\Ecm.Ware.dll");
                    typeRun3 = assRun3.GetType("Ecm.Ware.Forms.Frmware_Khachhang_Nhansu");

                    if (typeRun3 == null)
                    {
                        return;
                    }
                    objStartupForm3 = GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, typeRun3.Name);
                    if (objStartupForm3 == null)
                        objStartupForm3 = (System.Windows.Forms.Form)Activator.CreateInstance(typeRun3);
                    objStartupForm3.Text = formText;
                    objStartupForm3.MdiParent = mdiParent;
                    objStartupForm3.Show();
                    objStartupForm3.Activate();
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
                //frmbar_Dm_Table_Add = new Ecm.Bar.Forms.Frmbar_Dm_Table_Add();
                //frmbar_Dm_Table_Add.Dispose();



                //DataLoaded = true;
            }
        }
        #endregion
    }
}
