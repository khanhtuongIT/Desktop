using System;
using  GoobizFrame.Windows.PlugIn;

namespace Ecm.SystemControl.Plugins
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class SystemInfo : IPlugin
	{


        #region Forms
        Ecm.SystemControl.SystemInfo.FrmAbout frmAbout;
        Ecm.SystemControl.SystemInfo.FrmWebReferences frmWebReferences;
        Ecm.SystemControl.SystemInfo.FrmMenuInfo frmMenuInfo;
        //Ecm.SystemControl.SystemInfo.FrmHelp frmHelp;
        Ecm.SystemControl.SystemInfo.FrmSys_Dm_Heso_Chuongtrinh frmSys_Dm_Heso_Chuongtrinh;
         GoobizFrame.Windows.Forms.FrmHostConfiguration frmHostConfiguration;
        #endregion

        public SystemInfo()
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
                //case "FrmHelp":
                //    if (frmHelp == null || frmHelp.IsDisposed)
                //        frmHelp = new Ecm.SystemControl.SystemInfo.FrmHelp();
                //    frmHelp.Name = formName;
                //    frmHelp.Text = formText;
                //    frmHelp.MdiParent = this.mdiParent;
                //    frmHelp.Show();
                //    frmHelp.Activate();
                //    break;
                case "FrmAbout":
                    if (frmAbout == null || frmAbout.IsDisposed)
                        frmAbout = new Ecm.SystemControl.SystemInfo.FrmAbout();
                    frmAbout.Name = formName;
                    frmAbout.Text = formText;
                    frmAbout.MdiParent = this.mdiParent;
                    frmAbout.Show();
                    frmAbout.Activate();
                    break;
                case "FrmSys_Dm_Heso_Chuongtrinh":
                    frmSys_Dm_Heso_Chuongtrinh = (Ecm.SystemControl.SystemInfo.FrmSys_Dm_Heso_Chuongtrinh) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "FrmSys_Dm_Heso_Chuongtrinh");
                    if (frmSys_Dm_Heso_Chuongtrinh == null || frmSys_Dm_Heso_Chuongtrinh.IsDisposed)
                        frmSys_Dm_Heso_Chuongtrinh = new Ecm.SystemControl.SystemInfo.FrmSys_Dm_Heso_Chuongtrinh();
                    frmSys_Dm_Heso_Chuongtrinh.Name = formName;
                    frmSys_Dm_Heso_Chuongtrinh.Text = formText;
                    frmSys_Dm_Heso_Chuongtrinh.MdiParent = this.mdiParent;
                    frmSys_Dm_Heso_Chuongtrinh.Show();
                    frmSys_Dm_Heso_Chuongtrinh.Activate();
                    break;
                case "Registration":
                    WaitDialogForm.Close();
                     GoobizFrame.Windows.MdiUtils.Register.RunRegister(true);
                    sender = null;
                    e = null;
                    break;
                case "FrmHostConfiguration":
                    WaitDialogForm.Close();
                    frmHostConfiguration = new  GoobizFrame.Windows.Forms.FrmHostConfiguration();
                    //UCSetMachineLocation
                    Ecm.SystemControl.SystemInfo.UCSetMachineLocation ucSetMachineLocation1 = new Ecm.SystemControl.SystemInfo.UCSetMachineLocation();
                    ucSetMachineLocation1.Location = new System.Drawing.Point(33, 21);
                    ucSetMachineLocation1.Name = "ucSetMachineLocation1";
                    ucSetMachineLocation1.Size = new System.Drawing.Size(245, 223);
                    frmHostConfiguration.AddControl(ucSetMachineLocation1, "Tùy chọn vị trí máy");

                    //UCWebReferences
                     GoobizFrame.Windows.Forms.UCWebReferences ucWebReferences = new  GoobizFrame.Windows.Forms.UCWebReferences();
                    ucWebReferences.Location = new System.Drawing.Point(33, 21);
                    ucWebReferences.Name = "ucSetMachineLocation1";
                    ucWebReferences.Size = new System.Drawing.Size(245, 223);
                    frmHostConfiguration.AddControl(ucWebReferences, "Tùy chọn webservices");

                    frmHostConfiguration.Name = formName;
                    frmHostConfiguration.Text = formText;
                    frmHostConfiguration.MdiParent = this.mdiParent;
                    frmHostConfiguration.Show();
                    frmHostConfiguration.Activate();
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
		{get{return m_strName;}set{m_strName=value;}}

        public string PluginItemConfig
        { get { return m_PluginItemConfig; } set { m_PluginItemConfig = value; } }
		
        //public void Show(System.Windows.Forms.Form mdiParent)
        //{ 
        //    Main1 mn = new Main1();
        //    mn.ShowDialog();
        //}

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
