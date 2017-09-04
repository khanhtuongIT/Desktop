using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.MasterTables.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Bar_Master : IPlugin
    {

        bool DataLoaded = false;
        #region Forms
        #endregion

        public Bar_Master()
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

                //case "Frmbar_Dm_Menu_Add":
                //    frmbar_Dm_Menu_Add = (Ecm.MasterTables.Forms.Bar.Frmbar_Dm_Menu_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmbar_Dm_Menu_Add");

                //    if (frmbar_Dm_Menu_Add == null || frmbar_Dm_Menu_Add.IsDisposed)
                //        frmbar_Dm_Menu_Add = new Ecm.MasterTables.Forms.Bar.Frmbar_Dm_Menu_Add();
                //    frmbar_Dm_Menu_Add.Text = formText;
                //    frmbar_Dm_Menu_Add.MdiParent = mdiParent;
                //    frmbar_Dm_Menu_Add.Show();
                //    frmbar_Dm_Menu_Add.Activate();
                //    break;

                case "Frmbar_Dm_Menu_FullEdit":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Bar.Frmbar_Dm_Menu_FullEdit>(mdiParent, formText);
                    break;

                case "Frmbar_Dm_Table_FullEdit":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Bar.Frmbar_Dm_Table_FullEdit>(mdiParent, formText);
                    break;

                case "Frmbar_Dm_Class_FullEdit":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Bar.Frmbar_Dm_Class_FullEdit>(mdiParent, formText);
                    break;
                case "Frmbar_Dm_Rentlevel":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Bar.Frmbar_Dm_Rentlevel>(mdiParent, formText);
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
                //frmbar_Dm_Table_FullEdit = new Ecm.Bar.Forms.Frmbar_Dm_Table_FullEdit();
                //frmbar_Dm_Table_FullEdit.Dispose();

                

                DataLoaded = true;
            }
        }
        #endregion
    }
}
