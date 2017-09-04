using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;
using System.Reflection;
using System.Windows.Forms;

namespace Ecm.MasterTables.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Ware_Master : IPlugin
    {

        //bool DataLoaded = false;
        #region Forms
        //Forms.Ware.Frmware_Dm_Cuahang_Ban_Add frmware_Dm_Cuahang_Ban_Add;
        //Forms.Ware.Frmware_Dm_Donvitinh_Add frmware_Dm_Donvitinh_Add;
        //Forms.Ware.Frmware_Dm_Nhom_Hanghoa_Ban_Add frmware_Dm_Nhom_Hanghoa_Ban_Add;
        //Forms.Ware.Frmware_Dm_Loai_Hanghoa_Ban_Add frmware_Dm_Loai_Hanghoa_Ban_Add;
        //Forms.Ware.Frmware_Dm_Hanghoa_Ban_FullEdit frmware_Dm_Hanghoa_Ban_Add;
        //Forms.Ware.Frmware_Dm_Nhacungcap_Add frmware_Dm_Nhacungcap_Add;
        //Forms.Ware.Frmware_Dm_Nhasanxuat_Add frmware_Dm_Nhasanxuat_Add;
        //Forms.Ware.Frmware_Dm_Tiente_Add frmware_Dm_Tiente_Add;
        //Forms.Ware.Frmware_Dm_Soquy_Add _Frmware_Dm_Soquy_Add;
        //Forms.Ware.Frmware_Dm_Dinhluong_Add _Frmware_Dm_Dinhluong_Add;
        //Forms.Ware.Frmware_Dm_Xe_Add _Frmware_Dm_Xe_Add;
        //Forms.Ware.Frmware_Dm_Theocap_Add _Frmware_Dm_Theocap_Add;

        #endregion

        public Ware_Master()
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
                case "Frmware_Dm_Xe_Add":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Ware.Frmware_Dm_Xe_Add>(mdiParent, formText);
                    break;

                case "Frmware_Dm_Cuahang_Ban_Add":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Ware.Frmware_Dm_Cuahang_Ban_Add>(mdiParent, formText);
                    break;

                //case "Frmware_Dm_Theocap_Add":
                //    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Ware.Frmware_Dm_Theocap_Add>(mdiParent, formText);
                //    break;

                case "Frmware_Dm_Donvitinh_Add":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Ware.Frmware_Dm_Donvitinh_Add>(mdiParent, formText);
                    break;

                case "Frmware_Dm_Donvitinh_Quydoi_Add":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Ware.Frmware_Dm_Donvitinh_Quydoi_Add>(mdiParent, formText);
                    break;

                //case "Frmware_Dm_Nhom_Hanghoa_Ban_Add":
                //    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Ware.Frmware_Dm_Nhom_Hanghoa_Ban_Add>(mdiParent, formText);
                //    break;

                //case "Frmware_Dm_Phanloai_Nhom_Hanghoa_Ban_Add":
                //    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Ware.Frmware_Dm_Phanloai_Nhom_Hanghoa_Ban_Add>(mdiParent, formText);
                //    break;

                case "Frmware_Dm_Loai_Hanghoa_Ban_Add":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Ware.Frmware_Dm_Loai_Hanghoa_Ban_Add>(mdiParent, formText);
                    break;

                case "Frmware_Dm_Hanghoa_Ban_FullEdit":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Ware.Frmware_Dm_Hanghoa_Ban_FullEdit>(mdiParent, formText);
                    break;

                case "Frmware_Dm_Soquy_Add":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Ware.Frmware_Dm_Soquy_Add>(mdiParent, formText);
                    break;

                case "Frmware_Dm_Dinhluong_Add":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Ware.Frmware_Dm_Dinhluong_Add>(mdiParent, formText);
                    break;

                //case "Frmware_Dm_Nhacungcap_Add":
                //    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Ware.Frmware_Dm_Nhacungcap_Add>(mdiParent, formText);
                //    break;

                //case "Frmware_Dm_Nhasanxuat_Add":
                //    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Ware.Frmware_Dm_Nhasanxuat_Add>(mdiParent, formText);
                //    break;

                case "Frmware_Dm_Tiente_Add":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Ware.Frmware_Dm_Tiente_Add>(mdiParent, formText);
                    break;

                case "Frmware_Hanghoa_Ban_Dinhgia":
                    Assembly assRun;
                    Type typeRun;
                    System.Windows.Forms.Form objStartupForm = null;
                    assRun = Assembly.LoadFile(Application.StartupPath + @"\Ecm.Ware.dll");
                    typeRun = assRun.GetType("Ecm.Ware.Forms.Frmware_Hanghoa_Ban_Dinhgia");

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

                case "Frmware_Hanghoa_Ban_Dinhgia_Theocap":
                    Assembly assRun_cap;
                    Type typeRun_cap;
                    System.Windows.Forms.Form objStartupForm_cap = null;
                    assRun_cap = Assembly.LoadFile(Application.StartupPath + @"\Ecm.Ware.dll");
                    typeRun_cap = assRun_cap.GetType("Ecm.Ware.Forms.Frmware_Hanghoa_Ban_Dinhgia_Theocap");

                    if (typeRun_cap == null)
                    {
                        return;
                    }
                    objStartupForm_cap = GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, typeRun_cap.Name);
                    if (objStartupForm_cap == null)
                        objStartupForm_cap = (System.Windows.Forms.Form)Activator.CreateInstance(typeRun_cap);
                    objStartupForm_cap.Text = formText;
                    objStartupForm_cap.MdiParent = mdiParent;
                    objStartupForm_cap.Show();
                    objStartupForm_cap.Activate();
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
                //frmware_Dm_Cuahang_Ban_Add = new Ecm.MasterTables.Forms.Frmware_Dm_Cuahang_Ban_Add();
                //frmware_Dm_Cuahang_Ban_Add.Dispose();

                

                //DataLoaded = true;
            }
        }
        #endregion
    }
}
