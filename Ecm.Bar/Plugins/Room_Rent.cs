using System;
using System.Collections.Generic;
using System.Text;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.Bar.Plugins
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Room_Rent : IPlugin
    {

        bool DataLoaded = false;
        public Room_Rent()
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
                case "Frmbar_Rent_Reserve_RoomLookup":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Rent.Frmbar_Rent_Reserve_RoomLookup>(mdiParent, formText);
                    break;
                case "Frmbar_Rent_Reserve":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Rent.Frmbar_Rent_Reserve>(mdiParent, formText);
                    break;
                case "Frmbar_Rent_CheckIn":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Rent.Frmbar_Rent_CheckIn>(mdiParent, formText);
                    break;
                case "Frmbar_Rent_CheckOut":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Rent.Frmbar_Rent_CheckOut>(mdiParent, formText);
                    break;
                case "FrmRptSplit_Sum_Hhban_Hotel":
                    GoobizFrame.Windows.MdiUtils.MdiChecker.Show<Forms.Rent.FrmRptSplit_Sum_Hhban_Hotel>(mdiParent, formText);
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
