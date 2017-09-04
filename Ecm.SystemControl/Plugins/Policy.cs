using System;
using  GoobizFrame.Windows.PlugIn;
using Ecm.SystemControl.Policy;


namespace Ecm.SystemControl.Plugins
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
    public class Policy : IPlugin
	{
        public static bool DataLoaded = false;
        #region Forms
         GoobizFrame.Windows.Forms.Policy.Frmpol_Dm_User_Add _Frmpol_Dm_User_Add;
        //Ecm.SystemControl.Policy.Forms.Frmpol_Dm_Role_Add        _Frmpol_Dm_Role_Add;
        //Ecm.SystemControl.Policy.Forms.Frmpol_Dm_Right_Add       _Frmpol_Dm_Right_Add;
        //Ecm.SystemControl.Policy.Forms.Frmpol_Dm_Action_Add      _Frmpol_Dm_Action_Add;
         GoobizFrame.Windows.Forms.Policy.Frmpol_Change_Password _Frmpol_Change_Password;
         GoobizFrame.Windows.Forms.Policy.Formpol_RoleUser_Mngr _Formpol_RoleUser_Mngr;
         Forms.Frmpol_MainProcess1 pol;
        #endregion

        public Policy()
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
            DevExpress.Utils.WaitDialogForm WaitDialogForm = new DevExpress.Utils.WaitDialogForm(); 

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
                case "Formpol_RoleUser_Mngr":
                    _Formpol_RoleUser_Mngr = ( GoobizFrame.Windows.Forms.Policy.Formpol_RoleUser_Mngr)
                         GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Formpol_RoleUser_Mngr");

                    if (_Formpol_RoleUser_Mngr == null || _Formpol_RoleUser_Mngr.IsDisposed)
                        _Formpol_RoleUser_Mngr = new  GoobizFrame.Windows.Forms.Policy.Formpol_RoleUser_Mngr();
                    _Formpol_RoleUser_Mngr.Text = formText;
                    _Formpol_RoleUser_Mngr.MdiParent = mdiParent;
                    _Formpol_RoleUser_Mngr.Show();
                    _Formpol_RoleUser_Mngr.Activate();
                    break;

                case "Frmpol_Dm_User_Add":
                    _Frmpol_Dm_User_Add = ( GoobizFrame.Windows.Forms.Policy.Frmpol_Dm_User_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmpol_Dm_User_Add");

                    if (_Frmpol_Dm_User_Add == null || _Frmpol_Dm_User_Add.IsDisposed)
                        _Frmpol_Dm_User_Add = new  GoobizFrame.Windows.Forms.Policy.Frmpol_Dm_User_Add();
                    _Frmpol_Dm_User_Add.Text = formText;
                    _Frmpol_Dm_User_Add.MdiParent = mdiParent;
                    _Frmpol_Dm_User_Add.Show();
                    _Frmpol_Dm_User_Add.Activate();
                    break;

                //case "Frmpol_Dm_Role_Add":
                //    _Frmpol_Dm_Role_Add = (Ecm.SystemControl.Policy.Forms.Frmpol_Dm_Role_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmpol_Dm_Role_Add");

                //    if (_Frmpol_Dm_Role_Add == null || _Frmpol_Dm_Role_Add.IsDisposed)
                //        _Frmpol_Dm_Role_Add = new Ecm.SystemControl.Policy.Forms.Frmpol_Dm_Role_Add();
                //    _Frmpol_Dm_Role_Add.Text = formText;
                //    _Frmpol_Dm_Role_Add.MdiParent = mdiParent;
                //    _Frmpol_Dm_Role_Add.Show();
                //    _Frmpol_Dm_Role_Add.Activate();
                //    break;

                //case "Frmpol_Dm_Right_Add":
                //    _Frmpol_Dm_Right_Add = (Ecm.SystemControl.Policy.Forms.Frmpol_Dm_Right_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmpol_Dm_Right_Add");

                //    if (_Frmpol_Dm_Right_Add == null || _Frmpol_Dm_Right_Add.IsDisposed)
                //        _Frmpol_Dm_Right_Add = new Ecm.SystemControl.Policy.Forms.Frmpol_Dm_Right_Add();
                //    _Frmpol_Dm_Right_Add.Text = formText;
                //    _Frmpol_Dm_Right_Add.MdiParent = mdiParent;
                //    _Frmpol_Dm_Right_Add.Show();
                //    _Frmpol_Dm_Right_Add.Activate();
                //    break;

                //case "Frmpol_Dm_Action_Add":
                //    _Frmpol_Dm_Action_Add = (Ecm.SystemControl.Policy.Forms.Frmpol_Dm_Action_Add) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmpol_Dm_Action_Add");

                //    if (_Frmpol_Dm_Action_Add == null || _Frmpol_Dm_Action_Add.IsDisposed)
                //        _Frmpol_Dm_Action_Add = new Ecm.SystemControl.Policy.Forms.Frmpol_Dm_Action_Add();
                //    _Frmpol_Dm_Action_Add.Text = formText;
                //    _Frmpol_Dm_Action_Add.MdiParent = mdiParent;
                //    _Frmpol_Dm_Action_Add.Show();
                //    _Frmpol_Dm_Action_Add.Activate();
                //    break;

                case "Frmpol_Change_Password":
                    _Frmpol_Change_Password = ( GoobizFrame.Windows.Forms.Policy.Frmpol_Change_Password) GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmpol_Change_Password");

                    if (_Frmpol_Change_Password == null || _Frmpol_Change_Password.IsDisposed)
                        _Frmpol_Change_Password = new  GoobizFrame.Windows.Forms.Policy.Frmpol_Change_Password();
                    _Frmpol_Change_Password.Text = formText;
                    _Frmpol_Change_Password.MdiParent = mdiParent;
                    _Frmpol_Change_Password.Show();
                    _Frmpol_Change_Password.Activate();
                    break;

                case "Frmpol_MainProcess1":
                    pol = (Forms.Frmpol_MainProcess1)GoobizFrame.Windows.MdiUtils.MdiChecker.GetMdiChilden(mdiParent, "Frmpol_MainProcess1");

                    if (pol == null || pol.IsDisposed)
                        pol = new Forms.Frmpol_MainProcess1();
                    pol.Text = formText;
                    pol.MdiParent = mdiParent;
                    pol.Show();
                    pol.Activate();
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
		{
            get{ return m_strName; }
            set{ m_strName = value; }
        }

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
            new System.Threading.Thread(new System.Threading.ThreadStart(this.PreLoadThread)).Start();
        }

        void PreLoadThread()
        {
            lock (this)
            {
                _Frmpol_Dm_User_Add = new  GoobizFrame.Windows.Forms.Policy.Frmpol_Dm_User_Add();
                _Frmpol_Dm_User_Add.Dispose();
                _Frmpol_Change_Password = new  GoobizFrame.Windows.Forms.Policy.Frmpol_Change_Password();
                _Frmpol_Change_Password.Dispose();

                DataLoaded = true;
            }
        }
        #endregion
    }
}
