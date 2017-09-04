using System;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.SystemControl.Plugins
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class SystemControl : IPlugin
	{


        #region Forms
        #endregion

        public SystemControl()
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
                case "ActiveDirectoryLogon":
                    //if (activeDirectoryLogon == null || activeDirectoryLogon.IsDisposed)
                    //    activeDirectoryLogon = new Ecm.ADUsers.Forms.ActiveDirectoryLogon();
                    //activeDirectoryLogon.Text = formText;
                    ////activeDirectoryLogon.MdiParent = mdiParent;
                    //activeDirectoryLogon.ShowDialog();
                    //activeDirectoryLogon.Activate();
                    break;

            }

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
		{get{return m_strName;}set{m_strName=value;}}

        public string PluginItemConfig
        { get { return m_PluginItemConfig; } set { m_PluginItemConfig = value; } }
		
		public IPluginHost Host
		{
			get{return m_Host;}
			set
			{
				m_Host=value;
				m_Host.Register(this);
			}
        }

        public void PreLoadData()
        {
        }
        #endregion
    }
}
